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
    /// "Color channels" chapter.
    /// </summary>
    static class ColorChannels
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Colors";

        const string Filename = $"{Path}/ColorChannels.pdf";
        const string SampleName = "Color channels";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Channels from an RGB color
            var color = Color.FromArgb(64, 255, 128, 64);
            var paragraph = section.AddParagraph();
            var formattedText = paragraph.AddFormattedText("Channels from this RGB color:\n");
            formattedText.Font.Color = color;
            paragraph.AddText($"ARGB: {color.Argb:X}\n" +
                              $"ARGB Channels:\n" +
                              $"\tA: {color.A:X}\n" +
                              $"\tR: {color.R:X}\n" +
                              $"\tG: {color.G:X}\n" +
                              $"\tB: {color.B:X}\n" +
                              $"\tIsCmyk: {color.IsCmyk}\n" +
                              $"CMYK Channels:\n" +
                              $"\tAlpha: {color.Alpha:0.#}\n" +
                              $"\tC: {color.C:0.#}\n" +
                              $"\tM: {color.M:0.#}\n" +
                              $"\tY: {color.Y:0.#}\n" +
                              $"\tK: {color.K:0.#}");

            // Channels from an CMYK color
            color = Color.FromCmyk(25, 100, 50, 25, 12.5);
            paragraph = section.AddParagraph();
            formattedText = paragraph.AddFormattedText("Channels from this CMYK color:\n");
            formattedText.Font.Color = color;
            paragraph.AddText($"ARGB: {color.Argb:X}\n" +
                              $"ARGB Channels:\n" +
                              $"\tA: {color.A:X}\n" +
                              $"\tR: {color.R:X}\n" +
                              $"\tG: {color.G:X}\n" +
                              $"\tB: {color.B:X}\n" +
                              $"\tIsCmyk: {color.IsCmyk}\n" +
                              $"CMYK Channels:\n" +
                              $"\tAlpha: {color.Alpha:0.#}\n" +
                              $"\tC: {color.C:0.#}\n" +
                              $"\tM: {color.M:0.#}\n" +
                              $"\tY: {color.Y:0.#}\n" +
                              $"\tK: {color.K:0.#}");

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