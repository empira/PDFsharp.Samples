// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using PdfSharp.Fonts;
using PdfSharp.Quality;

namespace MigraDocDocs
{
    class Program
    {
        static void Main()
        {
#if CORE
            // Core build does not use Windows fonts,
            // so set a FontResolver that handles the fonts our samples need.
            GlobalFontSettings.FontResolver = new SamplesFontResolver();
#endif

            Helper.CreateTargetPaths();

            AutomaticGeneration? automaticGeneration = null;

            Menus.Menu(automaticGeneration);

            if (automaticGeneration != null)
                Menu.HandleResults(automaticGeneration.GetResultFiles());
        }
    }
}