// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.Rendering;
using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace HelloMigraDoc
{
    class Program
    {
        static void Main()
        {
            // Create a MigraDoc document.
            var document = Documents.CreateDocument();

            // Write MigraDoc DDL into a string.
            var ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);

            // Write MigraDoc DDL to a file.
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

#if true
            var renderer = new PdfDocumentRenderer
            {
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
#else
            var renderer = new PdfDocumentRenderer();
            renderer.Document = document;
            // Change some settings before rendering the MigraDoc document.
            renderer.PdfDocument.PageLayout = PdfPageLayout.SinglePage;
            renderer.PdfDocument.ViewerPreferences.FitWindow = true;
#endif

            renderer.RenderDocument();

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFullFileName("samples-MigraDoc/HelloMigraDoc.pdf");
            renderer.PdfDocument.Save(filename);

            // ...and start a viewer.
            PdfFileUtility.ShowDocument(filename);
        }
    }
}
