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

namespace MigraDocDocs.DOM.Document_.Rendering
{
    /// <summary>
    /// "Rendering a PDF file" chapter.
    /// </summary>
    static class ChangingPdfSettings
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/Rendering";
        
        const string Filename = $"{Path}/ChangingPdfSettings.pdf";
        const string SampleName = "Changing PDF settings";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph("Test document");

            section.AddPageBreak();

            section.AddParagraph("Page 2");

            // --- Rendering

            // Create a PDF renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer();

            // Associate the MigraDoc document with a renderer.
            pdfRenderer.Document = document;

            // --- Sample content

            // Let the PDF viewer show two pages of the file.
            pdfRenderer.PdfDocument.PageLayout = PdfPageLayout.TwoPageLeft;

            // Let the PDF viewer show the full pages.
            pdfRenderer.PdfDocument.ViewerPreferences.FitWindow = true;

            // Create the PDF file without compressing the content streams.
            pdfRenderer.PdfDocument.Options.CompressContentStreams = false;
            
            // --- Further rendering

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
