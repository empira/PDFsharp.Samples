namespace DocumentViewer
{
    partial class Viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this._miFile = new System.Windows.Forms.MenuItem();
            this._miSample1 = new System.Windows.Forms.MenuItem();
            this._miSample2 = new System.Windows.Forms.MenuItem();
            this._miOpen = new System.Windows.Forms.MenuItem();
            this._menuItem22 = new System.Windows.Forms.MenuItem();
            this._miPrinterSetup = new System.Windows.Forms.MenuItem();
            this._miPreview = new System.Windows.Forms.MenuItem();
            this._miPrint = new System.Windows.Forms.MenuItem();
            this._menuItem24 = new System.Windows.Forms.MenuItem();
            this._miExit = new System.Windows.Forms.MenuItem();
            this._miZoom = new System.Windows.Forms.MenuItem();
            this._miZoom800 = new System.Windows.Forms.MenuItem();
            this._miZoom600 = new System.Windows.Forms.MenuItem();
            this._miZoom400 = new System.Windows.Forms.MenuItem();
            this._miZoom200 = new System.Windows.Forms.MenuItem();
            this._miZoom150 = new System.Windows.Forms.MenuItem();
            this._miZoom100 = new System.Windows.Forms.MenuItem();
            this._miZoom50 = new System.Windows.Forms.MenuItem();
            this._miZoom25 = new System.Windows.Forms.MenuItem();
            this._miZoom10 = new System.Windows.Forms.MenuItem();
            this._menuItem18 = new System.Windows.Forms.MenuItem();
            this._miBestFit = new System.Windows.Forms.MenuItem();
            this._miFullPage = new System.Windows.Forms.MenuItem();
            this._miOriginalSize = new System.Windows.Forms.MenuItem();
            this._miDemonstrate = new System.Windows.Forms.MenuItem();
            this._miPdf = new System.Windows.Forms.MenuItem();
            this._miRtf = new System.Windows.Forms.MenuItem();
            this._miBmp = new System.Windows.Forms.MenuItem();
            this._miMetaFile = new System.Windows.Forms.MenuItem();
            this._miFirst = new System.Windows.Forms.MenuItem();
            this._miPrev = new System.Windows.Forms.MenuItem();
            this._miNext = new System.Windows.Forms.MenuItem();
            this._miLast = new System.Windows.Forms.MenuItem();
            this._menuItem1 = new System.Windows.Forms.MenuItem();
            this._menuItem2 = new System.Windows.Forms.MenuItem();
            this._statusBar = new System.Windows.Forms.StatusBar();
            this._pagePreview = new MigraDoc.Rendering.Forms.DocumentPreview();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miZoom,
            this._miDemonstrate,
            this._miFirst,
            this._miPrev,
            this._miNext,
            this._miLast});
            // 
            // _miFile
            // 
            this._miFile.Index = 0;
            this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miSample1,
            this._miSample2,
            this._miOpen,
            this._menuItem22,
            this._miPrinterSetup,
            this._miPreview,
            this._miPrint,
            this._menuItem24,
            this._miExit});
            this._miFile.Text = "&File";
            // 
            // _miSample1
            // 
            this._miSample1.Index = 0;
            this._miSample1.Text = "Create Sample 1";
            this._miSample1.Click += new System.EventHandler(this.MiSample1Click);
            // 
            // _miSample2
            // 
            this._miSample2.Index = 1;
            this._miSample2.Text = "Create Sample 2";
            this._miSample2.Click += new System.EventHandler(this.MiSample2Click);
            // 
            // _miOpen
            // 
            this._miOpen.Index = 2;
            this._miOpen.ShowShortcut = false;
            this._miOpen.Text = "&Open DDL File";
            this._miOpen.Click += new System.EventHandler(this.MiOpenClick);
            // 
            // _menuItem22
            // 
            this._menuItem22.Index = 3;
            this._menuItem22.Text = "-";
            // 
            // _miPrinterSetup
            // 
            this._miPrinterSetup.Enabled = false;
            this._miPrinterSetup.Index = 4;
            this._miPrinterSetup.Text = "Printer Setup";
            this._miPrinterSetup.Click += new System.EventHandler(this.MiPrinterSetupClick);
            // 
            // _miPreview
            // 
            this._miPreview.Enabled = false;
            this._miPreview.Index = 5;
            this._miPreview.Text = "Preview";
            this._miPreview.Click += new System.EventHandler(this.MiPreviewClick);
            // 
            // _miPrint
            // 
            this._miPrint.Enabled = false;
            this._miPrint.Index = 6;
            this._miPrint.Text = "&Print";
            this._miPrint.Click += new System.EventHandler(this.MiPrintClick);
            // 
            // _menuItem24
            // 
            this._menuItem24.Index = 7;
            this._menuItem24.Text = "-";
            // 
            // _miExit
            // 
            this._miExit.Index = 8;
            this._miExit.Text = "&Exit";
            this._miExit.Click += new System.EventHandler(this.MiExitClick);
            // 
            // _miZoom
            // 
            this._miZoom.Index = 1;
            this._miZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miZoom800,
            this._miZoom600,
            this._miZoom400,
            this._miZoom200,
            this._miZoom150,
            this._miZoom100,
            this._miZoom50,
            this._miZoom25,
            this._miZoom10,
            this._menuItem18,
            this._miBestFit,
            this._miFullPage,
            this._miOriginalSize});
            this._miZoom.Text = "&Zoom";
            // 
            // _miZoom800
            // 
            this._miZoom800.Index = 0;
            this._miZoom800.Text = "800%";
            this._miZoom800.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom600
            // 
            this._miZoom600.Index = 1;
            this._miZoom600.Text = "600%";
            this._miZoom600.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom400
            // 
            this._miZoom400.Index = 2;
            this._miZoom400.Text = "400%";
            this._miZoom400.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom200
            // 
            this._miZoom200.Index = 3;
            this._miZoom200.Text = "200%";
            this._miZoom200.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom150
            // 
            this._miZoom150.Index = 4;
            this._miZoom150.Text = "150%";
            this._miZoom150.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom100
            // 
            this._miZoom100.Index = 5;
            this._miZoom100.Text = "100%";
            this._miZoom100.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom50
            // 
            this._miZoom50.Index = 6;
            this._miZoom50.Text = "50%";
            this._miZoom50.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom25
            // 
            this._miZoom25.Index = 7;
            this._miZoom25.Text = "25%";
            this._miZoom25.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _miZoom10
            // 
            this._miZoom10.Index = 8;
            this._miZoom10.Text = "10%";
            this._miZoom10.Click += new System.EventHandler(this.MiZoomClick);
            // 
            // _menuItem18
            // 
            this._menuItem18.Index = 9;
            this._menuItem18.Text = "-";
            // 
            // _miBestFit
            // 
            this._miBestFit.Index = 10;
            this._miBestFit.Text = "Best Fit";
            this._miBestFit.Click += new System.EventHandler(this.MiBestFitClick);
            // 
            // _miFullPage
            // 
            this._miFullPage.Index = 11;
            this._miFullPage.Text = "Full Page";
            this._miFullPage.Click += new System.EventHandler(this.MiFullPageClick);
            // 
            // _miOriginalSize
            // 
            this._miOriginalSize.Index = 12;
            this._miOriginalSize.Text = "OriginalSize";
            this._miOriginalSize.Click += new System.EventHandler(this.MiOriginalSizeClick);
            // 
            // _miDemonstrate
            // 
            this._miDemonstrate.Index = 2;
            this._miDemonstrate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miPdf,
            this._miRtf,
            this._miBmp,
            this._miMetaFile});
            this._miDemonstrate.Text = "&Demonstrate";
            // 
            // _miPdf
            // 
            this._miPdf.Index = 0;
            this._miPdf.Text = "Create PDF File";
            this._miPdf.Click += new System.EventHandler(this.MiPdfClick);
            // 
            // _miRtf
            // 
            this._miRtf.Index = 1;
            this._miRtf.Text = "Create Word/RTF File";
            this._miRtf.Click += new System.EventHandler(this.MiRtfClick);
            // 
            // _miBmp
            // 
            this._miBmp.Index = 2;
            this._miBmp.Text = "Create Image File";
            this._miBmp.Click += new System.EventHandler(this.MiBmpClick);
            // 
            // _miMetaFile
            // 
            this._miMetaFile.Index = 3;
            this._miMetaFile.Text = "Create Meta File";
            this._miMetaFile.Click += new System.EventHandler(this.MiMetaFileClick);
            // 
            // _miFirst
            // 
            this._miFirst.Index = 3;
            this._miFirst.Text = "<<";
            this._miFirst.Click += new System.EventHandler(this.MiFirstClick);
            // 
            // _miPrev
            // 
            this._miPrev.Index = 4;
            this._miPrev.Text = "<";
            this._miPrev.Click += new System.EventHandler(this.MiPrevClick);
            // 
            // _miNext
            // 
            this._miNext.Index = 5;
            this._miNext.Text = ">";
            this._miNext.Click += new System.EventHandler(this.MiNextClick);
            // 
            // _miLast
            // 
            this._miLast.Index = 6;
            this._miLast.Text = ">>";
            this._miLast.Click += new System.EventHandler(this.MiLastClick);
            // 
            // _menuItem1
            // 
            this._menuItem1.Index = -1;
            this._menuItem1.Text = "";
            // 
            // _menuItem2
            // 
            this._menuItem2.Index = -1;
            this._menuItem2.Text = ",,";
            // 
            // _statusBar
            // 
            this._statusBar.Location = new System.Drawing.Point(0, 491);
            this._statusBar.Name = "_statusBar";
            this._statusBar.Size = new System.Drawing.Size(760, 22);
            this._statusBar.TabIndex = 2;
            // 
            // _pagePreview
            // 
            this._pagePreview.Ddl = null;
            this._pagePreview.DesktopColor = System.Drawing.SystemColors.ControlDark;
            this._pagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pagePreview.Document = null;
            this._pagePreview.Location = new System.Drawing.Point(0, 0);
            this._pagePreview.Name = "_pagePreview";
            this._pagePreview.Page = 0;
            this._pagePreview.PageColor = System.Drawing.Color.Snow;
            this._pagePreview.PageSize = new System.Drawing.Size(595, 842);
            this._pagePreview.Size = new System.Drawing.Size(760, 491);
            this._pagePreview.TabIndex = 3;
            this._pagePreview.ZoomPercent = 41;
            this._pagePreview.ZoomChanged += new MigraDoc.Rendering.Forms.PagePreviewEventHandler(this.PagePreviewChanged);
            this._pagePreview.PageChanged += new MigraDoc.Rendering.Forms.PagePreviewEventHandler(this.PagePreviewChanged);
            // 
            // Viewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(760, 513);
            this.Controls.Add(this._pagePreview);
            this.Controls.Add(this._statusBar);
            this.Menu = this._mainMenu;
            this.Name = "Viewer";
            this.Text = "MigraDoc Document Viewer (for demonstration only)";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.MainMenu _mainMenu;
        private System.Windows.Forms.MenuItem _menuItem18;
        private System.Windows.Forms.MenuItem _menuItem22;
        private System.Windows.Forms.MenuItem _menuItem24;
        private System.Windows.Forms.MenuItem _miFile;
        private System.Windows.Forms.MenuItem _miZoom;
        private System.Windows.Forms.MenuItem _miZoom800;
        private System.Windows.Forms.MenuItem _miOpen;
        private System.Windows.Forms.MenuItem _miPrint;
        private System.Windows.Forms.MenuItem _miExit;
        private System.Windows.Forms.MenuItem _miPrev;
        private System.Windows.Forms.MenuItem _miNext;
        private System.Windows.Forms.MenuItem _miPdf;
        private System.Windows.Forms.MenuItem _miRtf;
        private System.Windows.Forms.MenuItem _miZoom600;
        private System.Windows.Forms.MenuItem _miZoom400;
        private System.Windows.Forms.MenuItem _miZoom200;
        private System.Windows.Forms.MenuItem _miZoom150;
        private System.Windows.Forms.MenuItem _miZoom100;
        private System.Windows.Forms.MenuItem _miZoom50;
        private System.Windows.Forms.MenuItem _miZoom25;
        private System.Windows.Forms.MenuItem _miZoom10;
        private System.Windows.Forms.MenuItem _miBestFit;
        private System.Windows.Forms.MenuItem _miFullPage;
        private System.Windows.Forms.MenuItem _miBmp;
        private System.Windows.Forms.StatusBar _statusBar;
        private System.Windows.Forms.MenuItem _miFirst;
        private System.Windows.Forms.MenuItem _miLast;
        private System.Windows.Forms.MenuItem _menuItem1;
        private System.Windows.Forms.MenuItem _menuItem2;
        private System.Windows.Forms.MenuItem _miPreview;
        private System.Windows.Forms.MenuItem _miPrinterSetup;
        private System.Windows.Forms.MenuItem _miDemonstrate;
        private System.Windows.Forms.MenuItem _miSample1;
        private System.Windows.Forms.MenuItem _miSample2;
        private System.Windows.Forms.MenuItem _miMetaFile;
        private System.Windows.Forms.MenuItem _miOriginalSize;
    }
}
