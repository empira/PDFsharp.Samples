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
    /// "Links to web URLs" chapter.
    /// </summary>
    static class ToWebUrls
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Hyperlinks";
        
        const string Filename = $"{Path}/ToWebUrls.pdf";
        const string SampleName = "To web URLs";

        public static string Sample()
        {
            // --- Code needed for sample

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

            // -- A link to a web URL

            // Begin a paragraph.
            var paragraph = section.AddParagraph("Follow this ");

            // Add a hyperlink to a web URL to the paragraph.
            var hyperlink = paragraph.AddHyperlink("https://docs.pdfsharp.net", HyperlinkType.Url);
            hyperlink.AddText("link");

            // End the paragraph.
            paragraph.AddText(" to https://docs.pdfsharp.net.");
            
            // -- A link to a web URL with protocol omitted
            
            // Begin a new paragraph.
            paragraph = section.AddParagraph("Follow this ");

            // Add a hyperlink to a web URL file to the paragraph.
            // Using CreateWebLink, the HTTP protocol is used, if none is set.
            hyperlink = Hyperlink.CreateWebLink("docs.pdfsharp.net");
            paragraph.Add(hyperlink);
            hyperlink.AddText("link");

            // End the paragraph.
            paragraph.AddText(" to docs.pdfsharp.net.");

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
