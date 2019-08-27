#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PortfolioAnalyzer.CountrySectorChartModule
{
    /// <summary>
    /// Interaction logic for PieChart.xaml
    /// </summary>
    public partial class PieChart3D : UserControl
    {
        public PieChart3D()
        {
            InitializeComponent();
            ApplySeriesInterior();
        }
        private void ApplySeriesInterior()
        {
            series1.Palette = ChartColorPalette.Custom;
            series1.ColorModel.CustomBrushes = new List<Brush>{
                  this.Resources["Metro1"] as Brush,
                  this.Resources["Metro2"] as Brush,
                  this.Resources["Metro3"] as Brush,
                  this.Resources["Metro4"] as Brush,
                  this.Resources["Metro5"] as Brush,
                 };

            series2.Palette = ChartColorPalette.Custom;
            series2.ColorModel.CustomBrushes = new List<Brush>{
                       this.Resources["Metro3"] as Brush,
                  this.Resources["Metro2"] as Brush,
                  this.Resources["Metro1"] as Brush,
                  this.Resources["Metro5"] as Brush,
                  this.Resources["Metro4"] as Brush,
                 };
        }
    }
}
