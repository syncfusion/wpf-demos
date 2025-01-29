#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for EmptyPointSupportDemo.xaml
    /// </summary>
    public partial class EmptyPointSupportDemo
    {
        public EmptyPointSupportDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            EmptyPointChart.Dispose();
            base.Dispose(disposing);
        }

        private void EmptyPointInterior_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (ComboBoxAdv)sender;
            switch (value.SelectedIndex)
            {
                case 0:
                    {
                        column.EmptyPointInterior = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x8F, 0xFB)); 
                        break;
                    }
                case 1:
                    {
                        column.EmptyPointInterior = new SolidColorBrush(Color.FromArgb(0xFF, 0x77, 0x5D, 0xD0));
                        break;
                    }
                case 2:
                    {
                        column.EmptyPointInterior = new SolidColorBrush(Color.FromArgb(0xFF, 0xF5, 0x8A, 0x3C));
                        break;
                    }
                case 3:
                    {
                        column.EmptyPointInterior = new SolidColorBrush(Color.FromArgb(0xFF, 0xD7, 0x52, 0xC7));
                        break;
                    }
            }
        }
    }
}
