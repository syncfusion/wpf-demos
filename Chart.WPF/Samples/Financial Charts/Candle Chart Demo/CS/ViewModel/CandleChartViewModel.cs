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

namespace CandleChart
{
    public class CandleChartViewModel
    {
        public CandleChartViewModel()
        {
            this.ForeignExchangeDetails = new ObservableCollection<ForeignExchange>();

            DateTime date = new DateTime(2012, 5, 1);
            this.ForeignExchangeDetails.Add(new ForeignExchange() { _Date = date.AddDays(0), FXSymbol = "USDINR", Open = 52.66, High = 52.83, Low = 52.41, Close = 52.56 });
            this.ForeignExchangeDetails.Add(new ForeignExchange() { _Date = date.AddDays(1), FXSymbol = "USDINR", Open = 52.56, High = 53.12, Low = 52.38, Close = 52.96 });
            this.ForeignExchangeDetails.Add(new ForeignExchange() { _Date = date.AddDays(2), FXSymbol = "USDINR", Open = 52.96, High = 53.64, Low = 52.81, Close = 53.41 });
            this.ForeignExchangeDetails.Add(new ForeignExchange() { _Date = date.AddDays(3), FXSymbol = "USDINR", Open = 53.41, High = 53.92, Low = 53.22, Close = 53.59 });
            this.ForeignExchangeDetails.Add(new ForeignExchange() { _Date = date.AddDays(5), FXSymbol = "USDINR", Open = 53.49, High = 53.73, Low = 52.73, Close = 52.91 });
            this.ForeignExchangeDetails.Add(new ForeignExchange() { _Date = date.AddDays(6), FXSymbol = "USDINR", Open = 52.91, High = 53.32, Low = 52.67, Close = 53.12 });
            this.ForeignExchangeDetails.Add(new ForeignExchange() { _Date = date.AddDays(6), FXSymbol = "USDINR", Open = 53.22, High = 53.98, Low = 53.01, Close = 53.82 });

        }

        public ObservableCollection<ForeignExchange> ForeignExchangeDetails { get; set; }
    }
}
