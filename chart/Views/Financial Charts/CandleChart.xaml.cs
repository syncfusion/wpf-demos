#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Diagnostics;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for CandleChartDemo.xaml
    /// </summary>
    public partial class CandleChartDemo : DemoControl
    {
        public CandleChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            financialChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.marketwatch.com/investing/stock/aeis/downloaddatapartial?startdate=01/01/2020%2000:00:00&enddate=12/31/2020%2000:00:00&daterange=d30&frequency=p1d&csvdownload=true&downloadpartial=false&newdates=false") { UseShellExecute = true });
        }

        private void DateTimeAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            DateTimeAxisLabel dateTimeLabel = e.AxisLabel as DateTimeAxisLabel;
            bool isTransition = dateTimeLabel.IsTransition;

            switch (dateTimeLabel.IntervalType)
            {
                case DateTimeIntervalType.Days:
                    {
                        if (isTransition)
                            e.AxisLabel.LabelContent = dateTimeLabel.Position.FromOADate().ToString("MMM-dd");
                        else
                            e.AxisLabel.LabelContent = dateTimeLabel.Position.FromOADate().ToString("dd");
                    }
                    break;

                case DateTimeIntervalType.Hours:
                    {
                        if (isTransition)
                            e.AxisLabel.LabelContent =
                            dateTimeLabel.Position.FromOADate().ToString("MMM-dd");

                        else
                            e.AxisLabel.LabelContent =
                            dateTimeLabel.Position.FromOADate().ToString("dd");
                    }
                    break;
            }
        }
    }
}
