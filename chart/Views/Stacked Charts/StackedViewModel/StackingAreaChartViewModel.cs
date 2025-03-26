#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class StackingAreaChartViewModel : IDisposable
    {
        public StackingAreaChartViewModel()
        {

            this.SalesRate = new ObservableCollection<StackingAreaChartModel>();

            SalesRate.Add(new StackingAreaChartModel() { Year = "2014", Chocolate = 7053, SugerConfectionery = 1148, Biscuits = 1568 });
            SalesRate.Add(new StackingAreaChartModel() { Year = "2015", Chocolate = 6365, SugerConfectionery = 1130, Biscuits = 1375 });
            SalesRate.Add(new StackingAreaChartModel() { Year = "2016", Chocolate = 6267, SugerConfectionery = 1111, Biscuits = 1301 });
            SalesRate.Add(new StackingAreaChartModel() { Year = "2017", Chocolate = 6362, SugerConfectionery = 1098, Biscuits = 1339 });
            SalesRate.Add(new StackingAreaChartModel() { Year = "2018", Chocolate = 6031, SugerConfectionery = 812,  Biscuits = 1280 });
            SalesRate.Add(new StackingAreaChartModel() { Year = "2019", Chocolate = 5930, SugerConfectionery = 722,  Biscuits = 1236 });
            SalesRate.Add(new StackingAreaChartModel() { Year = "2020", Chocolate = 5265, SugerConfectionery = 585,  Biscuits = 1125 });
            SalesRate.Add(new StackingAreaChartModel() { Year = "2021", Chocolate = 5716, SugerConfectionery = 651,  Biscuits = 1147 });
        }

        public ObservableCollection<StackingAreaChartModel> SalesRate
        {
            get;
            set;
        }

        public void Dispose()
        {
            if(SalesRate != null)
                SalesRate.Clear();
        }
    }
}
