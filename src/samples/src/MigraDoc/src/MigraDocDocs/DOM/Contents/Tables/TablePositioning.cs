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
    /// "Table positioning" chapter.
    /// </summary>
    static class TablePositioning
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string Filename = $"{Path}/TablePositioning.pdf";
        const string SampleName = "Table positioning";

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

            // -- Left aligned table.
            {
                section.AddParagraph("Left aligned table:", StyleNames.Heading1);

                // Add table.
                var table = section.AddTable();
                table.Borders.Visible = true;

                // Add table content
                table.AddColumn(Unit.FromCentimeter(2));
                table.AddColumn(Unit.FromCentimeter(3));
                table.AddRow();
                table.AddRow();
                table.Rows[0][0].AddParagraph("Text A1");
                table.Rows[0][1].AddParagraph("Text B1");
                table.Rows[1][0].AddParagraph("Text A2");
                table.Rows[1][1].AddParagraph("Text B2");
            }

            // -- Left aligned table with 0 cm indent.
            {
                section.AddParagraph("Left aligned table, adjusted with 0 cm indent:", StyleNames.Heading1);

                // Add table.
                var table = section.AddTable();
                table.Borders.Visible = true;

                // Set left indent to zero, so that table is aligned at its border, not at its text.
                table.Rows.LeftIndent = Unit.Zero;

                // Add table content
                table.AddColumn(Unit.FromCentimeter(2));
                table.AddColumn(Unit.FromCentimeter(3));
                table.AddRow();
                table.AddRow();
                table.Rows[0][0].AddParagraph("Text A1");
                table.Rows[0][1].AddParagraph("Text B1");
                table.Rows[1][0].AddParagraph("Text A2");
                table.Rows[1][1].AddParagraph("Text B2");
            }

            // -- Center aligned table.
            {
                var paragraph = section.AddParagraph("Center aligned table:", StyleNames.Heading1);
                paragraph.Format.Alignment = ParagraphAlignment.Center;

                // Add table.
                var table = section.AddTable();
                table.Borders.Visible = true;

                // Make table center aligned.
                table.Rows.Alignment = RowAlignment.Center;

                // Add table content
                table.AddColumn(Unit.FromCentimeter(2));
                table.AddColumn(Unit.FromCentimeter(3));
                table.AddRow();
                table.AddRow();
                table.Rows[0][0].AddParagraph("Text A1");
                table.Rows[0][1].AddParagraph("Text B1");
                table.Rows[1][0].AddParagraph("Text A2");
                table.Rows[1][1].AddParagraph("Text B2");
            }

            // -- Right aligned table.
            {
                var paragraph = section.AddParagraph("Right aligned table:", StyleNames.Heading1);
                paragraph.Format.Alignment = ParagraphAlignment.Right;

                // Add table.
                var table = section.AddTable();
                table.Borders.Visible = true;

                // Make table right aligned.
                table.Rows.Alignment = RowAlignment.Right;

                // Add table content
                table.AddColumn(Unit.FromCentimeter(2));
                table.AddColumn(Unit.FromCentimeter(3));
                table.AddRow();
                table.AddRow();
                table.Rows[0][0].AddParagraph("Text A1");
                table.Rows[0][1].AddParagraph("Text B1");
                table.Rows[1][0].AddParagraph("Text A2");
                table.Rows[1][1].AddParagraph("Text B2");
            }

            // -- Table with 3 cm ident.
            {
                section.AddParagraph("Table with 3 cm ident:", StyleNames.Heading1);

                // Add table.
                var table = section.AddTable();
                table.Borders.Visible = true;

                // Set left indent.
                table.Rows.LeftIndent = Unit.FromCentimeter(3);

                // Add table content
                table.AddColumn(Unit.FromCentimeter(2));
                table.AddColumn(Unit.FromCentimeter(3));
                table.AddRow();
                table.AddRow();
                table.Rows[0][0].AddParagraph("Text A1");
                table.Rows[0][1].AddParagraph("Text B1");
                table.Rows[1][0].AddParagraph("Text A2");
                table.Rows[1][1].AddParagraph("Text B2");
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
