#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace LineChart
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.DataPoints = new ObservableCollection<Model>();
            DateTime year = new DateTime(1995, 1, 1);

            DataPoints.Add(new Model() { Year = year.AddYears(0), Profit = 80 });
            DataPoints.Add(new Model() { Year = year.AddYears(1), Profit = 200 });
            DataPoints.Add(new Model() { Year = year.AddYears(2), Profit = 400 });
            DataPoints.Add(new Model() { Year = year.AddYears(3), Profit = 600 });
            DataPoints.Add(new Model() { Year = year.AddYears(4), Profit = 700 });
            DataPoints.Add(new Model() { Year = year.AddYears(5), Profit = 1400 });
            DataPoints.Add(new Model() { Year = year.AddYears(6), Profit = 2000 });
            DataPoints.Add(new Model() { Year = year.AddYears(7), Profit = 4000 });
            DataPoints.Add(new Model() { Year = year.AddYears(8), Profit = 6000 });
            DataPoints.Add(new Model() { Year = year.AddYears(9), Profit = 8000 });
            DataPoints.Add(new Model() { Year = year.AddYears(10), Profit = 11000 });
        }

        public ObservableCollection<Model> DataPoints
        {
            get;
            set;
        }
    }
}
