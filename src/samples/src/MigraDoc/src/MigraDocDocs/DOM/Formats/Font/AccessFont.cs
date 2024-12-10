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

namespace MigraDocDocs.DOM.Formats.Font
{
    /// <summary>
    /// "Access the Font object" chapter.
    /// </summary>
    static class AccessFont
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Font";

        const string Filename = $"{Path}/AccessFont.pdf";
        const string SampleName = "Access font";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            var style = document.Styles[StyleNames.Normal];

            // Access the Font object of a Style. 
            style.ParagraphFormat.Font.Size = Unit.FromPoint(11);

            // Access the Font object of a Style using a shortcut.
            style.Font.Size = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            var paragraph = section.AddParagraph();

            // Access the Font object of a Paragraph.
            paragraph.Format.Font.Size = Unit.FromPoint(13);

            var formattedText = paragraph.AddFormattedText("Sample text");

            // Access the Font object of a FormattedText.
            formattedText.Font.Size = Unit.FromPoint(14);

            // Access a Font object’s property of a FormattedText using a shortcut.
            formattedText.Size = Unit.FromPoint(15);

            // The size for the FormattedText is set five times in this example, just to show the different ways to access a Font object.
            // Directly assigned values (here on formattedText) override values inherited from the parent (paragraph) and from the style (Normal).
            // The last assignment overrides the value directly set for the formattedText.
            // Therefore, 15 pt is the actually used size.

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
