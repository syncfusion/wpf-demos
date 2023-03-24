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
    public class CandleChartViewModel
    {
        public CandleChartViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<CandleChartModel>();
            DateTime date = new DateTime(2012, 4, 1);

            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(0), Open = 873.8, High = 878.85, Low = 855.5, Close = 860.5 });
            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(1), Open = 873.8, High = 878.85, Low = 855.5, Close = 860.5 });
            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(2), Open = 861, High = 868.4, Low = 835.2, Close = 843.45 });
            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(3), Open = 846.15, High = 853, Low = 838.5, Close = 847.5 });
            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(4), Open = 846, High = 860.75, Low = 841, Close = 855 });
            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(5), Open = 841, High = 845, Low = 827.85, Close = 838.65 });
            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(6), Open = 846, High = 874.5, Low = 841, Close = 860.75 });
            this.StockPriceDetails.Add(new CandleChartModel() { Date = date.AddDays(7), Open = 865, High = 872, Low = 865, Close = 868.9 });
        }
        public ObservableCollection<CandleChartModel> StockPriceDetails { get; set; }
    }
}
