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
    /// "Superscript & subscript" chapter.
    /// </summary>
    static class SuperscriptAndSubscript
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Font";

        const string Filename = $"{Path}/SuperscriptAndSubscript.pdf";
        const string SampleName = "Superscript & subscript";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Superscript sample

            var paragraph = section.AddParagraph("Using superscript: 5");
            var formattedText = paragraph.AddFormattedText("2");

            // Set formattedText font to Superscript.
            formattedText.Font.Superscript = true;

            paragraph.AddText(" = 25");

            // -- Subscript sample

            paragraph = section.AddParagraph("Using subscript: CO");
            formattedText = paragraph.AddFormattedText("2");

            // Set formattedText font to Subscript.
            formattedText.Font.Subscript = true;

            paragraph.AddText(" is a greenhouse gas.");

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
