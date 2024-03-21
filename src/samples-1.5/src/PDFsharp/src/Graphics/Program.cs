// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;

namespace Graphics
{
    /// <summary>
    /// This sample shows some of the capabilities of the XGraphcis class.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // NET6FIX
            if (Capabilities.Build.IsCoreBuild)
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();

            // Create a temporary file.
            string filename = PdfFileUtility.GetTempPdfFullFileName("samples-1.5/Graphics");
            s_document = new PdfDocument();
            s_document.Info.Title = "PDFsharp XGraphic Sample";
            s_document.Info.Author = "Stefan Lange";
            s_document.Info.Subject = "Created with code snippets that show the use of graphical functions";
            s_document.Info.Keywords = "PDFsharp, XGraphics";

            // Create demonstration pages.
            new LinesAndCurves().DrawPage(s_document.AddPage());
            new Shapes().DrawPage(s_document.AddPage());
            new Paths().DrawPage(s_document.AddPage());
            new Text().DrawPage(s_document.AddPage());
            new Images().DrawPage(s_document.AddPage());

            // Save the s_document...
            s_document.Save(filename);
            // ...and start a viewer.
            PdfFileUtility.ShowDocument(filename);
        }

        // ReSharper disable once InconsistentNaming
        internal static PdfDocument s_document = null!;
    }
}
