#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace syncfusion.olapchartdemos.wpf
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    public class PagingViewModel : NotificationObject, IDisposable
    {
        #region Field

        /// <summary>
        /// Specifies the connection string.
        /// </summary>
        public static string ConnectionString;
        private bool enablePaging = true;
        private OlapDataManager dataManager;

        #endregion

        #region Constructor

        public PagingViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            if (ConnectionString != string.Empty)
            {
                dataManager = new OlapDataManager(ConnectionString);
                SetOlapDataManager();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the OlapDataManager.
        /// </summary>
        /// <value>The OlapDataManager.</value>
        public OlapDataManager DataManager
        {
            get
            {
                return dataManager;
            }
            set
            {
                dataManager = value;
            }
        }

        public bool EnablePaging
        {
            get { return enablePaging; }
            set
            {
                enablePaging = value;
                RaisePropertyChanged(() => EnablePaging);
                SetOlapDataManager();
            }
        }

        #endregion

        #region Helper Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && dataManager != null)
                dataManager.Dispose();
        }

        private void SetOlapDataManager()
        {
            DataManager.SetCurrentReport(SimpleDimensions());
            DataManager.CurrentReport.PagerOptions.SeriesPageSize = 10;
            DataManager.CurrentReport.PagerOptions.CategoricalPageSize = 10;
            DataManager.ExecuteCellSet();
        }

        private OlapReport SimpleDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.EnablePaging = EnablePaging;
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";
            DimensionElement dimensionElement = new DimensionElement() { Name = "Customer", HierarchyName = "Customer" };
            dimensionElement.AddLevel("Customer Geography", "Country");
            olapReport.CategoricalElements.Add(dimensionElement);

            MeasureElements measureElements = new MeasureElements();
            measureElements.Add(new MeasureElement { Name = "Internet Sales Amount" });
            olapReport.SeriesElements.Add(measureElements);

            dimensionElement = new DimensionElement() { Name = "Geography", HierarchyName = "Geography" };
            dimensionElement.AddLevel("Geography", "Country");
            olapReport.CategoricalElements.Add(dimensionElement);

            dimensionElement = new DimensionElement() { Name = "Date" };
            dimensionElement.AddLevel("Fiscal", "Fiscal Year");
            olapReport.SeriesElements.Add(dimensionElement);
            olapReport.ChartSettings = DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }

        #endregion
    }
}
