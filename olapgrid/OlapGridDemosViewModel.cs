#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

namespace syncfusion.olapgriddemos.wpf
{

    public class OlapGridDemosViewModel : DemoBrowserViewModel
    {

        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new OlapGridProductDemos());
            return productdemos;
        }
    }

    public class OlapGridProductDemos : ProductDemo
    {
        public OlapGridProductDemos()
        {
            this.Product = "Olap Grid";
            this.ProductCategory = "BUSINESS INTELLIGENCE";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "GETTING STARTED", DemoViewType = typeof(OlapGridDemo), Description = "This sample illustrates the slice and dice operation which is performed at runtime in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "KPI ", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(KPI), Description = "This sample illustrates Key Performance Indicators such as goal, status, trend and value based on the product revenue in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Member Properties", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(MemberProperties), Description = "This sample illustrates the option available in OlapGrid to bind a member along with its properties. Member properties include basic information about each member in each tuple, including member name, parent level and number of children.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Transaction View", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(TransactionView), Description = "This sample illustrates the transaction view of sales details on each quantity value in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "MDX Query", GroupName = "DEFINING REPORTS", DemoViewType = typeof(MDXQuery), Description = "This sample illustrates the ability to load OLAP data in the OlapGrid with drill up and drill down functionalities by passing different MDX queries to the OlapDataManager.",ThemeMode=ThemeMode.None});
            this.Demos.Add(new DemoInfo() { SampleName = "Report-in-File", GroupName = "DEFINING REPORTS", DemoViewType = typeof(ReportInFile), Description = "This sample illustrates how to de-serialize a cube model template and display OLAP data in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Reports-in-Code", GroupName = "DEFINING REPORTS", DemoViewType = typeof(ReportsInCode), Description = "This sample illustrates about reading different OLAP data elements from an offline cube and displaying them in OlapGrid.", ThemeMode = ThemeMode.None });
            //this.Demos.Add(new DemoInfo() { SampleName = "XAML Configuration", GroupName = "DEFINING REPORTS", DemoViewType = typeof(XAMLConfiguration), Description = "This sample enables you to add an OlapReport created in XAML and bind the OLAP data through XAML configuration.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Appearance", GroupName = "APPEARANCE", DemoViewType = typeof(Appearance), Description = "This sample illustrates various properties to customize the appearance of OlapGrid, such as its column header, row header, summary cells and cell border.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Template", GroupName = "APPEARANCE", DemoViewType = typeof(CellTemplate), Description = "This sample illustrates the way to apply template for value cells.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", GroupName = "APPEARANCE", DemoViewType = typeof(ConditionalFormatting), Description = "This sample illustrates the way to apply formatting to Grid cells based on certain conditions.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Frozen Header", GroupName = "APPEARANCE", DemoViewType = typeof(FrozenHeader), Description = "This sample showcases frozen row and column headers thereby allowing only value cells to scroll.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Grid Layout", GroupName = "APPEARANCE", DemoViewType = typeof(GridLayout), Description = "This sample illustrates different types of layouts in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Hyperlink Cell", GroupName = "APPEARANCE", DemoViewType = typeof(HyperlinkCell), Description = "This sample illustrates hyperlink feature in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Drill State", GroupName = "DATA RELATION", DemoViewType = typeof(DrillState), Description = "This sample illustrates different ways to drill members in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Drill Through", GroupName = "DATA RELATION", DemoViewType = typeof(DrillThrough), Description = "This sample illustrates analysis of Reseller Sales Amount of Product over Countries, followed by the Promotion of Product.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Drill Types", GroupName = "DATA RELATION", DemoViewType = typeof(DrillTypes), Description = "This sample illustrates different drill types in OlapGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Selection", GroupName = "SELECTION", DemoViewType = typeof(CellSelection), Description = "This sample illustrates the way to select value cells.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Paging", GroupName = "PAGING", DemoViewType = typeof(GridPaging), Description = "This sample illustrates the paging feature of OlapPager to segment large CellSet, to get rendered in a more conducive way.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Exporting", GroupName = "EXPORTING", DemoViewType = typeof(ExportingGrid), Description = "OlapGrid WPF provides option for exporting its content to Excel, Word and PDF formats.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "SERIALIZATION", DemoViewType = typeof(Serialization), Description = "This sample illustrates how to serialize or de-serialize OlapReport settings along with the appearance of OlapGrid control, such as its column header, row header, summary cells and cell border.", ThemeMode = ThemeMode.None });
        }
    }
}
