// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using PdfSharp.UniversalAccessibility;
using PdfSharp.UniversalAccessibility.Drawing;

namespace UAFeatures.FeaturesV2
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
            var font = new XFont("Arial", 12, XFontStyleEx.Italic);

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

                // Create a new Link structure element and content in one line of code.
                gfx.DrawLink("This is a link to the next page.", font, XBrushes.DarkBlue, 50, 100, link, "Link to page 2");
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

                // Create a LinkAnnotation referring to the empira website.
                var link = PdfLinkAnnotation.CreateWebLink(rect, "http://www.empira.de");
                
                // Create a new Link structure element and content in one line of code.
                gfx.DrawLink("This is a link to the empira website.", font, XBrushes.DarkBlue, 50, 100, link, "Link to empira website");
            }
            sb.End();

            SaveAndShowDocument(document, "LinksV2");
        }
    }
}
