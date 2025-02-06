using System.Windows.Forms;

namespace GraphicsPreview
{
    partial class PreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.tbbSeparator1 = new System.Windows.Forms.ToolBarButton();
            this.tbbFirstPage = new System.Windows.Forms.ToolBarButton();
            this.tbbPrevPage = new System.Windows.Forms.ToolBarButton();
            this.tbbNextPage = new System.Windows.Forms.ToolBarButton();
            this.tbbLastPage = new System.Windows.Forms.ToolBarButton();
            this.tbbSeparator2 = new System.Windows.Forms.ToolBarButton();
            this.tbbOriginalSize = new System.Windows.Forms.ToolBarButton();
            this.menuZoom = new System.Windows.Forms.ContextMenu();
            this.miPercent800 = new System.Windows.Forms.MenuItem();
            this.miPercent600 = new System.Windows.Forms.MenuItem();
            this.miPercent400 = new System.Windows.Forms.MenuItem();
            this.miPercent200 = new System.Windows.Forms.MenuItem();
            this.miPercent150 = new System.Windows.Forms.MenuItem();
            this.miPercent100 = new System.Windows.Forms.MenuItem();
            this.miPercent75 = new System.Windows.Forms.MenuItem();
            this.miPercent50 = new System.Windows.Forms.MenuItem();
            this.miPercent25 = new System.Windows.Forms.MenuItem();
            this.miPercent10 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.miBestFit = new System.Windows.Forms.MenuItem();
            this.miFullPage = new System.Windows.Forms.MenuItem();
            this.tbbFullPage = new System.Windows.Forms.ToolBarButton();
            this.tbbBestFit = new System.Windows.Forms.ToolBarButton();
            this.tbbSmaller = new System.Windows.Forms.ToolBarButton();
            this.tbbLarger = new System.Windows.Forms.ToolBarButton();
            this.tbbSeparator3 = new System.Windows.Forms.ToolBarButton();
            this.tbbPrint = new System.Windows.Forms.ToolBarButton();
            this.tbbMakePdf = new System.Windows.Forms.ToolBarButton();
            this.ilToolbar = new System.Windows.Forms.ImageList(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.pagePreview = new PdfSharp.Forms.PagePreview();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbSeparator1,
            this.tbbFirstPage,
            this.tbbPrevPage,
            this.tbbNextPage,
            this.tbbLastPage,
            this.tbbSeparator2,
            this.tbbOriginalSize,
            this.tbbFullPage,
            this.tbbBestFit,
            this.tbbSmaller,
            this.tbbLarger,
            this.tbbSeparator3,
            this.tbbPrint,
            this.tbbMakePdf});
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.ilToolbar;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(638, 50);
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBarButtonClick);
            // 
            // tbbSeparator1
            // 
            this.tbbSeparator1.Name = "tbbSeparator1";
            this.tbbSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.tbbSeparator1.Visible = false;
            // 
            // tbbFirstPage
            // 
            this.tbbFirstPage.ImageIndex = 0;
            this.tbbFirstPage.Name = "tbbFirstPage";
            this.tbbFirstPage.Tag = "FirstPage";
            this.tbbFirstPage.Visible = false;
            // 
            // tbbPrevPage
            // 
            this.tbbPrevPage.Enabled = false;
            this.tbbPrevPage.ImageIndex = 1;
            this.tbbPrevPage.Name = "tbbPrevPage";
            this.tbbPrevPage.Tag = "PrevPage";
            this.tbbPrevPage.Visible = false;
            // 
            // tbbNextPage
            // 
            this.tbbNextPage.Enabled = false;
            this.tbbNextPage.ImageIndex = 2;
            this.tbbNextPage.Name = "tbbNextPage";
            this.tbbNextPage.Tag = "NextPage";
            this.tbbNextPage.Visible = false;
            // 
            // tbbLastPage
            // 
            this.tbbLastPage.Enabled = false;
            this.tbbLastPage.ImageIndex = 3;
            this.tbbLastPage.Name = "tbbLastPage";
            this.tbbLastPage.Tag = "LastPage";
            this.tbbLastPage.Visible = false;
            // 
            // tbbSeparator2
            // 
            this.tbbSeparator2.Name = "tbbSeparator2";
            this.tbbSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.tbbSeparator2.Visible = false;
            // 
            // tbbOriginalSize
            // 
            this.tbbOriginalSize.DropDownMenu = this.menuZoom;
            this.tbbOriginalSize.ImageIndex = 4;
            this.tbbOriginalSize.Name = "tbbOriginalSize";
            this.tbbOriginalSize.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbbOriginalSize.Tag = "OriginalSize";
            this.tbbOriginalSize.Text = "Original Size";
            // 
            // menuZoom
            // 
            this.menuZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPercent800,
            this.miPercent600,
            this.miPercent400,
            this.miPercent200,
            this.miPercent150,
            this.miPercent100,
            this.miPercent75,
            this.miPercent50,
            this.miPercent25,
            this.miPercent10,
            this.menuItem10,
            this.miBestFit,
            this.miFullPage});
            // 
            // miPercent800
            // 
            this.miPercent800.Index = 0;
            this.miPercent800.Text = "800%";
            this.miPercent800.Click += new System.EventHandler(this.MiPercent800Click);
            // 
            // miPercent600
            // 
            this.miPercent600.Index = 1;
            this.miPercent600.Text = "600%";
            this.miPercent600.Click += new System.EventHandler(this.MiPercent600Click);
            // 
            // miPercent400
            // 
            this.miPercent400.Index = 2;
            this.miPercent400.Text = "400%";
            this.miPercent400.Click += new System.EventHandler(this.MiPercent400Click);
            // 
            // miPercent200
            // 
            this.miPercent200.Index = 3;
            this.miPercent200.Text = "200%";
            this.miPercent200.Click += new System.EventHandler(this.MiPercent200Click);
            // 
            // miPercent150
            // 
            this.miPercent150.Index = 4;
            this.miPercent150.Text = "150%";
            this.miPercent150.Click += new System.EventHandler(this.MiPercent150Click);
            // 
            // miPercent100
            // 
            this.miPercent100.Index = 5;
            this.miPercent100.Text = "100%";
            this.miPercent100.Click += new System.EventHandler(this.MiPercent100Click);
            // 
            // miPercent75
            // 
            this.miPercent75.Index = 6;
            this.miPercent75.Text = "75%";
            this.miPercent75.Click += new System.EventHandler(this.MiPercent75Click);
            // 
            // miPercent50
            // 
            this.miPercent50.Index = 7;
            this.miPercent50.Text = "50%";
            this.miPercent50.Click += new System.EventHandler(this.MiPercent50Click);
            // 
            // miPercent25
            // 
            this.miPercent25.Index = 8;
            this.miPercent25.Text = "25%";
            this.miPercent25.Click += new System.EventHandler(this.MiPercent25Click);
            // 
            // miPercent10
            // 
            this.miPercent10.Index = 9;
            this.miPercent10.Text = "10%";
            this.miPercent10.Click += new System.EventHandler(this.MiPercent10Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 10;
            this.menuItem10.Text = "-";
            // 
            // miBestFit
            // 
            this.miBestFit.Index = 11;
            this.miBestFit.Text = "Best fit";
            this.miBestFit.Click += new System.EventHandler(this.MiBestFitClick);
            // 
            // miFullPage
            // 
            this.miFullPage.Index = 12;
            this.miFullPage.Text = "Full Page";
            this.miFullPage.Click += new System.EventHandler(this.MiFullPageClick);
            // 
            // tbbFullPage
            // 
            this.tbbFullPage.ImageIndex = 5;
            this.tbbFullPage.Name = "tbbFullPage";
            this.tbbFullPage.Tag = "FullPage";
            this.tbbFullPage.Text = "Full Page";
            // 
            // tbbBestFit
            // 
            this.tbbBestFit.ImageIndex = 6;
            this.tbbBestFit.Name = "tbbBestFit";
            this.tbbBestFit.Tag = "BestFit";
            this.tbbBestFit.Text = "Best Fit";
            // 
            // tbbSmaller
            // 
            this.tbbSmaller.ImageIndex = 7;
            this.tbbSmaller.Name = "tbbSmaller";
            this.tbbSmaller.Tag = "Smaller";
            this.tbbSmaller.Text = "Smaller";
            // 
            // tbbLarger
            // 
            this.tbbLarger.ImageIndex = 8;
            this.tbbLarger.Name = "tbbLarger";
            this.tbbLarger.Tag = "Larger";
            this.tbbLarger.Text = "Larger";
            // 
            // tbbSeparator3
            // 
            this.tbbSeparator3.Name = "tbbSeparator3";
            this.tbbSeparator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbPrint
            // 
            this.tbbPrint.ImageIndex = 10;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Tag = "Print";
            this.tbbPrint.Text = "Print";
            // 
            // tbbMakePdf
            // 
            this.tbbMakePdf.ImageIndex = 9;
            this.tbbMakePdf.Name = "tbbMakePdf";
            this.tbbMakePdf.Tag = "MakePdf";
            this.tbbMakePdf.Text = "Create PDF";
            // 
            // ilToolbar
            // 
            this.ilToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbar.ImageStream")));
            this.ilToolbar.TransparentColor = System.Drawing.Color.Lime;
            this.ilToolbar.Images.SetKeyName(0, "");
            this.ilToolbar.Images.SetKeyName(1, "");
            this.ilToolbar.Images.SetKeyName(2, "");
            this.ilToolbar.Images.SetKeyName(3, "");
            this.ilToolbar.Images.SetKeyName(4, "");
            this.ilToolbar.Images.SetKeyName(5, "");
            this.ilToolbar.Images.SetKeyName(6, "");
            this.ilToolbar.Images.SetKeyName(7, "");
            this.ilToolbar.Images.SetKeyName(8, "");
            this.ilToolbar.Images.SetKeyName(9, "");
            this.ilToolbar.Images.SetKeyName(10, "");
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 624);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(638, 22);
            this.statusBar.TabIndex = 2;
            // 
            // pagePreview
            // 
            this.pagePreview.BackColor = System.Drawing.SystemColors.Control;
            this.pagePreview.DesktopColor = System.Drawing.SystemColors.ControlDark;
            this.pagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePreview.Location = new System.Drawing.Point(0, 50);
            this.pagePreview.Name = "pagePreview";
            this.pagePreview.PageColor = System.Drawing.Color.GhostWhite;
            this.pagePreview.PageGraphicsUnit = PdfSharp.Drawing.XGraphicsUnit.Point;
            this.pagePreview.PageSize = ((PdfSharp.Drawing.XSize)(resources.GetObject("pagePreview.PageSize")));
            this.pagePreview.PageSizeF = new System.Drawing.Size(595, 842);
            this.pagePreview.PageGraphicsUnit = PdfSharp.Drawing.XGraphicsUnit.Point;
            this.pagePreview.Size = new System.Drawing.Size(638, 574);
            this.pagePreview.TabIndex = 4;
            this.pagePreview.Zoom = PdfSharp.Forms.Zoom.BestFit;
            this.pagePreview.ZoomPercent = 77;
            // 
            // PreviewForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(638, 646);
            this.Controls.Add(this.pagePreview);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBar);
            this.Name = "PreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphics Preview Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.ToolBarButton tbbFirstPage;
        private System.Windows.Forms.ToolBarButton tbbSeparator1;
        private System.Windows.Forms.ImageList ilToolbar;
        private System.Windows.Forms.ToolBarButton tbbPrevPage;
        private System.Windows.Forms.ToolBarButton tbbNextPage;
        private System.Windows.Forms.ToolBarButton tbbLastPage;
        private System.Windows.Forms.ToolBarButton tbbSeparator2;
        private System.Windows.Forms.ToolBarButton tbbOriginalSize;
        private System.Windows.Forms.ToolBarButton tbbFullPage;
        private System.Windows.Forms.ToolBarButton tbbBestFit;
        private System.Windows.Forms.ToolBarButton tbbSmaller;
        private System.Windows.Forms.ToolBarButton tbbLarger;
        private System.Windows.Forms.ToolBarButton tbbSeparator3;
        private System.Windows.Forms.ToolBarButton tbbMakePdf;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem miPercent800;
        private System.Windows.Forms.MenuItem miPercent600;
        private System.Windows.Forms.MenuItem miPercent400;
        private System.Windows.Forms.MenuItem miPercent200;
        private System.Windows.Forms.MenuItem miPercent150;
        private System.Windows.Forms.MenuItem miPercent75;
        private System.Windows.Forms.MenuItem miPercent50;
        private System.Windows.Forms.MenuItem miPercent25;
        private System.Windows.Forms.MenuItem miPercent10;
        private System.Windows.Forms.MenuItem miBestFit;
        private System.Windows.Forms.MenuItem miFullPage;
        private System.Windows.Forms.ContextMenu menuZoom;
        private System.Windows.Forms.MenuItem miPercent100;
        private ToolBarButton tbbPrint;
        private PdfSharp.Forms.PagePreview pagePreview;
    }
}

