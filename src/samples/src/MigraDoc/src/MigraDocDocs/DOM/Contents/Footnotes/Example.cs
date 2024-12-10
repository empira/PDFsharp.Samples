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
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Contents.Footnotes
{
    /// <summary>
    /// Example chapter.
    /// </summary>
    static class Example
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Footnotes";
        
        const string Filename = $"{Path}/Example.pdf";
        const string SampleName = "Example";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Style for footnote.
            const string footnoteStyleName = "Footnote";
            var style = document.Styles.AddStyle(footnoteStyleName, StyleNames.Normal);
            style.Font.Size = Unit.FromPoint(8);

            /// <summary>
            /// Gets the bookmark name by prepending the bookmarkPrefix to the referenceId.
            /// </summary>
            string GetFootnoteBookmarkName(int referenceId, string bookmarkPrefix)
            {
                return $"{bookmarkPrefix}_{referenceId}";
            }

            /// <summary>
            /// Adds the referenceId to the paragraph to refer to the footnote using its bookmark.
            /// </summary>
            void AddFootnoteReference(Paragraph paragraph, int referenceId, string bookmarkPrefix)
            {
                // If rendered to RTF at a decimal tab stop and directly after a number,
                // the following superscript referenceId would be interpreted as an exponent.
                // Due to this, the number and its so-called exponent would both be aligned
                // left of the decimal tab stop in RTF.
                // By inserting a small size space between them, we can avoid this.
                // The number will now be correctly aligned left of the decimal tab stop
                // and the referenceId will follow it after the tab stop.
                var separator = paragraph.AddFormattedText(" ");
                separator.Font.Size = Unit.FromPoint(1);
                separator.Font.Underline = Underline.None;

                // Get the bookmark name for this referenceId.
                var bookmarkName = GetFootnoteBookmarkName(referenceId, bookmarkPrefix);

                // Create a link to the footnote bookmark.
                var link = paragraph.AddHyperlink(bookmarkName);
                link.NoHyperlinkStyle = true;

                // Add the referenceId in superscript.
                var formattedText = link.AddFormattedText(referenceId.ToString());
                formattedText.Superscript = true;
            }

            /// <summary>
            /// Adds a footnote to the section.
            /// </summary>
            Paragraph AddFootnote(Section section, int referenceId, string bookmarkPrefix, string text)
            {
                // Add a paragraph in footnote style.
                var paragraph = section.AddParagraph();
                paragraph.Style = footnoteStyleName;

                // Get the bookmark name for this referenceId.
                var bookmarkName = GetFootnoteBookmarkName(referenceId, bookmarkPrefix);

                // Add the bookmark for the footnote.
                paragraph.AddBookmark(bookmarkName);

                // Add the referenceId in superscript.
                var formattedText = paragraph.AddFormattedText(referenceId.ToString());
                formattedText.Superscript = true;

                // Add the text to the footnote.
                paragraph.AddText($" {text}");

                return paragraph;
            }

            // Define a unique prefix for the context of the following footnotes.
            var bookmarkPrefix = "NameValueTable";

            // Add a new Table
            var table = section.AddTable();
            table.Borders.Visible = true;
            table.AddColumn();
            table.AddColumn();

            // Add a header row.
            var row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Font.Bold = true;
            row[0].AddParagraph("Name");
            row[1].AddParagraph("Value");

            // Add a first data row.
            row = table.AddRow();
            row[0].AddParagraph("X");
            var paragraph = row[1].AddParagraph("5");
            
            // Add a footnote reference to paragraph.
            AddFootnoteReference(paragraph, 1, bookmarkPrefix);

            // Add a second data row.
            row = table.AddRow();
            row[0].AddParagraph("Y");
            paragraph = row[1].AddParagraph("90.5");

            // Add a footnote reference to paragraph.
            AddFootnoteReference(paragraph, 2, bookmarkPrefix);

            // Add the footnotes and its texts.
            AddFootnote(section, 1, bookmarkPrefix, "X must be a value between 1 and 10.");
            AddFootnote(section, 2, bookmarkPrefix, "Y must be a value between 0.0 and 100.0.");

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
