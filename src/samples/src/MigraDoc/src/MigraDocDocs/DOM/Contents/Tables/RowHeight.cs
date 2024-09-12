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
    /// "Row height" chapter.
    /// </summary>
    static class RowHeight
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Tables";

        const string Filename = $"{Path}/RowHeight.pdf";
        const string SampleName = "Row height";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            const string dummyTextStyleName = "DummyText";
            var style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Add table.
            var table = section.AddTable();
            table.Borders.Visible = true;

            // Add first column.
            table.AddColumn(Unit.FromCentimeter(2.5));

            // Add second column.
            table.AddColumn(Unit.FromCentimeter(3));

            // -- RowHeightRule.Exactly, less text sample

            // Add first row.
            var row1 = table.AddRow();

            // Set row height.
            row1.HeightRule = RowHeightRule.Exactly;
            row1.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row1.
            row1[0].AddParagraph("Text A1:\n" +
                                 "Exactly 2.5 cm row height");

            // Add paragraph to second cell of row1.
            var paragraph = row1[1].AddParagraph("Text B1:\n");
            paragraph.AddFormattedText("The cell will be larger than needed to render the text.", dummyTextStyleName);

            // -- RowHeightRule.Exactly, more text sample

            // Add second row.
            var row2 = table.AddRow();

            // Set row height.
            row2.HeightRule = RowHeightRule.Exactly;
            row2.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row2.
            row2[0].AddParagraph("Text A2:\n" +
                                 "Exactly 2.5 cm row height");

            // Add paragraph to second cell of row2.
            paragraph = row2[1].AddParagraph("Text B2:\n");
            paragraph.AddFormattedText("Too much text will exceed the cell border. " +
                                       "Too much text will exceed the cell border. ", dummyTextStyleName);

            // -- RowHeightRule.AtLeast, less text sample

            // Add third row.
            var row3 = table.AddRow();

            // Set row height.
            row3.HeightRule = RowHeightRule.AtLeast;
            row3.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row3.
            row3[0].AddParagraph("Text A3:\n" +
                                "At least 2.5 cm row height");

            // Add paragraph to second cell of row3.
            paragraph = row3[1].AddParagraph("Text B3:\n");
            paragraph.AddFormattedText("The cell will be larger than needed to render the text.", dummyTextStyleName);

            // -- RowHeightRule.AtLeast, more text sample

            // Add fourth row.
            var row4 = table.AddRow();

            // Set row height.
            row4.HeightRule = RowHeightRule.AtLeast;
            row4.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row4.
            row4[0].AddParagraph("Text A4:\n" +
                                 "At least 2.5 cm row height");

            // Add paragraph to second cell of row4.
            paragraph = row4[1].AddParagraph("Text B4:\n");
            paragraph.AddFormattedText("The cell height will be adjusted to fit text that exceeds the given height. " +
                                       "The cell height will be adjusted to fit text that exceeds the given height.", dummyTextStyleName);

            // -- RowHeightRule not explicitly set, less text sample

            // Add fifth row.
            var row5 = table.AddRow();

            // Set row height.
            row5.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row5.
            row5[0].AddParagraph("Text A5:\n" +
                                "Implicitly at least 2.5 cm row height");

            // Add paragraph to second cell of row5.
            paragraph = row5[1].AddParagraph("Text B5:\n");
            paragraph.AddFormattedText("The cell will be larger than needed to render the text.", dummyTextStyleName);

            // -- RowHeightRule not explicitly set, more text sample

            // Add sixth row.
            var row6 = table.AddRow();

            // Set row height.
            row6.Height = Unit.FromCentimeter(2.5);

            // Add paragraph to first cell of row6.
            row6[0].AddParagraph("Text A6:\n" +
                                 "Implicitly at least 2.5 cm row height");

            // Add paragraph to second cell of row6.
            paragraph = row6[1].AddParagraph("Text B6:\n");
            paragraph.AddFormattedText("The cell height will be adjusted to fit text that exceeds the given height. " +
                                       "The cell height will be adjusted to fit text that exceeds the given height.", dummyTextStyleName);

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
