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
#pragma warning disable IDE0017

namespace MigraDocDocs.DOM.Formats
{
    static class Unit_
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Unit";

        /// <summary>
        /// "Creating a Unit value" chapter.
        /// </summary>
        public static string CreatingUnitValue()
        {
            const string filename = $"{Path}/CreatingUnitValue.pdf";
            const string sampleName = "Creating a Unit value";
            
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            section.AddParagraph("No left indent");

            // 1 centimeter indent

            var paragraph = section.AddParagraph("1 centimeter left indent");
            paragraph.Format.LeftIndent = Unit.FromCentimeter(1);

            paragraph = section.AddParagraph("1 centimeter parsed left indent");
            paragraph.Format.LeftIndent = "1cm";

            // 1 millimeter indent

            paragraph = section.AddParagraph("1 millimeter left indent");
            paragraph.Format.LeftIndent = Unit.FromMillimeter(1);

            paragraph = section.AddParagraph("1 millimeter parsed left indent");
            paragraph.Format.LeftIndent = "1mm";

            // 1 point indent

            paragraph = section.AddParagraph("1 point left indent");
            paragraph.Format.LeftIndent = Unit.FromPoint(1);

            paragraph = section.AddParagraph("1 point parsed left indent");
            paragraph.Format.LeftIndent = "1pt";

            // 1 inch indent

            paragraph = section.AddParagraph("1 inch left indent");
            paragraph.Format.LeftIndent = Unit.FromInch(1);

            paragraph = section.AddParagraph("1 inch parsed left indent");
            paragraph.Format.LeftIndent = "1in";

            // 1 pica indent

            paragraph = section.AddParagraph("1 pica left indent");
            paragraph.Format.LeftIndent = Unit.FromPica(1);
            paragraph = section.AddParagraph("1 pica parsed left indent");
            paragraph.Format.LeftIndent = "1pc";


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
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "Getting other measure values" chapter.
        /// </summary>
        public static string GettingOtherMeasureValues()
        {
            const string filename = $"{Path}/GettingOtherMeasureValues.pdf";
            const string sampleName = "Getting other measure values";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// "Changing UnitType" chapter.
        /// </summary>
        public static string ChangingUnitType()
        {
            const string filename = $"{Path}/ChangingUnitType.pdf";
            const string sampleName = "Changing the unit type";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// Comparing chapter.
        /// </summary>
        public static string Comparing()
        {
            const string filename = $"{Path}/Comparing.pdf";
            const string sampleName = "Comparing";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }
    }
}