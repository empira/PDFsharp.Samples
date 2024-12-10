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
    /// "Introduction" chapter.
    /// </summary>
    static class WrappingContent
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/TextFrames";
        
        const string Filename = $"{Path}/WrappingContent.pdf";
        const string SampleName = "Wrapping content";

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

            // -- TextFrame with text
            {
                // Add a TextFrame.
                var textFrame = section.AddTextFrame();
                textFrame.FillFormat.Color = Colors.Cyan;

                // Add some text.
                textFrame.AddParagraph("A simple TextFrame");
            }

            // -- TextFrame with image
            {
                // Add a TextFrame.
                var textFrame = section.AddTextFrame();
                textFrame.Width = Unit.FromCentimeter(5);
                textFrame.Height = Unit.FromCentimeter(5);
                textFrame.Top = Unit.FromCentimeter(1);
                textFrame.FillFormat.Color = Colors.Cyan;

                // Load image from relative path.
                textFrame.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
            }
            
            // -- TextFrame with table
            {
                // Add a TextFrame.
                var textFrame = section.AddTextFrame();
                textFrame.Width = Unit.FromCentimeter(5);
                textFrame.Height = Unit.FromCentimeter(5);
                textFrame.Top = Unit.FromCentimeter(1);
                textFrame.FillFormat.Color = Colors.Cyan;

                // Add a table.
                var table = textFrame.AddTable();
                table.Borders.Visible = true;

                // Make table align at border, not at content.
                table.LeftPadding = Unit.Zero;

                // Add table content
                table.AddColumn();
                table.AddColumn();
                var row = table.AddRow();
                row[0].AddParagraph("Column 1");
                row[1].AddParagraph("Column 2");
                row = table.AddRow();
                row[0].AddParagraph("Value 1");
                row[1].AddParagraph("Value 2");
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
