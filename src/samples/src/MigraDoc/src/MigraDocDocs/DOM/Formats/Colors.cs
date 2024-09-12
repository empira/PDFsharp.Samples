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
#pragma warning disable IDE0017

namespace MigraDocDocs.DOM.Formats
{
    static class Colors_
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Colors";

        /// <summary>
        /// "Using predefined colors" chapter.
        /// </summary>
        public static string UsingPredefinedColors()
        {
            const string filename = $"{Path}/UsingPredefinedColors.pdf";
            const string sampleName = "Using predefined colors";
            
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            var paragraph = section.AddParagraph("Font in \"CornflowerBlue\"");
            paragraph.Format.Font.Color = Colors.CornflowerBlue;

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "From RGB or CMYK value" chapter.
        /// </summary>
        public static string FromRgbOrCmyk()
        {
            const string filename = $"{Path}/FromRgbOrCmyk.pdf";
            const string sampleName = "From RGB or CMYK value";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "Working with opacity" chapter.
        /// </summary>
        public static string WorkingWithOpacity()
        {
            const string filename = $"{Path}/WorkingWithOpacity.pdf";
            const string sampleName = "Working with opacity";

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
            textFrame.Height = Unit.FromCentimeter(4.5);
            textFrame.FillFormat.Color = Colors.Cyan;

            // --- Sample content

            // From RGB with high opacity
            var paragraph = section.AddParagraph("Font from RGB with high opacity using constructor");
            paragraph.Format.Font.Color = new Color(196, 255, 128, 64);

            paragraph = section.AddParagraph("Font from RGB with high opacity using FromArgb method");
            paragraph.Format.Font.Color = Color.FromArgb(196, 255, 128, 64);

            // From RGB with low opacity
            paragraph = section.AddParagraph("Font from RGB with low opacity using constructor");
            paragraph.Format.Font.Color = new Color(64, 255, 128, 64);

            paragraph = section.AddParagraph("Font from RGB with low opacity using FromArgb method");
            paragraph.Format.Font.Color = Color.FromArgb(64, 255, 128, 64);

            // From CMYK with high opacity
            paragraph = section.AddParagraph("Font from CMYK with high opacity using constructor");
            paragraph.Format.Font.Color = new Color(75, 100, 50, 25, 12.5);

            paragraph = section.AddParagraph("Font from CMYK with high opacity using FromCmyk method");
            paragraph.Format.Font.Color = Color.FromCmyk(75, 100, 50, 25, 12.5);

            // From CMYK with low opacity
            paragraph = section.AddParagraph("Font from CMYK with low opacity using constructor");
            paragraph.Format.Font.Color = new Color(25, 100, 50, 25, 12.5);

            paragraph = section.AddParagraph("Font from CMYK with low opacity using FromCmyk method");
            paragraph.Format.Font.Color = Color.FromCmyk(25, 100, 50, 25, 12.5);

            // From existing RGB color with added low opacity
            paragraph = section.AddParagraph("Font from existing RGB color with added low opacity");
            var color = Color.FromRgb(255, 128, 64);
            paragraph.Format.Font.Color = Color.FromRgbColor(64, color);

            // From existing CMYK color with added low opacity
            paragraph = section.AddParagraph("Font from existing CMYK color with added low opacity");
            color = Color.FromCmyk(100, 50, 25, 12.5);
            paragraph.Format.Font.Color = Color.FromCmykColor(25, color);


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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "From hexadecimal value" chapter.
        /// </summary>
        public static string FromHexValue()
        {
            const string filename = $"{Path}/FromHexValue.pdf";
            const string sampleName = "From hexadecimal value";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }
        
        /// <summary>
        /// "Color channels" chapter.
        /// </summary>
        public static string ColorChannels()
        {
            const string filename = $"{Path}/ColorChannels.pdf";
            const string sampleName = "Color channels";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }
    }
}