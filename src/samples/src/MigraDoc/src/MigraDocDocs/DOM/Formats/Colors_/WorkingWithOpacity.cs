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
    /// "Working with opacity" chapter.
    /// </summary>
    static class WorkingWithOpacity
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Colors";

        const string Filename = $"{Path}/WorkingWithOpacity.pdf";
        const string SampleName = "Working with opacity";

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

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}