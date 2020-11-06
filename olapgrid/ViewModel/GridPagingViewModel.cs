#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace syncfusion.olapgriddemos.wpf
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    public class GridPagingViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private bool enablePaging = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GridPagingViewModel"/> class.
        /// </summary>
        public GridPagingViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            olapDataManager = new OlapDataManager(ConnectionString);
            SetOlapDataManager();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager GridDataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
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

        private void SetOlapDataManager()
        {
            this.GridDataManager.SetCurrentReport(CreateOlapReport());
            this.GridDataManager.CurrentReport.PagerOptions.SeriesPageSize = 10;
            this.GridDataManager.CurrentReport.PagerOptions.CategoricalPageSize = 10;
            this.GridDataManager.ExecuteCellSet();
        }

        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>
        private OlapReport CreateOlapReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";
            olapReport.EnablePaging = EnablePaging;
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
            return olapReport;
        }
        #endregion
    }
}
