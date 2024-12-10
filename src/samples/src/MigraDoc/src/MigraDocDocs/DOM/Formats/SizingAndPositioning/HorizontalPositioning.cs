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
    /// "Horizontal positioning" chapter.
    /// </summary>
    static class HorizontalPositioning
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/SizingAndPositioning";
        
        const string Filename = $"{Path}/HorizontalPositioning.pdf";
        const string SampleName = "Horizontal positioning";

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
                textFrame.AddParagraph("Default (at left page margin)");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2.5);

                // Without textFrame.Left and textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned at the left page margin.

                textFrame.FillFormat.Color = Colors.Cyan;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            // -- ShapePosition samples

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Horizontally centered (inside page margins)");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2.5);

                // Make textFrame horizontally centered.
                // Without textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned inside the page margins.
                textFrame.Left = ShapePosition.Center;

                textFrame.FillFormat.Color = Colors.Magenta;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Right (inside page margins)");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2.5);

                // Make textFrame right aligned.
                // Without textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned inside the page margins.
                textFrame.Left = ShapePosition.Right;

                textFrame.FillFormat.Color = Colors.Yellow;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Right inside page borders");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2.5);

                // Make textFrame right aligned inside the page borders.
                textFrame.Left = ShapePosition.Right;
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                textFrame.FillFormat.Color = Colors.Red;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            // -- Unit samples

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("2 cm (from left page margin)");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2.5);

                // Set left position to 2 cm.
                // Without textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned inside the page margins.
                textFrame.Left = Unit.FromCentimeter(2);

                textFrame.FillFormat.Color = Colors.Lime;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("2 cm from left page border");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2.5);

                // Set left position to 2 cm from the left page border.
                textFrame.Left = Unit.FromCentimeter(2);
                textFrame.RelativeHorizontal = RelativeHorizontal.Page;

                textFrame.FillFormat.Color = Colors.Cyan;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            // -- Inside and outside samples

            // Create a new section with mirrored margins.
            section = document.AddSection();
            section.PageSetup.LeftMargin = Unit.FromCentimeter(4);
            section.PageSetup.RightMargin = Unit.FromCentimeter(2);
            section.PageSetup.MirrorMargins = true;

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Outside aligned on even page");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(3);

                // Make textFrame outside aligned.
                // Without textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned inside the page margins.
                textFrame.Left = ShapePosition.Outside;

                textFrame.FillFormat.Color = Colors.Cyan;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Inside aligned on even page");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(3);

                // Make textFrame inside aligned.
                // Without textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned inside the page margins.
                textFrame.Left = ShapePosition.Inside;

                textFrame.FillFormat.Color = Colors.Magenta;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            // Add a page break and identical text frames on an odd page.
            section.AddPageBreak();

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Outside aligned on odd page");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(3);

                // Make textFrame outside aligned.
                // Without textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned inside the page margins.
                textFrame.Left = ShapePosition.Outside;

                textFrame.FillFormat.Color = Colors.Cyan;
                textFrame.LineFormat.Width = Unit.FromPoint(1);
            }

            {
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("Inside aligned on odd page");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(3);

                // Make textFrame inside aligned.
                // Without textFrame.RelativeHorizontal specified,
                // the TextFrame will be positioned inside the page margins.
                textFrame.Left = ShapePosition.Inside;

                textFrame.FillFormat.Color = Colors.Magenta;
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
                    PageLayout = PdfPageLayout.TwoPageRight,
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
