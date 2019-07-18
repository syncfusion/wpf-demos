#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Maps;
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

namespace ShapeSelection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.map.MouseLeftButtonUp+=map_MouseLeftButtonUp;
            this.map.MouseLeave += map_MouseLeave;
            (this.map.Layers[0] as ShapeFileLayer).ShapesSelected += MainWindow_ShapesSelected;
            listbox.SelectionChanged += listbox_SelectionChanged;
        }

        void map_MouseLeave(object sender, MouseEventArgs e)
        {
            listbox.Items.Clear();

            ShapeFileLayer shapefilelayer1 = (sender as SfMap).Layers[0] as ShapeFileLayer;

            if ( shapefilelayer1.SelectedMapShapes.Count > 0)
            {
                var selectedshapes = shapefilelayer1.SelectedMapShapes;
                foreach (MapShape mapshape in selectedshapes)
                {
                    if (mapshape.ShapeValue != null)
                    {
                        listbox.Items.Add(mapshape.ShapeValue.ToString());
                    }
                }

            }
            if (listbox.Items != null && listbox.Items.Count > 0)
            {
                textblock.Visibility = Visibility.Visible;
            }
            else
            {
                textblock.Visibility = Visibility.Collapsed;
            }
        }

        void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null && (sender as ListBox).SelectedValue != null)
            {
                string str = (sender as ListBox).SelectedValue.ToString();
                foreach (MapShape item in (this.map.Layers[0] as ShapeFileLayer).SelectedMapShapes)
                {
                    if (item.ShapeValue != null)
                    {
                        if (item.ShapeValue.ToString().Equals(str))
                        {
                            item.Shape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x8A, 0xC6, 0x3C));
                        }
                        else
                        {
                            item.Shape.Fill = (this.map.Layers[0] as ShapeFileLayer).ShapeSettings.SelectedShapeColor;
                        }
                    }
                }
            }
        }

        

        void MainWindow_ShapesSelected(object sender, SelectionEventArgs args)
        {
            ShapeFileLayer shapefilelayer1 = sender as ShapeFileLayer;
            if (shapefilelayer1.SelectedMapShapes.Count == 1 && shapefilelayer1.SelectedMapShapes[0].ShapeValue != null)
            {
                textblock.Visibility = Visibility.Visible;
                listbox.Items.Clear();
                listbox.Items.Add(new ListBoxItem() { Content = shapefilelayer1.SelectedMapShapes[0].ShapeValue.ToString() });
            }
        }

        void map_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            listbox.Items.Clear();

            ShapeFileLayer shapefilelayer1 = (sender as SfMap).Layers[0] as ShapeFileLayer;

            if (shapefilelayer1.SelectedMapShapes.Count > 0)
            {
                var selectedshapes = shapefilelayer1.SelectedMapShapes;
                foreach (MapShape mapshape in selectedshapes)
                {
                    if (mapshape.ShapeValue != null)
                    {
                        listbox.Items.Add(mapshape.ShapeValue.ToString());
                    }
                }

            }
            if (listbox.Items != null && listbox.Items.Count > 0)
            {
                textblock.Visibility = Visibility.Visible;
            }
            else
            {
                textblock.Visibility = Visibility.Collapsed;
            }
            
            
        }


    }
    public class Countries
    {
        public Countries()
        {
        }
        #region Properties
        public string Continent { get; set; }
        public string Country { get; set; }
                
        #endregion
    }
    public class MapViewModel
    {
        public ObservableCollection<Countries> CountriesList { get; set; }
        public MapViewModel()
        {
            CountriesList = GetCountries();
        }
        public static ObservableCollection<Countries> GetCountries()
        {
            ObservableCollection<Countries> countriesList = new ObservableCollection<Countries>();
            countriesList.Add(new Countries() { Country = "Afghanistan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Angola", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Albania", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "United Arab Emirates", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Argentina", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Armenia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Antarctica", Continent = "Antarctica" });
            countriesList.Add(new Countries() { Country = "Fr. S. and Antarctic Lands", Continent = "Antarctica" });
            countriesList.Add(new Countries() { Country = "Australia", Continent = "Oceania" });
            countriesList.Add(new Countries() { Country = "Austria", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Azerbaijan", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Burundi", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Belgium", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Benin", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Burkina Faso", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Bangladesh", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Bulgaria", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Bahamas", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Bosnia and Herz.", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Belarus", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Belize", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Bolivia", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Brazil", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Brunei", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Bhutan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Botswana", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Central African Rep.", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Canada", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Switzerland", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Chile", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "China", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Ivory Coast", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Cameroon", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Congo (Kinshasa)", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Congo (Brazzaville)", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Colombia", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Costa Rica", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Cuba", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "N. Cyprus", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Cyprus", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Czech Rep.", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Germany", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Djibouti", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Denmark", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Dominican Rep.", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Algeria", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Ecuador", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Egypt", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Eritrea", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Spain", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Estonia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Ethiopia", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Finland", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Fiji", Continent = "Oceania" });
            countriesList.Add(new Countries() { Country = "Falkland Is.", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "France", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Gabon", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "United Kingdom", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Georgia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Ghana", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Guinea", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Gambia", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Guinea Bissau", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Eq. Guinea", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Greece", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Greenland", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Guatemala", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Guyana", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Honduras", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Croatia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Haiti", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Hungary", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Indonesia", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "India", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Ireland", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Iran", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Iraq", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Iceland", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Israel", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Italy", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Jamaica", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Jordan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Japan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Kazakhstan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Kenya", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Kyrgyzstan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Cambodia", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "S. Korea", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Kosovo", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Kuwait", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Laos", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Lebanon", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Liberia", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Libya", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Sri Lanka", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Lesotho", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Lithuania", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Luxembourg", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Latvia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Morocco", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Moldova", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Madagascar", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Mexico", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Macedonia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Mali", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Myanmar", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Montenegro", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Mongolia", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Mozambique", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Mauritania", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Malawi", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Malaysia", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Namibia", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "New Caledonia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Niger", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Nigeria", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Nicaragua", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Netherlands", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Norway", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Nepal", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "New Zealand", Continent = "Oceania" });
            countriesList.Add(new Countries() { Country = "Oman", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Pakistan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Panama", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Peru", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Philippines", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Papua New Guinea", Continent = "Oceania" });
            countriesList.Add(new Countries() { Country = "Poland", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Puerto Rico", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "N. Korea", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Portugal", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Paraguay", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Qatar", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Romania", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Russia", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Rwanda", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "W. Sahara", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Saudi Arabia", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Sudan", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "S. Sudan", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Senegal", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Solomon Is.", Continent = "Oceania" });
            countriesList.Add(new Countries() { Country = "Sierra Leone", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "El Salvador", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Somaliland", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Somalia", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Serbia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Suriname", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Slovakia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Slovenia", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Sweden", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Swaziland", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Syria", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Chad", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Togo", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Thailand", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Tajikistan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Turkmenistan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "East Timor", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Trinidad and Tobago", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Tunisia", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Turkey", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Taiwan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Tanzania", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Uganda", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Ukraine", Continent = "Europe" });
            countriesList.Add(new Countries() { Country = "Uruguay", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "United States", Continent = "North America" });
            countriesList.Add(new Countries() { Country = "Uzbekistan", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Venezuela", Continent = "South America" });
            countriesList.Add(new Countries() { Country = "Vietnam", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Vanuatu", Continent = "Oceania" });
            countriesList.Add(new Countries() { Country = "West Bank", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "Yemen", Continent = "Asia" });
            countriesList.Add(new Countries() { Country = "South Africa", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Zambia", Continent = "Africa" });
            countriesList.Add(new Countries() { Country = "Zimbabwe", Continent = "Africa" });

            return countriesList;
        }
    }
}
