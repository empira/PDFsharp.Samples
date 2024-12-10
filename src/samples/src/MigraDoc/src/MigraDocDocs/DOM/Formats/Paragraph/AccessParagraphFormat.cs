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

namespace MigraDocDocs.DOM.Formats.Paragraph
{
    /// <summary>
    /// "Access the ParagraphFormat object" chapter.
    /// </summary>
    static class AccessParagraphFormat
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Paragraph";

        const string Filename = $"{Path}/AccessParagraphFormat.pdf";
        const string SampleName = "Access ParagraphFormat";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            var style = document.Styles[StyleNames.Normal];

            // Access the ParagraphFormat object of a Style. 
            style.ParagraphFormat.Alignment = ParagraphAlignment.Right;

            // Add a section to the document.
            var section = document.AddSection();

            var paragraph = section.AddParagraph("Sample text");

            // Access the ParagraphFormat object of a Paragraph.
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // The alignment for the Paragraph is set two times in this example, just to show the different ways to access a ParagraphFormat object.
            // Directly assigned values (here on paragraph) override values inherited from the style (Normal).
            // Therefore, Center is the actually used alignment value.

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
