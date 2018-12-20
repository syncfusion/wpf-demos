#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Globalization;
using System.Xml;
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.Shared;

namespace XMLBinding
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Initialization
        /// <summary>
        /// Contrcutor for window1.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Event for MedianWeight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.heatMap.MedianWeight = (int)e.NewValue;

            double sliderWidth = this.sliderColor.Width;
            double sliderHeight = this.sliderColor.Height;

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0.5);
            brush.EndPoint = new Point(1, 0.5);
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.LowestWeightColor, Offset = 0 });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.MedianWeightColor, Offset = (((double)this.heatMap.MedianWeight / 100)) });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.HighestWeightColor, Offset = 1 });
            this.sliderColor.Background = brush;
            double diff = 0.0;
            if (this.heatMap.ColorWeightsInfo.HighestValue != 0.0)
            {
                diff = this.heatMap.ColorWeightsInfo.HighestValue - this.heatMap.ColorWeightsInfo.LowestValue;
                centerLabel.Content = string.Format("${0:F0}", this.heatMap.ColorWeightsInfo.LowestValue + ((diff * e.NewValue) / 100));
            }
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.highColorValue.Content += this.heatMap.ColorWeightsInfo.HighestValue.ToString();
            this.lowColorValue.Content += this.heatMap.ColorWeightsInfo.LowestValue.ToString();
        }
        #endregion

    }
}
