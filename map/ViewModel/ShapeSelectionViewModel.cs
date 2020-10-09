#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.mapdemos.wpf
{
    public class ShapeSelectionViewModel
    {
        public ObservableCollection<ShapeSelectionModel> CountriesList { get; set; }
        public ShapeSelectionViewModel()
        {
            CountriesList = GetCountries();
        }
        public static ObservableCollection<ShapeSelectionModel> GetCountries()
        {
            ObservableCollection<ShapeSelectionModel> countriesList = new ObservableCollection<ShapeSelectionModel>();
            countriesList.Add(new ShapeSelectionModel() { Country = "Afghanistan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Angola", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Albania", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "United Arab Emirates", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Argentina", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Armenia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Antarctica", Continent = "Antarctica" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Fr. S. and Antarctic Lands", Continent = "Antarctica" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Australia", Continent = "Oceania" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Austria", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Azerbaijan", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Burundi", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Belgium", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Benin", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Burkina Faso", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Bangladesh", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Bulgaria", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Bahamas", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Bosnia and Herz.", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Belarus", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Belize", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Bolivia", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Brazil", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Brunei", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Bhutan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Botswana", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Central African Rep.", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Canada", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Switzerland", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Chile", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "China", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Ivory Coast", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Cameroon", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Congo (Kinshasa)", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Congo (Brazzaville)", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Colombia", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Costa Rica", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Cuba", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "N. Cyprus", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Cyprus", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Czech Rep.", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Germany", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Djibouti", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Denmark", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Dominican Rep.", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Algeria", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Ecuador", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Egypt", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Eritrea", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Spain", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Estonia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Ethiopia", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Finland", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Fiji", Continent = "Oceania" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Falkland Is.", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "France", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Gabon", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "United Kingdom", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Georgia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Ghana", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Guinea", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Gambia", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Guinea Bissau", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Eq. Guinea", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Greece", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Greenland", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Guatemala", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Guyana", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Honduras", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Croatia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Haiti", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Hungary", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Indonesia", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "India", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Ireland", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Iran", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Iraq", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Iceland", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Israel", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Italy", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Jamaica", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Jordan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Japan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Kazakhstan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Kenya", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Kyrgyzstan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Cambodia", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "S. Korea", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Kosovo", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Kuwait", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Laos", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Lebanon", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Liberia", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Libya", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Sri Lanka", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Lesotho", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Lithuania", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Luxembourg", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Latvia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Morocco", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Moldova", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Madagascar", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Mexico", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Macedonia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Mali", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Myanmar", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Montenegro", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Mongolia", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Mozambique", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Mauritania", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Malawi", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Malaysia", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Namibia", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "New Caledonia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Niger", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Nigeria", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Nicaragua", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Netherlands", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Norway", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Nepal", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "New Zealand", Continent = "Oceania" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Oman", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Pakistan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Panama", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Peru", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Philippines", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Papua New Guinea", Continent = "Oceania" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Poland", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Puerto Rico", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "N. Korea", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Portugal", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Paraguay", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Qatar", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Romania", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Russia", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Rwanda", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "W. Sahara", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Saudi Arabia", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Sudan", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "S. Sudan", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Senegal", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Solomon Is.", Continent = "Oceania" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Sierra Leone", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "El Salvador", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Somaliland", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Somalia", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Serbia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Suriname", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Slovakia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Slovenia", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Sweden", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Swaziland", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Syria", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Chad", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Togo", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Thailand", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Tajikistan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Turkmenistan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "East Timor", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Trinidad and Tobago", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Tunisia", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Turkey", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Taiwan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Tanzania", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Uganda", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Ukraine", Continent = "Europe" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Uruguay", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "United States", Continent = "North America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Uzbekistan", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Venezuela", Continent = "South America" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Vietnam", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Vanuatu", Continent = "Oceania" });
            countriesList.Add(new ShapeSelectionModel() { Country = "West Bank", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Yemen", Continent = "Asia" });
            countriesList.Add(new ShapeSelectionModel() { Country = "South Africa", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Zambia", Continent = "Africa" });
            countriesList.Add(new ShapeSelectionModel() { Country = "Zimbabwe", Continent = "Africa" });

            return countriesList;
        }
    }
}
