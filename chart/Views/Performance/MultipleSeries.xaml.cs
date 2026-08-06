#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public partial class MultipleSeriesDemo : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSeriesDemo"/> class.
        /// </summary>
        public MultipleSeriesDemo()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (lineChart != null)
            {
                var behaviors = Interaction.GetBehaviors(lineChart);

                foreach (var item in behaviors)
                {
                    if (item is ChartTimerBehavior)
                        item.Detach();
                }
                
                lineChart.Dispose();
                lineChart = null;
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}
