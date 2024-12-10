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
    /// "Fileless images" chapter.
    /// </summary>
    static class FromByteArray
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Images";
        
        const string Filename = $"{Path}/FromByteArray.pdf";
        const string SampleName = "From byte array";

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

            section.PageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1.5);

            // --- Sample content

            // Read image as byte array.
            var image = File.ReadAllBytes("../../../../../../../../../assets/migradoc/images/MigraDoc-landscape.png");

            // Convert image byte array to base64 pseudo-filename.
            var imageFilename = MigraDocFilenameFromByteArray(image);

            // Load image from pseudo-filename.
            var image2 = section.AddImage(imageFilename);

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

        /// <summary>
        /// Converts an image byte array to a base64 string that can be passed to AddImage method as a pseudo-filename.
        /// </summary>
        static string MigraDocFilenameFromByteArray(byte[] image)
        {
            return "base64:" +
                   Convert.ToBase64String(image);
        }
    }
}
