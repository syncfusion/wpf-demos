#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class EnergyProduction
    {
        public double ID { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Year { get; set; }

        public double Nuclear { get; set; }

        public double Coal
        {
            get; set;
        }

        public double Oil { get; set; }

        public double Gas
        {
            get; set;
        }

        public double HorizontalErrorValue { get; set; }

        public double VerticalErrorValue { get; set; }
    }
}
