#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class StackingAreaChartViewModel
    {
        public StackingAreaChartViewModel()
        {

            this.Accidents = new ObservableCollection<StackingAreaChartModel>();
            DateTime mth = new DateTime(2011, 1, 1);

            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(6), Bus = 3, Car = 4, Truck = 5 });
            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(7), Bus = 4, Car = 5, Truck = 6 });
            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(8), Bus = 3, Car = 4, Truck = 5 });
            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(9), Bus = 4, Car = 5, Truck = 6 });
            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(10), Bus = 7, Car = 8, Truck = 7 });
            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(11), Bus = 4, Car = 5, Truck = 6 });
            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(12), Bus = 7, Car = 8, Truck = 7 });
            Accidents.Add(new StackingAreaChartModel() { Month = mth.AddMonths(13), Bus = 4, Car = 5, Truck = 6 });
        }

        public ObservableCollection<StackingAreaChartModel> Accidents
        {
            get;
            set;
        }
    }
}
