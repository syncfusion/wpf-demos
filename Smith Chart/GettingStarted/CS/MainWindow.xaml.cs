#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.SmithChart;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GettingStarted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RenderingTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var renderingType = (sender as ComboBox).SelectedItem.ToString();
            SmithChart.RenderingType = (RenderingType)Enum.Parse(typeof(RenderingType), renderingType);
        }
    }


}
