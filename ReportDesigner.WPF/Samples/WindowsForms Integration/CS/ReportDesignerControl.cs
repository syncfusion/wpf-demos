#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Reports.Designer;
using System.Windows.Forms.Integration;
using Syncfusion.Windows.Reports.Viewer;
using Syncfusion.Windows.Reports;
using System.IO;
using Syncfusion.Windows.Reports.Designer.Wizard;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Reports.Designer.Dialogs;

namespace CustomizedReportDesignerWF
{
    public partial class ReportDesignerControl : RibbonForm
    {
        ReportDesigner reportDesigner = new ReportDesigner();
        ReportViewer reportViewer = new ReportViewer();

        public ReportDesignerControl()
        {
            InitializeComponent();
            InitializeApplicationMenuItems();
            WireNavigationEvents();
            InitializeReportDesignerPanelState();
        }

        private void InitializeApplicationMenuItems()
        {
            ToolStripDropDown dropDownMenu = new ToolStripDropDown();
            ToolStripButton newMenu = new ToolStripButton("&New");
            ToolStripButton openMenu = new ToolStripButton("&Open");
            ToolStripButton saveMenu = new ToolStripButton("&Save");
            ToolStripButton closeMenu = new ToolStripButton("&Close");
            ToolStripPanelItem dropDownPanel = new ToolStripPanelItem();
            Icon appIcon = new Icon(@"..\..\App.ico");

            newMenu.Image = new System.Drawing.Bitmap(@"../../Icons/New32.png");
            openMenu.Image = new System.Drawing.Bitmap(@"../../Icons/Open32.png");
            saveMenu.Image = new System.Drawing.Bitmap(@"../../Icons/Save32.png");
            closeMenu.Image = new System.Drawing.Bitmap(@"../../Icons/Close32.png");

            dropDownPanel.Items.Add(newMenu);
            dropDownPanel.Items.Add(openMenu);
            dropDownPanel.Items.Add(saveMenu);
            dropDownPanel.Items.Add(closeMenu);
            dropDownPanel.RowCount = 4;

            newMenu.Click += NewReport;
            openMenu.Click += OpenReport;
            saveMenu.Click += SaveReport;
            closeMenu.Click += CloseReportDesigner;

            foreach (ToolStripButton button in dropDownPanel.Items)
            {
                button.AutoSize = false;
                button.Size = new System.Drawing.Size(170, 35);
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.ImageScaling = ToolStripItemImageScaling.None;
            }

            dropDownMenu.Items.Add(dropDownPanel);
            this.reportRibbon.MenuButtonDropDown = dropDownMenu;

            this.Appearance = AppearanceType.Office2007;
            this.ColorScheme = ColorSchemeType.Blue;
            reportDesignerContainer.Child = reportDesigner;
            reportViewerContainer.Child = reportViewer;
            reportViewerContainer.Hide();

            //Assign the Element host child items.
            this.Controls.Add(reportViewerContainer);
            this.Controls.Add(reportDesignerContainer);
            this.Icon = appIcon;
            InsertTab.Checked = true;
        }

        private void InitializeReportDesignerPanelState()
        {
            reportDesigner.ShowReportData = true;
            reportDesigner.ShowRuler = true;
            reportDesigner.ShowProperties = true;
            reportDesigner.ShowRibbon = false;
            reportDesigner.ShowZoom = false;
            reportViewer.ShowToolBar = false;
        }

        private void WireNavigationEvents()
        {
            Previous.CheckedChanged += GoToPreviousUpdateStatus;
            Previous.Click += GoToPreviousPage;
            First.Click += GoToFirstPage;
            Next.Click += GoToNextPage;
            Last.Click += GoToLastPage;
            Refresh.Click += RefreshReport;
            Print.Click += PrintReport;
            PageLayout.Click += UpdatePageLayout;
        }

        public void IntializeReportViewerSettings()
        {
            if (this.PageText.Text == "1")
            {
                this.First.Enabled = false;
                this.Previous.Enabled = false;
            }
            if (this.reportViewer.GetTotalPage() == 1)
            {
                this.First.Enabled = false;
                this.Last.Enabled = false;
                this.Previous.Enabled = false;
                this.Next.Enabled = false;
            }
            this.Label2.Text = this.reportViewer.GetTotalPage().ToString();
        }

        private void UpdatePageLayout(object sender, EventArgs e)
        {
            this.reportViewer.ShowPageDialog();
        }

        private void PrintReport(object sender, EventArgs e)
        {
            this.reportViewer.PrintReport();
        }

        private void RefreshReport(object sender, EventArgs e)
        {
            this.reportViewer.Refresh();
            this.PageText.Text = "1";
            this.Last.Enabled = true;
            this.Next.Enabled = true;
            IntializeReportViewerSettings();
        }

        private void GoToLastPage(object sender, EventArgs e)
        {
            this.reportViewer.MoveLast();
            this.Last.Enabled = false;
            this.Next.Enabled = false;
            this.First.Enabled = true;
            this.Previous.Enabled = true;
            this.PageText.Text = this.reportViewer.CurrentPage.ToString();
            if (this.PageText.Text == this.reportViewer.GetTotalPage().ToString())
            {
                this.Next.Enabled = false;
                this.Last.Enabled = false;
            }
        }

        private void GoToNextPage(object sender, EventArgs e)
        {
            if (this.PageText.Text == this.reportViewer.GetTotalPage().ToString())
            {
                this.Next.Enabled = false;
                this.Last.Enabled = false;
            }
            this.First.Enabled = true;
            this.Previous.Enabled = true;
            this.reportViewer.MoveNext();
            this.PageText.Text = this.reportViewer.CurrentPage.ToString();
        }

        private void GoToFirstPage(object sender, EventArgs e)
        {
            this.First.Enabled = false;
            this.Previous.Enabled = false;
            this.Last.Enabled = true;
            this.Next.Enabled = true;
            this.reportViewer.MoveFirst();
            this.PageText.Text = "1";
        }

        private void GoToPreviousPage(object sender, EventArgs e)
        {
            if (this.reportViewer.CurrentPage == 1)
            {
                this.First.Enabled = false;
                this.Previous.Enabled = false;
            }
            this.Last.Enabled = true;
            this.Next.Enabled = true;
            this.reportViewer.MovePrevious();
            this.PageText.Text = this.reportViewer.CurrentPage.ToString();
        }

        private void GoToPreviousUpdateStatus(object sender, EventArgs e)
        {
            if (this.reportViewer.CurrentPage == 1)
            {
                this.First.Enabled = false;
                this.Previous.Enabled = false;
            }
            this.reportViewer.Refresh();
        }

        private void NewReport(object sender, EventArgs e)
        {
            reportDesigner.NewReport();
        }

        public void OpenReport(object sender, EventArgs e)
        {
            reportDesigner.OpenReportDialog();
        }

        public void SaveReport(object sender, EventArgs e)
        {
            reportDesigner.SaveReportDialog();
        }

        private void CloseReportDesigner(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowReportViewer(object sender, EventArgs e)
        {
            reportViewerContainer.Show();
            reportDesignerContainer.Hide();
            this.RunTab.Checked = true;
            this.RunTab.Visible = true;
            this.InsertTab.Visible = false;
            this.View.Visible = false;
            this.Last.Enabled = true;
            this.Next.Enabled = true;
            this.reportViewer.Reset();
            this.reportViewer.RenderingCompleted += ReportViewer_RenderingCompleted;
            this.reportViewer.LoadReport(this.reportDesigner.GetReportStream());
            this.reportViewer.RefreshReport();
        }

        void ReportViewer_RenderingCompleted(object sender, EventArgs e)
        {
            this.IntializeReportViewerSettings();
        }

        private void UpdateReportDesignerPanels(object sender, EventArgs e)
        {
            reportDesigner.ShowRuler = Ruler.Checked;
            reportDesigner.ShowProperties = Properties.Checked;
            reportDesigner.ShowGrouping = Grouping.Checked;
            reportDesigner.ShowReportData = ReportData.Checked;
        }

        private void InsertReportItem(object sender, EventArgs e)
        {
            UpdateButtonStatus();
            var button = (sender as ToolStripButton);

            if (button.Text == "List")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.List;
                button.Checked = true;
            }
            else if (button.Text == "Map")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Map;
                button.Checked = true;
            }
            else if (button.Text == "TextBox")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.TextBox;
                button.Checked = true;
            }
            else if (button.Text == "Rectangle")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Rectangle;
                button.Checked = true;
            }
            else if (button.Text == "SubReport")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.SubReport;
                button.Checked = true;
            }
            else if (button.Text == "Line")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Line;
                button.Checked = true;
            }
            else if (button.Text == "Image")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Image;
                button.Checked = true;
            }
            else if (button.Text == "SparklLine")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Sparkline;
                button.Checked = true;
            }
            else if (button.Text == "DataBar")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.DataBar;
                button.Checked = true;
            }
            else if (button.Text == "Gauge")
            {
                this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Gauge;
                button.Checked = true;
            }
        }

        private void InsertTableReportItem(object sender, EventArgs e)
        {
            UpdateButtonStatus();
            this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Tablix;
        }

        private void TableWizard(object sender, EventArgs e)
        {
            UpdateButtonStatus();
            this.reportDesigner.ShowWizard(ReportItemWizard.Table);
        }

        private void InsertChartReportItem(object sender, EventArgs e)
        {
            UpdateButtonStatus();
            this.reportDesigner.DrawingReportItem = Syncfusion.Windows.Reports.Designer.DrawingReportItem.Chart;
        }

        private void ChartWizard(object sender, EventArgs e)
        {
            UpdateButtonStatus();
            this.reportDesigner.ShowWizard(ReportItemWizard.Chart);
        }

        private void MatrixWizard(object sender, EventArgs e)
        {
            UpdateButtonStatus();
            this.reportDesigner.ShowWizard(ReportItemWizard.Table);
        }

        private void AddReportFooter(object sender, EventArgs e)
        {
            reportDesigner.ShowFooter = true;
            AddFooter.Visible = false;
            RemoveFooter1.Visible = true;
        }

        private void AddReportHeader(object sender, EventArgs e)
        {
            reportDesigner.ShowHeader = true;
            Addheader.Visible = false;
            RemoveHeader.Visible = true;
        }

        private void ViewDesign(object sender, EventArgs e)
        {
            reportDesignerContainer.Show();
            reportViewerContainer.Hide();
            this.InsertTab.Checked = true;
            this.InsertTab.Visible = true;
            this.View.Visible = true;
            this.RunTab.Visible = false;
            this.InsertTab.Visible = true;
            this.View.Visible = true;
        }

        private void RemoveReportHeader(object sender, EventArgs e)
        {
            reportDesigner.ShowHeader = false;
            Addheader.Visible = true;
            RemoveHeader.Visible = false;
        }

        private void RemoveReportFooter(object sender, EventArgs e)
        {
            reportDesigner.ShowFooter = false;
            {
                AddFooter.Visible = true;
                RemoveFooter1.Visible = false;
            }
        }

        private void UpdateButtonStatus()
        {
            SubReportButt.Checked = false;
            Gauge.Checked = false;
            Map.Checked = false;
            DataBar.Checked = false;
            Sparkline.Checked = false;
            List.Checked = false;
            TextBox.Checked = false;
            Image.Checked = false;
            Line.Checked = false;
            Rectangle.Checked = false;
        }

        private void UpdateMenuItems(object sender, EventArgs e)
        {
            UpdateButtonStatus();
        }
    }
}
