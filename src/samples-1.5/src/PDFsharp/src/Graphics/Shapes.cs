// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Graphics
{
    /// <summary>
    /// Shows how to draw graphical shapes.
    /// </summary>
    public class Shapes : Base
    {
        public void DrawPage(PdfPage page)
        {
            var gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Shapes");

            DrawRectangle(gfx, 1);
            DrawRoundedRectangle(gfx, 2);
            DrawEllipse(gfx, 3);
            DrawPolygon(gfx, 4);
            DrawPie(gfx, 5);
            DrawClosedCurve(gfx, 6);
        }

        /// <summary>
        /// Draws rectangles.
        /// </summary>
        void DrawRectangle(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawRectangle");

            var pen = new XPen(XColors.Navy, Math.PI);

            gfx.DrawRectangle(pen, 10, 0, 100, 60);
            gfx.DrawRectangle(XBrushes.DarkOrange, 130, 0, 100, 60);
            gfx.DrawRectangle(pen, XBrushes.DarkOrange, 10, 80, 100, 60);
            gfx.DrawRectangle(pen, XBrushes.DarkOrange, 150, 80, 60, 60);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws rounded rectangles.
        /// </summary>
        void DrawRoundedRectangle(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawRoundedRectangle");

            var pen = new XPen(XColors.RoyalBlue, Math.PI);

            gfx.DrawRoundedRectangle(pen, 10, 0, 100, 60, 30, 20);
            gfx.DrawRoundedRectangle(XBrushes.Orange, 130, 0, 100, 60, 30, 20);
            gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 10, 80, 100, 60, 30, 20);
            gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 150, 80, 60, 60, 20, 20);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws ellipses.
        /// </summary>
        void DrawEllipse(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawEllipse");

            var pen = new XPen(XColors.DarkBlue, 2.5);

            gfx.DrawEllipse(pen, 10, 0, 100, 60);
            gfx.DrawEllipse(XBrushes.Goldenrod, 130, 0, 100, 60);
            gfx.DrawEllipse(pen, XBrushes.Goldenrod, 10, 80, 100, 60);
            gfx.DrawEllipse(pen, XBrushes.Goldenrod, 150, 80, 60, 60);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws polygons.
        /// </summary>
        void DrawPolygon(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawPolygon");

            var pen = new XPen(XColors.DarkBlue, 2.5);

            gfx.DrawPolygon(pen, XBrushes.LightCoral, GetPentagram(50, new XPoint(60, 70)), XFillMode.Winding);
            gfx.DrawPolygon(pen, XBrushes.LightCoral, GetPentagram(50, new XPoint(180, 70)), XFillMode.Alternate);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws pies.
        /// </summary>
        void DrawPie(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawPie");

            var pen = new XPen(XColors.DarkBlue, 2.5);

            gfx.DrawPie(pen, 10, 0, 100, 90, -120, 75);
            gfx.DrawPie(XBrushes.Gold, 130, 0, 100, 90, -160, 150);
            gfx.DrawPie(pen, XBrushes.Gold, 10, 50, 100, 90, 80, 70);
            gfx.DrawPie(pen, XBrushes.Gold, 150, 80, 60, 60, 35, 290);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws a closed cardinal spline.
        /// </summary>
        void DrawClosedCurve(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawClosedCurve");

            var pen = new XPen(XColors.DarkBlue, 2.5);
            gfx.DrawClosedCurve(pen, XBrushes.SkyBlue,
              new XPoint[] { new XPoint(10, 120), new XPoint(80, 30), new XPoint(220, 20), new XPoint(170, 110), new XPoint(100, 90) },
              XFillMode.Winding, 0.7);

            EndBox(gfx);
        }
    }
}
