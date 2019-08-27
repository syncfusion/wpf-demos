#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Globalization;

namespace StockZoomingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        ViewModel viewmodel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            series.StrokeThickness = 0.3;
            series.Stroke = new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));


            SeriesInRangenavigator.StrokeThickness = 0.3;
            SeriesInRangenavigator.Stroke = new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));

        }

        private void onemonthdata_Click(object sender, RoutedEventArgs e)
        {
            var dateTime = Convert.ToDateTime(RangeNavigator.ViewRangeEnd);
            RangeNavigator.ViewRangeEnd = dateTime;
            RangeNavigator.ViewRangeStart = dateTime.AddMonths(-1);
        }

        private void threemonthsdata_Click(object sender, RoutedEventArgs e)
        {
            var dateTime = Convert.ToDateTime(RangeNavigator.ViewRangeEnd);
            RangeNavigator.ViewRangeEnd = dateTime;
            RangeNavigator.ViewRangeStart = dateTime.AddMonths(-3);
        }

        private void sixmonthsdata_Click(object sender, RoutedEventArgs e)
        {
            var dateTime = Convert.ToDateTime(RangeNavigator.ViewRangeEnd);
            RangeNavigator.ViewRangeEnd = dateTime;
            RangeNavigator.ViewRangeStart = dateTime.AddMonths(-6);
        }

        private void yeartoend_Click(object sender, RoutedEventArgs e)
        {
            int count = viewmodel.StockPriceDetails.Count;
            var dateTime = viewmodel.StockPriceDetails[count - 1].Date;
            RangeNavigator.ViewRangeEnd = dateTime;
            RangeNavigator.ViewRangeStart = new DateTime(dateTime.Year, 1, 1);
        }

        private void OneYear_Click(object sender, RoutedEventArgs e)
        {
            var dateTime = Convert.ToDateTime(RangeNavigator.ViewRangeEnd);
            RangeNavigator.ViewRangeEnd = dateTime;
            RangeNavigator.ViewRangeStart = dateTime.AddYears(-1);
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            int count = viewmodel.StockPriceDetails.Count;
            RangeNavigator.ViewRangeStart = viewmodel.StockPriceDetails[0].Date;
            RangeNavigator.ViewRangeEnd = viewmodel.StockPriceDetails[count - 1].Date;
        }
        private void axis1_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            if (axis1.ZoomPosition == 0 && axis1.ZoomFactor > 0.9 && RangeNavigator.Intervals[1].IntervalType == NavigatorIntervalType.Year)
                e.AxisLabel.LabelContent = e.AxisLabel.Position.FromOADate().ToString("MMM,yyyy");
            else
                e.AxisLabel.LabelContent = e.AxisLabel.Position.FromOADate().ToString("dd,MMM");
        }


    }

    public class Model
    {
        public DateTime Date { get; set; }
        public double YValue { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<Model>();
            DateTime date = new DateTime(2010, 5, 19);
            Random rd = new Random();
            double value = 70;
            for (int i = 0; i < 2555; i++)
            {
                if (rd.NextDouble() > .5)
                    value += rd.NextDouble();
                else
                    value -= rd.NextDouble();
                if (value >= 110) value = 110;
                if (value <= 20) value = 20;
                this.StockPriceDetails.Add(new Model()
                {
                    Date = date.AddDays(i),
                    YValue = value,
                });
            }
        }

        public ObservableCollection<Model> StockPriceDetails { get; set; }
    }

    public class LabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime) value;
            return date.ToString("D");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
