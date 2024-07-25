#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{   
    public partial class DoughnutGrouping : DemoControl
    {
        public DoughnutGrouping()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            chart.Dispose();
            base.Dispose(disposing);
        }

        private void groupTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = groupTo.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        {
                            doughnutSeries.GroupTo = 5;
                            doughnutSeries.YBindingPath = "Value";
                            doughnutSeries.GroupMode = PieGroupMode.Value;
                            label.SegmentLabelFormat = "$#.##'T";
                            break;
                        }
                    case 1:
                        {
                            doughnutSeries.YBindingPath = "Size";
                            doughnutSeries.GroupTo = 10;
                            doughnutSeries.GroupMode = PieGroupMode.Percentage;
                            label.SegmentLabelFormat = "P0";
                            break;
                        }
                    case 2:
                        {
                            doughnutSeries.GroupTo = 90;
                            doughnutSeries.YBindingPath = "Value";
                            doughnutSeries.GroupMode = PieGroupMode.Angle;
                            label.SegmentLabelFormat = "$#.##'T";
                            break;
                        }
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.visualcapitalist.com/ranked-the-largest-bond-markets-in-the-world/") { UseShellExecute = true });
        }

    }
}
