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
    /// "Numbered lists" chapter.
    /// </summary>
    static class NumberedLists
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Lists";
        
        const string Filename = $"{Path}/NumberedLists.pdf";
        const string SampleName = "Numbered lists";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();
            
            const string dummyTextStyleName = "DummyText";
            var style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            // --- Sample content

            // Style for list level 1.
            const string listLevel1StyleName = "ListLevel1";
            style = document.Styles.AddStyle(listLevel1StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.NumberList1;
            style.ParagraphFormat.ListInfo.NumberPosition = Unit.Zero;
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(0.5);

            // Special style for list level 1, first line.
            const string listLevel1Line1StyleName = "ListLevel1Line1";
            style = document.Styles.AddStyle(listLevel1Line1StyleName, listLevel1StyleName);
            style.ParagraphFormat.ListInfo.ContinuePreviousList = false;

            // style for list level 2.
            const string listLevel2StyleName = "ListLevel2";
            style = document.Styles.AddStyle(listLevel2StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.NumberList2;
            style.ParagraphFormat.ListInfo.NumberPosition = Unit.FromCentimeter(0.5);
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(1);

            // Special style for list level 2, first line.
            const string listLevel2Line1StyleName = "ListLevel2Line1";
            style = document.Styles.AddStyle(listLevel2Line1StyleName, listLevel2StyleName);
            style.ParagraphFormat.ListInfo.ContinuePreviousList = false;

            // Style for list level 3.
            const string listLevel3StyleName = "ListLevel3";
            style = document.Styles.AddStyle(listLevel3StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.NumberList3;
            style.ParagraphFormat.ListInfo.NumberPosition = Unit.FromCentimeter(1);
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(1.5);

            // Special style for list level 3, first line.
            const string listLevel3Line1StyleName = "ListLevel3Line1";
            style = document.Styles.AddStyle(listLevel3Line1StyleName, listLevel3StyleName);
            style.ParagraphFormat.ListInfo.ContinuePreviousList = false;

            // Add a section to the document.
            var section = document.AddSection();

            // Add a list item: Level 1, first entry.
            var paragraph = section.AddParagraph("Level 1, first entry. ");
            // Use special style for forst line to set ContinuePreviousList to false.
            paragraph.Style = listLevel1Line1StyleName;
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
            // Use special style for forst line to set ContinuePreviousList to false.
            paragraph.Style = listLevel2Line1StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 3, first entry in "Level 2, first entry in 'Level 1, second entry'".
            paragraph = section.AddParagraph("Level 3, first entry in \"Level 2, first entry in 'Level 1, second entry'\". ");
            // Use special style for forst line to set ContinuePreviousList to false.
            paragraph.Style = listLevel3Line1StyleName;
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
            // Use special style for forst line to set ContinuePreviousList to false.
            paragraph.Style = listLevel2Line1StyleName;
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                                       "sed diam. ", dummyTextStyleName);

            // Add a list item: Level 3, first entry in "Level 2, first entry in 'Level 1, third entry'".
            paragraph = section.AddParagraph("Level 3, first entry in \"Level 2, first entry in 'Level 1, third entry'\". ");
            // Use special style for forst line to set ContinuePreviousList to false.
            paragraph.Style = listLevel3Line1StyleName;
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

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
