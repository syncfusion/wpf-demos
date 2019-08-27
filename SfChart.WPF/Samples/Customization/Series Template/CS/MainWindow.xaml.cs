#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;

namespace CustomSeriesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ComboBox.SelectedIndex = 0;
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxIndex = (sender as ComboBox).SelectedIndex;

            if (comboBoxIndex == 0)
                ContentControl.Content = new ColumnSeries();
            else if (comboBoxIndex == 2)
                ContentControl.Content = new ScatterSeries();
           else if (comboBoxIndex == 3)
                ContentControl.Content = new SplineSeries();
           else if (comboBoxIndex == 1)
                ContentControl.Content = new CustomBarSeries(); 
        }
    }

    
    internal static class ChartDictionary
    {
        internal static ResourceDictionary GenericDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/CustomSeriesDemo;component/Resources/CustomTemplate.xaml", UriKind.Relative)
        };
    }
}
