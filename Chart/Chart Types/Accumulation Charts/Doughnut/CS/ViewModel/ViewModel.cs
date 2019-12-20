#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoughnutChart
{
    public class ViewModel
    {
        public string[] DoughnutTypes
        {
            get
            {
                return new string[] { "Doughnut", "Multiple Doughnut", "Stacked Doughnut" };
            }
        }

        public ViewModel()
        {
            this.Tax = new List<Model>();

            Tax.Add(new Model() { Category = "Total License", Percentage = 20d });
            Tax.Add(new Model() { Category = "Other", Percentage = 23d });
            Tax.Add(new Model() { Category = "Sales and Gross Receipt", Percentage = 12d });
            Tax.Add(new Model() { Category = "Corporation Net Income", Percentage = 28d });
            Tax.Add(new Model() { Category = "Individual Income", Percentage = 10d });
            Tax.Add(new Model() { Category = "Sales", Percentage = 10d });

            this.Population = new List<Populations>();

            Population.Add(new Populations() { Continent = "Asia", Countries = "China", States = "Taiwan", PopulationinContinents = 50.02, PopulationinCountries = 26.02, PopulationinStates = 18.02 });
            Population.Add(new Populations() { Continent = "Africa", Countries = "India", States = "Shandong", PopulationinContinents = 20.81, PopulationinCountries = 24, PopulationinStates = 8 });
            Population.Add(new Populations() { Continent = "Europe", Countries = "Nigeria", States = "Uttar Pradesh", PopulationinContinents = 15.37, PopulationinCountries = 12.81, PopulationinStates = 14.5 });
            Population.Add(new Populations() { Countries = "Ethiopia", States = "Maharashtra", PopulationinCountries = 8, PopulationinStates = 9.5 });
            Population.Add(new Populations() { Countries = "Germany", States = "Kano", PopulationinCountries = 8.37, PopulationinStates = 7.81 });
            Population.Add(new Populations() { Countries = "Turkey", States = "Lagos", PopulationinCountries = 7, PopulationinStates = 5 });
            Population.Add(new Populations() { States = "Oromia", PopulationinStates = 5 });
            Population.Add(new Populations() { States = "Amhara", PopulationinStates = 3 });
            Population.Add(new Populations() { States = "Hessen", PopulationinStates = 5.37 });
            Population.Add(new Populations() { States = "Bayern", PopulationinStates = 3 });
            Population.Add(new Populations() { States = "Istanbul", PopulationinStates = 4.5 });
            Population.Add(new Populations() { States = "Ankara", PopulationinStates = 2.5 });

            ExpenditureData = new List<Populations>
            {
                new Populations(){Category="Vehicle", Expenditure = 62.7, Image= new Uri(@"\Image\Car.png",UriKind.RelativeOrAbsolute) },
                new Populations(){Category="Education", Expenditure = 29.5, Image= new Uri(@"\Image\Chart_Book.png",UriKind.RelativeOrAbsolute) },
                new Populations(){Category="Home", Expenditure = 85.2, Image= new Uri(@"\Image\House.png",UriKind.RelativeOrAbsolute) },
                new Populations(){Category="Personal", Expenditure = 45.6, Image= new Uri(@"\Image\Personal.png",UriKind.RelativeOrAbsolute) },
            };
        }

        public IList<Model> Tax
        {
            get;
            set;
        }

        public IList<Populations> Population
        {
            get;
            set;
        }

        public IList<Populations> ExpenditureData
        {
            get;
            set;
        }
    }
}
