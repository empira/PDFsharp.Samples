// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace MigraDocDocs.DOM.Formats.Colors_
{
    /// <summary>
    /// "From hexadecimal value" chapter.
    /// </summary>
    static class FromHexValue
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Colors";

        const string Filename = $"{Path}/FromHexValue.pdf";
        const string SampleName = "From hexadecimal value";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // Add TextFrame with cyan background to show opacity.
            var textFrame = section.AddTextFrame();
            textFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            textFrame.RelativeVertical = RelativeVertical.Margin;
            textFrame.Left = Unit.FromCentimeter(2);
            textFrame.Width = Unit.FromCentimeter(2.5);
            textFrame.Height = Unit.FromCentimeter(2.5);
            textFrame.FillFormat.Color = Colors.Cyan;

            // --- Sample content

            // From hex number with 8 digits: 0xaarrggbb
            var paragraph = section.AddParagraph("Font from hex number with 0x and 8 digits");
            paragraph.Format.Font.Color = new Color(0x40ff8040);

            // From hex string with 0x and 8 digits: "0xaarrggbb"
            paragraph = section.AddParagraph("Font from hex string with 0x and 8 digits");
            paragraph.Format.Font.Color = Color.Parse("0x40ff8040");

            // From hex string with # and 8 digits: "#aarrggbb"
            paragraph = section.AddParagraph("Font from hex string with # and 8 digits");
            paragraph.Format.Font.Color = Color.Parse("#40ff8040");

            // From hex string with # and 6 digits: "#rrggbb" with alpha set to FF, so the actual value is 0xffff8040.
            paragraph = section.AddParagraph("Font from hex string with # and 6 digits");
            paragraph.Format.Font.Color = Color.Parse("#ff8040");

            // From hex string with # and 3 digits: "#rgb" with alpha set to FF and each color component digit duplicated, so the actual value is 0xffff8844.
            paragraph = section.AddParagraph("Font from hex string with # and 3 digits");
            paragraph.Format.Font.Color = Color.Parse("#f84");

            // --- Rendering

            // Create a renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer
            {
                // Associate the MigraDoc document with a renderer.
                Document = document,
                // Let the PDF viewer show this PDF with full pages.
                PdfDocument =
                {
                    PageLayout = PdfPageLayout.SinglePage,
                    ViewerPreferences =
                    {
                        FitWindow = true
                    }
                }
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}