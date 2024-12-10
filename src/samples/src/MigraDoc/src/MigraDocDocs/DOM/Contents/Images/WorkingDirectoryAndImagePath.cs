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
    /// "Working directory & image path" chapter.
    /// </summary>
    static class WorkingDirectoryAndImagePath
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Images";

        const string Filename = $"{Path}/WorkingDirectoryAndImagePath.pdf";
        const string SampleName = "Working directory & image path";

        public static string Sample()
        {
            // --- Code needed for sample

            // Ensure that assets folder exists.
            // '.\dev\download-assets.ps1' in solution root directory has to be executed before running this sample.
            IOUtility.EnsureAssets();

            // Create a new MigraDoc document.
            var document = new Document();

            // Set the image path.
            document.ImagePath = "../../../../../../assets/migradoc/images";

            // Add a section to the document.
            var section = document.AddSection();

            section.PageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1.5);

            // --- Sample content

            // Images with relative paths are first tried to be loaded from document.ImagePath.
            // If document.ImagePath also contains a relative path, a root directory is preceded.
            // This root directory is pdfRenderer.WorkingDirectory or the working directory of the application if not set.
            // If the image is not found there or document.ImagePath is not set, it is tried directly in this root directory.

            // Load image from relative path.
            // As both WorkingDirectory and ImagePath are set here, it is tried at
            // "../../.." + "/" + "../../../../../../assets/migradoc/images"
            // and it would be further tried at "../../.." if it was not there.
            section.AddImage("MigraDoc-landscape.png");

            // --- Rendering - partly also content of the sample here

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

            // Sample content:
            // Set the working directory, which will be the root for images with relative paths
            // and for the document saving operations.
            pdfRenderer.WorkingDirectory = "../../..";

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Needed because of the set WorkingDirectory:
            // The set pdfRenderer.WorkingDirectory will be preceded. We extract the filename to save it directly there
            // ("../../..").
            var filenameOnly = System.IO.Path.GetFileName(Filename);

            // Save the document.
            pdfRenderer.Save(filenameOnly);

            // Needed because of the set WorkingDirectory:
            // Of course, that’s not the right place for the file.
            // We move it to Filename inside the project’s working directory, where it is expected.
            var workingDirectoryFilename = System.IO.Path.Combine(pdfRenderer.WorkingDirectory, filenameOnly);
            File.Move(workingDirectoryFilename, Filename, true);

            return Filename;
        }
    }
}
