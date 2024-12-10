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

namespace MigraDocDocs.DOM.Document_.PageControl
{
    /// <summary>
    /// Sections chapter.
    /// </summary>
    static class Sections
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/PageControl";

        const string Filename = $"{Path}/Sections.pdf";
        const string SampleName = "Sections";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Add a section to the document.
            var section = document.AddSection();
            section.AddParagraph("First section.\n" +
                                 "It starts on the first page.");

            // Add a new section, which shall start on the next page.
            section = document.AddSection();
            section.AddParagraph("Second section.\n" +
                                 "It starts on the second page (the next one), as there’s no SectionStart defined.");

            // Add a new section, which shall start on an even page.
            section = document.AddSection();
            section.PageSetup.SectionStart = BreakType.BreakEvenPage;
            section.AddParagraph("Third section.\n" +
                                 "It starts on the fourth page instead of the third, as it shall start on an even page.");

            // Add a new section, which shall start on an odd page.
            section = document.AddSection();
            section.PageSetup.SectionStart = BreakType.BreakOddPage;
            section.AddParagraph("Fourth section.\n" +
                                 "It starts on the fifth page (the next one), as it is already an odd page.");

            // Add a new section, which shall start on an odd page.
            section = document.AddSection();
            section.PageSetup.SectionStart = BreakType.BreakOddPage;
            section.AddParagraph("Fifth section.\n" +
                                 "It starts on the seventh page instead of the sixth, as it shall start on an odd page.");

            // Add a new section, which shall start on an even page.
            section = document.AddSection();
            section.PageSetup.SectionStart = BreakType.BreakEvenPage;
            section.AddParagraph("Sixth section.\n" +
                                 "It starts on the eighth page (the next one), as it is already an even page.");

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
