#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using System.ComponentModel;
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

namespace StackingBar100Chart
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

    public class StackingBarChartViewModel
    {
        public StackingBarChartViewModel()
        {
            this.MedalDetails = new ObservableCollection<Medal>();

            MedalDetails.Add(new Medal() { CountryName = "URS", GoldMedals = 39, SilverMedals = 31, BronzeMedals = 29 });
            MedalDetails.Add(new Medal() { CountryName = "Germany", GoldMedals = 24, SilverMedals = 28, BronzeMedals = 32 });
            MedalDetails.Add(new Medal() { CountryName = "Britain", GoldMedals = 20, SilverMedals = 25, BronzeMedals = 25 });
            MedalDetails.Add(new Medal() { CountryName = "France", GoldMedals = 19, SilverMedals = 21, BronzeMedals = 23 });
            MedalDetails.Add(new Medal() { CountryName = "Italy", GoldMedals = 19, SilverMedals = 15, BronzeMedals = 17 });
        }

        public ObservableCollection<Medal> MedalDetails { get; set; }
    }

    public class Medal
    {
        public string CountryName { get; set; }

        public double GoldMedals { get; set; }

        public double SilverMedals { get; set; }

        public double BronzeMedals { get; set; }
    }
}
