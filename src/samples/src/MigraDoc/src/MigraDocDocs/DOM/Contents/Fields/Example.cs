// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using System.Globalization;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Contents.Fields
{
    /// <summary>
    /// Example chapter.
    /// </summary>
    static class Example
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Fields";
        
        const string Filename = $"{Path}/Example.pdf";
        const string SampleName = "Example";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set an explicit culture, as we don’t want the DateTime formatting to be dependent of the current culture.
            document.Culture = CultureInfo.GetCultureInfo("en-us");

            // Set document info.
            document.Info.Title = "Fields sample";
            document.Info.Subject = "Introducing fields and how to use them";
            document.Info.Author = "PDFsharp team";
            document.Info.Keywords = "InfoField, DateField, PageField, SectionField";

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

            // Set Heading2 style.
            style = document.Styles[StyleNames.Heading2];
            style.Font.Size = Unit.FromPoint(14);
            style.ParagraphFormat.SpaceBefore = Unit.FromPoint(12);
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            Paragraph paragraph;

            // --- Sample content

            // -- InfoField
            {
                // Add a heading.
                section.AddParagraph("InfoField", StyleNames.Heading1);

                paragraph = section.AddParagraph("Document title:\t");
                paragraph.AddInfoField(InfoFieldType.Title);

                paragraph = section.AddParagraph("Document title:\t");
                paragraph.AddInfoField(InfoFieldType.Subject);

                paragraph = section.AddParagraph("Document title:\t");
                paragraph.AddInfoField(InfoFieldType.Author);

                paragraph = section.AddParagraph("Document title:\t");
                paragraph.AddInfoField(InfoFieldType.Keywords);
            }

            // -- DateField with format strings
            {
                // Add a heading.
                section.AddParagraph("DateField with format strings", StyleNames.Heading1);

                paragraph = section.AddParagraph("Current date (default):\t");
                paragraph.AddDateField();

                paragraph = section.AddParagraph("Current date (format string \"D\"):\t");
                paragraph.AddDateField("D");

                paragraph = section.AddParagraph("Current time (format string \"T\"):\t");
                paragraph.AddDateField("T");

                paragraph = section.AddParagraph("Current date and time (format string \"f\"):\t");
                paragraph.AddDateField("f");

                paragraph = section.AddParagraph("Current year and month (format string \"y\"):\t");
                paragraph.AddDateField("y");

                paragraph = section.AddParagraph("User-defined format\n" +
                                                 "(format string \"dddd, MMMM d yyyy HH:mm:ss\"):\t");
                paragraph.AddDateField("dddd, MMMM d yyyy HH:mm:ss");
            }

            // -- New section for page number fields

            // Add a new section for better section fields presentation.
            section = document.AddSection();

            // Add a heading.
            paragraph = section.AddParagraph("Page and section number fields", StyleNames.Heading1);

            // Create a variable with the name of the bookmark.
            var bookmark1 = "bookmark1";

            // Prepend a bookmark to the paragraph for referring.
            paragraph.AddBookmark(bookmark1);

            // -- PageField and format strings
            {
                // Add a heading.
                section.AddParagraph("PageField and format strings", StyleNames.Heading2);


                paragraph = section.AddParagraph("Current page (default):\t");
                paragraph.AddPageField();

                paragraph = section.AddParagraph("Current page (format string \"ROMAN\"):\t");
                var field = paragraph.AddPageField();
                field.Format = "ROMAN";

                paragraph = section.AddParagraph("Current page (format string \"roman\"):\t");
                field = paragraph.AddPageField();
                field.Format = "roman";

                paragraph = section.AddParagraph("Current page (format string \"ALPHABETIC\"):\t");
                field = paragraph.AddPageField();
                field.Format = "ALPHABETIC";

                paragraph = section.AddParagraph("Current page (format string \"alphabetic\"):\t");
                field = paragraph.AddPageField();
                field.Format = "alphabetic";
            }

            // -- Other page fields
            {
                // Add a page break for better page fields presentation.
                section.AddPageBreak();

                // Add a heading.
                section.AddParagraph("PageRefField", StyleNames.Heading2);

                paragraph = section.AddParagraph("Page number of heading\n" +
                                                 "\"Page and section number fields\":\t");
                paragraph.AddPageRefField(bookmark1);

                // Add a heading.
                section.AddParagraph("NumPagesField", StyleNames.Heading2);

                paragraph = section.AddParagraph("Total page count:\t");
                paragraph.AddNumPagesField();

                // Add a heading.
                section.AddParagraph("SectionField", StyleNames.Heading2);

                paragraph = section.AddParagraph("Current section number:\t");
                paragraph.AddSectionField();

                // Add a heading.
                section.AddParagraph("SectionPagesField", StyleNames.Heading2);

                paragraph = section.AddParagraph("Section page count:\t");
                paragraph.AddSectionPagesField();
            }

            // -- PageField and StartingNumber set to 9
            {
                // Add a new section.
                section = document.AddSection();

                // Set the StartingNumber of the section,
                // which will be considered for PageFields and PageRefFields.
                section.PageSetup.StartingNumber = 9;

                // Add a heading.
                paragraph = section.AddParagraph("PageField and StartingNumber set to 9", StyleNames.Heading2);

                // Create a variable with the name of the bookmark.
                var bookmark2 = "bookmark2";

                // Prepend a bookmark to the paragraph for referring.
                paragraph.AddBookmark(bookmark2);

                paragraph = section.AddParagraph("Current page:\t");
                paragraph.AddPageField();

                section.AddPageBreak();

                paragraph = section.AddParagraph("Page number of heading\n" +
                                                 "\"PageField and StartingNumber set to 9\":\t");
                paragraph.AddPageRefField(bookmark2);
            }

            // -- PageField and StartingNumber set to null
            {
                // Add a new section.
                section = document.AddSection();

                // Set the underlying nullable StartingNumber to null to resume with the last page number.
                section.PageSetup.Values.StartingNumber = null;

                // Add a heading.
                paragraph = section.AddParagraph("PageField and StartingNumber set to null", StyleNames.Heading2);

                // Create a variable with the name of the bookmark.
                var bookmark3 = "bookmark3";

                // Prepend a bookmark to the paragraph for referring.
                paragraph.AddBookmark(bookmark3);

                paragraph = section.AddParagraph("Current page:\t");
                paragraph.AddPageField();

                section.AddPageBreak();

                paragraph = section.AddParagraph("Page number of heading\n" +
                                                 "\"PageField and StartingNumber set to null\":\t");
                paragraph.AddPageRefField(bookmark3);
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
