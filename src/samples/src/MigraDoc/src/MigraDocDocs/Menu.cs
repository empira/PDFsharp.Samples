// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;

namespace MigraDocDocs
{
    class Menu
    {
        const char SelectAllCharacter = ' ';
        const ConsoleKey SelectAllKey = ConsoleKey.Spacebar;
        const string SelectAllKeyName = "'space'";

        static readonly char? ReturnCharacter = null;
        const ConsoleKey ReturnKey = ConsoleKey.Backspace;
        const string ReturnKeyName = "'backspace'";

        public static int MaxShowDocumentIfDebugging { get; set; } = 5;

        public Menu(string heading, List<(char? Key, string Name, Action<AutomaticGeneration?> Action)> options, string optionsType, AutomaticGeneration? automaticGeneration, bool allowReturn = true)
            : this(heading, options, optionsType, automaticGeneration, null, allowReturn)
        { }

        public Menu(string heading, List<(char? Key, string Name, Action<AutomaticGeneration?> Action)> options, string optionsType, AutomaticGeneration? automaticGeneration, string? instruction, bool allowReturn = true)
        {
            _heading = heading;
            _options = options;
            _automaticGeneration = automaticGeneration;
            _allowReturn = allowReturn;

            if (instruction == null)
            {
                instruction = $"Choose a {optionsType} or press {SelectAllKeyName} for all";
                if (allowReturn)
                    instruction += $" or {ReturnKeyName} to return";
                instruction += ":";
            }
            _instruction = instruction;
        }

        public void Enter()
        {
            // Stay in menu.
            while (true)
            {
                char? choice;

                var isAutomaticGeneration = _automaticGeneration != null;

                if (isAutomaticGeneration)
                    choice = SelectAllCharacter;
                else
                    choice = Draw();

                // Return from menu, if chosen.
                if (_allowReturn && choice == ReturnCharacter)
                    return;

                // Start new AutomaticGeneration, if all is selected.
                var automaticGeneration = _automaticGeneration ?? (choice == SelectAllCharacter ? new AutomaticGeneration(this) : null);

                isAutomaticGeneration = automaticGeneration != null;

                // Invoke each chosen option’s action.
                foreach (var option in _options)
                {
                    if (choice == option.Key || isAutomaticGeneration)
                        option.Action.Invoke(automaticGeneration);
                }

                if (isAutomaticGeneration)
                {
                    // End automatic generation, if started in this menu.
                    if (automaticGeneration!.IsCalledFromMenu(this))
                    {
                        HandleResults(automaticGeneration.GetResultFiles());
                    }
                    // Return from menu, if automatic generation was started on an upper layer.
                    else
                        return;
                }
            }
        }

        char? Draw()
        {
            var validKeys = _options.Select(o => o.Key).Where(k => k.HasValue).Select(k => k!.Value).ToList();

            Console.Clear();
            Console.WriteLine(_heading);
            Console.WriteLine();
            Console.WriteLine(_instruction);
            Console.WriteLine();


            foreach (var option in _options)
            {
                var str = " ";

                if (option.Key.HasValue)
                    str += option.Key + ")";
                else
                    str += "--";

                str += $" {option.Name}";
                Console.WriteLine(str);
            }

            Console.WriteLine();

            while (true)
            {
                var key = Console.ReadKey();
                var keyChar = key.KeyChar;
                Console.WriteLine();
                Console.WriteLine();

                if (_allowReturn && key.Key == ReturnKey)
                    return null;
                if (key.Key == SelectAllKey)
                    return SelectAllCharacter;
                if (validKeys.Contains(keyChar))
                    return keyChar;

                var message = $"Invalid choice. Please press {String.Join(", ", validKeys)} or {SelectAllKeyName} for all";
                if (_allowReturn)
                    message += $" or {ReturnKeyName} to return";
                message += ".";

                Console.WriteLine(message);
                Console.WriteLine();
            }
        }

        public static void HandleResult(string resultFile)
        {
            HandleResults([resultFile]);
        }

        public static void HandleResults(ICollection<string> resultFiles)
        {
            var count = resultFiles.Count;
            var fileOrFiles = count == 1 ? "file" : "files";
            Console.WriteLine($"Created {count} result {fileOrFiles}.");
            Console.WriteLine();

            var showResultFiles = false;
            var userActionTookPlace = false;
            if (Debugger.IsAttached)
            {
                if (count <= MaxShowDocumentIfDebugging)
                    showResultFiles = true;
                else
                {
                    showResultFiles = AskYesAndConfirm($"There are more than {MaxShowDocumentIfDebugging} result files. Do you want to open them?",
                        "This could compromise your system responsiveness.");
                    userActionTookPlace = true;
                    Console.WriteLine();
                }
            }

            if (showResultFiles)
            {
                foreach (var resultFile in resultFiles)
                {
                    // Start a viewer.
                    Helper.ShowDocumentIfDebugging(resultFile);
                }
            }

            // If no user action took place, give the user some time to read, before the menu is refreshed.
            if (!userActionTookPlace)
                Thread.Sleep(3000);
        }

        static bool AskYes(string question)
        {
            return AskOneKey(question, "Press 'y' for 'yes' or another key to cancel.", ConsoleKey.Y);
        }

        static bool AskYesAndConfirm(string question, string warning)
        {
            if (!AskYes(question))
                return false;

            Console.WriteLine();

            return AskOneKey(warning, "Press 'c' to confirm or another key to cancel.", ConsoleKey.C);
        }

        static bool AskOneKey(string question, string prompt, ConsoleKey key)
        {
            Console.WriteLine($"{question} {prompt}");

            var readKey = Console.ReadKey();
            var result = readKey.Key == key;
            Console.WriteLine();
            return result;
        }

        readonly string _heading;
        readonly List<(Char? Key, String Name, Action<AutomaticGeneration?> Action)> _options;
        readonly AutomaticGeneration? _automaticGeneration;
        readonly string? _instruction;
        readonly bool _allowReturn;
    }
}