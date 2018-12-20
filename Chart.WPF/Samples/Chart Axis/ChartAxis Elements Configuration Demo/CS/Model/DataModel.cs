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
using System.ComponentModel;

namespace ChartAxisElementsConfigurationDemo
{
        public class DataModel
        {

            private string carbrand;
            public string CarBrand
            {
                get;
                set;
            }

            public DateTime Date
            { get; set; }
           
            public double CarsSold
            {
                get;
                set;
            }

            public double salesamount;
            public double EstimatedCost
            {
                get;
                set;
            }

            public double profitpercentage;
            public double ProfitPercentage
            {
                get;
                set;
            }

            public double averageraise;
            public double AverageRaise
            {
                get;
                set;
            }

            public double investedamount;
            public double InvestedAmount
            {
                get;
                set;
            }
        }
    }
