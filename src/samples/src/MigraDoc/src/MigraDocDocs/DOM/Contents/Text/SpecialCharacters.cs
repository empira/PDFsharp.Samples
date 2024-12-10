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

namespace MigraDocDocs.DOM.Contents.Text
{
    /// <summary>
    /// "Special characters" chapter.
    /// </summary>
    static class SpecialCharacters
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Text";

        const string Filename = $"{Path}/SpecialCharacters.pdf";
        const string SampleName = "Special characters";

        public static string Sample()
        {
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

            // Non-breakable blanks are not yet supported. They are currently ignored in ParagraphRenderer.GetSymbol().
            // Also, ElementsExtensions.GetSymbol() returns the wrong char (\u0083 instead of \u00A0).
#if false
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

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
