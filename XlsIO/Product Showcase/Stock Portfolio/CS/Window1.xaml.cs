#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using System.Globalization;

namespace StockPortfolio
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members

        #region Constants
        /// <summary>
        /// Specifies database connection string
        /// </summary>
        private string conString;
        /// <summary>
        /// Specifies number of the first row in data grid in first worksheet.
        /// </summary>
        private const int DEF_FST_ROW_NUM_FS = 38;
        /// <summary>
        /// Specifies number of the first row in data grid in first worksheet.
        /// </summary>
        private const int DEF_FST_ROW_NUM_SC = 25;
        #endregion

        #region Fields
        /// <summary>
        /// DataSet.
        /// </summary>
        private DataSet ds;
        /// <summary>
        /// Specifies workbook.
        /// </summary>
        private IWorkbook myWorkbook;
        /// <summary>
        /// Image for ChartArea background.
        /// </summary>
        private string userImage;
        /// <summary>
        /// Data directory
        /// </summary>
        private DirectoryInfo dataDirectory;
        /// <summary>
        /// Report's directory.
        /// </summary>
        private string reportDirectory;
        /// <summary>
        /// Image Dialog.
        /// </summary>
        private OpenFileDialog open;
        /// <summary>
        /// File Name
        /// </summary>
        private string fileName;
        #endregion
        # endregion

        # region Constructor and Load
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\";
            this.image1.Source = (ImageSource)img.ConvertFromString(file + "xlsio_header.png");
        }

        /// <summary>
        /// Window load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the DataSet
            ds = new DataSet();

            listStock.SelectedIndex = 0;
            dataDirectory = new DirectoryInfo(@"..\..\..\..\..\..\Common\Data\XlsIO\");
            reportDirectory = Application.ResourceAssembly.Location;
            conString = @"Provider=Microsoft.JET.OLEDB.4.0;" + @"data source=" + dataDirectory.FullName + "DataBase.mdb";

            // Create an open the connection
            OleDbConnection conn = new OleDbConnection(conString);
            conn.Open();

            // Create the adapter and fill the DataSet
            OleDbCommand command = new OleDbCommand(@"SELECT Min(Date) as MinDate, Max(Date) as MaxDate FROM StockData", conn);

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);

            DateTime minDate = DateTime.Parse(ds.Tables[0].Rows[0]["MinDate"].ToString().Trim(), CultureInfo.InvariantCulture);
            DateTime maxDate = DateTime.Parse(ds.Tables[0].Rows[0]["MaxDate"].ToString().Trim(), CultureInfo.InvariantCulture);

            DateTime sdate = minDate;
            DateTime edate = maxDate;
            comboBoxStartDate.Items.Add(minDate.ToLongDateString());
            comboBoxEndDate.Items.Add(maxDate.ToLongDateString());

            while (sdate < maxDate)
            {
                sdate = sdate.AddDays(1);
                edate = edate.AddDays(-1);
                comboBoxStartDate.Items.Add(sdate.ToLongDateString());
                comboBoxEndDate.Items.Add(edate.ToLongDateString());
            }
            comboBoxEndDate.SelectedIndex = 0;
            comboBoxStartDate.SelectedIndex = 0;

            listStock.Items.Clear();
            string[] list = { "AAPL", "ADBE", "AMD", "AMZN", "BF.B", "BRCM", "CSCO", "DELL", "EBAY", "GOOG", "IBM", "INTC", "JDSU", "JNPR", "MSFT", "ORCL", "QCOM", "SYMC", "YHOO" };
            for (int i = 0; i < list.Length; i++)
                listStock.Items.Add(list[i]);

            conn.Close();
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            // A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            // The number of default worksheets is the application setting in MS Excel.
            myWorkbook = excelEngine.Excel.Workbooks.Add(dataDirectory.FullName + "Template.xls");

            if (this.rdButtonxls.IsChecked.Value)
            {
                myWorkbook.Version = ExcelVersion.Excel97to2003;
                fileName = "StockPortfolio.xls";
            }
            else if (this.rdButtonxlsx.IsChecked.Value)
            {
                myWorkbook.Version = ExcelVersion.Excel2007;
                fileName = "StockPortfolio.xlsx";
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                myWorkbook.Version = ExcelVersion.Excel2010;
                fileName = "StockPortfolio.xlsx";
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                myWorkbook.Version = ExcelVersion.Excel2013;
                fileName = "StockPortfolio.xlsx";
            }
            IChart chart = myWorkbook.Worksheets[1].Charts[0];
            chart.PrimaryCategoryAxis.NumberFormat = "m/d/yyyy";
            chart.PrimaryValueAxis.NumberFormat = "\"$\"#,##0.00";
            chart.SecondaryValueAxis.NumberFormat = "\"$\"#,##0.00";
            chart.SecondaryValueAxis.TickLabelPosition = ExcelTickLabelPosition.TickLabelPosition_High;

            // Adding new worksheets in workbook's sheets collection
            for (int count = 1; count < listStock.SelectedItems.Count; count++)
                myWorkbook.Worksheets.AddCopyAfter(myWorkbook.Worksheets[1], myWorkbook.Worksheets[0]);

            // Adding hyperlinks to menu sheet 
            IWorksheet menu_sheet = myWorkbook.Worksheets[0];
            int InsertIndex = DEF_FST_ROW_NUM_SC - 3;

            menu_sheet.HyperLinks.RemoveAt(0);
            menu_sheet.Range["G21"].Text = "";

            for (int count = 0; count < listStock.SelectedItems.Count; count++)
            {
                menu_sheet.InsertRow(InsertIndex, 2, ExcelInsertOptions.FormatAsBefore);
                IHyperLink report_hyperlink = menu_sheet.HyperLinks.Add(menu_sheet.Range["G" + InsertIndex + ":I" + InsertIndex]);
                report_hyperlink.Type = ExcelHyperLinkType.Workbook;
                report_hyperlink.Address = listStock.SelectedItems[count].ToString() + "!A1";
                report_hyperlink.TextToDisplay = listStock.SelectedItems[count].ToString();

                InsertIndex += 2;
            }

            // Creating Stock report
            int itemIndex = 1;

            foreach (Object listStockItem in listStock.SelectedItems)
            {
                CreateStockReport(listStockItem.ToString(), itemIndex);
                FillAnalysisPortfolioSheet(listStockItem.ToString());
                itemIndex += 1;
            }

            try
            {
                // Saving the workbook to disk.
                myWorkbook.SaveAs(reportDirectory + @"..\..\" + fileName);
                // No exception will be thrown if there are unsaved workbooks. No use here since we are
                // saving the workbook.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information)
                    == MessageBoxResult.Yes)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process.Start(reportDirectory + @"..\..\" + fileName);
                    //Exit
                    this.Close();
                }
                else
                {
                    // Exit
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }           

        }

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process.Start(dataDirectory.FullName + "Template.xls");
            //Exit
            this.Close();
        }

        /// <summary>
        /// Choose image to insert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            open = new OpenFileDialog();

            open.Title = "Insert Image";

            open.Filter = "JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|Bitmap Files (*.bmp)|*.bmp|TIFF Files (*.tiff)|*.tiff|ICO (*.ico)|*.ico| All Picture Files (*.jpeg;*.jpg;*.bmp;*.gif;*.tiff;*.ico)|*.jpeg;*.jpg;*.bmp;*.gif;*.png;*.tiff;*.ico";
            if (open.ShowDialog().Value)
            {
                userImage = open.FileName;
            }
        }
        # endregion

        #region Helper Methods

        #region FillAnalysisPortfolioSheet
        private void FillAnalysisPortfolioSheet(string StockSymbol)
        {
            // Fill Portfolio Analysis sheet
            int AnalysisPortfolioSheetNum = myWorkbook.Worksheets.Count - 1;

            IWorksheet portf_analysis_sheet = myWorkbook.Worksheets[AnalysisPortfolioSheetNum];

            OleDbConnection conn = new OleDbConnection(conString);
            conn.Open();

            // Fill StockStyle
            ds.Tables.Clear();

            // Create the adapter and fill the DataSet
            OleDbCommand command = new OleDbCommand(@"select * from StockStyles", conn);

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);

            for (int count = 0; count < ds.Tables[0].Rows.Count; count++)
            {
                portf_analysis_sheet.Range["D" + (DEF_FST_ROW_NUM_SC + count)].Value = ds.Tables[0].Rows[count]["StockStyle"].ToString();
            }

            // Fill StockTypes
            ds.Tables.Clear();

            command = new OleDbCommand(@"select * from StockTypes", conn);

            adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);

            for (int count = 0; count < ds.Tables[0].Rows.Count; count++)
            {
                portf_analysis_sheet.Range["I" + (DEF_FST_ROW_NUM_SC + count)].Value = ds.Tables[0].Rows[count]["StockType"].ToString();
            }

            // Clear all tables in dataset
            ds.Tables.Clear();

            command = new OleDbCommand(@"select * from StockInfo where StockName = '" + StockSymbol + "'", conn);

            adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);

            int cell_num = DEF_FST_ROW_NUM_SC + Int32.Parse(ds.Tables[0].Rows[0]["StockStyle"].ToString()) - 1;

            int cell_value = 0;

            if (portf_analysis_sheet.Range["E" + cell_num.ToString()].Value.Length > 0)
                cell_value = Int32.Parse(portf_analysis_sheet.Range["E" + cell_num.ToString()].Value);

            cell_value += 1;
            portf_analysis_sheet.Range["E" + cell_num.ToString()].Value2 = cell_value;

            cell_num = DEF_FST_ROW_NUM_SC + Int32.Parse(ds.Tables[0].Rows[0]["StockType"].ToString()) - 1;

            cell_value = 0;

            if (portf_analysis_sheet.Range["E" + cell_num.ToString()].Value.Length > 0)
                cell_value = Int32.Parse(portf_analysis_sheet.Range["E" + cell_num.ToString()].Value);

            cell_value += 1;

            portf_analysis_sheet.Range["J" + cell_num.ToString()].Value2 = cell_value;

            // Close the connection
            conn.Close();
        }
        #endregion

        #region CreateStockReport
        private void CreateStockReport(string StockSymbol, int itemIndex)
        {
            // Clear all tables in dataset
            ds.Tables.Clear();

            // Create an open the connection
            OleDbConnection conn = new OleDbConnection(conString);
            conn.Open();

            // Create the adapter and fill the DataSet
            OleDbCommand command = new OleDbCommand(@"select Date, Volume, OpenPrice, HighPrice, LowPrice, ClosePrice from StockData where symbol = '"
               + StockSymbol + "' and Date between @FromDate and @ToDate order by Date", conn);

            command.Parameters.Add("@FromDate", OleDbType.Date).Value = comboBoxStartDate.SelectedValue;
            command.Parameters.Add("@ToDate", OleDbType.Date).Value = comboBoxEndDate.SelectedValue;

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);
            // Close the connection
            conn.Close();

            DataTable table = ds.Tables[0];

            if (table.Rows.Count > 0)
            {
                if (itemIndex > 1)
                    FillReport(itemIndex, table, StockSymbol, false);
                else
                    FillReport(1, table, StockSymbol, false);
            }
        }
        #endregion

        #region FillReport
        private void FillReport(int report, DataTable table, string StockSymbol, bool hasLegend)
        {
            IWorksheet reportSheet = myWorkbook.Worksheets[report];

            reportSheet.Name = StockSymbol;

            if (table.Rows.Count > 1)
                reportSheet.InsertRow(DEF_FST_ROW_NUM_FS + 1, table.Rows.Count - 1, ExcelInsertOptions.FormatAsBefore);
            // Inserting data into the spreadsheet.
            reportSheet.ImportDataTable(table, true, (DEF_FST_ROW_NUM_FS - 1), 3);

            int rownum = DEF_FST_ROW_NUM_FS - 1;

            reportSheet.Range["I3"].Text = StockSymbol;
            reportSheet.Range["C" + rownum.ToString()].Text = "Date";
            reportSheet.Range["D" + rownum.ToString()].Text = "Volume";
            reportSheet.Range["E" + rownum.ToString()].Text = "Open Price";
            reportSheet.Range["F" + rownum.ToString()].Text = "High Price";
            reportSheet.Range["G" + rownum.ToString()].Text = "Low Price";
            reportSheet.Range["H" + rownum.ToString()].Text = "Close Price";

            for (int count = 0; count < table.Rows.Count; count++)
            {
                string cellNum = (count + DEF_FST_ROW_NUM_FS).ToString();
                reportSheet.Range["I" + cellNum].Formula = "$H" + cellNum + "-$E" + cellNum;
            }

            IChartShapes charts = reportSheet.Charts;
            foreach (IChartShape chart in charts)
            {
                chart.DataRange = reportSheet.Range["C" + DEF_FST_ROW_NUM_FS + ":H" + (table.Rows.Count + (DEF_FST_ROW_NUM_FS - 1))];
                chart.ChartType = ExcelChartType.Stock_VolumeOpenHighLowClose;

                chart.ChartArea.IsBorderCornersRound = checkBoxCurved.IsChecked.Value;

                if (userImage != null && userImage.Length > 0)
                    chart.ChartArea.Fill.UserPicture(userImage);

                chart.Series[0].SerieFormat.LineProperties.LinePattern = ExcelChartLinePattern.Solid;
                chart.Series[0].SerieFormat.LineProperties.LineWeight = ExcelChartLineWeight.Narrow;
                chart.Series[0].SerieFormat.LineProperties.LineColor = System.Drawing.Color.Blue;

                chart.Series[1].SerieFormat.LineProperties.LinePattern = ExcelChartLinePattern.Solid;
                chart.Series[1].SerieFormat.LineProperties.LineWeight = ExcelChartLineWeight.Narrow;
                chart.Series[1].SerieFormat.LineProperties.LineColor = System.Drawing.Color.Blue;

                chart.HasLegend = hasLegend;
            }
        }
        #endregion

        #endregion
    }
}