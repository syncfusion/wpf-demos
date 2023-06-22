#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
 

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for DepthAxis.xaml
    /// </summary>
    public partial class DepthAxis : DemoControl
    {
        public DepthAxis()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.chart != null)
            {
                this.chart.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
