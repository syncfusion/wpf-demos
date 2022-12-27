#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class DoughnutChartViewModel : NotificationObject
    {
        private double startAngle;
        private double endAngle;
        private string _selectedItemName;
        private double _selectedItemsPercentage;
        private int selectedIndex;

        public double StartAngle
        {
            get
            {
                return startAngle;
            }

            set
            {
                startAngle = value;
                RaisePropertyChanged(nameof(this.StartAngle));
            }
        }

        public double EndAngle
        {
            get
            {
                return endAngle;
            }

            set
            {
                endAngle = value;
                RaisePropertyChanged(nameof(this.EndAngle));
            }
        }

        public string SelectedItemName
        {
            get { return _selectedItemName; }
            set
            {
                _selectedItemName = value;
                RaisePropertyChanged(nameof(this.SelectedItemName));
            }
        }

        public double SelectedItemsPercentage
        {
            get { return _selectedItemsPercentage; }
            set
            {
                _selectedItemsPercentage = value;
                RaisePropertyChanged(nameof(this.SelectedItemsPercentage));
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    RaisePropertyChanged(nameof(this.SelectedIndex));
                    if (Tax != null && selectedIndex > -1 && selectedIndex < Tax.Count)
                    {
                        SelectedItemName = Tax[selectedIndex].Category;
                        SelectedItemsPercentage = Tax[selectedIndex].Percentage;
                    }
                }
            }
        }

        public DoughnutChartViewModel()
        {
            StartAngle = 180;
            EndAngle = 360;

            this.Tax = new List<DoughnutChartModel>();

            Tax.Add(new DoughnutChartModel() { Category = "Total License", Percentage = 20d });
            Tax.Add(new DoughnutChartModel() { Category = "Sales and Gross Receipt", Percentage = 12d });
            Tax.Add(new DoughnutChartModel() { Category = "Corporation Net Income", Percentage = 28d });
            Tax.Add(new DoughnutChartModel() { Category = "Individual Income", Percentage = 10d });
            Tax.Add(new DoughnutChartModel() { Category = "Sales", Percentage = 10d });
            Tax.Add(new DoughnutChartModel() { Category = "Other", Percentage = 23d });

            this.Population = new List<DoughnutChartPopulations>();

            Population.Add(new DoughnutChartPopulations() { Continent = "Asia", Countries = "China", States = "Taiwan", PopulationinContinents = 50.02, PopulationinCountries = 26.02, PopulationinStates = 18.02 });
            Population.Add(new DoughnutChartPopulations() { Continent = "Africa", Countries = "India", States = "Shandong", PopulationinContinents = 20.81, PopulationinCountries = 24, PopulationinStates = 8 });
            Population.Add(new DoughnutChartPopulations() { Continent = "Europe", Countries = "Nigeria", States = "Uttar Pradesh", PopulationinContinents = 15.37, PopulationinCountries = 12.81, PopulationinStates = 14.5 });
            Population.Add(new DoughnutChartPopulations() { Countries = "Ethiopia", States = "Maharashtra", PopulationinCountries = 8, PopulationinStates = 9.5 });
            Population.Add(new DoughnutChartPopulations() { Countries = "Germany", States = "Kano", PopulationinCountries = 8.37, PopulationinStates = 7.81 });
            Population.Add(new DoughnutChartPopulations() { Countries = "Turkey", States = "Lagos", PopulationinCountries = 7, PopulationinStates = 5 });
            Population.Add(new DoughnutChartPopulations() { States = "Oromia", PopulationinStates = 5 });
            Population.Add(new DoughnutChartPopulations() { States = "Amhara", PopulationinStates = 3 });
            Population.Add(new DoughnutChartPopulations() { States = "Hessen", PopulationinStates = 5.37 });
            Population.Add(new DoughnutChartPopulations() { States = "Bayern", PopulationinStates = 3 });
            Population.Add(new DoughnutChartPopulations() { States = "Istanbul", PopulationinStates = 4.5 });
            Population.Add(new DoughnutChartPopulations() { States = "Ankara", PopulationinStates = 2.5 });

            ExpenditureData = new List<DoughnutChartPopulations>
            {
                new DoughnutChartPopulations(){Category="Vehicle", Expenditure = 62.7, Image= new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/Car.png",UriKind.RelativeOrAbsolute) },
                new DoughnutChartPopulations(){Category="Education", Expenditure = 29.5, Image= new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/Chart_Book.png",UriKind.RelativeOrAbsolute) },
                new DoughnutChartPopulations(){Category="Home", Expenditure = 85.2, Image= new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/House.png",UriKind.RelativeOrAbsolute) },
                new DoughnutChartPopulations(){Category="Personal", Expenditure = 45.6, Image= new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/Personal.png",UriKind.RelativeOrAbsolute) },
            };

            this.Metrics = new List<SemiPieAndDoughnutChartModel>();
            Metrics.Add(new SemiPieAndDoughnutChartModel(43, 32));
            Metrics.Add(new SemiPieAndDoughnutChartModel(20, 34));
            Metrics.Add(new SemiPieAndDoughnutChartModel(67, 41));
            Metrics.Add(new SemiPieAndDoughnutChartModel(52, 42));
            Metrics.Add(new SemiPieAndDoughnutChartModel(71, 48));
            Metrics.Add(new SemiPieAndDoughnutChartModel(30, 45));

            SelectedIndex = 1;
        }

        public IList<DoughnutChartModel> Tax
        {
            get;
            set;
        }

        public IList<DoughnutChartPopulations> Population
        {
            get;
            set;
        }

        public IList<DoughnutChartPopulations> ExpenditureData
        {
            get;
            set;
        }

        public IList<SemiPieAndDoughnutChartModel> Metrics
        {
            get;
            set;
        }
    }
}
