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
    /// Document chapter.
    /// </summary>
    static class CloningObjects
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/DocumentStructure";

        const string Filename = $"{Path}/CloningObjects.pdf";
        const string SampleName = "Cloning objects";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Add a paragraph to the section and save it in the variable paragraph.
            var paragraph = section.AddParagraph("This paragraph is rendered ");
            var formattedText = paragraph.AddFormattedText("twice");
            formattedText.Font.Bold = true;
            paragraph.AddText(".");

            // Add another paragraph to the section.
            section.AddParagraph("Another paragraph.");

            // Add a copy of paragraph and all its child objects to the section.
            section.Add(paragraph.Clone());

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
