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
    /// Alignment chapter.
    /// </summary>
    static class Alignment
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Paragraph";

        const string Filename = $"{Path}/Alignment.pdf";
        const string SampleName = "Alignment";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            const string dummyTextStyleName = "DummyText";
            style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Left alignment sample

            var paragraph = section.AddParagraph("This is a left aligned paragraph. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            var format = paragraph.Format;

            // Set the paragraph alignment to Left.
            format.Alignment = ParagraphAlignment.Left;

            // -- Center alignment sample

            paragraph = section.AddParagraph("This is a center aligned paragraph. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set the paragraph alignment to Center.
            format.Alignment = ParagraphAlignment.Center;

            // -- Right alignment sample

            paragraph = section.AddParagraph("This is a right aligned paragraph. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set the paragraph alignment to Right.
            format.Alignment = ParagraphAlignment.Right;

            // -- Justified alignment sample

            paragraph = section.AddParagraph("This is a justified paragraph. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set the paragraph alignment to Justify.
            format.Alignment = ParagraphAlignment.Justify;

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
