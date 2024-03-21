// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class Artifacts : FeatureBase
    {
        public static void Run()
        {
            new Artifacts().CreatePdf();
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

            // Create a paragraph.
            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                // Begin inserting text.
                gfx.DrawString("A paragraph ", font, XBrushes.DarkBlue, 50, 100);

                // Insert an artifact.
                sb.BeginArtifact();
                {
                    // This text is, as it is included in the artifact, not handled as actual content of the document. A screen reader will skip this text.
                    gfx.DrawString("An artifact ", font, XBrushes.Gray, 50, 150);
                }
                sb.End();

                // Continue with the text.
                gfx.DrawString("that contains ", font, XBrushes.DarkBlue, 50, 200);

                // Insert another artifact.
                sb.BeginArtifact();
                {
                    // Include some graphics and text into the artifact. As this is not handled as content, we don't even have to define an alternate text for the graphics.
                    gfx.DrawRectangle(XBrushes.Gray, 50, 225, 100, 50);
                    gfx.DrawString("A second artifact ", font, XBrushes.Gray, 200, 250);
                    gfx.DrawEllipse(XBrushes.Gray, 300, 225, 50, 50);
                    gfx.DrawImage(XImage.FromFile(IOUtility.GetAssetsPath(@"archives\samples-1.5\images\Z3.jpg")!), 400, 225, 75, 50);
                }
                sb.End();

                // Continue with the text.
                gfx.DrawString("text and ", font, XBrushes.DarkBlue, 50, 300);

                gfx.DrawString("some artifacts." , font, XBrushes.DarkBlue, 50, 400);
            }
            sb.End();

            SaveAndShowDocument(document, "Artifacts");
        }
    }
}
