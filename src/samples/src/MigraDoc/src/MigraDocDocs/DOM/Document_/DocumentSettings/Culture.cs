// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using System.Globalization;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Document_.DocumentSettings
{
    /// <summary>
    /// Culture chapter.
    /// </summary>
    static class Culture
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/DocumentSettings";
        
        const string Filename = $"{Path}/Culture.pdf";
        const string SampleName = "Culture";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content
            
            // Set the culture to French (France).
            document.Culture = CultureInfo.GetCultureInfo("fr-fr");
            
            // Add a section to the document.
            var section = document.AddSection();

            var paragraph = section.AddParagraph();

            // The DateField should output date and time at the default French format, like used in France.
            paragraph.AddDateField("f");

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
