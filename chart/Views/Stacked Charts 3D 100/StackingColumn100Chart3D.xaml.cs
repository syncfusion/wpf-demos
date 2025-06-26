#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Diagnostics;
using System.Windows;


namespace syncfusion.chartdemos.wpf
{

    /// <summary>
    /// Interaction logic for StackingColumn100Chart3D.xaml
    /// </summary>
    public partial class StackingColumn100Chart3D : DemoControl
    {
        public StackingColumn100Chart3D()
        {
            
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.columnChart != null)
            {
                this.columnChart.Dispose();
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.atlanticcouncil.org/wp-content/uploads/2020/09/CLOUD-MYTHS-REPORT.pdf") { UseShellExecute = true });
        }
    }
}
