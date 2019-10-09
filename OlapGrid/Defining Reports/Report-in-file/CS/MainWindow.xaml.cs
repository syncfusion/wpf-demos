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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Olap.Model;
using Syncfusion.Olap.MDXQueryBuilder;
using System.IO;
using Syncfusion.Windows.Shared;
using SampleUtils;
using System.Threading;
using Microsoft.Win32;
using Syncfusion.Olap.ReportBuilder;

namespace LoadingReportFiles
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : SampleWindow
    {

        #region Fields
        OlapDataManager olapDataManager = null;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                string connectionString = GetConnectionString();
                if (connectionString != "")
                    olapDataManager = new OlapDataManager(connectionString);
                cmbReportSet.SelectionChanged += new SelectionChangedEventHandler(cmbReportSet_SelectionChanged);
                cmbReportSet.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data will not be loaded properly");
            }
        }
        #endregion

        #region Find Template file
        string FindTemplateFile(string fileName)
        {
            // Check both in parent folder and Parent\Data folders.
            string dataFileName = @"Common\Data\CubeModelTemplates\" + fileName;
            for (int n = 0; n < 12; n++)
            {
                if (System.IO.File.Exists(fileName))
                {
                    return new FileInfo(fileName).FullName;
                }
                if (System.IO.File.Exists(dataFileName))
                {
                    return new FileInfo(dataFileName).FullName;
                }
                fileName = @"..\" + fileName;
                dataFileName = @"..\" + dataFileName;
            }
            return "";
        }
        #endregion

        #region Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.ShowWaitingDialog();
            try
            {
                olapgrid1.OlapDataManager = olapDataManager;                
                string samplePath = SampleSourceHelper.GetSamplePath() + @"\Common\Data\CubeModelTemplates\ReportDefenitionFile.xml";
                this.txtReportFilePath.Text = samplePath;
                LoadReports(samplePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "File not found");
            }
            this.CloseWaitingDialog();
            cmbReportSet.SelectedIndex = 1;
        }

        private void cmbReportSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.cmbReportSet.SelectedItem != null)
                {
                    this.olapDataManager.LoadReport(this.cmbReportSet.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowser_Click(object sender, RoutedEventArgs e)
        {
            if (this.olapDataManager != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.AddExtension = true;
                openFileDialog.DefaultExt = "xml";
                openFileDialog.Filter = "Report Set (.xml)|*.xml";
                if (openFileDialog.ShowDialog() == true)
                {
                    txtReportFilePath.Text = openFileDialog.FileName;
                    string fileName = openFileDialog.FileName;
                    LoadReports(fileName);
                }
            }
        }
        private void LoadReports(string fileName)
        {
            olapDataManager.LoadReportDefinitionFile(fileName);
            this.cmbReportSet.Items.Clear();
            foreach (OlapReport olapReport in this.olapDataManager.Reports)
            {
                this.cmbReportSet.Items.Add(olapReport.Name);
            }
            if (olapDataManager.Reports.Count > 0)
            {
                this.cmbReportSet.IsEnabled = true;
                this.cmbReportSet.SelectedItem = this.olapDataManager.Reports[0].Name;
            }
            else
            {
                this.cmbReportSet.IsEnabled = false;
            }
        }
        #endregion
    }
}
