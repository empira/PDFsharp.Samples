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

namespace MigraDocDocs.DOM.Formats.TabStops
{
    /// <summary>
    /// "Default tab stops" chapters.
    /// </summary>
    static class SettingDefaultTabStop
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/TabStops";

        const string Filename = $"{Path}/SettingDefaultTabStop.pdf";
        const string SampleName = "Setting DefaultTabStop";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // --- Sample content

            // Set default tab stop width.
            document.DefaultTabStop = Unit.FromCentimeter(1.75);

            const string tabStopStyleName = "tabStopStyle";

            // Set tab stops for tabStopStyle.
            style = document.Styles.AddStyle(tabStopStyleName, StyleNames.Normal);
            var format = style.ParagraphFormat;
            format.AddTabStop(Unit.FromCentimeter(3));
            format.AddTabStop(Unit.FromCentimeter(4));

            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph("Default tab stops (1.25 cm):\n" +
                                 "\tA\tB\tC\tD\tE\tF\n" +
                                 "\t1.75\t3.5\t5.25\t7\t8.75\t10.5");

            section.AddParagraph("Defined Tab stops A (3 cm) and B (4 cm), " +
                                 "then default tab stops (on 1.75 cm grid):\n" +
                                 "\tA\tB\tC\tD\tE\tF\n" +
                                 "\t3\t4\t5.25\t7\t8.75\t10.5", tabStopStyleName);

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
