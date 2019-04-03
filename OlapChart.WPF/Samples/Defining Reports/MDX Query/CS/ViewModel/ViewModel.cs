#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace MdxQuery
{
    using System;
    using System.Windows.Input;
    using Syncfusion.Windows.Chart;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using System.Windows;

    public class ViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;

        private string selectedMDX = "Simple Dimensions";
        private bool allowMDXToOlapReportParse = true;
        private string currentMDXQuery;
        private bool showAllLevel;
        private OlapDataManager olapDataManager;
        private View.MDXEditor mdxEditor;
        private ChartTypes olapChartType = ChartTypes.Column;
        private DelegateCommand<object> selectionCommand;
        private int rowCount = 3;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.MdxQuery = CurrentMDXQuery = SimpleDimensions();
        }

        #endregion

        #region Properties

        public string SelectedMDX
        {
            get { return selectedMDX; }
            set
            {
                selectedMDX = value;
                ReportSelection(value);
            }
        }

        public bool AllowMdxToOlapReportParse
        {
            get { return allowMDXToOlapReportParse; }
            set
            {
                allowMDXToOlapReportParse = value;
                ExecuteMDX();
            }
        }

        public string CurrentMDXQuery
        {
            get { return currentMDXQuery; }
            set { currentMDXQuery = value; }
        }

        public bool ShowLevelTypeAll
        {
            get { return showAllLevel; }
            set
            {
                showAllLevel = value;
                ExecuteMDX();
            }
        }

        /// <summary>
        /// Gets or sets the row count for legend.
        /// </summary>
        public int RowCount
        {
            get { return rowCount; }
            set
            {
                rowCount = value; 
                RaisePropertyChanged("RowCount");
            }
        }

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager DataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
        }

        public ICommand ShowMDXCommand
        {
            get { return new DelegateCommand<object>(ShowMDXWindow); }
        }

        public ICommand ProcessCommand
        {
            get { return new DelegateCommand<object>(ProcessMDX); }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand<object>(CancelProcess); }
        }

        /// <summary>
        /// Gets the selection command.
        /// </summary>
        /// <value>The selection command.</value>
        public DelegateCommand<object> SelectionCommand
        {
            get
            {
                return selectionCommand ?? new DelegateCommand<object>(ToggleSelection);
            }
            set { selectionCommand = value; }
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

        #endregion

        #region Helper Methods

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

        void CancelProcess(object param)
        {
            mdxEditor.Close();
        }

        void ShowMDXWindow(object Param)
        {
            mdxEditor = new View.MDXEditor(this);
            mdxEditor.Owner = Application.Current.MainWindow;
            mdxEditor.ShowDialog();
        }

        void ProcessMDX(object param)
        {
            mdxEditor.Close();
            ExecuteMDX();
        }

        private void ExecuteMDX()
        {
            this.DataManager.AllowMdxToOlapReportParse = AllowMdxToOlapReportParse;
            this.DataManager.ShowLevelTypeAll = ShowLevelTypeAll;
            this.DataManager.MdxQuery = CurrentMDXQuery;
            this.DataManager.NotifyElementModified();
            this.DataManager.ExecuteCellSet();
            RowCount = showAllLevel ? 1 : 3;
        }

        /// <summary>
        /// Toggles the report.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void ToggleSelection(object parameter)
        {
            string m_chartType = parameter.ToString();
            if (m_chartType == "Column")
                this.OlapChartType = ChartTypes.Column;
            else if (m_chartType == "Stacking Column")
                this.OlapChartType = ChartTypes.StackingColumn;
            else if (m_chartType == "Stacking Column 100")
                this.OlapChartType = ChartTypes.StackingColumn100;
        }

        /// <summary>
        /// Toggles the report.
        /// </summary>
        /// <param name="param">The parameter.</param>
        private void ReportSelection(object param)
        {
            this.DataManager.ShowLevelTypeAll = false;
            switch (param.ToString())
            {
                //For getting Simple Dimension data
                case "Simple Dimensions":
                    CurrentMDXQuery = SimpleDimensions();
                    break;
                //For getting Hierarchy and Levels data
                case "Hierarchy and Levels":
                    CurrentMDXQuery = HierarchyandLevels();
                    break;
                //For getting Multiple Series Dimensions data
                case "Multiple Series Dimensions":
                    CurrentMDXQuery = MultipleSeriesDimensions();
                    break;
                //For getting Multiple Measures in Series data
                case "Multiple Measures in Series":
                    CurrentMDXQuery = MultipleMeasuresInSeries();
                    break;
                //For getting Slicing by Measures data
                case "Slicing by Measures":
                    CurrentMDXQuery = this.SlicingByMeasures();
                    break;
                //For getting Slicing by Dimensions data
                case "Slicing by Dimensions":
                    CurrentMDXQuery = SlicingByDimensions();
                    break;
                //For getting Filtered Dimensions data
                case "Filtered Dimensions":
                    CurrentMDXQuery = FilteredDimensions();
                    break;
            }
            ExecuteMDX();
        }

        #region SimpleDimensions
        string SimpleDimensions()
        {
            return " SELECT NON EMPTY ({{Hierarchize({[Customer].[Customer Geography].[Country]})} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region  HierarchyandLevels
        string HierarchyandLevels()
        {
            return " SELECT NON EMPTY ({{{Hierarchize({[Product].[Product Model Categories].[Category]})}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region MultipleSeriesDimensions
        string MultipleSeriesDimensions()
        {
            return " SELECT NON EMPTY ({{{Hierarchize({[Customer].[Customer Geography].[Country]})}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}} * {{{Hierarchize({DrilldownLevel({[Sales Channel].[Sales Channel].[Sales Channel]})})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region MultipleMeasuresInSeries
        string MultipleMeasuresInSeries()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{[MEASURES].[Internet Sales Amount],[MEASURES].[Internet Total Product Cost]} * {{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region Slicing by Measures
        string SlicingByMeasures()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM  ( SELECT  ({{[MEASURES].[Internet Sales Amount]}} ) ON COLUMNS FROM [Adventure Works] )   CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region Slicing by Dimensions
        string SlicingByDimensions()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON ROWS FROM  ( SELECT  ({{{{[Sales Channel].[Sales Channel].&[Internet], [Sales Channel].[Sales Channel].&[Reseller]}}}} ) ON COLUMNS FROM [Adventure Works] )   CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE ";
        }
        #endregion

        #region Filtered Dimensions
        string FilteredDimensions()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize([Date].[Fiscal].[Fiscal Year])}}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON ROWS FROM  ( SELECT  {[Date].[Fiscal].[Fiscal Year].[FY 2002]} ON COLUMNS FROM [Adventure Works] )  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #endregion
    }
}