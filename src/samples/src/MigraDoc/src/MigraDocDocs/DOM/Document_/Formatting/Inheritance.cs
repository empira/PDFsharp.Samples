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

namespace MigraDocDocs.DOM.Document_.Formatting
{
    /// <summary>
    /// Inheritance chapter.
    /// </summary>
    static class Inheritance
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/Formatting";

        const string Filename = $"{Path}/Inheritance.pdf";
        const string SampleName = "Inheritance";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Set and use styles and direct formatting to show, how inheritance works.
            // Overridden and inherited values are explained for each style and document object in the following comments.

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.Font.Name = "times new roman";
            style.Font.Size = Unit.FromPoint(12);

            // Set Heading1 style.
            style = document.Styles[StyleNames.Heading1];
            style.Font.Size = Unit.FromPoint(20);
            style.Font.Bold = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(20); // Overrides 'Unit.FromPoint(12)' from Normal.
                                                                    // 'Font.Name = "times new roman"' will be inherited from Normal.

            // Set Heading2 style.
            style = document.Styles[StyleNames.Heading2];
            style.Font.Size = Unit.FromPoint(18); // Overrides 'Unit.FromPoint(20)' from Heading1.
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(10); // Overrides 'Unit.FromPoint(20)' from Heading1.
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(10);
            // 'Font.Bold = true' will be inherited from Heading1.
            // 'Font.Name = "times new roman"' will be inherited from Heading1 > Normal.

            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph("Example for inheritance.");
            // 'Font.Name = "times new roman"' will be inherited from Normal.
            // 'Font.Size = Unit.FromPoint(12)' will be inherited from Normal.

            var paragraph1 = section.AddParagraph("Heading 1: ");
            paragraph1.Style = StyleNames.Heading1;
            paragraph1.Format.Font.Underline = Underline.Single;
            // 'Font.Size = Unit.FromPoint(20)' will be inherited from Heading1.
            // 'Font.Bold = true' will be inherited from Heading1.
            // 'ParagraphFormat.SpaceBefore = Unit.FromPoint(20)' will be inherited from Heading1.
            // 'Font.Name = "times new roman"' will be inherited from Heading1 > Normal.

            var formattedText1 = paragraph1.AddFormattedText("Red");
            formattedText1.Color = Colors.Red;
            formattedText1.Bold = false; // Overrides 'true' from paragraph1 > Heading1.
            // 'Font.Underline' = will be inherited from paragraph1.
            // 'Font.Size = Unit.FromPoint(20)' will be inherited from paragraph1 > Heading1.
            // 'ParagraphFormat.SpaceBefore = Unit.FromPoint(20)' from paragraph1 > Heading1 is not relevant for formattedText1.
            // 'Font.Name = "times new roman"' will be inherited from paragraph1 > Heading1 > Normal.

            var paragraph2 = section.AddParagraph("Heading 2: ");
            paragraph2.Style = StyleNames.Heading2;
            // 'Font.Size = Unit.FromPoint(18)' will be inherited from Heading2.
            // 'Font.Italic = true' will be inherited from Heading2.
            // 'ParagraphFormat.SpaceBefore = Unit.FromPoint(10)' will be inherited from Heading2.
            // 'ParagraphFormat.SpaceAfter = Unit.FromPoint(10)' will be inherited from Heading2.
            // 'Font.Bold = true' will be inherited from Heading2 > Heading1.
            // 'Font.Name = "times new roman"' will be inherited from Heading2 > Heading1 > Normal.

            var formattedText2 = paragraph2.AddFormattedText("Blue");
            formattedText2.Color = Colors.Blue;
            formattedText2.Italic = false; // Overrides 'true' from paragraph2 > Heading2.
            // 'Font.Size = Unit.FromPoint(18)' will be inherited from Heading2.
            // 'ParagraphFormat.SpaceBefore = Unit.FromPoint(10)' from Heading2 is not relevant for formattedText2.
            // 'ParagraphFormat.SpaceAfter = Unit.FromPoint(10)' from Heading2 is not relevant for formattedText2.
            // 'Font.Bold = true' will be inherited from Heading2 > Heading1.
            // 'Font.Name = "times new roman"' will be inherited from Heading2 > Heading1 > Normal.

            var paragraph3 = section.AddParagraph("Whole text in ");
            paragraph3.Style = StyleNames.Normal;
            paragraph3.Format.Font.Color = Colors.Green;
            // 'Font.Name = "times new roman"' will be inherited from Normal.
            // 'Font.Size = Unit.FromPoint(12)' will be inherited from Normal.

            var formattedText3 = paragraph3.AddFormattedText("green");
            formattedText3.Bold = true;
            // 'Font.Color = Colors.Green' will be inherited from paragraph3.
            // 'Font.Name = "times new roman"' will be inherited from Normal.
            // 'Font.Size = Unit.FromPoint(12)' will be inherited from Normal.

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
