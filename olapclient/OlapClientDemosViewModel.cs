#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Collections.Generic;

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
