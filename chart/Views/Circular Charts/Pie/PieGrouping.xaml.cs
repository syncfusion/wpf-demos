#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Diagnostics;


namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PieGrouping : DemoControl
    {
        public PieGrouping()
        {
            InitializeComponent();
           groupTo.SelectedIndex = 0;
        }

        protected override void Dispose(bool disposing)
        {
            pieChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void groupTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = groupTo.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        {
                            pieSeries.GroupTo = 3;
                            pieSeries.YBindingPath = "Value";
                            pieSeries.GroupMode = PieGroupMode.Value;
                            label.SegmentLabelFormat = "$#.##'T";
                            break;
                        }
                    case 1:
                        {
                            pieSeries.YBindingPath = "Size";
                            pieSeries.GroupTo = 10;
                            pieSeries.GroupMode = PieGroupMode.Percentage;
                            label.SegmentLabelFormat = "P0";
                            break;
                        }
                    case 2:
                        {
                            pieSeries.GroupTo = 90;
                            pieSeries.YBindingPath = "Value";
                            pieSeries.GroupMode = PieGroupMode.Angle;
                            label.SegmentLabelFormat = "$#.##'T";
                            break;
                        }
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.visualcapitalist.com/visualizing-the-94-trillion-world-economy-in-one-chart/") { UseShellExecute = true });
        }
    }

    public class ItemsSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var data = value as List<object>;
                if (data != null && data.Count > 5)
                {
                    var data_list = data.Where(x => data.IndexOf(x) < 6).ToList();

                    string name = "Others";
                    double yvalue = data.Where(x => data.IndexOf(x) >= 6).Sum(x => (x is GroupingModel model) ? model.Value : 0);
                    double size = data.Where(x => data.IndexOf(x) >= 6).Sum(x => (x is GroupingModel model) ? model.Size : 0);
                    data_list.Add(new GroupingModel(name, yvalue, size));

                    return data_list;
                }
                else if (data != null)
                    return data;
                else
                {
                    return new List<object>() { value };
                }
            }

            return new List<object>();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is GroupingModel model)
            {
                if (parameter is PieSeries series)
                {
                    switch (series.GroupMode)
                    {
                        case PieGroupMode.Percentage:
                            return string.Format("{0:P0}", model.Size);
                        default:
                            return string.Format("${0:F2} T", model.Value);
                    }
                }

                else if (parameter is DoughnutSeries series1)
                {
                    switch (series1.GroupMode)
                    {
                        case PieGroupMode.Percentage:
                            return string.Format("{0:P0}", model.Size);
                        default:
                            return string.Format("${0:F2} T", model.Value);
                    }
                }
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

