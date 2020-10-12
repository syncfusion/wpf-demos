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
    public class RealTimeChartModel
    {
        public RealTimeChartModel(DateTime date, double value, double value1, double value2)
        {
            Date = date;
            Value = value;
            Value1 = value1;
            Value2 = value2;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
        public double Value1
        {
            get;
            set;
        }
        public double Value2
        {
            get;
            set;
        }
    }
}
