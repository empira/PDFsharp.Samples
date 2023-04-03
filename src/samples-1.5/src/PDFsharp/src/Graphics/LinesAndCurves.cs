// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Graphics
{
    /// <summary>
    /// Shows the capabilities of lines and curves functions.
    /// </summary>
    public class LinesAndCurves : Base
    {
        public void DrawPage(PdfPage page)
        {
            var gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Lines & Curves");

            DrawLine(gfx, 1);
            DrawLines(gfx, 2);
            DrawBezier(gfx, 3);
            DrawBeziers(gfx, 4);
            DrawCurve(gfx, 5);
            DrawArc(gfx, 6);
        }

        /// <summary>
        /// Draws simple lines.
        /// </summary>
        void DrawLine(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawLine");

            gfx.DrawLine(XPens.DarkGreen, 0, 0, 250, 0);

            gfx.DrawLine(XPens.Gold, 15, 7, 230, 15);

            var pen = new XPen(XColors.Navy, 4);
            gfx.DrawLine(pen, 0, 20, 250, 20);

            pen = new XPen(XColors.Firebrick, 6)
            {
                DashStyle = XDashStyle.Dash
            };
            gfx.DrawLine(pen, 0, 40, 250, 40);
            pen.Width = 7.3;
            pen.DashStyle = XDashStyle.DashDotDot;
            gfx.DrawLine(pen, 0, 60, 250, 60);

            pen = new XPen(XColors.Goldenrod, 10)
            {
                LineCap = XLineCap.Flat
            };
            gfx.DrawLine(pen, 10, 90, 240, 90);
            gfx.DrawLine(XPens.Black, 10, 90, 240, 90);

            pen = new XPen(XColors.Goldenrod, 10)
            {
                LineCap = XLineCap.Square
            };
            gfx.DrawLine(pen, 10, 110, 240, 110);
            gfx.DrawLine(XPens.Black, 10, 110, 240, 110);

            pen = new XPen(XColors.Goldenrod, 10)
            {
                LineCap = XLineCap.Round
            };
            gfx.DrawLine(pen, 10, 130, 240, 130);
            gfx.DrawLine(XPens.Black, 10, 130, 240, 130);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws a ploy line.
        /// </summary>
        void DrawLines(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawLines");

            var pen = new XPen(XColors.DarkSeaGreen, 6)
            {
                LineCap = XLineCap.Round,
                LineJoin = XLineJoin.Bevel
            };
            var points =
              new XPoint[] { new XPoint(20, 30), new XPoint(60, 120), new XPoint(90, 20), new XPoint(170, 90), new XPoint(230, 40) };
            gfx.DrawLines(pen, points);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws a single Bézier curve.
        /// </summary>
        void DrawBezier(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawBezier");

            gfx.DrawBezier(new XPen(XColors.DarkRed, 5), 20, 110, 40, 10, 170, 90, 230, 20);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws two Bézier curves.
        /// </summary>
        void DrawBeziers(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawBeziers");

            var points = new XPoint[]{new XPoint(20, 30), new XPoint(40, 120), new XPoint(80, 20), new XPoint(110, 90),
                                      new XPoint(180, 40), new XPoint(210, 40), new XPoint(220, 80)};
            var pen = new XPen(XColors.Firebrick, 4);
            //pen.DashStyle = XDashStyle.Dot;
            gfx.DrawBeziers(pen, points);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws a cardinal spline.
        /// </summary>
        void DrawCurve(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawCurve");

            var points =
              new XPoint[] { new XPoint(20, 30), new XPoint(60, 120), new XPoint(90, 20), new XPoint(170, 90), new XPoint(230, 40) };
            var pen = new XPen(XColors.RoyalBlue, 3.5);
            gfx.DrawCurve(pen, points, 1);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws an arc.
        /// </summary>
        void DrawArc(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawArc");

            var pen = new XPen(XColors.Plum, 4.7);
            gfx.DrawArc(pen, 0, 0, 250, 140, 190, 200);

            EndBox(gfx);
        }
    }
}
