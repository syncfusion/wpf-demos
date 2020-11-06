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

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class CellTemplateViewModel : NotificationObject, IDisposable
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
        /// Initializes a new instance of the <see cref="CellTemplateViewModel"/> class.
        /// </summary>
        public CellTemplateViewModel()
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
            olapDataManager.SetCurrentReport(ProductSalesReport());
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager GridDataManager
        {
            get
            {
                if (olapDataManager == null)
                {
                    olapDataManager = new OlapDataManager(ConnectionString);
                    olapDataManager.SetCurrentReport(ProductSalesReport());
                }
                return olapDataManager;
            }
            set { olapDataManager = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// IDisposal method
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && olapDataManager != null)
                olapDataManager.Dispose();
        }

        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>
        private OlapReport ProductSalesReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the name for Dimension Element for Column
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");
            //// Slicing Dimension
            //Specifying Excluded column elements
            DimensionElement excludedColumnElement = new DimensionElement();
            excludedColumnElement.Name = "Customer";
            excludedColumnElement.HierarchyName = "Customer Geography";
            excludedColumnElement.AddLevel("Customer Geography", "Country");
            excludedColumnElement.Hierarchy.LevelElements["Country"].Add("Australia");

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the name for Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow1 = new DimensionElement();
            // Specifying the name for Dimension Element for Row
            dimensionElementRow1.Name = "Product";
            dimensionElementRow1.AddLevel("Product Categories", "Category");

            DimensionElement dimensionElementRow2 = new DimensionElement();
            dimensionElementRow2.Name = "Date";
            dimensionElementRow2.AddLevel("Fiscal", "Fiscal Year");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn, excludedColumnElement);
            // Adding Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            // olapReport.ShowExpanders = false;
            olapReport.SeriesElements.Add(dimensionElementRow1);
            olapReport.SeriesElements.Add(dimensionElementRow2);

            return olapReport;
        }
        #endregion
    }
}
