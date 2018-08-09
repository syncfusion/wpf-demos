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

namespace PivotTable_2008
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
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
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

            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\PivotCodeDate.xlsx");

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Access the sheet to draw pivot table.
            IWorksheet pivotSheet = workbook.Worksheets[1];
            pivotSheet.Activate();
            //Select the data to add in cache
            IPivotCache cache = workbook.PivotCaches.Add(sheet["A1:H50"]);

            //Insert the pivot table. 
            IPivotTable pivotTable = pivotSheet.PivotTables.Add("PivotTable1", pivotSheet["A1"], cache);
            pivotTable.Fields[2].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[4].Axis = PivotAxisTypes.Page;
            pivotTable.Fields[6].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[3].Axis = PivotAxisTypes.Column;

            IPivotField field = pivotSheet.PivotTables[0].Fields[5];
            pivotTable.DataFields.Add(field, "Sum of Units", PivotSubtotalTypes.Sum);

            if (chkRowFilter.IsChecked .Value)
            {
                if (rdbLabelFilter.IsChecked .Value)
                {
                    //Applying label based filter to row field
                    pivotTable.Fields[2].PivotFilters.Add(PivotFilterType.CaptionEqual, null, "East", null);
                }
                else if (rdbValueFilter .IsChecked .Value )
                {
                    //Applying value based filter to row field
                    pivotTable.Fields[2].PivotFilters.Add(PivotFilterType.ValueEqual, field, "1341", null);
                }
                else
                {
                    //Applying multiple item filter to row field
                    pivotTable.Fields[2].Items[0].Visible = false;
                    pivotTable.Fields[2].Items[1].Visible = false;
                }
            }
            if (chkColumnFilter.IsChecked.Value )
            {
                if (rdbLabelFilter.IsChecked.Value)
                {
                    //Applying label based filter to row field
                    pivotTable.Fields[3].PivotFilters.Add(PivotFilterType.CaptionNotEqual, null, "Jones", null);
                }
                else if (rdbValueFilter.IsChecked.Value)
                {
                    //Applying value based filter to column field
                    pivotTable.Fields[3].PivotFilters.Add(PivotFilterType.ValueEqual, field, "398", null);
                }
                else
                {
                    //Applying multiple item filter to Column field
                    pivotTable.Fields[3].Items[0].Visible = false;
                    pivotTable.Fields[3].Items[1].Visible = false;
                }
            }
            if (chkPageFilter.IsChecked.Value)
            {
                //Create Pivot Filter object to apply filter to page Fields
                IPivotFilter filterValue = pivotTable.Fields[4].PivotFilters.Add();
                //Page Field would be filtered with value 'East'
                filterValue.Value1 = "Binder";
                if(!rdbValueFilter.IsChecked .Value )
                 //XlsIO layout the Pivot table like MS Excel
                pivotTable.Layout();
            }
            else if (chkMultiplePageFilter.IsChecked.Value)
            {
                //Applying multiple item filter page field
                pivotTable.Fields[4].Items[1].Visible = false;
                pivotTable.Fields[4].Items[2].Visible = false;
                if (!rdbValueFilter.IsChecked .Value)
                    pivotTable.Layout();
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
                        System.Diagnostics.Process.Start("PivotTable.xlsx");
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();

            IApplication application = excelEngine.Excel;

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

            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\PivotTable.xlsx");

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
            fields[0].Axis = PivotAxisTypes.None;
            fields[3].Axis = PivotAxisTypes.Row;
            fields[4].Axis = PivotAxisTypes.Column;
            IPivotField dataField = fields[5];

            //Accessing the Calculated fields from the pivot table .
            IPivotCalculatedFields calculatedfields = pivotTable.CalculatedFields;

            //Adding Calculatd field to the pivot table.
            //IPivotField calculatedField = calculatedfields.Add("Percent", "Units/3000*100");

            if (chkRowFilter.IsChecked.Value)
            {
                if (rdbLabelFilter.IsChecked.Value)
                {
                    //Applying label based filter to row field
                    pivotTable.Fields[3].PivotFilters.Add(PivotFilterType.CaptionNotEqual, null, "Parent", null);
                }
                else if (rdbValueFilter.IsChecked.Value)
                {
                    //Applying value based filter to row field
                    pivotTable.Fields[3].PivotFilters.Add(PivotFilterType.ValueGreaterThan, dataField, "100", null);
                }
                else
                {
                    //Applying multiple item filter to row field
                    pivotTable.Fields[3].Items[0].Visible = false;
                }

            }
            if (chkColumnFilter.IsChecked.Value)
            {
                if (rdbLabelFilter.IsChecked.Value)
                {
                    //Applying label based filter to column field
                    pivotTable.Fields[4].PivotFilters.Add(PivotFilterType.CaptionNotEqual, null, "Binder", null);
                }
                else if (rdbValueFilter.IsChecked.Value)
                {
                    //Applying value based filter to column field
                    pivotTable.Fields[4].PivotFilters.Add(PivotFilterType.ValueGreaterThan, dataField, "100", null);
                }
                else
                {
                    //Applying multiple item filter to column field
                    pivotTable.Fields[4].Items[0].Visible = false;
                }

            }
            if (chkPageFilter.IsChecked.Value)
            {
                //'Create Pivot Filter object to apply filter to page Fields
                IPivotFilter filterValue = pivotTable.Fields[2].PivotFilters.Add();
                //Page Field would be filtered with value 'East'
                filterValue.Value1 = "East";
                //XlsIO layout the Pivot table like MS Excel
                if(!rdbValueFilter .IsChecked .Value )
                pivotTable.Layout();
            }
            else if (chkMultiplePageFilter.IsChecked.Value)
            {
                pivotTable.Fields[2].Items[0].Visible = false;
                if (!rdbValueFilter.IsChecked.Value)
                    pivotTable.Layout();
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
                        System.Diagnostics.Process.Start("Sample.xlsx");
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

        private void chkRowFilter_Checked(object sender, RoutedEventArgs e)
        {
            if (chkRowFilter.IsChecked .Value  )
            {
                rdbLabelFilter.IsEnabled = true;
                rdbMultipleFilter.IsEnabled = true;
                rdbValueFilter.IsEnabled = true;
            }

            else if (!(chkRowFilter.IsChecked.Value && chkColumnFilter.IsChecked.Value))
            {
                rdbLabelFilter.IsEnabled = false;
                rdbMultipleFilter.IsEnabled = false;
                rdbValueFilter.IsEnabled = false;
            }
        }

        private void chkColumnFilter_Checked(object sender, RoutedEventArgs e)
        {
            if (chkColumnFilter .IsChecked.Value)
            {
                rdbLabelFilter.IsEnabled = true;
                rdbMultipleFilter.IsEnabled = true;
                rdbValueFilter.IsEnabled = true;
            }

            else if (!(chkRowFilter.IsChecked.Value && chkColumnFilter.IsChecked.Value))
            {
                rdbLabelFilter.IsEnabled = false;
                rdbMultipleFilter.IsEnabled = false;
                rdbValueFilter.IsEnabled = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rdbLabelFilter.IsEnabled = false;
            rdbMultipleFilter.IsEnabled = false;
            rdbValueFilter.IsEnabled = false;
        }

        private void chkPageFilter_Checked(object sender, RoutedEventArgs e)
        {
            if (chkPageFilter.IsChecked.Value == true)
                chkMultiplePageFilter.IsChecked = false;
        }

        private void chkMultiplePageFilter_Checked(object sender, RoutedEventArgs e)
        {
            if (chkMultiplePageFilter.IsChecked.Value == true)
                chkPageFilter.IsChecked = false;
        }

        private void chkRowFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(chkRowFilter.IsChecked.Value))
            {
                if (!chkColumnFilter.IsChecked.Value)
                {
                    rdbLabelFilter.IsEnabled = false;
                    rdbMultipleFilter.IsEnabled = false;
                    rdbValueFilter.IsEnabled = false;
                }
            }
        }

        private void chkColumnFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(chkRowFilter.IsChecked.Value ))
            {
                if(! chkColumnFilter.IsChecked.Value)
                {
                    rdbLabelFilter.IsEnabled = false;
                    rdbMultipleFilter.IsEnabled = false;
                    rdbValueFilter.IsEnabled = false;
                }
            }
        }
    }
}
