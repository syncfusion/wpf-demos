#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for LabelsIntersectionDemo.xaml
    /// </summary>
    public partial class LabelsIntersectionDemo : DemoControl
    {
        public LabelsIntersectionDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            AxisChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("https://en.wikipedia.org/wiki/List_of_footballers_with_500_or_more_goals");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(uri.AbsoluteUri));
        }
    } 
}
