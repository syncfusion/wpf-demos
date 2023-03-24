#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.chartdemos.wpf
{
    public partial class MultipleSeriesDemo : DemoControl
    {
        public MultipleSeriesDemo()
        {
            InitializeComponent();
        }

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

            base.Dispose(disposing);
        }
    }
}
