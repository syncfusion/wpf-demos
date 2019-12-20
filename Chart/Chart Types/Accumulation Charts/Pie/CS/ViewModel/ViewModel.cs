#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieChart
{
    public class ViewModel : INotifyPropertyChanged
    {
        public string CurrentPieTypeString
        {
            get
            {
                return currentPieTypeString;
            }

            set
            {
                currentPieTypeString = value;
                OnPropertyChanged("CurrentPieTypeString");
                
                if (currentPieTypeString == "Pie")
                {
                    CurrentPieType = new PieSeriesDemo();
                }
                else
                {
                    CurrentPieType = new MultiplePieSeriesDemo();
                }
            }
        }

        public object CurrentPieType
        {
            get
            {
                return currentPieType;
            }

            set
            {
                currentPieType = value;
                OnPropertyChanged("CurrentPieType");
            }
        }

        public List<String> PieTypes
        {
            get
            {
                return new List<string>() { "Pie", "Multiple Pie" };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string currentPieTypeString;
        private object currentPieType;

        public ViewModel()
        {
            this.Data = new List<Model>();

            Data.Add(new Model() { Country = "Uruguay", Count = 2807 });
            Data.Add(new Model() { Country = "Argentina", Count = 2577 });
            Data.Add(new Model() { Country = "USA", Count = 2473 });
            Data.Add(new Model() { Country = "Germany", Count = 2120 });
            Data.Add(new Model() { Country = "Netherlands", Count = 2071 });
            Data.Add(new Model() { Country = "Malta", Count = 960 });
            Data.Add(new Model() { Country = "Maldives", Count = 941 });
            Data.Add(new Model() { Country = "Monaco", Count = 908 });

            this.Population = new List<Population>();
            Population.Add(new Population() { Continent = "Asia", Countries = "China", States = "Taiwan", PopulationinContinents = 50.02, PopulationinCountries = 26.02, PopulationinStates = 18.02 });
            Population.Add(new Population() { Continent = "Africa", Countries = "India", States = "Shandong", PopulationinContinents = 20.81, PopulationinCountries = 24, PopulationinStates = 8 });
            Population.Add(new Population() { Continent = "Europe", Countries = "Nigeria", States = "Uttar Pradesh", PopulationinContinents = 15.37, PopulationinCountries = 12.81, PopulationinStates = 14.5 });
            Population.Add(new Population() { Countries = "Ethiopia", States = "Maharashtra", PopulationinCountries = 8, PopulationinStates = 9.5 });
            Population.Add(new Population() { Countries = "Germany", States = "Kano", PopulationinCountries = 8.37, PopulationinStates = 7.81 });
            Population.Add(new Population() { Countries = "Turkey", States = "Lagos", PopulationinCountries = 7, PopulationinStates = 5 });
            Population.Add(new Population() { States = "Oromia", PopulationinStates = 5 });
            Population.Add(new Population() { States = "Amhara", PopulationinStates = 3 });
            Population.Add(new Population() { States = "Hessen", PopulationinStates = 5.37 });
            Population.Add(new Population() { States = "Bayern", PopulationinStates = 3 });
            Population.Add(new Population() { States = "Istanbul", PopulationinStates = 4.5 });
            Population.Add(new Population() { States = "Ankara", PopulationinStates = 2.5 });

            CurrentPieTypeString = "Pie";
        }

        public IList<Model> Data
        {
            get;
            set;
        }

        public IList<Population> Population
        {
            get;
            set;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
