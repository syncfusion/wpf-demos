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

namespace BoxAndWhiskerChart
{
    public class BoxAndWhiskerChartViewModel
    {
        public BoxAndWhiskerChartViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<StockPrice>();

            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 1), Open = 28.77, High = 29.05, Low = 28.53, Close = 29.02 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 2), Open = 29.06, High = 29.3, Low = 28.24, Close = 28.46 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 3), Open = 28.52, High = 28.61, Low = 28.35, Close = 28.46 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 4), Open = 28.44, High = 28.65, Low = 28.27, Close = 28.63 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 5), Open = 28.64, High = 28.68, Low = 28.42, Close = 28.58 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 8), Open = 28.77, High = 29.05, Low = 28.53, Close = 29.02 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 9), Open = 29.06, High = 29.3, Low = 28.24, Close = 28.46 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 10), Open = 28.52, High = 28.61, Low = 28.35, Close = 28.46 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 11), Open = 28.44, High = 28.65, Low = 28.27, Close = 28.63 });
            this.StockPriceDetails.Add(new StockPrice() { _Date = new DateTime(2010, 3, 12), Open = 28.64, High = 28.68, Low = 28.42, Close = 28.58 });

            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 6), Open = 28.51 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 7), Open = 28.56 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 8), Open = 28.86 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 9), Open = 28.95 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 10), Open = 29.32 });

            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 11), Open = 29.21 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 12), Open = 28.42 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 13), Open = 28.5 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 14), Open = 29.63 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 15), Open = 28.8 });

            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 16), Open = 29.5 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 17), Open = 29.63 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 18), Open = 29.68 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 19), Open = 29.83 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 20), Open = 30.11 });

            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 29), Open = 29.7 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 30), Open = 29.55 });
            //this.StockPriceDetails.Add(new StockPrice() { Date = new DateTime(2010, 3, 31), Open = 28.65 });
        }

        public ObservableCollection<StockPrice> StockPriceDetails { get; set; }
    }
}
