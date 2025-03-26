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
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Sorting.xaml
    /// </summary>
    public partial class Sorting : DemoControl
    {
        SortOn sortOn;
        ExcelEngine excelEngine;
        OrderBy orderBy;
        string fileName = "Sorting.xlsx";
        public Sorting()
        {
            InitializeComponent();
            this.DataContext = this;

            string[] columnNames = { "ID", "Name", "DOJ", "Salary" };
            cmbAlgorithm.Items.Add("Cell Color");
            cmbAlgorithm.Items.Add("Font Color");
            for (int i = 0; i < columnNames.Length; i++)
            {
                numColumn.Items.Add(columnNames[i]);
                numSecCol.Items.Add(columnNames[i]);
                numthirdCol.Items.Add(columnNames[i]);
            }
            numColumn.SelectedIndex = 0;
            numSecCol.SelectedIndex = 0;
            numthirdCol.SelectedIndex = 0;
            cmbAlgorithm.SelectedIndex = 0;
            gridLevel.Visibility = System.Windows.Visibility.Hidden;
            excelEngine = new ExcelEngine();
        }


        #region Helper Methods
        private void SortColor(string outFileName)
        {
            IWorkbook book = excelEngine.Excel.Workbooks.Open(@"Assets\XlsIO\SortingData.xlsx", ExcelOpenType.Automatic);
            IWorksheet sheet = book.Worksheets[1];
            IRange range = sheet["A2:C50"];

            IDataSort sorter = book.CreateDataSorter();
            sorter.SortRange = range;

            ISortField field = sorter.SortFields.Add(2, sortOn, orderBy);
            field.Color = System.Drawing.Color.Red;

            field = sorter.SortFields.Add(2, sortOn, orderBy);
            field.Color = System.Drawing.Color.Blue;

            sorter.Sort();
            book.Worksheets.Remove(0);
            book.SaveAs(outFileName);
            book.Close();

        }
        private void SortValues(string outFileName)
        {
            IWorkbook book = excelEngine.Excel.Workbooks.Open(@"Assets\XlsIO\SortingData.xlsx", ExcelOpenType.Automatic);
            IWorksheet sheet = book.Worksheets[0];
            IRange range = sheet["A2:D51"];

            //Create the data sorter.
            IDataSort sorter = book.CreateDataSorter();
            //Specify the range to sort.
            sorter.SortRange = range;

            //Specify the sort field attributes (column index and sort order)
            ISortField field = sorter.SortFields.Add((int)numColumn.SelectedIndex, sortOn, orderBy);

            if (chkAddLevel.IsChecked.Value)
            {
                field = sorter.SortFields.Add((int)numSecCol.SelectedIndex, sortOn, orderBy);
            }
            if (checkBox1.IsChecked.Value)
                field = sorter.SortFields.Add((int)numthirdCol.SelectedIndex, sortOn, orderBy);

            //sort the data based on the sort field attributes.
            sorter.Sort();
            book.Worksheets.Remove(1);
            book.SaveAs(outFileName);
            book.Close();

        }
#endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            excelEngine.Dispose();
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            gridLevel.Visibility = Visibility.Visible;
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            gridLevel.Visibility = Visibility.Hidden;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            sortOn = SortOn.Values;

            orderBy = (descedingRdBtn.IsChecked.Value) ? OrderBy.Descending : OrderBy.Ascending;

            try
            {
                SortValues(fileName);

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

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            orderBy = (!onBottomRdBtn.IsChecked.Value) ? OrderBy.OnTop : OrderBy.OnBottom;

            try
            {
                SortColor(fileName);

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

        private void chkAddLevel_Checked_1(object sender, RoutedEventArgs e)
        {
            gridLevel.Visibility = Visibility.Visible;
            checkBox1.Visibility = Visibility.Visible;
        }

        private void chkAddLevel_Unchecked_1(object sender, RoutedEventArgs e)
        {
            gridLevel.Visibility = System.Windows.Visibility.Hidden;
            this.checkBox1.Visibility = Visibility.Hidden;
        }

        private void checkBox1_Unchecked_1(object sender, RoutedEventArgs e)
        {
            gridthirdLevel.Visibility = Visibility.Hidden;
        }

        private void checkBox1_Checked_1(object sender, RoutedEventArgs e)
        {
            gridthirdLevel.Visibility = Visibility.Visible;
        }

        private void cmbAlgorithm_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAlgorithm.SelectedIndex == 0)
            {
                sortOn = SortOn.CellColor;
            }
            else if (cmbAlgorithm.SelectedIndex == 1)
            {
                sortOn = SortOn.FontColor;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\SortingData.xlsx")
            {
                UseShellExecute = true
            };
            process.Start();
        }
    }
}
