#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class OlapClientDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new OlapClientProductDemos());
            return productdemos;
        }
    }

    public class OlapClientProductDemos : ProductDemo
    {
        public OlapClientProductDemos()
        {
            this.Product = "Olap Client";
            this.ProductCategory = "BUSINESS INTELLIGENCE";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M1.5 0C0.671573 0 0 0.671573 0 1.5V4.5V6.5V12.5C0 12.7761 0.223858 13 0.5 13C0.776142 13 1 12.7761 1 12.5V6.5V5H13V8.5C13 8.77614 13.2239 9 13.5 9C13.7761 9 14 8.77614 14 8.5V4.5V1.5C14 0.671573 13.3284 0 12.5 0H1.5ZM13 4H1V1.5C1 1.22386 1.22386 1 1.5 1H12.5C12.7761 1 13 1.22386 13 1.5V4ZM11.9596 6.69696C12.0684 6.44314 11.9508 6.14921 11.697 6.04043C11.4431 5.93165 11.1492 6.04923 11.0404 6.30304L9.88162 9.00693C9.43927 9.05911 9.08532 9.39999 9.01339 9.83598L6.63535 10.7277C6.4626 10.5855 6.24128 10.5 6 10.5C5.44772 10.5 5 10.9477 5 11.5C5 11.5512 5.00385 11.6015 5.01128 11.6507L3.18765 13.1096C2.97202 13.2821 2.93706 13.5967 3.10957 13.8123C3.28207 14.028 3.59672 14.0629 3.81235 13.8904L5.63585 12.4316C5.7487 12.4758 5.87152 12.5 6 12.5C6.49642 12.5 6.90836 12.1383 6.98661 11.664L9.36465 10.7723C9.5374 10.9145 9.75872 11 10 11C10.5523 11 11 10.5523 11 10C11 9.77528 10.9259 9.56787 10.8007 9.40089L11.9596 6.69696Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/BusinessIntilegence.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The OlapClient control enables users to browse and analyze multi-dimensional data in cube format using dimensions, measures, named sets, and KPIs.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Olap Client.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Calculated Members", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(CalculatedMembers), Description = "This sample illustrates how to create and manage calculated measures and members in OlapClient.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "MDX Query", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(MDXQuery), Description = "This sample illustrates the ability to load OLAP data into OlapClient control with drill up and drill down functionalities in OlapGrid and OlapChart by passing different MDX queries to OlapDataManager.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Configuration", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(Configuration), Description = "This sample illustrates about visualization of OLAP data through OlapChart and OlapGrid embedded in OlapClient control. Several properties are exposed to handle OlapReport manipulations, filtering, sorting and toggling sub-element's visibility.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Virtual KPI", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(VirtualKPI), Description = "This sample illustrates how to create and manage Virtual KPI elements in OlapClient.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Drill Through", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(DrillThrough), Description = "This sample illustrates the analysis of Reseller Sales Amount of Product over Countries, followed by the Promotion of the Product.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "APPEARANCE", DemoViewType = typeof(Customization), Description = "This sample illustrates about customizing the appearance of OlapChart and OlapGrid embedded in OlapClient control.", ThemeMode = ThemeMode.None });
            //this.Demos.Add(new DemoInfo() { SampleName = "Report Serialization", GroupName = "SERIALIZATION", DemoViewType = typeof(ReportSerialization), Description = "This sample illustrates the storage and retrieval of OlapReport as a stream that is transferred between database and OlapClient.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Paging", GroupName = "PAGING", DemoViewType = typeof(Paging), Description = "This sample illustrates the paging feature of OlapClient to segment large CellSet, to get rendered in a more conducive way.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Adventure Works Dashboard", GroupName = "OLAP DASHBOARD", DemoViewType = typeof(AdventureWorksDashboard), Description = "This sample allows you to view different reports of Adventure Works database in a single window.", ThemeMode = ThemeMode.None });
            //this.Demos.Add(new DemoInfo() { SampleName = "BI Dashboard", GroupName = "OLAP DASHBOARD", DemoViewType = typeof(BIDashboard), Description = "The dashboard providing an efficient way of reporting.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Cube Browser", GroupName = "OLAP DASHBOARD", DemoViewType = typeof(CubeBrowser), Description = "This sample illustrates a simple way of creating a cube browser using the OlapDataManager.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "GP Analysis Dashboard", GroupName = "OLAP DASHBOARD", DemoViewType = typeof(GPAnalysisDashboard), Description = "GP (Gross Profit) Analysis of Adventure Works database.", ThemeMode = ThemeMode.None });
        }
    }
}
