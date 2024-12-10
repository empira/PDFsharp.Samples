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

namespace MigraDocDocs.DOM.Formats.Unit_
{
    /// <summary>
    /// "Getting other measure values" chapter.
    /// </summary>
    static class GettingOtherMeasureValues
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Unit";

        const string Filename = $"{Path}/GettingOtherMeasureValues.pdf";
        const string SampleName = "Getting other measure values";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            section.AddParagraph($"1 inch equals {Unit.FromInch(1).Centimeter} centimeters");
            section.AddParagraph($"1 centimeter equals {Unit.FromCentimeter(1).Millimeter} millimeters");
            section.AddParagraph($"1 inch equals {Unit.FromInch(1).Point} point");
            section.AddParagraph($"1 inch equals {Unit.FromInch(1).Pica} pica");
            section.AddParagraph($"1 pica equals {Unit.FromPica(1).Point} point");

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