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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.spreadsheetdemos.wpf
{
    public class SpreadsheetDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SpreadsheetProductDemos() );
            return productdemos;
        }
    }

    public class SpreadsheetProductDemos : ProductDemo
    {
        public SpreadsheetProductDemos()
        {
            this.Product = "Spreadsheet";
            this.ProductCategory = "FILE VIEWERS AND EDITORS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "Essential SfSpreadsheet is an Excel inspired control that allows you to create, edit, view and format the Microsoft Excel files without Excel installed. SfSpreadsheet provides absolute ease of use UI experience with integrated ribbon to cover any possible business scenario.", GroupName = "GETTING STARTED", DemoViewType = typeof(GettingStarted), DemoLauchMode=DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Formula", Description = "SfSpreadsheet calculation engine offers automated calculation over a formula, expression or cross sheet references. SfSpreadsheet calculation engine is preloaded with 409 formulas covering a broad range of business functions.", GroupName = "GETTING STARTED", DemoViewType = typeof(FormulaDemo), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Formatting", Description = "This sample showcases various cell formatting options like font, background, alignment, cell borders, etc., in the SfSpreadsheet.", GroupName = "GETTING STARTED", DemoViewType = typeof(CellFormatting), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", Description = "This sample showcases the sorting and filtering support in the Spreadsheet control.", GroupName = "DATA MANIPULATION", DemoViewType = typeof(FilteringDemo), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Outlining", Description = "This sample showcases the outline support. SfSpreadsheet provides support for both row and column-wise grouping, and multi-level grouping like Excel.", GroupName = "DATA MANIPULATION", DemoViewType = typeof(OutliningDemo), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", Description = "This sample showcases the conditional formatting support in the SfSpreadsheet.Conditional formatting allows you to categorize cell styles that are dynamically applied, based on cell values and conditions that you define.", GroupName = "DATA VISUALIZAATION", DemoViewType = typeof(ConditionalFormattingDemo), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Advanced Conditional Formatting", Description = "This sample showcases advanced conditional formatting like data bars, icon sets and color scales in the SfSpreadsheet.", GroupName = "DATA VISUALIZAATION", DemoViewType = typeof(AdvancedConditionalFormatting), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Chart", Description = "This sample showcases how to import the Excel chart into the SfSpreadsheet.", GroupName = "DATA VISUALIZAATION", DemoViewType = typeof(ChartDemo), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "GraphicCell", Description = "This sample showcases the Image and RichTextBox importing support in SfSpreadsheet.", GroupName = "DATA VISUALIZAATION", DemoViewType = typeof(GraphicCellDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Sparklines", Description = "This sample showcases the Sparkline importing support in the SfSpreadsheet", GroupName = "DATA VISUALIZAATION", DemoViewType = typeof(SparklinesDemo), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Management", Description = "This sample showcases the import and export of DataTable in the Spreadsheet control.", GroupName = "MISCELLANEOUS", DemoViewType = typeof(DataManagementDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Exporting", Description = "This sample showcases the exporting of SfSpreadsheet into various file formats such as PDF, HTML and Image.", GroupName = "MISCELLANEOUS", DemoViewType = typeof(ExportingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", Description = "This sample demonstrates the printing of Spreadsheet control using PdfViewerControl", GroupName = "MISCELLANEOUS", DemoViewType = typeof(PrintingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Customization", Description = "This sample showcases the cell customization support in Spreadsheet control.", GroupName = "MISCELLANEOUS", DemoViewType = typeof(CellCustomizationDemo), DemoLauchMode = DemoLauchMode.Window });

        }
    }
}
