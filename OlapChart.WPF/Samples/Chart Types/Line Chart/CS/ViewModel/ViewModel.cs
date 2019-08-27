#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace LineChart
{
    using Syncfusion.Windows.Chart;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using System.Windows;
    using Syncfusion.Olap.Reports;
    using System;

    class ViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private ChartTypes olapChartType = ChartTypes.Line;
        private Visibility showLegend = Visibility.Visible;
        private OlapDataManager olapDataManager;
        private DelegateCommand<object> selectionCommand;
        private DelegateCommand<object> legendDelegateCommand;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(SimpleDimensions());
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
        /// Gets the selection command.
        /// </summary>
        /// <value>The selection command.</value>
        public DelegateCommand<object> SelectionCommand
        {
            get
            {
                return selectionCommand = selectionCommand ?? new DelegateCommand<object>(ToggleSelection);
            }
        }


        /// <summary>
        /// Gets or sets the type of the OLAP chart.
        /// </summary>
        /// <value>The type of the OLAP chart.</value>
        public ChartTypes OlapChartType
        {
            get
            {
                return olapChartType;
            }
            set
            {
                olapChartType = value;
                RaisePropertyChanged("OlapChartType");
            }
        }

        /// <summary>
        /// Gets or sets the legend visibility.
        /// </summary>
        /// <value>The legend visibility.</value>
        public Visibility ShowLegend
        {
            get { return showLegend; }
            set { showLegend = value; RaisePropertyChanged("ShowLegend"); }
        }


        /// <summary>
        /// Gets or sets the delegate command to show legend.
        /// </summary>
        /// <value>The delegate command to show legend.</value>
        public DelegateCommand<object> LegendDelegateCommand
        {
            get
            {
                return legendDelegateCommand ?? new DelegateCommand<object>(LegendOption);
            }
            set
            {
                legendDelegateCommand = value;
            }
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
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }

        /// <summary>
        /// Toggles the chart type.
        /// </summary>
        /// <param name="param">The parameter.</param>
        private void ToggleSelection(object param)
        {
            string m_chartType = param.ToString();
            if (m_chartType == "Line")
                this.OlapChartType = ChartTypes.Line;
            else if (m_chartType == "Spline")
                this.OlapChartType = ChartTypes.Spline;
            else if (m_chartType == "Rotated Spline")
                this.OlapChartType = ChartTypes.RotatedSpline;
            else if (m_chartType == "Step Line")
                this.OlapChartType = ChartTypes.StepLine;
        }

        private OlapReport SimpleDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Column Name for the Dimension and measure elements
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");
            dimensionElementColumn.Hierarchy.LevelElements[0].Add("Australia");
            dimensionElementColumn.Hierarchy.LevelElements[0].Add("United States");
            dimensionElementColumn.Hierarchy.LevelElements[0].Add("Germany");
            dimensionElementColumn.Hierarchy.LevelElements[0].IncludeAvailableMembers = true;

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            //Specifying the Row Name for the Dimension element
            DimensionElement dimensionElementRow = new DimensionElement();
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");
            dimensionElementRow.Hierarchy.LevelElements[0].Add("FY 2002");
            dimensionElementRow.Hierarchy.LevelElements[0].Add("FY 2003");
            dimensionElementRow.Hierarchy.LevelElements[0].Add("FY 2004");
            dimensionElementRow.Hierarchy.LevelElements[0].IncludeAvailableMembers = true;

            //Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            return olapReport;
        }

        /// <summary>
        /// Shows the legend of the control.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void LegendOption(object parameter)
        {
            this.ShowLegend = parameter.ToString() == "True" ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion
    }
}