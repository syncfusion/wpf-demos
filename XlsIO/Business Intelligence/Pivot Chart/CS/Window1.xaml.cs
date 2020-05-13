#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace PivotChart_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Set the default version as Excel 2007;
            if (this.rdButtonxlsx.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2007;                
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2010;                
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2013;
            }

#if NETCORE
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\PivotCodeDate.xlsx");
#else
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\PivotCodeDate.xlsx");
#endif

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Access the sheet to draw pivot table.
            IWorksheet pivotSheet = workbook.Worksheets[1];

            //Select the data to add in cache
            IPivotCache cache = workbook.PivotCaches.Add(sheet["A1:H50"]);

            //Insert the pivot table. 
            IPivotTable pivotTable = pivotSheet.PivotTables.Add("PivotTable1", pivotSheet["A1"], cache);
            pivotTable.Fields[2].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[4].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[3].Axis = PivotAxisTypes.Column;

            IPivotField field = pivotSheet.PivotTables[0].Fields[5];
            pivotTable.DataFields.Add(field, "Sum of Units", PivotSubtotalTypes.Sum);

            //Show expand/collapse button.
            pivotTable.ShowDrillIndicators = true;

            //Shows row grand.
            pivotTable.RowGrand = true;

            //Shows filter and field caption.
            pivotTable.DisplayFieldCaptions = true;

            //Apply built in style.
            pivotTable.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium2;

            //Add the Pivot chart sheet to the workbook.
            IChart pivotChartSheet = workbook.Charts.Add();
            pivotChartSheet.Name = "PivotChart";

            //Set the Pivot source for the Pivot Chart.
            pivotChartSheet.PivotSource = pivotTable;

            //Set the Pivot Chart Type.
            pivotChartSheet.PivotChartType = ExcelChartType.Column_Clustered;

            pivotSheet.Range[1, 1, 1, 14].ColumnWidth = 11;
            pivotSheet.SetColumnWidth(1, 15.29);
            pivotSheet.SetColumnWidth(2, 15.29);
			//Activate the pivot sheet.
            pivotChartSheet.Activate();

            try
            {
                //Saving the workbook to disk.
                workbook.SaveAs("PivotChart.xlsx");

                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("PivotChart.xlsx")
                        {
                            UseShellExecute = true
                        };
                        process.Start();
#else
                        Process.Start("PivotChart.xlsx");
#endif
                        //Exit
                        this.Close();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                    // Exit
                    this.Close();
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
    }
}
