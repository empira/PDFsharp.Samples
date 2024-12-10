// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Document_.MigraDocSettings
{
    /// <summary>
    /// "Predefined fonts and bullet chars" chapter.
    /// </summary>
    static class PredefinedFonts
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/MigraDocSettings";
        
        const string Filename = $"{Path}/PredefinedFonts.pdf";
        const string SampleName = "Predefined fonts";

        public static string Sample()
        {
            // --- Sample content

            // Set the error font.
            PredefinedFontsAndChars.ErrorFontName = "Arial";

            // Set the bullet font and char for list level 1.
            PredefinedFontsAndChars.Bullets.Level1FontName = "Wingdings";
            PredefinedFontsAndChars.Bullets.Level1Character = '\u0076';

            // Set the bullet font and char for list level 2.
            PredefinedFontsAndChars.Bullets.Level2FontName = "Wingdings";
            PredefinedFontsAndChars.Bullets.Level2Character = '\u00AA';

            // Set the bullet font and char for list level 3.
            PredefinedFontsAndChars.Bullets.Level3FontName = "Wingdings";
            PredefinedFontsAndChars.Bullets.Level3Character = '\u0077';

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(12);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Set List style.
            style = document.Styles[StyleNames.List];
            style.ParagraphFormat.SpaceBefore = Unit.Zero;
            style.ParagraphFormat.SpaceAfter = Unit.Zero;
            
            // Style for list level 1.
            const string listLevel1StyleName = "ListLevel1";
            style = document.Styles.AddStyle(listLevel1StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.BulletList1;
            style.ParagraphFormat.ListInfo.NumberPosition = Unit.Zero;
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(0.5);

            // Style for list level 2.
            const string listLevel2StyleName = "ListLevel2";
            style = document.Styles.AddStyle(listLevel2StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.BulletList2;
            style.ParagraphFormat.ListInfo.NumberPosition = Unit.FromCentimeter(0.5);
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(1);

            // Style for list level 3.
            const string listLevel3StyleName = "ListLevel3";
            style = document.Styles.AddStyle(listLevel3StyleName, StyleNames.List);
            style.ParagraphFormat.ListInfo.ListType = ListType.BulletList3;
            style.ParagraphFormat.ListInfo.NumberPosition = Unit.FromCentimeter(1);
            style.ParagraphFormat.LeftIndent = Unit.FromCentimeter(1.5);

            // Add a section to the document.
            var section = document.AddSection();

            // Add a not existing image.
            section.AddParagraph("This image can not be loaded:");
            section.AddImage("notExistingFile.jpg");

            // Add a bullet list.
            section.AddParagraph("A list with custom chars of a custom font:");
            section.AddParagraph("Level 1", listLevel1StyleName);
            section.AddParagraph("Level 2", listLevel2StyleName);
            section.AddParagraph("Level 3", listLevel3StyleName);

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
