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
    /// <summary>
    /// Interaction logic for FastRangeAreaChartDemo.xaml
    /// </summary>
    public partial class FastRangeAreaChartDemo : DemoControl
    {
        public FastRangeAreaChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (FastRangeAreaChart != null)
            {
                FastRangeAreaChart.Series.Clear();
                FastRangeAreaChart.Dispose();
                FastRangeAreaChart = null;
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }  
}
