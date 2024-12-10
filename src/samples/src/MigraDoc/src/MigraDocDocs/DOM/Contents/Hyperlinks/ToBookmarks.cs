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

namespace MigraDocDocs.DOM.Contents.Hyperlinks
{
    /// <summary>
    /// "Links inside a PDF file" chapter.
    /// </summary>
    static class ToBookmarks
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Hyperlinks";
        
        const string Filename = $"{Path}/ToBookmarks.pdf";
        const string SampleName = "To bookmarks";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Attention: ToFiles and NewWindow samples also depend on this code.

            // Style for links.
            var style = document.Styles[StyleNames.Hyperlink];
            style.Font.Color = Colors.Blue;
            style.Font.Underline = Underline.Single;

            // Add a section to the document.
            var section = document.AddSection();

            // Create a variable with the name of the bookmark.
            // Attention: This bookmark is referred to in ToFiles and NewWindow samples.
            var bookmark1 = "bookmark1";

            // -- The page with the link

            // Begin a paragraph.
            var paragraph = section.AddParagraph("Follow this ");

            // Add a hyperlink to bookmark1 to the paragraph.
            var hyperlink = paragraph.AddHyperlink(bookmark1);
            hyperlink.AddText("link");

            // End the paragraph.
            paragraph.AddText(" to bookmark 1.");

            // -- The page with the bookmark

            // Add a page break for a better presentation of the jump to the bookmark.
            section.AddPageBreak();

            // Add a new paragraph.
            paragraph = section.AddParagraph("Bookmark 1 is here");

            // Prepend a bookmark to the paragraph.
            paragraph.AddBookmark(bookmark1, true);

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
        /// Let samples depending on this sample create the file, if needed.
        /// </summary>
        public static string CreateSampleIfNeeded()
        {
            // Use existing file, if not older than thirty seconds.
            if (File.Exists(Filename))
            {
                var now = DateTime.Now;
                var fileDate = File.GetLastWriteTime(Filename);
                var timeSpan = now - fileDate;
                if (timeSpan.TotalSeconds <= 30)
                    return Filename;
            }

            // Otherwise create a new result file.
            return Sample();
        }
    }
}
