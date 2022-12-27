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
    public class PieChartViewModel : NotificationObject
    {
        private double startAngle;
        private double endAngle;

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

        public PieChartViewModel()
        {
            this.Data = new List<PieChartModel>();

            Data.Add(new PieChartModel() { Country = "Uruguay", Count = 2807 });
            Data.Add(new PieChartModel() { Country = "Argentina", Count = 2577 });
            Data.Add(new PieChartModel() { Country = "USA", Count = 2473 });
            Data.Add(new PieChartModel() { Country = "Germany", Count = 2120 });
            Data.Add(new PieChartModel() { Country = "Netherlands", Count = 2071 });
            Data.Add(new PieChartModel() { Country = "Malta", Count = 960 });
            Data.Add(new PieChartModel() { Country = "Maldives", Count = 941 });
            Data.Add(new PieChartModel() { Country = "Monaco", Count = 908 });

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

            this.Metrics = new List<SemiPieAndDoughnutChartModel>();
            Metrics.Add(new SemiPieAndDoughnutChartModel(43, 32));
            Metrics.Add(new SemiPieAndDoughnutChartModel(20, 34));
            Metrics.Add(new SemiPieAndDoughnutChartModel(67, 41));
            Metrics.Add(new SemiPieAndDoughnutChartModel(52, 42));
            Metrics.Add(new SemiPieAndDoughnutChartModel(71, 48));
            Metrics.Add(new SemiPieAndDoughnutChartModel(30, 45));

            StartAngle = 180;
            EndAngle = 360;

        }

        public IList<PieChartModel> Data
        {
            get;
            set;
        }

        public IList<Population> Population
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
