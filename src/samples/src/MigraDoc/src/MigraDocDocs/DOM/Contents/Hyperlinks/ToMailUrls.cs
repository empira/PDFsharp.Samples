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
    /// "Links to mail URLs" chapter.
    /// </summary>
    static class ToMailUrls
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Hyperlinks";
        
        const string Filename = $"{Path}/ToMailUrls.pdf";
        const string SampleName = "To mail URLs";

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

            // -- A link to a mail address

            // Begin a paragraph.
            var paragraph = section.AddParagraph("Follow this ");

            // Add a hyperlink to a mail URL to the paragraph.
            var hyperlink = paragraph.AddHyperlink("mailto:john.doe@example.com", HyperlinkType.Url);
            hyperlink.AddText("link");

            // End the paragraph.
            paragraph.AddText(" to write a mail to mailto:john.doe@example.com.");

            // -- A link to a mail address with mailto omitted

            // Begin a new paragraph.
            paragraph = section.AddParagraph("Follow this ");

            // Add a hyperlink to a mail URL to the paragraph.
            // Using CreateWebLink, the mailto protocol is used, if none is set.
            hyperlink = Hyperlink.CreateMailLink("john.doe@example.com");
            paragraph.Add(hyperlink);
            hyperlink.AddText("link");

            // End the paragraph.
            paragraph.AddText(" to write a mail to john.doe@example.com.");

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
