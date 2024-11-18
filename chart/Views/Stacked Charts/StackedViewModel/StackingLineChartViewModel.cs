#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class StackingLineChartViewModel
    {
        public ObservableCollection<StackingLineChartModel> StackedLinedData { get; set; }
        public StackingLineChartViewModel()
        {
            this.StackedLinedData = new ObservableCollection<StackingLineChartModel>()
          {
           new StackingLineChartModel() { Year = "2010", UnitedKingdom = 2.4, US = 2.7, Cameroon = 2.9, China = 10.6 },
           new StackingLineChartModel() { Year = "2011", UnitedKingdom = 1.1, US = 1.5, Cameroon = 3.4, China = 9.6 },
           new StackingLineChartModel() { Year = "2012", UnitedKingdom = 1.4, US = 2.3, Cameroon = 4.6, China = 7.9 },
           new StackingLineChartModel() { Year = "2013", UnitedKingdom = 1.8, US = 1.8, Cameroon = 5, China = 7.8 },
           new StackingLineChartModel() { Year = "2014", UnitedKingdom = 3.2, US = 2.3, Cameroon = 5.7, China = 7.4 },
           new StackingLineChartModel() { Year = "2015", UnitedKingdom = 2.4, US = 2.7, Cameroon = 5.7, China = 7 },
          };
        }
    }
}
