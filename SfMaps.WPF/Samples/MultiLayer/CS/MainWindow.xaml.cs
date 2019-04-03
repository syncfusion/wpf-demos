#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace MultiLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class Country : INotifyPropertyChanged
    {
        public string NAME { get; set; }

        private Visibility itemsvisibility = Visibility.Visible;
        public Visibility ItemsVisibility
        {
            get { return itemsvisibility; }
            set { itemsvisibility = value; }
        }

        private double weather { get; set; }
        public double Weather
        {
            get
            {
                return weather;
            }
            set
            {
                weather = value;
            }
        }

        private double population { get; set; }
        public double Population
        {
            get
            {
                return population;
            }
            set
            {
                population = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Population"));
            }

        }
        public string PopulationFormat { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.PopulationFormat = (String.Format("{0:0,0}", this.Population).Trim('$'));
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
    public class MapViewModel
    {
        public ObservableCollection<Country> MuliLayerList { get; set; }
        public ObservableCollection<Country> AfricaList { get; set; }
        public ObservableCollection<Country> OceaniaList { get; set; }
        public MapViewModel()
        {
            this.OceaniaList = new ObservableCollection<Country>();
            this.OceaniaList.Add(new Country() { NAME = "New South Wales", Weather = 26 });
            this.OceaniaList.Add(new Country() { NAME = "Queensland", Weather = 30 });
            this.OceaniaList.Add(new Country() { NAME = "Tasmania", Weather = 21 });
            this.OceaniaList.Add(new Country() { NAME = "Western Australia", Weather = 32 });
            this.AfricaList = new ObservableCollection<Country>();
            this.AfricaList.Add(new Country() { NAME = "Algeria", Weather = 47 });
            this.AfricaList.Add(new Country() { NAME = "Congo (Brazzaville)", Weather = 45 });
            this.AfricaList.Add(new Country() { NAME = "Ethiopia", Weather = 50 });
            this.AfricaList.Add(new Country() { NAME = "South Africa", Weather = 30 });
            this.MuliLayerList = new ObservableCollection<Country>();
            this.MuliLayerList.Add(new Country() { NAME = "Asia", Weather = 40 });
            this.MuliLayerList.Add(new Country() { NAME = "South America", Weather = 45 });
            this.MuliLayerList.Add(new Country() { NAME = "North America", Weather = 52 });
            this.MuliLayerList.Add(new Country() { NAME = "Antarctica", ItemsVisibility = Visibility.Collapsed });
            this.MuliLayerList.Add(new Country() { NAME = "Oceania", ItemsVisibility = Visibility.Collapsed });
            this.MuliLayerList.Add(new Country() { NAME = "Europe", ItemsVisibility = Visibility.Collapsed });
            this.MuliLayerList.Add(new Country() { NAME = "Africa", ItemsVisibility = Visibility.Collapsed });

        }
        
    }
}
