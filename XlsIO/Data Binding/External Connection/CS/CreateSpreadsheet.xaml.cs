#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using Syncfusion.XlsIO;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Controls;
using System.Collections;
using Syncfusion.Windows.Shared;


namespace EssentialXlsIOSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreateSpreadsheet : ChromelessWindow
    {

        #region "Constants"
        private const string DEFAULTPATH = "..\\..\\..\\..\\..\\..\\..\\..\\..\\..\\Common\\Data\\XlsIO\\{0}";
        private const string DEFAULTIMAGEPATH = "..\\..\\..\\..\\..\\..\\..\\..\\..\\..\\Common\\Images\\XlsIO\\{0}";
        public string ConnectionString = "Data Source=" + Path.GetFullPath(@"..\..\..\..\..\..\Common\Data\Northwind.mdb");
        public string fileName;
        #endregion
        public string filename;

        #region "Constructor"
        /// <summary>
        /// Window constructor
        /// </summary>
        public CreateSpreadsheet()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }

        /// <summary>
        /// Window load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                OleDbConnection da = new OleDbConnection();
                da.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Password=\"\";User ID=Admin;" + ConnectionString;
                OleDbCommand Command = new OleDbCommand("select country from Customers", da);
                OleDbDataAdapter Adapter = new OleDbDataAdapter(Command);
                DataSet Dataset = new DataSet();
                Adapter.Fill(Dataset);
                // Add Customer ID to the list box.
                foreach (DataRow row in Dataset.Tables[0].Rows)
                {
                    if (!listCustomer.Items.Contains(row["country"]))
                    {
                        listCustomer.Items.Add(row["country"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region "Helpher Methods"
        /// <summary>
        /// Creates spreadsheet from customer id.
        /// </summary>
        /// <param name="id"></param>
        public void GenerateXls(IList selectedcountry)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            //Create the workbook with default sheet
            IWorkbook workbook = application.Workbooks.Create();
            //Get the 1st sheet from the workbook
            IWorksheet sheet = workbook.Worksheets[0];
            //connection string for DataSource
            string Connectionstring = "OLEDB;Provider=Microsoft.JET.OLEDB.4.0;Password=\"\";User ID=Admin;" + ConnectionString;
            //query for the datasource
            string query;
            string countries = string.Empty;
            if (selectedcountry.Count > 0)
            {
                countries = "'" + selectedcountry[0].ToString() + "'";
                for (int i = 0; i < selectedcountry.Count; i++)
                {
                    countries = countries + "," + "'" + selectedcountry[i] + "'";
                }
                query = "select * from Customers where country in(" + countries + ");";
            }
            else
                query = "select * from Customers";
            //Add the connection to workbook
            IConnection Connection = workbook.Connections.Add("Connection1", "Sample connection with MsAccess", Connectionstring, query, ExcelCommandType.Sql);
            //Add the QueryTable to sheet object
            sheet.ListObjects.AddEx(ExcelListObjectSourceType.SrcQuery, Connection, sheet.Range["A1"]);

            //Refresh the Connection for include the data
            if (refresh.IsChecked.Value)
            {
                sheet.ListObjects[0].Refresh();
                sheet.UsedRange.AutofitColumns();
            }

            //Set the Workbook version as excel 2007
            if (this.rdButtonxlsx.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2007;
                fileName = "ExternalConnection.xlsx";
                //Set the Workbook version as Excel 2010
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2010;
                fileName = "ExternalConnection.xlsx";
                //Set the Workbook version as Excel 2010
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2013;
                fileName = "ExternalConnection.xlsx";
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
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GenerateXls(listCustomer.SelectedItems);

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process.Start((fileName));

                        //Exit
                        this.Close();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("MS Excel is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
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
        #endregion
        #region "HelperMethod"
        ///<summary>
        /// Get the input file and return the path of the file
        ///</summary>
        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }

        ///<summary>
        /// Get the image file and return the path of the image file
        ///</summary>
        private string GetFullImagePath(string inputImage)
        {
            return string.Format(DEFAULTIMAGEPATH, inputImage);
        }
        #endregion

    }
}
