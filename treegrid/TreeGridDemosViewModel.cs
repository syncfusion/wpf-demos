#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
﻿using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.treegriddemos.wpf
{
    public class TreeGridDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new TreeGridProductDemos());
            return productdemos;
        }
    }

    public class TreeGridProductDemos : ProductDemo
    {
        public TreeGridProductDemos()
        {
            this.Product = "TreeGrid";
            this.ProductCategory = "GRIDS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V4H1V2C1 1.44772 1.44772 1 2 1ZM6 5H1V12C1 12.5523 1.44772 13 2 13H12C12.5523 13 13 12.5523 13 12V9L6.5 9C6.22392 8.99993 6 8.7761 6 8.5V5ZM7 8V5H13V8L7 8ZM14 12V2C14 0.895431 13.1046 0 12 0H2C0.895431 0 0 0.89543 0 2V12C0 13.1046 0.89543 14 2 14H12C13.1046 14 14 13.1046 14 12ZM4.68 10.26L3.48 9.36C3.28223 9.21167 3 9.35279 3 9.6V11.4C3 11.6472 3.28223 11.7883 3.48 11.64L4.68 10.74C4.84 10.62 4.84 10.38 4.68 10.26ZM5.14 1.98L4.24 3.18C4.12 3.34 3.88 3.34 3.76 3.18L2.86 1.98C2.71167 1.78223 2.85279 1.5 3.1 1.5L4.9 1.5C5.14721 1.5 5.28833 1.78223 5.14 1.98Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Grids.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.ControlDescription = "The TreeGrid control displays the hierarchical or self-relational data in a tree structure with multicolumn interface like multicolumn treeview.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/TreeGrid.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "File Explorer",
                Description = "This sample showcases the folder directory model with SfTreeGrid. The information is loaded on demand as the user opens each parent folder.",
                ImagePath = @"/syncfusion.treegriddemos.wpf;component/Assets/treegrid/FileExplorer_Icon.png",
                GroupName = "PRODUCT SHOWCASE",
                DemoViewType = typeof(FileExplorer),
                DemoLauchMode = DemoLauchMode.Window,
                ThemeMode = ThemeMode.Default
            });
            List<Documentation> gettingStartedDocumentation = new List<Documentation>();
            gettingStartedDocumentation.Add(new Documentation { Content = "TreeGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html") });
            gettingStartedDocumentation.Add(new Documentation { Content = "TreeGrid - GettingStarted Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/getting-started") });
            gettingStartedDocumentation.Add(new Documentation { Content = "TreeGrid - Self-Relational Collection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/getting-started#binding-self-relational-data-in-sftreegrid") });            
            this.Demos.Add(new DemoInfo() { SampleName = "Self-Relational Collection", Description= "This sample showcases how to bind the Self-Relational data by specifying ChildPropertyName and ParentPropertyName in SfTreeGrid.", GroupName = "GETTING STARTED", DemoViewType = typeof(SelfRelationalDataBinding), Documentations = gettingStartedDocumentation });

            List<Documentation> nestedCollectionDocumentation = new List<Documentation>();            
            nestedCollectionDocumentation.Add(new Documentation { Content = "TreeGrid - Nested Collection Documentation",Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/getting-started#binding-nested-collection-with-sftreegrid") });            
            this.Demos.Add(new DemoInfo() { SampleName = "Nested Collection", Description= "This sample showcases how to bind the Nested Collection data by specifying ChildPropertyName in SfTreeGrid.", GroupName = "GETTING STARTED", DemoViewType = typeof(NestedCollectionDemo), Documentations = nestedCollectionDocumentation });

            List<Documentation> onDemandLoadingDocumentation = new List<Documentation>();
            onDemandLoadingDocumentation.Add(new Documentation { Content = "TreeGrid - LoadOnDemandCommand API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_LoadOnDemandCommand") });            
            onDemandLoadingDocumentation.Add(new Documentation { Content = "TreeGrid - On-Demand Loading Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/load-on-demand") });
            this.Demos.Add(new DemoInfo() { SampleName = "On-Demand Loading", Description= "This sample exposes the OnDemand data loading of SfTreeGrid.", GroupName = "GETTING STARTED", DemoViewType = typeof(OnDemandLoadingDemo), Documentations = onDemandLoadingDocumentation });

            List<Documentation> sortingDocumentation = new List<Documentation>();
            sortingDocumentation.Add(new Documentation { Content = "TreeGrid - AllowSorting API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_AllowSorting") });
            sortingDocumentation.Add(new Documentation { Content = "TreeGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/sorting") });            
            this.Demos.Add(new DemoInfo() { SampleName = "Sorting", Description= "This sample showcases the sorting capabilities of data in SfTreeGrid. The SfTreeGrid control allows you to sort the data against one or more columns and provides some sorting functionalities like Tristate Sorting, Showing Sort Orders or Sort Numbers.", GroupName = "SORTING", DemoViewType = typeof(SortingDemo), Documentations = sortingDocumentation });

            List<Documentation> customSortingDocumentation = new List<Documentation>();
            customSortingDocumentation.Add(new Documentation { Content = "TreeGrid - Custom Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/sorting#custom-sorting") });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Sorting", Description= "This sample showcases how to sort a column based on length of the string using SortComparer in SfTreeGrid.", GroupName = "SORTING", DemoViewType = typeof(CustomSortingDemo), Documentations = customSortingDocumentation });

            List<Documentation> filteringDocumentation = new List<Documentation>();
            filteringDocumentation.Add(new Documentation { Content = "TreeGrid - FilterLevel API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_FilterLevel") });
            filteringDocumentation.Add(new Documentation { Content = "TreeGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/filtering") });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", Description= "This sample showcases the filtering capabilities of SfTreeGrid.", GroupName = "FILTERING", DemoViewType = typeof(FilteringDemo), Documentations = filteringDocumentation });

            List<Documentation> advancedFilteringDocumentation = new List<Documentation>();
            advancedFilteringDocumentation.Add(new Documentation { Content = "TreeGrid - AllowFiltering", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_AllowFiltering") });            
            advancedFilteringDocumentation.Add(new Documentation { Content = "TreeGrid - Advanced Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/filtering#advanced-filtering") });
            this.Demos.Add(new DemoInfo() { SampleName = "Advanced Filtering", Description= "This sample showcases Excel-inspired filtering capabilities in SfTreeGrid.", GroupName = "FILTERING", DemoViewType = typeof(ExcelLikeFilteringDemo) , ThemeMode= ThemeMode.None, Documentations = advancedFilteringDocumentation });

            List<Documentation> selectionDocumentation = new List<Documentation>();
            selectionDocumentation.Add(new Documentation { Content = "TreeGrid - SelectionMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_SelectionMode") });
            selectionDocumentation.Add(new Documentation { Content = "TreeGrid - NavigationMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_NavigationMode") });
            selectionDocumentation.Add(new Documentation { Content = "TreeGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/selection") });
            this.Demos.Add(new DemoInfo() { SampleName = "Selection", Description= "This sample showcases the row selection capability of SfTreeGrid. SfTreeGrid control provides an interactive support for selecting rows in different mode with smooth and ease manner. It supports to select a specific row or group of rows programmatically or by Mouse and Keyboard interactions by SelectionMode property. This property provides options like Single, Multiple, Extended and None.", GroupName = "EDITING AND SELECTION", DemoViewType = typeof(SelectionDemo), Documentations = selectionDocumentation });

            List<Documentation> editingDocumentation = new List<Documentation>();
            editingDocumentation.Add(new Documentation { Content = "TreeGrid - AllowEditing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridColumnBase.html#Syncfusion_UI_Xaml_Grid_GridColumnBase_AllowEditing") });
            editingDocumentation.Add(new Documentation { Content = "TreeGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/editing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", Description= "This sample showcases the editing capability in SfTreeGrid. SfTreeGrid provided options to trigger the edit mode by either with single or double click.", GroupName = "EDITING AND SELECTION", DemoViewType = typeof(EditingDemo), Documentations = editingDocumentation });

            List<Documentation> dataValidationDocumentation = new List<Documentation>();
            dataValidationDocumentation.Add(new Documentation { Content = "TreeGrid - GridValidationMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_GridValidationMode") });            
            dataValidationDocumentation.Add(new Documentation { Content = "TreeGrid - Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/data-validation") });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Validation", Description= "This sample showcases the data validation capability in SfTreeGrid by implementing IDataErrorInfo interface.", GroupName = "DATA VALIDATION", DemoViewType = typeof(DataValidationDemo), Documentations = dataValidationDocumentation });

            List<Documentation> checkboxSelectionDocumentation = new List<Documentation>();
            checkboxSelectionDocumentation.Add(new Documentation { Content = "TreeGrid - Node CheckBox Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/node-checkbox") });
            this.Demos.Add(new DemoInfo() { SampleName = "CheckBox Selection", Description= "This sample showcases how nodes can be selected by CheckBox in SfTreeGrid.", GroupName = "NODE CHECKBOX", DemoViewType = typeof(CheckBoxSelection), Documentations = checkboxSelectionDocumentation });

            List<Documentation> conditionalCheckBoxDocumentation = new List<Documentation>();
            conditionalCheckBoxDocumentation.Add(new Documentation { Content = "TreeGrid - Disabling CheckBox Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/node-checkbox#disabling-checkbox-for-certain-nodes") });            
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional CheckBox", Description = "This sample showcases how to enable/disable CheckBox based on child nodes in SfTreeGrid.", GroupName = "NODE CHECKBOX", DemoViewType = typeof(ConditionalCheckBox), ThemeMode = ThemeMode.None, Documentations = conditionalCheckBoxDocumentation });

            List<Documentation> columnSizerDocumentation = new List<Documentation>();
            columnSizerDocumentation.Add(new Documentation { Content = "TreeGrid - ColumnSizer API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_ColumnSizer") });
            columnSizerDocumentation.Add(new Documentation { Content = "TreeGrid - Column Sizing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/column-sizing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Column Sizer", Description= "This sample showcases the different types of column sizer capabilities in SfTreeGrid. The SfTreeGrid provides in-built feature for customizing the width of the column based on the data present in the cell by defining the ColumnSizer property. This property has different ColumnSizer options like Auto, FillColumn, AutoFillColumn, SizeToCells, SizeToHeader, Star and None.", GroupName = "COLUMNS", DemoViewType = typeof(ColumnSizerDemo), Documentations = columnSizerDocumentation });

            List<Documentation> stackedHeadersDocumentation = new List<Documentation>();
            stackedHeadersDocumentation.Add(new Documentation { Content = "TreeGrid - StackedHeaderRows API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_StackedHeaderRows") });
            stackedHeadersDocumentation.Add(new Documentation { Content = "TreeGrid - Stacked Headers Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/columns#stacked-headers") });
            this.Demos.Add(new DemoInfo() { SampleName = "Stacked Headers", Description = "This sample showcases the Stacked headers capability in SfTreeGrid.", GroupName = "COLUMNS", DemoViewType = typeof(StackedHeaderDemo), Documentations = stackedHeadersDocumentation });

            List<Documentation> cellMergeDocumentation = new List<Documentation>();            
            cellMergeDocumentation.Add(new Documentation { Content = "TreeGrid - Merge Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/mergecell") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Merge", Description= "This sample showcases the merging capabilities in SfTreeGrid.", GroupName = "COLUMNS", DemoViewType = typeof(CellMerging), Documentations = cellMergeDocumentation });

            List<Documentation> freezeColumnsDocumentation = new List<Documentation>();
            freezeColumnsDocumentation.Add(new Documentation { Content = "TreeGrid - FrozenColumnCount API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_FrozenColumnCount") });
            freezeColumnsDocumentation.Add(new Documentation { Content = "TreeGrid - FooterColumnCount API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_FooterColumnCount") });
            freezeColumnsDocumentation.Add(new Documentation { Content = "TreeGrid - Freezing Columns Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/columns#freezing-columns") });
            this.Demos.Add(new DemoInfo() { SampleName = "Freeze Columns", Description= "This sample showcases the freeze columns capability of SfTreeGrid. The SfTreeGrid provides support to freeze columns at the left and also at the right similar to Excel freeze panes with the help of FrozenColumnCount and FooterColumnCount.", GroupName = "APPEARANCE", DemoViewType = typeof(FrozenColumnsDemo), Documentations = freezeColumnsDocumentation });

            List<Documentation> cellStyleDocumentation = new List<Documentation>();
            cellStyleDocumentation.Add(new Documentation { Content = "TreeGrid - Styling Cells based on Records Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/conditional-styling#style-cells-based-on-record-using-converter") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Style", Description= "This sample showcases the conditional formatting capability of SfTreeGrid. The SfTreeGrid control allows you to format the styles of cells and rows based on certain conditions by using Converter and StyleSelector.", GroupName = "APPEARANCE", ThemeMode = ThemeMode.None, DemoViewType = typeof(CellStyleDemo), Documentations = cellStyleDocumentation });

            List<Documentation> conditionalFormattingDocumentation = new List<Documentation>();
            conditionalFormattingDocumentation.Add(new Documentation { Content = "TreeGrid - Conditional Styling Rows Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/conditional-styling#conditional-styling-in-wpf-treegrid-sftreegrid-1") });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", Description= "This sample showcases the conditional formatting capability of SfTreeGrid. The SfTreeGrid control allows you to format the styles of cells and rows based on certain conditions by using Converter and StyleSelector.", GroupName = "APPEARANCE", ThemeMode = ThemeMode.None, DemoViewType = typeof(ConditionalFormatting), Documentations = conditionalFormattingDocumentation });

            List<Documentation> levelStylingDocumentation = new List<Documentation>();
            levelStylingDocumentation.Add(new Documentation { Content = "TreeGrid - Conditional Styling Rows Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/conditional-styling#conditional-styling-in-wpf-treegrid-sftreegrid-1") });
            this.Demos.Add(new DemoInfo() { SampleName = "Level Styling", Description= "This sample showcases the Level Style capabilities of SfTreeGrid. In the SfTreeGrid, the node style can be customized based on its level or depth. This sample illustrates how the background color of the node or row can be changed based on its level.", ThemeMode = ThemeMode.None, GroupName = "APPEARANCE", DemoViewType = typeof(LevelStylingDemo), Documentations = levelStylingDocumentation });

            List<Documentation> contextMenuDocumentation = new List<Documentation>();
            contextMenuDocumentation.Add(new Documentation { Content = "TreeGrid - Context Menu Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/interactive-features#context-menu") });
            this.Demos.Add(new DemoInfo() { SampleName = "Context Menu", Description = "This sample showcases the context menu capabilities of SfTreeGrid. ContextMenu in SfTreeGrid is entirely customizable menu for the extensible functionalities of the Grid. ContextMenu is enabled for various parts of the Grid with the appropriate APIs. SfTreeGrid has a set of APIs that allows access to the context menu in various parts of the Grid.", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(ContextMenuDemo), ThemeMode = ThemeMode.None, Documentations = contextMenuDocumentation });

            List<Documentation> dragAndDropDocumentation = new List<Documentation>();
            dragAndDropDocumentation.Add(new Documentation { Content = "TreeGrid - AllowDraggingRows API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_AllowDraggingRows") });            
            dragAndDropDocumentation.Add(new Documentation { Content = "TreeGrid - Drag and Drop Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/interactive-features#drag-and-drop-row") });
            this.Demos.Add(new DemoInfo() { SampleName = "Drag and Drop", Description = "This sample showcases the built-in row drag and drop capability of SfTreeGrid.", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(DragAndDropDemo), Documentations = dragAndDropDocumentation });
            
            List<Documentation> excelExportingDocumentation = new List<Documentation>();            
            excelExportingDocumentation.Add(new Documentation { Content = "TreeGrid - Export to Excel Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/export-to-excel") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Exporting", Description = "This sample showcases the excel exporting capability of SfTreeGrid. The SfGridConverter assembly helps to provide support for exporting data from a SfTreeGrid to an Excel spreadsheet. Our XlsIO libraries are used to support the conversion of the SfTreeGrid contents to Excel.", GroupName = "EXPORT & PRINT", DemoViewType = typeof(ExcelExportingDemo), Documentations = excelExportingDocumentation });

            List<Documentation> pdfExportingDocumentation = new List<Documentation>();            
            pdfExportingDocumentation.Add(new Documentation { Content = "TreeGrid - Export to PDF Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/export-to-pdf") });
            this.Demos.Add(new DemoInfo() { SampleName = "PDF Exporting", Description = "This sample showcases the PDF exporting capability of SfTreeGrid. The SfGridConverter assembly helps to provide support for exporting data from a SfTreeGrid to a PDF file. Our Pdf.Base libraries are used to support the conversion of the SfTreeGrid contents to PDF. The exporting to PDF provides the options like Auto Column Width, Auto Row Height, Export Format, Export HyperLink, Repeat Headers, Fit All Columns in one page, PdfGrid Style, PdfGrid LayoutFormat, Customize HeaderCell Style, Customize RecordCell Style, Customize Pdf Header and Footer and export all to PDF.", GroupName = "EXPORT & PRINT", DemoViewType = typeof(PDFExportingDemo), Documentations = pdfExportingDocumentation });

            List<Documentation> printingDocumentation = new List<Documentation>();
            printingDocumentation.Add(new Documentation { Content = "TreeGrid - Printing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treegrid/printing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", Description = "This sample showcases the printing capability of SfTreeGrid.", GroupName = "EXPORT & PRINT", DemoViewType = typeof(PrintingDemo), Documentations = printingDocumentation });
        }
    }
}
