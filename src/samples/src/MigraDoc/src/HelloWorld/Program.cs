// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;

// NET6FIX - will be removed
if (PdfSharp.Capabilities.Build.IsCoreBuild)
    GlobalFontSettings.FontResolver = new FailsafeFontResolver();

// Create a MigraDoc document.
var document = CreateDocument();

var style = document.Styles[StyleNames.Normal]!;
style.Font.Name = "Arial";

// Create a renderer for the MigraDoc document.
var pdfRenderer = new PdfDocumentRenderer
{
    // Associate the MigraDoc document with a renderer.
    Document = document,
    PdfDocument = new PdfDocument()
};

// Layout and render document to PDF.
pdfRenderer.RenderDocument();

// Save the document...
var filename = IOHelper.CreateTemporaryPdfFileName("HelloWorldMigraDoc");
pdfRenderer.PdfDocument.Save(filename);
// ...and start a viewer.
Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });

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
    const string imagePath = @"..\..\..\..\..\..\..\..\..\assets\migradoc\images\MigraDoc-128x128.png";
    var logo = document.LastSection.AddImage(imagePath);

    return document;
}
