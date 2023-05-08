#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public partial class ExportChartDemo : DemoControl
    {
        public ExportChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                var dataContext = DataContext as ExportChartViewModel;

                if (dataContext.ChartView != null && dataContext.ChartView is ChartView)
                {
                    ChartView chartView = dataContext.ChartView as ChartView;
                    chartView.Dispose();
                }
            }

            if (ViewContent != null)
            {
                ViewContent = null;
            }

            base.Dispose(disposing);
        }
    }
}
