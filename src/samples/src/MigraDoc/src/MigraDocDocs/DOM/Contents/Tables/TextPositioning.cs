// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace MigraDocDocs.DOM.Contents.Tables
{
    /// <summary>
    /// "Text positioning" chapter.
    /// </summary>
    static class TextPositioning
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string Filename = $"{Path}/TextPositioning.pdf";
        const string SampleName = "Text positioning";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Heading1 style.
            var style = document.Styles[StyleNames.Heading1];
            style.Font.Bold = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(18);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(6);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- ParagraphAlignment and VerticalAlignment
            {
                section.AddParagraph("ParagraphAlignment and VerticalAlignment:", StyleNames.Heading1);

                // Add table.
                var table = section.AddTable();
                table.Borders.Visible = true;
                
                // Set left indent to zero, so that table is aligned at its border, not at its text.
                table.Rows.LeftIndent = Unit.Zero;
                
                // Set row height for whole table to show effect of vertical alignment.
                table.Rows.Height = Unit.FromCentimeter(2);

                // Add first column with left alignment.
                var columnA = table.AddColumn(Unit.FromCentimeter(5));
                columnA.Format.Alignment = ParagraphAlignment.Left;

                // Add second column with center alignment.
                var columnB = table.AddColumn(Unit.FromCentimeter(5));
                columnB.Format.Alignment = ParagraphAlignment.Center;

                // Add third column with right alignment.
                var columnC = table.AddColumn(Unit.FromCentimeter(5));
                columnC.Format.Alignment = ParagraphAlignment.Right;

                // Add first row with top vertical alignment.
                var row1 = table.AddRow();
                row1.VerticalAlignment = VerticalAlignment.Top;

                // Add paragraph to first cell of row1.
                row1[0].AddParagraph("Text A1");

                // Add paragraph to second cell of row1.
                row1[1].AddParagraph("Text B1");

                // Add paragraph to third cell of row1.
                row1[2].AddParagraph("Text C1");

                // Add second row with center vertical alignment.
                var row2 = table.AddRow();
                row2.VerticalAlignment = VerticalAlignment.Center;

                // Add paragraph to first cell of row2.
                row2[0].AddParagraph("Text A2");

                // Add paragraph to second cell of row2.
                row2[1].AddParagraph("Text B2");

                // Add paragraph to third cell of row2.
                row2[2].AddParagraph("Text C2");

                // Add third row with bottom vertical alignment.
                var row3 = table.AddRow();
                row3.VerticalAlignment = VerticalAlignment.Bottom;

                // Add paragraph to first cell of row3.
                row3[0].AddParagraph("Text A3");

                // Add paragraph to second cell of row3.
                row3[1].AddParagraph("Text B3");

                // Add paragraph to third cell of row3.
                row3[2].AddParagraph("Text C3");
            }

            // -- Padding
            {
                section.AddParagraph("Padding:", StyleNames.Heading1);

                // Add table.
                var table = section.AddTable();
                table.Borders.Visible = true;

                // Set left indent to zero, so that table is aligned at its border, not at its text.
                table.Rows.LeftIndent = Unit.Zero;

                // Add first column.
                var columnA = table.AddColumn(Unit.FromCentimeter(15));

                // Set LeftPadding and RightPadding for columnA.
                columnA.LeftPadding = Unit.FromCentimeter(2);
                columnA.RightPadding = Unit.FromCentimeter(1);

                // Add first row.
                var row1 = table.AddRow();

                // Set TopPadding and BottomPadding for row1.
                row1.TopPadding = Unit.FromCentimeter(0.5);
                row1.BottomPadding = Unit.FromCentimeter(1.5);

                // Add paragraph to first cell of row1.
                var cellA1 = row1[0];
                var paragraph = cellA1.AddParagraph("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod " +
                                                    "tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos " +
                                                    "et accusam et justo duo dolores et ea rebum.");
                paragraph.Format.Alignment = ParagraphAlignment.Justify;
            }

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
