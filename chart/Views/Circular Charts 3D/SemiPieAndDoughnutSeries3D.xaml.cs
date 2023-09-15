#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SemiPieAndDoughnutSeries3D.xaml
    /// </summary>
    public partial class SemiPieAndDoughnutSeries3D : DemoControl
    {
        public SemiPieAndDoughnutSeries3D()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (contentcontrol != null)
            {
                if (contentcontrol.Content is PieSeriesDemo3D)
                {
                    (contentcontrol.Content as PieSeriesDemo3D).PieChart.Dispose();
                }
                else if (contentcontrol.Content is DoughnutSeriesDemo3D)
                {
                    (contentcontrol.Content as DoughnutSeriesDemo3D).DoughnutChart.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}
