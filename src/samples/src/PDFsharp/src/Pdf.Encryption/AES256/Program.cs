// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

/*
  This sample demonstrates how to create and open a PDF 2.0 document with 
  AES 256 bit encryption.
*/

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Diagnostics;
using PdfSharp.Pdf.Security;
using PdfSharp.Quality;
using PdfSharp.Fonts;

const string userPassword = "User";

#if CORE
// Core build does not use Windows fonts, so set a FontResolver that handles the fonts our samples need.
GlobalFontSettings.FontResolver = new SamplesFontResolver();
#endif

// =====================================
// Part 1 - Create an encrypted PDF file
// =====================================

// Create a new PDF document.
var document = new PdfDocument();
document.Info.Title = "AES 256 bit encryption demonstration";
document.PageLayout = PdfPageLayout.SinglePage;

// Create an empty page in this document.
var page = document.AddPage();

// Draw some text.
var gfx = XGraphics.FromPdfPage(page);
var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);
gfx.DrawString("AES 256 bit test", font, XBrushes.Black,
    new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);

// Set document encryption.
document.SecuritySettings.UserPassword = userPassword;
var securityHandler = document.SecurityHandler;
securityHandler.SetEncryptionToV5();

// Save the document...
var filename = PdfFileUtility.GetTempPdfFullFileName("samples-PDFsharp/AES256");
document.Save(filename);
// ...and start a viewer.
PdfFileUtility.ShowDocument(filename);

// ===================================
// Part 2 - Open an encrypted PDF file
// ===================================

// Open the PDF document.
// After opening the document with the correct password it is not protected anymore.
// You must set the security handler again to save it encrypted.
document = PdfReader.Open(filename, userPassword, PdfDocumentOpenMode.Modify);

// Draw some text on 2nd page.
page = document.AddPage();
gfx = XGraphics.FromPdfPage(page);
gfx.DrawString("2nd page", font, XBrushes.Black,
    new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);

// Save the document with new name...
filename = PdfFileUtility.GetTempPdfFullFileName("samples-PDFsharp/AES256-unprotected");
document.Save(filename);
// ...and start a viewer.
PdfFileUtility.ShowDocument(filename);
