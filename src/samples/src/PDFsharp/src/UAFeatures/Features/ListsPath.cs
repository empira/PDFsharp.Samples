// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class ListsPath : FeatureBase
    {
        public static void Run()
        {
            new ListsPath().CreatePdf();
        }

        void CreatePdf()
        {
            // Create PDF document.
            var document = new PdfDocument();
            document.ViewerPreferences.FitWindow = true;
            document.PageLayout = PdfPageLayout.SinglePage;

            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(document);

            // Create a font (nothing special here).
            var font = new XFont("Segoe UI", 12, XFontStyleEx.Italic);
            var fontH1 = new XFont("Segoe UI", 20, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            {
                gfx.DrawString("List with paths as label", fontH1, XBrushes.DarkBlue, 50, 50);
            }
            sb.End();

            // Create a new list.
            sb.BeginElement(PdfBlockLevelElementTag.List);
            {
                // Create the first list item.
                sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                {
                    // Create the label of the first list item.
                    sb.BeginElement(PdfBlockLevelElementTag.Label);
                    {
                        // Draw an ellipse as the list item's label.
                        gfx.DrawEllipse(XBrushes.DarkBlue, 50, 75, 3, 3);

                        // Set the alternative text for the label's structure element.
                        sb.SetAltText("Bullet");
                    }
                    sb.End();

                    // Add the list item's content into a ListBody structure element.
                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                    {
                        gfx.DrawString("Item 1", font, XBrushes.DarkBlue, 60, 80);
                    }
                    sb.End();
                }
                sb.End();

                // Create the second list item.
                sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                {
                    // Create the label of the second list item.
                    sb.BeginElement(PdfBlockLevelElementTag.Label);
                    {
                        // Draw an ellipse as the list item's label.
                        gfx.DrawEllipse(XBrushes.DarkBlue, 50, 95, 3, 3);

                        // Set the alternative text for the label's structure element.
                        sb.SetAltText("Bullet");
                    }
                    sb.End();

                    // Add the list item's content into a ListBody structure element.
                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                    {
                        gfx.DrawString("Item 2", font, XBrushes.DarkBlue, 60, 100);
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();

            SaveAndShowDocument(document, "ListsPath");
        }
    }
}
