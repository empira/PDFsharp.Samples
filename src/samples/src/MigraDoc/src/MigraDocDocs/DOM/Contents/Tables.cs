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

namespace MigraDocDocs.DOM.Contents
{
    static class Tables
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        /// <summary>
        /// Inheritance chapter.
        /// </summary>
        public static string Inheritance()
        {
            const string filename = $"{Path}/Inheritance.pdf";
            const string sampleName = "Inheritance";

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
            var column1 = table.AddColumn();
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.

            // Add second column and set format.
            var column2 = table.AddColumn();
            column2.Format.Font.Bold = true;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.

            // Add third column and set format.
            var column3 = table.AddColumn();
            column3.Format.Alignment = ParagraphAlignment.Center;
            column3.Format.Font.Color = Colors.Red;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.

            // Set format for all rows.
            table.Rows.Height = Unit.FromPoint(25);

            // Add first row and set format.
            var rowA = table.AddRow();
            rowA.VerticalAlignment = VerticalAlignment.Center;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rows.

            // Get first cell of rowA.
            var cellA1 = rowA[0];
            // 'Borders.Visible = true' will be inherited from rowA (same value as column1) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowA (same value as column1) > table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowA > rows.
            // 'VerticalAlignment = Center' will be inherited from rowA.

            // Add paragraph to cellA1.
            cellA1.AddParagraph("Test A1");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellA1 > rowA (same value as column1) > table.

            // Get second cell of rowA.
            var cellA2 = rowA[1];
            // 'Borders.Visible = true' will be inherited from rowA (same value as column2) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowA (same value as column2) > table.
            // 'Format.Font.Bold = true' will be inherited from column2.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowA > rows.
            // 'VerticalAlignment = Center' will be inherited from rowA.

            // Add paragraph to cellA2.
            cellA2.AddParagraph("Test A2");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellA2 > rowA (same value as column2) > table.
            // 'Format.Font.Bold = true' will be inherited from cellA2 > column2.

            // Get third cell of rowA.
            var cellA3 = rowA[2];
            // 'Borders.Visible = true' will be inherited from rowA (same value as column3) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowA (same value as column3) > table.
            // 'Format.Alignment = Center' will be inherited from column3.
            // 'Format.Font.Color = Red' will be inherited from column3.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowA > rows.
            // 'VerticalAlignment = Center' will be inherited from rowA.

            // Add paragraph to cellA3.
            cellA3.AddParagraph("Test A3");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellA3 > rowA (same value as column3) > table.
            // 'Format.Alignment = Center' will be inherited from cellA3 > column3.
            // 'Format.Font.Color = Red' will be inherited from cellA3 > column3.

            // Add second row and set format.
            var rowB = table.AddRow();
            rowB.Format.Font.Italic = true;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rows.

            // Get first cell of rowB.
            var cellB1 = rowB[0];
            // 'Borders.Visible = true' will be inherited from rowB (same value as column1) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowB (same value as column1) > table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowB > rows.
            // 'Format.Font.Italic = true' will be inherited from rowB.

            // Add paragraph to cellB1.
            cellB1.AddParagraph("Test B1");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellB1 > rowB (same value as column1) > table.
            // 'Format.Font.Italic = true' will be inherited from cellB1 > rowB.

            // Get second cell of rowB.
            var cellB2 = rowB[1];
            // 'Borders.Visible = true' will be inherited from rowB (same value as column2) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowB (same value as column2) > table.
            // 'Format.Font.Bold = true' will be inherited from column2.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowB > rows.
            // 'Format.Font.Italic = true' will be inherited from rowB.

            // Add paragraph to cellB2.
            cellB2.AddParagraph("Test B2");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellB2 > rowB (same value as column2) > table.
            // 'Format.Font.Bold = true' will be inherited from cellB2 > column2.
            // 'Format.Font.Italic = true' will be inherited from cellB2 > rowB.

            // Get third cell of rowB.
            var cellB3 = rowB[2];
            // 'Borders.Visible = true' will be inherited from rowB (same value as column3) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowB (same value as column3) > table.
            // 'Format.Alignment = Center' will be inherited from column3.
            // 'Format.Font.Color = Red' will be inherited from column3.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowB > rows.
            // 'Format.Font.Italic = true' will be inherited from rowB.

            // Add paragraph to cellB3.
            cellB3.AddParagraph("Test B3");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellB3 > rowB (same value as column3) > table.
            // 'Format.Alignment = Center' will be inherited from cellB3 > column3.
            // 'Format.Font.Color = Red' will be inherited from cellB3 > column3
            // 'Format.Font.Italic = true' will be inherited from cellB3 > rowB.

            // Add third row and set format.
            var rowC = table.AddRow();
            rowC.VerticalAlignment = VerticalAlignment.Bottom;
            rowC.Format.Font.Color = Colors.Green;
            // 'Borders.Visible = true' will be inherited from table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rows.

            // Get first cell of rowC.
            var cellC1 = rowC[0];
            // 'Borders.Visible = true' will be inherited from rowC (same value as column1) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowC (same value as column1) > table.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowC > rows.
            // 'VerticalAlignment = Bottom' will be inherited from rowC.
            // 'Format.Font.Color = Green' will be inherited from rowC.

            // Add paragraph to cellC1.
            cellC1.AddParagraph("Test C1");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellC1 > rowC (same value as column1) > table.
            // 'Format.Font.Color = Green' will be inherited from cellC1 > rowC.

            // Get second cell of rowC.
            var cellC2 = rowC[1];
            // 'Borders.Visible = true' will be inherited from rowC (same value as column2) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowC (same value as column2) > table.
            // 'Format.Font.Bold = true' will be inherited from column2.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowC > rows.
            // 'VerticalAlignment = Bottom' will be inherited from rowC.
            // 'Format.Font.Color = Green' will be inherited from rowC.

            // Add paragraph to cellC2.
            cellC2.AddParagraph("Test C2");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellC2 > rowC (same value as column2) > table.
            // 'Format.Font.Bold = true' will be inherited from cellC2 > column2.
            // 'Format.Font.Color = Green' will be inherited from cellC2 > rowC.

            // Get third cell of rowC.
            var cellC3 = rowC[2];
            // 'Borders.Visible = true' will be inherited from rowC (same value as column3) > table.
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from rowC (same value as column3) > table.
            // 'Format.Alignment = Center' will be inherited from column3.
            // 'Format.Font.Color = Red' will NOT be inherited from column3, as the value from rowC (see below) has priority.
            // 'Height = Unit.FromPoint(25)' will be inherited from rowC > rows.
            // 'VerticalAlignment = Bottom' will be inherited from rowC.
            // 'Format.Font.Color = Green' will be inherited from rowC.

            // Add paragraph to cellC3.
            cellC3.AddParagraph("Test C3");
            // 'Format.Font.Size = Unit.FromPoint(8)' will be inherited from cellC3 > rowC (same value as column3) > table.
            // 'Format.Alignment = Center' will be inherited from cellC3 > column3.
            // 'Format.Font.Color = Green' will be inherited from cellC3 > rowC.

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
