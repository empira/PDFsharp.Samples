// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.DocumentObjectModel;

namespace HelloMigraDoc
{
    public class TableOfContents
    {
        /// <summary>
        /// Defines the table of contents.
        /// </summary>
        public static void DefineTableOfContents(Document document)
        {
            var section = document.LastSection;
            section.AddPageBreak();

            var paragraph = section.AddParagraph("Table of Contents");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 24;
            paragraph.Format.OutlineLevel = OutlineLevel.Level1;

            paragraph = section.AddParagraph();
            paragraph.Style = Styles.TocStyle;
            var hyperlink = paragraph.AddHyperlink(Paragraphs.BookmarkName);
            hyperlink.AddText("Paragraphs\t");
            hyperlink.AddPageRefField(Paragraphs.BookmarkName);

            paragraph = section.AddParagraph();
            paragraph.Style = Styles.TocStyle;
            hyperlink = paragraph.AddHyperlink(Tables.BookmarkName);
            hyperlink.AddText("Tables\t");
            hyperlink.AddPageRefField(Tables.BookmarkName);

            paragraph = section.AddParagraph();
            paragraph.Style = Styles.TocStyle;
            hyperlink = paragraph.AddHyperlink(Charts.BookmarkName);
            hyperlink.AddText("Charts\t");
            hyperlink.AddPageRefField(Charts.BookmarkName);
        }
    }
}
