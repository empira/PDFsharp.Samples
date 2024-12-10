// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace HelloMigraDoc
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

            // Create a MigraDoc document.
            var document = Documents.CreateDocument();

            // Write MigraDoc DDL to a file.
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            // Create a renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer
            {
                // Associate the MigraDoc document with a renderer.
                Document = document,
                PdfDocument =
                {
                    // Change some settings before rendering the MigraDoc document.
                    PageLayout = PdfPageLayout.SinglePage,
                    ViewerPreferences =
                    {
                        FitWindow = true
                    }
                }
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFullFileName("samples-MigraDoc/HelloMigraDoc.pdf");
            pdfRenderer.PdfDocument.Save(filename);

            // ...and start a viewer.
            PdfFileUtility.ShowDocument(filename);
        }
    }
}
