#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SalesOfProductsAnalysis.ViewModel
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
            olapDataManager = new OlapDataManager(ViewModel.ConnectionString);
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

            olapReport.Name = "BarChartReport";
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionRow = new DimensionElement();
            dimensionRow.Name = "Product";
            dimensionRow.AddLevel("Subcategory", "Subcategory");

            MeasureElements meansureElements = new MeasureElements();
            meansureElements.Elements.Add(new MeasureElement() { Name = "Internet Sales Amount" });

            DimensionElement dimensionColumn = new DimensionElement();
            dimensionColumn.Name = "Date";
            dimensionColumn.AddLevel("Fiscal", "Fiscal Year");
            dimensionColumn.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionColumn.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2004");

            DimensionElement excludedDimensions = new DimensionElement();
            excludedDimensions.Name = "Product";
            excludedDimensions.AddLevel("Subcategory", "Subcategory");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].IncludeAvailableMembers = true;
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Helmets");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Vests");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Jerseys");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Mountain Bikes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Mountain Frames");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Road Bikes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Tires and Tubes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Touring Bikes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Shorts");

            olapReport.CategoricalElements.Add(meansureElements);
            olapReport.CategoricalElements.Add(dimensionColumn);
            olapReport.SeriesElements.Add(dimensionRow, excludedDimensions);

            return olapReport;
        }

        #endregion
    }
}
