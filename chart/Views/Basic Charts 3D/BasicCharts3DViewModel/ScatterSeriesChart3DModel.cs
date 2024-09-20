#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class ScatterSeriesChart3DModel : NotificationObject
    {
        public int Count { get; set; }
        public double Value { get; set; }

        public ScatterSeriesChart3DModel(int count, double value)
        {
            Count = count;
            Value = value;
        }
    }
}
