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
    /// Inheritance chapter.
    /// </summary>
    static class Inheritance
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string filename = $"{Path}/Inheritance.pdf";
        const string sampleName = "Inheritance";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Set and use direct formatting at different levels to show, how inheritance works in tables.
            // Overridden and inherited values are explained for each document object in the following comments.

            // Add table and set format.
            var table = section.AddTable();
            table.Borders.Visible = true;
            table.Format.Font.Size = Unit.FromPoint(8);

            // Add first column.
            var columnA = table.AddColumn();
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.

            // Add second column and set format.
            var columnB = table.AddColumn();
            columnB.Format.Font.Bold = true;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.

            // Add third column and set format.
            var columnC = table.AddColumn();
            columnC.Format.Alignment = ParagraphAlignment.Center;
            columnC.Format.Font.Color = Colors.Red;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.

            // Set format for all rows.
            table.Rows.Height = Unit.FromPoint(25);

            // Add first row and set format.
            var row1 = table.AddRow();
            row1.VerticalAlignment = VerticalAlignment.Center;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rows.

            // Get first cell of row1.
            var cellA1 = row1[0];
            // 'Borders.Visible = true' will be inherited from row1 (same value as columnA) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row1 (same value as columnA) > table.
            // 'Height = Unit.FromPoint(25)' will be inherited from row1 > rows.
            // 'VerticalAlignment = Center' will be inherited from row1.

            // Add paragraph to cellA1.
            cellA1.AddParagraph("Text A1");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellA1 > row1 (same value as columnA) > table.

            // Get second cell of row1.
            var cellB1 = row1[1];
            // 'Borders.Visible = true' will be inherited from row1 (same value as columnB) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row1 (same value as columnB) > table.
            // 'Format.Font.Bold = true' will be inherited from columnB.
            // 'Height = Unit.FromPoint(25)' will be inherited from row1 > rows.
            // 'VerticalAlignment = Center' will be inherited from row1.

            // Add paragraph to cellB1.
            cellB1.AddParagraph("Text B1");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellB1 > row1 (same value as columnB) > table.
            // 'Format.Font.Bold = true' will be inherited from cellB1 > columnB.

            // Get third cell of row1.
            var cellC1 = row1[2];
            // 'Borders.Visible = true' will be inherited from row1 (same value as columnC) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row1 (same value as columnC) > table.
            // 'Format.Alignment = Center' will be inherited from columnC.
            // 'Format.Font.Color = Red' will be inherited from columnC.
            // 'Height = Unit.FromPoint(25)' will be inherited from row1 > rows.
            // 'VerticalAlignment = Center' will be inherited from row1.

            // Add paragraph to cellC1.
            cellC1.AddParagraph("Text C1");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellC1 > row1 (same value as columnC) > table.
            // 'Format.Alignment = Center' will be inherited from cellC1 > columnC.
            // 'Format.Font.Color = Red' will be inherited from cellC1 > columnC.

            // Add second row and set format.
            var row2 = table.AddRow();
            row2.Format.Font.Italic = true;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rows.

            // Get first cell of row2.
            var cellA2 = row2[0];
            // 'Borders.Visible = true' will be inherited from row2 (same value as columnA) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row2 (same value as columnA) > table.
            // 'Height = Unit.FromPoint(25)' will be inherited from row2 > rows.
            // 'Format.Font.Italic = true' will be inherited from row2.

            // Add paragraph to cellA2.
            cellA2.AddParagraph("Text A2");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellA2 > row2 (same value as columnA) > table.
            // 'Format.Font.Italic = true' will be inherited from cellA2 > row2.

            // Get second cell of row2.
            var cellB2 = row2[1];
            // 'Borders.Visible = true' will be inherited from row2 (same value as columnB) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row2 (same value as columnB) > table.
            // 'Format.Font.Bold = true' will be inherited from columnB.
            // 'Height = Unit.FromPoint(25)' will be inherited from row2 > rows.
            // 'Format.Font.Italic = true' will be inherited from row2.

            // Add paragraph to cellB2.
            cellB2.AddParagraph("Text B2");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellB2 > row2 (same value as columnB) > table.
            // 'Format.Font.Bold = true' will be inherited from cellB2 > columnB.
            // 'Format.Font.Italic = true' will be inherited from cellB2 > row2.

            // Get third cell of row2.
            var cellC2 = row2[2];
            // 'Borders.Visible = true' will be inherited from row2 (same value as columnC) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row2 (same value as columnC) > table.
            // 'Format.Alignment = Center' will be inherited from columnC.
            // 'Format.Font.Color = Red' will be inherited from columnC.
            // 'Height = Unit.FromPoint(25)' will be inherited from row2 > rows.
            // 'Format.Font.Italic = true' will be inherited from row2.

            // Add paragraph to cellC2.
            cellC2.AddParagraph("Text C2");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellC2 > row2 (same value as columnC) > table.
            // 'Format.Alignment = Center' will be inherited from cellC2 > columnC.
            // 'Format.Font.Color = Red' will be inherited from cellC2 > columnC
            // 'Format.Font.Italic = true' will be inherited from cellC2 > row2.

            // Add third row and set format.
            var row3 = table.AddRow();
            row3.VerticalAlignment = VerticalAlignment.Bottom;
            row3.Format.Font.Color = Colors.Green;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rows.

            // Get first cell of row3.
            var cellA3 = row3[0];
            // 'Borders.Visible = true' will be inherited from row3 (same value as columnA) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row3 (same value as columnA) > table.
            // 'Height = Unit.FromPoint(25)' will be inherited from row3 > rows.
            // 'VerticalAlignment = Bottom' will be inherited from row3.
            // 'Format.Font.Color = Green' will be inherited from row3.

            // Add paragraph to cellA3.
            cellA3.AddParagraph("Text A3");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellA3 > row3 (same value as columnA) > table.
            // 'Format.Font.Color = Green' will be inherited from cellA3 > row3.

            // Get second cell of row3.
            var cellB3 = row3[1];
            // 'Borders.Visible = true' will be inherited from row3 (same value as columnB) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row3 (same value as columnB) > table.
            // 'Format.Font.Bold = true' will be inherited from columnB.
            // 'Height = Unit.FromPoint(25)' will be inherited from row3 > rows.
            // 'VerticalAlignment = Bottom' will be inherited from row3.
            // 'Format.Font.Color = Green' will be inherited from row3.

            // Add paragraph to cellB3.
            cellB3.AddParagraph("Text B3");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellB3 > row3 (same value as columnB) > table.
            // 'Format.Font.Bold = true' will be inherited from cellB3 > columnB.
            // 'Format.Font.Color = Green' will be inherited from cellB3 > row3.

            // Get third cell of row3.
            var cellC3 = row3[2];
            // 'Borders.Visible = true' will be inherited from row3 (same value as columnC) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from row3 (same value as columnC) > table.
            // 'Format.Alignment = Center' will be inherited from columnC.
            // 'Format.Font.Color = Red' will NOT be inherited from columnC, as the value from row3 (see below) has priority.
            // 'Height = Unit.FromPoint(25)' will be inherited from row3 > rows.
            // 'VerticalAlignment = Bottom' will be inherited from row3.
            // 'Format.Font.Color = Green' will be inherited from row3.

            // Add paragraph to cellC3.
            cellC3.AddParagraph("Text C3");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellC3 > row3 (same value as columnC) > table.
            // 'Format.Alignment = Center' will be inherited from cellC3 > columnC.
            // 'Format.Font.Color = Green' will be inherited from cellC3 > row3.

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
