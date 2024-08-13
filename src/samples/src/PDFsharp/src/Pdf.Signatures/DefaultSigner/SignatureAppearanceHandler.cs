// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Globalization;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Quality;

namespace DefaultSigner
{
    class SignatureAppearanceHandler : IAnnotationAppearanceHandler
    {
        public void DrawAppearance(XGraphics gfx, XRect rect)
        {
            var imageFolder = IOUtility.GetAssetsPath("pdfsharp-6.x/signatures") ??
                              throw new InvalidOperationException("Call Download-Assets.ps1 before running the tests.");
            var pngFile = Path.Combine(imageFolder, "JohnDoe.png");
            var image = XImage.FromFile(pngFile);

            string text = "John Doe\nSeattle, " + DateTime.Now.ToString(CultureInfo.GetCultureInfo("EN-US"));
            var font = new XFont("Verdana", 7.0, XFontStyleEx.Regular);
            var textFormatter = new XTextFormatter(gfx);
            double num = (double)image.PixelWidth / image.PixelHeight;
            double signatureHeight = rect.Height * .4;
            var point = new XPoint(rect.Width / 10, rect.Height / 10);
            // Draw image.
            gfx.DrawImage(image, point.X, point.Y, signatureHeight * num, signatureHeight);
            // Adjust position for text. We draw it below image.
            point = new XPoint(point.X, rect.Height / 2d);
            //textFormatter.DrawString(text, font, new XSolidBrush(XColor.FromKnownColor(XKnownColor.Black)), new XRect(point.X, point.Y, rect.Width, rect.Height - point.Y), XStringFormats.TopLeft);
            textFormatter.DrawString(text, font, XBrushes.Black, new XRect(point.X, point.Y, rect.Width, rect.Height - point.Y), XStringFormats.TopLeft);
        }
    }
}