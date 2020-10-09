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
    public class AnimationViewModel 
    {
        public AnimationViewModel()
        {
            this.Population_Data = new ObservableCollection<AnimationModel>
            {
                new AnimationModel { State = "Ontario", Continent = "North America", Country = "Canada", Population = 13210600 },
                new AnimationModel { State = "New York", Continent = "North America", Country = "United States", Population = 19378102 },
                new AnimationModel { State = "Pennsylvania", Continent = "North America", Country = "United States", Population = 12702379 },
                new AnimationModel { State = "Ohio", Continent = "North America", Country = "United States", Population = 11536504 },
                new AnimationModel { State = "Buenos Aires", Continent = "South America", Country = "Argentina", Population = 15594428 },
                new AnimationModel { State = "Minas Gerais", Continent = "South America", Country = "Brazil", Population = 20593366 },
                new AnimationModel { State = "Rio de Janeiro", Continent = "South America", Country = "Brazil", Population = 16369178 },
                new AnimationModel { State = "Bahia", Continent = "South America", Country = "Brazil", Population = 15044127 },
                new AnimationModel { State = "Rio Grande do Sul", Continent = "South America", Country = "Brazil", Population = 11164050 },
                new AnimationModel { State = "Parana", Continent = "South America", Country = "Brazil", Population = 10997462 },
                new AnimationModel { State = "Chittagong", Continent = "Asia", Country = "Bangladesh", Population = 28079000 },
                new AnimationModel { State = "Rajshahi", Continent = "Asia", Country = "Bangladesh", Population = 18329000 },
                new AnimationModel { State = "Khulna", Continent = "Asia", Country = "Bangladesh", Population = 15563000 },
                new AnimationModel { State = "Liaoning", Continent = "Asia", Country = "China", Population = 43746323 },
                new AnimationModel { State = "Shaanxi", Continent = "Asia", Country = "China", Population = 37327378 },
                new AnimationModel { State = "Fujian", Continent = "Asia", Country = "China", Population = 36894216 },
                new AnimationModel { State = "Shanxi", Continent = "Asia", Country = "China", Population = 35712111 },
                new AnimationModel { State = "Kerala", Continent = "Asia", Country = "India", Population = 33387677 },
                new AnimationModel { State = "Punjab", Continent = "Asia", Country = "India", Population = 27704236 },
                new AnimationModel { State = "Haryana", Continent = "Asia", Country = "India", Population = 25353081 },
                new AnimationModel { State = "Delhi", Continent = "Asia", Country = "India", Population = 16753235 },
                new AnimationModel { State = "Jammu", Continent = "Asia", Country = "India", Population = 12548926 },
                new AnimationModel { State = "West Java", Continent = "Asia", Country = "Indonesia", Population = 43021826 },
                new AnimationModel { State = "East Java", Continent = "Asia", Country = "Indonesia", Population = 37476011 },
                new AnimationModel { State = "Banten", Continent = "Asia", Country = "Indonesia", Population = 10644030 },
                new AnimationModel { State = "Jakarta", Continent = "Asia", Country = "Indonesia", Population = 10187595 },
                new AnimationModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 24000200 },
                new AnimationModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 15042531 },
                new AnimationModel { State = "Rift Valley", Continent = "Africa", Country = "Kenya", Population = 10006805 },
                new AnimationModel { State = "Lagos", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new AnimationModel { State = "Kano", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new AnimationModel { State = "Gauteng", Continent = "Africa", Country = "South Africa", Population = 12728400 },
                new AnimationModel { State = "KwaZulu-Natal", Continent = "Africa", Country = "South Africa", Population = 10456900 },
                new AnimationModel { State = "Ile-de- France", Continent = "Europe", Country = "France", Population = 11694000 },
                new AnimationModel { State = "North Rhine-Westphalia", Continent = "Europe", Country = "Germany", Population = 17872863 },
                new AnimationModel { State = "Bavaria", Continent = "Europe", Country = "Germany", Population = 12510331 },
                new AnimationModel { State = "NBaden-Wurttemberg", Continent = "Europe", Country = "Germany", Population = 10747479 },
                new AnimationModel { State = "England", Continent = "Europe", Country = "United Kingdom", Population = 51446600 }
            };

        }

        public ObservableCollection<AnimationModel> Population_Data { get; set; }

    }
}
