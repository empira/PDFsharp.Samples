// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using PdfSharp.Quality;
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Contents.TextFrames
{
    /// <summary>
    /// "Margins" chapter.
    /// </summary>
    static class Margins
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/TextFrames";
        
        const string Filename = $"{Path}/Margins.pdf";
        const string SampleName = "Margins";

        public static string Sample()
        {
            // --- Code needed for sample

            // Ensure that assets folder exists.
            // '.\dev\download-assets.ps1' in solution root directory has to be executed before running this sample.
            IOUtility.EnsureAssets();

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- TextFrame with various margins
            {
                // Add a TextFrame.
                var textFrame = section.AddTextFrame();
                textFrame.Top = Unit.FromCentimeter(1);
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(6);
                textFrame.FillFormat.Color = Colors.Cyan;

                // Set the margins.
                textFrame.MarginTop = Unit.FromCentimeter(0.5);
                textFrame.MarginRight = Unit.FromCentimeter(1);
                textFrame.MarginBottom = Unit.FromCentimeter(1.5);
                textFrame.MarginLeft = Unit.FromCentimeter(2);

                // Add some text.
                textFrame.AddParagraph("A TextFrame with various margins");
            }

            // -- TextFrame with a margin
            {
                // Add a TextFrame.
                var textFrame = section.AddTextFrame();
                textFrame.Top = Unit.FromCentimeter(1);
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(6);
                textFrame.FillFormat.Color = Colors.Cyan;

                // Set a margin.
                textFrame.Margin = Unit.FromCentimeter(1);

                // Add some text.
                textFrame.AddParagraph("A TextFrame with 1 cm margin");
            }

            // --- Rendering

            // Create a renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer
            {
                // Associate the MigraDoc document with a renderer.
                Document = document,
                // Let the PDF viewer show this PDF with full pages.
                PdfDocument =
                {
                    PageLayout = PdfPageLayout.SinglePage,
                    ViewerPreferences =
                    {
                        FitWindow = true
                    }
                }
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
