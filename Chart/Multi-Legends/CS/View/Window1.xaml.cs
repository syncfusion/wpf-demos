#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Syncfusion.Windows.SampleLayout;
using Syncfusion.UI.Xaml.Charts;

namespace MultipleLegendsDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : SampleLayoutWindow
    {
        public Window1()
        {
            InitializeComponent();
            series2.XAxis = catAxis;

            var viewModel = this.DataContext as ProductDetails;
            if(viewModel != null)
            {
                this.DockPosition.ItemsSource = viewModel.ChartDock;
                this.DockPosition.SelectedIndex = 1;

                this.DockPosition2.ItemsSource = viewModel.ChartDock;
                this.DockPosition2.SelectedIndex = 1;

                this.LegendPosition.ItemsSource = viewModel.LegendPosition;
                this.LegendPosition.SelectedIndex = 1;

                this.LegendPosition2.ItemsSource = viewModel.LegendPosition;
                this.LegendPosition2.SelectedIndex = 1;
            }
        }
    }
}
