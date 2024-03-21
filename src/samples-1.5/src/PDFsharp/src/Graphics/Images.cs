// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace Graphics
{
    /// <summary>
    /// Shows how to draw images.
    /// </summary>
    public class Images : Base
    {
        readonly string _jpegSamplePath = IOUtility.GetAssetsPath("archives/samples-1.5/images/Z3.jpg")!;
        readonly string _gifSamplePath = IOUtility.GetAssetsPath("archives/samples-1.5/images/Test.gif")!;
        readonly string _pngSamplePath = IOUtility.GetAssetsPath("archives/samples-1.5/images/Test.png")!;
        readonly string _tiffSamplePath = IOUtility.GetAssetsPath("archives/samples-1.5/images/Rose (RGB 8).tif")!;
        readonly string _pdfSamplePath = IOUtility.GetAssetsPath("archives/samples-1.5/PDFs/SomeLayout.pdf")!;

        public void DrawPage(PdfPage page)
        {
            var gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Images");

            DrawImage(gfx, 1);
            DrawImageScaled(gfx, 2);
            DrawImageRotated(gfx, 3);
            DrawImageSheared(gfx, 4);
            // NET6HACK
#if !CORE
            DrawGif(gfx, 5);
#endif
            DrawPng(gfx, 6);
#if !CORE
            DrawTiff(gfx, 7);
#endif
            DrawFormXObject(gfx, 8);
        }

        /// <summary>
        /// Draws an image in original size.
        /// </summary>
        void DrawImage(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawImage (original)");

            var image = XImage.FromFile(_jpegSamplePath);

            // Left position in point
            double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
            gfx.DrawImage(image, x, 0);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws an image scaled.
        /// </summary>
        void DrawImageScaled(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawImage (scaled)");

            var image = XImage.FromFile(_jpegSamplePath);
            gfx.DrawImage(image, 0, 0, 250, 140);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws an image transformed.
        /// </summary>
        void DrawImageRotated(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawImage (rotated)");

            var image = XImage.FromFile(_jpegSamplePath);

            const double dx = 250, dy = 140;

            gfx.TranslateTransform(dx / 2, dy / 2);
            gfx.ScaleTransform(0.7);
            gfx.RotateTransform(-25);
            gfx.TranslateTransform(-dx / 2, -dy / 2);

            //XMatrix matrix = new XMatrix();  //XMatrix.Identity;

            double width = image.PixelWidth * 72 / image.HorizontalResolution;
            double height = image.PixelHeight * 72 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, 0, width, height);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws an image transformed.
        /// </summary>
        void DrawImageSheared(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawImage (sheared)");

            var image = XImage.FromFile(_jpegSamplePath);

            const double dx = 250, dy = 140;

            //XMatrix matrix = gfx.Transform;
            //matrix.TranslatePrepend(dx / 2, dy / 2);
            //matrix.ScalePrepend(-0.7, 0.7);
            //matrix.ShearPrepend(-0.4, -0.3);
            //matrix.TranslatePrepend(-dx / 2, -dy / 2);
            //gfx.Transform = matrix;

            gfx.TranslateTransform(dx / 2, dy / 2);
            gfx.ScaleTransform(-0.7, 0.7);
            gfx.ShearTransform(-0.4, -0.3);
            gfx.TranslateTransform(-dx / 2, -dy / 2);

            double width = image.PixelWidth * 72 / image.HorizontalResolution;
            double height = image.PixelHeight * 72 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, 0, width, height);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws a GIF image with transparency.
        /// </summary>
        void DrawGif(XGraphics gfx, int number)
        {
            BackColor = XColors.LightGoldenrodYellow;
            BorderPen = new XPen(XColor.FromArgb(202, 121, 74), BorderWidth);
            BeginBox(gfx, number, "DrawImage (GIF)");

            var image = XImage.FromFile(_gifSamplePath);

            const double dx = 250, dy = 140;

            double width = image.PixelWidth * 72 / image.HorizontalResolution;
            double height = image.PixelHeight * 72 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws a PNG image with transparency.
        /// </summary>
        void DrawPng(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawImage (PNG)");

            var image = XImage.FromFile(_pngSamplePath);

            const double dx = 250, dy = 140;

            double width = image.PixelWidth * 72 / image.HorizontalResolution;
            double height = image.PixelHeight * 72 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws a TIFF image with transparency.
        /// </summary>
        void DrawTiff(XGraphics gfx, int number)
        {
            XColor oldBackColor = BackColor;
            BackColor = XColors.LightGoldenrodYellow;
            BeginBox(gfx, number, "DrawImage (TIFF)");

            var image = XImage.FromFile(_tiffSamplePath);

            const double dx = 250, dy = 140;

            double width = image.PixelWidth * 72 / image.HorizontalResolution;
            double height = image.PixelHeight * 72 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

            EndBox(gfx);
            BackColor = oldBackColor;
        }

        /// <summary>
        /// Draws a form XObject (a page from an external PDF file).
        /// </summary>
        void DrawFormXObject(XGraphics gfx, int number)
        {
            //this.backColor = XColors.LightSalmon;
            BeginBox(gfx, number, "DrawImage (Form XObject)");

            var image = XImage.FromFile(_pdfSamplePath);

            const double dx = 250, dy = 140;

            gfx.TranslateTransform(dx / 2, dy / 2);
            gfx.ScaleTransform(0.35);
            gfx.TranslateTransform(-dx / 2, -dy / 2);

            double width = image.PixelWidth * 72 / image.HorizontalResolution;
            double height = image.PixelHeight * 72 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

            EndBox(gfx);
        }
    }
}
