#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Mdx_Query.ViewModel
{
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;
    using System;
    using System.Windows.Input;
    using Syncfusion.Olap.Reports;
    using System.Windows;

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
        private bool showAllLevel;
        private string currentMDXQuery;
        private bool allowMDXToOlapReportParse;
        private string selectedMDX = "Simple Dimensions";
        private OlapDataManager olapDataManager;
        View.MDXEditor mdxEditor;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.olapDataManager = new OlapDataManager(ConnectionString);
            this.olapDataManager.MdxQuery = CurrentMDXQuery = SimpleDimensions();
            this.olapDataManager.AllowMdxToOlapReportParse = AllowMDXToOlapReportParse;
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

        public bool AllowMDXToOlapReportParse
        {
            get { return this.allowMDXToOlapReportParse; }
            set
            {
                this.allowMDXToOlapReportParse = value;
               
            }
        }

        public string CurrentMDXQuery
        {
            get { return this.currentMDXQuery; }
            set { this.currentMDXQuery = value; }
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

        public ICommand ShowMDXCommand
        {
            get { return new DelegateCommand<object>(ShowMDXWindow); }
        }

        public ICommand ProcessCommand
        {
            get { return new DelegateCommand<object>(ProcessMDX); }
        }

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand<object>(CancelProcess); }
        }

        #endregion

        #region Helper Methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ExecuteMDX()
        {
            this.ClientDataManager.CurrentReport.ChartSettings.ChartType = "Column";
            this.ClientDataManager.CurrentReport.ChartSettings.ChartColorPalette = "Default";
            this.ClientDataManager.CurrentReport.ChartSettings.LegendVisibility = true;
            ChartAppearanceSettings chartSettings = this.ClientDataManager.CurrentReport.ChartSettings;
            this.ClientDataManager.AllowMdxToOlapReportParse = AllowMDXToOlapReportParse;
            this.ClientDataManager.ShowLevelTypeAll = ShowLevelTypeAll;
            this.ClientDataManager.MdxQuery = CurrentMDXQuery;
            this.ClientDataManager.NotifyElementModified(); 
            this.ClientDataManager.Reports.Clear();
            this.olapDataManager.ExecuteCellSet();
            this.olapDataManager.CurrentReport.ChartSettings = chartSettings;
        }

        #region SimpleDimensions
        public String SimpleDimensions()
        {
            return " SELECT NON EMPTY ({{Hierarchize({[Customer].[Customer Geography].[Country]})} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region  HierarchyandLevels
        public String HierarchyandLevels()
        {
            return " SELECT NON EMPTY ({{{Hierarchize({[Product].[Product Model Categories].[Category]})}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region MultipleSeriesDimensions
        public String MultipleSeriesDimensions()
        {
            return " SELECT NON EMPTY ({{{Hierarchize({[Customer].[Customer Geography].[Country]})}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}} * {{{Hierarchize({DrilldownLevel({[Sales Channel].[Sales Channel].[Sales Channel]})})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region MultipleMeasuresInSeries
        public String MultipleMeasuresInSeries()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{[MEASURES].[Internet Sales Amount],[MEASURES].[Internet Total Product Cost]} * {{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region Slicing by Measures
        public String SlicingByMeasures()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM  ( SELECT  ({{[MEASURES].[Internet Sales Amount]}} ) ON COLUMNS FROM [Adventure Works] )   CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region Slicing by Dimensions
        public String SlicingByDimensions()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON ROWS FROM  ( SELECT  ({{{{[Sales Channel].[Sales Channel].&[Internet], [Sales Channel].[Sales Channel].&[Reseller]}}}} ) ON COLUMNS FROM [Adventure Works] )   CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE ";
        }
        #endregion

        #region Filtered Dimensions

        public String FilteredDimensions()
        {
            return " SELECT   NONEMPTY( VISUALTOTALS( ({{Drilldownlevel({ [CUSTOMER].[CUSTOMER GEOGRAPHY] })}}) ),{[Measures].[Internet Sales Amount]})  dimension properties MEMBER_TYPE, PARENT_UNIQUE_NAME  ON COLUMNS ,  NON EMPTY({[Measures].[Internet Sales Amount]})  dimension properties MEMBER_TYPE, PARENT_UNIQUE_NAME  ON ROWS  FROM [ADVENTURE WORKS] WHERE ({{{{[DATE].[FISCAL].[FISCAL YEAR].[FY 2002]}}}})  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }

        #endregion

        void ShowMDXWindow(Object Param)
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

        void CancelProcess(object param)
        {
            mdxEditor.Close();
        }

        /// <summary>
        /// Toggles the report.
        /// </summary>
        /// <param name="param">The parameter.</param>
        private void ReportSelection(object param)
        {
            this.ClientDataManager.ShowLevelTypeAll = false;
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
                //For showing All Member
                case "Showing All Member":
                    this.ClientDataManager.ShowLevelTypeAll = !this.ClientDataManager.ShowLevelTypeAll;
                    break;
            }
            ExecuteMDX();
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }
        #endregion
    }
}