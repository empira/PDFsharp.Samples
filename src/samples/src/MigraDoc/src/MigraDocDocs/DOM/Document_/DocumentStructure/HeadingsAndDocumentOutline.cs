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

namespace MigraDocDocs.DOM.Document_.DocumentStructure
{
    /// <summary>
    /// "Headings & document outline" chapter.
    /// </summary>
    static class HeadingsAndDocumentOutline
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/DocumentStructure";

        const string Filename = $"{Path}/HeadingsAndDocumentOutline.pdf";
        const string SampleName = "Headings & document outline";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set heading styles.
            var style = document.Styles[StyleNames.Heading1];
            style.Font.Size = 20;
            style.Font.Bold = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(20);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

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
            var headingChapter1 = section1.AddParagraph("Heading of chapter 1");
            headingChapter1.Style = StyleNames.Heading1;

            // Add content of chapter 1.
            var paragraphChapter1 = section1.AddParagraph("Content of chapter 1");

            // Add a heading of level 2.
            var headingChapter1_1 = section1.AddParagraph("Heading of chapter 1.1");
            headingChapter1_1.Style = StyleNames.Heading2;

            // Add content of chapter 1.1.
            var paragraphChapter1_1 = section1.AddParagraph("Content of chapter 1.1");

            // Add another heading of level 2.
            var headingChapter1_2 = section1.AddParagraph("Heading of chapter 1.2");
            headingChapter1_2.Style = StyleNames.Heading2;

            // Add content of chapter 1.2. 
            var paragraphChapter1_2 = section1.AddParagraph("Content of chapter 1.2");

            // Add a heading of level 3.
            var headingChapter1_2_1 = section1.AddParagraph("Heading of chapter 1.2.1");
            headingChapter1_2_1.Style = StyleNames.Heading3;

            // Add content of chapter 1.2.1.
            var paragraphChapter1_2_1 = section1.AddParagraph("Content of chapter 1.2.1");

            // Add a second section for the next chapters to the document.
            var section2 = document.AddSection();

            // Add another heading of level 1 to the second section.
            var headingChapter2 = section2.AddParagraph("Heading of chapter 2");
            headingChapter2.Style = StyleNames.Heading1;

            // Add content of chapter 2.
            var paragraphChapter2 = section2.AddParagraph("Content of chapter 2");

            var headingChapter3 = section2.AddParagraph("Heading of chapter 3 in a differing format");
            headingChapter3.Format.OutlineLevel = OutlineLevel.Level1;
            headingChapter3.Format.Font.Size = 30;
            headingChapter3.Format.SpaceBefore = Unit.FromPoint(60);
            headingChapter3.Format.SpaceAfter = Unit.FromPoint(30);

            // Add content of chapter 3.
            var paragraphChapter3 = section2.AddParagraph("Content of chapter 3");

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
