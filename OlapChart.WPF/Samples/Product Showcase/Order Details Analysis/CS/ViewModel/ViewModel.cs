#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace OrderDetailsAnalysis.ViewModel
{
    using System;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;

    class ViewModel : NotificationObject, IDisposable
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

            olapReport.Name = "ColumnChart";
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionColumn = new DimensionElement();
            dimensionColumn.Name = "Product";
            dimensionColumn.AddLevel("Product Categories", "Category");

            MeasureElements meansureElements = new MeasureElements();
            meansureElements.Elements.Add(new MeasureElement() { Name = "Reseller Order Quantity" });

            DimensionElement dimensionRow = new DimensionElement();
            dimensionRow.Name = "Date";
            dimensionRow.AddLevel("Fiscal", "Fiscal Year");

            olapReport.CategoricalElements.Add(dimensionColumn);
            olapReport.CategoricalElements.Add(meansureElements);
            olapReport.SeriesElements.Add(dimensionRow);

            return olapReport;
        }

        #endregion
    }
}