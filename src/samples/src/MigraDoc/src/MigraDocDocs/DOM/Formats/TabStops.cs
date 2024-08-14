// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using System.Globalization;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
#pragma warning disable IDE0017

namespace MigraDocDocs.DOM.Formats
{
    static class TabStops
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/TabStops";

        /// <summary>
        /// Split over Position and Alignment chapters.
        /// </summary>
        public static string PositionAndAlignment()
        {
            const string filename = $"{Path}/PositionAndAlignment.pdf";
            const string sampleName = "Position & alignment";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // --- Sample content

            // Set an explicit culture, as there are values with point as decimal separator are supplied
            // to be aligned at a decimal TabStop.
            document.Culture = CultureInfo.GetCultureInfo("en-us");

            const string tabStopStyleName = "tabStopStyle";
            const string tabStopHeaderStyleName = "tabStopHeaderStyle";

            // Set tabstops for tabStopStyle.
            var style = document.Styles.AddStyle(tabStopStyleName, StyleNames.Normal);
            var format = style.ParagraphFormat;
            format.AddTabStop(Unit.FromCentimeter(1));
            format.AddTabStop(Unit.FromCentimeter(6), TabAlignment.Right);
            format.AddTabStop(Unit.FromCentimeter(8), TabAlignment.Decimal);
            format.AddTabStop(Unit.FromCentimeter(11), TabAlignment.Center);

            // Set tabstops for tabStopHeaderStyle.
            style = document.Styles.AddStyle(tabStopHeaderStyleName, tabStopStyleName);
            format = style.ParagraphFormat;
            format.Font.Bold = true; // Use Center instead of Decimal for Weight header.
            format.AddTabStop(Unit.FromCentimeter(8), TabAlignment.Center);

            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph("Nr.\tName\tSize (cm)\tWeight (kg)\tCountry", tabStopHeaderStyleName);

            section.AddParagraph("1.\tJohn Doe\t183\t85.3\tUSA", tabStopStyleName);
            section.AddParagraph("2.\tJane Doe\t179\t67.8\tUK", tabStopStyleName);
            section.AddParagraph("3.\tMax Mustermann\t94\t31.62\tGermany", tabStopStyleName);
            section.AddParagraph("4.\tYamada Hanako\t177\t79\tJapan", tabStopStyleName);

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
        /// Leader chapter.
        /// </summary>
        public static string Leader()
        {
            const string filename = $"{Path}/Leader.pdf";
            const string sampleName = "Leader";

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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, sampleName);

            // Save the document.
            pdfRenderer.Save(filename);

            return filename;
        }

        /// <summary>
        /// Inheritance chapter.
        /// </summary>
        public static string Inheritance()
        {
            const string filename = $"{Path}/Inheritance.pdf";
            const string sampleName = "Inheritance";

            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Set Heading1 style.
            style = document.Styles[StyleNames.Heading1];
            style.Font.Size = Unit.FromPoint(18);

            // --- Sample content

            // Set TOC1 style.
            const string toc1StyleName = "TOC1";
            style = document.Styles.AddStyle(toc1StyleName, StyleNames.Normal);
            var format = style.ParagraphFormat;
            format.Font.Italic = true;
            format.AddTabStop(Unit.FromCentimeter(1));
            format.AddTabStop(Unit.FromCentimeter(1.5));
            format.AddTabStop(Unit.FromCentimeter(12), TabAlignment.Right, TabLeader.Dots);

            // Set TOC2A style. Inherits from TOC1 and edits the inherited TabStops.
            const string toc2AStyleName = "TOC2A";
            style = document.Styles.AddStyle(toc2AStyleName, toc1StyleName);
            format = style.ParagraphFormat;
            format.RemoveTabStop(Unit.FromCentimeter(1)); // Removes TabStop at 1 cm inherited from toc1Style.
            // TabStop at 1.5 cm is inherited from toc1Style.
            format.AddTabStop(Unit.FromCentimeter(2.5));
            // TabStop at 12 cm is inherited from toc1Style.

            // Set TOC2B style. Same as TOC2A, but creates all TAbStops from scratch.
            const string toc2BStyleName = "TOC2B";
            style = document.Styles.AddStyle(toc2BStyleName, toc1StyleName);
            format = style.ParagraphFormat;
            // Clear all inherited TabStops.
            format.ClearAll();
            // Create TabStops from scratch.
            format.AddTabStop(Unit.FromCentimeter(1.5));
            format.AddTabStop(Unit.FromCentimeter(2.5));
            format.AddTabStop(Unit.FromCentimeter(12), TabAlignment.Right, TabLeader.Dots);

            // Add a section to the document.
            var section = document.AddSection();

            var paragraph = section.AddParagraph("Table of contents");
            paragraph.Style = StyleNames.Heading1;

            // Use TOC1 style.
            paragraph = section.AddParagraph("\tA\tChapter 1\t5");
            paragraph.Style = toc1StyleName;
            paragraph.AddTab();

            // Use TOC2A style.
            paragraph = section.AddParagraph("\tA-1\tPart 1\t5");
            paragraph.Style = toc2AStyleName;

            paragraph = section.AddParagraph("\tA-2\tPart 2\t7");
            paragraph.Style = toc2AStyleName;

            paragraph = section.AddParagraph("\tA-3\tPart 3\t7");
            paragraph.Style = toc2AStyleName;

            paragraph = section.AddParagraph("\tB\tChapter 2\t8");
            paragraph.Style = toc1StyleName;

            // Use TOC2B style.
            paragraph = section.AddParagraph("\tB-1\tPart 1\t8");
            paragraph.Style = toc2BStyleName;

            paragraph = section.AddParagraph("\tB-2\tPart 2\t10");
            paragraph.Style = toc2BStyleName;

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
