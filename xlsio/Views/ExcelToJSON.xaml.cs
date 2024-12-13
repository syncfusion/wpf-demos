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
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelToJSON.xaml
    /// </summary>
    public partial class ExcelToJSON : DemoControl
    {
        # region Constructor
        /// <summary>
        /// ExcelToJSON constructor
        /// </summary>
        public ExcelToJSON()
        {
            InitializeComponent();    

            string[] findOptions = { "Workbook", "Worksheet", "Range" };

            for (int i = 0; i < findOptions.Length; i++)
            {
                cmbConvert.Items.Add(findOptions[i]);
            }
            cmbConvert.SelectedIndex = 0;
            chkboxAsSchema.IsChecked = true;
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
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\ExcelToJSON.xlsx") { UseShellExecute = true };
            process.Start();
        }

        /// <summary>
        /// Convert To JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelEngine excelEngine = new ExcelEngine();
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(@"Assets\XlsIO\ExcelToJSON.xlsx", ExcelOpenType.Automatic);
                IWorksheet sheet = workbook.Worksheets[0];
                IRange range = sheet.Range["A2:B10"];

                bool isSchema = chkboxAsSchema.IsChecked.Value;

                string fileName = "ExcelToJSON.json";

                if (cmbConvert.SelectedIndex == 0)
                    workbook.SaveAsJson(fileName, isSchema);
                else if (cmbConvert.SelectedIndex == 1)
                    workbook.SaveAsJson(fileName, sheet, isSchema);
                else if (cmbConvert.SelectedIndex == 2)
                    workbook.SaveAsJson(fileName, range, isSchema);

                workbook.Close();
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the JSON?", "JSON has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the JSON file using the default Application
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName) { UseShellExecute = true };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}