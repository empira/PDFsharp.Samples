// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class ParagraphsArticle : FeatureBase
    {
        public static void Run()
        {
            new ParagraphsArticle().CreatePdf();
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
            var fontH2 = new XFont("Arial", 16, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            gfx.DrawString("My first PDF/UA document", fontH1, XBrushes.DarkBlue, 50, 100);
            sb.End();

            // Create article element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert heading in article.
                sb.BeginElement(PdfBlockLevelElementTag.Heading1);
                gfx.DrawString("My first chapter", fontH2, XBrushes.DarkBlue, 50, 150);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("My first paragraph", font, XBrushes.DarkBlue, 50, 200);
                sb.End();

                // StructureElement with two DrawStrings.
                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    gfx.DrawString("A paragraph ", font, XBrushes.DarkBlue, 50, 250);
                    gfx.DrawString("that contains two DrawStrings", font, XBrushes.DarkBlue, 50, 270);
                }
                sb.End();
            }
            sb.End();

            SaveAndShowDocument(document, "ParagraphsArticle");
        }
    }
}
