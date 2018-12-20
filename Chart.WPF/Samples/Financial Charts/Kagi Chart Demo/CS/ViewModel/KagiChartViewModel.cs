#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace KagiChart
{
    public class KagiChartViewModel
    {
        public KagiChartViewModel()
        {
            this.GoldPriceDetails = new ObservableCollection<Gold>();
            DateTime date = new DateTime(2011, 3, 30);

            this.GoldPriceDetails.Add(new Gold() { Month = date, Price = 1439 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(1), Price = 1535.5 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(2), Price = 1536.5 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(3), Price = 1505.5 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(4), Price = 1628.5 });

            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(5), Price = 1813.5 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(6), Price = 1620 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(7), Price = 1722 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(8), Price = 1746 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(9), Price = 1531 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(10), Price = 1744 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(11), Price = 1770 });
            this.GoldPriceDetails.Add(new Gold() { Month = date.AddMonths(12), Price = 1662.5 });

           
        }

        public ObservableCollection<Gold> GoldPriceDetails { get; set; }
    }
}
