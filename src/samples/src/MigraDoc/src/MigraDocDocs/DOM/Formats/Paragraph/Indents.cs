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
    /// Indents chapter.
    /// </summary>
    static class Indents
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Paragraph";

        const string Filename = $"{Path}/Indents.pdf";
        const string SampleName = "Indents";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Set alignment to Justify for better indent recognition.
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;

            const string dummyTextStyleName = "DummyText";
            style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            const string dummyText = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod " +
                                     "tempor invidunt ut labore.";

            var paragraph = section.AddParagraph("This is a paragraph without any indent assigned. ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);

            // -- Left indent sample

            paragraph = section.AddParagraph("This is a paragraph with a left indent of 2 cm. ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);
            var format = paragraph.Format;

            // Set left indent to 2 cm.
            format.LeftIndent = Unit.FromCentimeter(2);

            // -- First line indent sample

            paragraph = section.AddParagraph("This is a paragraph with a first line indent of 2 cm. ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);
            format = paragraph.Format;

            // Set first line indent to 2 cm.
            format.FirstLineIndent = Unit.FromCentimeter(2);

            // -- Right indent sample

            paragraph = section.AddParagraph("This is a paragraph with a right indent of 2 cm. ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);
            format = paragraph.Format;

            // Set right indent to 2 cm.
            format.RightIndent = Unit.FromCentimeter(2);

            // -- All indents sample

            paragraph = section.AddParagraph("This is a paragraph with a left and right indent of 2 cm and" +
                                             " a first line intend of 1 cm, which is added to the left indent for the first line. ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);
            format = paragraph.Format;

            // Set left indent to 2 cm.
            format.LeftIndent = Unit.FromCentimeter(2);

            // Set right indent to 2 cm.
            format.RightIndent = Unit.FromCentimeter(2);

            // Set first line indent to 1 cm.
            format.FirstLineIndent = Unit.FromCentimeter(1);

            // -- Negative indents sample

            paragraph = section.AddParagraph("This is a paragraph with a left and right indent of -1 cm and" +
                                             " a first line intend of -0.5 cm, which is added to the left indent for the first line. ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);
            format = paragraph.Format;

            // Set left indent to -1 cm.
            format.LeftIndent = Unit.FromCentimeter(-1);

            // Set right indent to -1 cm.
            format.RightIndent = Unit.FromCentimeter(-1);

            // Set first line indent to -0.5 cm.
            format.FirstLineIndent = Unit.FromCentimeter(-0.5);

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
