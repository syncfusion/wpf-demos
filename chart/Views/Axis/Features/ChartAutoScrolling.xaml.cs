#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows.Threading;

using Syncfusion.UI.Xaml.Charts;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for ChartAutoScrollingDemo.xaml
    /// </summary>
    public partial class ChartAutoScrollingDemo : DemoControl
    {
        #region Constructor
        public ChartAutoScrollingDemo()
        {
            InitializeComponent(); 
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            Chart1.Dispose();
            viewModel.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}
