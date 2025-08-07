#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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
using System.IO;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoFill.xaml
    /// </summary>
    public partial class AutoFill : DemoControl
    {      
        ExcelEngine excelEngine;        
        string fileName = "FillOption.xlsx";
        private readonly List<string> autoFillOptions = new List<string> { "Default", "Copy", "Series", "Formats", "Values", "Days", "Weekdays", "Months", "Years", "Linear Trend", "Growth Trend" };
        private readonly List<string> fillSeriesOptions = new List<string> { "Linear", "Growth", "Days", "Weekdays", "Months", "Years", "Auto Fill" };
        private readonly List<string> trendOnlyOptions = new List<string>() { "Linear", "Growth" };
        private bool m_initializing;

        #region Constructor
        public AutoFill()
        {
            m_initializing = true;
            
            InitializeComponent();
            m_initializing = false;
            
            this.StepValueTextBox.IsEnabled = false;
            this.StopValueTextBox.IsEnabled = false;
            this.TrendCheckBox.IsEnabled = false;
            this.SeriesByComboBox.IsEnabled = false;
            this.FillOptionComboBox.ItemsSource = autoFillOptions;
            this.FillOptionComboBox.SelectedIndex = 0;
            excelEngine = new ExcelEngine();
            
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            excelEngine.Dispose();
        }
        
        private void CreateDocument_Click(object sender, RoutedEventArgs e)
        {
            if (this.FillOptionComboBox.SelectedItem == null)
                return;
            if(this.AutoFillRadio.IsChecked == true)
            {
                AutoFillMethod(GetAutoFillEnum(this.FillOptionComboBox.SelectedItem.ToString()));
            }
            else
            {
                FillSeriesMethod(GetFillSeriesEnum(this.FillOptionComboBox.SelectedItem.ToString()), (ExcelSeriesBy)Enum.Parse(typeof(ExcelSeriesBy), this.SeriesByComboBox.Text),this.StepValueTextBox.Text, this.StopValueTextBox.Text,(bool)this.TrendCheckBox.IsChecked);
            }
            try
            {

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


        private void TrendCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if ((bool)this.TrendCheckBox.IsChecked)
            {
                StepValueTextBox.Text = null;
                StopValueTextBox.Text = null;
                this.StepValueTextBox.IsEnabled = false;
                this.StopValueTextBox.IsEnabled = false;
            }
            else
            {
                this.StepValueTextBox.IsEnabled = true;
                this.StopValueTextBox.IsEnabled = true;
            }
        }
        /// <summary>
        /// Method to create a document with using AutoFill option.
        /// </summary>
        /// <param name="autoFillOption"></param>
        public void AutoFillMethod(ExcelAutoFillType autoFillOption)
        {

            //Instantiate the spreadsheet creation engine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                IWorkbook workbook = application.Workbooks.Create(1);

                IWorksheet sheet = workbook.Worksheets[0];
                sheet["A1"].Number = 2;
                sheet["A2"].Number = 4;
                sheet["A3"].Number = 6;

                switch (autoFillOption)
                {
                    case ExcelAutoFillType.FillDefault:
                    case ExcelAutoFillType.FillCopy:
                    case ExcelAutoFillType.FillValues:
                    case ExcelAutoFillType.FillSeries:
                    case ExcelAutoFillType.GrowthTrend:
                    case ExcelAutoFillType.LinearTrend:
                        {
                            sheet["A1:A3"].AutoFill(sheet["A4:A1000"], autoFillOption);
                            break;
                        }
                    case ExcelAutoFillType.FillFormats:
                        {
                            sheet["A1"].CellStyle.Color = System.Drawing.Color.Blue;
                            sheet["A2"].CellStyle.Color = System.Drawing.Color.Red;
                            sheet["A3"].CellStyle.Color = System.Drawing.Color.Chocolate;
                            sheet["A1:A3"].NumberFormat = "$0.00";
                            sheet["A1:A3"].AutoFill(sheet["A4:A1000"], autoFillOption);
                            break;
                        }
                    case ExcelAutoFillType.FillMonths:
                    case ExcelAutoFillType.FillDays:
                    case ExcelAutoFillType.FillWeekdays:
                    case ExcelAutoFillType.FillYears:
                        {
                            DateTime dateTime = new DateTime(2025, 1, 1);
                            sheet["A1"].Value2 = dateTime;
                            sheet["A2"].Value2 = dateTime.AddDays(1);
                            sheet["A3"].Value2 = dateTime.AddDays(2);
                            sheet["A1:A3"].NumberFormat = "m/d/yyyy";
                            sheet["A1:A3"].AutoFill(sheet["A4:A1000"], autoFillOption);
                            break;
                        }

                }

                sheet.UsedRange.ColumnWidth = 10;

                fileName = "AutoFill.xlsx";
                workbook.SaveAs(fileName);
            }

        }

        /// <summary>
        /// Method to apply fill series.
        /// </summary>
        /// <param name="fillSeries"></param>
        /// <param name="seriesBy"></param>
        /// <param name="stepValue"></param>
        /// <param name="stopValue"></param>
        /// <param name="enableTrend"></param>
        public void FillSeriesMethod(ExcelFillSeries fillSeries, ExcelSeriesBy seriesBy, object stepValue, object stopValue, bool enableTrend)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet sheet = workbook.Worksheets[0];
                if (seriesBy == ExcelSeriesBy.Columns)
                {
                    sheet["A1"].Number = 2;
                    sheet["A2"].Number = 4;
                    sheet["A3"].Number = 6;
                }
                else
                {
                    sheet["A1"].Number = 2;
                    sheet["B1"].Number = 4;
                    sheet["C1"].Number = 6;
                }

                stepValue = stepValue != null ? ConvertObject(stepValue.ToString()) : stepValue;
                stopValue = stopValue != null ? ConvertObject(stopValue.ToString()) : stopValue;

                switch (fillSeries)
                {
                    case ExcelFillSeries.AutoFill:
                    case ExcelFillSeries.Linear:
                    case ExcelFillSeries.Growth:
                        break;
                    case ExcelFillSeries.Years:
                    case ExcelFillSeries.Days:
                    case ExcelFillSeries.Weekdays:
                    case ExcelFillSeries.Months:
                        {
                            if (seriesBy == ExcelSeriesBy.Columns)
                            {
                                DateTime dateTime = new DateTime(2025, 1, 1);
                                sheet["A1"].Value2 = dateTime;
                                sheet["A2"].Value2 = dateTime.AddDays(1);
                                sheet["A3"].Value2 = dateTime.AddDays(2);
                                sheet["A1:A3"].NumberFormat = "m/d/yyyy";
                            }
                            else
                            {
                                DateTime dateTime = new DateTime(2025, 1, 1);
                                sheet["A1"].Value2 = dateTime;
                                sheet["B1"].Value2 = dateTime.AddDays(1);
                                sheet["C1"].Value2 = dateTime.AddDays(2);
                                sheet["A1:C1"].NumberFormat = "m/d/yyyy";
                            }

                            break;
                        }

                }
                if (seriesBy == ExcelSeriesBy.Columns)
                {
                    if (enableTrend)
                        sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, enableTrend);
                    else if (stepValue == null && stopValue == null)
                    {
                        if (fillSeries == ExcelFillSeries.AutoFill)
                        {
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, enableTrend);
                        }
                    }
                    else if ((stepValue == null && stopValue != null) || (stepValue != null && stopValue == null))
                    {
                        bool isStepValue = stepValue != null;
                        if (isStepValue)
                        {
                            if (stepValue is DateTime)
                                sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, isStepValue);
                            else if (stepValue is double)
                                sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stepValue, isStepValue);
                        }
                        else
                        {
                            if (stopValue is DateTime)
                                sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stopValue, isStepValue);
                            else if (stopValue is double)
                                sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stopValue, isStepValue);
                        }
                    }
                    else
                    {
                        if (stepValue is DateTime && stopValue is DateTime)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (DateTime)stopValue);
                        else if (stepValue is DateTime && stopValue is double)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (double)stopValue);
                        else if (stepValue is double && stopValue is double)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stepValue, (double)stopValue);
                        else if (stepValue is double && stopValue is DateTime)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stepValue, (DateTime)stopValue);
                    }

                }
                else
                {
                    if (enableTrend)
                        sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, enableTrend);
                    else if (stepValue == null && stopValue == null)
                    {
                        if (fillSeries == ExcelFillSeries.AutoFill)
                        {
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, enableTrend);
                        }
                    }
                    else if ((stepValue == null && stopValue != null) || (stepValue != null && stopValue == null))
                    {
                        bool isStepValue = stepValue != null;
                        if (isStepValue)
                        {
                            if (stepValue is DateTime)
                                sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, isStepValue);
                            else if (stepValue is double)
                                sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stepValue, isStepValue);
                        }
                        else
                        {
                            if (stopValue is DateTime)
                                sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stopValue, isStepValue);
                            else if (stopValue is double)
                                sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stopValue, isStepValue);
                        }
                    }
                    else
                    {
                        if (stepValue is DateTime && stopValue is DateTime)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (DateTime)stopValue);
                        else if (stepValue is DateTime && stopValue is double)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (double)stopValue);
                        else if (stepValue is double && stopValue is double)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stepValue, (double)stopValue);
                        else if (stepValue is double && stopValue is DateTime)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stepValue, (DateTime)stopValue);
                    }
                }

                sheet.UsedRange.ColumnWidth = 10;
                fileName = "FillSeries.xlsx";
                workbook.SaveAs(fileName);

            }
        }


        #region HelperMethod
        public object ConvertObject(string value)
        {
            double d;
            DateTime dt;
            if (string.IsNullOrEmpty(value)) return null;
            if (double.TryParse(value, out d)) return d;
            if (DateTime.TryParse(value, out dt)) return dt;
            return value;
        }
        private ExcelAutoFillType GetAutoFillEnum(string type)
        {
            switch (type)
            {
                case "Default":
                    return ExcelAutoFillType.FillDefault;
                case "Copy":
                    return ExcelAutoFillType.FillCopy;
                case "Series":
                    return ExcelAutoFillType.FillSeries;
                case "Formats":
                    return ExcelAutoFillType.FillFormats;
                case "Values":
                    return ExcelAutoFillType.FillValues;
                case "Days":
                    return ExcelAutoFillType.FillDays;
                case "Weekdays":
                    return ExcelAutoFillType.FillWeekdays;
                case "Months":
                    return ExcelAutoFillType.FillMonths;
                case "Years":
                    return ExcelAutoFillType.FillYears;
                case "Linear Trend":
                    return ExcelAutoFillType.LinearTrend;
                case "Growth Trend":
                    return ExcelAutoFillType.GrowthTrend;
                default:
                    return ExcelAutoFillType.FillDefault;
            }
        }
        private ExcelFillSeries GetFillSeriesEnum(string type)
        {
            switch (type)
            {
                case "Linear":
                    return ExcelFillSeries.Linear;
                case "Growth":
                    return ExcelFillSeries.Growth;
                case "Days":
                    return ExcelFillSeries.Days;
                case "Weekdays":
                    return ExcelFillSeries.Weekdays;
                case "Months":
                    return ExcelFillSeries.Months;
                case "Years":
                    return ExcelFillSeries.Years;
                case "Auto Fill":
                    return ExcelFillSeries.AutoFill;
                default:
                    return ExcelFillSeries.AutoFill;
            }
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (m_initializing)
                return;

            bool isAutoFill = AutoFillRadio.IsChecked == true;
            FillOptionComboBox.ItemsSource = isAutoFill ? autoFillOptions : fillSeriesOptions;
            //FillOptionComboBox.SelectedItem = null;
            if (isAutoFill)
            {
                SeriesByComboBox.SelectedIndex = 0;
                StepValueTextBox.Text = null;
                StopValueTextBox.Text = null;
            }
            FillOptionComboBox.SelectedIndex = 0;
            string option = FillOptionComboBox.SelectedItem?.ToString();
            bool isTrendOption = option == "Linear" || option == "Growth";
            TrendCheckBox.IsEnabled = isTrendOption;
            TrendRow.Visibility = isTrendOption?Visibility.Visible: Visibility.Collapsed;
            TrendCheckBox.IsChecked = false;
            TrendCheckBox.IsEnabled = false;
            TrendCheckBox.IsEnabled = isTrendOption;

            StepValueTextBox.IsEnabled = !isAutoFill;
            StopValueTextBox.IsEnabled = !isAutoFill;
            SeriesByComboBox.IsEnabled = !isAutoFill;
        }

        private void FillOptionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AutoFillRadio.IsChecked == true)
                return;

            string option = FillOptionComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(option))
                return;

            bool isTrendOption = option == "Linear" || option == "Growth";
            bool isAutoFillOption = option == "Auto Fill";

            TrendCheckBox.IsEnabled = isTrendOption;
            if ((bool)TrendCheckBox.IsChecked && !isTrendOption)
                TrendCheckBox.IsChecked = false;

            TrendCheckBox.Visibility = isTrendOption ? Visibility.Visible : Visibility.Collapsed;
            TrendRow.Visibility = isTrendOption ? Visibility.Visible : Visibility.Collapsed;

            bool isTrendChecked = TrendCheckBox.IsChecked == true;
            if (isAutoFillOption) 
            {
                StepValueTextBox.Text = null;
                StopValueTextBox.Text = null;
            }
            StepValueTextBox.IsEnabled = !isAutoFillOption && !isTrendChecked;
            StopValueTextBox.IsEnabled = !isAutoFillOption && !isTrendChecked;
        }
        #endregion

    }
}
