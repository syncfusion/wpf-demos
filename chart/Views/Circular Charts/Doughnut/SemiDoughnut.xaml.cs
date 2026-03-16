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
    public partial class SemiDoughnut : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SemiDoughnut"/> class.
        /// </summary>
        public SemiDoughnut()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            DoughnutChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}
