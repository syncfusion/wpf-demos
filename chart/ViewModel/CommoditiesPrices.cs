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
    public class CommoditiesPrices
    {
        public CommoditiesPrices()
        {
            CommodityDetails = new ObservableCollection<Commodities>();
            CommodityDetails.Add(new Commodities() { Date = "Jan", YValue1 = 15, YValue2 = 39, YValue3 = 60 });
            CommodityDetails.Add(new Commodities() { Date = "Feb", YValue1 = 20, YValue2 = 30, YValue3 = 55 });
            CommodityDetails.Add(new Commodities() { Date = "Mar", YValue1 = 24, YValue2 = 38, YValue3 = 48 });
            CommodityDetails.Add(new Commodities() { Date = "Apr", YValue1 = 21, YValue2 = 35, YValue3 = 57 });
            CommodityDetails.Add(new Commodities() { Date = "May", YValue1 = 15, YValue2 = 39, YValue3 = 60 });
            CommodityDetails.Add(new Commodities() { Date = "Jun", YValue1 = 13, YValue2 = 41, YValue3 = 64 });
            CommodityDetails.Add(new Commodities() { Date = "Jul", YValue1 = 18, YValue2 = 41, YValue3 = 64 });
            CommodityDetails.Add(new Commodities() { Date = "Aug", YValue1 = 24, YValue2 = 42, YValue3 = 57 });
            CommodityDetails.Add(new Commodities() { Date = "Sep", YValue1 = 19, YValue2 = 54, YValue3 = 63 });
            CommodityDetails.Add(new Commodities() { Date = "Oct", YValue1 = 31, YValue2 = 40, YValue3 = 50 });
            CommodityDetails.Add(new Commodities() { Date = "Nov", YValue1 = 39, YValue2 = 50, YValue3 = 66 });
            CommodityDetails.Add(new Commodities() { Date = "Dec", YValue1 = 50, YValue2 = 60, YValue3 = 70 });

        }

        public ObservableCollection<Commodities> CommodityDetails { get; set; }
    }
}
