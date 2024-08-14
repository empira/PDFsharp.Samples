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

namespace MigraDocDocs.DOM.Contents
{
    static class Text
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Contents/Text";

        /// <summary>
        /// Example chapter.
        /// </summary>
        public static string Example()
        {
            const string filename = $"{Path}/Example.pdf";
            const string sampleName = "Example";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();
            
            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Add a paragraph with the first part of the text to be default formatted.
            var paragraph = section.AddParagraph("This is an example for a ");

            // Add a FormattedText to the paragraph.
            var formattedText = paragraph.AddFormattedText("bold");
            // Format it. The properties of formattedText.Font can be set directly on formattedText.
            formattedText.Bold = true;

            // Add a Text with the rest of the running text to the paragraph.
            paragraph.AddText(" word in the middle of a sentence.");

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
        /// Hyphenation chapter.
        /// </summary>
        public static string Hyphenation()
        {
            const string filename = $"{Path}/Hyphenation.pdf";
            const string sampleName = "Hyphenation";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();
            
            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            section.AddParagraph(
                "Soft hyphens can be inserted into a long word, " +
                "to allow hyphenation at specific positions: \"super\u00ADcali\u00ADfragilistic\u00ADexpialidocious\". " +
                "Therefore, insert the unicode escape sequence with the soft hyphen’s character number (00AD). " +
                "In an UTF encoded file you can alternatively insert the soft hyphen’s character directly.");

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
        /// "Special characters" chapter.
        /// </summary>
        public static string SpecialCharacters()
        {
            const string filename = $"{Path}/SpecialCharacters.pdf";
            const string sampleName = "Special characters";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            var paragraph = section.AddParagraph();

            // --- Sample content

            // Add all provided SymbolNames.
            paragraph.AddText("Blank:");
            paragraph.AddCharacter(SymbolName.Blank);

            paragraph.AddText("|En:");
            paragraph.AddCharacter(SymbolName.En);

            paragraph.AddText("|Em:");
            paragraph.AddCharacter(SymbolName.Em);

            paragraph.AddText("|Em4:");
            paragraph.AddCharacter(SymbolName.Em4);

            paragraph.AddText("|EmQuarter:");
            paragraph.AddCharacter(SymbolName.EmQuarter);

            paragraph.AddText("|Tab:");
            paragraph.AddCharacter(SymbolName.Tab);

            paragraph.AddText("|LineBreak:");
            paragraph.AddCharacter(SymbolName.LineBreak);

            paragraph.AddText("|ParaBreak:");
            paragraph.AddCharacter(SymbolName.ParaBreak);

            paragraph.AddText("|Euro:");
            paragraph.AddCharacter(SymbolName.Euro);

            paragraph.AddText("|Copyright:");
            paragraph.AddCharacter(SymbolName.Copyright);

            paragraph.AddText("|Trademark:");
            paragraph.AddCharacter(SymbolName.Trademark);

            paragraph.AddText("|RegisteredTrademark:");
            paragraph.AddCharacter(SymbolName.RegisteredTrademark);

            paragraph.AddText("|Bullet:");
            paragraph.AddCharacter(SymbolName.Bullet);

            paragraph.AddText("|Not:");
            paragraph.AddCharacter(SymbolName.Not);

            paragraph.AddText("|EmDash:");
            paragraph.AddCharacter(SymbolName.EmDash);

            paragraph.AddText("|EnDash:");
            paragraph.AddCharacter(SymbolName.EnDash);

#if false // Non-breakable blanks are not yet supported (ignored in ParagraphRenderer.GetSymbol()).
            //paragraph.AddText("|HardBlank:");
            //paragraph.AddCharacter(SymbolName.HardBlank);

            //paragraph.AddText("|NonBreakableBlank:");
            //paragraph.AddCharacter(SymbolName.NonBreakableBlank);
#endif

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
