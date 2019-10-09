#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Reports.Designer;
using Syncfusion.Windows.Shared;

namespace Report_Designer_Customization_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ReportEditer : RibbonWindow
    {

        public bool ShowRibbon
        {
            get;
            set;
        }

        public bool ShowReportData
        {
            get;
            set;
        }

        public bool ShowRuler
        {
            get;
            set;
        }

        public bool ShowProperties
        {
            get;
            set;
        }

        public string ReportPath
        {
            get;
            set;
        }

        private string titlePrefix = "Syncfusion Essential Report Designer";

        public ReportEditer()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            this.Loaded += new RoutedEventHandler(ReportEditer_Loaded);
        }

        void ReportEditer_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReportDesignerControl.EnableMDIDesigner = false;
            this.ReportDesignerControl.AllReportsClosed += new AllReportsClosedEventHandler(ReportDesignerControl_AllReportsClosed);
            this.ReportDesignerControl.ShowReportData = this.ShowReportData;
            this.ReportDesignerControl.ShowRibbon = this.ShowRibbon;

            this.ReportDesignerControl.ShowProperties = this.ShowProperties;
            this.ReportDesignerControl.ShowRuler = this.ShowRuler;
            this.ReportDesignerControl.ShowApplicationMenu = false;
            this.ReportDesignerControl.OpenReport(this.ReportPath);
            this.Closed += new EventHandler(ReportEditer_Closed);

            WindowTitleBarButton HelpButton = null;
            Syncfusion.Windows.Tools.Controls.TitleBar _titlebar = VisualUtils.FindDescendant(this as RibbonWindow, typeof(Syncfusion.Windows.Tools.Controls.TitleBar)) as Syncfusion.Windows.Tools.Controls.TitleBar;
            if (_titlebar != null)
                HelpButton = _titlebar.Template.FindName("HelpButton", _titlebar) as WindowTitleBarButton;

            if (HelpButton != null)
                HelpButton.Click += new RoutedEventHandler(HelpButton_Click);

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://help.syncfusion.com/wpf/reportdesigner/getting-started");
        }

        void ReportEditer_Closed(object sender, EventArgs e)
        {
        }

        public ReportEditer(string reportPath, bool showRibbon,bool showReportData,bool showRuler,bool showProperties)
        {

            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            SkinStorage.SetVisualStyle(this, "Office2013");

            this.Loaded += new RoutedEventHandler(ReportEditer_Loaded);
            this.ReportPath = reportPath;
            this.ShowRibbon = showRibbon;
            this.ShowProperties = showProperties;
            this.ShowRuler = showRuler;
            this.ShowReportData = showReportData;
        }

        void ReportDesignerControl_AllReportsClosed(object sender, AllReportsClosedEventArgs e)
        {
            this.Close();
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool cannotClose = this.ReportDesignerControl.PreCloseApplication();

            if (cannotClose == false)
            {
                e.Cancel = true;
            }
        }

        private void ReportDesignerControl_ReportOpened(object sender, ReportChangedEventArgs e)
        {
            this.Title = e.ReportName.Replace(".rdl", "") + " - " + titlePrefix;
        }

        private void ReportDesignerControl_ReportSaved(object sender, ReportChangedEventArgs e)
        {
            this.Title = e.ReportName.Replace(".rdl", "") + " - " + titlePrefix;
            this.DialogResult = true;
        }

        private void ReportDesignerControl_NewReportOpened(object sender, ReportChangedEventArgs e)
        {
            this.Title = e.ReportName.Replace(".rdl", "") + " - " + titlePrefix;
        }
    }
}
