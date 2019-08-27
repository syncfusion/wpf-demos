#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace MDXQuery.ViewModel
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;
    using System.Windows.Input;
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
        private OlapDataManager olapDataManager;
        private string selectedMDX = "Simple Dimensions";
        private bool allowMDXToOlapReportParse = true;
        private string currentMDXQuery;
        private bool showAllLevel;
        View.MDXEditor mdxEditor;
        private DelegateCommand<object> reportDelegateCommand;

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


        public bool AllowMDXToOlapReportParse
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
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager GridDataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
        }

        /// <summary>
        /// Gets or sets the delegate command to show legend.
        /// </summary>
        /// <value>The delegate command to show legend.</value>
        public DelegateCommand<object> ReportDelegateCommand
        {
            get
            {
                return reportDelegateCommand ?? new DelegateCommand<object>(ReportSelection);
            }
            set
            {
                reportDelegateCommand = value;
            }
        }

        #endregion

        #region Helper method

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

        private void ExecuteMDX()
        {
            this.GridDataManager.AllowMdxToOlapReportParse = AllowMDXToOlapReportParse;
            this.GridDataManager.ShowLevelTypeAll = ShowLevelTypeAll;
            this.GridDataManager.MdxQuery = (string.IsNullOrEmpty(CurrentMDXQuery)) ? " " : CurrentMDXQuery;
            this.GridDataManager.NotifyElementModified();
            this.GridDataManager.ExecuteCellSet();
        }

        void ShowMDXWindow(Object Param)
        {
            mdxEditor = new View.MDXEditor(this);
            mdxEditor.Owner = Application.Current.MainWindow;
            SkinStorage.SetVisualStyle(mdxEditor, SkinStorage.GetVisualStyle(Application.Current.MainWindow));
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
            this.GridDataManager.ShowLevelTypeAll = false;
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
                case "Formatted MDX":
                    CurrentMDXQuery = this.FormattedMdx();
                    break;
                //For showing All Member
                case "Showing All Member":
                    this.GridDataManager.ShowLevelTypeAll = !this.GridDataManager.ShowLevelTypeAll;
                    break;
            }
            ExecuteMDX();
        }

        #region SimpleDimensions
        String SimpleDimensions()
        {
            return " SELECT NON EMPTY ({{Hierarchize({[Customer].[Customer Geography].[Country]})} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region  HierarchyandLevels
        String HierarchyandLevels()
        {
            return " SELECT NON EMPTY ({{{Hierarchize({[Product].[Product Model Categories].[Category]})}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region MultipleSeriesDimensions
        String MultipleSeriesDimensions()
        {
            return " SELECT NON EMPTY ({{{Hierarchize({[Customer].[Customer Geography].[Country]})}} * {[MEASURES].[Sales Amount]}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}} * {{{Hierarchize({DrilldownLevel({[Sales Channel].[Sales Channel].[Sales Channel]})})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region MultipleMeasuresInSeries
        String MultipleMeasuresInSeries()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{[MEASURES].[Internet Sales Amount],[MEASURES].[Internet Total Product Cost]} * {{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM [Adventure Works]  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region Slicing by Measures
        String SlicingByMeasures()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}}} ) dimension properties member_type ON ROWS FROM  ( SELECT  ({{[MEASURES].[Internet Sales Amount]}} ) ON COLUMNS FROM [Adventure Works] )   CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        #region Slicing by Dimensions
        String SlicingByDimensions()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize({[Date].[Fiscal].[Fiscal Year]})}}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON ROWS FROM  ( SELECT  ({{{{[Sales Channel].[Sales Channel].&[Internet], [Sales Channel].[Sales Channel].&[Reseller]}}}} ) ON COLUMNS FROM [Adventure Works] )   CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE ";
        }
        #endregion

        #region Filtered Dimensions
        String FilteredDimensions()
        {
            return " SELECT NON EMPTY ({{{{Hierarchize({[Customer].[Customer Geography].[Country]})}}}} ) dimension properties member_type ON COLUMNS, NON EMPTY ({{{{Hierarchize([Date].[Fiscal].[Fiscal Year])}}} * {[MEASURES].[Internet Sales Amount]}} ) dimension properties member_type ON ROWS FROM  ( SELECT  {[Date].[Fiscal].[Fiscal Year].[FY 2002]} ON COLUMNS FROM [Adventure Works] )  CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE";
        }
        #endregion

        private string FormattedMdx()
        {
            return @" WITH  MEMBER [Measures].[Customers] As  [Measures].[Customer Count] ,
FORE_COLOR=RGB(255,255,255), BACK_COLOR = IIF([Measures].[Customer Count]>1500,RGB(0,255,0), RGB(220,0,0))
MEMBER [Measures].[Internet Sales] As [Measures].[Internet Sales Amount], BACK_COLOR=IIF([Measures].[Internet Sales Amount]>7000000,RGB(255,255,0),RGB(255,255,255))
 SELECT
NON EMPTY({ { Hierarchize({[Customer].[Customer Geography].[Country]
    })} * {[Measures].[Customers],[Measures].[Internet Sales]}} ) dimension properties member_type ON COLUMNS, 
NON EMPTY({ { Hierarchize({[Date].[Fiscal].[Fiscal Year]})}} ) dimension properties member_type ON ROWS
FROM[Adventure Works]
CELL PROPERTIES VALUE, FORMAT_STRING, FORMATTED_VALUE, FORE_COLOR, FONT_FLAGS, FONT_SIZE, FONT_NAME, BACK_COLOR";
        }
        
        #endregion
    }
}