#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M1 2.5C1 1.67157 1.67157 1 2.5 1H3V3H1V2.5ZM4 3V1H11.5C12.3284 1 13 1.67157 13 2.5V3H4ZM4 4H13V11.5C13 12.3284 12.3284 13 11.5 13H4V4ZM3 4V13H2.5C1.67157 13 1 12.3284 1 11.5V4H3ZM2.5 0C1.11929 0 0 1.11929 0 2.5V3.5V11.5C0 12.8807 1.11929 14 2.5 14H3.5H11.5C12.8807 14 14 12.8807 14 11.5V3.5V2.5C14 1.11929 12.8807 0 11.5 0H3.5H2.5ZM10.1 7H10.5C10.5 8.80451 9.88509 9.67705 9.22991 10.0976C8.8456 10.3443 8.41026 10.4599 8 10.4911V10.1C8 9.85279 7.71777 9.71167 7.52 9.86L6.32 10.76C6.16 10.88 6.16 11.12 6.32 11.24L7.52 12.14C7.71777 12.2883 8 12.1472 8 11.9V11.4931C8.5735 11.4605 9.20053 11.3048 9.77009 10.9392C10.7816 10.2899 11.5 9.0529 11.5 7H11.9C12.1472 7 12.2883 6.71777 12.14 6.52L11.24 5.32C11.12 5.16 10.88 5.16 10.76 5.32L9.86 6.52C9.71167 6.71777 9.85279 7 10.1 7Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/BusinessIntilegence.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The OlapGrid is a highly customizable, presentation-quality business control that utilizes OLAP data sources to generate multi-dimensional views.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Olap Grid.png", UriKind.RelativeOrAbsolute));
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
