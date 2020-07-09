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

namespace EssentialXlsIOSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExcelToJSON : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public ExcelToJSON()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);

            string[] findOptions = { "Workbook", "Worksheet", "Range" };

            for (int i = 0; i < findOptions.Length; i++)
            {
                combo1.Items.Add(findOptions[i]);
            }
            combo1.SelectedIndex = 0;
            check1.IsChecked = true;
        }

        private void InputTemplte(object sender, RoutedEventArgs e)
        {
#if NETCORE
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"..\..\..\..\..\..\..\Common\Data\XlsIO\ExcelToJSON.xlsx")
            {
                UseShellExecute = true
            };
            process.Start();            
#else
            System.Diagnostics.Process.Start(@"..\..\..\..\..\..\Common\Data\XlsIO\ExcelToJSON.xlsx");
#endif
        }

        private void ConvertToJson(object sender, RoutedEventArgs e)
        {
            try
            {

                ExcelEngine excelEngine = new ExcelEngine();
#if NETCORE
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\ExcelToJSON.xlsx", ExcelOpenType.Automatic);
#else
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\ExcelToJSON.xlsx", ExcelOpenType.Automatic);
#endif
                IWorksheet sheet = workbook.Worksheets[0];
                IRange range = sheet.Range["A2:B10"];

                bool isSchema = check1.IsChecked.Value;

                string fileName = "ExcelToJSON.json";

                if (combo1.SelectedIndex == 0)
                    workbook.SaveAsJson(fileName, isSchema);
                else if (combo1.SelectedIndex == 1)
                    workbook.SaveAsJson(fileName, sheet, isSchema);
                else if (combo1.SelectedIndex == 2)
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
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                    // Exit
                    this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}