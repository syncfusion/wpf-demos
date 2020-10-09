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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;

    class CustomerRangeAnalysisViewModel : NotificationObject, IDisposable
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
        /// Initializes a new instance of the <see cref="CustomerRangeAnalysisViewModel"/> class.
        /// </summary>
        public CustomerRangeAnalysisViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(OlapReport());
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager DataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
        }

        #endregion

        #region Helper Method
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

        private OlapReport OlapReport()
        {
            OlapReport olapReport = new OlapReport();

            olapReport.Name = "StackedBarChart";
            olapReport.CurrentCubeName = "Adventure Works";

            MeasureElements meansureElements = new MeasureElements();
            meansureElements.Elements.Add(new MeasureElement() { Name = "Internet Order Quantity" });

            DimensionElement dimensionColumn = new DimensionElement();
            dimensionColumn.Name = "Date";
            dimensionColumn.AddLevel("Fiscal", "Fiscal Year");
            dimensionColumn.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionColumn.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2004");

            DimensionElement dimensionColumnProduct = new DimensionElement();
            dimensionColumnProduct.Name = "Product";
            dimensionColumnProduct.AddLevel("Product Categories", "Category");

            DimensionElement dimensionRow = new DimensionElement();
            dimensionRow.Name = "Customer";
            dimensionRow.AddLevel("Commute Distance", "Commute Distance");

            olapReport.CategoricalElements.Add(meansureElements);
            olapReport.CategoricalElements.Add(dimensionColumn);
            olapReport.CategoricalElements.Add(dimensionColumnProduct);
            olapReport.SeriesElements.Add(dimensionRow);

            return olapReport;
        }

        #endregion
    }
}
