#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Collections.Generic;

    public class OlapChartDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new OlapChartProductDemos());
            return productdemos;
        }
    }

    public class OlapChartProductDemos : ProductDemo
    {
        public OlapChartProductDemos()
        {
            this.Product = "Olap Chart";
            this.ProductCategory = "BUSINESS INTELLIGENCE";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "GETTING STARTED", DemoViewType = typeof(OlapChartDemo), Description = "This sample illustrates the Excel like feature to add hierarchies dynamically in OlapChart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Configuration ", GroupName = "GETTING STARTED", DemoViewType = typeof(OlapChartConfiguration), Description = "This sample illustrates the steps as in the User Guide to add OlapChart in an application.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Customer Growth Analysis", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(CustomerGrowthAnalysis), Description = "This sample illustrates the customer growth analysis on certain countries over the months of fiscal year 2004.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Customer Range Analysis", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(CustomerRangeAnalysis), Description = "This sample illustrates the distance and quantity of orders placed for a specific set of products through internet rather than resellers.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Internet Revenue Analysis", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(InternetRevenueAnalysis), Description = "This sample illustrates the analysis on internet revenue over certain fiscal years.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Order Details Analysis", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(OrderDetailsAnalysis), Description = "This sample illustrates the orders placed over the years through resellers for a set of products.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Product Sales Analysis", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(SalesOfProductsAnalysis), Description = "This sample illustrates a comparative analysis of sales among products for a particular year.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Product Trend Analysis", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(ProductTrendAnalysis), Description = "This sample illustrates a comparative analysis of earnings through products sales for a particular year.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Sales Reason Analysis", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(SalesReasonAnalysis), Description = "This sample illustrates a contribution analysis for sales made in different countries.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "KPI", GroupName = "DEFINING REPORTS", DemoViewType = typeof(KPI), Description = "This sample illustrates about rendering of Key Performance Indicators(KPI) in OlapChart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "MDX Query", GroupName = "DEFINING REPORTS", DemoViewType = typeof(MDXQuery), Description = "This sample illustrates the ability to load OLAP data in the OlapChart with drill up and drill down functionalities by passing different MDX queries to the OlapDataManager.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Report-in-File", GroupName = "DEFINING REPORTS", DemoViewType = typeof(ReportInFile), Description = "This sample illustrates the way to load a set of reports from a file to OlapDataManager and set respective one as current report to OlapChart. You can create these reports using our Report Builder Utility which is available as Add-On in our Dashboard", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Reports-in-Code", GroupName = "DEFINING REPORTS", DemoViewType = typeof(ReportsInCode), Description = "This sample illustrates about reading and displaying different elements of OLAP data in OlapChart from an offline cube.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "XAML Configuration", GroupName = "DEFINING REPORTS", DemoViewType = typeof(XAMLConfiguration), Description = "This sample enables you to add an OlapReport created in XAML and bind the data through XAML configuration.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Area Chart", GroupName = "CHART TYPES", DemoViewType = typeof(AreaChart), Description = "This sample illustrates the visualization of multi-dimensional OLAP data through various Area Chart types. It shows Area, Stacking Area, Step Area and Spline Area Chart types.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Bar Chart", GroupName = "CHART TYPES", DemoViewType = typeof(BarChart), Description = "This sample illustrates the visualization of multi-dimensional OLAP data through various Bar Chart types. It shows Bar and Stacking Bar Chart types.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Column Chart", GroupName = "CHART TYPES", DemoViewType = typeof(ColumnChart), Description = "This sample illustrates the visualization of multi-dimensional OLAP data through various Column Chart types. It shows Column, Stacking Column and Stacking Column 100 Chart types.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Line Chart", GroupName = "CHART TYPES", DemoViewType = typeof(LineChart), Description = "This sample illustrates the visualization of multi-dimensional OLAP data through various Line Chart types. Such Line Charts are ideal for visualizing trends. It displays Line, Spline, Rotated Spline and Step Line Chart types.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Pie Chart", GroupName = "CHART TYPES", DemoViewType = typeof(PieChart), Description = "This sample illustrates the visualization of OLAP data through Pie Chart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Scatter Chart", GroupName = "CHART TYPES", DemoViewType = typeof(ScatterChart), Description = "This sample illustrates the visualization of multi-dimensional OLAP data through Scatter Chart. Templates allow data points to be rendered as either ellipse, triangle or polygon.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Appearance", GroupName = "APPEARANCE", DemoViewType = typeof(Appearance), Description = "This sample illustrates the customization of plot area and data points.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Chart Animations", GroupName = "APPEARANCE", DemoViewType = typeof(ChartAnimations), Description = "This sample illustrates the different types of animations in each series of OlapChart for different chart types.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Expanders Visibility", GroupName = "APPEARANCE", DemoViewType = typeof(ExpandersVisibility), Description = "This sample illustrates about drill-down functionality through expanders in OlapChart. You can also hide the expanders to prevent this functionality.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Series Customization", GroupName = "APPEARANCE", DemoViewType = typeof(SeriesCustomization), Description = "This sample illustrates Chart Series customization through series template binding.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Watermark", GroupName = "APPEARANCE", DemoViewType = typeof(Watermark), Description = "This sample illustrates the insertion of watermark text or image into the background of OlapChart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Drill State", GroupName = "DATA RELATION", DemoViewType = typeof(DrillState), Description = "This sample illustrates the different ways to drill members in OlapChart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Drill Types", GroupName = "DATA RELATION", DemoViewType = typeof(DrillTypes), Description = "This sample illustrates the different drill types supported in OlapChart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", GroupName = "PRINTING", DemoViewType = typeof(PrintingChart), Description = "This sample demonstrates the printing features of OlapChart that allows printing in color mode or in black-and-white mode. It also allows printing a specific part of OlapChart through the cropping feature.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Paging", GroupName = "PAGING", DemoViewType = typeof(Paging), Description = "This sample illustrates the paging feature supported in OlapChart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Exporting", GroupName = "EXPORTING", DemoViewType = typeof(ExportingChart), Description = "OlapChart WPF provides option for exporting its content to Excel, Word and PDF formats.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Zooming and Scrolling", GroupName = "ZOOMING AND SCROLLING", DemoViewType = typeof(ZoomingAndScrolling), Description = "This sample illustrates about zooming and scrolling features supported in OlapChart.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "SERIALIZATION", DemoViewType = typeof(Serialization), Description = "This sample illustrates how to serialize or de-serialize OlapReport settings along with the appearance of OlapChart.", ThemeMode = ThemeMode.None });
        }
    }
}
