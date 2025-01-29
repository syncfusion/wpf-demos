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
            double value = 1000;

            for (int i = 0; i < 100; i++)
            {
                if (rd.NextDouble() > .5)
                {
                    value += rd.NextDouble();
                    this.StockPriceDetails.Add(new TrendlineModel() { Value = value, Date = date.AddDays(i) });
                }
                else
                {
                    value -= rd.NextDouble();
                    this.StockPriceDetails.Add(new TrendlineModel() { Value = value, Date = date.AddDays(i) });
                }
            }
        }

        public ObservableCollection<TrendlineModel> StockPriceDetails { get; set; }
    }
}
