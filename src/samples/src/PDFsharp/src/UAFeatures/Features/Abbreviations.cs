// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class Abbreviations : FeatureBase
    {
        public static void Run()
        {
            new Abbreviations().CreatePdf();
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
            var fontH1 = new XFont("Segoe UI", 20, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            gfx.DrawString("An abbreviation sample", fontH1, XBrushes.DarkBlue, 50, 50);
            sb.End();

            // Create a paragraph.
            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                // Insert simple text.
                gfx.DrawString("A text with an ", font, XBrushes.DarkBlue, 50, 100);

                // Insert a Span for an abbreviation.
                sb.BeginElement(PdfInlineLevelElementTag.Span);
                {
                    // Draw the abbreviation.
                    gfx.DrawString("abbr.", font, XBrushes.DarkBlue, 50, 120);
                    // Set the expanded text for the abbreviation. Note that we also need the trailing blank here, if there was one in pure text representation.
                    sb.SetExpandedText("abbreviation ");
                }
                sb.End();

                // Insert further text.
                gfx.DrawString("in a structure element in the middle.", font, XBrushes.DarkBlue, 50, 140);
            }
            sb.End();

            SaveAndShowDocument(document, "Abbreviations");
        }
    }
}
