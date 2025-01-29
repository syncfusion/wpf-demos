#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    public class CrosshairViewModel
    {
        public ObservableCollection<CrosshairModel> StockDetails { get; }
        public CrosshairViewModel()
        {
            StockDetails = new ObservableCollection<CrosshairModel>();

            Random rand = new Random();
            double value = 100;
            DateTime dateTime = new DateTime(1900, 1, 1);

            for (int i = 1; i < 1600; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();

                StockDetails.Add(new CrosshairModel() { Date = dateTime.AddMonths(i), StockValue = value });
            }
        }
    }
}
