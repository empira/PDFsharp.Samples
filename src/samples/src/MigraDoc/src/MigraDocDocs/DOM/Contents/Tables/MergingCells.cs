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
    /// "Merging cells" chapter.
    /// </summary>
    static class MergingCells
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string Filename = $"{Path}/MergingCells.pdf";
        const string SampleName = "Merging cells";

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
            table.AddColumn(Unit.FromCentimeter(4));

            // Add second column.
            table.AddColumn(Unit.FromCentimeter(4));

            // Add third column.
            table.AddColumn(Unit.FromCentimeter(4));

            // Add fourth column.
            table.AddColumn(Unit.FromCentimeter(4));

            // Add first row.
            var row1 = table.AddRow();

            // Add paragraph to first cell of row1.
            var cellA1 = row1[0];
            cellA1.AddParagraph("Text A1");

            // Merge cellA1 two rows down.
            cellA1.MergeDown = 2;

            // Add paragraph to second cell of row1.
            var cellB1 = row1[1];
            cellB1.AddParagraph("Text B1");

            // Merge cellB1 one column right.
            cellB1.MergeRight = 1;

            // Don't handle third cell of row1, as cellB1 gets this space.

            // Add paragraph to fourth cell of row1.
            row1[3].AddParagraph("Text D1");

            // Add second row.
            var row2 = table.AddRow();

            // Don't handle first cell of row2, as cellA1 gets this space.

            // Add paragraph to second cell of row2.
            row2[1].AddParagraph("Text B2");

            // Add paragraph to third cell of row2.
            row2[2].AddParagraph("Text C2");

            // Add paragraph to fourth cell of row2.
            row2[3].AddParagraph("Text D2");

            // Add third row.
            var row3 = table.AddRow();

            // Don't handle first cell of row3, as cellA1 gets this space.

            // Add paragraph to second cell of row3.
            row3[1].AddParagraph("Text B3");

            // Add paragraph to third cell of row3.
            var cellC3 = row3[2];
            cellC3.AddParagraph("Text C3");

            // Merge cellC3 one row down and one column right.
            cellC3.MergeDown = 1;
            cellC3.MergeRight = 1;

            // Don't handle fourth cell of row3, as cellC3 gets this space.

            // Add fourth row.
            var row4 = table.AddRow();

            // Add paragraph to first cell of row4.
            row4[0].AddParagraph("Text A4");

            // Add paragraph to second cell of row4.
            row4[1].AddParagraph("Text B4");

            // Don't handle third cell of row4, as cellC3 gets this space.

            // Don't handle fourth cell of row4, as cellC3 gets this space.

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
