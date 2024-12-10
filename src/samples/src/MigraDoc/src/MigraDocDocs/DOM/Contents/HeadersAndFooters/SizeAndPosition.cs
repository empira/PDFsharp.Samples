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
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Contents.HeadersAndFooters
{
    /// <summary>
    /// "Size & position" chapter.
    /// </summary>
    static class SizeAndPosition
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/HeadersAndFooters";

        const string Filename = $"{Path}/SizeAndPosition.pdf";
        const string SampleName = "Size & position";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;

            const string dummyTextStyleName = "DummyText";
            style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            // --- Sample content

            // Add a first section to the document.
            var section = document.AddSection();

            // Set header and footer distance from page border.
            section.PageSetup.HeaderDistance = Unit.FromCentimeter(0.75);
            section.PageSetup.FooterDistance = Unit.FromCentimeter(0.75);

            const string dummyText = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt" +
                                     " ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo " +
                                     "dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est.";

            // Set up header.
            var header = section.Headers.Primary;
            var paragraph = header.AddParagraph("Header ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);

            // Set up footer.
            var footer = section.Footers.Primary;
            paragraph = footer.AddParagraph("Footer ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);

            // Add section content.
            paragraph = section.AddParagraph("Content ");
            paragraph.AddFormattedText(dummyText, dummyTextStyleName);


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
