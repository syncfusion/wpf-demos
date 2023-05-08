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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class SemiPieAndDoughnutChartViewModel : ObservableCollection<SemiPieAndDoughnutChartModel>
    {
        public double StartAngle
        {
            get
            {
                return startAngle;
            }

            set
            {
                startAngle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("StartAngle"));
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
                OnPropertyChanged(new PropertyChangedEventArgs("EndAngle"));
            }
        }

        public string[] SeriesType
        {
            get
            {
                return new string[] { "Pie", "Doughnut" };
            }
        }

        private double startAngle;
        private double endAngle;

        public SemiPieAndDoughnutChartViewModel()
        {
            StartAngle = 180;
            EndAngle = 360;

            Add(new SemiPieAndDoughnutChartModel(43, 32));
            Add(new SemiPieAndDoughnutChartModel(20, 34));
            Add(new SemiPieAndDoughnutChartModel(67, 41));
            Add(new SemiPieAndDoughnutChartModel(52, 42));
            Add(new SemiPieAndDoughnutChartModel(71, 48));
            Add(new SemiPieAndDoughnutChartModel(30, 45));
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }
    }
}
