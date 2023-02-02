#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class DataValuesColumn1
    {
        public String Gadget { get; set; }

        public String Month { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public DataValuesColumn1(string gadget, string month, double value1, double value2)
        {
            Gadget = gadget;
            Value1 = value1;
            Value2 = value2;
            Month = month;
        }
    }
}
