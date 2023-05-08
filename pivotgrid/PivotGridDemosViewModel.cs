#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pivotgriddemos.wpf
{
    public class PivotGridDemosViewModel : DemoBrowserViewModel
    {

        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new PivotGridProductDemos());
            return productdemos;
        }
    }

    public class PivotGridProductDemos : ProductDemo
    {
        public PivotGridProductDemos()
        {
            this.Product = "Pivot Grid";
#if NET50 || NETCORE
            this.ProductCategory = "GRIDS";
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Grids.png", UriKind.RelativeOrAbsolute));
#else
            this.ProductCategory = "BUSINESS INTELLIGENCE";
#endif
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V12C13 12.5523 12.5523 13 12 13H2C1.44772 13 1 12.5523 1 12V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V2ZM4 5C4 4.72386 3.77614 4.5 3.5 4.5C3.22386 4.5 3 4.72386 3 5L3 11C3 11.2761 3.22386 11.5 3.5 11.5C3.77614 11.5 4 11.2761 4 11L4 5ZM4.5 3.5C4.5 3.22386 4.72386 3 5 3L11 3C11.2761 3 11.5 3.22386 11.5 3.5C11.5 3.77614 11.2761 4 11 4L5 4C4.72386 4 4.5 3.77614 4.5 3.5ZM9.1 7H9.5C9.5 8.80451 8.88509 9.67705 8.22991 10.0976C7.8456 10.3443 7.41026 10.4599 7 10.4911V10.1C7 9.85279 6.71777 9.71167 6.52 9.86L5.32 10.76C5.16 10.88 5.16 11.12 5.32 11.24L6.52 12.14C6.71777 12.2883 7 12.1472 7 11.9V11.4931C7.5735 11.4605 8.20053 11.3048 8.77009 10.9392C9.78157 10.2899 10.5 9.0529 10.5 7H10.9C11.1472 7 11.2883 6.71777 11.14 6.52L10.24 5.32C10.12 5.16 9.88 5.16 9.76 5.32L8.86 6.52C8.71167 6.71777 8.85279 7 9.1 7Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/BusinessIntilegence.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The PivotGridControl organizes and summarizes business data in a cross-table format. Key features include custom calculations and export to Excel and more.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/PivotGrid.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(PivotGridDemo), Description = "This sample illustrate to show sales data across customer geography and product categories during each fiscal year."});
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(PivotGridCustomization), Description = "This sample illustrates customization of PivotGrid, such as changing GridLine color, freezing headers, showing/hiding sub-totals etc..."});
            this.Demos.Add(new DemoInfo() { SampleName = "Field Caption", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(FieldCaption), Description = "This sample illustrates setting caption and duplication of PivotField and PivotCalculation in PivotTable Field List."});
            this.Demos.Add(new DemoInfo() { SampleName = "UI Threading", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(UIThreading), Description = "The pivotGrid supports to load data in a different UI thread. That is, PivotGrid control can perform long running operations in a background thread so that we can access other UI controls when PivotGrid is loading. It also loads uniquely for every layout change operation, such as filtering, sorting, drag and drop, FieldList and PivotSchemaDesigner."});
            this.Demos.Add(new DemoInfo() { SampleName = "Row Pivots Only", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(RowPivotsOnly), Description = "This sample illustrates about multiple functionalities, implemented in PivotGrid by enabling RowPivotsOnly property."});
            this.Demos.Add(new DemoInfo() { SampleName = "On-Demand Loading", GroupName = "PERFORMANCE", DemoViewType = typeof(OnDemandLoading),Description = "This sample illustrates the fast performance of loading data through on-demand, index-based engine in PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Selection", GroupName = "SELECTION", DemoViewType = typeof(CellSelection), Description = "This sample illustrates the cell selection in PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Template", GroupName = "APPEARANCE", DemoViewType = typeof(CellTemplate), Description = "This sample illustrates the procedure to apply templates to header cells."});
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", GroupName = "APPEARANCE", DemoViewType = typeof(ConditionalFormatting), Description = "This sample illustrates the procedure to apply formatting for PivotGrid cells based on certain conditions."});
            this.Demos.Add(new DemoInfo() { SampleName = "Color Scales", GroupName = "APPEARANCE", DemoViewType = typeof(ColorScales), Description = "This sample illustrates the procedure to apply formatting for Pivot Grid cells based on certain conditions using gradient color scales."});
            this.Demos.Add(new DemoInfo() { SampleName = "Hyperlink Cell", GroupName = "APPEARANCE", DemoViewType = typeof(HyperlinkCell), Description = "This sample illustrates about hyperlink support in PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "State Persistence", GroupName = "APPEARANCE", DemoViewType = typeof(StatePersistence), Description = "This sample illustrates on how to persist expand and collapse state in PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "ToolTip", GroupName = "APPEARANCE", DemoViewType = typeof(ToolTip), Description = "This sample illustrates the usage of tooltip in PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Summary Display", GroupName = "APPEARANCE", DemoViewType = typeof(SummaryDisplayOption), Description = "This sample illustrates the display options available in PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Field List", GroupName = "FIELD LIST", DemoViewType = typeof(FieldList), Description = "This sample demonstrates about PivotGrid's Field List that allows you to add or remove an item, to or from PivotGrid's Grouping Bar."});
            this.Demos.Add(new DemoInfo() { SampleName = "Grouping Bar", GroupName = "GROUPING BAR", DemoViewType = typeof(GroupingBar), Description = "This sample illustrates the usage of Grouping Bar in PivotGrid for handling sorting and filtering operations."});
            this.Demos.Add(new DemoInfo() { SampleName = "Context Menu", GroupName = "GROUPING BAR", DemoViewType = typeof(ContextMenu), Description = "This sample illustrates the context menu support in PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Drill Through", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(DrillThrough), Description = "This sample provides raw item for PivotGrid cell values"});
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(PivotEditing), Description = "This sample illustrates the usage of editing Value Cells and Total Cells at run time."});
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(Filtering), Description = "This feature provides programmatic level support to apply filtering (Add, Remove, Insert, RemoveAt and InsertAt) to PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Sorting", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(Sorting), Description = "This feature allows users to sort column values in ascending or descending order by clicking on column header."});
            this.Demos.Add(new DemoInfo() { SampleName = "Updating", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(PivotUpdating), Description = "This sample illustrates the dynamic update of value cells and how to save changes to the underlying datasource at runtime."});
            this.Demos.Add(new DemoInfo() { SampleName = "Expression Fields", GroupName = "EXPRESSION FIELDS", DemoViewType = typeof(ExpressionFields), Description = "This sample illustrates the way to add filter expression fields to PivotGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Summaries", GroupName = "SUMMARIES", DemoViewType = typeof(CustomSummary), Description = "This sample illustrates the usage of summary types like Custom and DisplayIfDiscreteValuesEqual and its run-time features through PivotSchemaDesigner."});
            this.Demos.Add(new DemoInfo() { SampleName = "Exporting", GroupName = "EXPORTING", DemoViewType = typeof(Exporting), Description = "PivotGrid for WPF provides an option for exporting to Excel, Word and PDF formats."});
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", GroupName = "PRINTING", DemoViewType = typeof(Printing), Description = "This sample illustrates how to print the PivotGrid control."});
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "SERIALIZATION", DemoViewType = typeof(Serialization), Description = "This sample illustrates the serialization support available in the PivotGrid control."});
        }
    }
}
