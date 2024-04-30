// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace XForms
{
    /// <summary>
    /// This sample shows how to create an XForm object from scratch. You can think of such an
    /// object as a template, that, once created, can be drawn frequently anywhere in your PDF document.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Create a new PDF document.
            var document = new PdfDocument();
            document.PageLayout = PdfPageLayout.SinglePage;
            document.ViewerPreferences.FitWindow = true;

            // Create a font.
            var font = new XFont("Arial", 16);

            // Create a new page.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page, XPageDirection.Downwards);
            gfx.DrawString("XPdfForm Sample", font, XBrushes.DarkGray, 15, 25, XStringFormats.Default);

            // Step 1: Create an XForm and draw some graphics on it.

            // Create an empty XForm object with the specified width and height
            // A form is bound to its target document when it is created. The reason is that the form can 
            // share fonts and other objects with its target document.
            var form = new XForm(document, XUnit.FromMillimeter(70), XUnit.FromMillimeter(55));

            // Create an XGraphics object for drawing the contents of the form.
            var formGfx = XGraphics.FromForm(form);

            // Draw a large transparent rectangle to visualize the area the form occupies.
            var back = XColors.Orange;
            back.A = 0.2;
            var brush = new XSolidBrush(back);
            formGfx.DrawRectangle(brush, -10_000, -10_000, 20_000, 20_000);

            // On a form you can draw...

            // ... text
            formGfx.DrawString("Text, Graphics, Images, and Forms", new XFont("Arial", 10, XFontStyleEx.Regular), XBrushes.Navy, 3, 0, XStringFormats.TopLeft);
            //formGfx.DrawString("Text, Graphics, Images, and Forms", new XFont("Segoe WP", 10, XFontStyleEx.Regular), XBrushes.Navy, 3, 0, XStringFormats.TopLeft);
            var pen = XPens.LightBlue.Clone();
            pen.Width = 2.5;

            // ... graphics like Bézier curves.
            formGfx.DrawBeziers(pen, XPoint.ParsePoints("30,120 80,20 100,140 175,33.3"));

            // ... raster images like PNG files.
            XGraphicsState state = formGfx.Save();
            formGfx.RotateAtTransform(17, new XPoint(30, 30));
            formGfx.DrawImage(XImage.FromFile(IOUtility.GetAssetsPath("archives/samples-1.5/images/Test.png")!), 20, 20);
            formGfx.Restore(state);

            // ... and forms like XPdfForm objects.
            state = formGfx.Save();
            formGfx.RotateAtTransform(-8, new XPoint(165, 115));
            formGfx.DrawImage(XPdfForm.FromFile(IOUtility.GetAssetsPath("archives/samples-1.5/PDFs/SomeLayout.pdf")!), new XRect(140, 80, 50, 50 * Math.Sqrt(2)));
            formGfx.Restore(state);

            // When you finished drawing on the form, dispose the XGraphic object.
            formGfx.Dispose();

            // Step 2: Draw the XPdfForm on your PDF page like an image.

            // Draw the form on the page of the document in its original size.
            gfx.DrawImage(form, 20, 50);

#if true
            // Draw it stretched.
            gfx.DrawImage(form, 300, 100, 250, 40);

            // Draw and rotate it.
            const int d = 25;
            for (int idx = 0; idx < 360; idx += d)
            {
                gfx.DrawImage(form, 300, 480, 200, 200);
                gfx.RotateAtTransform(d, new XPoint(300, 480));
            }
#endif

            // Save the document...
            string filename = PdfFileUtility.GetTempPdfFullFileName("samples-1.5/XForms");
            document.Save(filename);
            // ...and start a viewer.
            PdfFileUtility.ShowDocument(filename);
        }
    }
}
