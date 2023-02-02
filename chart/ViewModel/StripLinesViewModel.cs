#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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
    public class StripLinesViewModel
    {
        public ObservableCollection<StripLinesModel> ClimateData { get; set; }
        public StripLinesViewModel()
        {
            ClimateData = new ObservableCollection<StripLinesModel>();
            ClimateData.Add(new StripLinesModel() { Month = "Jan", Temperature = 33 });
            ClimateData.Add(new StripLinesModel() { Month = "Feb", Temperature = 37 });
            ClimateData.Add(new StripLinesModel() { Month = "Mar", Temperature = 39 });
            ClimateData.Add(new StripLinesModel() { Month = "Apr", Temperature = 43 });
            ClimateData.Add(new StripLinesModel() { Month = "May", Temperature = 45 });
            ClimateData.Add(new StripLinesModel() { Month = "Jun", Temperature = 43 });
            ClimateData.Add(new StripLinesModel() { Month = "Jul", Temperature = 41 });
            ClimateData.Add(new StripLinesModel() { Month = "Aug", Temperature = 40 });
            ClimateData.Add(new StripLinesModel() { Month = "Sep", Temperature = 39 });
            ClimateData.Add(new StripLinesModel() { Month = "Oct", Temperature = 39 });
            ClimateData.Add(new StripLinesModel() { Month = "Nov", Temperature = 34 });
            ClimateData.Add(new StripLinesModel() { Month = "Dec", Temperature = 33 });
        }
    }
}
