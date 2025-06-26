#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    /// Interaction logic for ReplaceOptions.xaml
    /// </summary>
    public partial class ReplaceOptions : DemoControl
    {
        #region Constants
        private const string DEFAULTPATH = @"Assets\XlsIO\{0}";
        string fileName = "ReplaceOptions.xlsx";
        #endregion

        # region Constructor
        /// <summary>
        /// ReplaceOptions constructor
        /// </summary>
        public ReplaceOptions()
        {
            InitializeComponent();

            string[] findOptions = { "Berlin", "8000", "Representative", "3/6/2013" };

            for (int i = 0; i < findOptions.Length; i++)
            {
                comboBox1.Items.Add(findOptions[i]);
            }
            comboBox1.SelectedIndex = 0;
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
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\ReplaceOptions.xlsx")
            {
                UseShellExecute = true
            };
            process.Start();
        }

        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReplaceData(fileName);

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                        {
                            UseShellExecute = true
                        };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
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
        /// Get the input file and return the path of input file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }
        /// <summary>
        /// Replaces data in the given excel file.
        /// </summary>
        /// <param name="fileName">The excel file in which replace operation is to be done.</param>
        private void ReplaceData(string fileName)
        {
            #region Workbook Initialize

            ExcelEngine excelEngine = new ExcelEngine();
            //Get the path of the input file
            string inputPath = GetFullTemplatePath("ReplaceOptions.xlsx");
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(@"Assets\XlsIO\ReplaceOptions.xlsx", ExcelOpenType.Automatic);            IWorksheet sheet = workbook.Worksheets[0];
            ExcelFindOptions options = ExcelFindOptions.None;
            if (checkBox1.IsChecked == true) options |= ExcelFindOptions.MatchCase;
            if (checkBox2.IsChecked == true) options |= ExcelFindOptions.MatchEntireCellContent;

            sheet.Replace(comboBox1.Text, textBox1.Text, options);

            workbook.SaveAs(fileName);
            workbook.Close();
            excelEngine.Dispose();
            #endregion
        }
        #endregion
    }
}