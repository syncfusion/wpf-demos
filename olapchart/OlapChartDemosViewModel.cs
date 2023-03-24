#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M1 0C0.447715 0 0 0.447715 0 1V2C0 2.55228 0.447715 3 1 3H2C2.55228 3 3 2.55228 3 2V1C3 0.447715 2.55228 0 2 0H1ZM5 1C4.72386 1 4.5 1.22386 4.5 1.5C4.5 1.77614 4.72386 2 5 2H11C11.2761 2 11.5 1.77614 11.5 1.5C11.5 1.22386 11.2761 1 11 1H5ZM9 5C7.67885 5 6.50729 5.6405 5.77892 6.62793L8.80733 8.31965L10.4994 5.29053C10.0364 5.10317 9.53024 5 9 5ZM5 9L5.00011 9.03064C5.00085 9.12636 5.00502 9.22225 5.01267 9.31813C5.07559 10.1067 5.37095 10.859 5.8614 11.4798C5.94474 11.5852 6.03307 11.6861 6.12599 11.7821C6.15596 11.8131 6.18642 11.8435 6.21736 11.8735C6.6546 12.2969 7.18452 12.6167 7.76802 12.8056C8.16641 12.9345 8.5803 12.9994 8.99455 13L9.01062 13C9.37366 12.999 9.73682 12.9486 10.0899 12.8487C10.7109 12.6728 11.2779 12.3499 11.7444 11.9101C11.7961 11.8613 11.8464 11.8112 11.8955 11.7598C11.9465 11.7062 11.9962 11.6511 12.0444 11.5945C12.5576 10.9924 12.8806 10.2516 12.9728 9.46588C12.9896 9.32263 12.9986 9.17906 12.9998 9.03577L13 9L12.9998 8.96476C12.9944 8.34628 12.8455 7.73505 12.5621 7.18021C12.3857 6.83498 12.1611 6.51916 11.8966 6.24144C11.8521 6.19471 11.8065 6.14906 11.7598 6.10453C11.6377 5.98818 11.5082 5.87947 11.3719 5.77915L9.68035 8.80733C9.41101 9.28949 8.8018 9.46201 8.31965 9.19267L5.29146 7.50108C5.10351 7.9661 5.00451 8.46282 5.00015 8.96523L5 9ZM9 4C6.25091 4 4.02001 6.21862 4.00013 8.96302C3.99995 8.98746 3.99995 9.01191 4.00013 9.03638C4.00966 10.3735 4.54403 11.5858 5.40749 12.4776C5.44494 12.5163 5.48302 12.5544 5.5217 12.5919C6.41935 13.4613 7.64193 13.9973 8.98968 14L9 14C10.3376 14 11.5525 13.4748 12.4497 12.6193C12.509 12.5628 12.5668 12.5049 12.6233 12.4456C13.4674 11.5582 13.9889 10.3611 13.9998 9.04222C14.0001 9.01332 14.0001 8.98443 13.9998 8.95555C13.9881 7.614 13.4481 6.39855 12.5777 5.50713C12.5384 5.46691 12.4985 5.42735 12.4579 5.38846C11.5598 4.52841 10.3416 4 9 4ZM1.5 4.5C1.77614 4.5 2 4.72386 2 5V11C2 11.2761 1.77614 11.5 1.5 11.5C1.22386 11.5 1 11.2761 1 11V5C1 4.72386 1.22386 4.5 1.5 4.5Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/BusinessIntilegence.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The OLAP chart control is a lightweight control that allows you to efficiently visualize multi-dimensional data from the OLAP data source.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Olap Chart.png", UriKind.RelativeOrAbsolute));
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
