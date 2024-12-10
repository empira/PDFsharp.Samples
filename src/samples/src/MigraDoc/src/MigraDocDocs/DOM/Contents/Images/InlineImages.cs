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

namespace MigraDocDocs.DOM.Contents.Images
{
    /// <summary>
    /// "Inline images" chapter.
    /// </summary>
    static class InlineImages
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Images";
        
        const string Filename = $"{Path}/InlineImages.pdf";
        const string SampleName = "Inline images";

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
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(36);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Inline image ignoring position properties.

            {
                var paragraph = section.AddParagraph("Inside of a paragraph, an image is positioned inside the text ");

                var image = paragraph.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-landscape.png");
                image.Resolution = 300;

                // This has no effect, as the image is located inside a paragraph. 
                image.Left = Unit.FromCentimeter(5);
                image.RelativeHorizontal = RelativeHorizontal.Page;
                image.Top = Unit.FromCentimeter(5);
                image.RelativeVertical = RelativeVertical.Page;
                image.WrapFormat.Style = WrapStyle.Through;
                image.WrapFormat.DistanceTop = Unit.FromCentimeter(0.5);
                image.WrapFormat.DistanceRight = Unit.FromCentimeter(1);
                image.WrapFormat.DistanceBottom = Unit.FromCentimeter(1.5);
                image.WrapFormat.DistanceLeft = Unit.FromCentimeter(2);

                image.LineFormat.Width = Unit.FromPoint(1);

                paragraph.AddText(" flow.\n" +
                                  "Set position properties have no effect here.");
            }

            // -- Image as bullet

            {
                var paragraph = section.AddParagraph();
                paragraph.Format.Font.Size = Unit.FromPoint(14);
                paragraph.Format.ClearAll();
                paragraph.Format.TabStops.AddTabStop(Unit.FromCentimeter(1));

                var image = paragraph.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
                image.Height = Unit.FromPoint(14);

                paragraph.AddText("\tAn image as a bullet");
            }

            // -- Image aligned at tab stop

            {
                var paragraph = section.AddParagraph("An image aligned at a tab stop\t");
                paragraph.Format.ClearAll();
                paragraph.Format.TabStops.AddTabStop(Unit.FromCentimeter(16), TabAlignment.Right);

                var image = paragraph.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-landscape.png");
                image.Resolution = 300;
            }

            // -- Increased distance with no-break spaces

            {
                // Add some no-break spaces to increase the distance to the image.
                var paragraph = section.AddParagraph("To increase the distance between the image\u00A0\u00A0\u00A0");

                var image = paragraph.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-landscape.png");
                image.Resolution = 300;

                image.LineFormat.Width = Unit.FromPoint(1);

                // Add some no-break spaces to increase the distance to the image.
                paragraph.AddText("\u00A0\u00A0\u00A0and the text, you can insert some no-break spaces as a workaround.");
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
