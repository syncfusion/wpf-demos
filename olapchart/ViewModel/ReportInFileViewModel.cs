#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using Microsoft.Win32;
    using System.Collections.ObjectModel;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using SampleUtils;
    using Syncfusion.Olap.Reports;
    using System;
    using System.Windows;
    using System.ComponentModel;

    public class ReportInFileViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;

        private OlapDataManager olapDataManager;
        private ObservableCollection<string> reportNameCollecton;
        private string selectedReportName;
        private string reportPath;
        private DelegateCommand<object> browseCommand;
        private DelegateCommand<object> keyCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportInFileViewModel"/> class.
        /// </summary>
        public ReportInFileViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            this.olapDataManager = new OlapDataManager(ConnectionString);
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                this.olapDataManager.LoadReportDefinitionFile(System.IO.Path.GetFullPath(@"..\..\common\Assets\Common\Data\CubeModelTemplates\ReportDefenitionFile.xml"));
            }
            else
            {
                this.olapDataManager.LoadReportDefinitionFile(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Common\Data\CubeModelTemplates\ReportDefenitionFile.xml"));
            }
            this.olapDataManager.LoadReport(this.olapDataManager.Reports[0].Name);
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the OlapChart data manager.
        /// </summary>
        /// <value>The OlapChart data manager.</value>
        public OlapDataManager DataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }


        /// <summary>
        /// Gets the available report names.
        /// </summary>
        /// <value>The available report names.</value>
        public ObservableCollection<string> AvailableReportNames
        {
            get
            {
                if (this.reportNameCollecton == null)
                {
                    this.reportNameCollecton = new ObservableCollection<string>();
                    foreach (OlapReport item in this.DataManager.Reports)
                    {
                        this.reportNameCollecton.Add(item.Name);
                    }
                }
                return this.reportNameCollecton;
            }
            set
            {
                this.reportNameCollecton = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("AvailableReportNames"));
            }
        }


        /// <summary>
        /// Gets or sets the selected report.
        /// </summary>
        /// <value>The selected report.</value>
        public string SelectedReport
        {
            get { return this.selectedReportName; }
            set
            {
                this.selectedReportName = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedReport"));
                if (!string.IsNullOrEmpty(this.selectedReportName))
                {
                    this.DataManager.LoadReport(this.selectedReportName);
                }
            }
        }


        /// <summary>
        /// Gets or sets the browse command.
        /// </summary>
        /// <value>The browse command.</value>
        public DelegateCommand<object> BrowseCommand
        {
            get
            {
                this.browseCommand = this.browseCommand = new DelegateCommand<object>(this.BrowseReport);
                return this.browseCommand;
            }
            set { this.browseCommand = value; }
        }
        /// <summary>
        /// Gets or sets the Key command.
        /// </summary>
        /// <value>The Key command.</value>
        public DelegateCommand<object> KeyCommand
        {
            get
            {
                this.keyCommand = this.keyCommand = new DelegateCommand<object>(this.ManualReport);
                return this.keyCommand;
            }
            set { this.keyCommand = value; }
        }



        /// <summary>
        /// Gets or sets the report path.
        /// </summary>
        /// <value>The report path.</value>
        public string ReportPath
        {
            get { return this.reportPath; }
            set
            {
                this.reportPath = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("ReportPath"));
            }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }

        /// <summary>
        /// Browses the report.
        /// </summary>
        /// <param name="parm">The parm.</param>
        private void BrowseReport(object parm)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.AddExtension = true;
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                openFileDialog.InitialDirectory = System.IO.Path.GetFullPath(@"..\..\common\Assets\Common\Data\CubeModelTemplates");
            }
            else
            {
                openFileDialog.InitialDirectory = System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Common\Data\CubeModelTemplates");
            }
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "Report Set (.xml)|*.xml";
            openFileDialog.RestoreDirectory = true;
            bool? openFileDialogResult = openFileDialog.ShowDialog();
            if (openFileDialogResult.HasValue && openFileDialogResult.Value)
            {
                this.ReportPath = openFileDialog.FileName;
                this.DataManager.LoadReportDefinitionFile(this.ReportPath);
                ObservableCollection<string> newList = new ObservableCollection<string>();
                foreach (OlapReport item in this.DataManager.Reports)
                {
                    newList.Add(item.Name);
                }
                this.AvailableReportNames = newList;
                this.SelectedReport = this.DataManager.Reports[0].Name;
            }
            else
                MessageBox.Show("Report is not in an appropriate format");
        }
        private void ManualReport(object parm)
        {
            try
            {
                this.DataManager.LoadReportDefinitionFile(this.ReportPath);
                ObservableCollection<string> newList = new ObservableCollection<string>();
                int i = 1;
                foreach (OlapReport item in this.DataManager.Reports)
                {
                    if (string.IsNullOrEmpty(item.Name))
                    {
                        item.Name = "Report" + i;
                        i++;
                    }
                    newList.Add(item.Name);
                }
                this.AvailableReportNames = newList;
                this.SelectedReport = this.DataManager.Reports[0].Name;
            }
            catch (Exception)
            {
                MessageBox.Show("Report is not in an appropriate format");
            }
        }

        #endregion
    }
}
