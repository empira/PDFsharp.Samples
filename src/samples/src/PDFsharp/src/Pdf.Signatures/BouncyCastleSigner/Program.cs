// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Security.Cryptography.X509Certificates;
using BouncyCastleSigner;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Signatures;
using PdfSharp.Quality;

// The minimum assets version required.
// Our test .pfx file is stored in the assets.
const int requiredAssets = 1014;
IOUtility.EnsureAssetsVersion(requiredAssets);

var font = new XFont("Verdana", 10.0, XFontStyleEx.Regular);
var document = new PdfDocument();
var pdfPage = document.AddPage();
var xGraphics = XGraphics.FromPdfPage(pdfPage);
var layoutRectangle = new XRect(0.0, 0.0, pdfPage.Width.Point, pdfPage.Height.Point);
xGraphics.DrawString("Signed sample document", font, XBrushes.Black, layoutRectangle, XStringFormats.TopCenter);
var options = new DigitalSignatureOptions
{
    ContactInfo = "John Doe",
    Location = "Seattle",
    Reason = "License Agreement",
    Rectangle = new XRect(36.0, 700.0, 400.0, 50.0),
    AppearanceHandler = new SignatureAppearanceHandler()
};
var pdfSignatureHandler = DigitalSignatureHandler.ForDocument(document,
    new PdfSharp.Snippets.Pdf.BouncyCastleSigner(GetCertificate(), PdfMessageDigestType.SHA256), options);

// Save the document...
string filename = PdfFileUtility.GetTempPdfFullFileName("samples-PDFsharp/Signatures/BouncyCastleSignerSample");
document.Save(filename);
// ...and start a viewer.
PdfFileUtility.ShowDocument(filename);

return;

static (X509Certificate2, X509Certificate2Collection) GetCertificate()
{
    var certFolder = IOUtility.GetAssetsPath("pdfsharp-6.x/signatures") ??
                     throw new InvalidOperationException("Call Download-Assets.ps1 before running the tests.");
    var pfxFile = Path.Combine(certFolder, "test-cert_rsa_1024.pfx");
    var rawData = File.ReadAllBytes(pfxFile);

    // This code is for demonstration only. Do not use password literals for real certificates in source code.
    var certificatePassword = "Seecrit1243";

    var certificate = new X509Certificate2(rawData,
        certificatePassword,
        X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

    var collection = new X509Certificate2Collection();
    collection.Import(rawData, certificatePassword,
        X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

    return (certificate, collection);
}
