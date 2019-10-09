#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Gauges;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace CircularGaugeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.cmb_RangePosition.ItemsSource = Enum.GetValues(typeof(RangePosition));
            this.cmb_TickPosition.ItemsSource = Enum.GetValues(typeof(TickPosition));
            this.cmb_LabelPosition.ItemsSource = Enum.GetValues(typeof(LabelPosition));

        }
        
        void sweepdirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            if (cb != null && cb.SelectedItem != null)
            {
                if (cb.SelectedIndex == 0)
                {
                    gauge3.Scales[0].SweepDirection = SweepDirection.Clockwise;
                }
                else
                {
                    gauge3.Scales[0].SweepDirection = SweepDirection.Counterclockwise;
                }
            }
        }

    }
}
