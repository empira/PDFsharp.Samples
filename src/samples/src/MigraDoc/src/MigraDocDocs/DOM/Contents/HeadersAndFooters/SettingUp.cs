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
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Contents.HeadersAndFooters
{
    /// <summary>
    /// "Setting up headers & footers", "Scope of headers & footers" and "Presenting various information" chapters.
    /// </summary>
    static class SettingUp
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/HeadersAndFooters";
        
        const string Filename = $"{Path}/SettingUp.pdf";
        const string SampleName = "Setting up";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Style for header.
            var style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            // Style for footer.
            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.ClearAll();
            style.ParagraphFormat.TabStops.AddTabStop(Unit.FromCentimeter(8), TabAlignment.Center);
            style.ParagraphFormat.TabStops.AddTabStop(Unit.FromCentimeter(16), TabAlignment.Right);

            // -- First section
            {
                // Add a first section to the document.
                var section = document.AddSection();

                // Set up header.
                var header = section.Headers.Primary;
                header.AddParagraph("Test document");

                // Set up footer.
                var footer = section.Footers.Primary;
                var paragraph = footer.AddParagraph("\tSection one\t");
                paragraph.AddPageField();

                // Add section content.
                section.AddParagraph("Content of first section first page");
                section.AddPageBreak();
                section.AddParagraph("Content of first section second page");
                section.AddPageBreak();
                section.AddParagraph("Content of first section third page");
            }

            // -- Second section
            {
                // Add a second section to the document.
                var section = document.AddSection();

                // No header is set here, so the header is copied from the previous section.

                // If no footer is set here, the footer will be copied from the previous section.
                // Overwrite the inherited footer with an empty one.
                section.Footers.Primary = new HeaderFooter();

                // Add section content.
                section.AddParagraph("Content of second section first page");
                section.AddPageBreak();
                section.AddParagraph("Content of second section second page");
                section.AddPageBreak();
                section.AddParagraph("Content of second section third page");
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
