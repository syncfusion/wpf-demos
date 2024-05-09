#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
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

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for PyramidChartDemo.xaml
    /// </summary>
    public partial class PyramidMode : DemoControl
    {
        public PyramidMode()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
        }

        protected override void Dispose(bool disposing)
        {
            PyramidChart.Dispose();
            base.Dispose(disposing);
        }

        private void groupTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = comboBox.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        {
                            pyramidSeries.PyramidMode = ChartPyramidMode.Linear;
                            break;
                        }
                    case 1:
                        {
                            pyramidSeries.PyramidMode = ChartPyramidMode.Surface;
                            break;
                        }
                }
            }
        }
    }
}
