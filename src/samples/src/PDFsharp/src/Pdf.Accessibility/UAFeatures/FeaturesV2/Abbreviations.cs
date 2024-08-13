// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;
using PdfSharp.UniversalAccessibility.Drawing;

namespace UAFeatures.FeaturesV2
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
            var font = new XFont("Arial", 12, XFontStyleEx.Italic);
            var fontH1 = new XFont("Arial", 20, XFontStyleEx.Italic);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create Heading 1 element in one line of code.
            gfx.DrawString("An abbreviation sample", fontH1, XBrushes.DarkBlue, 50, 50, PdfBlockLevelElementTag.Heading1);

            // Create a paragraph.
            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            {
                // Insert simple text.
                gfx.DrawString("A text with an ", font, XBrushes.DarkBlue, 50, 100);

                // Insert an abbreviation in one line of code. Note that we also need the trailing blank here, if there was one in pure text representation.
                gfx.DrawAbbreviation("abbr.", "abbreviation ", font, XBrushes.DarkBlue, 50, 120);

                // Insert further text.
                gfx.DrawString("in a structure element in the middle.", font, XBrushes.DarkBlue, 50, 140);
            }
            sb.End();

            SaveAndShowDocument(document, "AbbreviationsV2");
        }
    }
}
