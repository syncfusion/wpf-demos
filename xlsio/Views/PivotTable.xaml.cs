#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;
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
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for PivotTable.xaml
    /// </summary>
    public partial class PivotTable : DemoControl
    {
        #region Constructor
        public PivotTable()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Set the default version as Xlsx;
            application.DefaultVersion = ExcelVersion.Xlsx;
            
            IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\PivotCodeDate.xlsx");
            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Access the sheet to draw pivot table.
            IWorksheet pivotSheet = workbook.Worksheets[1];
            pivotSheet.Activate();
            //Select the data to add in cache
            IPivotCache cache = workbook.PivotCaches.Add(sheet["A1:H50"]);

            //Insert the pivot table. 
            IPivotTable pivotTable = pivotSheet.PivotTables.Add("PivotTable1", pivotSheet["A1"], cache);
            if (chkboxGroupingFilter.IsChecked.Value)
                pivotTable.Fields[0].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[2].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[4].Axis = PivotAxisTypes.Page;
            pivotTable.Fields[6].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[3].Axis = PivotAxisTypes.Column;

            IPivotField field = pivotSheet.PivotTables[0].Fields[5];
            pivotTable.DataFields.Add(field, "Sum of Units", PivotSubtotalTypes.Sum);

            if (chkboxRowFilter.IsChecked.Value)
            {
                //Applying multiple item filter to row field
                pivotTable.Fields[2].Items[0].Visible = false;
                pivotTable.Fields[2].Items[1].Visible = false;
            }
            if (chkboxColumnFilter.IsChecked.Value)
            {
                //Applying multiple item filter to Column field
                pivotTable.Fields[3].Items[0].Visible = false;
                pivotTable.Fields[3].Items[1].Visible = false;
            }
            if (chkboxPageFilter.IsChecked.Value)
            {
                //Create Pivot Filter object to apply filter to page Fields
                IPivotFilter filterValue = pivotTable.Fields[4].PivotFilters.Add();
                //Page Field would be filtered with value 'East'
                filterValue.Value1 = "Binder";
            }
            else if (chkboxMultiplePageFilter.IsChecked.Value)
            {
                //Applying multiple item filter page field
                pivotTable.Fields[4].Items[1].Visible = false;
                pivotTable.Fields[4].Items[2].Visible = false;
            }
            if (chkboxGroupingFilter.IsChecked.Value)
            {
                //Apply grouping to the pivot table
                IPivotFieldGroup group = pivotTable.Fields[0].FieldGroup;
                group.GroupBy = PivotFieldGroupType.Years | PivotFieldGroupType.Quarters | PivotFieldGroupType.Months;
            }
            //Apply built in style.
            pivotTable.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium2;
            pivotSheet.Range[1, 1, 1, 14].ColumnWidth = 11;
            pivotSheet.SetColumnWidth(1, 15.29);
            pivotSheet.SetColumnWidth(2, 15.29);
            //Activate the pivot sheet.
            pivotSheet.Activate();

            try
            {
                //Saving the workbook to disk.
                workbook.SaveAs("PivotTable.xlsx");

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
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("PivotTable.xlsx")
                        {
                            UseShellExecute = true
                        };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Microsoft Excel is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }

        private void btnCustomize_Click(object sender, RoutedEventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();

            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\PivotTable.xlsx");

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[1];
            sheet.Activate();
            //Access the collection of Pivot Table in the worksheet.
            IPivotTables pivotTables = sheet.PivotTables;

            //Access the Single pivot table from the collection.
            IPivotTable pivotTable = pivotTables[0];

            //Access collection of pivot fields from the pivot table.
            IPivotFields fields = pivotTable.Fields;

            //Access a Pivot field from the collection.
            IPivotField field = fields[2];
            //Add the field to page axis
            field.Axis = PivotAxisTypes.Page;
           

            fields[1].Axis = PivotAxisTypes.None;
            fields[3].Axis = PivotAxisTypes.Row;
            fields[4].Axis = PivotAxisTypes.Column;
            IPivotField dataField = fields[5];

            //Accessing the Calculated fields from the pivot table .
            IPivotCalculatedFields calculatedfields = pivotTable.CalculatedFields;

            //Adding Calculatd field to the pivot table.
            //IPivotField calculatedField = calculatedfields.Add("Percent", "Units/3000*100");

            if (chkboxRowFilter.IsChecked.Value)
            {
                //Applying multiple item filter to row field
                pivotTable.Fields[3].Items[0].Visible = false;
            }
            if (chkboxColumnFilter.IsChecked.Value)
            {
                //Applying multiple item filter to column field
                pivotTable.Fields[4].Items[0].Visible = false;
            }
            if (chkboxPageFilter.IsChecked.Value)
            {
                //'Create Pivot Filter object to apply filter to page Fields
                IPivotFilter filterValue = pivotTable.Fields[2].PivotFilters.Add();
                //Page Field would be filtered with value 'East'
                filterValue.Value1 = "East";
            }
            else if (chkboxMultiplePageFilter.IsChecked.Value)
            {
                pivotTable.Fields[2].Items[0].Visible = false;
            }
            if (chkboxGroupingFilter.IsChecked.Value)
            {
                //Apply grouping to the pivot table
                IPivotFieldGroup group = pivotTable.Fields[0].FieldGroup;
                group.GroupBy = PivotFieldGroupType.Years | PivotFieldGroupType.Quarters | PivotFieldGroupType.Months;
            }
            sheet.Range[1, 1, 1, 14].ColumnWidth = 11;
            sheet.SetColumnWidth(1, 15.29);
            sheet.SetColumnWidth(2, 15.29);

            try
            {
                //Saving the workbook to disk.
                workbook.SaveAs("Sample.xlsx");

                //Close the workbook.
                workbook.Close();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.xlsx")
                        {
                            UseShellExecute = true
                        };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Microsoft Excel is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }

        private void chkboxPageFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            chkboxPageFilter.IsChecked = false; 
        }

        private void chkboxMultiplePageFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            chkboxMultiplePageFilter.IsChecked = false;
        }
        #endregion
    }
}
