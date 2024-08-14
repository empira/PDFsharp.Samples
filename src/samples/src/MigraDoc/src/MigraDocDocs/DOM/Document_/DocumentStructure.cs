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

namespace MigraDocDocs.DOM.Document_
{
    static class DocumentStructure
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/DocumentStructure";

        /// <summary>
        /// Split over Document, Sections and "Further structuring" chapters.
        /// </summary>
        public static string SimpleDocument()
        {
            const string filename = $"{Path}/SimpleDocument.pdf";
            const string sampleName = "Simple document";

            // --- Sample content

            // Create a new MigraDoc document.
            var document = new Document();
            
            // Add a section to the document.
            var section = document.AddSection();

            // Add a paragraph to the section.
            var paragraph = section.AddParagraph("Some text.");

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "Headings & document outline" chapter.
        /// </summary>
        public static string HeadingsAndDocumentOutline()
        {
            const string filename = $"{Path}/HeadingsAndDocumentOutline.pdf";
            const string sampleName = "Headings & document outline";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set heading styles.
            var style = document.Styles[StyleNames.Heading1];
            style.Font.Size = 20;
            style.Font.Bold = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(20);
            style.ParagraphFormat.SpaceAfter= Unit.FromPoint(12);

            style = document.Styles[StyleNames.Heading2];
            style.Font.Size = 18;
            style.Font.Bold = false;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(16);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(8);

            style = document.Styles[StyleNames.Heading3];
            style.Font.Size = 16;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(12);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(4);

            // --- Sample content

            // Add a first section for "Heading 1" to the document.
            var section1 = document.AddSection();

            // Add a heading of level 1 to the first section.
            var heading1 = section1.AddParagraph("Heading 1");
            heading1.Style = StyleNames.Heading1;

            // Add "Heading 1" content.
            var paragraph1 = section1.AddParagraph("Content for heading 1");

            // Add a heading of level 2.
            var heading1_1 = section1.AddParagraph("Heading 1.1");
            heading1_1.Style = StyleNames.Heading2;

            // Add "Heading 1.1" content.
            var paragraph1_1 = section1.AddParagraph("Content for heading 1.1");

            // Add another heading of level 2.
            var heading1_2 = section1.AddParagraph("Heading 1.2");
            heading1_2.Style = StyleNames.Heading2;

            // Add "Heading 1.2" content.
            var paragraph1_2 = section1.AddParagraph("Content for heading 1.2");

            // Add a heading of level 3.
            var heading1_2_1 = section1.AddParagraph("Heading 1.2.1");
            heading1_2_1.Style = StyleNames.Heading3;

            // Add "Heading 1.2.1" content.
            var paragraph1_2_1 = section1.AddParagraph("Content for heading 1.2.1");

            // Add a second section for "Heading 2" to the document.
            var section2 = document.AddSection();

            // Add another heading of level 1 to the second section.
            var heading2 = section2.AddParagraph("Heading 2");
            heading2.Style = StyleNames.Heading1;

            // Add "Heading 2" content.
            var paragraph2 = section2.AddParagraph("Content for heading 2");

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }
    }
}
