#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
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

namespace Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chart.Serialize();
            deserializedChart.Visibility = Visibility.Collapsed;
            textGrid.Visibility = Visibility.Visible;
            string filePath = System.IO.Directory.GetParent(@"../").FullName + "\\chart.xml";
            text_block.Text = System.IO.File.ReadAllText(filePath);
            Load.IsEnabled = true;
            Load.Opacity = 1;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            textGrid.Visibility = Visibility.Collapsed;
            deserializedChart = (SfChart)chart.Deserialize();
            chartGrid.Children.Add(deserializedChart);
            chartGrid.Visibility = Visibility.Visible;
            Grid.SetRow(chartGrid, 1);
            Load.IsEnabled = false;
            Load.Opacity = 0.5;
        }
    }
}
