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

namespace MigraDocDocs.DOM.Formats
{
    static class Paragraph
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Paragraph";

        /// <summary>
        /// Introduction chapter.
        /// </summary>
        public static string AccessParagraphFormat()
        {
            const string filename = $"{Path}/AccessParagraphFormat.pdf";
            const string sampleName = "Access ParagraphFormat";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }
        
        /// <summary>
        /// Alignment chapter.
        /// </summary>
        public static string Alignment()
        {
            const string filename = $"{Path}/Alignment.pdf";
            const string sampleName = "Alignment";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Left alignment sample

            var paragraph = section.AddParagraph("This is a left aligned paragraph.");
            var format = paragraph.Format;

            // Set the paragraph alignment to Left.
            format.Alignment = ParagraphAlignment.Left;

            // -- Center alignment sample

            paragraph = section.AddParagraph("This is a center aligned paragraph.");
            format = paragraph.Format;

            // Set the paragraph alignment to Center.
            format.Alignment = ParagraphAlignment.Center;

            // -- Right alignment sample

            paragraph = section.AddParagraph("This is a right aligned paragraph.");
            format = paragraph.Format;

            // Set the paragraph alignment to Right.
            format.Alignment = ParagraphAlignment.Right;

            // -- Justified alignment sample

            paragraph = section.AddParagraph("This is a justified paragraph.");
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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "Space before & space after" chapter.
        /// </summary>
        public static string SpaceBeforeAndAfter()
        {
            const string filename = $"{Path}/SpaceBeforeAndAfter.pdf";
            const string sampleName = "Space before & space after";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();
            
            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- SpaceBefore ignored sample

            var paragraph = section.AddParagraph("This paragraph has a SpaceBefore of 10 cm defined, " +
                                                 "but SpaceBefore is always ignored for the first paragraph of a page.");
            var format = paragraph.Format;

            // Set SpaceBefore.
            format.SpaceBefore = Unit.FromCentimeter(10);

            // -- SpaceBefore sample

            paragraph = section.AddParagraph("This paragraph has a SpaceBefore of 20 pt defined.");
            format = paragraph.Format;

            // Set SpaceBefore.
            format.SpaceBefore = Unit.FromPoint(20);

            // -- SpaceAfter sample

            paragraph = section.AddParagraph("This paragraph has a SpaceAfter of 20 pt defined.");
            format = paragraph.Format;

            // Set SpaceAfter.
            format.SpaceAfter = Unit.FromPoint(20);

            // -- No SpaceBefore and SpaceAfter sample

            section.AddParagraph("This paragraph has no SpaceBefore and SpaceAfter defined. " +
                                 "But due to the last paragraph’s SpaceAfter and the next paragraph’s SpaceBefore, " +
                                 "there is actually space before and after this paragraphs, as the bigger values win.");

            // -- SpaceBefore and SpaceAfter sample

            paragraph = section.AddParagraph("This paragraph has a SpaceBefore of 10 pt and a SpaceAfter of 20 pt defined.");
            format = paragraph.Format;

            // Set SpaceBefore and SpaceAfter.
            format.SpaceBefore = Unit.FromPoint(10);
            format.SpaceAfter = Unit.FromPoint(20);

            paragraph = section.AddParagraph("This paragraph has also a SpaceBefore of 10 pt and a SpaceAfter of 20 pt defined. " +
                                             "Due to the last paragraph’s SpaceAfter, there is actually space of 20 pt before it, as the bigger value wins.");
            format = paragraph.Format;

            // Set SpaceBefore and SpaceAfter.
            format.SpaceBefore = Unit.FromPoint(10);
            format.SpaceAfter = Unit.FromPoint(20);

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// Indents chapter.
        /// </summary>
        public static string Indents()
        {
            const string filename = $"{Path}/Indents.pdf";
            const string sampleName = "Indents";

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

            var paragraph = section.AddParagraph("This is a paragraph without any indent assigned. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);

            // -- Left indent sample

            paragraph = section.AddParagraph("This is a paragraph with a left indent of 2 cm. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            var format = paragraph.Format;

            // Set left indent to 2 cm.
            format.LeftIndent = Unit.FromCentimeter(2);

            // -- First line indent sample

            paragraph = section.AddParagraph("This is a paragraph with a first line indent of 2 cm. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set first line indent to 2 cm.
            format.FirstLineIndent = Unit.FromCentimeter(2);

            // -- Right indent sample

            paragraph = section.AddParagraph("This is a paragraph with a right indent of 2 cm. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            format = paragraph.Format;

            // Set right indent to 2 cm.
            format.RightIndent = Unit.FromCentimeter(2);

            // -- All indents sample

            paragraph = section.AddParagraph("This is a paragraph with a left and right indent of 2 cm and" +
                                             " a first line intend of 1 cm, which is added to the left indent for the first line. ");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
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
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "Line spacing" chapter.
        /// </summary>
        public static string LineSpacing()
        {
            const string filename = $"{Path}/LineSpacing.pdf";
            const string sampleName = "Line spacing";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }
    }
}
