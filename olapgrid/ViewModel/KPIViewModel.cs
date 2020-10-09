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
    using System.Collections.Generic;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class KPIViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private List<string> productList;
        private string selectedProduct;
        private List<string> reportList;
        private string selectedReport;
        private bool enalbeProductList = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIViewModel"/> class.
        /// </summary>
        public KPIViewModel()
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
            olapDataManager.SetCurrentReport(LoadBasicKPI());
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
        /// Gets or sets the product list.
        /// </summary>
        /// <value>The product list.</value>
        public List<string> ProductList
        {
            get
            {
                productList = productList ?? new List<string> { "Bikes", "Accessories", "Clothing", "Components" };
                return productList;
            }
            set { productList = value; }
        }


        /// <summary>
        /// Gets or sets the name of the selected product.
        /// </summary>
        /// <value>The name of the selected product.</value>
        public string SelectedProductName
        {
            get
            {
                selectedProduct = selectedProduct ?? "Bikes";
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                this.GridDataManager.SetCurrentReport(LoadBasicKPI());
                this.GridDataManager.NotifyElementModified();
            }
        }


        /// <summary>
        /// Gets or sets the report list.
        /// </summary>
        /// <value>The report list.</value>
        public List<string> ReportList
        {
            get
            {
                reportList = reportList ?? new List<string> { "Simple KPI", "Complex KPI" };
                return reportList;
            }
            set { reportList = value; }
        }


        /// <summary>
        /// Gets or sets the name of the selected report.
        /// </summary>
        /// <value>The name of the selected report.</value>
        public string SelectedReportName
        {
            get
            {
                selectedReport = selectedReport ?? "Simple KPI";
                return selectedReport;
            }
            set
            {
                selectedReport = value;
                if (selectedReport == "Complex KPI")
                {
                    this.EnableProductList = false;
                    this.GridDataManager.SetCurrentReport(LoadComplexKPI());
                }
                else
                {
                    this.EnableProductList = true;
                    this.GridDataManager.SetCurrentReport(LoadBasicKPI());
                }
                this.GridDataManager.NotifyElementModified();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [enable product list].
        /// </summary>
        /// <value><c>true</c> if [enable product list]; otherwise, <c>false</c>.</value>
        public bool EnableProductList
        {
            get { return enalbeProductList; }
            set
            {
                enalbeProductList = value;
                RaisePropertyChanged("EnableProductList");
            }
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

        #region LoadingBasicKPI
        OlapReport LoadBasicKPI()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the name for Dimension Element for Column
            dimensionElementColumn.Name = "Product";
            dimensionElementColumn.AddLevel("Product Categories", "Category");
            dimensionElementColumn.Hierarchy.LevelElements["Category"].Add(this.SelectedProductName);
            dimensionElementColumn.Hierarchy.LevelElements["Category"].IncludeAvailableMembers = true;

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the name for Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Gross Profit" });

            KpiElements kpiElement = new KpiElements();
            kpiElement.Elements.Add(new KpiElement { Name = "Internet Revenue", ShowKPIGoal = true, ShowKPIStatus = true, ShowKPIValue = true, ShowKPITrend = true });

            DimensionElement dimensionElementRow = new DimensionElement();
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            olapReport.CategoricalElements.Add(kpiElement);
            olapReport.SeriesElements.Add(dimensionElementRow);

            return olapReport;
        }
        #endregion

        #region LoadingComplexKPI
        OlapReport LoadComplexKPI()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            KpiElements kpiElement = new KpiElements();
            kpiElement.Elements.Add(new KpiElement { Name = "Internet Revenue", ShowKPIGoal = true, ShowKPIStatus = true, ShowKPIValue = true, ShowKPITrend = true });

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementColumn.Name = "Employee";
            dimensionElementColumn.AddLevel("Employee Department", "Department");

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            olapReport.CategoricalElements.Add(dimensionElementRow);
            olapReport.CategoricalElements.Add(kpiElement);
            olapReport.SeriesElements.Add(dimensionElementColumn);
            return olapReport;
        }
        #endregion

        #endregion
    }
}
