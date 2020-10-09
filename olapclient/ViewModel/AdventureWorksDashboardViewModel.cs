#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.DataProvider;
    using System;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class AdventureWorksDashboardViewModel : Syncfusion.Windows.Shared.NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private AdomdDataProvider adomdProvider;
        private OlapDataManager chartDataManager1;
        private OlapDataManager chartDataManager2;
        private OlapDataManager chartDataManager4;
        private OlapDataManager gaugeDataManager;
        private OlapDataManager chartDataManager3;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AdventureWorksDashboardViewModel"/> class.
        /// </summary>
        public AdventureWorksDashboardViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = AdventureWorksDashboardModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = AdventureWorksDashboardModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            adomdProvider = new AdomdDataProvider(ConnectionString);

            chartDataManager1 = new OlapDataManager(adomdProvider);
            chartDataManager1.SetCurrentReport(SimpleDimensions());

            chartDataManager2 = new OlapDataManager(adomdProvider);
            chartDataManager2.SetCurrentReport(ProductSalesReport());

            chartDataManager3 = new OlapDataManager(adomdProvider);
            chartDataManager3.SetCurrentReport(ProductSalesReport());

            chartDataManager4 = new OlapDataManager(adomdProvider);
            chartDataManager4.SetCurrentReport(InternetGrossProfitReportonCountry());

            gaugeDataManager = new OlapDataManager(adomdProvider);
            gaugeDataManager.SetCurrentReport(ReportWithKPI());
        }

        #endregion

        #region Properties

        public OlapDataManager ChartDataManager1
        {
            get { return chartDataManager1; }
            set { chartDataManager1 = value; }
        }


        public OlapDataManager ChartDataManager2
        {
            get { return chartDataManager2; }
            set { chartDataManager2 = value; }
        }


        public OlapDataManager ChartDataManager3
        {
            get { return chartDataManager3; }
            set { chartDataManager3 = value; }
        }

        public OlapDataManager ChartDataManager4
        {
            get { return chartDataManager4; }
            set { chartDataManager4 = value; }
        }

        public OlapDataManager GaugeDataManager
        {
            get { return gaugeDataManager; }
            set { gaugeDataManager = value; }
        }

        #endregion

        #region Helper Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// OlapReport for Internet Sales Analysis
        /// </summary>
        /// <returns></returns>
        private OlapReport SimpleDimensions()
        {
            OlapReport olapReport = new OlapReport();
            // Selecting the Cube
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for Column Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Category");

            // Specifying Name for the Measure element
            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Name for Row Dimension Element
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            // Excluded Element
            DimensionElement ExcludedDimension = new DimensionElement();
            ExcludedDimension.Name = "Date";
            ExcludedDimension.AddLevel("Fiscal", "Fiscal Year");
            ExcludedDimension.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2005");
            ExcludedDimension.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow, ExcludedDimension);

            return olapReport;
        }

        /// <summary>
        /// OlapReport based on Product Dimension and Sales Amount.
        /// </summary>
        /// <returns></returns>
        private OlapReport ProductSalesReport()
        {
            OlapReport olapReport = new OlapReport();
            // Selecting the cube
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Name for Row Dimension Element
            dimensionElementRow.Name = "Product";
            dimensionElementRow.AddLevel("Product Categories", "Category");

            // Specifying Name for the Measure element
            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Sales Amount" });

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for Column Dimension Element
            dimensionElementColumn.Name = "Promotion";
            dimensionElementColumn.AddLevel("Promotions", "Promotions");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            return olapReport;
        }

        /// <summary>
        /// OlapReport based on Customer Dimension and Internet gross profit.
        /// </summary>
        /// <returns></returns>
        private OlapReport InternetGrossProfitReportonCountry()
        {
            OlapReport olapReport = new OlapReport();

            olapReport.ShowExpanders = false;

            // Selecting the Cube
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Name for the Row Dimension Element
            dimensionElementRow.Name = "Customer";
            dimensionElementRow.AddLevel("Customer Geography", "Country");

            // Specifying the Measure Element
            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Gross Profit" });

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Column Dimension element
            dimensionElementColumn.Name = "Date";
            dimensionElementColumn.AddLevel("Fiscal", "Fiscal Year");

            // Excluded Element
            DimensionElement ExcludedDimension = new DimensionElement();
            ExcludedDimension.Name = "Date";
            ExcludedDimension.AddLevel("Fiscal", "Fiscal Year");
            ExcludedDimension.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2005");
            ExcludedDimension.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;

            // Adding Column Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            // Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.CategoricalElements.Add(dimensionElementColumn, ExcludedDimension);

            return olapReport;
        }

        /// <summary>
        /// OlapReport the with KPI Elements
        /// </summary>
        /// <returns></returns>
        private OlapReport ReportWithKPI()
        {
            OlapReport report = new OlapReport();

            report.CurrentCubeName = "Adventure Works";

            //Specifying the KPI name

            KpiElements kpiElement = new KpiElements();

            kpiElement.Elements.Add(new KpiElement { Name = "Internet Revenue", ShowKPIGoal = true, ShowKPIStatus = true, ShowKPIValue = true, ShowKPITrend = true });

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the dimension name
            dimensionElementColumn.Name = "Customer";
            //Adding the level with the hierarchy Name
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            //Specifying the measure name
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the dimension name
            dimensionElementRow.Name = "Date";

            //Adding the level with the hierarchy Name
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            report.CategoricalElements.Add(dimensionElementColumn);
            report.CategoricalElements.Add(kpiElement);
            report.CategoricalElements.Add(measureElementColumn);
            report.SeriesElements.Add(dimensionElementRow);

            return report;
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (chartDataManager1 != null)
                    chartDataManager1.Dispose();
                if (chartDataManager2 != null)
                    chartDataManager2.Dispose();
                if (chartDataManager3 != null)
                    chartDataManager3.Dispose();
                if (chartDataManager4 != null)
                    chartDataManager4.Dispose();
                if (gaugeDataManager != null)
                    gaugeDataManager.Dispose();
                if (adomdProvider != null)
                    adomdProvider.Dispose();
            }
        }

        #endregion
    }
}
