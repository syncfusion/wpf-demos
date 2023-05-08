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
    public class CurrencyDataViewModel
    {
        public CurrencyDataViewModel()
        {
            CurrencyDetails = new ObservableCollection<CurenncyDetailModel>();

            Random rand = new Random();
            double value = 100;
            DateTime dateTime = new DateTime(1895, 1, 1);

            for (int i = 1; i < 600; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();

                CurrencyDetails.Add(new CurenncyDetailModel() { Date = dateTime.AddMonths(i), CurrencyValue = value });
            }

        }

        public ObservableCollection<CurenncyDetailModel> CurrencyDetails { get; set; }

    }
}
