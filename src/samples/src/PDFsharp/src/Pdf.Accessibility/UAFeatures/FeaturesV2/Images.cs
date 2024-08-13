// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.UniversalAccessibility;
using PdfSharp.UniversalAccessibility.Drawing;

namespace UAFeatures.FeaturesV2
{
    class Images : FeatureBase
    {
        public static void Run()
        {
            new Images().CreatePdf();
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

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create Heading 1 element in one line of code.
            gfx.DrawString("An image sample", fontH1, XBrushes.DarkBlue, 50, 100, PdfBlockLevelElementTag.Heading1);

            // Create a paragraph.
            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                gfx.DrawString("A paragraph", font, XBrushes.DarkBlue, 50, 200);

                // Insert an image with unchanged size.
                // Create the figure with alternate text and matching bounding box in one line of code.
                var image = XImage.FromFile(IOUtility.GetAssetsPath(@"archives\samples-1.5\images\Z3.jpg")!);
                gfx.DrawImage(image, 50, 300, "A BMW Z3 driving through a sandstone desert.");

                // Insert an image with a defined size.
                // Create the figure with alternate text and matching bounding box in one line of code.
                gfx.DrawImage(image, 50, 500, 400, 300, "A scaled BMW Z3 driving through a sandstone desert.");
            }
            sb.End();

            SaveAndShowDocument(document, "ImagesV2");
        }
    }
}
