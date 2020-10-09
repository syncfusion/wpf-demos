#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class TrendlineViewModel
    {
        public Array PolynomialOrders
        {
            get
            {
                return new string[] { "2", "3", "4", "5", "6" };
            }
        }

        public Array StrokeDashArrays
        {
            get
            {
                return new string[] { "1,1", "4,4", "4,8", "4,2", "1,0" };
            }
        }

        public TrendlineViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<TrendlineModel>();
            DateTime date = new DateTime(2013, 1, 1);
            Random rd = new Random();
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 26, Date = date.AddDays(1) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 34, Date = date.AddDays(2) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 42, Date = date.AddDays(3) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 29, Date = date.AddDays(4) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 14, Date = date.AddDays(5) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 89, Date = date.AddDays(6) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 45, Date = date.AddDays(7) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 39, Date = date.AddDays(8) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 45, Date = date.AddDays(9) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 88, Date = date.AddDays(10) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 70, Date = date.AddDays(11) });
            this.StockPriceDetails.Add(new TrendlineModel() { Value = 45, Date = date.AddDays(12) });
        }

        public ObservableCollection<TrendlineModel> StockPriceDetails { get; set; }
    }
}
