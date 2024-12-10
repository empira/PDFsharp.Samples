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
using PdfSharp.Quality;

namespace MigraDocDocs.DOM.Formats.SizingAndPositioning
{
    /// <summary>
    /// "Vertical positioning" chapter.
    /// </summary>
    static class VerticalPositioning
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/SizingAndPositioning";
        
        const string Filename = $"{Path}/VerticalPositioning.pdf";
        const string SampleName = "vertical positioning";

        public static string Sample()
        {
            // --- Code needed for sample

            // Ensure that assets folder exists.
            // '.\dev\download-assets.ps1' in solution root directory has to be executed before running this sample.
            IOUtility.EnsureAssets();

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Default sample

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Default (at current position in document flow, which is the upper page margin here)");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 2 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(2);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Without textFrame.Top and textFrame.RelativeVertical specified,
                // the TextFrame will be positioned at the current vertical position.

                textFrame.FillFormat.Color = Colors.Cyan;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            // -- ShapePosition samples

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Vertically centered inside page margins");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 4 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(4);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Make textFrame vertically centered inside the page margins.
                textFrame.Top = ShapePosition.Center;
                textFrame.RelativeVertical = RelativeVertical.Margin;

                textFrame.FillFormat.Color = Colors.Magenta;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Bottom inside page margins");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 6 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(6);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Make textFrame bottom aligned inside the page margins.
                textFrame.Top = ShapePosition.Bottom;
                textFrame.RelativeVertical = RelativeVertical.Margin;

                textFrame.FillFormat.Color = Colors.Yellow;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Bottom inside page borders");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 8 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(8);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Make textFrame bottom aligned inside the page borders.
                textFrame.Top = ShapePosition.Bottom;
                textFrame.RelativeVertical = RelativeVertical.Page;

                textFrame.FillFormat.Color = Colors.Red;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            // -- Unit samples

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("2 cm from upper page margin");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 10 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(10);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Set top position to 2 cm from the upper page margin.
                textFrame.Top = Unit.FromCentimeter(2);
                textFrame.RelativeVertical = RelativeVertical.Margin;

                textFrame.FillFormat.Color = Colors.Lime;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("2 cm from upper page border");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 12 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(12);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Set top position to 2 cm from the upper page border.
                textFrame.Top = Unit.FromCentimeter(2);
                textFrame.RelativeVertical = RelativeVertical.Page;

                textFrame.FillFormat.Color = Colors.Cyan;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            // -- In document flow samples

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("0 cm from current position in document flow, which is after the default sample text frame here");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 14 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(14);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Set top position to 0 cm.
                // Without textFrame.RelativeVertical specified, the TextFrame will be
                // positioned at the current position in document flow plus the Top value.
                textFrame.Top = Unit.FromCentimeter(0);

                textFrame.FillFormat.Color = Colors.Magenta;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("2 cm from current position in document flow, which is after the last text frame here");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(2);
                textFrame.Height = Unit.FromCentimeter(4);

                // Set left position to 16 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(16);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                // Set top position to 2 cm.
                // Without textFrame.RelativeVertical specified, the TextFrame will be
                // positioned at the current position in document flow plus the Top value.
                textFrame.Top = Unit.FromCentimeter(2);

                textFrame.FillFormat.Color = Colors.Yellow;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

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
