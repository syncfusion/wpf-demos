#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
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
#else
            this.ProductCategory = "BUSINESS INTELLIGENCE";
#endif
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(PivotGridDemo), Description = "This sample illustrate to show sales data across customer geography and product categories during each fiscal year.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(PivotGridCustomization), Description = "This sample illustrates customization of PivotGrid, such as changing GridLine color, freezing headers, showing/hiding sub-totals etc...", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Field Caption", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(FieldCaption), Description = "This sample illustrates setting caption and duplication of PivotField and PivotCalculation in PivotTable Field List.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "UI Threading", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(UIThreading), Description = "The pivotGrid supports to load data in a different UI thread. That is, PivotGrid control can perform long running operations in a background thread so that we can access other UI controls when PivotGrid is loading. It also loads uniquely for every layout change operation, such as filtering, sorting, drag and drop, FieldList and PivotSchemaDesigner.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Row Pivots Only", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(RowPivotsOnly), Description = "This sample illustrates about multiple functionalities, implemented in PivotGrid by enabling RowPivotsOnly property.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "On-Demand Loading", GroupName = "PERFORMANCE", DemoViewType = typeof(OnDemandLoading),Description = "This sample illustrates the fast performance of loading data through on-demand, index-based engine in PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Selection", GroupName = "SELECTION", DemoViewType = typeof(CellSelection), Description = "This sample illustrates the cell selection in PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Template", GroupName = "APPEARANCE", DemoViewType = typeof(CellTemplate), Description = "This sample illustrates the procedure to apply templates to header cells.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", GroupName = "APPEARANCE", DemoViewType = typeof(ConditionalFormatting), Description = "This sample illustrates the procedure to apply formatting for PivotGrid cells based on certain conditions.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Color Scales", GroupName = "APPEARANCE", DemoViewType = typeof(ColorScales), Description = "This sample illustrates the procedure to apply formatting for Pivot Grid cells based on certain conditions using gradient color scales.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Hyperlink Cell", GroupName = "APPEARANCE", DemoViewType = typeof(HyperlinkCell), Description = "This sample illustrates about hyperlink support in PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "State Persistence", GroupName = "APPEARANCE", DemoViewType = typeof(StatePersistence), Description = "This sample illustrates on how to persist expand and collapse state in PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "ToolTip", GroupName = "APPEARANCE", DemoViewType = typeof(ToolTip), Description = "This sample illustrates the usage of tooltip in PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Summary Display", GroupName = "APPEARANCE", DemoViewType = typeof(SummaryDisplayOption), Description = "This sample illustrates the display options available in PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Field List", GroupName = "FIELD LIST", DemoViewType = typeof(FieldList), Description = "This sample demonstrates about PivotGrid's Field List that allows you to add or remove an item, to or from PivotGrid's Grouping Bar.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Grouping Bar", GroupName = "GROUPING BAR", DemoViewType = typeof(GroupingBar), Description = "This sample illustrates the usage of Grouping Bar in PivotGrid for handling sorting and filtering operations.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Context Menu", GroupName = "GROUPING BAR", DemoViewType = typeof(ContextMenu), Description = "This sample illustrates the context menu support in PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Drill Through", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(DrillThrough), Description = "This sample provides raw item for PivotGrid cell values", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(PivotEditing), Description = "This sample illustrates the usage of editing Value Cells and Total Cells at run time.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(Filtering), Description = "This feature provides programmatic level support to apply filtering (Add, Remove, Insert, RemoveAt and InsertAt) to PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Sorting", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(Sorting), Description = "This feature allows users to sort column values in ascending or descending order by clicking on column header.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Updating", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(PivotUpdating), Description = "This sample illustrates the dynamic update of value cells and how to save changes to the underlying datasource at runtime.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Expression Fields", GroupName = "EXPRESSION FIELDS", DemoViewType = typeof(ExpressionFields), Description = "This sample illustrates the way to add filter expression fields to PivotGrid.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Summaries", GroupName = "SUMMARIES", DemoViewType = typeof(CustomSummary), Description = "This sample illustrates the usage of summary types like Custom and DisplayIfDiscreteValuesEqual and its run-time features through PivotSchemaDesigner.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Exporting", GroupName = "EXPORTING", DemoViewType = typeof(Exporting), Description = "PivotGrid for WPF provides an option for exporting to Excel, Word and PDF formats.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", GroupName = "PRINTING", DemoViewType = typeof(Printing), Description = "This sample illustrates how to print the PivotGrid control.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "SERIALIZATION", DemoViewType = typeof(Serialization), Description = "This sample illustrates the serialization support available in the PivotGrid control.", ThemeMode = ThemeMode.None });
        }
    }
}