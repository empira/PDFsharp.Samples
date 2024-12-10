// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace MigraDocDocs.DOM.Formats.Colors_
{
    /// <summary>
    /// "From RGB or CMYK value" chapter.
    /// </summary>
    static class FromRgbOrCmyk
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Colors";

        const string Filename = $"{Path}/FromRgbOrCmyk.pdf";
        const string SampleName = "From RGB or CMYK value";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // From RGB
            var paragraph = section.AddParagraph("Font from RGB using constructor");
            paragraph.Format.Font.Color = new Color(255, 128, 64);

            paragraph = section.AddParagraph("Font from RGB using FromRgb method");
            paragraph.Format.Font.Color = Color.FromRgb(255, 128, 64);

            // From CMYK
            paragraph = section.AddParagraph("Font from CMYK using constructor");
            paragraph.Format.Font.Color = new Color(100, 50, 25, 12.5);

            paragraph = section.AddParagraph("Font from CMYK using FromCmyk method");
            paragraph.Format.Font.Color = Color.FromCmyk(100, 50, 25, 12.5);

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