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
    /// "WrapFormat" chapter.
    /// </summary>
    static class WrapFormat
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/SizingAndPositioning";
        
        const string Filename = $"{Path}/WrapFormat.pdf";
        const string SampleName = "WrapFormat";

        public static string Sample()
        {
            // --- Code needed for sample

            // Ensure that assets folder exists.
            // '.\dev\download-assets.ps1' in solution root directory has to be executed before running this sample.
            IOUtility.EnsureAssets();

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(3);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(3);

            // Set Heading1 style.
            style = document.Styles[StyleNames.Heading1];
            style.Font.Bold = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(12);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(6);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- WrapStyle.TopBottom samples

            section.AddParagraph("WrapStyle.TopBottom", StyleNames.Heading1);

            {
                section.AddParagraph("The default for WrapFormat.Style is WrapStyle.TopBottom. Therefore, the TextFrame will follow this paragraph...");

                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("TextFrame with default (TopBottom) WrapStyle");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2);
                
                textFrame.FillFormat.Color = Colors.Cyan;
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                section.AddParagraph("...and precede this paragraph.");
            }

            // -- WrapStyle.Through samples

            section.AddParagraph("WrapStyle.Through", StyleNames.Heading1);

            {

                var image = section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
                image.Resolution = 200;

                // Set WrapStyle to Through, as the next content shall not start below it,
                // but at the same vertical position.
                image.WrapFormat.Style = WrapStyle.Through;

                section.AddParagraph("With WrapFormat.Style of the image set to WrapStyle.Through, this text will start in front of the image and not below it.");
            }

            {
                section.AddParagraph("The first of the next two TextFrames has WrapFormat.Style set to WrapStyle.Through. Therefore, the second one starts at the same height,...");

                // Add a first TextFrame.
                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("TextFrame with Through WrapStyle");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2);

                // Set WrapStyle to Through, as the next content shall not start below it,
                // but at the same vertical position.
                textFrame.WrapFormat.Style = WrapStyle.Through;

                textFrame.FillFormat.Color = Colors.Magenta;
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                var textFrame2 = section.AddTextFrame();
                textFrame2.AddParagraph("TextFrame with default (TopBottom) WrapStyle");

                // Set width and height.
                textFrame2.Width = Unit.FromCentimeter(6);
                textFrame2.Height = Unit.FromCentimeter(2);

                // textFrame2 will be inserted on the same vertical position as textFrame, due to WrapStyle.Through set there.
                // So only move it right.
                textFrame2.Left = Unit.FromCentimeter(7);

                textFrame2.FillFormat.Color = Colors.Yellow;
                textFrame2.LineFormat.Width = Unit.FromPoint(1);

                section.AddParagraph("...but the next paragraph starts below the second TextFrame.");
            }

            // -- WrapFormat distances sample

            section.AddParagraph("WrapFormat distances", StyleNames.Heading1);

            {

                section.AddParagraph("The next TextFrame has defined distances...");

                var textFrame = section.AddTextFrame();
                textFrame.AddParagraph("TextFrame with various WrapFormat distances set");

                // Set width and height.
                textFrame.Width = Unit.FromCentimeter(6);
                textFrame.Height = Unit.FromCentimeter(2);

                // Set WrapFormat distances.
                textFrame.WrapFormat.DistanceTop = Unit.FromCentimeter(0.5);
                textFrame.WrapFormat.DistanceRight = Unit.FromCentimeter(1);
                textFrame.WrapFormat.DistanceBottom = Unit.FromCentimeter(1.5);
                textFrame.WrapFormat.DistanceLeft = Unit.FromCentimeter(2);

                textFrame.FillFormat.Color = Colors.Red;
                textFrame.LineFormat.Width = Unit.FromPoint(1);

                section.AddParagraph("...to the surrounding elements.");
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
