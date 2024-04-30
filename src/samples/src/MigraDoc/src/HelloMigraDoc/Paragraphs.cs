// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.DocumentObjectModel;

namespace HelloMigraDoc
{
    /// <summary>
    /// This class demonstrates MigraDoc paragraphs.
    /// </summary>
    public class Paragraphs
    {
        public static void DefineParagraphs(Document document)
        {
            var paragraph = document.LastSection.AddParagraph("Paragraph Layout Overview", "Heading1");
            paragraph.AddBookmark("Paragraphs");

            DemonstrateAlignment(document);
            DemonstrateIndent(document);
            DemonstrateFormattedText(document);
            DemonstrateBordersAndShading(document);
        }

        static void DemonstrateAlignment(Document document)
        {
            document.LastSection.AddParagraph("Alignment", "Heading2");

            document.LastSection.AddParagraph("Left Aligned", "Heading3");

            var paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.AddText(FillerText.Text);

            document.LastSection.AddParagraph("Right Aligned", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            paragraph.AddText(FillerText.Text);

            document.LastSection.AddParagraph("Centered", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddText(FillerText.Text);

            document.LastSection.AddParagraph("Justified", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Justify;
            paragraph.AddText(FillerText.MediumText);
        }

        static void DemonstrateIndent(Document document)
        {
            document.LastSection.AddParagraph("Indent", "Heading2");

            document.LastSection.AddParagraph("Left Indent", "Heading3");

            var paragraph = document.LastSection.AddParagraph();
            paragraph.Format.LeftIndent = "2cm";
            paragraph.AddText(FillerText.Text);

            document.LastSection.AddParagraph("Right Indent", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.RightIndent = "1in";
            paragraph.AddText(FillerText.Text);

            document.LastSection.AddParagraph("First Line Indent", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.FirstLineIndent = "12mm";
            paragraph.AddText(FillerText.Text);

            document.LastSection.AddParagraph("First Line Negative Indent", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.LeftIndent = "1.5cm";
            paragraph.Format.FirstLineIndent = "-1.5cm";
            paragraph.AddText(FillerText.Text);
        }

        static void DemonstrateFormattedText(Document document)
        {
            document.LastSection.AddParagraph("Formatted Text", "Heading2");

            var paragraph = document.LastSection.AddParagraph();
            paragraph.AddText("Text can be formatted ");
            paragraph.AddFormattedText("bold", TextFormat.Bold);
            paragraph.AddText(", ");
            paragraph.AddFormattedText("italic", TextFormat.Italic);
            paragraph.AddText(", or ");
            paragraph.AddFormattedText("bold & italic", TextFormat.Bold | TextFormat.Italic);
            paragraph.AddText(".");
            paragraph.AddLineBreak();
            paragraph.AddText("You can set the ");
            var formattedText = paragraph.AddFormattedText("size");
            formattedText.Size = 15;
            paragraph.AddText(", the ");
            formattedText = paragraph.AddFormattedText("color");
            formattedText.Color = Colors.Firebrick;
            paragraph.AddText(", the ");
            paragraph.AddFormattedText("font", new Font("Times New Roman", 12));
            paragraph.AddText(".");
            paragraph.AddLineBreak();
            paragraph.AddText("You can set the ");
            formattedText = paragraph.AddFormattedText("subscript");
            formattedText.Subscript = true;
            paragraph.AddText(" or ");
            formattedText = paragraph.AddFormattedText("superscript");
            formattedText.Superscript = true;
            paragraph.AddText(".");
        }

        static void DemonstrateBordersAndShading(Document document)
        {
            document.LastSection.AddPageBreak();
            document.LastSection.AddParagraph("Borders and Shading", "Heading2");

            document.LastSection.AddParagraph("Border around Paragraph", "Heading3");

            var paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Borders.Width = 2.5;
            paragraph.Format.Borders.Color = Colors.Navy;
            paragraph.Format.Borders.Distance = 3;
            paragraph.AddText(FillerText.MediumText);

            document.LastSection.AddParagraph("Shading", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Shading.Color = Colors.LightCoral;
            paragraph.AddText(FillerText.Text);

            document.LastSection.AddParagraph("Borders & Shading", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Style = "TextBox";
            paragraph.AddText(FillerText.MediumText);
        }
    }
}
