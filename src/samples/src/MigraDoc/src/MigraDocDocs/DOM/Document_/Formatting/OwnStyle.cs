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
    /// Styles chapter.
    /// </summary>
    static class OwnStyle
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/Formatting";

        const string Filename = $"{Path}/OwnStyle.pdf";
        const string SampleName = "Own style";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            const string codeBlockStyleName = "code block";

            // Set font name and left indent for code block style.
            var style = document.Styles.AddStyle(codeBlockStyleName, StyleNames.Normal);
            style.Font.Name = "Courier New";
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(1);
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(7);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(7);

            // Add a section to the document.
            var section = document.AddSection();

            // Add some text.
            section.AddParagraph("How to setup an own style:");

            // Add a code block.
            var paragraph = section.AddParagraph("const string codeBlockStyleName = \"code block\";\n" +
                                                 "\n" +
                                                 "// Set font name and left indent for code block style.\n" +
                                                 "var style = document.Styles.AddStyle(codeBlockStyleName, StyleNames.Normal);\n" +
                                                 "style.Font.Name = \"Courier New\";\n" +
                                                 "style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(1);\n" +
                                                 "style.ParagraphFormat.SpaceBefore = Unit.FromPoint(7);\n" +
                                                 "style.ParagraphFormat.SpaceAfter = Unit.FromPoint(7);");
            // Use code block style for paragraph.
            paragraph.Style = codeBlockStyleName;

            // Add some text.
            section.AddParagraph("How to use an own style:");

            // Add a code block.
            paragraph = section.AddParagraph("// Use code block style for paragraph.\n" +
                                             "paragraph.Style = codeBlockStyleName;");
            // Use code block style for paragraph.
            paragraph.Style = codeBlockStyleName;

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
