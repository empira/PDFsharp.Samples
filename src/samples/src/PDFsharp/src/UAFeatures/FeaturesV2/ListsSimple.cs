// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;
using PdfSharp.UniversalAccessibility.Drawing;

namespace UAFeatures.FeaturesV2
{
    class ListsSimple : FeatureBase
    {
        public static void Run()
        {
            new ListsSimple().CreatePdf();
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
            var font = new XFont("Arial     ", 12, XFontStyleEx.Italic);
            var fontH1 = new XFont("Arial", 20, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            {
                gfx.DrawString("Simple list", fontH1, XBrushes.DarkBlue, 50, 50);
            }
            sb.End();

            // Create a new list.
            sb.BeginElement(PdfBlockLevelElementTag.List);
            {
                // Create the first list item in one line of code.
                gfx.DrawListItem("1)", "Item 1", font, XBrushes.DarkBlue, 50, 80, 20);

                // Create the second list item.
                sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                {
                    // Create the label of the second list item in one line of code.
                    gfx.DrawString("2)", font, XBrushes.DarkBlue, 50, 100, PdfBlockLevelElementTag.Label);

                    // Create a LBody structure element for the second list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                    {
                        // Draw some text.
                        gfx.DrawString("Item 2", font, XBrushes.DarkBlue, 70, 100);

                        // Create a nested list.
                        sb.BeginElement(PdfBlockLevelElementTag.List);
                        {
                            // Create the first list item of the nested list in one line of code.
                            gfx.DrawListItem("a)", "Item 2a", font, XBrushes.DarkBlue, 70, 120, 20);

                            // Create the second list item of the nested list in one line of code.
                            gfx.DrawListItem("b)", "Item 2b", font, XBrushes.DarkBlue, 70, 140, 20);
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();

            SaveAndShowDocument(document, "ListsSimpleV2");
        }
    }
}
