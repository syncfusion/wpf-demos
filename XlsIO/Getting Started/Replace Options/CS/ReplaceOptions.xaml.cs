#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace EssentialXlsIOSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ReplaceOptions : ChromelessWindow
    {
        #region Constants
        private const string DEFAULTPATH = @"..\..\..\..\..\..\..\..\..\..\Common\Data\XlsIO\{0}";
        private const string DEFAULTIMAGEPATH = @"..\..\..\..\..\..\..\..\..\..\Common\Images\XlsIO\{0}";
        #endregion
        string fileName = "ReplaceOptions.xlsx";
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public ReplaceOptions()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);

            string[] findOptions = { "Berlin", "8000", "Representative", "3/6/2013" };

            for (int i = 0; i < findOptions.Length; i++)
            {
                combo1.Items.Add(findOptions[i]);
            }
            combo1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
#if NETCORE
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"..\..\..\..\..\..\..\Common\Data\XlsIO\ReplaceOptions.xlsx")
            {
                UseShellExecute = true
            };
            process.Start();            
#else
            System.Diagnostics.Process.Start(@"..\..\..\..\..\..\Common\Data\XlsIO\ReplaceOptions.xlsx");
#endif
        }

        private void button2_Click(object sender, RoutedEventArgs e)
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
#if NETCORE
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
#else
                        System.Diagnostics.Process.Start(fileName);
#endif                  

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

        private string GetFullImagePath(string imageFile)
        {
            return string.Format(DEFAULTIMAGEPATH, imageFile);
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
#if NETCORE
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\ReplaceOptions.xlsx", ExcelOpenType.Automatic);
#else
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\ReplaceOptions.xlsx", ExcelOpenType.Automatic);
#endif
            IWorksheet sheet = workbook.Worksheets[0];

            ExcelFindOptions options = ExcelFindOptions.None;
            if (check1.IsChecked == true) options |= ExcelFindOptions.MatchCase;
            if (check2.IsChecked == true) options |= ExcelFindOptions.MatchEntireCellContent;

            sheet.Replace(combo1.Text, textBox1.Text, options);

            workbook.SaveAs(fileName);
            workbook.Close();
            excelEngine.Dispose();
            #endregion
        }
        #endregion
    }
}