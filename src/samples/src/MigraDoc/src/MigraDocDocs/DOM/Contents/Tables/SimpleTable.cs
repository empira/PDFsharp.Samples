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

namespace MigraDocDocs.DOM.Contents.Tables
{
    /// <summary>
    /// "A simple table" chapter.
    /// </summary>
    static class SimpleTable
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Tables";

        const string Filename = $"{Path}/SimpleTable.pdf";
        const string SampleName = "A simple table";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(3);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(3);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content
            
            // Add table.
            var table = section.AddTable();
            table.Borders.Visible = true;

            // Add first column.
            var columnA = table.AddColumn(Unit.FromCentimeter(2));

            // Add second column.
            var columnB = table.AddColumn(Unit.FromCentimeter(3));

            // Add first row.
            var row1 = table.AddRow();
            
            // Add paragraph to first cell of row1.
            var cellA1 = row1[0];
            cellA1.AddParagraph("Text A1");

            // Add paragraph to second cell of row1.
            var cellB1 = row1[1];
            cellB1.AddParagraph("Text B1 contains more text.");

            // Add second row.
            var row2 = table.AddRow();

            // Add paragraph to first cell of row2.
            var cellA2 = row2[0];
            cellA2.AddParagraph("Text A2");

            // Add paragraph to second cell of row2.
            var cellB2 = row2[1];
            cellB2.AddParagraph("Text B2 contains...");
            cellB2.AddParagraph("...a second paragraph.");

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
