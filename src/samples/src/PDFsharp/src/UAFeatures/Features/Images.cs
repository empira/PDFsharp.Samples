// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
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
            var font = new XFont("Segoe UI", 16, XFontStyleEx.Italic);
            var fontH1 = new XFont("Segoe UI", 20, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            gfx.DrawString("An image sample", fontH1, XBrushes.DarkBlue, 50, 100);
            sb.End();

            // Create a paragraph.
            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                gfx.DrawString("A paragraph", font, XBrushes.DarkBlue, 50, 200);

                // Insert an image with unchanged size.
                // Create the figure and pass its alternate text and its bounding box as a parameter.
                var image = XImage.FromFile(IOUtility.GetAssetsPath(@"archives\samples-1.5\images\Z3.jpg")!);
                sb.BeginElement(PdfIllustrationElementTag.Figure, "A BMW Z3 driving through a sandstone desert.", new XRect(50, 300, image.PointWidth, image.PointHeight));
                {
                    // Add the image as usual.
                    gfx.DrawImage(image, 50, 300);
                }
                sb.End();

                // Insert an image with a defined size.
                // Create the figure and pass its alternate text and its bounding box as a parameter.
                sb.BeginElement(PdfIllustrationElementTag.Figure, "A scaled BMW Z3 driving through a sandstone desert.", new XRect(50, 500, 400, 300));
                {
                    // Add the image as usual.
                    gfx.DrawImage(image, 50, 500, 400, 300);
                }
                sb.End();
            }
            sb.End();

            SaveAndShowDocument(document, "Images");
        }
    }
}
