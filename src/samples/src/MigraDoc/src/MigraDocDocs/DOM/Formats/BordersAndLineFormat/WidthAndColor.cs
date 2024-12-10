// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace MigraDocDocs.DOM.Formats.BordersAndLineFormat
{
    /// <summary>
    /// "Width & color" chapter.
    /// </summary>
    static class WidthAndColor
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/BordersAndLineFormat";
        
        const string Filename = $"{Path}/WidthAndColor.pdf";
        const string SampleName = "Width & color";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Borders sample

            // Add table.
            var table = section.AddTable();

            // Set Borders width for all cells.
            table.Borders.Width = Unit.FromPoint(5);

            // Set Borders color for all cells.
            table.Borders.Color = Colors.Blue;

            // Add column.
            var column = table.AddColumn(Unit.FromCentimeter(5));

            // Add row.
            var row = table.AddRow();
            
            // Add a paragraph to the cell.
            row[0].AddParagraph("Table Borders");

            // -- LineFormat sample

            var textFrame = section.AddTextFrame();
            textFrame.RelativeHorizontal = RelativeHorizontal.Page;
            textFrame.Left = Unit.FromCentimeter(10.5);
            textFrame.RelativeVertical = RelativeVertical.Margin;
            textFrame.Top = Unit.FromPoint(2.5);
            textFrame.Width = Unit.FromCentimeter(5);
            textFrame.Height = Unit.FromCentimeter(1);

            // Add a paragraph to textFrame.
            textFrame.AddParagraph("TextFrame LineFormat");

            // Set LineFormat width.
            textFrame.LineFormat.Width = Unit.FromPoint(5);

            // Set LineFormat color.
            textFrame.LineFormat.Color = Colors.Blue;

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
