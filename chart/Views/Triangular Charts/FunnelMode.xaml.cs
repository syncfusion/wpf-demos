#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Windows.Controls;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for FunnelChartDemo.xaml
    /// </summary>
    public partial class FunnelMode : DemoControl
    {
        public FunnelMode()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 1;
        }

        protected override void Dispose(bool disposing)
        {
            FunnelChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = comboBox.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        {
                            funnelSeries.FunnelMode = ChartFunnelMode.ValueIsWidth;
                            FunnelChart.Width = 700;
                            break;
                        }
                    case 1:
                        {
                            funnelSeries.FunnelMode = ChartFunnelMode.ValueIsHeight;
                            break;
                        }
                }
            }
        }
    }
}
