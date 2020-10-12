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
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;

    class CustomerGrowthAnalysisViewModel : NotificationObject, IDisposable
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
        /// Initializes a new instance of the <see cref="CustomerGrowthAnalysisViewModel"/> class.
        /// </summary>
        public CustomerGrowthAnalysisViewModel()
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
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the dimension Element name
            dimensionElementColumn.Name = "Customer";
            // Adding level Element along with Hierarchy Element
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            DimensionElement dimensionElementColumnMonth = new DimensionElement();
            // Specifying the dimension Element name
            dimensionElementColumnMonth.Name = "Date";
            // Adding level Element along with Hierarchy Element
            dimensionElementColumnMonth.AddLevel("Month of Year", "Month of Year");

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the measure elements
            measureElementColumn.Elements.Add(new MeasureElement { UniqueName = "[Measures].[Growth in Customer Base]" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the dimension Element name
            dimensionElementRow.Name = "Date";
            // Adding level Element along with Hierarchy Element
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");
            dimensionElementRow.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionElementRow.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2004");

            // Adding the Column Elements
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding the Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding the month column
            olapReport.CategoricalElements.Add(dimensionElementRow);
            // Adding the Row Elements
            olapReport.SeriesElements.Add(dimensionElementColumnMonth);
            return olapReport;
        }

        #endregion
    }
}
