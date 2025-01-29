#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M11 3.5V12C11 12.5523 10.5523 13 10 13H2C1.44772 13 1 12.5523 1 12V2C1 1.44772 1.44772 1 2 1H6H8.5V2C8.5 2.82843 9.17157 3.5 10 3.5H11ZM12 12V3.41421C12 3.149 11.8946 2.89464 11.7071 2.70711L9.29289 0.292893C9.10536 0.105357 8.851 0 8.58579 0H6H2C0.895431 0 0 0.89543 0 2V12C0 13.1046 0.895431 14 2 14H10C11.1046 14 12 13.1046 12 12ZM5.5 6V8H3V6H5.5ZM6.5 6H9V8H6.5V6ZM9 9H6.5V11H9V9ZM5.5 11V9H3V11H5.5ZM2 6C2 5.44772 2.44772 5 3 5H9C9.55228 5 10 5.44772 10 6V11C10 11.5523 9.55228 12 9 12H3C2.44772 12 2 11.5523 2 11V6Z"),
                Width = 12,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileViewersAndEditors.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Spreadsheet is an Excel-inspired control featuring an integrated ribbon covering all possible business scenarios and a built-in calculation engine.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Spreadsheet.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();

            List<Documentation> gettingStartedDocumentation = new List<Documentation>();
            gettingStartedDocumentation.Add(new Documentation { Content = "Spreadsheet - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Spreadsheet.SfSpreadsheet.html") });
            gettingStartedDocumentation.Add(new Documentation { Content = "Spreadsheet - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/getting-started") });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "Essential SfSpreadsheet is an Excel inspired control that allows you to create, edit, view and format the Microsoft Excel files without Excel installed. SfSpreadsheet provides absolute ease of use UI experience with integrated ribbon to cover any possible business scenario.", GroupName = "GETTING STARTED", DemoViewType = typeof(GettingStarted), Documentations = gettingStartedDocumentation, DemoLauchMode=DemoLauchMode.Window });
            
            List<Documentation> formulaDocumentation = new List<Documentation>();
            formulaDocumentation.Add(new Documentation { Content = "Spreadsheet - Formula Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/formulas") });
            this.Demos.Add(new DemoInfo() { SampleName = "Formula", Description = "SfSpreadsheet calculation engine offers automated calculation over a formula, expression or cross sheet references. SfSpreadsheet calculation engine is preloaded with 409 formulas covering a broad range of business functions.", GroupName = "GETTING STARTED", DemoViewType = typeof(FormulaDemo), DemoLauchMode = DemoLauchMode.Window, Documentations = formulaDocumentation });
            
            List<Documentation> cellFormattingDocumentation = new List<Documentation>();
            cellFormattingDocumentation.Add(new Documentation { Content = "Spreadsheet - Cell Formatting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/formatting") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Formatting", Description = "This sample showcases various cell formatting options like font, background, alignment, cell borders, etc., in the SfSpreadsheet.", GroupName = "GETTING STARTED", DemoViewType = typeof(CellFormatting), DemoLauchMode = DemoLauchMode.Window, Documentations = cellFormattingDocumentation });
            
            List<Documentation> filteringDocumentation = new List<Documentation>();
            filteringDocumentation.Add(new Documentation { Content = "Spreadsheet - AllowFiltering API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Spreadsheet.SfSpreadsheet.html#Syncfusion_UI_Xaml_Spreadsheet_SfSpreadsheet_AllowFiltering") });
            filteringDocumentation.Add(new Documentation { Content = "Spreadsheet - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/sorting-and-filtering#filtering") });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", Description = "This sample showcases the sorting and filtering support in the Spreadsheet control.", GroupName = "DATA MANIPULATION", DemoViewType = typeof(FilteringDemo), Documentations = filteringDocumentation, DemoLauchMode = DemoLauchMode.Window });
            
            List<Documentation> outliningDocumentation = new List<Documentation>();
            outliningDocumentation.Add(new Documentation { Content = "Spreadsheet - Outline Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/outline") });
            this.Demos.Add(new DemoInfo() { SampleName = "Outlining", Description = "This sample showcases the outline support. SfSpreadsheet provides support for both row and column-wise grouping, and multi-level grouping like Excel.", GroupName = "DATA MANIPULATION", DemoViewType = typeof(OutliningDemo), DemoLauchMode = DemoLauchMode.Window, Documentations = outliningDocumentation });
            
            List<Documentation> conditionalFormattingDocumentation = new List<Documentation>();
            conditionalFormattingDocumentation.Add(new Documentation { Content = "Spreadsheet - AddCondition API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.XlsIO.IConditionalFormats.html#Syncfusion_XlsIO_IConditionalFormats_AddCondition") });
            conditionalFormattingDocumentation.Add(new Documentation { Content = "Spreadsheet - Conditional Formatting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/conditional-formatting") });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", Description = "This sample showcases the conditional formatting support in the SfSpreadsheet.Conditional formatting allows you to categorize cell styles that are dynamically applied, based on cell values and conditions that you define.", GroupName = "DATA VISUALIZATION", DemoViewType = typeof(ConditionalFormattingDemo), DemoLauchMode = DemoLauchMode.Window, Documentations = conditionalFormattingDocumentation });
            
            List<Documentation> advancedConditionalFormattingDocumentation = new List<Documentation>();
            advancedConditionalFormattingDocumentation.Add(new Documentation { Content = "Spreadsheet - Data Bars Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/conditional-formatting#data-bars") });
            advancedConditionalFormattingDocumentation.Add(new Documentation { Content = "Spreadsheet - Color Scales Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/conditional-formatting#color-scales") });
            advancedConditionalFormattingDocumentation.Add(new Documentation { Content = "Spreadsheet - Icon Sets Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/conditional-formatting#icon-sets") });
            this.Demos.Add(new DemoInfo() { SampleName = "Advanced Conditional Formatting", Description = "This sample showcases advanced conditional formatting like data bars, icon sets and color scales in the SfSpreadsheet.", GroupName = "DATA VISUALIZATION", DemoViewType = typeof(AdvancedConditionalFormatting), DemoLauchMode = DemoLauchMode.Window, Documentations = advancedConditionalFormattingDocumentation });
            
            List<Documentation> chartDocumentation = new List<Documentation>();
            chartDocumentation.Add(new Documentation { Content = "Spreadsheet - Chart Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/shapes#charts") });
            this.Demos.Add(new DemoInfo() { SampleName = "Chart", Description = "This sample showcases how to import the Excel chart into the SfSpreadsheet.", GroupName = "DATA VISUALIZATION", DemoViewType = typeof(ChartDemo), DemoLauchMode = DemoLauchMode.Window, Documentations = chartDocumentation });
            
            this.Demos.Add(new DemoInfo() { SampleName = "GraphicCell", Description = "This sample showcases the Image and RichTextBox importing support in SfSpreadsheet.", GroupName = "DATA VISUALIZATION", DemoViewType = typeof(GraphicCellDemo) });
            
            List<Documentation> sparklinesDocumentation = new List<Documentation>();
            sparklinesDocumentation.Add(new Documentation { Content = "Spreadsheet - SparklineCellRenderer API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.SpreadsheetHelper.SparklineCellRenderer.html") });
            sparklinesDocumentation.Add(new Documentation { Content = "Spreadsheet - Sparklines Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/shapes#sparklines") });
            this.Demos.Add(new DemoInfo() { SampleName = "Sparklines", Description = "This sample showcases the Sparkline importing support in the SfSpreadsheet", GroupName = "DATA VISUALIZATION", DemoViewType = typeof(SparklinesDemo), DemoLauchMode = DemoLauchMode.Window, Documentations = sparklinesDocumentation });
            
            List<Documentation> dataManagementDocumentation = new List<Documentation>();
            dataManagementDocumentation.Add(new Documentation() { Content = "Spreadsheet - Data Management Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/data-management") });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Management", Description = "This sample showcases the import and export of DataTable in the Spreadsheet control.", GroupName = "MISCELLANEOUS", DemoViewType = typeof(DataManagementDemo), Documentations = dataManagementDocumentation });
            
            List<Documentation> exportingDocumentation = new List<Documentation>();
            exportingDocumentation.Add(new Documentation { Content = "Spreadsheet - Exporting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/data-management#export-to-datatable") });
            exportingDocumentation.Add(new Documentation { Content = "Spreadsheet - Conversion Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/conversion") });
            this.Demos.Add(new DemoInfo() { SampleName = "Exporting", Description = "This sample showcases the exporting of SfSpreadsheet into various file formats such as PDF, HTML and Image.", GroupName = "MISCELLANEOUS", DemoViewType = typeof(ExportingDemo), Documentations = exportingDocumentation });
            
            List<Documentation> printingDocumentation = new List<Documentation>();
            printingDocumentation.Add(new Documentation() { Content = "Spreadsheet - Printing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/printing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", Description = "This sample demonstrates the printing of Spreadsheet control using PdfViewerControl", GroupName = "MISCELLANEOUS", DemoViewType = typeof(PrintingDemo), Documentations = printingDocumentation });

            List<Documentation> cellCustomizationDocumentation = new List<Documentation>();
            cellCustomizationDocumentation.Add(new Documentation() { Content = "Spreadsheet - Cell Customization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/spreadsheet/cell-customization") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Customization", Description = "This sample showcases the cell customization support in Spreadsheet control.", GroupName = "MISCELLANEOUS", DemoViewType = typeof(CellCustomizationDemo), DemoLauchMode = DemoLauchMode.Window, Documentations = cellCustomizationDocumentation });

        }
    }
}
