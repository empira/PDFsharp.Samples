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
    /// "Rounded corners" chapter.
    /// </summary>
    static class RoundedCorners
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string Filename = $"{Path}/RoundedCorners.pdf";
        const string SampleName = "Rounded corners";

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
            table.Shading.Color = Colors.LightBlue;

            // Add first column (used for border cells).
            table.AddColumn(Unit.FromCentimeter(0.25));

            // Add second column.
            table.AddColumn(Unit.FromCentimeter(3));

            // Add third column.
            table.AddColumn(Unit.FromCentimeter(3));

            // Add fourth column (used for border cells).
            table.AddColumn(Unit.FromCentimeter(0.25));

            // -- Add border cells row.

            // Add first row.
            var row1 = table.AddRow();

            // Set height for border cells row.
            row1.HeightRule = RowHeightRule.Exactly;
            row1.Height = Unit.FromCentimeter(0.25);

            // The border cells shall not be alone on one page.
            row1.KeepWith = 1;

            // The whole row consists of empty border cells.

            // Make first cell of row1 TopLeft rounded corner.
            row1[0].RoundedCorner = RoundedCorner.TopLeft;

            // Make fourth cell of row1 TopRight rounded corner.
            row1[3].RoundedCorner = RoundedCorner.TopRight;
            
            // -- Add content rows.

            // Add second row.
            var row2 = table.AddRow();

            // The first cell is an empty border cell.

            // Add paragraph to second cell of row2.
            row2[1].AddParagraph("Text B2");

            // Add paragraph to third cell of row2.
            row2[2].AddParagraph("Text C2");

            // The last cell is an empty border cell.

            // Add third row.
            var row3 = table.AddRow();

            // The first cell is an empty border cell.

            // Add paragraph to second cell of row3.
            row3[1].AddParagraph("Text B3");

            // Add paragraph to third cell of row3.
            row3[2].AddParagraph("Text C3");

            // The last cell is an empty border cell.

            // Add fourth row.
            var row4 = table.AddRow();

            // The first cell is an empty border cell.

            // Add paragraph to second cell of row4.
            row4[1].AddParagraph("Text B4");

            // Add paragraph to third cell of row4.
            row4[2].AddParagraph("Text C4");

            // The last cell is an empty border cell.

            // The following border cells shall not be alone on one page.
            row4.KeepWith = 1;

            // -- Add border cells row.

            // Add fifth row.
            var row5 = table.AddRow();

            // Set height for border cells row.
            row5.HeightRule = RowHeightRule.Exactly;
            row5.Height = Unit.FromCentimeter(0.25);

            // The whole row consists of empty border cells.

            // Make first cell of row5 BottomLeft rounded corner.
            row5[0].RoundedCorner = RoundedCorner.BottomLeft;

            // Make fourth cell of row5 BottomRight rounded corner.
            row5[3].RoundedCorner = RoundedCorner.BottomRight;

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
