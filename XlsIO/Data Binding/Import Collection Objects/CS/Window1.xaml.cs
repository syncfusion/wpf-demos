#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using System.Data;
using Syncfusion.XlsIO;
using Syncfusion.Windows.Shared;

namespace CollectionObjects
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private string fileName;
        #endregion

        #region Constants
#if NETCORE
        private const string DEFAULTPATH = @"..\..\..\..\..\..\..\Common\Data\XlsIO\{0}";
#else
        private const string DEFAULTPATH = @"..\..\..\..\..\..\Common\Data\XlsIO\{0}";
#endif
        #endregion

        # region Constructor and Load
        /// <summary>
        /// Window constructor
        /// </summary>
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

        /// <summary>
        /// Window Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            #region Initialize Workbook
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.
            //Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            //Set the Default version as Excel 97to2003
            if (this.rdButtonxls.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel97to2003;
                fileName = "CollectionObject.xls";
            }
            //Set the Default version as Excel 2007
            else if (this.rdButtonxlsx.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2007;
                fileName = "CollectionObject.xlsx";
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2010;
                fileName = "CollectionObject.xlsx";
            }
            else 
            {
                application.DefaultVersion = ExcelVersion.Excel2013;
                fileName = "CollectionObject.xlsx";
            }
            //Create a new spreadsheet.
            IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            sheet.ImportData((List<Brand>)this.dataGrid.ItemsSource, 4, 1, true);

            #region Define Styles
            IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
            IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

            pageHeader.Font.FontName = "Calibri";
            pageHeader.Font.Size = 16;
            pageHeader.Font.Bold = true;
            pageHeader.Color = System.Drawing.Color.FromArgb(0, 146, 208, 80);
            pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

            tableHeader.Font.Bold = true;
            tableHeader.Font.FontName = "Calibri";
            tableHeader.Color = System.Drawing.Color.FromArgb(0, 146, 208, 80);

            #endregion

            #region Apply Styles
            // Apply style for header
            sheet["A1:C2"].Merge();
            sheet["A1"].Text = "Automobile Brands in the US";
            sheet["A1"].CellStyle = pageHeader;

            sheet["A4:C4"].CellStyle = tableHeader;

            sheet["A1:C1"].CellStyle.Font.Bold = true;
            sheet.UsedRange.AutofitColumns();

            #endregion

            #endregion

            try
            {
                #region Save the Workbook
                //Saving the workbook to disk. This spreadsheet is the result of opening and modifying
                //an existing spreadsheet and then saving the result to a new workbook.
                workbook.SaveAs(fileName);
                #endregion

                #region Workbook Close and Dispose
                //Close the workbook.
                workbook.Close();

                excelEngine.Dispose();
                #endregion

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
#else
                    Process.Start(fileName);
#endif
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }

        # endregion
        #region HelperMethods
        /// <summary>
        /// Get the file path of input file and return the same
        /// </summary>
        /// <param name="inputPath">Input file</param>
        /// <returns>path of the input file</returns>
        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }
        #endregion
        #region Export CLRObjects
        private void buttonImport_Click(object sender, RoutedEventArgs e)
        {
            //Imports Data from the Template spreadsheet into the Grid.

            #region Workbook Initialize
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Get path of the Input file
            string inputPath = GetFullTemplatePath("ExportData.xlsx");

            //After opening, the workbook object represents the complete in-memory object model of the template spreadsheet.
            IWorkbook workbook = application.Workbooks.Open(inputPath);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];
            #endregion

            #region Export CLR Object from Workbook
            //Read data from spreadsheet.

            Dictionary<string, string> mappingProperties = new Dictionary<string, string>();
            mappingProperties.Add("Brand", "BrandName");
            mappingProperties.Add("Vehicle Type", "VehicleType.VehicleName");
            mappingProperties.Add("Model", "VehicleType.Model.ModelName");

            List<Brand> CLRObjects = worksheet.ExportData<Brand>(4, 1, 141, 3, mappingProperties);
            dataGrid.ItemsSource = CLRObjects;
            btnExport.IsEnabled = true;
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserResizeRows = false;
            #endregion

            #region Workbook Close and Dispose
            //Close the workbook.
            workbook.Close();

            //No exception will be thrown if there are unsaved workbooks.
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
            #endregion
        }
        #endregion

        #region Input Template
        private void buttonInput_Click(object sender, RoutedEventArgs e)
        {
            //Get the path of the input file
            string inputPath = GetFullTemplatePath("ExportData.xlsx");
            //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(inputPath)
            {
                UseShellExecute = true
            };
            process.Start();
#else
            Process.Start(inputPath);
#endif
        }
        #endregion
    }
}