#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for DepthAxis.xaml
    /// </summary>
    public partial class DepthAxis : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepthAxis"/> class.
        /// </summary>
        public DepthAxis()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (chart != null)
            {
                var existingSeriesCollection = chart.Series;

                BindingOperations.ClearBinding(chart, SfChart3D.SeriesProperty);

                chart.Series = existingSeriesCollection;

                chart.Dispose();
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}
