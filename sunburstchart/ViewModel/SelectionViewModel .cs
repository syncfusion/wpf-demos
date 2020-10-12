#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.SunburstChart;
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

namespace syncfusion.sunburstchartdemos.wpf
{
    public class SelectionViewModel : Control
    {
        public SelectionViewModel()
        {
            this.Population_Data = new ObservableCollection<SelectionModel>
            {
                new SelectionModel { State = "Ontario", Continent = "North America", Country = "Canada", Population = 13210600 },
                new SelectionModel { State = "Mexico", Continent = "North America", Country = "Mexico", Population = 15174272 },
                new SelectionModel { State = "California", Continent = "North America", Country = "United States", Population = 37253956 },
                new SelectionModel { State = "Texas", Continent = "North America", Country = "United States", Population = 25145561 },
                new SelectionModel { State = "New York", Continent = "North America", Country = "United States", Population = 19378102 },
                new SelectionModel { State = "Florida", Continent = "North America", Country = "United States", Population = 18801310 },
                new SelectionModel { State = "Illinois", Continent = "North America", Country = "United States", Population = 12830632 },
                new SelectionModel { State = "Pennsylvania", Continent = "North America", Country = "United States", Population = 12702379 },
                new SelectionModel { State = "Ohio", Continent = "North America", Country = "United States", Population = 11536504 },
                new SelectionModel { State = "Buenos Aires", Continent = "South America", Country = "Argentina", Population = 15594428 },
                new SelectionModel { State = "Sao Paulo", Continent = "South America", Country = "Brazil", Population = 43663672 },
                new SelectionModel { State = "Minas Gerais", Continent = "South America", Country = "Brazil", Population = 20593366 },
                new SelectionModel { State = "Rio de Janeiro", Continent = "South America", Country = "Brazil", Population = 16369178 },
                new SelectionModel { State = "Bahia", Continent = "South America", Country = "Brazil", Population = 15044127 },
                new SelectionModel { State = "Rio Grande do Sul", Continent = "South America", Country = "Brazil", Population = 11164050 },
                new SelectionModel { State = "Parana", Continent = "South America", Country = "Brazil", Population = 10997462 },
                new SelectionModel { State = "Dhaka", Continent = "Asia", Country = "Bangladesh", Population = 46729000 },
                new SelectionModel { State = "Chittagong", Continent = "Asia", Country = "Bangladesh", Population = 28079000 },
                new SelectionModel { State = "Rajshahi", Continent = "Asia", Country = "Bangladesh", Population = 18329000 },
                new SelectionModel { State = "Rangpur", Continent = "Asia", Country = "Bangladesh", Population = 15665000 },
                new SelectionModel { State = "Khulna", Continent = "Asia", Country = "Bangladesh", Population = 15563000 },
                new SelectionModel { State = "Jiangxi", Continent = "Asia", Country = "China", Population = 44567475 },
                new SelectionModel { State = "Liaoning", Continent = "Asia", Country = "China", Population = 43746323 },
                new SelectionModel { State = "Heilongjiang", Continent = "Asia", Country = "China", Population = 38312224 },
                new SelectionModel { State = "Shaanxi", Continent = "Asia", Country = "China", Population = 37327378 },
                new SelectionModel { State = "Fujian", Continent = "Asia", Country = "China", Population = 36894216 },
                new SelectionModel { State = "Shanxi", Continent = "Asia", Country = "China", Population = 35712111 },
                new SelectionModel { State = "Shanghai", Continent = "Asia", Country = "China", Population = 23019148 },
                new SelectionModel { State = "Karnataka", Continent = "Asia", Country = "India", Population = 61130704 },
                new SelectionModel { State = "Gujarat", Continent = "Asia", Country = "India", Population = 60383628 },
                new SelectionModel { State = "Kerala", Continent = "Asia", Country = "India", Population = 33387677 },
                new SelectionModel { State = "Punjab", Continent = "Asia", Country = "India", Population = 27704236 },
                new SelectionModel { State = "Haryana", Continent = "Asia", Country = "India", Population = 25353081 },
                new SelectionModel { State = "Delhi", Continent = "Asia", Country = "India", Population = 16753235 },
                new SelectionModel { State = "Jammu", Continent = "Asia", Country = "India", Population = 12548926 },
                new SelectionModel { State = "West Java", Continent = "Asia", Country = "Indonesia", Population = 43021826 },
                new SelectionModel { State = "East Java", Continent = "Asia", Country = "Indonesia", Population = 37476011 },
                new SelectionModel { State = "Central Java", Continent = "Asia", Country = "Indonesia", Population = 32380687 },
                new SelectionModel { State = "North Sumatra", Continent = "Asia", Country = "Indonesia", Population = 12985075 },
                new SelectionModel { State = "Banten", Continent = "Asia", Country = "Indonesia", Population = 10644030 },
                new SelectionModel { State = "Jakarta", Continent = "Asia", Country = "Indonesia", Population = 10187595 },
                new SelectionModel { State = "Tehran", Continent = "Asia", Country = "Iran", Population = 14795116 },
                new SelectionModel { State = "Tokyo", Continent = "Asia", Country = "Japan", Population = 13010279 },
                new SelectionModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 24000200 },
                new SelectionModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 15042531 },
                new SelectionModel { State = "Rift Valley", Continent = "Africa", Country = "Kenya", Population = 10006805 },
                new SelectionModel { State = "Lagos", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new SelectionModel { State = "Kano", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new SelectionModel { State = "Gauteng", Continent = "Africa", Country = "South Africa", Population = 12728400 },
                new SelectionModel { State = "KwaZulu-Natal", Continent = "Africa", Country = "South Africa", Population = 10456900 },
                new SelectionModel { State = "Ile-de- France", Continent = "Europe", Country = "France", Population = 11694000 },
                new SelectionModel { State = "North Rhine-Westphalia", Continent = "Europe", Country = "Germany", Population = 17872863 },
                new SelectionModel { State = "Bavaria", Continent = "Europe", Country = "Germany", Population = 12510331 },
                new SelectionModel { State = "NBaden-Wurttemberg", Continent = "Europe", Country = "Germany", Population = 10747479 },
                new SelectionModel { State = "Istanbul", Continent = "Europe", Country = "Turkey", Population = 12915158 },
                new SelectionModel { State = "England", Continent = "Europe", Country = "United Kingdom", Population = 51446600 }
            };
        }

        public ObservableCollection<SelectionModel> Population_Data { get; set; }

    }
}
