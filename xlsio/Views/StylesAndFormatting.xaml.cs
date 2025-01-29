#region Copyright Syncfusion Inc. 2001 - 2012
// Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
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
    /// Interaction logic for StylesAndFormatting.xaml
    /// </summary>
    public partial class StylesAndFormatting : DemoControl
    {
        # region Constructor
        /// <summary>
        /// StylesAndFormatting Constructor
        /// </summary>
        public StylesAndFormatting()
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

        # region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 12 worksheets
            IWorkbook workbook = application.Workbooks.Create(12);
            IWorkbook tempWorkbook = application.Workbooks.Open(@"Assets\XlsIO\CalendarTemplate.xlsx");
            workbook.Worksheets.AddCopyAfter(tempWorkbook.Worksheets[0], workbook.Worksheets[11]);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet;

            # region Calendar

            # region Draw Calendar
            String[] monthArray = new String[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            String[] dateArray = new String[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            System.Drawing.Color[] colorArray = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(149, 55, 53), System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.FromArgb(0, 32, 96), System.Drawing.Color.FromArgb(0, 176, 80), System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.FromArgb(128, 128, 128), System.Drawing.Color.FromArgb(255, 0, 0), System.Drawing.Color.FromArgb(96, 73, 123), System.Drawing.Color.FromArgb(169, 161, 117), System.Drawing.Color.FromArgb(0, 176, 240), System.Drawing.Color.FromArgb(192, 0, 0), System.Drawing.Color.FromArgb(63, 49, 81), System.Drawing.Color.FromArgb(192, 0, 0) };

            int cMonth = DateTime.Today.Month - 1;

            for (int monIndex = 1; monIndex < 13; monIndex++)
            {
                sheet = workbook.Worksheets[monIndex - 1];
                sheet.Name = monthArray[monIndex - 1];

                sheet.Range["B3:H3"].Merge();
                sheet.Range["B4:H4"].Merge();
                sheet.IsGridLinesVisible = false;

                //Write the month as the heading
                sheet.Range["B3"].Text = monthArray[monIndex - 1];

                //Apply styles for the month title
                sheet.Range["B3:H3"].HorizontalAlignment = ExcelHAlign.HAlignCenter;
                sheet.Range["B3:H3"].VerticalAlignment = ExcelVAlign.VAlignCenter;
                sheet.Range["B3:H3"].BorderAround(ExcelLineStyle.Thin, System.Drawing.Color.Brown);
                sheet.Range["B3:H3"].RowHeight = 30;

                IStyle style = sheet.Range["B3"].CellStyle;
                style.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                style.Interior.FillPattern = ExcelPattern.Gradient;
                style.Interior.Gradient.TwoColorGradient(ExcelGradientStyle.Diagonl_Up, ExcelGradientVariants.ShadingVariants_3);
                style.Interior.Gradient.ForeColorIndex = ExcelKnownColors.White;
                style.Interior.Gradient.BackColor = colorArray[monIndex - 1];
                IFont font = style.Font;
                font.FontName = "Segoe UI";
                font.Size = 22;
                font.Italic = true;

                //Write the weekdays
                for (int i = 2, j = 0; i < 9; i++, j++)
                {
                    sheet.SetValue(5, i, dateArray[j]);
                    sheet.Range[5, i].HorizontalAlignment = ExcelHAlign.HAlignCenter;
                }

                //Get the number of days in the month
                int days = DateTime.DaysInMonth(DateTime.Today.Year, monIndex);

                //Write the calendar
                DateTime firstDay = new DateTime(DateTime.Today.Year, monIndex, 1);
                IRange range = sheet.FindFirst(firstDay.Date.DayOfWeek.ToString(), ExcelFindType.Text);

                int row = range.End.Row + 1;
                int column = range.End.Column;
                int date = 1;

                while (date < days + 1)
                {
                    for (; column < 9; column++)
                    {
                        sheet.Range[row, column].Number = date;
                        date++;
                        if (date == days + 1)
                            break;
                    }
                    column = 2;
                    row++;
                }

                //Format Sunday
                sheet.Range["B5:B11"].BuiltInStyle = BuiltInStyles.WarningText;
                sheet.Range["B5"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

                //Format day title
                sheet.Range["B5:H5"].BuiltInStyle = BuiltInStyles.Heading4;
                sheet.Range["B5:H5"].CellStyle.Font.Size = 10;

                //Border around the entire calendar
                sheet.UsedRange.BorderAround(ExcelLineStyle.Double, System.Drawing.Color.Black);
                sheet.UsedRange.BorderInside(ExcelLineStyle.Hair, System.Drawing.Color.Black);

                sheet.Range["B3"].RowHeight = 35;
                sheet.Range["B5:H11"].RowHeight = 60;
                sheet.UsedRange.ColumnWidth = 15;

                //Set Legend
                sheet["K7"].BuiltInStyle = BuiltInStyles.Accent2_20;
                sheet["K8"].BuiltInStyle = BuiltInStyles.Accent4_20;

                sheet.Range["L7"].Text = "Holidays";
                sheet.Range["L8"].Text = "Today";
                sheet.Range["L7:L8"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
            }
            # endregion

            # region Styles for today
            foreach (IWorksheet cSheet in workbook.Worksheets)
            {
                if (cSheet.Name == monthArray[cMonth])
                {
                    //Apply styles for today
                    IRange tRange = cSheet.FindFirst(DateTime.Today.Day, ExcelFindType.Number);
                    tRange.BuiltInStyle = BuiltInStyles.Accent4_20;
                    tRange.CellStyle.Font.RGBColor = System.Drawing.Color.Purple;

                    tRange.AddComment().Text = "Today";
                    tRange.Comment.Width = 100;
                    tRange.Comment.Height = 40;
                    cSheet.Activate();
                }
                else if (cSheet.Name == "Holidays")
                {
                    cSheet.Range["B3"].CellStyle.Interior.FillPattern = ExcelPattern.Gradient;
                     cSheet.Range["B3"].CellStyle.Font.FontName = "Calibri";
                    cSheet.Range["B3"].CellStyle.Font.Size = 11;
                    cSheet.Range["B3"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                }
            }

            # endregion

            # region Update Holidays
            workbook.Worksheets[12].EnableSheetCalculations();
            //Highlight holidays
            for (int i = 8; i <= 18; i++)
            {
                IRange range = workbook.Worksheets[12].Range["D" + i.ToString()];
                range.Value = range.CalculatedValue;
                int sheetIndex = range.DateTime.Month;
                IRange holiday = workbook.Worksheets[sheetIndex - 1].FindFirst(range.DateTime.Day, ExcelFindType.Number);
                holiday.AddComment().Text = workbook.Worksheets[12].Range["B" + i.ToString()].Text;
                holiday.Comment.Width = 100;
                holiday.Comment.Height = 40;
                
                holiday.BuiltInStyle = BuiltInStyles.Accent2_20;
                holiday.CellStyle.Font.RGBColor = System.Drawing.Color.Red;
            }

            # endregion

            # endregion

            try
            {
                string filename = "Formatting.xlsx";
                //Saving the workbook to disk.
                workbook.SaveAs(filename);

                //Close the workbook.
                workbook.Close();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
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

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\CalendarTemplate.xlsx") { UseShellExecute = true };
            process.Start();
        }
        # endregion
    }
}