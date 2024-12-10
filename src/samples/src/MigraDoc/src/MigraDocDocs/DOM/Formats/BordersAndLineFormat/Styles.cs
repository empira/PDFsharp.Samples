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
    /// Styles chapter.
    /// </summary>
    static class Styles
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/BordersAndLineFormat";
        
        const string Filename = $"{Path}/Styles.pdf";
        const string SampleName = "Styles";

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

            // -- BorderStyle.Single sample
            {
                // Add table.
                var table = section.AddTable();

                // Set Borders width for all cells.
                table.Borders.Width = Unit.FromPoint(1);

                // Set Borders style for all cells.
                table.Borders.Style = BorderStyle.Single;

                // Add column.
                var column = table.AddColumn(Unit.FromCentimeter(5));

                // Add row.
                var row = table.AddRow();

                // Add a paragraph to the cell.
                row[0].AddParagraph("BorderStyle.Single");
            }

            // Add a paragraph for spacing.
            section.AddParagraph();

            // -- BorderStyle.Dot sample
            {
                // Add table.
                var table = section.AddTable();

                // Set Borders width for all cells.
                table.Borders.Width = Unit.FromPoint(1);

                // Set Borders style for all cells.
                table.Borders.Style = BorderStyle.Dot;

                // Add column.
                var column = table.AddColumn(Unit.FromCentimeter(5));

                // Add row.
                var row = table.AddRow();

                // Add a paragraph to the cell.
                row[0].AddParagraph("BorderStyle.Dot");
            }

            // Add a paragraph for spacing.
            section.AddParagraph();

            // -- BorderStyle.DashSmallGap sample
            {
                // Add table.
                var table = section.AddTable();

                // Set Borders width for all cells.
                table.Borders.Width = Unit.FromPoint(1);

                // Set Borders style for all cells.
                table.Borders.Style = BorderStyle.DashSmallGap;

                // Add column.
                var column = table.AddColumn(Unit.FromCentimeter(5));

                // Add row.
                var row = table.AddRow();

                // Add a paragraph to the cell.
                row[0].AddParagraph("BorderStyle.DashSmallGap");
            }

            // Add a paragraph for spacing.
            section.AddParagraph();

            // -- BorderStyle.DashLargeGap sample
            {
                // Add table.
                var table = section.AddTable();

                // Set Borders width for all cells.
                table.Borders.Width = Unit.FromPoint(1);

                // Set Borders style for all cells.
                table.Borders.Style = BorderStyle.DashLargeGap;

                // Add column.
                var column = table.AddColumn(Unit.FromCentimeter(5));

                // Add row.
                var row = table.AddRow();

                // Add a paragraph to the cell.
                row[0].AddParagraph("BorderStyle.DashLargeGap");
            }

            // Add a paragraph for spacing.
            section.AddParagraph();

            // -- BorderStyle.DashDot sample
            {
                // Add table.
                var table = section.AddTable();

                // Set Borders width for all cells.
                table.Borders.Width = Unit.FromPoint(1);

                // Set Borders style for all cells.
                table.Borders.Style = BorderStyle.DashDot;

                // Add column.
                var column = table.AddColumn(Unit.FromCentimeter(5));

                // Add row.
                var row = table.AddRow();

                // Add a paragraph to the cell.
                row[0].AddParagraph("BorderStyle.DashDot");
            }

            // Add a paragraph for spacing.
            section.AddParagraph();

            // -- BorderStyle.DashDotDot sample
            {
                // Add table.
                var table = section.AddTable();

                // Set Borders width for all cells.
                table.Borders.Width = Unit.FromPoint(1);

                // Set Borders style for all cells.
                table.Borders.Style = BorderStyle.DashDotDot;

                // Add column.
                var column = table.AddColumn(Unit.FromCentimeter(5));

                // Add row.
                var row = table.AddRow();

                // Add a paragraph to the cell.
                row[0].AddParagraph("BorderStyle.DashDotDot");
            }

            // -- DashStyle.Solid sample
            {
                var textFrame = section.AddTextFrame();
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;
                textFrame.Left = Unit.FromCentimeter(10.5);
                textFrame.RelativeVertical = RelativeVertical.Margin;
                textFrame.Top = Unit.Zero;
                textFrame.Width = Unit.FromCentimeter(5);
                textFrame.Height = Unit.FromCentimeter(0.9);

                // Add a paragraph to textFrame.
                textFrame.AddParagraph("DashStyle.Solid");

                // Set LineFormat width.
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                // Set LineFormat style.
                textFrame.LineFormat.DashStyle = DashStyle.Solid;
            }

            // -- DashStyle.Dash sample
            {
                var textFrame = section.AddTextFrame();
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;
                textFrame.Left = Unit.FromCentimeter(10.5);
                textFrame.RelativeVertical = RelativeVertical.Margin;
                textFrame.Top = Unit.FromCentimeter(1.75);
                textFrame.Width = Unit.FromCentimeter(5);
                textFrame.Height = Unit.FromCentimeter(0.9);

                // Add a paragraph to textFrame.
                textFrame.AddParagraph("DashStyle.Dash");

                // Set LineFormat width.
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                // Set LineFormat style.
                textFrame.LineFormat.DashStyle = DashStyle.Dash;
            }

            // -- DashStyle.DashDot sample
            {
                var textFrame = section.AddTextFrame();
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;
                textFrame.Left = Unit.FromCentimeter(10.5);
                textFrame.RelativeVertical = RelativeVertical.Margin;
                textFrame.Top = Unit.FromCentimeter(3.5);
                textFrame.Width = Unit.FromCentimeter(5);
                textFrame.Height = Unit.FromCentimeter(0.9);

                // Add a paragraph to textFrame.
                textFrame.AddParagraph("DashStyle.DashDot");

                // Set LineFormat width.
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                // Set LineFormat style.
                textFrame.LineFormat.DashStyle = DashStyle.DashDot;
            }

            // -- DashStyle.DashDotDot sample
            {
                var textFrame = section.AddTextFrame();
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;
                textFrame.Left = Unit.FromCentimeter(10.5);
                textFrame.RelativeVertical = RelativeVertical.Margin;
                textFrame.Top = Unit.FromCentimeter(5.25);
                textFrame.Width = Unit.FromCentimeter(5);
                textFrame.Height = Unit.FromCentimeter(0.9);

                // Add a paragraph to textFrame.
                textFrame.AddParagraph("DashStyle.DashDotDot");

                // Set LineFormat width.
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                // Set LineFormat style.
                textFrame.LineFormat.DashStyle = DashStyle.DashDotDot;
            }

            // -- DashStyle.SquareDot sample
            {
                var textFrame = section.AddTextFrame();
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;
                textFrame.Left = Unit.FromCentimeter(10.5);
                textFrame.RelativeVertical = RelativeVertical.Margin;
                textFrame.Top = Unit.FromCentimeter(7);
                textFrame.Width = Unit.FromCentimeter(5);
                textFrame.Height = Unit.FromCentimeter(0.9);

                // Add a paragraph to textFrame.
                textFrame.AddParagraph("DashStyle.SquareDot");

                // Set LineFormat width.
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                // Set LineFormat style.
                textFrame.LineFormat.DashStyle = DashStyle.SquareDot;
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
