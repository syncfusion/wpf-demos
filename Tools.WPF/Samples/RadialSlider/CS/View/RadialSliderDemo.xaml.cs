#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace SfRadialSlider
{
    /// <summary>
    /// Interaction logic for RadialSliderDemo.xaml
    /// </summary>
    public partial class RadialSliderDemo : UserControl
    {
        public RadialSliderDemo()
        {
            InitializeComponent();
        }

        private void Label_Customization_DrawLabel(object sender, Syncfusion.Windows.Controls.Navigation.DrawLabelEventArgs e)
        {
            e.Handled = true;
            if (e.Handled == true)
            {
                e.Text += "°C";

                e.Foreground = Brushes.Red;

                e.FontSize = 10;

                Label_Customization.Content = e.Text;

                if (e.Value == 10 || e.Value==20 || e.Value==30)
                {
                    e.Foreground = Brushes.Green;
                }
                else if(e.Value==40 ||e.Value==50 || e.Value==60)
                {
                    e.Foreground = Brushes.Blue;
                }
                else if(e.Value==70 || e.Value==80 || e.Value==90)
                {
                    e.Foreground = Brushes.Red;
                }

            }
        }

        private void SfRadialSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Clockwise_FulCircle.Content = e.NewValue;
        }

        private void Label_Customization_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Label_Customization.Content = e.NewValue;
        }

        private void Value_Customization_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Value_Customization.Content = e.NewValue;
        }

        private void AntiClockwise_SemiCircle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.AntiClockwise_SemiCircle.Content = e.NewValue;
        }

        private void RadialSlider_Customization_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.RadialSlider_Customization.Content = e.NewValue;
        }
    }
}
