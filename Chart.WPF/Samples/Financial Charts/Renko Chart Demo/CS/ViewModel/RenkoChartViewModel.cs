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

namespace RenkoChart
{
    public class RenkoChartViewModel
    {
        public RenkoChartViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<StockPrice>();

            double[] points5 = {   28.77,29.06,28.52,28.44,28.64,28.51,28.56,28.86,28.95,29.32,29.21,28.42,28.5,
                                          29.63,28.8,29.5,29.63,29.68,29.83,30.11,29.7,29.55,28.65,28.77,29.06,28.52,28.44,28.64,28.51,28.56,28.86,28.95,29.32,29.21,28.42,28.5,
                                          29.63,28.8,29.5,29.63,29.68,29.83,30.11,29.7,29.55,28.65};

            DateTime date5 = new DateTime(2010, 3, 1);

            for (int day = 0; day < points5.Length; day++)
            {
                StockPriceDetails.Add(new StockPrice() { _Date = date5.AddDays(day), Price = points5[day] });
            }
           
        }

        public ObservableCollection<StockPrice> StockPriceDetails { get; set; }
    }
}
