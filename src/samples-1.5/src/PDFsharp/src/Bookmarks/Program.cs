// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace Bookmarks
{
    /// <summary>
    /// This sample shows how to create bookmarks. Bookmarks are called outlines
    /// in the PDF reference manual, that's why you deal with the class PdfOutline.
    /// </summary>
    class Program
    {
        static void Main()
        {
#if CORE
            // Core build does not use Windows fonts, so set a FontResolver that handles the fonts our samples need.
            GlobalFontSettings.FontResolver = new SamplesFontResolver();
#endif

            // Create a new PDF document.
            var document = new PdfDocument();
            document.PageLayout = PdfPageLayout.SinglePage;
            document.ViewerPreferences.FitWindow = true;

            // Create a font.
            var font = new XFont("Verdana", 16);

            // Create first page.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            gfx.DrawString("Page 1", font, XBrushes.Black, 20, 50, XStringFormats.Default);

            // Create the root bookmark. You can set the style and the color.
            var outline = document.Outlines.Add("Root", page, true, PdfOutlineStyle.Bold, XColors.Red);

            // Create some more pages.
            for (int idx = 2; idx <= 5; idx++)
            {
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);

                string text = "Page " + idx;
                gfx.DrawString(text, font, XBrushes.Black, 20, 50, XStringFormats.Default);

                // Create a sub bookmark.
                outline.Outlines.Add(text, page, true);
            }

            // Save the document...
            string filename = PdfFileUtility.GetTempPdfFullFileName("samples-1.5/Bookmarks");
            document.Save(filename);
            // ...and start a viewer.
            PdfFileUtility.ShowDocument(filename);
        }
    }
}
