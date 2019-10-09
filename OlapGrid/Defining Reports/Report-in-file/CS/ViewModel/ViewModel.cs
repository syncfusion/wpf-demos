#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace ReportInFile.ViewModel
{
    using Syncfusion.Olap.Manager;
    using SampleUtils;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;
    using Microsoft.Win32;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class ViewModel :INotifyPropertyChanged, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private ObservableCollection<string> reportNameCollecton;
        private string selectedReportName;
        private DelegateCommand<object> browseCommand;
        private DelegateCommand<object> keyDownCommand;
        private string reportPath;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.olapDataManager = new OlapDataManager(ConnectionString);
            this.olapDataManager.LoadReportDefinitionFile(SampleSourceHelper.GetSamplePath() + @"\Common\Data\CubeModelTemplates\ReportDefenitionFile.xml");
            this.olapDataManager.LoadReport(this.olapDataManager.Reports[0].Name);
        }

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager GridDataManager
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
                    foreach (OlapReport item in this.GridDataManager.Reports)
                    {
                        this.reportNameCollecton.Add(item.Name);
                    }
                }
                return this.reportNameCollecton;
            }
            set
            {
                this.reportNameCollecton = value;
                if (null != this.PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("AvailableReportNames"));
                }
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
                if (null != this.PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedReport"));
                }
                
                if (!string.IsNullOrEmpty(this.selectedReportName))
                {
                    this.GridDataManager.LoadReport(this.selectedReportName);
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
        public DelegateCommand<object> KeyDownCommand
        {
            get
            {
                this.keyDownCommand = this.keyDownCommand = new DelegateCommand<object>(this.ManualReportLoad);
                return this.keyDownCommand;
            }
            set { this.keyDownCommand = value; }
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
                if (null != this.PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ReportPath"));
                }
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
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }

        /// <summary>
        /// Browses the report.
        /// </summary>
        /// <param name="parm">The parm.</param>
        private void ManualReportLoad(object parm)
        {
            try
            {
                this.GridDataManager.LoadReportDefinitionFile(this.ReportPath);
                ObservableCollection<string> newList = new ObservableCollection<string>();
                int i = 1;
                foreach (OlapReport item in this.GridDataManager.Reports)
                {
                    if (string.IsNullOrEmpty(item.Name))
                    {
                        item.Name = "Report" + i;
                        i++;
                    }
                    newList.Add(item.Name);
                  
                }
               
                this.AvailableReportNames = newList;
                this.SelectedReport = this.GridDataManager.Reports[0].Name;
            }
            catch (Exception )
            {
                MessageBox.Show("Report is not in an appropriate format");
            }
        }

        private void BrowseReport(object parm)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "Report Set (.xml)|*.xml";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    this.ReportPath = openFileDialog.FileName;
                    this.GridDataManager.LoadReportDefinitionFile(this.ReportPath);
                    ObservableCollection<string> newList = new ObservableCollection<string>();
                    int i = 1;
                    foreach (OlapReport item in this.GridDataManager.Reports)
                    {

                        if (string.IsNullOrEmpty(item.Name))
                        {
                            item.Name = "Report" + i;
                            i++;
                        }
                        newList.Add(item.Name);
                    }
                    this.AvailableReportNames = newList;
                    this.SelectedReport = this.GridDataManager.Reports[0].Name;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Report is not in an appropriate format");
            }
        }
        #endregion
    }
}