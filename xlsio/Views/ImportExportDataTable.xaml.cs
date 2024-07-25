#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
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
using System.Data;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.UI.Xaml.Grid;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for ImportExportDataTable.xaml
    /// </summary>
    public partial class ImportExportDataTable : DemoControl
    {
        private string fileName;
        # region Constructor
        /// <summary>
        /// ImportExportDataTable constructor
        /// </summary>
        public ImportExportDataTable()
        {
            InitializeComponent();
            btnExport.IsEnabled = false;
        }
        # endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            if(dataGrid != null)
            {
                dataGrid.Dispose();
                dataGrid = null;
            }
            base.Dispose(disposing);
        }
        #endregion

        # region Events

        # region Input template
        /// <summary>
        /// Input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Get the path of the input file
            string inputPath = @"Assets\XlsIO\NorthwindDataTemplate.xls";
            //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(inputPath)
            {
                UseShellExecute = true
            };
            process.Start();
        }
        # endregion

        # region Import from spreadsheet
        /// <summary>
        /// Importing using XlsIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            //Imports Data from the Template spreadsheet into the Grid.

            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Open an existing spreadsheet which will be used as a template for generating the new spreadsheet.
            //After opening, the workbook object represents the complete in-memory object model of the template spreadsheet.
            IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\NorthwindDataTemplate.xls");

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            sheet.ExportDataTableEvent += ExportDataTableEventActions;

            //Read data from spreadsheet.
            DataTable customersTable = sheet.ExportDataTable(sheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);

            //Update the table
            UpdateListView(customersTable);

            //Close the workbook.
            workbook.Close();

            //No exception will be thrown if there are unsaved workbooks.
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
            
            btnExport.IsEnabled = true;
        }
        # endregion

        # region Export to spreadsheet
        /// <summary>
        /// Exporting using XlsIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //Exports the DataTable to a spreadsheet.

            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            if (this.rdbtnXls.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel97to2003;
                fileName = "ExportDataTable.xls";
            }
            else if (this.rdbtnXlsx.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Xlsx;
                fileName = "ExportDataTable.xlsx";
            }
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 3 worksheets
            IWorkbook workbook = application.Workbooks.Create(1);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Convert the table contents to a data table
            DataTable dTable = dataGrid.DataContext as DataTable;

            //Export DataTable.
            if (dTable != null)
                sheet.ImportDataTable(dTable, true, 3, 1, -1, -1);
            else
            {
                MessageBox.Show("There is no datatable to export, Please import a datatable first", "Error");

                //Close the workbook.
                workbook.Close();
                return;
            }

            # region Formatting the Report

            //Body Style
            IStyle bodyStyle = workbook.Styles.Add("BodyStyle");
            bodyStyle.BeginUpdate();

            //Add custom colors to the palette.
            workbook.SetPaletteColor(9, System.Drawing.Color.FromArgb(239, 242, 247));
            bodyStyle.Color = System.Drawing.Color.FromArgb(239, 243, 247);
            bodyStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            bodyStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;

            //Apply Style
            sheet.UsedRange.CellStyleName = "BodyStyle";
            bodyStyle.EndUpdate();

            //Header Style
            IStyle headerStyle = workbook.Styles.Add("HeaderStyle");
            headerStyle.BeginUpdate();

            //Add custom colors to the palette.
            workbook.SetPaletteColor(8, System.Drawing.Color.FromArgb(182, 189, 218));
            headerStyle.Color = System.Drawing.Color.FromArgb(182, 189, 218);
            headerStyle.Font.Bold = true;
            headerStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            headerStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            headerStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
            headerStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;

            //Apply Style
            sheet.Range["A1:K3"].CellStyleName = "HeaderStyle";
            headerStyle.EndUpdate();

            //Remove grid lines in the worksheet.
            sheet.IsGridLinesVisible = false;

            //Autofit Rows and Columns
            sheet.UsedRange.AutofitRows();
            sheet.UsedRange.AutofitColumns();

            //Adjust Row Height.
            sheet.Rows[2].RowHeight = 25;

            //Freeze header row.
            sheet.Range["A4"].FreezePanes();

            sheet.Range["C2"].Text = "Customer Details";
            sheet.Range["C2:D2"].Merge();
            sheet.Range["C2"].CellStyle.Font.Size = 14;
            sheet.Range["C2"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

            # endregion

            try
            {
                //Saving the workbook to disk.
                workbook.SaveAs(fileName);

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }

        # endregion

        # endregion

        # region Helper Methods

        /// <summary>
        /// Updates the list view with the datatable
        /// </summary>
        /// <param name="table"></param>
        protected void UpdateListView(DataTable table)
        {
            //Create a grid view
            GridView gridView1 = new GridView();
            gridView1.AllowsColumnReorder = true;

            //Update the grid view columns
            foreach (System.Data.DataColumn column in table.Columns)
            {
                GridViewColumn column1 = new GridViewColumn();
                column1.DisplayMemberBinding = new Binding(column.ColumnName);
                column1.Header = column.ColumnName;
                gridView1.Columns.Add(column1);
            }

            //Bind the data grid
            Binding bind = new Binding();
            dataGrid.DataContext = table;
            dataGrid.SetBinding(SfDataGrid.ItemsSourceProperty, bind);

            if (Root_Grid.Children.Count > 0)
                Root_Grid.Children.RemoveAt(0);
            Root_Grid.Children.Add(dataGrid);

            dataGrid.Columns[0].Width = 100;
            dataGrid.Columns[1].Width = 150;
            dataGrid.Columns[2].Width = 146;
            dataGrid.Columns[3].Width = 150;
            dataGrid.Columns[4].Width = 150;
            dataGrid.Columns[5].Width = 80;
            dataGrid.Columns[6].Width = 100;
            dataGrid.Columns[7].Width = 100;
            dataGrid.Columns[8].Width = 100;
            dataGrid.Columns[9].Width = 100;
            dataGrid.Columns[10].Width = 100;
        }

        /// <summary>
        /// Export dataTable required actions.
        /// </summary>
        /// <param name="e"></param>
        private void ExportDataTableEventActions(ExportDataTableEventArgs e)
        {
            if (this.rdbtnSkip.IsChecked.Value)
            {
                if (e.ExcelValue != null && e.ExcelValue.ToString() == "Owner")
                    e.ExportDataTableAction = ExportDataTableActions.SkipRow;
            }
            if (this.rdbtnStop.IsChecked.Value)
            {
                if (e.ExcelValue != null && e.ExcelValue.ToString() == "CACTU")
                    e.ExportDataTableAction = ExportDataTableActions.StopExporting;
            }
            if (this.rdbtnReplace.IsChecked.Value)
            {
                if (e.ExcelValue != null && e.ExcelValue.ToString() == "México D.F.")
                    e.DataTableValue = "Mexico";
            }
        }

        # endregion

        private void btnExport_Disable(object sender, RoutedEventArgs e)
        {
            btnExport.IsEnabled = false;
        }
    }
}