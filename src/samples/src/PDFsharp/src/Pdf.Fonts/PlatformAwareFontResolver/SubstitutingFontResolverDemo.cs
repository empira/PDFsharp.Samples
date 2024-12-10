// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;

GlobalFontSettings.FontResolver = new SubstitutingFontResolver.SubstitutingFontResolver();
GlobalFontSettings.FallbackFontResolver = new FailsafeFontResolver();

// Create a new PDF document.
var document = new PdfDocument();
document.Info.Title = "Created with PDFsharp";
document.Info.Subject = "Just a simple Hello-World program.";

// Create an empty page in this document.
var page = document.AddPage();

// Get an XGraphics object for drawing on this page.
var gfx = XGraphics.FromPdfPage(page);

// Draw two lines with a red default pen.
var width = page.Width.Point;
var height = page.Height.Point;
gfx.DrawLine(XPens.Red, 0, 0, width, height);
gfx.DrawLine(XPens.Red, width, 0, 0, height);

// Draw a circle with a red pen which is 1.5 point thick.
var r = width / 5;
gfx.DrawEllipse(new XPen(XColors.Red, 1.5), XBrushes.White, new XRect(width / 2 - r, height / 2 - r, 2 * r, 2 * r));

// Create a font.
var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);

// Draw the text.
gfx.DrawString("Hello, PDFsharp!", font, XBrushes.Black,
    new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);

// Create a font.
font = new XFont("Arial", 20, XFontStyleEx.BoldItalic);

// Draw the text.
gfx.DrawString("Hello, PDFsharp!", font, XBrushes.Black,
    new XRect(0, 0, page.Width.Point, page.Height.Point - 50), XStringFormats.Center);

// Create a font.
font = new XFont("Courier New", 20, XFontStyleEx.BoldItalic);

// Draw the text.
gfx.DrawString("Hello, PDFsharp!", font, XBrushes.Black,
    new XRect(0, 50, page.Width.Point, page.Height.Point - 50), XStringFormats.Center);

#if false
// Test behavior with a font that cannot be found.
// Create a font.
font = new XFont("Fubar non-existent font", 20, XFontStyleEx.BoldItalic);

// Draw the text.
gfx.DrawString("Hello, PDFsharp!", font, XBrushes.Black,
    new XRect(0, 75, page.Width.Point, page.Height.Point - 75), XStringFormats.Center);
#endif

// Save the document...
var filename = PdfFileUtility.GetTempPdfFullFileName("samples/HelloWorldSample");
document.Save(filename);
// ...and start a viewer.
PdfFileUtility.ShowDocument(filename);
