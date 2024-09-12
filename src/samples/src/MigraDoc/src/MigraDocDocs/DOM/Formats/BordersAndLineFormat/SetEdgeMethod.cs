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

namespace MigraDocDocs.DOM.Formats.BordersAndLineFormat
{
    /// <summary>
    /// "Borders in tables" chapter.
    /// </summary>
    static class SetEdgeMethod
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Formats/BordersAndLineFormat";

        const string Filename = $"{Path}/SetEdgeMethod.pdf";
        const string SampleName = "SetEdge method";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Add table.
            var table = section.AddTable();

            // Set borders for all cells.
            table.Borders.Width = Unit.FromPoint(1);

            // Add first column.
            var columnA = table.AddColumn(Unit.FromCentimeter(3));

            // Add second column.
            var columnB = table.AddColumn(Unit.FromCentimeter(3));

            // Add third column.
            var columnC = table.AddColumn(Unit.FromCentimeter(3));

            // Add first row.
            var row1 = table.AddRow();

            // Add paragraph to first cell of row1.
            var cellA1 = row1[0];
            cellA1.AddParagraph("Text A1");

            // Add paragraph to second cell of row1.
            var cellB1 = row1[1];
            cellB1.AddParagraph("Text B1");

            // Add paragraph to third cell of row1.
            var cellC1 = row1[2];
            cellC1.AddParagraph("Text C1");

            // Add second row.
            var row2 = table.AddRow();

            // Add paragraph to first cell of row2.
            var cellA2 = row2[0];
            cellA2.AddParagraph("Text A2");

            // Add paragraph to second cell of row2.
            var cellB2 = row2[1];
            cellB2.AddParagraph("Text B2");

            // Add paragraph to third cell of row2.
            var cellC2 = row2[2];
            cellC2.AddParagraph("Text C2");

            // Add third row.
            var row3 = table.AddRow();

            // Add paragraph to first cell of row3.
            var cellA3 = row3[0];
            cellA3.AddParagraph("Text A3");

            // Add paragraph to second cell of row3.
            var cellB3 = row3[1];
            cellB3.AddParagraph("Text B3");

            // Add paragraph to third cell of row3.
            var cellC3 = row3[2];
            cellC3.AddParagraph("Text C3");

            // Set a border surrounding B2 to C3.
            table.SetEdge(1, 1, 2, 2, Edge.Box, BorderStyle.Dot, Unit.FromPoint(3), Colors.Red);

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
