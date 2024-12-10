// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Document_.Rendering
{
    /// <summary>
    /// "Rendering a PDF file" chapter.
    /// </summary>
    static class RenderingPdfFile
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/Rendering";
        
        const string Filename = $"{Path}/RenderingPdfFile.pdf";
        const string SampleName = "Rendering a PDF file";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph("Test document");
            
            // --- Sample content / Rendering

            // Create a PDF renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer();

            // Associate the MigraDoc document with a renderer.
            pdfRenderer.Document = document;

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Not part of the sample: Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
