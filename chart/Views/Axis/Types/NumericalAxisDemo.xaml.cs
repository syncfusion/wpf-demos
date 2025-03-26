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
    /// Interaction logic for LogarithmicAxisDemo.xaml
    /// </summary>
    public partial class NumericalAxisDemo : DemoControl
    {
        public NumericalAxisDemo()
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
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.google.com/search?q=india+vs+australia+odi+result+2019&oq=indian+vs+australia+odi+res&aqs=chrome.2.69i57j0l5.11336j1j4&sourceid=chrome&ie=UTF-8") { UseShellExecute = true });
        }
    }
}