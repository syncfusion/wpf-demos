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
    using Syncfusion.Olap.Engine;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.DataProvider;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class DrillThroughReportViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        internal AdomdDataProvider dataProvider;
        private OlapDataManager olapDataManager1;
        private OlapDataManager dataManager2;
        private DelegateCommand<object> hyperlinkCommand;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DrillThroughReportViewModel"/> class.
        /// </summary>
        public DrillThroughReportViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            dataProvider = new AdomdDataProvider(ConnectionString);

            olapDataManager1 = new OlapDataManager(dataProvider);
            olapDataManager1.SetCurrentReport(ResellerSalesReport());

            dataManager2 = new OlapDataManager(dataProvider);
            dataManager2.SetCurrentReport(ProductPromotionReport());
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager GridDataManager1
        {
            get { return olapDataManager1; }
            set { olapDataManager1 = value; }
        }

        /// <summary>
        /// Gets or sets the grid data manager2.
        /// </summary>
        /// <value>The grid data manager2.</value>
        public OlapDataManager GridDataManager2
        {
            get { return dataManager2; }
            set { dataManager2 = value; }
        }

        /// <summary>
        /// Gets or sets the hyperlink cell command.
        /// </summary>
        /// <value>The hyperlink cell command.</value>
        public DelegateCommand<object> HyperlinkCellCommand
        {
            get
            {
                hyperlinkCommand = hyperlinkCommand ?? new DelegateCommand<object>(HyperlinkCellClicked);
                return hyperlinkCommand;
            }
            set { hyperlinkCommand = value; }
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
            if (disposing)
            {
                if (this.olapDataManager1 != null)
                    this.olapDataManager1.Dispose();
                if (this.dataManager2 != null)
                    this.dataManager2.Dispose();
                if (this.dataProvider != null)
                    this.dataProvider.Dispose();
            }
        }

        private void HyperlinkCellClicked(object parm)
        {
            if (parm is PivotCellDescriptor)
            {
                this.GridDataManager2.SetCurrentReport(GetOlapReport((parm as PivotCellDescriptor).CellData));
                this.GridDataManager2.NotifyElementModified();
            }
        }

        /// <summary>
        /// Report for Reseller Sales Amount over Geography and Product
        /// </summary>
        /// <returns></returns>
        private OlapReport ResellerSalesReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the name for Dimension Element for Column
            dimensionElementColumn.Name = "Geography";
            dimensionElementColumn.AddLevel("Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the name for Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Reseller Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the name for Dimension Element for Row
            dimensionElementRow.Name = "Product";
            dimensionElementRow.AddLevel("Product Categories", "Category");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.ShowExpanders = false;
            olapReport.SeriesElements.Add(dimensionElementRow);

            return olapReport;
        }

        /// <summary>
        /// Report for Reseller Sales Amount Product Promotion.
        /// </summary>
        /// <returns></returns>
        private OlapReport ProductPromotionReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the name for Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Reseller Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the name for Dimension Element for Row
            dimensionElementRow.Name = "Promotion";
            dimensionElementRow.AddLevel("Promotion", "Promotion");

            // Adding Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            return olapReport;
        }

        /// <summary>
        /// OlapReport for Sales Reason sliced by Product and Date
        /// </summary>
        /// <param name="pivotValueCellData">The Pivot value cell data.</param>
        /// <returns></returns>
        private OlapReport GetOlapReport(PivotValueCellData pivotValueCellData)
        {
            OlapReport olapReport = new OlapReport();
            // Selecting the Current cube
            olapReport.CurrentCubeName = "Adventure Works";

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the name for Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Reseller Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the name for Dimension Element for Row
            dimensionElementRow.Name = "Promotion";
            dimensionElementRow.AddLevel("Promotion", "Promotion");

            // Adding Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            // Specifying Date Slicer Element
            DimensionElement DateSlicerElement = new DimensionElement();
            DateSlicerElement.Name = "Geography";
            DateSlicerElement.AddLevel("Geography", "Country");
            DateSlicerElement.Hierarchy.LevelElements["Country"].IncludeAvailableMembers = true;

            if (pivotValueCellData.Columns.Count > 0)
            {
                DateSlicerElement.Hierarchy.LevelElements["Country"].Add(pivotValueCellData.Columns[0]);
            }

            // Adding Slicer Element
            olapReport.SlicerElements.Add(DateSlicerElement);

            // Specifying the Product Slicer Element
            DimensionElement ProductSlicerElement = new DimensionElement();
            ProductSlicerElement.Name = "Product";
            ProductSlicerElement.AddLevel("Product Categories", "Category");
            ProductSlicerElement.Hierarchy.LevelElements["Category"].IncludeAvailableMembers = true;

            if (pivotValueCellData.Rows.Count > 0)
            {
                ProductSlicerElement.Hierarchy.LevelElements["Category"].Add(pivotValueCellData.Rows[0]);
            }
            // Adding Slicer Element
            olapReport.SlicerElements.Add(ProductSlicerElement);

            return olapReport;
        }

        #endregion
    }
}
