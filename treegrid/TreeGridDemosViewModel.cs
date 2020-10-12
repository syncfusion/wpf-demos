#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
            this.Demos = new List<DemoInfo>();

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

            this.Demos.Add(new DemoInfo() { SampleName = "Self-Relational Collection", Description= "This sample showcases how to bind the Self-Relational data by specifying ChildPropertyName and ParentPropertyName in SfTreeGrid.", GroupName = "GETTING STARTED", DemoViewType = typeof(SelfRelationalDataBinding) });
            this.Demos.Add(new DemoInfo() { SampleName = "Nested Collection", Description= "This sample showcases how to bind the Nested Collection data by specifying ChildPropertyName in SfTreeGrid.", GroupName = "GETTING STARTED", DemoViewType = typeof(NestedCollectionDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "On-Demand Loading", Description= "This sample exposes the OnDemand data loading of SfTreeGrid.", GroupName = "GETTING STARTED", DemoViewType = typeof(OnDemandLoadingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Sorting", Description= "This sample showcases the sorting capabilities of data in SfTreeGrid. The SfTreeGrid control allows you to sort the data against one or more columns and provides some sorting functionalities like Tristate Sorting, Showing Sort Orders or Sort Numbers.", GroupName = "SORTING", DemoViewType = typeof(SortingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Sorting", Description= "This sample showcases how to sort a grid column using SortComparer in SfTreeGrid.", GroupName = "SORTING", DemoViewType = typeof(CustomSortingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", Description= "This sample showcases the filtering capabilities of SfTreeGrid.", GroupName = "FILTERING", DemoViewType = typeof(FilteringDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Advanced Filtering", Description= "This sample showcases Excel-inspired filtering capabilities in SfTreeGrid.", GroupName = "FILTERING", DemoViewType = typeof(ExcelLikeFilteringDemo) , ThemeMode= ThemeMode.Default});
            this.Demos.Add(new DemoInfo() { SampleName = "Selection", Description= "This sample showcases the row selection capability of SfTreeGrid. SfTreeGrid control provides an interactive support for selecting rows in different mode with smooth and ease manner. It supports to select a specific row or group of rows programmatically or by Mouse and Keyboard interactions by SelectionMode property. This property provides options like Single, Multiple, Extended and None.", GroupName = "EDITING AND SELECTION", DemoViewType = typeof(SelectionDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", Description= "This sample showcases the editing capability in SfTreeGrid. SfTreeGrid provided options to trigger the edit mode by either with single or double click.", GroupName = "EDITING AND SELECTION", DemoViewType = typeof(EditingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Validation", Description= "This sample showcases the data validation capability in SfTreeGrid by implementing IDataErrorInfo interface.", GroupName = "DATA VALIDATION", DemoViewType = typeof(DataValidationDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "CheckBox Selection", Description= "This sample showcases how nodes can be selected by CheckBox in SfTreeGrid.", GroupName = "NODE CHECKBOX", DemoViewType = typeof(CheckBoxSelection) });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional CheckBox", Description= "This sample showcases how to show CheckBox based on some conditions in SfTreeGrid.", GroupName = "NODE CHECKBOX", DemoViewType = typeof(ConditionalCheckBox) });
            this.Demos.Add(new DemoInfo() { SampleName = "Column Sizer", Description= "This sample showcases the different types of column sizer capabilities in SfTreeGrid. The SfTreeGrid provides in-built feature for customizing the width of the column based on the data present in the cell by defining the ColumnSizer property. This property has different ColumnSizer options like Auto, FillColumn, AutoFillColumn, SizeToCells, SizeToHeader, Star and None.", GroupName = "COLUMNS", DemoViewType = typeof(ColumnSizerDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Stacked Headers", Description = "This sample showcases the Stacked headers capability in SfTreeGrid.", GroupName = "COLUMNS", DemoViewType = typeof(StackedHeaderDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Merge", Description= "This sample showcases the merging capabilities in SfTreeGrid.", GroupName = "COLUMNS", DemoViewType = typeof(CellMerging) });
            this.Demos.Add(new DemoInfo() { SampleName = "Freeze Columns", Description= "This sample showcases the freeze columns capability of STreeGrid. The SfTreeGrid provides support to freeze columns at the left and also at the right similar to Excel freeze panes with the help of FrozenColumnCount and FooterColumnCount.", GroupName = "APPEARANCE", DemoViewType = typeof(FrozenColumnsDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Style", Description= "This sample showcases the conditional formatting capability of SfTreeGrid. The SfTreeGrid control allows you to format the styles of cells and rows based on certain conditions by using Converter and StyleSelector.", GroupName = "APPEARANCE", ThemeMode = ThemeMode.Default, DemoViewType = typeof(CellStyleDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", Description= "This sample showcases the conditional formatting capability of SfTreeGrid. The SfTreeGrid control allows you to format the styles of cells and rows based on certain conditions by using Converter and StyleSelector.", GroupName = "APPEARANCE", ThemeMode = ThemeMode.Default, DemoViewType = typeof(ConditionalFormatting) });
            this.Demos.Add(new DemoInfo() { SampleName = "Level Styling", Description= "This sample showcases the Level Style capabilities of SfTreeGrid. In the SfTreeGrid, the node style can be customized based on its level or depth. This sample illustrates how the background color of the node or row can be changed based on its level.", ThemeMode = ThemeMode.Default, GroupName = "APPEARANCE", DemoViewType = typeof(LevelStylingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Context Menu", Description= "This sample showcases the context menu capabilities of SfTreeGrid. ContextMenu in SfTreeGrid is entirely customizable menu for the extensible functionalities of the Grid. ContextMenu is enabled for various parts of the Grid with the appropriate APIs. SfTreeGrid has a set of APIs that allows access to the context menu in various parts of the Grid.", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(ContextMenuDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Drag and Drop", Description= "This sample showcases the built-in row drag and drop capability of SfTreeGrid.", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(DragAndDropDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Exporting", Description = "This sample showcases the excel exporting capability of SfTreeGrid. The SfGridConverter assembly helps to provide support for exporting data from a SfTreeGrid to an Excel spreadsheet. Our XlsIO libraries are used to support the conversion of the SfTreeGrid contents to Excel.", GroupName = "EXPORT & PRINT", DemoViewType = typeof(ExcelExportingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "PDF Exporting", Description = "This sample showcases the PDF exporting capability of SfTreeGrid. The SfGridConverter assembly helps to provide support for exporting data from a SfTreeGrid to a PDF file. Our Pdf.Base libraries are used to support the conversion of the SfTreeGrid contents to PDF. The exporting to PDF provides the options like Auto Column Width, Auto Row Height, Export Format, Export HyperLink, Repeat Headers, Fit All Columns in one page, PdfGrid Style, PdfGrid LayoutFormat, Customize HeaderCell Style, Customize RecordCell Style, Customize Pdf Header and Footer and export all to PDF.", GroupName = "EXPORT & PRINT", DemoViewType = typeof(PDFExportingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", Description = "This sample showcases the printing capability of SfTreeGrid.", GroupName = "EXPORT & PRINT", DemoViewType = typeof(PrintingDemo) });
        }
    }
}
