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
            DateTime year = new DateTime(2005, 5, 1);

            DataPoints.Add(new Model() { Year = year.AddYears(1), India = 28, Germany = 31, England = 36, France = 39 });
            DataPoints.Add(new Model() { Year = year.AddYears(2), India = 25, Germany = 28, England = 32, France = 36 });
            DataPoints.Add(new Model() { Year = year.AddYears(3), India = 26, Germany = 30, England = 34, France = 40 });
            DataPoints.Add(new Model() { Year = year.AddYears(4), India = 27, Germany = 36, England = 41, France = 44 });
            DataPoints.Add(new Model() { Year = year.AddYears(5), India = 32, Germany = 36, England = 42, France = 45 });
            DataPoints.Add(new Model() { Year = year.AddYears(6), India = 35, Germany = 39, England = 42, France = 48 });
            DataPoints.Add(new Model() { Year = year.AddYears(7), India = 30, Germany = 38, England = 43, France = 46 });
        }

        public ObservableCollection<Model> DataPoints
        {
            get;
            set;
        }
    }
}
