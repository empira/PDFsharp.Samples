// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class Tables : FeatureBase
    {
        public static void Run()
        {
            new Tables().CreatePdf();
        }

        PdfDocument _document = default!;

        // Create a font (nothing special here).
        readonly XFont _font = new XFont("Segoe UI", 12, XFontStyleEx.Italic);
        readonly XFont _fontH1 = new XFont("Segoe UI", 20, XFontStyleEx.Italic);
        readonly XFont _fontTH = new XFont("Segoe UI", 10, XFontStyleEx.Bold);

        void CreateSimpleTable()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            {
                gfx.DrawString("Simple table", _fontH1, XBrushes.DarkBlue, 50, 50);
            }
            sb.End();

            // Create a new table.
            sb.BeginElement(PdfBlockLevelElementTag.Table);
            {
                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 1", _fontTH, XBrushes.DarkBlue, 50, 100);
                    }
                    sb.End();

                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 2", _fontTH, XBrushes.DarkBlue, 100, 100);
                    }
                    sb.End();
                }
                sb.End();

                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 1", _font, XBrushes.DarkBlue, 50, 120);
                    }
                    sb.End();

                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 2", _font, XBrushes.DarkBlue, 100, 120);
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreateHeadBodyFootTable()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            {
                gfx.DrawString("Table with THead, TBody and TFoot", _fontH1, XBrushes.DarkBlue, 50, 250);
            }
            sb.End();

            // Create a new table.
            sb.BeginElement(PdfBlockLevelElementTag.Table);
            {
                // Create a THead element containing all the header rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableHeadRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new header cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                        {
                            gfx.DrawString("Header 1", _fontTH, XBrushes.DarkBlue, 50, 300);
                        }
                        sb.End();

                        // Create a new header cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                        {
                            gfx.DrawString("Header 2", _fontTH, XBrushes.DarkBlue, 100, 300);
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();

                // Create a TBody element containing all the data rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableBodyRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Data 1", _font, XBrushes.DarkBlue, 50, 320);
                        }
                        sb.End();

                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Data 2", _font, XBrushes.DarkBlue, 100, 320);
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();

                // Create a TFoot element containing all the footer rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableFooterRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Footer 1", _font, XBrushes.DarkBlue, 50, 340);
                        }
                        sb.End();

                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Footer 2", _font, XBrushes.DarkBlue, 100, 340);
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreateBorderTable()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            {
                gfx.DrawString("Table with drawn borders", _fontH1, XBrushes.DarkBlue, 50, 50);
            }
            sb.End();

            // Create a new table.
            sb.BeginElement(PdfBlockLevelElementTag.Table);
            {
                // Create a TableHeadRowGroup element containing all the header rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableHeadRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new header cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                        {
                            gfx.DrawString("Header 1", _fontTH, XBrushes.DarkBlue, 50, 100);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(45, 85), new XPoint(45, 105));
                            gfx.DrawLine(XPens.Black, new XPoint(45, 85), new XPoint(95, 85));
                        }
                        sb.End();

                        // Create a new header cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                        {
                            gfx.DrawString("Header 2", _fontTH, XBrushes.DarkBlue, 100, 100);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(95, 85), new XPoint(95, 105));
                            gfx.DrawLine(XPens.Black, new XPoint(95, 85), new XPoint(145, 85));
                            // Draw the right border.
                            gfx.DrawLine(XPens.Black, new XPoint(145, 85), new XPoint(145, 105));
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();

                // Create a TableBodyRowGroup element containing all the data rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableBodyRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Data 1", _font, XBrushes.DarkBlue, 50, 120);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(45, 105), new XPoint(45, 125));
                            gfx.DrawLine(XPens.Black, new XPoint(45, 105), new XPoint(95, 105));
                        }
                        sb.End();

                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Data 2", _font, XBrushes.DarkBlue, 100, 120);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(95, 105), new XPoint(95, 125));
                            gfx.DrawLine(XPens.Black, new XPoint(95, 105), new XPoint(145, 105));
                            // Draw the right border.
                            gfx.DrawLine(XPens.Black, new XPoint(145, 105), new XPoint(145, 125));
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();

                // Create a TableFooterRowGroup element containing all the footer rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableFooterRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Footer 1", _font, XBrushes.DarkBlue, 50, 140);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(45, 125), new XPoint(45, 145));
                            gfx.DrawLine(XPens.Black, new XPoint(45, 125), new XPoint(95, 125));
                            // Draw the bottom border.
                            gfx.DrawLine(XPens.Black, new XPoint(45, 145), new XPoint(95, 145));
                        }
                        sb.End();

                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Footer 2", _font, XBrushes.DarkBlue, 100, 140);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(95, 125), new XPoint(95, 145));
                            gfx.DrawLine(XPens.Black, new XPoint(95, 125), new XPoint(145, 125));
                            // Draw the right and bottom border.
                            gfx.DrawLine(XPens.Black, new XPoint(145, 125), new XPoint(145, 145));
                            gfx.DrawLine(XPens.Black, new XPoint(95, 145), new XPoint(145, 145));
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreatePageSpanningTable()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            {
                gfx.DrawString("A table spanning over two pages with repeating header", _fontH1, XBrushes.DarkBlue, 50, 250);
            }
            sb.End();

            // Create a new table. We don't use TableHeadRowGroup because it is only allowed to use it once per table.
            sb.BeginElement(PdfBlockLevelElementTag.Table);
            {
                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 1", _fontTH, XBrushes.DarkBlue, 50, 300);
                    }
                    sb.End();

                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 2", _fontTH, XBrushes.DarkBlue, 100, 300);
                    }
                    sb.End();
                }
                sb.End();

                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 1", _font, XBrushes.DarkBlue, 50, 320);
                    }
                    sb.End();

                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 2", _font, XBrushes.DarkBlue, 100, 320);
                    }
                    sb.End();
                }
                sb.End();

                // Create a third page.
                var page = _document.AddPage();
                gfx = XGraphics.FromPdfPage(page);

                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 1", _fontTH, XBrushes.DarkBlue, 50, 100);
                    }
                    sb.End();

                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 2", _fontTH, XBrushes.DarkBlue, 100, 100);
                    }
                    sb.End();
                }
                sb.End();

                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 1b", _font, XBrushes.DarkBlue, 50, 120);
                    }
                    sb.End();

                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 2b", _font, XBrushes.DarkBlue, 100, 120);
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreatePdf()
        {
            // Create PDF document.
            _document = new PdfDocument();
            _document.ViewerPreferences.FitWindow = true;
            _document.PageLayout = PdfPageLayout.SinglePage;

            // Initialize the manager for universal accessibility.
            UAManager.ForDocument(_document);

            // Create a page and a graphics object as usual.
            var page = _document.AddPage();
            // The next line is required to get this XGraphics object later via uaManager.CurrentGraphics.
            XGraphics.FromPdfPage(page);

            CreateSimpleTable();

            CreateHeadBodyFootTable();

            // Create a second page.
            page = _document.AddPage();
            // The next line is required to get this XGraphics object later via uaManager.CurrentGraphics.
            XGraphics.FromPdfPage(page);

            CreateBorderTable();

            CreatePageSpanningTable();

            SaveAndShowDocument(_document, "Tables");
        }
    }
}
