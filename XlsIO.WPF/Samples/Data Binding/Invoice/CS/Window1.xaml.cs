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
using System.Data.OleDb;
using System.Data;
using Syncfusion.XlsIO;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;

namespace Invoice
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
                string shipName, address, shipCity, shipCountry;
        Double freight;
        string shippedDate;
        private string fileName;

        public readonly static string connString = @"Data Source=..\..\..\..\..\..\..\Common\Data\NorthwindIO.sdf";
        public readonly static string connString_35 = @"Data Source=..\..\..\..\..\..\..\Common\Data\NorthwindIO_3.5.sdf";
        # endregion

        # region Constructor and Load
        /// <summary>
        /// Window Constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }

        /// <summary>
        /// Window load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet orderDS = new DataSet();
            SqlCeConnection con = new SqlCeConnection();
            SqlCeDataAdapter dataAdapter = null;

            if(con.ServerVersion.StartsWith("3.5"))
              dataAdapter   = new SqlCeDataAdapter("Select OrderID from Orders Order By OrderID", connString_35);
            else
              dataAdapter = new SqlCeDataAdapter("Select OrderID from Orders Order By OrderID", connString);

            dataAdapter.Fill(orderDS);
            DataTable dt = orderDS.Tables["Table"];

            // Add Customer ID to the list box.
            foreach (DataRow row in orderDS.Tables["Table"].Rows)
                listCustomer.Items.Add(row["OrderID"]);
        }
        # endregion

        # region Helpher Methods
        /// <summary>
        /// Creates spreadsheet from customer id.
        /// </summary>
        /// <param name="id"></param>
        public void GenerateXls(int id)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            IWorkbook workbook;

            if (this.rdButtonxls.IsChecked.Value)
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\Invoice.xls");
            else
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\Invoice.xlsx", ExcelOpenType.Automatic);

            IWorksheet sheet = workbook.Worksheets[0];

            sheet.Range["A5"].Text = "One Portals Way";
            sheet.Range["A6"].Text = "Twin Points WA 98156";
            sheet.Range["A7"].Text = "Phone: 1-206-555-1417 ";
            sheet.Range["A8"].Text = "Fax: 1-206-555-5938";

            sheet.Range["D5"].Text = "INVOICE NO:";
            sheet.Range["D6"].Text = "DATE:";
            sheet.Range["D7"].Text = "CUSTOMER ID  :";
            sheet.Range["E6"].Formula = "TODAY()";

            sheet.Range["E5"].Number = id;

            //Set values for Ship To.
            GetShipDetails(id);
            sheet.Range["E7"].Text = shipName;
            sheet.Range["E10"].Text = shipName;
            sheet.Range["E11"].Text = address;
            sheet.Range["E12"].Text = shipCity;
            sheet.Range["E13"].Text = shipCountry;

            //Set values for Bill To.
            sheet.Range["B10"].Text = shipName;
            sheet.Range["B11"].Text = address;
            sheet.Range["B12"].Text = shipCity;
            sheet.Range["B13"].Text = shipCountry;

            //Calculates sub total
            sheet.Range["E27"].Formula = "SUM(E20:E26)";

            //Set the number format
            sheet.Range["E20:E29"].NumberFormat = "$#,##0.00";
            sheet.Range["E28"].Value = freight.ToString();

            //Calculates final total
            sheet.Range["E29"].Formula = "E27+E28";

            //Import the data tables.
            sheet.ImportDataTable(GetOrder(id), false, 17, 1);
            sheet.ImportDataTable(GetProductDetails(id), false, 20, 1);

            //Calculates price from discount and unit price.
            for (int i = 20; i <= 26; i++)
            {
                if (sheet.Range["A" + i.ToString()].Value == "")
                    break;
                else
                    sheet.Range["E" + i.ToString()].Formula = "(B" + i.ToString() + "*C" + i.ToString() + ")- (D" + i.ToString() + "/100)";
            }
            if (this.rdButtonxls.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel97to2003;
                fileName = "Invoice.xls";
            }
            else if (this.rdButtonxlsx.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2007;
                fileName = "Invoice.xlsx";
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2010;
                fileName = "Invoice.xlsx";
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2013;
                fileName = "Invoice.xlsx";
            }
            //Save the workbook to disk.
            workbook.SaveAs(fileName);

            //Close the workbook.
            workbook.Close();

            //No exception will be thrown if there are unsaved workbooks.
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
        }

        /// <summary>
        /// Gets the product details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private DataTable GetProductDetails(int id)
        {
            SqlCeConnection con = new SqlCeConnection();
            SqlCeDataAdapter dataAdapter = null;
            DataSet ds = new DataSet();

            if (con.ServerVersion.StartsWith("3.5"))
                dataAdapter = new SqlCeDataAdapter("Select ProductID,Quantity,UnitPrice,Discount from SyncOrderDetails where OrderID=" + id, connString_35);
            else
                dataAdapter = new SqlCeDataAdapter("Select ProductID,Quantity,UnitPrice,Discount from SyncOrderDetails where OrderID=" + id, connString);
          
            dataAdapter.Fill(ds);

            DataTable prodDS = new DataTable();
            prodDS = ds.Tables[0];
            return prodDS;
        }

        /// <summary>
        /// Gets shipping details
        /// </summary>
        /// <param name="id"></param>
        private void GetShipDetails(int id)
        {
            SqlCeConnection con = new SqlCeConnection();
            SqlCeDataAdapter dataAdapter = null;
            DataSet ds = new DataSet();

            if (con.ServerVersion.StartsWith("3.5"))
                dataAdapter = new SqlCeDataAdapter("Select ShipName,ShipAddress,Freight,ShippedDate,ShipCity,ShipCountry from Orders where OrderID=" + id, connString_35);
            else
                dataAdapter = new SqlCeDataAdapter("Select ShipName,ShipAddress,Freight,ShippedDate,ShipCity,ShipCountry from Orders where OrderID=" + id, connString);
           
            dataAdapter.Fill(ds);
            DataTable dataTable = new DataTable();
            dataTable = ds.Tables[0];

            DataRow dr;
            int rows = dataTable.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                dr = dataTable.Rows[i];
                shipName = dr["ShipName"].ToString();
                freight = System.Convert.ToDouble(dr["Freight"].ToString());
                address = dr["ShipAddress"].ToString();
                shippedDate = dr["ShippedDate"].ToString();
                shipCity = dr["ShipCity"].ToString();
                shipCountry = dr["ShipCountry"].ToString();
            }
        }

        /// <summary>
        /// Gets order id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private DataTable GetOrder(int id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCeConnection con = new SqlCeConnection();
            SqlCeDataAdapter dataAdapter = null;

            if (con.ServerVersion.StartsWith("3.5"))
                dataAdapter = new SqlCeDataAdapter("Select Salesperson,ShipName,ShipCountry,CustomerID,OrderDate,RequiredDate from SyncOrders where OrderID=" + id, connString_35);
            else
                dataAdapter = new SqlCeDataAdapter("Select Salesperson,ShipName,ShipCountry,CustomerID,OrderDate,RequiredDate from SyncOrders where OrderID=" + id, connString);
           
            dataAdapter.Fill(ds);
            dt = ds.Tables[0];

            return dt;
        }
        # endregion

        # region Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Generate Invoice for the selected ID.
                GenerateXls((int)listCustomer.SelectedItem);

                //Message box confirmation to view the created xls document.
                if (MessageBox.Show("Do you want to view the Output file?", "Excel File Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start(fileName);
                    this.Close();
                }
                else
                    // Exit
                    this.Close();
            }
            catch (NullReferenceException)
            {
                // Shows the Message box with Exception message, if an exception is thrown.
                MessageBox.Show("Please Select the Employee From ListBox", "Report", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }

        }
        # endregion
    }
}