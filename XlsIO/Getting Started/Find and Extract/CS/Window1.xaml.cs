#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.Windows.Shared;
using System.Globalization;

namespace FindAndExtract
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
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
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Open an existing spreadsheet which will be used as a template for generating the new spreadsheet.
            //After opening, the workbook object represents the complete in-memory object model of the template spreadsheet.
#if NETCORE
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\FindAndExtract.xls");
#else
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\FindAndExtract.xls");
#endif

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            IRange result;
            string selection = listBox.SelectedItem.ToString().Substring(listBox.SelectedItem.GetType().FullName.Length + 2);
            
            try
            {
                #region Find and Extract Numbers
                if (selection == "Number with format 0.00")
                {
                    result = sheet.FindFirst(1000000.00075, ExcelFindType.Number);

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }
                if (selection == "Number with format $#,##0.00")
                {
                    result = sheet.FindFirst(3.2, ExcelFindType.Number);

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }

                #endregion

                #region Find and Extract DateTime
                if (selection == "DateTime with format m/d/yy h:mm")
                {
                    result = sheet.FindFirst(DateTime.Parse("12/1/2007  1:23:00 AM", CultureInfo.InvariantCulture));

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }
                if (selection == "Time with format h:mm:ss AM/PM")
                {
                    result = sheet.FindFirst(DateTime.Parse("1/1/2007  2:23:00 AM", CultureInfo.InvariantCulture));

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.DateTime.ToString();
                }
                if (selection == "Date with format d-mmm-yy")
                {
                    result = sheet.FindFirst(DateTime.Parse("12/4/2007  1:23:00 AM", CultureInfo.InvariantCulture));

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }
                if (selection == "Date with format Saturday, December 01, 2007")
                {
                    result = sheet.FindFirst(DateTime.Parse("8/1/2007  3:23:00 AM", CultureInfo.InvariantCulture));

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }
                #endregion

                #region Find and Extract Text

                if (selection == "Text")
                {
                    result = sheet.FindFirst("Simple text", ExcelFindType.Text);

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }
                if (selection == "Text With Styles and Patterns")
                {
                    result = sheet.FindFirst("Text with Styles and patterns", ExcelFindType.Text);

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }
                if (selection == "Number with Text Format")
                {
                    result = sheet.FindFirst("$8.200", ExcelFindType.Text);

                    //Gets the cell display text
                    textDisplay.Content = result.DisplayText.ToString();

                    //Gets the cell value
                    textValue.Content = result.Value2.ToString();
                }
                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Please select an item from list box", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}