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

namespace syncfusion.chartdemos.wpf
{
    public class LineChartViewModel
    {
        public LineChartViewModel()
        {
            this.DataPoints = new ObservableCollection<LineChartModel>();
            DateTime year = new DateTime(2005, 5, 1);

            DataPoints.Add(new LineChartModel() { Year = year.AddYears(1), Germany = 24, England = 34 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(2), Germany = 14, England = 24 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(3), Germany = 25, England = 35 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(4), Germany = 08, England = 18 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(5), Germany = 27, England = 37 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(6), Germany = 34, England = 44 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(7), Germany = 39, England = 49 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(8), Germany = 17, England = 27 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(9), Germany = 24, England = 34 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(10), Germany = 28, England = 38 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(11), Germany = 34, England = 44 });
            DataPoints.Add(new LineChartModel() { Year = year.AddYears(12), Germany = 39, England = 49 });
        }

        public ObservableCollection<LineChartModel> DataPoints
        {
            get;
            set;
        }
    }
}
