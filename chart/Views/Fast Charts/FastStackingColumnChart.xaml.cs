#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
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
    /// Interaction logic for FastStackingColumnChartDemo.xaml
    /// </summary>
    public partial class FastStackingColumnChartDemo : DemoControl
    {
        public FastStackingColumnChartDemo()
        {
            InitializeComponent();
            var colorModel = new ChartColorModel();
            var customBrushes = new List<Brush>();

            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x2B, 0xD2, 0x6E)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x8F, 0xFB)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xFE, 0xBE, 0x19)));

            colorModel.CustomBrushes = customBrushes;
            FastStackingColumn.ColorModel = colorModel;
            FastStackingColumn.Palette = ChartColorPalette.Custom;
        }

        protected override void Dispose(bool disposing)
        {
            if (FastStackingColumn != null)
            {
                FastStackingColumn.Series.Clear();
                FastStackingColumn.Dispose();
                FastStackingColumn = null;
            }

            base.Dispose(disposing);
        }
    } 
}
