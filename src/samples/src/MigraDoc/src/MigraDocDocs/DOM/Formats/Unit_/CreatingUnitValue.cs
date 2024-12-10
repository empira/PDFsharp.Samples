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
    /// "Creating a Unit value" chapter.
    /// </summary>
    static class CreatingUnitValue
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Unit";

        const string Filename = $"{Path}/CreatingUnitValue.pdf";
        const string SampleName = "Creating a Unit value";

        public static string Sample()
        {
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

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}