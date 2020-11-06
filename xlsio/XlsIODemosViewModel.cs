#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

namespace syncfusion.xlsiodemos.wpf
{
    public class XlsIODemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new XlsIOProductDemos());
            return productdemos;
        }
    }
    public class XlsIOProductDemos : ProductDemo
    {
        public XlsIOProductDemos()
        {
            this.Product = "XlsIO";
            this.ProductCategory = "FILE FORMAT";
			this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();
            
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Budget Planner",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This sample demonstrates how to create a simple Budget planner using XlsIO.",
                DemoViewType = typeof(BudgetPlanner)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Attendance Tracker",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This sample demonstrates how to use Attendance Tracker in spreadsheets using XlsIO.",
                DemoViewType = typeof(AttendanceTracker)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Create Spreadsheet",
                GroupName = "GETTING STARTED",
                Description = "This sample demonstrates how to create a simple Excel document with formulas and formatting using XlsIO.",
                DemoViewType = typeof(CreateSpreadsheet)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Find And Extract",
                GroupName = "GETTING STARTED",
                Description = "This sample demonstrates how to extract data from a spreadsheet using XlsIO.",
                DemoViewType = typeof(FindAndExtract)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Conditional Formatting",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply conditional formats using XlsIO.",
                DemoViewType = typeof(ConditionalFormatting)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Format Cells",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply formatting to the cells using XlsIO.",
                DemoViewType = typeof(FormatCells)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Styles And Formatting",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply styles and formatting using XlsIO.",
                DemoViewType = typeof(StylesAndFormatting)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Formula",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use formulas in spreadsheets using XlsIO.",
                DemoViewType = typeof(Formula)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Compute All Formulas",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use formulas in spreadsheets using XlsIO.",
                DemoViewType = typeof(ComputeAllFormulas)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Table Formula",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use table formula in spreadsheets using XlsIO.",
                DemoViewType = typeof(TableFormula)
            });
#if !NET50					
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "External Formula",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use external formula in spreadsheets using XlsIO.",
                DemoViewType = typeof(ExternalFormula)
            });
#endif		
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Data Validation",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use data validation in spreadsheets using XlsIO.",
                DemoViewType = typeof(DataValidation)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Form Controls",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use form controls in spreadsheet using XlsIO.",
                DemoViewType = typeof(FormControls)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Interactive Features",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use interactive features in spreadsheet using XlsIO.",
                DemoViewType = typeof(InteractiveFeatures)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Ole Object",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use OLE objects in spreadsheet using XlsIO.",
                DemoViewType = typeof(OleObject)
            });
			
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Range Manipulation",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to manipulate cells in a spreadsheet using XlsIO.",
                DemoViewType = typeof(RangeManipulation)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Import HTML Table",
                GroupName = "DATA BINDING",
                Description = "This sample demonstrates how to convert HTML table to worksheet using Essential XlsIO.",
                DemoViewType = typeof(ImportHTMLTable)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Chart Worksheet",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create a simple chart sheet using XlsIO.",
                DemoViewType = typeof(ChartWorksheet)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Embedded Chart",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create a simple chart using XlsIO.",
                DemoViewType = typeof(EmbeddedChart)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Sparklines",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create sparkline charts using XlsIO.",
                DemoViewType = typeof(Sparklines)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Box and Whisker",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Box and Whisker chart using XlsIO.",
                DemoViewType = typeof(BoxAndWhisker)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Funnel Chart",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Funnel chart using XlsIO.",
                DemoViewType = typeof(Funnel)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Treemap",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Treemap chart using XlsIO.",
                DemoViewType = typeof(Treemap)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Sunburst",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Sunburst chart using XlsIO.",
                DemoViewType = typeof(Sunburst)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Row Column Manipulation",
                GroupName = "SHEET MANAGEMENT",
                Description = "This sample demonstrates how to customize rows and columns in a spreadsheet using XlsIO.",
                DemoViewType = typeof(RowColumnManipulation)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Worksheet Management",
                GroupName = "SHEET MANAGEMENT",
                Description = "This sample demonstrates how to customize spreadsheets using XlsIO.",
                DemoViewType = typeof(WorksheetManagement)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Worksheet To Image",
                GroupName = "EXPORT",
                Description = "This sample demonstrates how to convert spreadsheets to image using XlsIO.",
                DemoViewType = typeof(WorksheetToImage)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To PDF",
                GroupName = "EXPORT",
                Description = "This sample demonstrates how to convert Excel spreadsheets to PDF document using XlsIO.",
                Tag = Tag.Updated,
            DemoViewType = typeof(ExcelToPDF)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To ODS",
                GroupName = "EXPORT",
                Description = "This sample demonstrates how to convert Excel spreadsheets to OpenDocument spreadsheets using XlsIO.",
                DemoViewType = typeof(ExcelToODS)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To JSON",
                GroupName = "EXPORT",
                Description = "This sample demonstrates the conversion of Excel documents to JSON file using Essential XlsIO.",
                DemoViewType = typeof(ExcelToJSON)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "AutoShapes",
                GroupName = "SHAPES",
                Description = "This sample demonstrates how to use AutoShapes in spreadsheets using XlsIO.",
                DemoViewType = typeof(AutoShape)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Group Shapes",
                GroupName = "SHAPES",
                Description = "This sample demonstrates how to use group shapes in spreadsheets using XlsIO.",
                DemoViewType = typeof(GroupShape)
            });

        }
    }
}

