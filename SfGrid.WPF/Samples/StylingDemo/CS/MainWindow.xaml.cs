#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;

namespace StylingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.sfGrid.Loaded += sfGrid_Loaded;
        }

        void sfGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                this.sfGrid.ItemsSource = (this.DataContext as CountryInfoViewModel).CountryDetails;
            }
            var  countryvm = (this.DataContext as CountryInfoViewModel);
            var r = new Random();
            for (int i = 0; i < countryvm.CountryDetails.Count; i++)
            {
                var item = countryvm.CountryDetails[i];
                var economy = new ObservableCollection<EconomyGrowth>();
                for (int j = 0; j < 5; j++)
                {
                    economy.Add(new EconomyGrowth() { Year = DateTime.Now.Year - j, GrowthPercentage = r.Next(0,5) });
                }
                item.EconomyRate = economy;
            }
        }
    }
}
