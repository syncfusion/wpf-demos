#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.SunburstChart;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Selection
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
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Population_Data = new ObservableCollection<Model>
            {
                new Model { State = "Ontario", Continent = "North America", Country = "Canada", Population = 13210600 },
                new Model { State = "Mexico", Continent = "North America", Country = "Mexico", Population = 15174272 },
                new Model { State = "California", Continent = "North America", Country = "United States", Population = 37253956 },
                new Model { State = "Texas", Continent = "North America", Country = "United States", Population = 25145561 },
                new Model { State = "New York", Continent = "North America", Country = "United States", Population = 19378102 },
                new Model { State = "Florida", Continent = "North America", Country = "United States", Population = 18801310 },
                new Model { State = "Illinois", Continent = "North America", Country = "United States", Population = 12830632 },
                new Model { State = "Pennsylvania", Continent = "North America", Country = "United States", Population = 12702379 },
                new Model { State = "Ohio", Continent = "North America", Country = "United States", Population = 11536504 },
                new Model { State = "Buenos Aires", Continent = "South America", Country = "Argentina", Population = 15594428 },
                new Model { State = "Sao Paulo", Continent = "South America", Country = "Brazil", Population = 43663672 },
                new Model { State = "Minas Gerais", Continent = "South America", Country = "Brazil", Population = 20593366 },
                new Model { State = "Rio de Janeiro", Continent = "South America", Country = "Brazil", Population = 16369178 },
                new Model { State = "Bahia", Continent = "South America", Country = "Brazil", Population = 15044127 },
                new Model { State = "Rio Grande do Sul", Continent = "South America", Country = "Brazil", Population = 11164050 },
                new Model { State = "Parana", Continent = "South America", Country = "Brazil", Population = 10997462 },
                new Model { State = "Dhaka", Continent = "Asia", Country = "Bangladesh", Population = 46729000 },
                new Model { State = "Chittagong", Continent = "Asia", Country = "Bangladesh", Population = 28079000 },
                new Model { State = "Rajshahi", Continent = "Asia", Country = "Bangladesh", Population = 18329000 },
                new Model { State = "Rangpur", Continent = "Asia", Country = "Bangladesh", Population = 15665000 },
                new Model { State = "Khulna", Continent = "Asia", Country = "Bangladesh", Population = 15563000 },
                new Model { State = "Jiangxi", Continent = "Asia", Country = "China", Population = 44567475 },
                new Model { State = "Liaoning", Continent = "Asia", Country = "China", Population = 43746323 },
                new Model { State = "Heilongjiang", Continent = "Asia", Country = "China", Population = 38312224 },
                new Model { State = "Shaanxi", Continent = "Asia", Country = "China", Population = 37327378 },
                new Model { State = "Fujian", Continent = "Asia", Country = "China", Population = 36894216 },
                new Model { State = "Shanxi", Continent = "Asia", Country = "China", Population = 35712111 },
                new Model { State = "Shanghai", Continent = "Asia", Country = "China", Population = 23019148 },
                new Model { State = "Karnataka", Continent = "Asia", Country = "India", Population = 61130704 },
                new Model { State = "Gujarat", Continent = "Asia", Country = "India", Population = 60383628 },
                new Model { State = "Kerala", Continent = "Asia", Country = "India", Population = 33387677 },
                new Model { State = "Punjab", Continent = "Asia", Country = "India", Population = 27704236 },
                new Model { State = "Haryana", Continent = "Asia", Country = "India", Population = 25353081 },
                new Model { State = "Delhi", Continent = "Asia", Country = "India", Population = 16753235 },
                new Model { State = "Jammu", Continent = "Asia", Country = "India", Population = 12548926 },
                new Model { State = "West Java", Continent = "Asia", Country = "Indonesia", Population = 43021826 },
                new Model { State = "East Java", Continent = "Asia", Country = "Indonesia", Population = 37476011 },
                new Model { State = "Central Java", Continent = "Asia", Country = "Indonesia", Population = 32380687 },
                new Model { State = "North Sumatra", Continent = "Asia", Country = "Indonesia", Population = 12985075 },
                new Model { State = "Banten", Continent = "Asia", Country = "Indonesia", Population = 10644030 },
                new Model { State = "Jakarta", Continent = "Asia", Country = "Indonesia", Population = 10187595 },
                new Model { State = "Tehran", Continent = "Asia", Country = "Iran", Population = 14795116 },
                new Model { State = "Tokyo", Continent = "Asia", Country = "Japan", Population = 13010279 },
                new Model { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 24000200 },
                new Model { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 15042531 },
                new Model { State = "Rift Valley", Continent = "Africa", Country = "Kenya", Population = 10006805 },
                new Model { State = "Lagos", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new Model { State = "Kano", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new Model { State = "Gauteng", Continent = "Africa", Country = "South Africa", Population = 12728400 },
                new Model { State = "KwaZulu-Natal", Continent = "Africa", Country = "South Africa", Population = 10456900 },
                new Model { State = "Ile-de- France", Continent = "Europe", Country = "France", Population = 11694000 },
                new Model { State = "North Rhine-Westphalia", Continent = "Europe", Country = "Germany", Population = 17872863 },
                new Model { State = "Bavaria", Continent = "Europe", Country = "Germany", Population = 12510331 },
                new Model { State = "NBaden-Wurttemberg", Continent = "Europe", Country = "Germany", Population = 10747479 },
                new Model { State = "Istanbul", Continent = "Europe", Country = "Turkey", Population = 12915158 },
                new Model { State = "England", Continent = "Europe", Country = "United Kingdom", Population = 51446600 }
            };
        }

        public ObservableCollection<Model> Population_Data { get; set; }

        public Array SelectionMode
        {
            get { return Enum.GetValues(typeof(Syncfusion.UI.Xaml.SunburstChart.SelectionMode)); }
        }

        public Array SelectionType
        {
            get { return Enum.GetValues(typeof(SelectionType)); }
        }

        public Array SelectionDisplayMode
        {
            get { return Enum.GetValues(typeof(SelectionDisplayMode)).Cast<SelectionDisplayMode>().Except(new SelectionDisplayMode[] { Syncfusion.UI.Xaml.SunburstChart.SelectionDisplayMode.HighlightByStrokeColor }).ToArray(); }
        }
    }

    public class Model
    {
        public string Continent { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public double Population { get; set; }
    }
}
