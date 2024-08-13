// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Security.Cryptography.X509Certificates;
using DefaultSigner;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Signatures;
using PdfSharp.Quality;

// The minimum assets version required.
// Our test .pfx file is stored in the assets.
const int requiredAssets = 1014;
IOUtility.EnsureAssetsVersion(requiredAssets);

// When we add a timestamp to the digital signature, PDFsharp must access a timestamp server on the Internet.
// This is done async and therefore, we use 'await document.SaveAsync(filename)' here.
// Using the sync version of 'Save' also works, but it blocks the current thread during the web request.

// Create a signed document without a timestamp (which is very common).
await CreateSignedDocument();

// PDFsharp 6.2 cannot add a timestamp when using .NET Framework.
#if NET6_0_OR_GREATER
// Create the same signed document, but with a timestamp.
await CreateSignedDocument(true);
#endif
return;

static async Task CreateSignedDocument(bool addTimestamp =false)
{
    var font = new XFont("Verdana", 10, XFontStyleEx.Regular);
    var fontHeader = new XFont("Verdana", 18, XFontStyleEx.Regular);
    using var document = new PdfDocument();
    var pdfPage = document.AddPage();
    var xGraphics = XGraphics.FromPdfPage(pdfPage);
    var layoutRectangle = new XRect(0, 72, pdfPage.Width.Point, pdfPage.Height.Point);
    xGraphics.DrawString("License Agreement", fontHeader, XBrushes.Black, layoutRectangle, XStringFormats.TopCenter);
    var textFormatter = new XTextFormatter(xGraphics);
    layoutRectangle = new XRect(72, 144, pdfPage.Width.Point - 144, pdfPage.Height.Point - 144);

    var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam interdum ultrices purus, et congue nulla aliquam quis. Nullam quis finibus velit. Proin sed tellus eu risus accumsan facilisis eu quis felis. Nulla vel nisl non elit elementum tempus. Fusce et tellus feugiat, tempus elit non, vulputate magna. Etiam id vestibulum enim. Sed euismod auctor orci pellentesque dapibus. Fusce nec commodo erat, a posuere sapien. Phasellus sed lobortis orci. In hac habitasse platea dictumst. Sed lacinia lobortis nunc, sed consequat elit eleifend vitae.\r\n\r\n" +
               "Nulla fringilla nunc ipsum, sed consectetur enim scelerisque nec. Maecenas malesuada libero sit amet nulla mattis finibus. Praesent id ipsum non nulla maximus vestibulum eu ac ipsum. Morbi eget augue at odio mollis tempus in id ante. Praesent efficitur lectus eu velit sagittis, quis egestas lorem pellentesque. Cras placerat aliquet tristique. Donec tincidunt orci ornare odio pretium, ac blandit justo ultrices. Vestibulum a posuere orci. Morbi consectetur, dui ut aliquet dapibus, leo nunc bibendum nibh, eu mattis nulla lectus non mauris. Pellentesque in condimentum lorem, nec aliquet nulla. Etiam massa arcu, blandit a tempor sed, porttitor non ligula. Suspendisse tempor vitae risus ac pretium. Aliquam non dictum massa, vel dictum metus. Pellentesque vitae magna nec dolor gravida ultricies et non nunc. Vivamus at velit at dolor luctus convallis sed consequat risus.\r\n\r\n" +
               "Morbi sit amet eros vitae erat dapibus pulvinar. Cras viverra ex at ullamcorper luctus. Aliquam lobortis quis leo eu hendrerit. Praesent imperdiet, ipsum sed porttitor aliquam, augue felis tempor erat, eu pellentesque est nisl eget risus. Fusce nec facilisis orci, non hendrerit ligula. In vitae enim pellentesque sem lacinia varius sit amet eu lectus. Donec finibus nunc metus, consequat viverra libero finibus ac. Sed ut blandit elit, non ullamcorper ex. Aenean placerat, dui sed gravida fringilla, purus nibh venenatis nibh, id feugiat purus sem in lacus. Nullam sit amet justo augue. In ut pharetra neque. Vestibulum ac efficitur enim, nec tristique nibh. Praesent quis velit interdum ante eleifend convallis. Vestibulum eget lorem at ipsum porttitor aliquet. Maecenas malesuada malesuada leo ut feugiat. Vivamus euismod vitae ligula eget lacinia.";
    //textFormatter.DrawString(text, font, new XSolidBrush(XColor.FromKnownColor(XKnownColor.Black)), layoutRectangle, XStringFormats.TopLeft);
    textFormatter.DrawString(text, font, XBrushes.Black, layoutRectangle, XStringFormats.TopLeft);

    var pdfPosition = xGraphics.Transformer.WorldToDefaultPage(new XPoint(144, 600));
    var options = new DigitalSignatureOptions
    {
        ContactInfo = "John Doe",
        Location = "Seattle",
        Reason = "License Agreement",
        Rectangle = new XRect(pdfPosition.X, pdfPosition.Y, 200, 50),
        AppearanceHandler = new SignatureAppearanceHandler()
    };

    // Specify the URI of a timestamp server if you want a signature with timestamp.
    var pdfSignatureHandler = DigitalSignatureHandler.ForDocument(document,
        new PdfSharpDefaultSigner(GetCertificate(), PdfMessageDigestType.SHA256, addTimestamp ? new Uri("http://timestamp.apple.com/ts01") : null),
        options);

    // Save the document...
    string filename = PdfFileUtility.GetTempPdfFullFileName("samples-PDFsharp/Signatures/DefaultSignerSample" + (addTimestamp ? "Timestamped" : null));
    await document.SaveAsync(filename);
    // ...and start a viewer.
    PdfFileUtility.ShowDocument(filename);
}


static X509Certificate2 GetCertificate()
{
    var certFolder = IOUtility.GetAssetsPath("pdfsharp-6.x/signatures") ??
                     throw new InvalidOperationException("Call Download-Assets.ps1 before running the tests.");
    var pfxFile = Path.Combine(certFolder , "test-cert_rsa_1024.pfx");
    var rawData = File.ReadAllBytes(pfxFile);

    // This code is for demonstration only. Do not use password literals for real certificates in source code.
    var certificatePassword = "Seecrit1243";

    var certificate = new X509Certificate2(rawData,
        certificatePassword,
        X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

    return certificate;
}