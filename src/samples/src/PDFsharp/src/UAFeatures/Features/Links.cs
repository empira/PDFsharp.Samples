// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class Links : FeatureBase
    {
        public static void Run()
        {
            new Links().CreatePdf();
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
                // Create the links bounding rect.
                var rect = new PdfRectangle(gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(50, 90), new XPoint(205, 105))));
                
                // Create a LinkAnnotation referencing to page 2.
                var link = PdfLinkAnnotation.CreateDocumentLink(rect, 2);

                // Create a new Link structure element with the LinkAnnotation and the alternative text passed as parameters.
                sb.BeginElement(link, "Link to page 2");
                {
                    // Insert the text shown as link.
                    gfx.DrawString("This is a link to the next page.", font, XBrushes.DarkBlue, 50, 100);
                }
                sb.End();
            }
            sb.End();

            // Add a second page.
            page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);
            
            // Create a paragraph.
            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                // Create the links bounding rect.
                var rect = new PdfRectangle(gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(50, 90), new XPoint(235, 105))));
                
                // Create a LinkAnnotation referencing to the empira website.
                var link = PdfLinkAnnotation.CreateWebLink(rect, "http://www.empira.de");

                // Create a new Link structure element with the LinkAnnotation and the alternative text passed as parameters.
                sb.BeginElement(link, "Link to empira website");
                {
                    // Insert the text shown as link.
                    gfx.DrawString("This is a link to the empira website.", font, XBrushes.DarkBlue, 50, 100);
                }
                sb.End();
            }
            sb.End();

            SaveAndShowDocument(document, "Links");
        }
    }
}
