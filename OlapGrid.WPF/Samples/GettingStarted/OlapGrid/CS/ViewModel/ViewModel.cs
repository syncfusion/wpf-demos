#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace OlapGrid.ViewModel
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class ViewModel : NotificationObject, IDisposable
    {
        #region Members

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
            olapDataManager.SetCurrentReport(Report());
        }

        #endregion

        #region Properties

        public OlapDataManager GridDataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
        }
        #endregion

        #region Sample Report

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

        private OlapReport Report()
        {
            OlapReport olapReport = new OlapReport() { Name = "GridReport" };
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement internalDimension = new DimensionElement();
            internalDimension.Name = "Product";
            internalDimension.AddLevel("Product Categories", "Category");
            internalDimension.Hierarchy.LevelElements[0].Add(new MemberElement { Name = "Bikes" });

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Sales Amount" });
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Order Quantity" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            DimensionElement dimensionElementSlicer = new DimensionElement();
            dimensionElementSlicer.Name = "Sales Channel";
            dimensionElementSlicer.AddLevel("Sales Channel", "Sales Channel");

            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);

            //Adding Slicer Elements
            olapReport.SlicerElements.Add(dimensionElementSlicer);


            return olapReport;
        }

        #endregion
    }
}