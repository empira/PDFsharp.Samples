// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
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
            var font = new XFont("Arial", 12, XFontStyleEx.Italic);
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
                // Create the first list item.
                sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                {
                    // Create the label of the first list item.
                    sb.BeginElement(PdfBlockLevelElementTag.Label);
                    {
                        gfx.DrawString("1)", font, XBrushes.DarkBlue, 50, 80);
                    }
                    sb.End();

                    // Add the list item's content into a ListBody structure element.
                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                    {
                        gfx.DrawString("Item 1", font, XBrushes.DarkBlue, 70, 80);
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
                        gfx.DrawString("2)", font, XBrushes.DarkBlue, 50, 100);
                    }
                    sb.End();

                    // Create a ListBody structure element for the second list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                    {
                        // Draw some text.
                        gfx.DrawString("Item 2", font, XBrushes.DarkBlue, 70, 100);

                        // Create a nested list.
                        sb.BeginElement(PdfBlockLevelElementTag.List);
                        {
                            // Create the first list item of the nested list.
                            sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                            {
                                // Create the label of the nested list's first item.
                                sb.BeginElement(PdfBlockLevelElementTag.Label);
                                {
                                    gfx.DrawString("a)", font, XBrushes.DarkBlue, 70, 120);
                                }
                                sb.End();

                                // Add the list item's content into a ListBody structure element.
                                sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                {
                                    gfx.DrawString("Item 2a", font, XBrushes.DarkBlue, 90, 120);
                                }
                                sb.End();
                            }
                            sb.End();

                            // Create the second list item of the nested list.
                            sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                            {
                                // Create the label of the nested list's second item.
                                sb.BeginElement(PdfBlockLevelElementTag.Label);
                                {
                                    gfx.DrawString("b)", font, XBrushes.DarkBlue, 70, 140);
                                }
                                sb.End();

                                // Add the list item's content into a ListBody structure element.
                                sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                {
                                    gfx.DrawString("Item 2b", font, XBrushes.DarkBlue, 90, 140);
                                }
                                sb.End();
                            }
                            sb.End();
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
            
            SaveAndShowDocument(document, "ListsSimple");
        }
    }
}
