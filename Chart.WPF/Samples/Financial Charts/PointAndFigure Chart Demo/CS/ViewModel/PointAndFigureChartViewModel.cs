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

namespace PointAndFigureChart
{
    public class PointAndFigureChartViewModel
    {
        public PointAndFigureChartViewModel()
        {
            this.SharePriceDetails = new ObservableCollection<SharePrice>();
            double[] highValues = {   45.825,45.475,4.575,45.615,0,45.615,45.615,45.376,45.375,45.655,45.666,0,45.615,45.615,45.435,
                                      45.435,45.325,45.236,0,45.115,45.138,45.175,45.175,45.425,45.425,0,45.275,45.275,
									  45.127,44.855,44.875,44.91,0,44.91,44.995,45.035,44.925,45.125,45.245,0,45.245,45.245,45.175,
									  45.18,45.075,45.12,0,45.005,45.075,44.965,44.901,44.816,44.7,0,0,44.725,44.751,44.75,44.751};

            double[] lowValues = {  45.425,45.425,4.475,45.53,0,45.615,45.325,45.175,45.175,45.375,45.565,0,45.615,45.375,45.375,
                                    45.325,45.23,45.075,0,45.115,45.925,45.925,45.075,45.075,45.275,0,45.275,45.125,
									44.855,44.825,44.825,44.845,0,44.91,44.91,44.925,44.895,44.895,45.075,0,45.245,44.975,44.975,
									45.045,45.045,44.975,0,45.005,44.93,44.875,44.775,44.625,44.575,0,0,44.7,44.675,44.625,44.475};
            DateTime date = new DateTime(2000, 1, 1);
            for (int i = 0; i < highValues.Count(); i++)
            {
                this.SharePriceDetails.Add(new SharePrice() { _Date = date.AddDays(i), High = highValues[i], Low = lowValues[i] });
            }
        }

        public ObservableCollection<SharePrice> SharePriceDetails { get; set; }
    }
}
