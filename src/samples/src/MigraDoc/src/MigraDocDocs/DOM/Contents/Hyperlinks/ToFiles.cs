// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace MigraDocDocs.DOM.Contents.Hyperlinks
{
    /// <summary>
    /// "Links to other files" chapter.
    /// </summary>
    static class ToFiles
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Hyperlinks";
        
        const string Filename = $"{Path}/ToFiles.pdf";
        const string SampleName = "To files";

        public static string Sample()
        {
            // --- Code needed for sample

            // Result file from ToBookmarks sample is needed for this sample.
            var toBookmarksFilename = ToBookmarks.CreateSampleIfNeeded();

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(6);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(6);

            // --- Sample content

            // Style for links.
            style = document.Styles[StyleNames.Hyperlink];
            style.Font.Color = Colors.Blue;
            style.Font.Underline = Underline.Single;

            // Add a section to the document.
            var section = document.AddSection();

            // Use filename only for the links, as the path has to be relative to this result pdf or absolute.
            var otherFilename = "ToBookmarks.pdf";

            // This must be the filename used in ToBookmarks sample.
            Debug.Assert(otherFilename == System.IO.Path.GetFileName(toBookmarksFilename));

            // Create a variable with the name of the bookmark.
            // Attention: Value must be identical to the variable in ToBookmarks sample.
            var bookmark1 = "bookmark1";

            // -- A link to another file

            // Begin a paragraph.
            var paragraph = section.AddParagraph("Follow this ");

            // Add a hyperlink to ToBookmarks sample result PDF file to the paragraph.
            // A PDF file link shall be opened in the same window by default.
            var hyperlink = paragraph.AddHyperlink(otherFilename, HyperlinkType.File);
            hyperlink.AddText("link");

            // End the paragraph.
            paragraph.AddText(" to ToBookmarks sample result PDF file.");

            // -- A link to a bookmark in another file
            
            // Begin a new paragraph.
            paragraph = section.AddParagraph("Follow this ");

            // Add a hyperlink to bookmark1 in ToBookmarks sample result PDF file to the paragraph.
            // A PDF file link shall be opened in the same window by default.
            hyperlink = paragraph.AddHyperlink(otherFilename, bookmark1);
            hyperlink.AddText("link");

            // End the paragraph.
            paragraph.AddText(" to bookmark 1 in ToBookmarks sample result PDF file.");

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
