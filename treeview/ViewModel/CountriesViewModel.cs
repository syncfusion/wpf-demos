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

namespace syncfusion.treeviewdemos.wpf
{
    public class CountriesViewModel
    {
        public ObservableCollection<Country> Countries { get; set; }

        public ObservableCollection<State> States { get; set; }

        public ObservableCollection<City> Cities { get; set; }

        public ObservableCollection<object> SelectedPlaces { get; set; }

        public CountriesViewModel()
        {
            this.Countries = GenerateCountriesInfo();
        }

        private ObservableCollection<Country> GenerateCountriesInfo()
        {
            var australia = new Country() { Name = "Australia" };
            var _NSW = new State() { Name = "New South Wales" };
            var victoria = new State() { Name = "Victoria" };
            var queensland = new State() { Name = "Queensland" };
            var westAussie = new State() { Name = "West Australia" };
            var southAussie = new State() { Name = "South Australia" };
            var sydney = new City() { Name = "Sydney" };
            var canbera = new City() { Name = "Canberra" };
            var maitland = new City() { Name = "Maitland" };
            var melborne = new City() { Name = "Melbourne" };
            var brisbane = new City() { Name = "Brisbane" };
            var perth = new City() { Name = "Perth" };
            var aldehide = new City() { Name = "Adelaide" };

            australia.States = new ObservableCollection<State>();
            australia.States.Add(_NSW);
            australia.States.Add(victoria);
            australia.States.Add(queensland);
            australia.States.Add(westAussie);
            australia.States.Add(southAussie);
            _NSW.Cities = new ObservableCollection<City>();
            _NSW.Cities.Add(sydney);
            _NSW.Cities.Add(canbera);
            _NSW.Cities.Add(maitland);
            victoria.Cities = new ObservableCollection<City>();
            victoria.Cities.Add(melborne);
            queensland.Cities = new ObservableCollection<City>();
            queensland.Cities.Add(brisbane);
            westAussie.Cities = new ObservableCollection<City>();
            westAussie.Cities.Add(perth);
            southAussie.Cities = new ObservableCollection<City>();
            southAussie.Cities.Add(aldehide);


            var brazil = new Country() { Name = "Brazil" };
            var saoPaulostate = new State() { Name = "São Paulo" };
            var deJaneiro = new State() { Name = "Rio de Janeiro" };
            var gerais = new State() { Name = "Minas Gerais" };
            var ceara = new State() { Name = "Ceará" };
            var parana = new State() { Name = "Paraná" };
            var saoPaulo = new City() { Name = "São Paulo" };
            var campinas = new City() { Name = "Campinas" };
            var sorocaba = new City() { Name = "Sorocaba" };
            var horizonte = new City() { Name = "Belo Horizonte" };
            var brassilia = new City() { Name = "Distrito Federal e Entorno (Brasilia)" };
            var fortaleza = new City() { Name = "Fortaleza" };
            var caucaia = new City() { Name = "Caucaia" };
            var curitiba = new City() { Name = "Curitiba" };

            brazil.States = new ObservableCollection<State>();
            brazil.States.Add(saoPaulostate);
            brazil.States.Add(deJaneiro);
            brazil.States.Add(gerais);
            brazil.States.Add(ceara);
            brazil.States.Add(parana);
            saoPaulostate.Cities = new ObservableCollection<City>();
            saoPaulostate.Cities.Add(saoPaulo);
            saoPaulostate.Cities.Add(campinas);
            saoPaulostate.Cities.Add(sorocaba);
            gerais.Cities = new ObservableCollection<City>();
            gerais.Cities.Add(horizonte);
            gerais.Cities.Add(brassilia);
            ceara.Cities = new ObservableCollection<City>();
            ceara.Cities.Add(fortaleza);
            ceara.Cities.Add(caucaia);
            parana.Cities = new ObservableCollection<City>();
            parana.Cities.Add(curitiba);


            var china = new Country() { Name = "China" };
            var guangdong = new State() { Name = "Guangdong" };
            var jingjinji = new State() { Name = "Jingjinji" };
            var yangtze = new State() { Name = "Yangtze River Delta" };
            var chengyu = new State() { Name = "Chengyu" };
            var zhejiang = new State() { Name = "Zhejiang Province" };

            var guanghou = new City() { Name = "Guangzhou" };
            var beijing = new City() { Name = "Beijing" };
            var tianjin = new City() { Name = "Tianjin" };
            var shanghai = new City() { Name = "Shanghai" };
            var chongqing = new City() { Name = "Chongqing" };
            var hangzhou = new City() { Name = "Hangzhou" };

            china.States = new ObservableCollection<State>();
            china.States.Add(guangdong);
            china.States.Add(jingjinji);
            china.States.Add(yangtze);
            china.States.Add(chengyu);
            china.States.Add(zhejiang);
            guangdong.Cities = new ObservableCollection<City>();
            guangdong.Cities.Add(guanghou);
            jingjinji.Cities = new ObservableCollection<City>();
            jingjinji.Cities.Add(beijing);
            jingjinji.Cities.Add(tianjin);
            yangtze.Cities = new ObservableCollection<City>();
            yangtze.Cities.Add(shanghai);
            chengyu.Cities = new ObservableCollection<City>();
            chengyu.Cities.Add(chongqing);
            zhejiang.Cities = new ObservableCollection<City>();
            zhejiang.Cities.Add(hangzhou);

            var usa = new Country() { Name = "United States of America" };
            var newYork = new State() { Name = "New York" };
            var california = new State() { Name = "California" };
            var illinois = new State() { Name = "Illinois" };
            var texas = new State() { Name = "Texas" };
            var pennsylvania = new State() { Name = "Pennsylvania" };

            var losAngeles = new City() { Name = "Los Angeles" };
            var sanJose = new City() { Name = "San Jose" };
            var sanFrancisco = new City() { Name = "San Francisco" };
            var chicago = new City() { Name = "Chicago" };
            var houston = new City() { Name = "Houston" };
            var sanAntonio = new City() { Name = "San Antonio" };
            var dallas = new City() { Name = "Dallas" };
            var philadelphia = new City() { Name = "Philadelphia" };
            usa.States = new ObservableCollection<State>();
            usa.States.Add(newYork);
            usa.States.Add(california);
            usa.States.Add(illinois);
            usa.States.Add(texas);
            usa.States.Add(pennsylvania);
            california.Cities = new ObservableCollection<City>();
            california.Cities.Add(losAngeles);
            california.Cities.Add(sanJose);
            california.Cities.Add(sanFrancisco);
            illinois.Cities = new ObservableCollection<City>();
            illinois.Cities.Add(chicago);
            texas.Cities = new ObservableCollection<City>();
            texas.Cities.Add(houston);
            texas.Cities.Add(sanAntonio);
            texas.Cities.Add(dallas);
            pennsylvania.Cities = new ObservableCollection<City>();
            pennsylvania.Cities.Add(philadelphia);


            var india = new Country() { Name = "India" };
            var delhi = new State() { Name = "Delhi" };
            var maharastra = new State() { Name = "Maharashtra" };
            var westBengal = new State() { Name = "West Bengal" };
            var karnataka = new State() { Name = "Karnataka" };
            var tamilNadu = new State() { Name = "Tamil Nadu" };
            var newDelhi = new City() { Name = "New Delhi" };
            var mumbai = new City() { Name = "Mumbai" };
            var pune = new City() { Name = "Pune" };
            var kolkata = new City() { Name = "Kolkata" };
            var bangalore = new City() { Name = "Bangalore" };
            var chennai = new City() { Name = "Chennai" };

            india.States = new ObservableCollection<State>();
            india.States.Add(delhi);
            india.States.Add(maharastra);
            india.States.Add(westBengal);
            india.States.Add(karnataka);
            india.States.Add(tamilNadu);
            delhi.Cities = new ObservableCollection<City>();
            delhi.Cities.Add(newDelhi);
            maharastra.Cities = new ObservableCollection<City>();
            maharastra.Cities.Add(mumbai);
            maharastra.Cities.Add(pune);
            westBengal.Cities = new ObservableCollection<City>();
            westBengal.Cities.Add(kolkata);
            karnataka.Cities = new ObservableCollection<City>();
            karnataka.Cities.Add(bangalore);
            tamilNadu.Cities = new ObservableCollection<City>();
            tamilNadu.Cities.Add(chennai);

            var CountriesInfo = new ObservableCollection<Country>();
            CountriesInfo.Add(australia);
            CountriesInfo.Add(brazil);
            CountriesInfo.Add(china);
            CountriesInfo.Add(usa);
            CountriesInfo.Add(india);

            SelectedPlaces = new ObservableCollection<object>();
            SelectedPlaces.Add(_NSW);
            SelectedPlaces.Add(southAussie);
            SelectedPlaces.Add(ceara);
            SelectedPlaces.Add(newYork);

            return CountriesInfo;
        }
    }
}
