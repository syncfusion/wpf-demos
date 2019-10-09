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

namespace DepthAxis
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
        private void seriesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            ZAxisViewModel viewModel = new ZAxisViewModel();
            if (combo.SelectedIndex == 0)
            {
                chart.Series.Clear();
                ColumnSeries3D series = new ColumnSeries3D();
                series.ShowTooltip = true;
                series.Palette = ChartColorPalette.Metro;
                series.ItemsSource = viewModel.FruitDetails;
                series.XBindingPath = "FruitsName";
                series.YBindingPath = "Count";
                series.ZBindingPath = "Day";
                chart.Series.Add(series);
            }
            else if (combo.SelectedIndex == 1)
            {
                chart.Series.Clear();
                BarSeries3D series = new BarSeries3D();
                series.ShowTooltip = true;
                series.Palette = ChartColorPalette.Metro;
                series.ItemsSource = viewModel.FruitDetails;
                series.XBindingPath = "FruitsName";
                series.YBindingPath = "Count";
                series.ZBindingPath = "Day";
                chart.Series.Add(series);
            }
            else if (combo.SelectedIndex == 2)
            {
                chart.Series.Clear();
                ScatterSeries3D series = new ScatterSeries3D();
                series.ShowTooltip = true;
                series.Palette = ChartColorPalette.Metro;
                series.ItemsSource = viewModel.FruitDetails;
                series.XBindingPath = "FruitsName";
                series.YBindingPath = "Count";
                series.ZBindingPath = "Day";
                chart.Series.Add(series);
            }
        }
    }

    public class ZAxisModel
    {
        public string FruitsName
        {
            get;
            set;
        }
        public string Day
        {
            get;
            set;
        }

        public double Count
        {
            get;
            set;
        }

    }
    public class ZAxisViewModel
    {
        public ObservableCollection<ZAxisModel> FruitDetails
        {
            get;
            set;
        }
        public ZAxisViewModel()
        {
            FruitDetails = new ObservableCollection<ZAxisModel>();
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Apple", Day = "Sun", Count = 50 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Orange", Day = "Mon", Count = 30 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Mango", Day = "Tue", Count = 60 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Banana", Day = "Wed", Count = 80 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Grape", Day = "Thur", Count = 60 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Jackfruit", Day = "Fri", Count = 30 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Guava", Day = "Sat", Count = 75 });
        }
    }
}
