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

namespace MigraDocDocs.DOM.Document_.Formatting
{
    /// <summary>
    /// Styles chapter.
    /// </summary>
    static class DefaultStyle
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/Formatting";

        const string Filename = $"{Path}/DefaultStyle.pdf";
        const string SampleName = "Default style";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Set font Size and SpaceBefore for Heading1 style.
            var style = document.Styles[StyleNames.Heading1];
            style.Font.Size = Unit.FromPoint(20);
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(7);

            // Add a section to the document.
            var section = document.AddSection();

            // Add a heading to the section. Note that SpaceBefore is ignored for the first paragraph of a page.
            var paragraph = section.AddParagraph("First heading");
            // Use Heading1 style for paragraph.
            paragraph.Style = StyleNames.Heading1;

            section.AddParagraph("First content");

            // Add another heading to the section.
            paragraph = section.AddParagraph("Second heading");
            // Use Heading1 style for paragraph.
            paragraph.Style = StyleNames.Heading1;

            section.AddParagraph("Second content");

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
