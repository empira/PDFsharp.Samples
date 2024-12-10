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
    /// "Changing UnitType" chapter.
    /// </summary>
    static class ChangingUnitType
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Unit";

        const string Filename = $"{Path}/ChangingUnitType.pdf";
        const string SampleName = "Changing the unit type";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Set Type does not change the value, so the described distance or size changes.
            var unit = Unit.FromInch(1);
            unit.Type = UnitType.Centimeter;

            section.AddParagraph($"1 inch unit, set to centimeters: {unit}");

            // ConvertType() changes the value, so the described distance or size is preserved.
            unit = Unit.FromInch(1);
            unit.ConvertType(UnitType.Centimeter);

            section.AddParagraph($"1 inch unit, converted to centimeters: {unit}");

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