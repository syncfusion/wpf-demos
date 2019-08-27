#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace ConditionalFormatting.ViewModel
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class ViewModel : NotificationObject, IDisposable
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
            get { return olapDataManager; }
            set { olapDataManager = value; }
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
            if (disposing && olapDataManager != null)
                olapDataManager.Dispose();
        }

        /// <summary>
        /// Report on Product Internet Sales Amount over Country and Year.
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
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.ShowExpanders = false;
            olapReport.SeriesElements.Add(dimensionElementRow1);
            olapReport.SeriesElements.Add(dimensionElementRow2);

            return olapReport;
        }      

        #endregion
    }
}