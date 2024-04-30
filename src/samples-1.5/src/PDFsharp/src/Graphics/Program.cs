// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace Graphics
{
    /// <summary>
    /// This sample shows some of the capabilities of the XGraphcis class.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Create a temporary file by creating a file stream.
            string filename = PdfFileUtility.GetTempPdfFullFileName("samples-1.5/Graphics");
            Document = new PdfDocument(filename);
            Document.Info.Title = "PDFsharp XGraphic Sample";
            Document.Info.Author = "Stefan Lange";
            Document.Info.Subject = "Created with code snippets that show the use of graphical functions";
            Document.Info.Keywords = "PDFsharp, XGraphics";

            // Show a single page.
            Document.PageLayout = PdfPageLayout.SinglePage;

            // Let the viewer application fit the page in the windows.
            Document.ViewerPreferences.FitWindow = true;

            // Create demonstration pages.
            new LinesAndCurves().DrawPage(Document.AddPage());
            new Shapes().DrawPage(Document.AddPage());
            new Paths().DrawPage(Document.AddPage());
            new Text().DrawPage(Document.AddPage());
            new Images().DrawPage(Document.AddPage());

            // Save the document by closing the stream...
            Document.Close();
            // ...and start a viewer.
            PdfFileUtility.ShowDocument(filename);
        }

        // ReSharper disable once InconsistentNaming
        internal static PdfDocument Document { get; private set; } = default!;
    }
}
