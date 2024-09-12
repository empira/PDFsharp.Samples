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
    /// "Avoiding page breaks" chapter.
    /// </summary>
    static class AvoidingPageBreaks
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string Filename = $"{Path}/AvoidingPageBreaks.pdf";
        const string SampleName = "Avoiding page breaks";

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
            table.Borders.Visible = true;

            // Add first column.
            table.AddColumn(Unit.FromCentimeter(6));

            // Add second column.
            table.AddColumn(Unit.FromCentimeter(10));
            
            // Set row height to force page break earlier.
            table.Rows.Height = Unit.FromCentimeter(6);

            // -- Add some rows.

            // Add first row.
            var row1 = table.AddRow();

            // Add paragraph to first cell of row1.
            row1[0].AddParagraph("Text A1");

            // Add paragraph to second cell of row1.
            row1[1].AddParagraph("Text B1");

            // Add second row.
            var row2 = table.AddRow();

            // Add paragraph to first cell of row2.
            row2[0].AddParagraph("Text A2");

            // Add paragraph to second cell of row2.
            row2[1].AddParagraph("Text B2");

            // -- Add some rows, that shall be kept together.

            // Add third row.
            var row3 = table.AddRow();

            // Keep rows 3, 4 and 5 together.
            row3.KeepWith = 2;

            // Add paragraph to first cell of row3.
            row3[0].AddParagraph("Text A3");

            // Add paragraph to second cell of row3.
            row3[1].AddParagraph("Text B3:\n" +
                                 "This row shall be kept together with the following two rows.");

            // Add fourth row.
            var row4 = table.AddRow();

            // Add paragraph to first cell of row4.
            row4[0].AddParagraph("Text A4");

            // Add paragraph to second cell of row4.
            row4[1].AddParagraph("Text B4");

            // Add fifth row.
            var row5 = table.AddRow();

            // Add paragraph to first cell of row5.
            row5[0].AddParagraph("Text A5");

            // Add paragraph to second cell of row5.
            row5[1].AddParagraph("Text B5");

            // -- Add another row.

            // Add sixth row.
            var row6 = table.AddRow();

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
