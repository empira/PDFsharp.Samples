using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Forms;
using PdfSharp.Pdf;

namespace GraphicsPreview
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
            pagePreview.PageSize = PageSizeConverter.ToSize(PageSize.A4);
            UpdateStatusBar();
        }

        public PagePreview.RenderEvent? RenderEvent
        {
            get => _renderEvent;
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(RenderEvent));
                pagePreview.SetRenderFunction(new Action<XGraphics>(value));
                _renderEvent = value;
            }
        }
        PagePreview.RenderEvent? _renderEvent = null;

        public void UpdateDrawing()
        {
            pagePreview.Invalidate();
        }

        /// <summary>
        /// Prints the document to the default printer.
        /// See MSDN documentation for information about printer selection and printer settings.
        /// </summary>
        void Print()
        {
            var pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        /// <summary>
        /// Draws the page on the printer.
        /// </summary>
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            var graphics = ev.Graphics;
            graphics.PageUnit = GraphicsUnit.Point;
            var gfx = XGraphics.FromGraphics(graphics, PageSizeConverter.ToSize(PageSize.A4));
            if (_renderEvent != null)
                _renderEvent(gfx);

            ev.HasMorePages = false;
        }

        /// <summary>
        /// Create a new PDF document and start the viewer.
        /// </summary>
        void MakePdf()
        {
            var filename = Guid.NewGuid().ToString().ToUpper() + ".pdf";
            var document = new PdfDocument(filename);
            document.Info.Creator = "Preview Sample";
            var page = document.AddPage();
            page.Size = PageSize.A4;
            var gfx = XGraphics.FromPdfPage(page);

            if (_renderEvent != null)
                _renderEvent(gfx);
            document.Close();
            Process.Start(filename);
        }

        static int GetNewZoom(int currentZoom, bool larger)
        {
            var values = new[]
            {
                10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 120, 140, 160, 180, 200, 
                250, 300, 350, 400, 450, 500, 600, 700, 800
            };

            if (currentZoom <= (int)Zoom.Minimum && !larger)
                return (int)Zoom.Minimum;
            if (currentZoom >= (int)Zoom.Maximum && larger)
                return (int)Zoom.Maximum;

            if (larger)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    if (currentZoom < values[i])
                        return values[i];
                }
            }
            else
            {
                for (var i = values.Length - 1; i >= 0; i--)
                {
                    if (currentZoom > values[i])
                        return values[i];
                }
            }
            return (int)Zoom.Percent100;
        }

        void UpdateStatusBar()
        {
            var status = String.Format("PageSize: {0}pt x {1}pt, Zoom: {2}%",
                pagePreview.PageSize.Width,
                pagePreview.PageSize.Height,
                pagePreview.ZoomPercent);
            statusBar.Text = status;
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateStatusBar();
        }

        private void ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            var tag = e.Button.Tag;
            if (tag == null)
                return;

            switch (tag.ToString())
            {
                case "OriginalSize":
                    pagePreview.Zoom = Zoom.OriginalSize;
                    break;

                case "FullPage":
                    pagePreview.Zoom = Zoom.FullPage;
                    break;

                case "BestFit":
                    pagePreview.Zoom = Zoom.BestFit;
                    break;

                case "Smaller":
                    pagePreview.ZoomPercent = GetNewZoom(this.pagePreview.ZoomPercent, false);
                    break;

                case "Larger":
                    pagePreview.ZoomPercent = GetNewZoom(this.pagePreview.ZoomPercent, true);
                    break;

                case "Print":
                    Print();
                    break;

                case "MakePdf":
                    MakePdf();
                    break;
            }
            UpdateStatusBar();
        }

        private void MiPercent800Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent800;
            UpdateStatusBar();
        }

        private void MiPercent600Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent600;
            UpdateStatusBar();
        }

        private void MiPercent400Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent400;
            UpdateStatusBar();
        }

        private void MiPercent200Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent200;
            UpdateStatusBar();
        }

        private void MiPercent100Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent100;
            UpdateStatusBar();
        }

        private void MiPercent150Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent150;
            UpdateStatusBar();
        }

        private void MiPercent75Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent75;
            UpdateStatusBar();
        }

        private void MiPercent50Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent50;
            UpdateStatusBar();
        }

        private void MiPercent25Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent25;
            UpdateStatusBar();
        }

        private void MiPercent10Click(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.Percent10;
            UpdateStatusBar();
        }

        private void MiBestFitClick(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.BestFit;
            UpdateStatusBar();
        }

        private void MiFullPageClick(object sender, EventArgs e)
        {
            pagePreview.Zoom = Zoom.FullPage;
            UpdateStatusBar();
        }

    }
}
