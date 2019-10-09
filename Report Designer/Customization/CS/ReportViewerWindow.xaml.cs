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
using Syncfusion.Windows.Shared;

namespace Report_Designer_Customization_Demo
{
    /// <summary>
    /// Interaction logic for ReportViewerWindow.xaml
    /// </summary>
    public partial class ReportViewerWindow : ChromelessWindow
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

        public ReportViewerWindow()
        {
            InitializeComponent();
            SkinStorage.SetVisualStyle(this, "Metro");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowRuler = true;
            this.ShowRibbon = true;
            this.ShowReportData = true;
            this.ShowProperties = true;
            this.CheckBoxPropertiesVisibility.Click += new RoutedEventHandler(CheckBoxPropertiesVisibility_Click);
            this.CheckBoxReportDataVisibility.Click += new RoutedEventHandler(CheckBoxReportDataVisibility_Click);
            this.CheckBoxRulerVisibility.Click += new RoutedEventHandler(CheckBoxRulerVisibility_Click);
            this.CheckBoxRibbonVisibility.Click += new RoutedEventHandler(CheckBoxRibbonVisibility_Click);
            this.reportListBox.SelectedIndex = 1;
        }

        void CheckBoxRibbonVisibility_Click(object sender, RoutedEventArgs e)
        {
            this.ShowRibbon = (this.CheckBoxRibbonVisibility.IsChecked == true) ? true : false;
        }

        void CheckBoxRulerVisibility_Click(object sender, RoutedEventArgs e)
        {
            this.ShowRuler = (this.CheckBoxRulerVisibility.IsChecked == true) ? true : false;
        }

        void CheckBoxReportDataVisibility_Click(object sender, RoutedEventArgs e)
        {
            this.ShowReportData = (this.CheckBoxReportDataVisibility.IsChecked == true) ? true : false;
        }

        void CheckBoxPropertiesVisibility_Click(object sender, RoutedEventArgs e)
        {
            this.ShowProperties = (this.CheckBoxPropertiesVisibility.IsChecked == true) ? true : false;
        }

        private void reportListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int report = reportListBox.SelectedIndex;

            reportViewerControl.Reset();

            if (report == 0)
            {
                reportViewerControl.ReportPath = @"../../../../../Common/Data/ReportTemplate/AreaCharts.rdl";
            }
            else if (report == 1)
            {
                reportViewerControl.ReportPath = @"../../../../../Common/Data/ReportTemplate/BarCharts.rdl";
            }
            else if (report == 2)
            {
                reportViewerControl.ReportPath = @"../../../../../Common/Data/ReportTemplate/LineCharts.rdl";
            }
            else if (report == 3)
            {
                reportViewerControl.ReportPath = @"../../../../../Common/Data/ReportTemplate/PieCharts.rdl";
            }
            else if (report == 4)
            {
                reportViewerControl.ReportPath = @"../../../../../Common/Data/ReportTemplate/InvoiceTemplate.rdl";
            }

            reportViewerControl.RefreshReport();
        }

        private void openreport_Click(object sender, RoutedEventArgs e)
        {
            ReportEditer editor = new ReportEditer(this.reportViewerControl.ReportPath, this.ShowRibbon, this.ShowReportData, this.ShowRuler, this.ShowProperties);
            editor.Owner = this;
            editor.ShowDialog();
            string reportPath = this.reportViewerControl.ReportPath;
            this.reportViewerControl.ReportPath = String.Empty;
            this.reportViewerControl.ReportPath = reportPath;
            this.reportViewerControl.RefreshReport();
        }
    }
}
