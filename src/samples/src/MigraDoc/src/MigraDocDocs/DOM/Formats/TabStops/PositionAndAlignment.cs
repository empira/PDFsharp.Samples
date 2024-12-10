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

namespace MigraDocDocs.DOM.Formats.TabStops
{
    /// <summary>
    /// Split over Position and Alignment chapters.
    /// </summary>
    static class PositionAndAlignment
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/TabStops";

        const string Filename = $"{Path}/PositionAndAlignment.pdf";
        const string SampleName = "Position & alignment";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Set an explicit culture, as there are values with point as decimal separator are supplied
            // to be aligned at a decimal TabStop.
            document.Culture = CultureInfo.GetCultureInfo("en-us");

            const string tabStopStyleName = "tabStopStyle";
            const string tabStopHeaderStyleName = "tabStopHeaderStyle";

            // Set tab stops for tabStopStyle.
            var style = document.Styles.AddStyle(tabStopStyleName, StyleNames.Normal);
            var format = style.ParagraphFormat;
            format.AddTabStop(Unit.FromCentimeter(1));
            format.AddTabStop(Unit.FromCentimeter(6), TabAlignment.Right);
            format.AddTabStop(Unit.FromCentimeter(8), TabAlignment.Decimal);
            format.AddTabStop(Unit.FromCentimeter(11), TabAlignment.Center);

            // Set tab stops for tabStopHeaderStyle.
            style = document.Styles.AddStyle(tabStopHeaderStyleName, tabStopStyleName);
            format = style.ParagraphFormat;
            format.Font.Bold = true; // Use Center instead of Decimal for Weight header.
            format.AddTabStop(Unit.FromCentimeter(8), TabAlignment.Center);

            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph("Nr.\tName\tSize (cm)\tWeight (kg)\tCountry", tabStopHeaderStyleName);

            section.AddParagraph("1.\tJohn Doe\t183\t85.3\tUSA", tabStopStyleName);
            section.AddParagraph("2.\tJane Doe\t179\t67.8\tUK", tabStopStyleName);
            section.AddParagraph("3.\tMax Mustermann\t94\t31.62\tGermany", tabStopStyleName);
            section.AddParagraph("4.\tYamada Hanako\t177\t79\tJapan", tabStopStyleName);

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
