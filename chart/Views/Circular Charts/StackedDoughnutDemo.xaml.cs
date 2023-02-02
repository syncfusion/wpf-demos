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
using System.Globalization;
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
    /// Interaction logic for StackedDoughnutDemo.xaml
    /// </summary>
    public partial class StackedDoughnutDemo : DemoControl
    {
        public StackedDoughnutDemo()
        {
            InitializeComponent();
            var colorModel = new ChartColorModel();
            var customBrushes = new List<Brush>();
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x47, 0xBA, 0x9F)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x88, 0x70)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x96, 0x86, 0xC9)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x65, 0x90)));

            colorModel.CustomBrushes = customBrushes;
            doughnutSeries.ColorModel = colorModel;
            doughnutSeries.Palette = ChartColorPalette.Custom;

        }

        protected override void Dispose(bool disposing)
        {
            chart.Dispose();
            base.Dispose(disposing);
        }
    } 
}
