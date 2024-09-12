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

namespace MigraDocDocs.DOM.Contents.Lists
{
    /// <summary>
    /// Indents chapter.
    /// </summary>
    static class Indents
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Lists";
        
        const string Filename = $"{Path}/Indents.pdf";
        const string SampleName = "Indents";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();
            
            const string dummyTextStyleName = "DummyText";
            var style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            // --- Sample content

            // Style for list level 1
            const string listLevel1StyleName = "ListLevel1";
            style = document.Styles.AddStyle(listLevel1StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.BulletList1;
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(0.5);
            style.ParagraphFormat.FirstLineIndent = Unit.FromCentimeter(-0.5);
            // The bullet is at the left margin (LeftIndent + FirstLineIndent).
            // This equals NumberPosition = Unit.Zero.

            // Style for list level 2
            const string listLevel2StyleName = "ListLevel2";
            style = document.Styles.AddStyle(listLevel2StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.BulletList2;
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(1);
            style.ParagraphFormat.FirstLineIndent = Unit.FromCentimeter(-0.5);
            // The bullet is 0.5 cm from left margin (LeftIndent + FirstLineIndent).
            style.ParagraphFormat.TabStops.AddTabStop(Unit.FromCentimeter(1.5));
            // The text after the bullet starts 1.5 cm from left margin
            // (tab stop is independent of LeftIndent).

            // Style for list level 3
            const string listLevel3StyleName = "ListLevel3";
            style = document.Styles.AddStyle(listLevel3StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.BulletList3;
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(2.5);
            // As NumberPosition, FirstLineIndent and tab stops are not set, the default tab stops are used
            // to position the text after the bullet. The default tab stop distance is 1.25 cm, so the next
            // tab stop after 2.5 cm will be found at 3.75 cm.

            // Add a section to the document.
            var section = document.AddSection();

            // Add a list item: Level 1, first entry.
            var paragraph = section.AddParagraph("Level 1, first entry. ");
            paragraph.Style = listLevel1StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 1, second entry.
            paragraph = section.AddParagraph("Level 1, second entry. ");
            paragraph.Style = listLevel1StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 2, first entry in "Level 1, second entry".
            paragraph = section.AddParagraph("Level 2, first entry in \"Level 1, second entry\". ");
            paragraph.Style = listLevel2StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 3, first entry in "Level 2, first entry in 'Level 1, second entry'".
            paragraph = section.AddParagraph("Level 3, first entry in \"Level 2, first entry in 'Level 1, second entry'\". ");
            paragraph.Style = listLevel3StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 3, second entry in "Level 2, first entry in 'Level 1, second entry'".
            paragraph = section.AddParagraph("Level 3, second entry in \"Level 2, first entry in 'Level 1, second entry'\". ");
            paragraph.Style = listLevel3StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 1, third entry.
            paragraph = section.AddParagraph("Level 1, third entry. ");
            paragraph.Style = listLevel1StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 2, first entry in "Level 1, third entry".
            paragraph = section.AddParagraph("Level 2, first entry in \"Level 1, third entry\". ");
            paragraph.Style = listLevel2StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 3, first entry in "Level 2, first entry in 'Level 1, third entry'".
            paragraph = section.AddParagraph("Level 3, first entry in \"Level 2, first entry in 'Level 1, third entry'\". ");
            paragraph.Style = listLevel3StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 2, second entry in "Level 1, third entry".
            paragraph = section.AddParagraph("Level 2, second entry in \"Level 1, third entry\". ");
            paragraph.Style = listLevel2StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 1, fourth entry.
            paragraph = section.AddParagraph("Level 1, fourth entry. ");
            paragraph.Style = listLevel1StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

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
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
