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

namespace Semi_PieSeries3D
{
    public class DataValues
    {
        public double Utilization { get; set; }

        public double ResponseTime { get; set; }

        public DataValues(double utilization, double responseTime)
        {
            Utilization = utilization;
            ResponseTime = responseTime;
        }
    }
}
