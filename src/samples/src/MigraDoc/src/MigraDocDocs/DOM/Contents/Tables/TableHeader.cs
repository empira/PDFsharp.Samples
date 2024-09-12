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
    /// "Table header" chapter.
    /// </summary>
    static class TableHeader
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string Filename = $"{Path}/TableHeader.pdf";
        const string SampleName = "Table header";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();
            
            const string tableHeaderStyleName = "TableHeader";
            var style = document.Styles.AddStyle(tableHeaderStyleName, StyleNames.Normal);
            style.Font.Bold = true;

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Add table.
            var table = section.AddTable();
            table.Borders.Visible = true;

            // Add first column.
            table.AddColumn(Unit.FromCentimeter(6));

            // Add second column.
            table.AddColumn(Unit.FromCentimeter(10));

            // -- Create header row

            // Add first row as header.
            var row1 = table.AddRow();
            row1.HeadingFormat = true;
            row1.Style = tableHeaderStyleName;

            // Add paragraph to first cell of row1.
            row1[0].AddParagraph("Header A1");

            // Add paragraph to second cell of row1.
            row1[1].AddParagraph("Header B1");

            // -- Create some other rows

            // Add second row.
            var row2 = table.AddRow();

            // Add paragraph to first cell of row2.
            var cellA2 = row2[0];
            cellA2.AddParagraph("Text A2");

            // Add paragraph to second cell of row2.
            row2[1].AddParagraph("Text B2");

            // Add third row.
            var row3 = table.AddRow();

            // Set row height to force page break.
            row3.Height = Unit.FromCentimeter(22);

            // Add paragraph to first cell of row3.
            row3[0].AddParagraph("Text A3");

            // Add paragraph to second cell of row3.
            row3[1].AddParagraph("Text B3:\n" +
                                 "It’s a huge row to force a page break.\n" +
                                 "The table header should be repeated on the next page.");

            // Add fourth row.
            var row4 = table.AddRow();

            // Add paragraph to first cell of row4.
            row4[0].AddParagraph("Text A4");

            // Add paragraph to second cell of row4.
            row4[1].AddParagraph("Text B4");

            // Add fifth row.
            var row5 = table.AddRow();

            // Set row height.
            row5.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row5.
            row5[0].AddParagraph("Text A5");

            // Add paragraph to second cell of row5.
            row5[1].AddParagraph("Text B5");

            // Add sixth row.
            var row6 = table.AddRow();

            // Set row height.
            row6.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row6.
            row6[0].AddParagraph("Text A6");

            // Add paragraph to second cell of row6.
            row6[1].AddParagraph("Text B6");

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
