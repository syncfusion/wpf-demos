#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace ThreeLineBreak
{
    public class ThreeLineBreakChartViewModel
    {
        public ThreeLineBreakChartViewModel()
        {
            this.SharePriceDetails = new ObservableCollection<SharePrice>();
            double[] priceValues = {   25.250,27.750,29.000,28.275,27.750,27.750,27.275,26.250,25.750,25.250,26.250,25.250,24.500,
										  25.625,25.500,26.625,26.275,26.250,26.875,27.250,26.875,26.500,27.125,26.275,25.875,26.625,
										  27.125,26.250,27.000,27.250,27.500,28.500,29.500,28.875,28.500,29.000,28.500,28.500,29.000,
										  29.000,40.000,29.875,29.875,28.875,28.500,28.250,28.875,29.275,29.275,29.750,29.500,29.275,
										  28.500,27.750,27.625,27.500,26.500,25.000,26.625,26.000,25.875,25.000,25.250,25.125,25.050};
            DateTime date = new DateTime(2011,6,1);
            for(int i = 0; i < priceValues.Count(); i++)
            {
                this.SharePriceDetails.Add(new SharePrice(){_Date = date.AddDays(i), Close=priceValues[i], High = 0, Low = 0, Open = 0});
            }
        }

        public ObservableCollection<SharePrice> SharePriceDetails {get; set; }
    }
}
