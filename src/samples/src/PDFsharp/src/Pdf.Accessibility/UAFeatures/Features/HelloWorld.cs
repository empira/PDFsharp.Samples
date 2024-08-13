// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class HelloWorld : FeatureBase
    {
        public static void Run()
        {
            new HelloWorld().CreatePdf();
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
            var font = new XFont("Arial", 16, XFontStyleEx.Italic);
            var fontH1 = new XFont("Arial", 20, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create article element in document.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Create a page and a graphics object as usual.
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);

                // Create Heading 1 element.
                sb.BeginElement(PdfBlockLevelElementTag.Heading1);
                gfx.DrawString("Header Text", fontH1, XBrushes.DarkBlue, 50, 100);
                sb.End();

                // Create paragraph element.
                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                // A trailing blank is needed here to make word break identification possible for screen readers.
                // If there are several DrawStrings in one BlockLevelElement, insert trailing blanks as if you would write the content as pure text.
                gfx.DrawString("Line 1 ", font, XBrushes.DarkBlue, 50, 200);
                gfx.DrawString("Line 2", font, XBrushes.DarkBlue, 50, 250);
                sb.End();
            }
            sb.End();

            SaveAndShowDocument(document, "HelloWorld");
        }
    }
}
