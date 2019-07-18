#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace ReportsinCode
{
    using System;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Chart;

    class ViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private ChartTypes olapChartType = ChartTypes.Column;
        private DelegateCommand<bool> showAllMemberCommand;
        private DelegateCommand<object> chartTypeCommand;
        private DelegateCommand<object> reportTypeCommand;
        private int rowCount = 2;
        private bool isCalculatedReportSelected;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            showAllMemberCommand = new DelegateCommand<bool>(ToggleShowAllMember);
            chartTypeCommand = new DelegateCommand<object>(ToggleSelection);
            reportTypeCommand = new DelegateCommand<object>(ToggleReportSelection);
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(SimpleReport());
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
        /// Gets or sets the row count for legend.
        /// </summary>
        public int RowCount
        {
            get
            {
                return rowCount;
            }
            set
            {
                rowCount = value;
                RaisePropertyChanged("RowCount");
            }
        }

        /// <summary>
        /// Gets or sets the type of the olap chart.
        /// </summary>
        /// <value>The type of the olap chart.</value>
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
        /// Gets or sets the delegate command to show legend.
        /// </summary>
        /// <value>The delegate command to show legend.</value>
        public DelegateCommand<object> ReportTypeCommand
        {
            get { return reportTypeCommand; }
            set { reportTypeCommand = value; }
        }

        /// <summary>
        /// Gets the command for show all member operation.
        /// </summary>
        public DelegateCommand<bool> ShowAllMemberCommand
        {
            get { return showAllMemberCommand; }
            set { showAllMemberCommand = value; }
        }

        /// <summary>
        /// Gets the selection command.
        /// </summary>
        public DelegateCommand<object> ChartTypeCommand
        {
            get { return chartTypeCommand; }
            set { chartTypeCommand = value; }
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

        /// <summary>
        /// Toggles the report.
        /// </summary>
        /// <param name="param">The parameter.</param>
        private void ToggleSelection(object param)
        {
            string m_chartType = param.ToString();
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
        /// <param name="showAllMember">Indicates whether all member is shown or not.</param>
        private void ToggleShowAllMember(bool showAllMember)
        {
            DataManager.ShowLevelTypeAll = showAllMember;
            DataManager.NotifyElementModified();
            RowCount = showAllMember ? 1 : isCalculatedReportSelected ? 8 : 2;
        }

        /// <summary>
        /// Toggles the report.
        /// </summary>
        /// <param name="param">The parameter.</param>
        private void ToggleReportSelection(object param)
        {
            isCalculatedReportSelected = false;
            string m_content = param.ToString();
            switch (m_content)
            {
                case "Report with Dimension and Measure":
                    DataManager.SetCurrentReport(SimpleReport());
                    break;
                case "Report with Slicer":
                    DataManager.SetCurrentReport(SlicingByDimensions());
                    RowCount = 2;
                    break;
                case "Report with Filter":
                    DataManager.SetCurrentReport(FilteredDimensions());
                    break;
                case "Report with Order":
                    DataManager.SetCurrentReport(SortingByMeasures());
                    break;
                case "Report with Top-Count":
                    DataManager.SetCurrentReport(FilteringByTopCount());
                    break;
                case "Report with Exclude":
                    DataManager.SetCurrentReport(ExcludeReport());
                    break;
                case "Report with Subset":
                    DataManager.SetCurrentReport(SubsetReport());
                    break;
                case "Report with NamedSet":
                    DataManager.SetCurrentReport(NamedSetReport());
                    break;
                case "Report with Calculated Member":
                    DataManager.SetCurrentReport(CalculatedReport());
                    isCalculatedReportSelected = true;
                    break;
            }
            if (m_content.Equals("Report with Order") || m_content.Equals("Report with Subset") || m_content.Equals("Report with NamedSet") || m_content.Equals("Report with Top-Count"))
                DataManager.CurrentReport.ShowExpanders = false;
            else
                DataManager.CurrentReport.ShowExpanders = true;
            this.DataManager.NotifyElementModified();
            RowCount = isCalculatedReportSelected ? 8 : 2;
        }

        #region SimpleReport
        OlapReport SimpleReport()
        {
            // CubeModel cubeModel = new CubeModel(ConnectionString);
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.HierarchyName = "Customer Geography";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }
        #endregion

        #region Slicing by Dimensions
        OlapReport SlicingByDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the dimension Name
            dimensionElementColumn.Name = "Customer";
            //Adding the Level Name along with the Hierarchy Name
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the dimension Name
            dimensionElementRow.Name = "Date";
            //Adding the Level Name along with the Hierarchy Name
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            DimensionElement dimensionElementSlicer = new DimensionElement();
            dimensionElementSlicer.Name = "Sales Channel";
            dimensionElementSlicer.AddLevel("Sales Channel", "Sales Channel");

            MeasureElements measureElementRow = new MeasureElements();
            measureElementRow.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            olapReport.CategoricalElements.Add(dimensionElementColumn);
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.SlicerElements.Add(dimensionElementSlicer);
            olapReport.SeriesElements.Add(measureElementRow);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }
        #endregion

        #region Filtered Dimensions
        OlapReport FilteredDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();

            //Specifying the dimension Name
            dimensionElementColumn.Name = "Customer";
            //Adding the Level Name along with the Hierarchy Name
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            DimensionElement dimensionElementRow = new DimensionElement();

            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");
            dimensionElementRow.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionElementRow.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2002");

            MeasureElements measureElementRow = new MeasureElements();
            measureElementRow.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            olapReport.CategoricalElements.Add(dimensionElementColumn);
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.SeriesElements.Add(measureElementRow);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }
        #endregion

        #region Sorting by Measure

        OlapReport SortingByMeasures()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();

            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            //Specifying the Hierarchy Name
            dimensionElementColumn.HierarchyName = "Customer Geography";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            //Creating Measure Elements
            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });
            DimensionElement dimensionElementRow = new DimensionElement();

            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            //SortOrder.BDESC for Breaking Hierarchy with Descending
            //SortOrder.DESC for displaying values in Descending Order regardless of hierarchy
            //SortOrder.BASC for Breaking Hierarchy with Ascending
            //SortOrder.ASC for displaying values in Ascending Order regardless of hierarchy
            SortElement sortElement = new SortElement(AxisPosition.Categorical, SortOrder.BDESC, true);
            sortElement.Element.UniqueName = "[Measures].[Internet Sales Amount]";


            // Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Sort Element
            olapReport.CategoricalElements.Add(sortElement);
            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;

        }

        #endregion

        #region Filtering By Top-Count
        OlapReport FilteringByTopCount()
        {
            //Creating OlapReport
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            //Creating Measure Element
            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            //Filter the top 5 elements of "Internet Sales Amount".
            TopCountElement topCountElement = new TopCountElement(AxisPosition.Categorical, 5);
            topCountElement.MeasureName = "Internet Sales Amount";

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(topCountElement);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }
        #endregion

        #region Exclude Report
        OlapReport ExcludeReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";
            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            //Specifying the Hierarchy Name
            dimensionElementColumn.HierarchyName = "Customer Geography";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            DimensionElement ExcludedDimension = new DimensionElement();
            ExcludedDimension.Name = "Date";
            ExcludedDimension.AddLevel("Fiscal", "Fiscal Year");
            ExcludedDimension.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2002");
            ExcludedDimension.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;

            //Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow, ExcludedDimension);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }
        #endregion

        #region Subset Report

        OlapReport SubsetReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";
            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            //Specifying the Hierarchy Name
            dimensionElementColumn.HierarchyName = "Customer Geography";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            //Specifying the SubsetElement
            //Specify the start index and end index to retrieve the records.
            SubsetElement subSetElementColumn = new SubsetElement(5);
            subSetElementColumn.Name = "Top 5 Elements";

            SubsetElement subSetElementRow = new SubsetElement(3);
            subSetElementRow.Name = "Top 3 Elements";

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            olapReport.CategoricalElements.SubSetElement = subSetElementColumn;
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.SeriesElements.SubSetElement = subSetElementRow;

            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }

        #endregion

        #region NamedSet Report

        OlapReport NamedSetReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the dimension Name
            dimensionElementColumn.Name = "Customer";
            //Specifying the Hierarchy Name
            dimensionElementColumn.HierarchyName = "Customer Geography";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            //Specifying the measure elements
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            //Specifying the NamedSet Element
            NamedSetElement dimensionElementRow = new NamedSetElement();
            //Specifying the dimension name
            dimensionElementRow.Name = "Core Product Group";

            //Adding the Column members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding the Measure elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding the Row members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }

        #endregion

        #region Calculated Member Report

        OlapReport CalculatedReport()
        {
            // CubeModel cubeModel = new CubeModel(ConnectionString);
            OlapReport olapReport = new OlapReport();
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.HierarchyName = "Customer Geography";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            DimensionElement internalDimension = new DimensionElement();
            internalDimension.Name = "Product";
            internalDimension.AddLevel("Product Categories", "Category");

            //// Calculated Measure
            CalculatedMember calculatedMeasure1 = new CalculatedMember();
            calculatedMeasure1.Name = "Oder on Discount";
            calculatedMeasure1.Expression = "[Measures].[Order Quantity] + ([Measures].[Order Quantity] * 0.10)";
            calculatedMeasure1.AddElement(new MeasureElement { Name = "Order Quantity" });

            //// Calculated Measure
            CalculatedMember calculatedMeasure2 = new CalculatedMember();
            calculatedMeasure2.Name = "Sales Range";
            calculatedMeasure2.AddElement(new MeasureElement { Name = "Sales Amount" });
            calculatedMeasure2.Expression = "IIF([Measures].[Sales Amount]>200000,\"High\",\"Low\")";

            // Calculated Dimension
            CalculatedMember calculateDimension = new CalculatedMember();
            calculateDimension.Name = "Bikes & Components";
            calculateDimension.Expression = "([Product].[Product Categories].[Category].[Bikes] + [Product].[Product Categories].[Category].[Components] )";
            calculateDimension.AddElement(internalDimension);

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Sales Amount" });
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Order Quantity" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            // Adding Calculated members in calculated member collection
            olapReport.CalculatedMembers.Add(calculatedMeasure1);
            olapReport.CalculatedMembers.Add(calculateDimension);
            olapReport.CalculatedMembers.Add(calculatedMeasure2);

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            olapReport.CategoricalElements.Add(calculateDimension);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            olapReport.CategoricalElements.Add(calculatedMeasure1);
            olapReport.CategoricalElements.Add(calculatedMeasure2);

            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.ChartSettings = this.DataManager.CurrentReport.ChartSettings;
            return olapReport;
        }

        #endregion

        #endregion
    }
}