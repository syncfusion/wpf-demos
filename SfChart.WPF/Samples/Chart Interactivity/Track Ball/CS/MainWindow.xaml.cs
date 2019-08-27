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
using Syncfusion.Windows.SampleLayout;
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

namespace GraphChart
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
    }

    public class Commodities
    {
        public string Commodity { get; set; }
        public double ChangingPrice { get; set; }
    }

    public class CommoditiesPrices
    {
        public CommoditiesPrices()
        {
            CommodityDetails = new ObservableCollection<Commodities>();
            CommodityDetails.Add(new Commodities() { Commodity = "Gold", ChangingPrice = 46 });
            CommodityDetails.Add(new Commodities() { Commodity = "Silver", ChangingPrice = -10 });
            CommodityDetails.Add(new Commodities() { Commodity = "Crudeoil", ChangingPrice = -34 });
            CommodityDetails.Add(new Commodities() { Commodity = "Naturalgas", ChangingPrice = -45 });
            CommodityDetails.Add(new Commodities() { Commodity = "Aluminium", ChangingPrice = 8 });
            CommodityDetails.Add(new Commodities() { Commodity = "Copper", ChangingPrice = 23 });
            CommodityDetails.Add(new Commodities() { Commodity = "Nickel", ChangingPrice = -15 });
            CommodityDetails.Add(new Commodities() { Commodity = "Lead", ChangingPrice = 16 });
            CommodityDetails.Add(new Commodities() { Commodity = "Cotton", ChangingPrice = 37 });
            CommodityDetails.Add(new Commodities() { Commodity = "Menthaoil", ChangingPrice = -22 });
            CommodityDetails.Add(new Commodities() { Commodity = "Zinc", ChangingPrice = 13 });

        }

        public ObservableCollection<Commodities> CommodityDetails { get; set; }
    }

    public class TrackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartPointInfo val = value as ChartPointInfo;
            return String.Format("$ {0}", val.ValueY);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

}
