#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace ExportChartDemo
{
    public class ViewModel
    {
        public ObservableCollection<DataModel> ClimateData { get; set; }

        public ViewModel()
        {
            ClimateData = new ObservableCollection<DataModel>();
            ClimateData.Add(new DataModel() { Month = "Jan", Temperature = 33 });
            ClimateData.Add(new DataModel() { Month = "Feb", Temperature = 37 });
            ClimateData.Add(new DataModel() { Month = "Mar", Temperature = 39 });
            ClimateData.Add(new DataModel() { Month = "Apr", Temperature = 43 });
            ClimateData.Add(new DataModel() { Month = "May", Temperature = 45 });
            ClimateData.Add(new DataModel() { Month = "Jun", Temperature = 43 });
            ClimateData.Add(new DataModel() { Month = "Jul", Temperature = 41 });
            ClimateData.Add(new DataModel() { Month = "Aug", Temperature = 40 });
            ClimateData.Add(new DataModel() { Month = "Sep", Temperature = 39 });
            ClimateData.Add(new DataModel() { Month = "Oct", Temperature = 39 });
            ClimateData.Add(new DataModel() { Month = "Nov", Temperature = 34 });
            ClimateData.Add(new DataModel() { Month = "Dec", Temperature = 33 });
        }
    }
}
