﻿// MigraDoc - Creating Documents on the Fly
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

namespace MigraDocDocs.DOM.Document_.DocumentSettings
{
    /// <summary>
    /// "Color mode" chapter.
    /// </summary>
    static class ColorMode
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/DocumentSettings";
        
        const string Filename = $"{Path}/ColorMode.pdf";
        const string SampleName = "Color mode";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Render all colors in CMYK.
            document.UseCmykColor = true;
            
            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph("Black text");

            var paragraph = section.AddParagraph("Red text");
            paragraph.Format.Font.Color = Color.FromRgb(255, 0, 0);

            paragraph = section.AddParagraph("Magenta text");
            paragraph.Format.Font.Color = Color.FromCmyk(0, 100, 0, 0);

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