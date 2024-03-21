// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class Language : FeatureBase
    {
        public static void Run()
        {
            new Language().CreatePdf();
        }

        void CreatePdf()
        {
            // Create PDF document.
            var document = new PdfDocument();
            document.ViewerPreferences.FitWindow = true;
            document.PageLayout = PdfPageLayout.SinglePage;

            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(document);
            uaManager.SetDocumentLanguage("en-US");

            // Create a font (nothing special here).
            var font = new XFont("Segoe UI", 12, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create a paragraph.
            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                // Insert some text.
                gfx.DrawString("In Germany we say ", font, XBrushes.DarkBlue, 50, 100);

                // Create a nested structure element.
                sb.BeginElement(PdfInlineLevelElementTag.Span);
                {
                    // Insert the German text without changing language.
                    gfx.DrawString("\"Herzlichen Glückwunsch!\" ", font, XBrushes.DarkBlue, 50, 120);
                }
                sb.End();
                
                // Insert further text in.
                gfx.DrawString("to congratulate somebody.", font, XBrushes.DarkBlue, 50, 140);

                // Insert some text.
                gfx.DrawString("But attention - we pronounce it ", font, XBrushes.DarkBlue, 50, 180);

                // Create a nested structure element.
                sb.BeginElement(PdfInlineLevelElementTag.Span);
                {
                    // Change the language for the current structure element.
                    sb.SetLanguage("de-DE");

                    // Insert the text in the new language.
                    gfx.DrawString("\"Herzlichen Glückwunsch!\" ", font, XBrushes.DarkBlue, 50, 200);
                }
                sb.End();

                // Insert further text in the original language.
                gfx.DrawString("in German.", font, XBrushes.DarkBlue, 50, 220);
            }
            sb.End();

            SaveAndShowDocument(document, "Language");
        }
    }
}
