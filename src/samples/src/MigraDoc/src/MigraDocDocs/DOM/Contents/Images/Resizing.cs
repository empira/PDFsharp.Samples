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
using PdfSharp.Quality;

namespace MigraDocDocs.DOM.Contents.Images
{
    /// <summary>
    /// "Sizing & positioning" chapter.
    /// </summary>
    static class Resizing
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Images";
        
        const string Filename = $"{Path}/Resizing.pdf";
        const string SampleName = "Resizing";

        public static string Sample()
        {
            // --- Code needed for sample

            // Ensure that assets folder exists.
            // '.\dev\download-assets.ps1' in solution root directory has to be executed before running this sample.
            IOUtility.EnsureAssets();

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Heading1 style.
            var style = document.Styles[StyleNames.Heading1];
            style.Font.Bold = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(18);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(6);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Original size sample

            section.AddParagraph("Original size", StyleNames.Heading1);

            section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");

            // -- Double width sample

            section.AddParagraph("Double width (and height through LockAspectRatio)", StyleNames.Heading1);

            var image = section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
            image.ScaleWidth = 2;

            // -- No interpolation sample

            section.AddParagraph("Double width (and height through LockAspectRatio) without interpolation", StyleNames.Heading1);

            image = section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
            image.ScaleWidth = 2;
            image.Interpolate = false;

            // -- Double width and half height sample

            section.AddParagraph("Double width and half height", StyleNames.Heading1);

            image = section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
            image.ScaleWidth = 2;
            image.ScaleHeight = 0.5;

            // -- No LockAspectRatio sample

            section.AddParagraph("Half height without LockAspectRatio", StyleNames.Heading1);

            image = section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
            image.LockAspectRatio = false;
            image.ScaleHeight = 0.5;

            // -- Resolution sample

            section.AddParagraph("300 dpi resolution (default is 72)", StyleNames.Heading1);

            image = section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-80x80.png");
            image.Resolution = 300;

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
