// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

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
                        automaticGeneration.HandleResults();
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

                Console.WriteLine();
                Console.WriteLine(message);
                Console.WriteLine();
            }

        }

        readonly string _heading;
        readonly List<(Char? Key, String Name, Action<AutomaticGeneration?> Action)> _options;
        readonly AutomaticGeneration? _automaticGeneration;
        readonly string? _instruction;
        readonly bool _allowReturn;
    }
}