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
using System.Windows.Threading;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for Palettes.xaml
    /// </summary>
    public partial class Palettes : DemoControl
    {
        public Palettes()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            areaChart.Dispose();
            barChart.Dispose();
            doughnutChart.Dispose();
            base.Dispose(disposing);
        }

        private void palettecombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    barChart.Palette = ChartColorPalette.Metro;
                    doughnutChart.Series[0].Palette = ChartColorPalette.Metro;
                    areaChart.Palette = ChartColorPalette.Metro;
                    break;
                case 1:
                    barChart.Palette = ChartColorPalette.AutumnBrights;
                    doughnutChart.Series[0].Palette = ChartColorPalette.AutumnBrights;
                    areaChart.Palette = ChartColorPalette.AutumnBrights;
                    break;
                case 2:
                    barChart.Palette = ChartColorPalette.FloraHues;
                    doughnutChart.Series[0].Palette = ChartColorPalette.FloraHues;
                    areaChart.Palette = ChartColorPalette.FloraHues;
                    break;
                case 3:
                    barChart.Palette = ChartColorPalette.Pineapple;
                    doughnutChart.Series[0].Palette = ChartColorPalette.Pineapple;
                    areaChart.Palette = ChartColorPalette.Pineapple;
                    break;
                case 4:
                    barChart.Palette = ChartColorPalette.TomotoSpectrum;
                    doughnutChart.Series[0].Palette = ChartColorPalette.TomotoSpectrum;
                    areaChart.Palette = ChartColorPalette.TomotoSpectrum;
                    break;
                case 5:
                    barChart.Palette = ChartColorPalette.RedChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.RedChrome;
                    areaChart.Palette = ChartColorPalette.RedChrome;
                    break;
                case 6:
                    barChart.Palette = ChartColorPalette.BlueChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.BlueChrome;
                    areaChart.Palette = ChartColorPalette.BlueChrome;
                    break;
                case 7:
                    barChart.Palette = ChartColorPalette.PurpleChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.PurpleChrome;
                    areaChart.Palette = ChartColorPalette.PurpleChrome;
                    break;
                case 8:
                    barChart.Palette = ChartColorPalette.GreenChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.GreenChrome;
                    areaChart.Palette = ChartColorPalette.GreenChrome;
                    break;
                case 9:
                    barChart.Palette = ChartColorPalette.Elite;
                    doughnutChart.Series[0].Palette = ChartColorPalette.Elite;
                    areaChart.Palette = ChartColorPalette.Elite;
                    break;
                case 10:
                    barChart.Palette = ChartColorPalette.LightCandy;
                    doughnutChart.Series[0].Palette = ChartColorPalette.LightCandy;
                    areaChart.Palette = ChartColorPalette.LightCandy;
                    break;
                case 11:
                    barChart.Palette = ChartColorPalette.SandyBeach;
                    doughnutChart.Series[0].Palette = ChartColorPalette.SandyBeach;
                    areaChart.Palette = ChartColorPalette.SandyBeach;
                    break;
                case 12:
                    barChart.Palette = ChartColorPalette.Custom;
                    doughnutSeries.Palette = ChartColorPalette.Custom;
                    areaChart.Palette = ChartColorPalette.Custom;
                    barChart.ColorModel = grid.Resources["CustomColor"] as ChartColorModel;
                    doughnutSeries.ColorModel = grid.Resources["CustomColor"] as ChartColorModel;
                    areaChart.ColorModel = grid.Resources["CustomColor"] as ChartColorModel;
                    break;
            }

        }
    } 
}
