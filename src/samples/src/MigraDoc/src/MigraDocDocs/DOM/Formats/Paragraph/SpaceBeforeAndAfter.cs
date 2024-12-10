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

namespace MigraDocDocs.DOM.Formats.Paragraph
{
    /// <summary>
    /// "Space before & space after" chapter.
    /// </summary>
    static class SpaceBeforeAndAfter
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Paragraph";

        const string Filename = $"{Path}/SpaceBeforeAndAfter.pdf";
        const string SampleName = "Space before & space after";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- SpaceBefore ignored sample

            var paragraph = section.AddParagraph("This paragraph has a SpaceBefore of 10 cm defined, " +
                                                 "but SpaceBefore is always ignored for the first paragraph of a page.");
            var format = paragraph.Format;

            // Set SpaceBefore.
            format.SpaceBefore = Unit.FromCentimeter(10);

            // -- SpaceBefore sample

            paragraph = section.AddParagraph("This paragraph has a SpaceBefore of 20 pt defined.");
            format = paragraph.Format;

            // Set SpaceBefore.
            format.SpaceBefore = Unit.FromPoint(20);

            // -- SpaceAfter sample

            paragraph = section.AddParagraph("This paragraph has a SpaceAfter of 20 pt defined.");
            format = paragraph.Format;

            // Set SpaceAfter.
            format.SpaceAfter = Unit.FromPoint(20);

            // -- No SpaceBefore and SpaceAfter sample

            section.AddParagraph("This paragraph has no SpaceBefore and SpaceAfter defined. " +
                                 "But due to the last paragraph’s SpaceAfter and the next paragraph’s SpaceBefore, " +
                                 "there is actually space before and after this paragraphs, as the bigger values win.");

            // -- SpaceBefore and SpaceAfter sample

            paragraph = section.AddParagraph("This paragraph has a SpaceBefore of 10 pt and a SpaceAfter of 20 pt defined.");
            format = paragraph.Format;

            // Set SpaceBefore and SpaceAfter.
            format.SpaceBefore = Unit.FromPoint(10);
            format.SpaceAfter = Unit.FromPoint(20);

            paragraph = section.AddParagraph("This paragraph has also a SpaceBefore of 10 pt and a SpaceAfter of 20 pt defined. " +
                                             "Due to the last paragraph’s SpaceAfter, there is actually space of 20 pt before it, as the bigger value wins.");
            format = paragraph.Format;

            // Set SpaceBefore and SpaceAfter.
            format.SpaceBefore = Unit.FromPoint(10);
            format.SpaceAfter = Unit.FromPoint(20);

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
