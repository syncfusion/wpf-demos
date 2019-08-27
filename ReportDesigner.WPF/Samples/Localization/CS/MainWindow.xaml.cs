#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.IO;
using System.Reflection;

namespace Report_Designer_Utility_2008
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private string titlePrefix = "Syncfusion wesentlich Reportage Konstrukteur";

        public MainWindow()
        {
            //SkinStorage.SetEnableOptimization(this, true);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
            InitializeComponent();
            SkinStorage.SetVisualStyle(this, "Office2013");
        }

        private void RibbonMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
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

        void ReportDesignerControl_AllReportsClosed(object sender, AllReportsClosedEventArgs e)
        {
            this.Close();
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void ReportDesignerControl_ReportOpened(object sender, ReportChangedEventArgs e)
        {
            this.Title = e.ReportName.Replace(".rdl", "") + " - " + titlePrefix;
        }

        private void ReportDesignerControl_ReportSaved(object sender, ReportChangedEventArgs e)
        {
            this.Title = e.ReportName.Replace(".rdl", "") + " - " + titlePrefix;
        }

        private void ReportDesignerControl_NewReportOpened(object sender, ReportChangedEventArgs e)
        {
            this.Title = e.ReportName.Replace(".rdl", "") + " - " + titlePrefix;
        }
    }
}
