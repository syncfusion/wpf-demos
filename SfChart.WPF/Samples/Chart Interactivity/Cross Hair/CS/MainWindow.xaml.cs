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

namespace CrossHairBehavior
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

    public class CurrencyData
    {
        public CurrencyData()
        {
            CurrencyDetails = new ObservableCollection<CurenncyDetail>();

            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Rupee", CurrencyValue = 58.76 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Yen", CurrencyValue = 100.94 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Naira", CurrencyValue = 163.27 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Rand", CurrencyValue = 10.45 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Pound", CurrencyValue = 7.12 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Ruble", CurrencyValue = 34.51 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Peso", CurrencyValue = 12.91 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Yuan", CurrencyValue = 6.24 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Shilling", CurrencyValue = 87.80 });
            CurrencyDetails.Add(new CurenncyDetail() { CurrencyName = "Ringgit", CurrencyValue = 5.21 });

        }

        public ObservableCollection<CurenncyDetail> CurrencyDetails { get; set; }

    }

    public class CurenncyDetail
    {
        public string CurrencyName { get; set; }
        public double CurrencyValue { get; set; }
    }

}