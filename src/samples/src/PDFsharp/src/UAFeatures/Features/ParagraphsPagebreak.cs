using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class ParagraphsPagebreak : FeatureBase
    {
        public static void Run()
        {
            new ParagraphsPagebreak().CreatePdf();
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

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                // Draw text on first page.
                gfx.DrawString("A paragraph that contains text content on its first page, ", font, XBrushes.DarkBlue, 50, 100);

                // Break to second page.
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);

                // Draw text on second page, but still same paragraph.
                gfx.DrawString("text content, ", font, XBrushes.DarkBlue, 50, 100);

                // Create an inline element of type Span within current paragraph.
                sb.BeginElement(PdfInlineLevelElementTag.Span);
                gfx.DrawString("a span, ", font, XBrushes.DarkBlue, 50, 150);
                sb.End();

                // Continue text in paragraph.
                gfx.DrawString("and more text content on its second page ", font, XBrushes.DarkBlue, 50, 200);

                // Break to third page.
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);

                // Further text, but still in the paragraph that starts on page one.
                gfx.DrawString("and further text content ", font, XBrushes.DarkBlue, 50, 100);
                gfx.DrawString("on its third page.", font, XBrushes.DarkBlue, 50, 150);
            }
            sb.End();

            SaveAndShowDocument(document, "ParagraphsPagebreak");
        }
    }
}
