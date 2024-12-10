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

namespace MigraDocDocs.DOM.Formats.BordersAndLineFormat
{
    /// <summary>
    /// "Border distance" chapter.
    /// </summary>
    static class BorderDistance
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/BordersAndLineFormat";
        
        const string Filename = $"{Path}/BorderDistance.pdf";
        const string SampleName = "Border distance";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();
            
            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- No border distance

            // Add paragraph.
            var paragraph = section.AddParagraph("No border distance");

            // Set border for paragraph.
            paragraph.Format.Borders.Width = Unit.FromPoint(1);

            // -- 2 cm border distance

            // Add paragraph.
            paragraph = section.AddParagraph("2 cm border distance");

            // Set border and distance for paragraph.
            paragraph.Format.Borders.Width = Unit.FromPoint(1);
            paragraph.Format.Borders.Distance = Unit.FromCentimeter(2);

            // -- 2 cm border distance and indents for compensation

            // Add paragraph.
            paragraph = section.AddParagraph("2 cm border distance and indents for compensation");

            // Set border and distance for paragraph.
            paragraph.Format.Borders.Width = Unit.FromPoint(1);
            paragraph.Format.Borders.Distance = Unit.FromCentimeter(2);

            // Set left and right indent to compensate growth.
            paragraph.Format.LeftIndent = Unit.FromCentimeter(2);
            paragraph.Format.RightIndent = Unit.FromCentimeter(2);

            // -- Various border distances

            // Add paragraph.
            paragraph = section.AddParagraph("Various border distances");

            // Set border and distances for paragraph.
            paragraph.Format.Borders.Width = Unit.FromPoint(1);
            paragraph.Format.Borders.DistanceFromTop = Unit.FromCentimeter(0.5);
            paragraph.Format.Borders.DistanceFromRight = Unit.FromCentimeter(1);
            paragraph.Format.Borders.DistanceFromBottom = Unit.FromCentimeter(1.5);
            paragraph.Format.Borders.DistanceFromLeft = Unit.FromCentimeter(2);

            // -- Various border distances and indents for compensation

            // Add paragraph.
            paragraph = section.AddParagraph("Various border distances and indents for compensation");

            // Set border and distances for paragraph.
            paragraph.Format.Borders.Width = Unit.FromPoint(1);
            paragraph.Format.Borders.DistanceFromTop = Unit.FromCentimeter(0.5);
            paragraph.Format.Borders.DistanceFromRight = Unit.FromCentimeter(1);
            paragraph.Format.Borders.DistanceFromBottom = Unit.FromCentimeter(1.5);
            paragraph.Format.Borders.DistanceFromLeft = Unit.FromCentimeter(2);

            // Set left and right indent to compensate growth.
            paragraph.Format.LeftIndent = Unit.FromCentimeter(2);
            paragraph.Format.RightIndent = Unit.FromCentimeter(1);

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
