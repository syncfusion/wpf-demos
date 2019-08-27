#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Threading;

namespace MotionChartDemo_2012
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        DispatcherTimer _timer;
        ViewModel model = new ViewModel();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < 12; j++)
            {
                this.Chart.Areas[0].Series[j].DataSource = new ObservableCollection<Country>() { model.DataValue1[i][j]};
            }
            this.Txt.Text = model.DataValue1[i][0].Year.ToString();
            i++;
            if (i == 51)
            {
                i = 0;
                _timer.Stop();
                this.Txt.Text = "";
            }
        }

        private void Series1_MouseMove_1(object sender, Syncfusion.Windows.Chart.ChartMouseEventArgs e)
        {
            this.Interactive.HorizontalLabelVisibility = Visibility.Visible;
            this.Interactive.VerticalLabelVisibility = Visibility.Visible;
            this.Primary.InteractiveCursorTemplate = this.Grid.Resources["Xlabeltemplate"] as DataTemplate;
            this.Secondary.InteractiveCursorTemplate = this.Grid.Resources["Ylabeltemplate"] as DataTemplate;

        }

        private void Series1_MouseLeave_1(object sender, ChartMouseEventArgs e)
        {
            this.Interactive.HorizontalLabelVisibility = Visibility.Collapsed;
            this.Interactive.VerticalLabelVisibility = Visibility.Collapsed;
            this.Primary.InteractiveCursorTemplate = null;
            this.Secondary.InteractiveCursorTemplate = null;
        }
    }
    /// <summary>
    /// Model Class
    /// </summary>
    public class Country
    {
        public double Value { get; set; }
        public int Year { get; set; }
        public double X { get; set; }
        public double Size { get; set; }
    }

    /// <summary>
    /// ViewModel Class
    /// </summary>
    public class ViewModel
    {
        Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
        public ViewModel()
        {
            string filePath = System.IO.Path.GetFullPath(@"..\..\Data\Agriculture.xlsx");
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = ExcelObj.Workbooks.Open(
               filePath, 0, true, 5,
                "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
                0, true);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            DataValue1 = new ObservableCollection<ObservableCollection<Country>>();
            double[] bubSize = new double[12] { 30, 55, 15, 50, 20, 13, 18, 25, 17, 25, 22, 35 };
            for (int i = 2; i <= colCount; i++)
            {
                DataValue = new ObservableCollection<Country>();
                for (int j = 2; j < rowCount; j++)
                {
                    double value = (xlRange.Cells[j, i].Value2 == null ? 0.0 : xlRange.Cells[j, i].Value2);
                    int year = Convert.ToInt32(xlRange.Cells[1, i].Value2);
                    double x = i - 1;
                    double size = bubSize[j - 2];
                    DataValue.Add(new Country() { Value = value, Year = year, X = x, Size = size });
                }
                DataValue1.Add(DataValue);
            }
        }
        public ObservableCollection<Country> DataValue { get; set;}
        public ObservableCollection<ObservableCollection<Country>> DataValue1 { get; set; }
    }

    /// <summary>
    /// Interactive Cursor X-Axis Label converter
    /// </summary>
    public class XvalueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is InteractiveCursorLabelContent)
                {
                    InteractiveCursorLabelContent v1 = (InteractiveCursorLabelContent)value;
                    if (v1.DataPoint != null)
                    {
                        double ab = (double)v1.DataPoint.X;
                        return Math.Round(ab).ToString();
                    }
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Interactive Cursor Y-Axis Label converter
    /// </summary>
    public class YvalueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is InteractiveCursorLabelContent)
                {
                    InteractiveCursorLabelContent v1 = (InteractiveCursorLabelContent)value;
                    if (v1.DataPoint != null)
                    {
                        double ab = (double)v1.DataPoint.Y;
                        return Math.Round(ab).ToString();
                    }
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bubble Segment X,Y Value Converter
    /// </summary>
    public class ContentConverter : IValueConverter
    {
        #region IValueConverter Members
        double[] newvalX = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        double[] oldvalX = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        double[] newvalY = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        double[] oldvalY = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int _incX = -1;
        private int _incY = -1;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string param = parameter as string;
                if (param == "X")
                {
                    if (value is ChartBubbleSegment)
                    {
                        double mydouble = (double)(value as ChartBubbleSegment).X;
                        _incX++;
                        if (_incX == 12)
                            _incX = 0;
                        newvalX[_incX] = oldvalX[_incX];
                        oldvalX[_incX] = mydouble;
                        return newvalX[_incX];
                    }
                }
                if (param == "Y")
                {
                    if (value is ChartBubbleSegment)
                    {
                        double mydouble = (double)(value as ChartBubbleSegment).Y;
                        _incY++;
                        if (_incY == 12)
                            _incY = 0;
                        newvalY[_incY] = oldvalY[_incY];
                        oldvalY[_incY] = mydouble;
                        return newvalY[_incY];
                    }
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Bubble Segment Size Converter
    /// </summary>
    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && ((ChartSegment)(value)).Series != null)
            {
                var size = (((ChartSegment)(value)).CorrespondingPoints[0].DataPoint).Values[1];
                return size;
            }
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
