#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
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
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for EncryptAndDecrypt.xaml
    /// </summary>
    public partial class EncryptAndDecrypt : DemoControl
    {
        # region Private Members
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        # endregion

        # region Constructor
        /// <summary>
        /// EncryptAndDecrypt constructor
        /// </summary>
        public EncryptAndDecrypt()
        {
            InitializeComponent();
        }
        # endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        /// <summary>
        /// Encrypt the selected spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                if (rdbtnXLSX.IsChecked.Value)
                    application.DefaultVersion = ExcelVersion.Xlsx;
                else
                    application.DefaultVersion = ExcelVersion.Excel97to2003;

                // Opening the Existing Worksheet from a Workbook.
                IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\Encrypt.xlsx");

                //Encrypt the workbook with password.
                workbook.PasswordToOpen = "syncfusion";

                try
                {
                    //Save the workbook to disk.
                    string fileName = "EncryptedWorkbook";
                    if (rdbtnXLS.IsChecked.Value)
                        fileName = fileName + ".xls";
                    else
                        fileName = fileName + ".xlsx";

                    workbook.SaveAs(fileName);

                    //Close the workbook.
                    workbook.Close();
                    excelEngine.Dispose();

                    //Message box confirmation to view the created spreadsheet.
                    if (MessageBox.Show("Document is encrypted. Do you want to view the encrypted workbook?", "Workbook has been created",
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Decrypt the selected spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                if (rdbtnXLSX.IsChecked.Value)
                    application.DefaultVersion = ExcelVersion.Xlsx;
                else
                    application.DefaultVersion = ExcelVersion.Excel97to2003;

                // Opening the encrypted Workbook.
                IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\EncryptedSpreadsheet.xlsx", ExcelParseOptions.Default, true, "syncfusion");

                //Modify the decrypted document.
                workbook.Worksheets[0].Range["B2"].Text = "Demo for workbook decryption with Essential XlsIO";
                workbook.Worksheets[0].Range["B5"].Text = "This document is decrypted using password 'syncfusion'";

                workbook.PasswordToOpen = "";

                try
                {
                    //Save the workbook to disk.
                    string fileName = "Decrypt";
                    if (rdbtnXLS.IsChecked.Value)
                        fileName = fileName + ".xls";
                    else
                        fileName = fileName + ".xlsx";

                    workbook.SaveAs(fileName);

                    //Close the workbook.
                    workbook.Close();
                    excelEngine.Dispose();

                    //Message box confirmation to view the created spreadsheet.
                    if (MessageBox.Show("Document is decrypted and modified. Do you want to view the modified workbook?", "Workbook has been created",
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
                catch (System.ArgumentException)
                {
                    MessageBox.Show("Password is wrong!!! Please re-enter correct password.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        # endregion
    }
}