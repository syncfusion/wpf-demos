#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GettingStartedDemo : DemoControl
    {
        StockZoomingViewModel viewmodel = new StockZoomingViewModel();
        public GettingStartedDemo()
        {
            InitializeComponent();
        }

        private void axis1_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            if (axis1.ZoomPosition == 0 && axis1.ZoomFactor > 0.9 && RangeNavigator.Intervals[1].IntervalType == NavigatorIntervalType.Year)
                e.AxisLabel.LabelContent = e.AxisLabel.Position.FromOADate().ToString("MMM,yyyy");
            else
                e.AxisLabel.LabelContent = e.AxisLabel.Position.FromOADate().ToString("dd,MMM");
        }

        protected override void Dispose(bool disposing)
        {
            Chart.Dispose();
            base.Dispose(disposing);
        }
    }
}
