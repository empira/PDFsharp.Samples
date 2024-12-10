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
    /// Comparing chapter.
    /// </summary>
    static class Comparing
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Unit";

        const string Filename = $"{Path}/Comparing.pdf";
        const string SampleName = "Comparing";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Set Heading1 style.
            style = document.Styles[StyleNames.Heading1];
            style.Font.Size = Unit.FromPoint(18);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            var oneCm = Unit.FromCentimeter(1);
            var nineMm = Unit.FromMillimeter(9);
            var tenMm = Unit.FromMillimeter(10);

            section.AddParagraph($"oneCm: {oneCm}\n" +
                                 $"nineMm: {nineMm}\n" +
                                 $"tenMm: {tenMm}");

            var paragraph = section.AddParagraph("Comparing one centimeter and nine millimeters");
            paragraph.Style = StyleNames.Heading1;

            section.AddParagraph($"Result for oneCm.CompareTo(nineMm): {oneCm.CompareTo(nineMm)}\n" +
                                 $"Result for oneCm.Equals(nineMm) : {oneCm.Equals(nineMm)}\n" +
                                 $"Result for oneCm.IsSameValue(nineMm) {oneCm.IsSameValue(nineMm)}");

            paragraph = section.AddParagraph("Comparing one centimeter and ten millimeters");
            paragraph.Style = StyleNames.Heading1;

            section.AddParagraph($"Result for oneCm.CompareTo(tenMm): {oneCm.CompareTo(tenMm)}\n" +
                                 $"Result for oneCm.Equals(tenMm) : {oneCm.Equals(tenMm)}\n" +
                                 $"Result for oneCm.IsSameValue(tenMm) {oneCm.IsSameValue(tenMm)}");

            paragraph = section.AddParagraph("Notes");
            paragraph.Style = StyleNames.Heading1;

            section.AddParagraph("As you can see, CompareTo() won't consider Unit values of one centimeter and ten millimeters as the same. " +
                                 "This is because CompareTo() actually compares the point value of the Units, which will have some rounding differences. " +
                                 "If finding equal values in a comparison is necessary, you could call IsSameValue() first. ");

            section.AddParagraph("IsSameValue() compares the point values of the Units, while suppressing rounding errors. " +
                                 "Therefore, it returns true for one centimeter and ten millimeters.");

            section.AddParagraph("Equals() considers also the UnitType, so Units of a different measure can never be the same.");

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