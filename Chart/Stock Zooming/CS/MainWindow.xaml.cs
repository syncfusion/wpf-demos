#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Globalization;

namespace StockZoomingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        ViewModel viewmodel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void axis1_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            if (axis1.ZoomPosition == 0 && axis1.ZoomFactor > 0.9 && RangeNavigator.Intervals[1].IntervalType == NavigatorIntervalType.Year)
                e.AxisLabel.LabelContent = e.AxisLabel.Position.FromOADate().ToString("MMM,yyyy");
            else
                e.AxisLabel.LabelContent = e.AxisLabel.Position.FromOADate().ToString("dd,MMM");
        }
    }
}
