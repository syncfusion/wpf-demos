#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows;
using syncfusion.demoscommon.wpf;
using System.Diagnostics;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for DateTimeAxisDemo.xaml
    /// </summary>
    public partial class DateTimeAxisDemo : DemoControl
    {
        public DateTimeAxisDemo()
        {
            InitializeComponent();

        }

        protected override void Dispose(bool disposing)
        {
            Chart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://fred.stlouisfed.org/series/EXUSEU") { UseShellExecute = true });
        }
    }
}