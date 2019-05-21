#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace DrillState.ViewModel
{
    using System;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;

    public class ViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private DelegateCommand<object> drillEventCommand;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(CreateOlapReport());
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

        /// <summary>
        /// Gets or sets the drill event command.
        /// </summary>
        /// <value>The drill event command.</value>
        public DelegateCommand<object> DrillEventCommand
        {
            get
            {
                drillEventCommand = drillEventCommand ?? new DelegateCommand<object>(DoDrillDownOrUp);
                return drillEventCommand;
            }
            set { drillEventCommand = value; }
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

        private void DoDrillDownOrUp(object parm)
        {
            if (parm.ToString().Equals("Expand-All"))
            {
                var dimensionElement = this.DataManager.CurrentReport.SeriesElements[0].ElementValue as DimensionElement;
                if (dimensionElement != null)
                    dimensionElement.DrillState = DrillState.ExpandAll;
            }
            else if (parm.ToString().Equals("Collapse-All"))
            {
                var dimensionElement = this.DataManager.CurrentReport.SeriesElements[0].ElementValue as DimensionElement;
                if (dimensionElement != null)
                    dimensionElement.DrillState = DrillState.CollapseAll;
            }
            else if (parm.ToString().Equals("Expand-Level"))
            {
                DimensionElement dimensionElement = this.DataManager.CurrentReport.SeriesElements[0].ElementValue as DimensionElement;
                if (dimensionElement != null)
                {
                    dimensionElement.DrillState = DrillState.ExpandToLevel;
                    dimensionElement.DrillUpDownLevel = "Product";
                    this.DataManager.CurrentReport.SeriesElements[0].ElementValue = dimensionElement;
                }
            }
            else if (parm.ToString().Equals("Collapse-Level"))
            {
                DimensionElement dimensionElement = this.DataManager.CurrentReport.SeriesElements[0].ElementValue as DimensionElement;
                if (dimensionElement != null)
                {
                    dimensionElement.DrillState = DrillState.CollapseToLevel;
                    dimensionElement.DrillUpDownLevel = "Subcategory";
                    this.DataManager.CurrentReport.SeriesElements[0].ElementValue = dimensionElement;
                }
            }
            else if (parm.ToString().Equals("Expand-Member"))
            {
                DimensionElement dimensionElement = this.DataManager.CurrentReport.SeriesElements[0].ElementValue as DimensionElement;
                if (dimensionElement != null)
                {
                    dimensionElement.DrillState = DrillState.ExpandToLevel;
                    dimensionElement.DrillUpDownLevel = "Product";
                    dimensionElement.DrillUpDownMember = "Bikes";
                    this.DataManager.CurrentReport.SeriesElements[0].ElementValue = dimensionElement;
                }
            }
            else if (parm.ToString().Equals("Collapse-Member"))
            {
                DimensionElement dimensionElement = this.DataManager.CurrentReport.SeriesElements[0].ElementValue as DimensionElement;
                if (dimensionElement != null)
                {
                    dimensionElement.DrillState = DrillState.CollapseToLevel;
                    dimensionElement.DrillUpDownLevel = "Subcategory";
                    dimensionElement.DrillUpDownMember = "Mountain-100 Black, 48";
                    this.DataManager.CurrentReport.SeriesElements[0].ElementValue = dimensionElement;
                }
            }
            else if (parm.ToString().Equals("Reset-All"))
            {
                DimensionElement dimensionElement = this.DataManager.CurrentReport.SeriesElements[0].ElementValue as DimensionElement;
                if (dimensionElement != null)
                    dimensionElement.Hierarchy.LevelElements[0].MemberElements.Clear();
            }
            this.DataManager.NotifyElementModified();
        }
        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>
        private OlapReport CreateOlapReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElement = new DimensionElement() { Name = "Product" };
            dimensionElement.AddLevel("Product Categories", "Category");
            olapReport.SeriesElements.Add(dimensionElement);

            dimensionElement = new DimensionElement() { Name = "Date" };
            dimensionElement.AddLevel("Fiscal", "Fiscal Year");
            olapReport.CategoricalElements.Add(dimensionElement);

            return olapReport;
        }

        #endregion
    }
}