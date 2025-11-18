#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for HistogramChartDemo.xaml
    /// </summary>
    public partial class HistogramChartDemo : DemoControl
    {
        public HistogramChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            AreaChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }

    public class RangeEndValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Syncfusion.UI.Xaml.Charts.HistogramSegment histogramSegment && parameter == null)
            {
                var rangeStart = (int)(histogramSegment.XData)*20;
                var rangeEnd = rangeStart + 20;
                var rangeValue = histogramSegment.YData;

                string text = $"{rangeStart} - {rangeEnd} : {rangeValue}";
                return text;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
