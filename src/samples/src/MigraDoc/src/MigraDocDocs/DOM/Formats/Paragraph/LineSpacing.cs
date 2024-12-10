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
    /// "Line spacing" chapter.
    /// </summary>
    static class LineSpacing
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Paragraph";

        const string Filename = $"{Path}/LineSpacing.pdf";
        const string SampleName = "Line spacing";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(24);

            const string dummyTextStyleName = "DummyText";
            style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            const string biggerTextStyleName = "BiggerText";
            style = document.Styles.AddStyle(biggerTextStyleName, StyleNames.Normal);
            style.Font.Size = Unit.FromPoint(18);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Single line spacing sample

            var paragraph = section.AddParagraph("This is a 12 pt paragraph with a Single line spacing. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);
            paragraph.AddFormattedText("This sentence is 18 pt.", biggerTextStyleName);
            paragraph.AddFormattedText(" Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            var format = paragraph.Format;

            // Set LineSpacingRule to Single.
            format.LineSpacingRule = LineSpacingRule.Single;

            // -- OnePtFive line spacing sample

            paragraph = section.AddParagraph("This is a 12 pt paragraph with a OnePtFive line spacing. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);
            paragraph.AddFormattedText("This sentence is 18 pt.", biggerTextStyleName);
            paragraph.AddFormattedText(" Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set LineSpacingRule to OnePtFive.
            format.LineSpacingRule = LineSpacingRule.OnePtFive;

            // -- Double line spacing sample

            paragraph = section.AddParagraph("This is a 12 pt paragraph with a Double line spacing. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);
            paragraph.AddFormattedText("This sentence is 18 pt.", biggerTextStyleName);
            paragraph.AddFormattedText(" Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set LineSpacingRule to Double.
            format.LineSpacingRule = LineSpacingRule.Double;

            // -- Multiple line spacing sample

            paragraph = section.AddParagraph("This is a 12 pt paragraph with a Multiple line spacing of 2.5. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);
            paragraph.AddFormattedText("This sentence is 18 pt.", biggerTextStyleName);
            paragraph.AddFormattedText(" Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set LineSpacingRule to Multiple.
            format.LineSpacingRule = LineSpacingRule.Multiple;
            // Set LineSpacing to 2.5 (which is the factor, when using Multiple).
            format.LineSpacing = 2.5;

            // -- AtLeast line spacing sample

            paragraph = section.AddParagraph("This is a 12 pt paragraph with a line spacing of at least 15 pt. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);
            paragraph.AddFormattedText("This sentence is 18 pt.", biggerTextStyleName);
            paragraph.AddFormattedText(" Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set LineSpacingRule to AtLeast.
            format.LineSpacingRule = LineSpacingRule.AtLeast;
            // Set LineSpacing to 15 pt.
            format.LineSpacing = Unit.FromPoint(15);

            // -- Exactly line spacing sample

            paragraph = section.AddParagraph("This is a 12 pt paragraph with a line spacing of exactly 15 pt. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);
            paragraph.AddFormattedText("This sentence is 18 pt.", biggerTextStyleName);
            paragraph.AddFormattedText(" Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set LineSpacingRule to Exactly.
            format.LineSpacingRule = LineSpacingRule.Exactly;
            // Set LineSpacing to 15 pt.
            format.LineSpacing = Unit.FromPoint(15);

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
