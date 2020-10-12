#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using System;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class ReportInCodeViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;

        private OlapDataManager olapDataManager;
        private DelegateCommand<object> reportSelectionCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportInCodeViewModel"/> class.
        /// </summary>
        public ReportInCodeViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(SimpleReport());
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


        /// <summary>
        /// Gets or sets the report selection command.
        /// </summary>
        /// <value>The report selection command.</value>
        public DelegateCommand<object> ReportSelectionCommand
        {
            get
            {
                reportSelectionCommand = reportSelectionCommand ?? new DelegateCommand<object>(ChangeSelectedReport);
                return reportSelectionCommand;
            }
            set { reportSelectionCommand = value; }
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

        /// <summary>
        /// Changes the selected report.
        /// </summary>
        /// <param name="parm">The pram.</param>
        private void ChangeSelectedReport(object parm)
        {
            if (parm != null)
            {
                switch (parm.ToString())
                {
                    case "Basic Report with Dimension and Measure":
                        this.GridDataManager.SetCurrentReport(SimpleReport());
                        break;
                    case "Basic Report with Slicer":
                        this.GridDataManager.SetCurrentReport(SlicingByDimensions());
                        break;
                    case "Basic Report with Filter":
                        this.GridDataManager.SetCurrentReport(FilteredDimensions());
                        break;
                    case "Basic Report with Order":
                        this.GridDataManager.SetCurrentReport(SortingByMeasures());
                        break;
                    case "Basic Report with Top-Count":
                        this.GridDataManager.SetCurrentReport(FilteringByTopCount());
                        break;
                    case "Basic Report with Exclude":
                        this.GridDataManager.SetCurrentReport(ExcludeReport());
                        break;
                    case "Basic Report with Subset":
                        this.GridDataManager.SetCurrentReport(SubsetReport());
                        break;
                    case "Basic Report with NamedSet":
                        this.GridDataManager.SetCurrentReport(NamedSetReport());
                        break;
                    case "Report with Calculated Member":
                        this.GridDataManager.SetCurrentReport(CalculatedReport());
                        break;
                    case "Show All Member":
                        this.GridDataManager.ShowLevelTypeAll = !this.GridDataManager.ShowLevelTypeAll;
                        break;
                }
                if (parm.ToString().Equals("Basic Report with Subset") || parm.ToString().Equals("Basic Report with Named set") || parm.ToString().Equals("Basic Report with Top-Count") || parm.ToString().Equals("Basic Report with Order"))
                {
                    this.GridDataManager.CurrentReport.ShowExpanders = false;
                }
                else if (parm.ToString().Equals("Show All Member") && this.GridDataManager.CurrentReport.ShowExpanders == false)
                {
                    this.GridDataManager.CurrentReport.ShowExpanders = false;
                }
                else
                {
                    this.GridDataManager.CurrentReport.ShowExpanders = true;
                }

                this.GridDataManager.NotifyElementModified();
            }
        }

        #region SimpleReport
        OlapReport SimpleReport()
        {
            // CubeModel cubeModel = new CubeModel(ConnectionString);
            OlapReport olapReport = new OlapReport();
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
            DimensionElement dimensionElementRow1 = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow1.Name = "Product";
            dimensionElementRow1.AddLevel("Product Categories", "Category");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.SeriesElements.Add(dimensionElementRow1);

            return olapReport;
        }
        #endregion

        #region Slicing by Dimensions
        OlapReport SlicingByDimensions()
        {
            OlapReport olapReport = new OlapReport();
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
            return olapReport;
        }
        #endregion

        #region Filtered Dimensions
        OlapReport FilteredDimensions()
        {
            OlapReport olapReport = new OlapReport();
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

            return olapReport;
        }
        #endregion

        #region Sorting by Measure

        OlapReport SortingByMeasures()
        {
            OlapReport olapReport = new OlapReport();
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

            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Sort Element
            olapReport.CategoricalElements.Add(sortElement);
            //Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            return olapReport;
        }

        #endregion

        #region Filtering By Top-Count
        OlapReport FilteringByTopCount()
        {
            //Creating OlapReport
            OlapReport olapReport = new OlapReport();
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
            return olapReport;
        }
        #endregion

        #region Exclude Report
        OlapReport ExcludeReport()
        {
            OlapReport olapReport = new OlapReport();
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

            return olapReport;
        }
        #endregion

        #region Subset Report

        OlapReport SubsetReport()
        {
            OlapReport olapReport = new OlapReport();
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

            //Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            olapReport.CategoricalElements.SubSetElement = subSetElementColumn;
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.SeriesElements.SubSetElement = subSetElementRow;

            return olapReport;
        }

        #endregion

        #region NamedSet Report

        OlapReport NamedSetReport()
        {
            OlapReport olapReport = new OlapReport();
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
            dimensionElementRow.Name = "Long Lead Products";

            //Adding the Column members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding the Measure elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding the Row members
            olapReport.SeriesElements.Add(dimensionElementRow);
            return olapReport;
        }

        #endregion

        #region Calculated Member Report

        OlapReport CalculatedReport()
        {
            // CubeModel cubeModel = new CubeModel(ConnectionString);
            OlapReport olapReport = new OlapReport();
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


            //// Adding Calculated members in calculated member collection
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

            return olapReport;
        }

        #endregion

        #endregion
    }
}
