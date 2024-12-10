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
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Formats.PageSetup
{
    /// <summary>
    /// Example chapter.
    /// </summary>
    static class Example
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/PageSetup";

        const string Filename = $"{Path}/Example.pdf";
        const string SampleName = "Example";

        public static string Sample()
        {
            // --- Code needed for sample


            var text = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore " +
                       "et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. " +
                       "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, " +
                       "consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, " +
                       "sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea " +
                       "takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                       "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. " +
                       "At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, " +
                       "no sea takimata sanctus est Lorem ipsum dolor sit amet. " +
                       "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore " +
                       "et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. " +
                       "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, " +
                       "consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, " +
                       "sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea " +
                       "takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                       "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. " +
                       "At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, " +
                       "no sea takimata sanctus est Lorem ipsum dolor sit amet. " +
                       "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore " +
                       "et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. " +
                       "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, " +
                       "consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, " +
                       "sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea " +
                       "takimata sanctus est Lorem ipsum dolor sit amet.";

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);
            style.ParagraphFormat.AddTabStop(Unit.FromCentimeter(8));

            // Set Heading1 style.
            style = document.Styles[StyleNames.Heading1];
            style.Font.Size = Unit.FromPoint(16);
            style.Font.Bold = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(18);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(18);

            // --- Sample content

            // -- Section 1: A5 landscape orientation with various margins
            {
                // Add a section to the document.
                var section = document.AddSection();

                // Set PageSetup of the section.
                section.PageSetup.PageFormat = PageFormat.A5;
                section.PageSetup.Orientation = Orientation.Landscape;
                section.PageSetup.TopMargin = Unit.FromCentimeter(2);
                section.PageSetup.RightMargin = Unit.FromCentimeter(4);
                section.PageSetup.BottomMargin = Unit.FromCentimeter(6);
                section.PageSetup.LeftMargin = Unit.FromCentimeter(8);

                // Add section content.
                section.AddParagraph("Section 1: A5 landscape orientation with various margins", StyleNames.Heading1);
                section.AddParagraph(text);
            }

            // -- Section 2: Inherited from section 1, but portrait orientation
            {
                // Add section to the document.
                var section = document.AddSection();

                // Set PageSetup of the section.
                // Set only Orientation.
                section.PageSetup.Orientation = Orientation.Portrait;
                // All other values are inherited from the previous section.

                // Add section content.
                section.AddParagraph("Section 2: Inherited from section 1, but portrait orientation", StyleNames.Heading1);
                section.AddParagraph(text);
            }

            // -- Section 3: Default page setup
            {
                // Add section to the document.
                var section = document.AddSection();

                // Set PageSetup of the section.
                // Reset to DefaultPageSetup.
                section.PageSetup = document.DefaultPageSetup.Clone();

                // Add section content.
                section.AddParagraph("Section 3: Default page setup", StyleNames.Heading1);
                section.AddParagraph(text);
            }

            // -- Section 4: User defined 15 x 20 centimeters
            {
                // Add section to the document.
                var section = document.AddSection();

                // Set PageSetup of the section.
                section.PageSetup.PageWidth = Unit.FromCentimeter(15);
                section.PageSetup.PageHeight = Unit.FromCentimeter(20);
                // All other values are inherited from the previous section.

                // Add section content.
                section.AddParagraph("Section 4: User defined 15 x 20 centimeters", StyleNames.Heading1);
                section.AddParagraph(text);
            }

            // -- Section 5: A5 landscape with various margins and MirrorMargins
            {
                // Add section to the document.
                var section = document.AddSection();

                // Set PageSetup of the section.
                section.PageSetup.MirrorMargins = true;
                section.PageSetup.Orientation = Orientation.Landscape;
                section.PageSetup.PageFormat = PageFormat.A5;
                section.PageSetup.TopMargin = Unit.FromCentimeter(2);
                section.PageSetup.RightMargin = Unit.FromCentimeter(4);
                section.PageSetup.BottomMargin = Unit.FromCentimeter(6);
                section.PageSetup.LeftMargin = Unit.FromCentimeter(8);

                // Add section content.
                section.AddParagraph("Section 5: A5 landscape with various margins and MirrorMargins", StyleNames.Heading1);
                section.AddParagraph(text);
            }

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
