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
    /// "Single borders" chapter.
    /// </summary>
    static class SingleBorders
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/BordersAndLineFormat";
        
        const string Filename = $"{Path}/SingleBorders.pdf";
        const string SampleName = "Single borders";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Single borders
            {
                // Add table.
                var table = section.AddTable();

                // Add first column.
                var column = table.AddColumn(Unit.FromCentimeter(3));

                // Add row.
                var row = table.AddRow();

                var cell = row[0];

                // Set single borders for cell.
                cell.Borders.Top.Color = Colors.Cyan;
                cell.Borders.Right.Color = Colors.Magenta;
                cell.Borders.Bottom.Color = Colors.Yellow;
                cell.Borders.Left.Color = Colors.Red;
                cell.Borders.DiagonalDown.Color = Colors.Blue;
                cell.Borders.DiagonalUp.Color = Colors.Lime;
            }

            // Add a paragraph for spacing.
            section.AddParagraph();

            // -- General and single borders
            {
                // Add table.
                var table = section.AddTable();

                // Add first column.
                var column = table.AddColumn(Unit.FromCentimeter(3));

                // Add row.
                var row = table.AddRow();

                var cell = row[0];

                // Set general borders for cell.
                cell.Borders.Style = BorderStyle.Dot;

                // Set a single border for cell.
                cell.Borders.Right.Color = Colors.Magenta;
            }

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
