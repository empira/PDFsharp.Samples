// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;

#if CORE
// Core build does not use Windows fonts,
// so set a FontResolver that handles the fonts our samples need.
GlobalFontSettings.FontResolver = new SamplesFontResolver();
#endif

// Create a MigraDoc document.
var document = CreateDocument();

var style = document.Styles[StyleNames.Normal]!;
style.Font.Name = "Arial";

// Create a renderer for the MigraDoc document.
var pdfRenderer = new PdfDocumentRenderer
{
    // Associate the MigraDoc document with a renderer.
    Document = document,
    PdfDocument =
    {
        // Change some settings before rendering the MigraDoc document.
        PageLayout = PdfPageLayout.SinglePage,
        ViewerPreferences =
        {
            FitWindow = true
        }
    }
};

// Layout and render document to PDF.
pdfRenderer.RenderDocument();

// Save the document...
var filename = PdfFileUtility.GetTempPdfFullFileName("samples-MigraDoc/HelloWorldMigraDoc");
pdfRenderer.PdfDocument.Save(filename);

// ...and start a viewer.
PdfFileUtility.ShowDocument(filename);

// Creates a minimalistic document.
static Document CreateDocument()
{
    // Create a new MigraDoc document.
    var document = new Document();

    // Add a section to the document.
    var section = document.AddSection();

    // Add a paragraph to the section.
    var paragraph = section.AddParagraph();

    // Set font color.
    paragraph.Format.Font.Color = Colors.DarkBlue;

    // Add some text to the paragraph.
    paragraph.AddFormattedText("Hello, World!", TextFormat.Bold);

    // Create the primary footer.
    var footer = section.Footers.Primary;

    // Add content to footer.
    paragraph = footer.AddParagraph();
    paragraph.Add(new DateField { Format = "yyyy/MM/dd HH:mm:ss" });
    paragraph.Format.Alignment = ParagraphAlignment.Center;

    // Add MigraDoc logo.
    string imagePath = IOUtility.GetAssetsPath(@"migradoc/images/MigraDoc-128x128.png")!;
    document.LastSection.AddImage(imagePath);

    return document;
}
