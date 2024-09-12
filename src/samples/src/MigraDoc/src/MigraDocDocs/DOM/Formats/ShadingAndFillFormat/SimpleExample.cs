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

namespace MigraDocDocs.DOM.Formats.ShadingAndFillFormat
{
    /// <summary>
    /// "Setting the background color" chapter.
    /// </summary>
    static class SimpleExample
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Formats/ShadingAndFillFormat";
        
        const string Filename = $"{Path}/SimpleExample.pdf";
        const string SampleName = "Simple example";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Shading sample

            var paragraph = section.AddParagraph("Paragraph Shading");
            var format = paragraph.Format;

            // Set the Shading color.
            format.Shading.Color = Colors.Aqua;

            // -- FillFormat sample

            var textFrame = section.AddTextFrame();
            textFrame.AddParagraph("TextFrame FillFormat");

            // Set the FillFormat color.
            textFrame.FillFormat.Color = Colors.Aqua;

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
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
