// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;

// This sample is the obligatory Hello World program.

#if CORE
// Core build does not use Windows fonts, so set a FontResolver that handles the fonts our samples need.
GlobalFontSettings.FontResolver = new SamplesFontResolver();
#endif

// Create a new PDF document.
var document = new PdfDocument();

// Show a single page.
document.PageLayout = PdfPageLayout.SinglePage;

// Let the viewer application fit the page in the windows.
document.ViewerPreferences.FitWindow = true;

// Set the document title.
document.Info.Title = "Created with PDFsharp";

// Create an empty page.
var page = document.AddPage();

// Get an XGraphics object for drawing.
var gfx = XGraphics.FromPdfPage(page);

// Create a font.
var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);

// Draw the text.
gfx.DrawString("Hello, World!", font, XBrushes.Black,
    new XRect(0, 0, page.Width.Point, page.Height.Point),
    XStringFormats.Center);

// Save the document...
string filename = PdfFileUtility.GetTempPdfFullFileName("samples-1.5/HelloWorld");
document.Save(filename);
// ...and start a viewer.
PdfFileUtility.ShowDocument(filename);
