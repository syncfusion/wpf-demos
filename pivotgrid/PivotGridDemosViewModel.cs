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
           
            List<Documentation> gettingStartedDocumentation = new List<Documentation>();
            gettingStartedDocumentation.Add(new Documentation { Content = "PivotGridControl - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html") });
            gettingStartedDocumentation.Add(new Documentation { Content = "PivotGrid - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/pivotgrid-getting-started") });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(PivotGridDemo),  Description = "This sample illustrate to show sales data across customer geography and product categories during each fiscal year.", Documentations = gettingStartedDocumentation, ThemeMode = ThemeMode.None});

            List<Documentation> customizationDocumentaion = new List<Documentation>();
            customizationDocumentaion.Add(new Documentation { Content = "PivotGrid - GridLayout API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_GridLayout") });
            customizationDocumentaion.Add(new Documentation { Content = "PivotGrid - GridLineStroke API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_GridLineStroke") });
            customizationDocumentaion.Add(new Documentation { Content = "PivotGrid - Grid Layout Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/grid-layout") });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(PivotGridCustomization), Description = "This sample illustrates customization of PivotGrid, such as changing GridLine color, freezing headers, showing/hiding sub-totals etc...", Documentations = customizationDocumentaion, ThemeMode = ThemeMode.None });

            List<Documentation> fieldCaptionDocumentation = new List<Documentation>();
            fieldCaptionDocumentation.Add(new Documentation { Content = "PivotGrid - PivotFields API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_PivotFields") });
            fieldCaptionDocumentation.Add(new Documentation { Content = "PivotGrid - PivotCalculations API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_PivotCalculations") });
            fieldCaptionDocumentation.Add(new Documentation { Content = "PivotGrid - Pivot Table Field List Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/pivotgrid-field-list") });
            this.Demos.Add(new DemoInfo() { SampleName = "Field Caption", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(FieldCaption), Description = "This sample illustrates setting caption and duplication of PivotField and PivotCalculation in PivotTable Field List.", Documentations = fieldCaptionDocumentation, ThemeMode = ThemeMode.None });
            
            
            this.Demos.Add(new DemoInfo() { SampleName = "UI Threading", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(UIThreading), Description = "The pivotGrid supports to load data in a different UI thread. That is, PivotGrid control can perform long running operations in a background thread so that we can access other UI controls when PivotGrid is loading. It also loads uniquely for every layout change operation, such as filtering, sorting, drag and drop, FieldList and PivotSchemaDesigner.", ThemeMode = ThemeMode.None });
            
            List<Documentation> rowPivotsOnlyDocumentation = new List<Documentation>();
            rowPivotsOnlyDocumentation.Add(new Documentation { Content = "PivotGrid - RowPivotsOnly API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_RowPivotsOnly") });
            rowPivotsOnlyDocumentation.Add(new Documentation { Content = "PivotGrid - Row Pivots Only Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/defining-rowpivotsonly-mode-for-pivotgridcont") });
            this.Demos.Add(new DemoInfo() { SampleName = "Row Pivots Only", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(RowPivotsOnly), Description = "This sample illustrates about multiple functionalities, implemented in PivotGrid by enabling RowPivotsOnly property.", Documentations = rowPivotsOnlyDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> onDemandLoadingDocumentation = new List<Documentation>();
            onDemandLoadingDocumentation.Add(new Documentation { Content = "PivotGrid - EnableOnDemandCalculations API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.PivotAnalysis.Base.PivotEngine.html#Syncfusion_PivotAnalysis_Base_PivotEngine_EnableOnDemandCalculations") });
            onDemandLoadingDocumentation.Add(new Documentation { Content = "PivotGrid - UseIndexedEngine API Referenece", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.PivotAnalysis.Base.PivotEngine.html#Syncfusion_PivotAnalysis_Base_PivotEngine_UseIndexedEngine") });
            this.Demos.Add(new DemoInfo() { SampleName = "On-Demand Loading", GroupName = "PERFORMANCE", DemoViewType = typeof(OnDemandLoading),Description = "This sample illustrates the fast performance of loading data through on-demand, index-based engine in PivotGrid.", Documentations = onDemandLoadingDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> cellSelectionDocumentation = new List<Documentation>();
            cellSelectionDocumentation.Add(new Documentation { Content = "PivotGrid - AllowSelection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_AllowSelection") });
            cellSelectionDocumentation.Add(new Documentation { Content = "PivotGrid - AllowSelectionWithHeaders API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_AllowSelectionWithHeaders") });
            cellSelectionDocumentation.Add(new Documentation { Content = "PivotGrid - Cell Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/selection") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Selection", GroupName = "SELECTION", DemoViewType = typeof(CellSelection), Description = "This sample illustrates the cell selection in PivotGrid.", Documentations = cellSelectionDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> cellTemplateDocumentation = new List<Documentation>();
            cellTemplateDocumentation.Add(new Documentation { Content = "PivotGrid - Cell Templates Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/styles-and-templates#cell-templates") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Template", GroupName = "APPEARANCE", DemoViewType = typeof(CellTemplate), Description = "This sample illustrates the procedure to apply templates to header cells.", Documentations = cellTemplateDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> conditionalFormattingDocumentation = new List<Documentation>();
            conditionalFormattingDocumentation.Add(new Documentation { Content = "PivotGrid - Conditional Formatting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/conditional-formatting") });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", GroupName = "APPEARANCE", DemoViewType = typeof(ConditionalFormatting), Description = "This sample illustrates the procedure to apply formatting for PivotGrid cells based on certain conditions.", Documentations = conditionalFormattingDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> colorScalesDocumentation = new List<Documentation>();
            colorScalesDocumentation.Add(new Documentation { Content = "PivotGrid - ColorScaleConditionalFormats API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_ColorScaleConditionalFormats") });
            colorScalesDocumentation.Add(new Documentation { Content = "PivotGrid - Color Scales Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/conditional-formatting-colorscales") });
            this.Demos.Add(new DemoInfo() { SampleName = "Color Scales", GroupName = "APPEARANCE", DemoViewType = typeof(ColorScales), Description = "This sample illustrates the procedure to apply formatting for Pivot Grid cells based on certain conditions using gradient color scales.", Documentations = colorScalesDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> hyperlinkCellDocumentation = new List<Documentation>();
            hyperlinkCellDocumentation.Add(new Documentation { Content = "PivotGrid - Hyperlink Cells Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/hyperlink-cells") });
            this.Demos.Add(new DemoInfo() { SampleName = "Hyperlink Cell", GroupName = "APPEARANCE", DemoViewType = typeof(HyperlinkCell), Description = "This sample illustrates about hyperlink support in PivotGrid.", Documentations = hyperlinkCellDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> statePersistenceDocumentation = new List<Documentation>();
            statePersistenceDocumentation.Add(new Documentation { Content = "PivotGrid - StatePersistenceEnabled API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_StatePersistenceEnabled") });
            statePersistenceDocumentation.Add(new Documentation { Content = "PivotGrid - State Persistence Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/state-persistence") });
            this.Demos.Add(new DemoInfo() { SampleName = "State Persistence", GroupName = "APPEARANCE", DemoViewType = typeof(StatePersistence), Description = "This sample illustrates on how to persist expand and collapse state in PivotGrid.", Documentations = statePersistenceDocumentation, ThemeMode = ThemeMode.None });

            List<Documentation> toolTipDocumentation = new List<Documentation>();
            toolTipDocumentation.Add(new Documentation { Content = "PivotGrid - ToolTipEnabled API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_ToolTipEnabled") });
            toolTipDocumentation.Add(new Documentation { Content = "PivotGrid - ToolTip Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/tooltip") });
            this.Demos.Add(new DemoInfo() { SampleName = "ToolTip", GroupName = "APPEARANCE", DemoViewType = typeof(ToolTip), Description = "This sample illustrates the usage of tooltip in PivotGrid.", Documentations = toolTipDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> summaryDisplayDocumentation = new List<Documentation>();
            summaryDisplayDocumentation.Add(new Documentation { Content = "PivotGrid - Display Options Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/display-options") });
            this.Demos.Add(new DemoInfo() { SampleName = "Summary Display", GroupName = "APPEARANCE", DemoViewType = typeof(SummaryDisplayOption), Description = "This sample illustrates the display options available in PivotGrid.", Documentations = summaryDisplayDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> fieldListDocumentation = new List<Documentation>();
            fieldListDocumentation.Add(new Documentation { Content = "PivotGrid - ShowFieldList API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_ShowFieldList") });
            fieldListDocumentation.Add(new Documentation { Content = "PivotGrid - Field List Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/pivotgrid-field-list") });
            this.Demos.Add(new DemoInfo() { SampleName = "Field List", GroupName = "FIELD LIST", DemoViewType = typeof(FieldList), Description = "This sample demonstrates about PivotGrid's Field List that allows you to add or remove an item, to or from PivotGrid's Grouping Bar.", Documentations = fieldListDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> groupingBarDocumentation = new List<Documentation>();
            groupingBarDocumentation.Add(new Documentation { Content = "PivotGrid - ShowGroupingBar API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_ShowGroupingBar") });
            groupingBarDocumentation.Add(new Documentation { Content = "PivotGrid - Grouping Bar Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/grouping-bar") });
            this.Demos.Add(new DemoInfo() { SampleName = "Grouping Bar", GroupName = "GROUPING BAR", DemoViewType = typeof(GroupingBar), Description = "This sample illustrates the usage of Grouping Bar in PivotGrid for handling sorting and filtering operations.", Documentations = groupingBarDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> contextMenuDocumentation = new List<Documentation>();
            contextMenuDocumentation.Add(new Documentation { Content = "PivotGrid - Context Menu Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/grouping-bar-context-menu") });
            this.Demos.Add(new DemoInfo() { SampleName = "Context Menu", GroupName = "GROUPING BAR", DemoViewType = typeof(ContextMenu), Description = "This sample illustrates the context menu support in PivotGrid.", Documentations = contextMenuDocumentation, ThemeMode = ThemeMode.None });
            
            
            this.Demos.Add(new DemoInfo() { SampleName = "Drill Through", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(DrillThrough), Description = "This sample provides raw item for PivotGrid cell values", ThemeMode = ThemeMode.None });

            List<Documentation> editingDocumentation = new List<Documentation>();
            editingDocumentation.Add(new Documentation { Content = "PivotGrid - EnableValueEditing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_EnableValueEditing") });
            editingDocumentation.Add(new Documentation { Content = "PivotGrid - AllowEditingOfTotalCells API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotEditingManager.html#Syncfusion_Windows_Controls_PivotGrid_PivotEditingManager_AllowEditingOfTotalCells") });
            editingDocumentation.Add(new Documentation { Content = "PivotGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/editing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(PivotEditing), Description = "This sample illustrates the usage of editing Value Cells and Total Cells at run time.", Documentations = editingDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> filteringDocumentation = new List<Documentation>();
            filteringDocumentation.Add(new Documentation { Content = "PivotGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/filtering") });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(Filtering), Description = "This feature provides programmatic level support to apply filtering (Add, Remove, Insert, RemoveAt and InsertAt) to PivotGrid.", Documentations = filteringDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> sortingDocumentation = new List<Documentation>();
            sortingDocumentation.Add(new Documentation { Content = "PivotGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/sorting") });
            this.Demos.Add(new DemoInfo() { SampleName = "Sorting", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(Sorting), Description = "This feature allows users to sort column values in ascending or descending order by clicking on column header.", Documentations = sortingDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> updatingDocumentation = new List<Documentation>();
            updatingDocumentation.Add(new Documentation { Content = "PivotGrid - EnableUpdating API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_EnableUpdating") });
            updatingDocumentation.Add(new Documentation { Content = "PivotGrid - Updating Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/updating") });
            this.Demos.Add(new DemoInfo() { SampleName = "Updating", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(PivotUpdating), Description = "This sample illustrates the dynamic update of value cells and how to save changes to the underlying datasource at runtime.", Documentations = updatingDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> expressionFieldsDocumentation = new List<Documentation>();
            expressionFieldsDocumentation.Add(new Documentation { Content = "PivotGrid - Expression Fields Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/expression-fields") });
            this.Demos.Add(new DemoInfo() { SampleName = "Expression Fields", GroupName = "EXPRESSION FIELDS", DemoViewType = typeof(ExpressionFields), Description = "This sample illustrates the way to add filter expression fields to PivotGrid.", Documentations = expressionFieldsDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> customSummariesDocumentation = new List<Documentation>();
            customSummariesDocumentation.Add(new Documentation { Content = "PivotGrid - Custom Summary Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/runtime-custom-summary") });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Summaries", GroupName = "SUMMARIES", DemoViewType = typeof(CustomSummary), Description = "This sample illustrates the usage of summary types like Custom and DisplayIfDiscreteValuesEqual and its run-time features through PivotSchemaDesigner.", Documentations = customSummariesDocumentation, ThemeMode = ThemeMode.None });

            List<Documentation> exportingDocumentation = new List<Documentation>();
            exportingDocumentation.Add(new Documentation { Content = "PivotGrid - Exporting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/exporting") });
            this.Demos.Add(new DemoInfo() { SampleName = "Exporting", GroupName = "EXPORTING", DemoViewType = typeof(Exporting), Description = "PivotGrid for WPF provides an option for exporting to Excel, Word and PDF formats.", Documentations = exportingDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> printingDocumentation = new List<Documentation>();
            printingDocumentation.Add(new Documentation { Content = "PivotGrid - Printing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/print-and-print-preview") });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", GroupName = "PRINTING", DemoViewType = typeof(Printing), Description = "This sample illustrates how to print the PivotGrid control.", Documentations = printingDocumentation, ThemeMode = ThemeMode.None });
            
            List<Documentation> serializationDocumentation = new List<Documentation>();
            serializationDocumentation.Add(new Documentation { Content = "PivotGrid - Serialization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/pivot-grid/serializationdeserialization") });
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "SERIALIZATION", DemoViewType = typeof(Serialization), Description = "This sample illustrates the serialization support available in the PivotGrid control.", Documentations = serializationDocumentation, ThemeMode = ThemeMode.None });
        }
    }
}
