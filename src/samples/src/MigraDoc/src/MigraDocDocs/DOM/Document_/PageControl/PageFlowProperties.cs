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

namespace MigraDocDocs.DOM.Document_.PageControl
{
    /// <summary>
    /// "Page flow properties" chapter.
    /// </summary>
    static class PageFlowProperties
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/PageControl";

        const string Filename = $"{Path}/PageFlowProperties.pdf";
        const string SampleName = "Page flow properties";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Work with 50 lines of 5 mm for easier arrangement of the page content.
            var lineHeight = Unit.FromMillimeter(5);

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.Font.Size = Unit.FromPoint(12);
            style.ParagraphFormat.LineSpacing = lineHeight;
            style.ParagraphFormat.LineSpacingRule = LineSpacingRule.Exactly;
            style.ParagraphFormat.SpaceBefore = lineHeight;
            style.ParagraphFormat.SpaceAfter = lineHeight;

            // Set Heading1 style.
            style = document.Styles[StyleNames.Heading1];
            style.Font.Bold = true;
            style.Font.Underline = Underline.Single;

            const string dummyTextStyleName = "DummyText";
            style = document.Styles.AddStyle(dummyTextStyleName, StyleNames.Normal);
            style.Font.Color = Colors.Gray;

            // --- Sample content

            // Add a section to the document.
            var section = document.AddSection();

            // Add paragraph to ensure that 50 lines fit on a page.
            section.AddParagraph("The next Paragraph with line numbers ensures, that exactly 50 lines fit on one page.\n" +
                                 "This makes it easier to force and understand page breaks of this sample.");
            section.AddParagraph("4\n5\n6\n7\n8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45\n46\n47\n48\n49\n50\n" +
                                 "1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45\n46\n47\n48\n49\n50");

            // -- Paragraph breaking after the second line

            // Add paragraph to move the content.
            // Force page break after the second line of the dummy paragraph.
            section.AddParagraph("1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n");

            var paragraph = section.AddParagraph("Paragraph with PageBreakBefore set to true");
            paragraph.Style = StyleNames.Heading1;

            paragraph = section.AddParagraph("As PageBreakBefore is set to true, this dummy text will be inserted on the next page.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            paragraph.Format.PageBreakBefore = true;

            // -- Paragraph breaking after the second line

            // Add paragraph to move the content.
            // Force page break after the second line of the dummy paragraph.
            section.AddParagraph("5\n6\n7\n8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45");

            paragraph = section.AddParagraph("Paragraph breaking after the second line");
            paragraph.Style = StyleNames.Heading1;

            paragraph = section.AddParagraph("This paragraph will break onto the next page after the second line, as no more text " +
                                             "will fit on this page.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);

            // -- Paragraph without page flow properties set

            // Add paragraph to move the content.
            // Force page break after the first line of the dummy paragraph.
            // Because of the default WidowControl = true, the whole paragraph will break onto the next page.
            section.AddParagraph("4\n5\n6\n7\n8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45\n46");

            paragraph = section.AddParagraph("Paragraph without page flow properties set");
            paragraph.Style = StyleNames.Heading1;

            paragraph = section.AddParagraph("As WidowControl is enabled in Normal style by default, this dummy text will " +
                                             "completely break onto the next page instead of breaking after the first line.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);

            // -- Paragraph with WidowControl set to false

            // Add paragraph to move the content.
            // Force page break after the first line of the dummy paragraph.
            // Because of WidowControl = false, this will work.
            section.AddParagraph("6\n7\n8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45\n46");

            paragraph = section.AddParagraph("Paragraph with WidowControl set to false");
            paragraph.Style = StyleNames.Heading1;

            paragraph = section.AddParagraph("As WidowControl is set to false, this dummy text will break onto the next page " +
                                             "leaving the first line alone on the first page.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            paragraph.Format.WidowControl = false;

            // -- Paragraph with KeepTogether set to true

            // Add paragraph to move the content.
            // Force page break after the second line of the dummy paragraph.
            // Because of KeepTogether = true, the whole paragraph will break onto the next page.
            section.AddParagraph("5\n6\n7\n8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45");

            paragraph = section.AddParagraph("Paragraph with KeepTogether set to true");
            paragraph.Style = StyleNames.Heading1;

            paragraph = section.AddParagraph("As KeepTogether is set to true, this dummy text will completely break onto the next " +
                                             "page instead of breaking after the second line.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            paragraph.Format.KeepTogether = true;

            // -- Paragraph with KeepWithNext set to true

            // Add paragraph to move the content.
            // Force page break after the first the dummy paragraph.
            // Because of KeepWithNext = true, the first dummy paragraph will break with the second one onto the next page.
            section.AddParagraph("6\n7\n8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45");

            paragraph = section.AddParagraph("Paragraph with KeepWithNext set to true");
            paragraph.Style = StyleNames.Heading1;

            paragraph = section.AddParagraph("As KeepWithNext is set to true, this dummy text will completely break onto the next " +
                                             "page with the next paragraph instead of breaking between them.");
            paragraph.Format.KeepWithNext = true;

            paragraph = section.AddParagraph("The paragraph before is formatted to stay on the same page as this one.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);

            // -- Paragraph with KeepTogether and KeepWithNext set to true

            // Add paragraph to move the content.
            // Force page break after the second line of the first the dummy paragraph.
            // Because of KeepTogether = true and KeepWithNext = true, the first dummy paragraph will break with the second one onto the next page.
            section.AddParagraph("8\n9\n10\n" +
                                 "11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                 "21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
                                 "31\n32\n33\n34\n35\n36\n37\n38\n39\n40\n" +
                                 "41\n42\n43\n44\n45");

            paragraph = section.AddParagraph("Paragraph with KeepTogether and KeepWithNext set to true");
            paragraph.Style = StyleNames.Heading1;

            paragraph = section.AddParagraph("As KeepTogether and KeepWithNext are set to true, this dummy text will completely " +
                                             "break onto the next page with the next paragraph instead of breaking after the " +
                                             "second line.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);
            paragraph.Format.KeepTogether = true;
            paragraph.Format.KeepWithNext = true;

            paragraph = section.AddParagraph("The paragraph before is formatted to stay on the same page as this one.\n");
            paragraph.AddFormattedText("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod" +
                                       "tempor invidunt ut labore.", dummyTextStyleName);

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
