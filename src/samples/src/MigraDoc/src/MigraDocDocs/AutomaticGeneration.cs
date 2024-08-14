// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

namespace MigraDocDocs
{
    class AutomaticGeneration
    {
        public AutomaticGeneration(Menu? callingMenu)
        {
            _callingMenu = callingMenu;
        }

        public bool IsCalledFromMenu(Menu menu)
        {
            return _callingMenu == menu;
        }

        public void AddResultFile(string resultFile)
        {
            if (!_resultFiles.Add(resultFile))
                throw new InvalidOperationException("The filenames of the samples must be unique.");
        }

        public void HandleResults()
        {
            foreach (var resultFile in _resultFiles)
            {
                // Start a viewer.
                Helper.ShowDocumentIfDebugging(resultFile);
            }
        }

        readonly Menu? _callingMenu;

        // Initialize _resultFiles as HashSet, as it must not contain filename duplicates.
        readonly HashSet<string> _resultFiles = [];
    }
}