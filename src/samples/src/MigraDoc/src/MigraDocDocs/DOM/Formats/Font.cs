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

namespace MigraDocDocs.DOM.Formats
{
    static class Font
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Font";

        /// <summary>
        /// Introduction chapter.
        /// </summary>
        public static string AccessFont()
        {
            const string filename = $"{Path}/AccessFont.pdf";
            const string sampleName = "Access font";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            var style = document.Styles[StyleNames.Normal];

            // Access the Font object of a Style. 
            style.ParagraphFormat.Font.Size = Unit.FromPoint(11);

            // Access the Font object of a Style using a shortcut.
            style.Font.Size = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            var paragraph = section.AddParagraph();

            // Access the Font object of a Paragraph.
            paragraph.Format.Font.Size = Unit.FromPoint(13);

            var formattedText = paragraph.AddFormattedText("Sample text");

            // Access the Font object of a FormattedText.
            formattedText.Font.Size = Unit.FromPoint(14);

            // Access a Font object’s property of a FormattedText using a shortcut.
            formattedText.Size = Unit.FromPoint(15);

            // The size for the FormattedText is set five times in this example, just to show the different ways to access a Font object.
            // Directly assigned values (here on formattedText) override values inherited from the parent (paragraph) and from the style (Normal).
            // The last assignment overrides the value directly set for the formattedText.
            // Therefore, 15 pt is the actually used size.

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
        /// "Font name, size & color" chapter.
        /// </summary>
        public static string FontNameSizeAndColor()
        {
            const string filename = $"{Path}/FontNameSizeAndColor.pdf";
            const string sampleName = "Font name, size & color";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();
            
            var paragraph = section.AddParagraph("This is a sample paragraph.");
            var font = paragraph.Format.Font;

            // --- Sample content

            // Set the font name.
            font.Name = "times new roman";

            // Set the font size.
            font.Size = Unit.FromPoint(14);

            // Set the font color.
            font.Color = Colors.Blue;
            
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
        /// "Bold & italic" chapter.
        /// </summary>
        public static string BoldAndItalic()
        {
            const string filename = $"{Path}/BoldAndItalic.pdf";
            const string sampleName = "Bold & italic";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            var paragraph = section.AddParagraph("This is a sample paragraph.");
            var font = paragraph.Format.Font;

            // --- Sample content

            // Set the font to bold.
            font.Bold = true;

            // Set the font to italic.
            font.Italic = true;

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
        /// Underline chapter.
        /// </summary>
        public static string UnderlineTypes()
        {
            const string filename = $"{Path}/UnderlineTypes.pdf";
            const string sampleName = "Underline types";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Set the font.Underline to Single.
            var paragraph = section.AddParagraph("This is a sample paragraph with Underline.Single, so it is underlined by one single line.");
            paragraph.Format.Font.Underline = Underline.Single;

            // Set the font.Underline to Words.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.Words, so every word is underlined separately.");
            paragraph.Format.Font.Underline = Underline.Words;

            // Set the font.Underline to Dotted.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.Dotted, so it is underlined by one dotted line.");
            paragraph.Format.Font.Underline = Underline.Dotted;

            // Set the font.Underline to Dash.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.Dash, so it is underlined by one dashed line.");
            paragraph.Format.Font.Underline = Underline.Dash;

            // Set the font.Underline to DotDash.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.DotDash, so it is underlined by alternated dots and dashes.");
            paragraph.Format.Font.Underline = Underline.DotDash;

            // Set the font.Underline to DotDotDash.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.DotDotDash, so it is underlined by the pattern dot - dot - dash.");
            paragraph.Format.Font.Underline = Underline.DotDotDash;

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
        /// "Superscript & subscript" chapter.
        /// </summary>
        public static string SuperscriptAndSubscript()
        {
            const string filename = $"{Path}/SuperscriptAndSubscript.pdf";
            const string sampleName = "Superscript & subscript";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // -- Superscript sample

            var paragraph = section.AddParagraph("Using superscript: 5");
            var formattedText = paragraph.AddFormattedText("2");

            // Set formattedText font to Superscript.
            formattedText.Font.Superscript = true;

            paragraph.AddText(" = 25");
            
            // -- Subscript sample

            paragraph = section.AddParagraph("Using subscript: CO");
            formattedText = paragraph.AddFormattedText("2");

            // Set formattedText font to Subscript.
            formattedText.Font.Subscript = true;

            paragraph.AddText(" is a greenhouse gas.");

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
