// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

namespace MigraDocDocs
{
    class Program
    {
        static void Main()
        {
            Helper.CreateTargetPaths();

            AutomaticGeneration? automaticGeneration = null;

            Menus.Menu(automaticGeneration);

            if (automaticGeneration != null)
                Menu.HandleResults(automaticGeneration.GetResultFiles());
        }
    }
}