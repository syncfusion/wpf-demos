#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public partial class RealTimeChartDemo : DemoControl
    {
        public RealTimeChartDemo()
        {
            InitializeComponent();
            (this.Chart.DataContext as RealTimeChartViewModel).SuspendSeriesAction = Chart.SuspendSeriesNotification;
            (this.Chart.DataContext as RealTimeChartViewModel).ResumeSeriesAction = Chart.ResumeSeriesNotification;
        }

        protected override void Dispose(bool disposing)
        {
            if(DataContext != null)
            {
                RealTimeChartViewModel viewModel = DataContext as RealTimeChartViewModel;
                viewModel.Dispose();
                DataContext = null;
            }

            Chart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}