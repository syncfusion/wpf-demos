#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace FiscalYearDashBoard.ViewModel
{
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using System;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class ViewModel : Syncfusion.Windows.Shared.NotificationObject, IDisposable
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
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(ProductSalesAnalysis());
        }

        #endregion

        #region Properties

        public OlapDataManager ClientDataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
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
            if (disposing && olapDataManager != null)
                olapDataManager.Dispose();
        }

        /// <summary>
        /// OlapReport the with KPI Elements
        /// </summary>
        /// <returns></returns>
        private OlapReport ProductSalesAnalysis()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the name for Dimension Element for Column
            dimensionElementColumn.Name = "Product";
            dimensionElementColumn.AddLevel("Product Categories", "Category");


            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the name for Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Gross Profit" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the Name for Row Dimension Element
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            KpiElements kpiElement = new KpiElements();
            kpiElement.Elements.Add(new KpiElement { Name = "Revenue", ShowKPIStatus = true, ShowKPIGoal = false, ShowKPITrend = true, ShowKPIValue = true });

            // Adding Column Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.CategoricalElements.Add(kpiElement);
            // Adding Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);

            //olapReport.ShowExpanders = false;

            return olapReport;
        }

        #endregion
    }
}