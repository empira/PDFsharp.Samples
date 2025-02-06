using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Forms;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.Rendering;
//using MigraDoc.Rendering.Printing; // TODO_OLD: MigraDoc.Rendering.Printing doesn't exist
using MigraDoc.Rendering.Forms;
using MigraDoc.RtfRendering;

namespace DocumentViewer
{
    /// <summary>
    /// Demonstrates all techniques you need to preview and print a MigraDoc document, and convert it to a
    /// PDF, RTF, or image file.
    /// </summary>
    public partial class Viewer : Form
    {
        private DocumentPreview _pagePreview;

        public Viewer()
        {
            InitializeComponent();

            // Create a new MigraDoc document.
            var document = SampleDocuments.CreateSample1();

            var ddl = DdlWriter.WriteToString(document);
            _pagePreview!.Ddl = ddl;

            UpdateStatusBar();
        }

        readonly PrinterSettings _printerSettings = new PrinterSettings();
        
        void UpdateStatusBar()
        {
            var info = String.Format("Page {0} of {1} - Zoom: {2}%", _pagePreview.Page, _pagePreview.PageCount,
              _pagePreview.ZoomPercent);
            _statusBar.Text = info;
        }

        /// <summary>
        /// Opens and shows a MigraDoc DDL file.
        /// 
        /// A MigraDoc DDL file is a text based serialization of a MigraDoc document.
        /// </summary>
        private void MiOpenClick(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = null!;
            try
            {
                dialog = new OpenFileDialog
                         {
                             CheckFileExists = true,
                             CheckPathExists = true,
                             Filter = "MigraDoc DDL (*.mdddl)|*.mdddl|All Files (*.*)|*.*",
                             FilterIndex = 1,
                             InitialDirectory = Path.GetFullPath(Path.Combine(GetProgramDirectory(), "..\\..\\..\\..\\assets\\ddl"))
                         };
                //dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var document = DdlReader.DocumentFromFile(dialog.FileName);
                    var folder = Path.GetDirectoryName(dialog.FileName)!;
                    Environment.CurrentDirectory = folder;
                    var ddl = DdlWriter.WriteToString(document);
                    _pagePreview.Ddl = ddl;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
                _pagePreview.Ddl = null!;
            }
            finally
            {
                if (dialog != null!)
                    dialog.Dispose();
            }
            UpdateStatusBar();
        }

        /// <summary>
        /// Prints the current document on a printer.
        /// </summary>
        private void MiPrintClick(object sender, EventArgs e)
        {
#if true_ // MigraDoc.Rendering.Printing was removed - it worked for GDI build only.
            // Reuse the renderer from the preview
            var renderer = _pagePreview.Renderer;
            if (renderer == null)
                return;

            var pageCount = renderer.FormattedDocument.PageCount;

            // Creates a PrintDocument that simplifies printing of MigraDoc documents
            var printDocument = new MigraDocPrintDocument();

            // Attach the current printer settings
            printDocument.PrinterSettings = _printerSettings;

            if (_printerSettings.PrintRange == PrintRange.Selection)
                printDocument.SelectedPage = _pagePreview.Page;

            // Attach the current document renderer
            printDocument.Renderer = renderer;

            // Print the document
            printDocument.Print();
#endif
        }

        /// <summary>
        /// Sets the zoom factor.
        /// </summary>
        private void MiZoomClick(object sender, EventArgs e)
        {
            // Tricky conversion from menu item to zoom value...
            var name = ((MenuItem)sender).Text;
            name = name.Substring(0, name.Length - 1);
            _pagePreview.ZoomPercent = int.Parse(name);
            UpdateStatusBar();
        }

        private void MiBestFitClick(object sender, EventArgs e)
        {
            _pagePreview.Zoom = MigraDoc.Rendering.Forms.Zoom.BestFit;
            UpdateStatusBar();
        }

        private void MiFullPageClick(object sender, EventArgs e)
        {
            _pagePreview.Zoom = MigraDoc.Rendering.Forms.Zoom.FullPage;
            UpdateStatusBar();
        }

        private void MiOriginalSizeClick(object sender, EventArgs e)
        {
            _pagePreview.Zoom = MigraDoc.Rendering.Forms.Zoom.OriginalSize;
            UpdateStatusBar();
        }

        private void MiFirstClick(object sender, EventArgs e)
        {
            _pagePreview.FirstPage();
            UpdateStatusBar();
        }

        private void MiPrevClick(object sender, EventArgs e)
        {
            _pagePreview.PrevPage();
            UpdateStatusBar();
        }

        private void MiNextClick(object sender, EventArgs e)
        {
            _pagePreview.NextPage();
            UpdateStatusBar();
        }

        private void MiLastClick(object sender, EventArgs e)
        {
            _pagePreview.LastPage();
            UpdateStatusBar();
        }

        /// <summary>
        /// Creates a PDF file from the current document.
        /// </summary>
        private void MiPdfClick(object sender, EventArgs e)
        {
            var printer = new PdfDocumentRenderer();
            printer.DocumentRenderer = _pagePreview.Renderer;
            printer.Document = _pagePreview.Document;
            printer.RenderDocument();
            _pagePreview.Document.BindToRenderer(null!);
            printer.Save("test.pdf");

            Process.Start("test.pdf");
        }

        /// <summary>
        /// Creates a RTF file from the current document.
        /// </summary>
        private void MiRtfClick(object sender, EventArgs e)
        {
            var rtf = new RtfDocumentRenderer();
            rtf.Render(_pagePreview.Document, "test.rtf", null!);

            Process.Start("test.rtf");
        }

        /// <summary>
        /// Creates an image from the current page.
        /// </summary>
        private void MiBmpClick(object sender, EventArgs e)
        {
            var page = _pagePreview.Page;

            // Reuse the renderer from the preview.
            var renderer = _pagePreview.Renderer;
            var info = renderer.FormattedDocument!.GetPageInfo(page);

            // Create an image.
            var dpi = 150;
            int dx, dy;
            if (info.Orientation == PdfSharp.PageOrientation.Portrait)
            {
                dx = (int)(info.Width.Inch * dpi);
                dy = (int)(info.Height.Inch * dpi);
            }
            else
            {
                dx = (int)(info.Height.Inch * dpi);
                dy = (int)(info.Width.Inch * dpi);
            }

            Image image = new Bitmap(dx, dy, PixelFormat.Format32bppRgb);

            // Create a Graphics object for the image and scale it for drawing with 72 dpi.
            var graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            var scale = dpi / 72f;
            graphics.ScaleTransform(scale, scale);

            // Create an XGraphics object and render the page.
            var gfx = XGraphics.FromGraphics(graphics, new XSize(info.Width.Point, info.Height.Point), null);
            renderer.RenderPage(gfx, page);
            gfx.Dispose();
            image.Save("test.png", ImageFormat.Png);

            Process.Start("mspaint", "test.png");  // Use MSPaint, not Photoshop...
        }

        /// <summary>
        /// Creates a meta file from the current page.
        /// </summary>
        private void MiMetaFileClick(object sender, EventArgs e)
        {
            var page = _pagePreview.Page;

            // Reuse the renderer from the preview
            var renderer = _pagePreview.Renderer;
            var info = renderer.FormattedDocument!.GetPageInfo(page);

            // Create an image
            float dx, dy;
            if (info.Orientation == PdfSharp.PageOrientation.Portrait)
            {
                dx = (float)(info.Width.Inch * 72);
                dy = (float)(info.Height.Inch * 72);
            }
            else
            {
                dx = (float)(info.Height.Inch * 72);
                dy = (float)(info.Width.Inch * 72);
            }

            // Create a graphics object as reference.
            var graphicsDisplay = CreateGraphics();
            var hdc = graphicsDisplay.GetHdc();

            // There is a little difference between the display resolution (i.g. 96 DPI) and the real physical solution of the display.
            // This must be taken into account...
            var devInfo = DeviceInfos.GetInfos(hdc);

            // Create the metafile.
            var metafile = new Metafile("test.emf", hdc,
              new RectangleF(0, 0, devInfo.ScaleX * dx, devInfo.ScaleY * dy), MetafileFrameUnit.Point);
            graphicsDisplay.ReleaseHdc(hdc);
            graphicsDisplay.Dispose();

            // Create a Graphics object for the metafile and scale it for drawing with 72 dpi.
            var graphics = Graphics.FromImage(metafile);
            graphics.Clear(Color.White);
            //graphics.PageUnit = GraphicsUnit.Point; ???
            graphics.ScaleTransform(graphics.DpiX / 72, graphics.DpiY / 72);

            // Check if size is correct.
            graphics.DrawLine(Pens.Red, 0, 0, dx, dy);

            // Create an XGraphics object and render the page.
            var gfx = XGraphics.FromGraphics(graphics, new XSize(info.Width.Point, info.Height.Point), null);
            renderer.RenderPage(gfx, page);
            gfx.Dispose();

            metafile.Dispose();

            Process.Start("test.emf");
        }


        /// <summary>
        /// Demonstrates the preview using System.Windows.Forms.PrintPreviewDialog.
        /// In .NET 1.x this dialog is a lousy implementation. In .NET 2.0 it's a little bit better 
        /// (at least portrait/landscape is handled correctly...).
        /// </summary>
        private void MiPreviewClick(object sender, EventArgs e)
        {
#if true_ // MigraDoc.Rendering.Printing was removed - it worked for GDI build only.
            using (var dialog = new PrintPreviewDialog())
            {
                dialog.Text = "Preview using System.Windows.Froms.PrintPreviewDialog";
#if NET_2_0
                dialog.ShowIcon = false;
#endif
                dialog.MinimizeBox = false;
                dialog.MaximizeBox = false;

                // Reuse the renderer from the preview
                var renderer = _pagePreview.Renderer;

                // Creates a PrintDocument that simplifies printing of MigraDoc documents
                var printDocument = new MigraDocPrintDocument();

                // Attach the current printer settings
                printDocument.PrinterSettings = _printerSettings;

                // Attach the current document renderer
                printDocument.Renderer = renderer;

                // Attach the current print document
                dialog.Document = printDocument;

                // Show the preview
                dialog.ShowDialog();
            }
#endif
        }

        /// <summary>
        /// Opens the printer setup dialog.
        /// </summary>
        private void MiPrinterSetupClick(object sender, EventArgs e)
        {
            using (var dialog = new PrintDialog())
            {
                dialog.PrinterSettings = _printerSettings;
                dialog.AllowSelection = true;
                dialog.AllowSomePages = true;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Called by preview control to reflect changes to the text in the status bar.
        /// </summary>
        private void PagePreviewChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void MiSample1Click(object sender, EventArgs e)
        {
            var document = SampleDocuments.CreateSample1();
            _pagePreview.Ddl = DdlWriter.WriteToString(document);
        }

        private void MiSample2Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(GetProgramDirectory());
            var document = SampleDocuments.CreateSample2();
            _pagePreview.Ddl = DdlWriter.WriteToString(document);
        }

        private void MiExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private string GetProgramDirectory()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.Location);
        }

    }
}
