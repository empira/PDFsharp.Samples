// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

/*
  This sample demonstrates how to create and open a PDF 1.6 document with 
  AES 128 bit encryption.
*/

using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp;
using PdfSharp.Pdf.IO;
using PdfSharp.Snippets.Font;
using System.Diagnostics;
using PdfSharp.Diagnostics;
using PdfSharp.Pdf.Security;

// NET6FIX - will be removed
if (Capabilities.Build.IsCoreBuild)
    GlobalFontSettings.FontResolver = new FailsafeFontResolver();

const string userPassword = "User";

// =====================================
// Part 1 - Create an encrypted PDF file
// =====================================

// Create a new PDF document.
var document = new PdfDocument();
document.Info.Title = "AES 128 bit encryption demonstration";
document.PageLayout = PdfPageLayout.SinglePage;

// Create an empty page in this document.
var page = document.AddPage();

// Draw some text.
var gfx = XGraphics.FromPdfPage(page);
var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);
gfx.DrawString("AES 128 bit test", font, XBrushes.Black,
    new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

// Set document encryption.
document.SecuritySettings.UserPassword = userPassword;
var securityHandler = document.SecurityHandler ?? NRT.ThrowOnNull<PdfStandardSecurityHandler>();
securityHandler.SetEncryptionToV4UsingAES();

// Save the document...
var filename = "AES128_tempfile.pdf";
document.Save(filename);
// ...and start a viewer.
Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });

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
    new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

// Save the document with new name...
filename = "AES128-unprotected_tempfile.pdf";
document.Save(filename);
// ...and start a viewer.
Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
