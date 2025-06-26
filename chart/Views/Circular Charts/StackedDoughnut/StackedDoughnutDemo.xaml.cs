#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

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
            InitializeProperties();
            var colorModel = new ChartColorModel();
            var customBrushes = new List<Brush>();
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x96, 0xD7, 0x59)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF5, 0x8A, 0x3C)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x8F, 0xFB)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x77, 0x5D, 0xD0)));

            colorModel.CustomBrushes = customBrushes;
            doughnutSeries.ColorModel = colorModel;
            doughnutSeries.Palette = ChartColorPalette.Custom;
        }

        private void InitializeProperties()
        {
            capStyle.SelectedIndex = 1;
            trackFill.SelectedIndex = 0;
            trackStroke.SelectedIndex = 0;
            startAngle.Value = -90;
            endAngle.Value = 270;
        }

        protected override void Dispose(bool disposing)
        {
            chart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void trackStroke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (ComboBoxAdv)sender;
            switch (value.SelectedIndex)
            {
                case 0:
                    {
                        doughnutSeries.TrackBorderColor = new SolidColorBrush(Color.FromRgb(230, 230, 230));
                        break;
                    }
                case 1:
                    {
                        doughnutSeries.TrackBorderColor = new SolidColorBrush(Color.FromRgb(203, 213, 225));
                        break;
                    }
                case 2:
                    {
                        doughnutSeries.TrackBorderColor = new SolidColorBrush(Color.FromRgb(191, 219, 254));
                        break;
                    }
                case 3:
                    {
                        doughnutSeries.TrackBorderColor = new SolidColorBrush(Color.FromRgb(254, 215, 170));
                        break;
                    }
                case 4:
                    {
                        doughnutSeries.TrackBorderColor = new SolidColorBrush(Color.FromRgb(221, 214, 254));
                        break;
                    }
            }
        }

        private void trackFill_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = (ComboBoxAdv)sender;
            switch (value.SelectedIndex)
            {
                case 0:
                    {
                        doughnutSeries.TrackColor = new SolidColorBrush(Color.FromRgb(230, 230, 230));
                        break;
                    }
                case 1:
                    {
                        doughnutSeries.TrackColor = new SolidColorBrush(Color.FromRgb(241, 245, 249));
                        break;
                    }
                case 2:
                    {
                        doughnutSeries.TrackColor = new SolidColorBrush(Color.FromRgb(239, 246, 255));
                        break;
                    }
                case 3:
                    {
                        doughnutSeries.TrackColor = new SolidColorBrush(Color.FromRgb(255, 247, 237));
                        break;
                    }
                case 4:
                    {
                        doughnutSeries.TrackColor = new SolidColorBrush(Color.FromRgb(245, 243, 255));
                        break;
                    }
            }

        }
    }
}
