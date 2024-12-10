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
    /// Leader chapter.
    /// </summary>
    static class Leader
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/TabStops";

        const string Filename = $"{Path}/Leader.pdf";
        const string SampleName = "Leader";

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

            // -- TabLeader.Spaces sample

            var paragraph = section.AddParagraph("\tTabLeader.Spaces");
            var format = paragraph.Format;

            // Add TabStop with Spaces TabLeader.
            format.AddTabStop(Unit.FromCentimeter(10), TabLeader.Spaces);

            // -- TabLeader.Dots sample

            paragraph = section.AddParagraph("\tTabLeader.Dots");
            format = paragraph.Format;

            // Add TabStop with Spaces TabLeader.
            format.AddTabStop(Unit.FromCentimeter(10), TabLeader.Dots);

            // -- TabLeader.Dashes sample

            paragraph = section.AddParagraph("\tTabLeader.Dashes");
            format = paragraph.Format;

            // Add TabStop with Spaces TabLeader.
            format.AddTabStop(Unit.FromCentimeter(10), TabLeader.Dashes);

            // -- TabLeader.Lines sample

            paragraph = section.AddParagraph("\tTabLeader.Lines");
            format = paragraph.Format;

            // Add TabStop with Spaces TabLeader.
            format.AddTabStop(Unit.FromCentimeter(10), TabLeader.Lines);

            // -- TabLeader.Heavy sample

            paragraph = section.AddParagraph("\tTabLeader.Heavy");
            format = paragraph.Format;

            // Add TabStop with Spaces TabLeader.
            format.AddTabStop(Unit.FromCentimeter(10), TabLeader.Heavy);

            // -- TabLeader.MiddleDot sample

            paragraph = section.AddParagraph("\tTabLeader.MiddleDot");
            format = paragraph.Format;

            // Add TabStop with Spaces TabLeader.
            format.AddTabStop(Unit.FromCentimeter(10), TabLeader.MiddleDot);

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
