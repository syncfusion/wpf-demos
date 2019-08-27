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
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.Charts;

namespace StockAnalysis
{
    /// <summary>
    /// Interaction logic for StockAnalysisView.xaml
    /// </summary>
    public partial class StockAnalysisView : UserControl
    {
        public StockAnalysisView()
        {
            InitializeComponent();
            StockViewModel viewModel = new StockViewModel();
            this.DataContext = viewModel.Stocks[0].Datas;
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            
        }

        private void tileView_Loaded_1(object sender, RoutedEventArgs e)
        {
            TileViewItem tile = tileView.ItemContainerGenerator.ContainerFromIndex(0) as TileViewItem;
            if (tile != null)
            {
                tile.TileViewItemState = TileViewItemState.Maximized;
            }
        }
    }

    public class CustomTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var obj = value as StockData;
            return obj != null && obj.Open < obj.Last ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
