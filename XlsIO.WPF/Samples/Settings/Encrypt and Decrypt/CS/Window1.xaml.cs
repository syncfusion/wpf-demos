#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
using Microsoft.Win32;
using Syncfusion.Windows.Shared;

namespace EncryptionDecryption
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\";
            this.image1.Source = (ImageSource)img.ConvertFromString(file + "xlsio_header.png");
            
        }
        # endregion

        # region Events

        # region Process Spreadsheet
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
                if ((bool)this.rdButtonxlsxDecrypt.IsChecked)
                    application.DefaultVersion = ExcelVersion.Excel2007;
                else if ((bool)this.rdButtonexcel2010Decrypt.IsChecked)
                    application.DefaultVersion = ExcelVersion.Excel2010;
                else if ((bool)this.rdButtonexcel2013Decrypt.IsChecked)
                    application.DefaultVersion = ExcelVersion.Excel2013;

                // Opening the encrypted Workbook.
                IWorkbook workbook = application.Workbooks.Open(this.txtDecryptSource.Text, ExcelParseOptions.Default, true, this.txtDeOpen.Password);

                //Modify the decrypted document.
                workbook.Worksheets[0].Range["B2"].Text = "Demo for workbook decryption with Essential XlsIO";
                workbook.Worksheets[0].Range["B5"].Text = "This document is decrypted using password " + this.txtDeOpen.Password;

                try
                {
                    //Save the workbook to disk.
                    workbook.SaveAs("Decrypt.xlsx");

                    //Close the workbook.
                    workbook.Close();
                    excelEngine.Dispose();

                    //Message box confirmation to view the created spreadsheet.
                    if (MessageBox.Show("Document is decrypted and modified. Do you want to view the modified workbook?", "Workbook has been created",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process.Start("Decrypt.xlsx");

                    }
                    else
                        // Exit
                        this.Close();

                    //Reset the controls of successful creation of spreadsheet.
                    this.txtDecryptSource.Text = String.Empty;
                    this.txtDeOpen.Password = String.Empty;
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
                if ((bool)this.rdButtonxlsx.IsChecked)
                    application.DefaultVersion = ExcelVersion.Excel2007;
                else if ((bool)this.rdButtonexcel2010.IsChecked)
                    application.DefaultVersion = ExcelVersion.Excel2010;
                if ((bool)this.rdButtonexcel2013.IsChecked)
                    application.DefaultVersion = ExcelVersion.Excel2013;

                // Opening the Existing Worksheet from a Workbook.
                IWorkbook workbook = application.Workbooks.Open(this.txtEncryptSource.Text);

                //Encrypt the workbook with password.
                workbook.PasswordToOpen = this.txtEnOpen.Password;

                try
                {
                    //Save the workbook to disk.
                    workbook.SaveAs("EncryptedWorkbook.xlsx");

                    //Close the workbook.
                    workbook.Close();
                    excelEngine.Dispose();

                    //Message box confirmation to view the created spreadsheet.
                    if (MessageBox.Show("Document is encrypted. Do you want to view the encrypted workbook?", "Workbook has been created",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process.Start("EncryptedWorkbook.xlsx");
                    }

                    //Reset the controls of successful creation of spreadsheet.
                    this.txtEncryptSource.Text = String.Empty;
                    this.txtEnOpen.Password = String.Empty;
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
        # endregion

        # region Get Spreadsheet
        /// <summary>
        /// Get the spreadsheet to encrypt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseEncrypt_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.Filter = "Excel 2007 Spreadsheets (*.xlsx)|*.xlsx";
            openFileDialog1.Title = "Choose a Spreadsheet to Encrypt";

            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog().Value)
            {
                this.txtEncryptSource.Text = openFileDialog1.FileName;
                this.btnEncrypt.IsEnabled = true;
            }
            else
                this.btnEncrypt.IsEnabled = false;
        }

        /// <summary>
        /// Get the spreadsheet to decrypt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseDecrypt_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.Filter = "Excel 2007 Spreadsheets (*.xlsx)|*.xlsx";
            openFileDialog1.Title = "Choose a Spreadsheet to Decrypt";

            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog().Value)
            {
                this.txtDecryptSource.Text = openFileDialog1.FileName;
                this.btnDecrypt.IsEnabled = true;
            }
            else
                this.btnDecrypt.IsEnabled = false;
        }
        # endregion

        # endregion
    }
}