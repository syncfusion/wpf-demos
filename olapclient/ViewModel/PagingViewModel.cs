#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    public class PagingViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingViewModel"/> class.
        /// </summary>
        public PagingViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = PagingModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = PagingModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            this.olapDataManager = new OlapDataManager(ConnectionString);
            this.olapDataManager.SetCurrentReport(CreateOlapReport());
            this.olapDataManager.CurrentReport.PagerOptions.SeriesPageSize = 10;
            this.olapDataManager.CurrentReport.PagerOptions.CategoricalPageSize = 10;
        }

        #endregion

        #region Properties

        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
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

        private OlapReport CreateOlapReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";
            olapReport.Name = "Sales Report";
            olapReport.EnablePaging = true;

            DimensionElement dimensionElement = new DimensionElement() { Name = "Customer" };
            dimensionElement.AddLevel("Customer Geography", "Country");
            olapReport.SeriesElements.Add(dimensionElement);

            dimensionElement = new DimensionElement() { Name = "Geography", HierarchyName = "Geography" };
            dimensionElement.AddLevel("Geography", "Country");
            olapReport.SeriesElements.Add(dimensionElement);


            dimensionElement = new DimensionElement() { Name = "Date" };
            dimensionElement.AddLevel("Fiscal", "Fiscal Year");
            olapReport.CategoricalElements.Add(dimensionElement);

            return olapReport;
        }

        #endregion
    }
}
