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
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for PieSeriesDemo3D.xaml
    /// </summary>
    public partial class SemiPieSeries3D : DemoControl
    {
        public SemiPieSeries3D()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.PieChart != null)
            {
                this.PieChart.Dispose();
            }

            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://leafly-cms-production.imgix.net/wp-content/uploads/2022/11/04104710/Leafly-Crops-Report-2022.11.4corrected.pdf") { UseShellExecute = true });
        }
    }
}
