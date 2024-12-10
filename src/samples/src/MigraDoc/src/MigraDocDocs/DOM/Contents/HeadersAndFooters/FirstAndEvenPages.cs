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
    /// "First & even pages", "Scope of headers & footers" and "Presenting various information" chapters.
    /// </summary>
    static class FirstAndEvenPages
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/HeadersAndFooters";
        
        const string Filename = $"{Path}/FirstAndEvenPages.pdf";
        const string SampleName = "First & even pages";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Style for header.
            var style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            // Style for footer.
            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.ClearAll();
            style.ParagraphFormat.TabStops.AddTabStop(Unit.FromCentimeter(8), TabAlignment.Center);
            style.ParagraphFormat.TabStops.AddTabStop(Unit.FromCentimeter(16), TabAlignment.Right);

            // -- First section
            {
                // Add a first section to the document.
                var section = document.AddSection();

                // Use the EvenPage header and footer.
                section.PageSetup.OddAndEvenPagesHeaderFooter = true;

                // Use the FirstPage header and footer.
                section.PageSetup.DifferentFirstPageHeaderFooter = true;

                // Set up primary header with short document title.
                var header = section.Headers.Primary;
                header.AddParagraph("Test document");

                // Despite of OddAndEvenPagesHeaderFooter, even pages shall use the same header as odd ones.
                section.Headers.EvenPage = section.Headers.Primary.Clone();

                // Set up first page header with long document title.
                header = section.Headers.FirstPage;
                header.AddParagraph("The Test document");

                // Set up primary footer with page number on the right.
                var footer = section.Footers.Primary;
                var paragraph = footer.AddParagraph("\tSection one\t");
                paragraph.AddPageField();

                // Set up even page footer with page number on the left.
                footer = section.Footers.EvenPage;
                paragraph = footer.AddParagraph();
                paragraph.AddPageField();
                paragraph.AddText("\tSection one");

                // Set up first page footer without page number.
                footer = section.Footers.FirstPage;
                footer.AddParagraph("\tSection one");

                // Add section content.
                section.AddParagraph("Content of first section first page");
                section.AddPageBreak();
                section.AddParagraph("Content of first section second page");
                section.AddPageBreak();
                section.AddParagraph("Content of first section third page");
            }

            // -- Second section
            {
                // Add a second section to the document.
                var section = document.AddSection();

                section.PageSetup = new PageSetup();

                // Disable EvenPage and FirstPage header and footer use, which otherwise would be inherited from the previous section.
                section.PageSetup.OddAndEvenPagesHeaderFooter = false;
                section.PageSetup.DifferentFirstPageHeaderFooter = false;

                // No primary header is set here, so the primary header is copied from the previous section.

                // Even if we disabled EvenPage and FirstPage header and footer use for this section,
                // we should assign new instances, as they could be further inherited and therefore cause irritation.
                section.Headers.EvenPage = new HeaderFooter();
                section.Headers.FirstPage = new HeaderFooter();

                // If no footers are set here, the footers will be copied from the previous section.
                // Overwrite the inherited footer with empty ones.
                section.Footers.Primary = new HeaderFooter();
                section.Footers.EvenPage = new HeaderFooter();
                section.Footers.FirstPage = new HeaderFooter();

                // Add section content.
                section.AddParagraph("Content of second section first page");
                section.AddPageBreak();
                section.AddParagraph("Content of second section second page");
                section.AddPageBreak();
                section.AddParagraph("Content of second section third page");
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
