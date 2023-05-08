#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{    
    public partial class RealTimeChartDemo : DemoControl
    {
        public RealTimeChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(DataContext != null)
            {
                RealTimeChartViewModel viewModel = DataContext as RealTimeChartViewModel;
                viewModel.Dispose();
                DataContext = null;
            }

            Chart.Dispose();
            base.Dispose(disposing);
        }
    }
}