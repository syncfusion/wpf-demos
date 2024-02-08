#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class StackingBarChartModel
    {
        public string Year { get; set; }
        
        public double iPod { get; set; }

        public double iPhone{ get; set; }
        
        public double iPad{ get; set; }


        public StackingBarChartModel(string year, double ipod, double iphone, double ipad)
        {
            Year = year;
            iPod = ipod;
            iPhone = iphone;
            iPad = ipad;
        }

    }
}
