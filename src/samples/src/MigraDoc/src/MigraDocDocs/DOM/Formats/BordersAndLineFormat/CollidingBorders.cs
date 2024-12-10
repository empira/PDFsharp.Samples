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

namespace MigraDocDocs.DOM.Formats.BordersAndLineFormat
{
    /// <summary>
    /// "Borders in tables" chapter.
    /// </summary>
    static class CollidingBorders
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/BordersAndLineFormat";
        
        const string Filename = $"{Path}/CollidingBorders.pdf";
        const string SampleName = "Colliding borders";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Add table.
            var table = section.AddTable();

            // Add first column.
            var columnA = table.AddColumn(Unit.FromCentimeter(3));

            // Add second column.
            var columnB = table.AddColumn(Unit.FromCentimeter(3));

            // Add third column.
            var columnC = table.AddColumn(Unit.FromCentimeter(3));

            // Add fourth column.
            var columnD = table.AddColumn(Unit.FromCentimeter(3));

            // Add fifth column.
            var columnE = table.AddColumn(Unit.FromCentimeter(3));

            // Add first row.
            var row1 = table.AddRow();

            // Add paragraph to first cell of row1.
            var cellA1 = row1[0];
            cellA1.AddParagraph("Text A1");

            // Add paragraph to second cell of row1.
            var cellB1 = row1[1];
            cellB1.AddParagraph("Text B1");

            // Set cellB1 to a thin border.
            cellB1.Borders.Width = Unit.FromPoint(1);
            cellB1.Borders.Color = Colors.DarkGray;

            // Add paragraph to third cell of row1.
            var cellC1 = row1[2];
            cellC1.AddParagraph("Text C1");

            // Add paragraph to fourth cell of row1.
            var cellD1 = row1[3];
            cellD1.AddParagraph("Text D1");

            // Set cellD1 to a thin border.
            cellD1.Borders.Width = Unit.FromPoint(1);
            cellD1.Borders.Color = Colors.DarkGray;

            // Add paragraph to fifth cell of row1.
            var cellE1 = row1[4];
            cellE1.AddParagraph("Text E1");

            // Add second row.
            var row2 = table.AddRow();

            // Add paragraph to first cell of row2.
            var cellA2 = row2[0];
            cellA2.AddParagraph("Text A2");

            // Set cellA2 to a thin border.
            cellA2.Borders.Width = Unit.FromPoint(1);
            cellA2.Borders.Color = Colors.DarkGray;

            // Add paragraph to second cell of row2.
            var cellB2 = row2[1];
            cellB2.AddParagraph("Text B2");

            // Set cellB2 to a thin dotted light border.
            cellB2.Borders.Width = Unit.FromPoint(1);
            cellB2.Borders.Color = Colors.LightGray;
            cellB2.Borders.Style = BorderStyle.Dot;

            // Add paragraph to third cell of row2.
            var cellC2 = row2[2];
            cellC2.AddParagraph("Text C2");

            // Set cellC2 to a thin border.
            cellC2.Borders.Width = Unit.FromPoint(1);
            cellC2.Borders.Color = Colors.DarkGray;

            // Add paragraph to fourth cell of row2.
            var cellD2 = row2[3];
            cellD2.AddParagraph("Text D2");

            // Set cellD2 to a thick dotted light border.
            cellD2.Borders.Width = Unit.FromPoint(3);
            cellD2.Borders.Color = Colors.LightGray;
            cellD2.Borders.Style = BorderStyle.Dot;

            // Add paragraph to fifth cell of row2.
            var cellE2 = row2[4];
            cellE2.AddParagraph("Text E2");

            // Set cellE2 to a thin border.
            cellE2.Borders.Width = Unit.FromPoint(1);
            cellE2.Borders.Color = Colors.DarkGray;

            // Add third row.
            var row3 = table.AddRow();

            // Add paragraph to first cell of row3.
            var cellA3 = row3[0];
            cellA3.AddParagraph("Text A3");

            // Add paragraph to second cell of row3.
            var cellB3 = row3[1];
            cellB3.AddParagraph("Text B3");

            // Set cellB3 to a thin border.
            cellB3.Borders.Width = Unit.FromPoint(1);
            cellB3.Borders.Color = Colors.DarkGray;

            // Add paragraph to third cell of row3.
            var cellC3 = row3[2];
            cellC3.AddParagraph("Text C3");

            // Add paragraph to fourth cell of row3.
            var cellD3 = row3[3];
            cellD3.AddParagraph("Text D3");

            // Set cellD3 to a thin border.
            cellD3.Borders.Width = Unit.FromPoint(1);
            cellD3.Borders.Color = Colors.DarkGray;

            // Add paragraph to fifth cell of row3.
            var cellE3 = row3[4];
            cellE3.AddParagraph("Text E3");

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
