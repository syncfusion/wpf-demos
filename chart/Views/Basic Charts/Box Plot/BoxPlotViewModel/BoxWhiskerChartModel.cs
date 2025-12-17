#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;

namespace syncfusion.chartdemos.wpf
{
    public class BoxWhiskerChartModel
    {
        public string Levels { get; set; }

        public List<double> Energy { get; set; }

        public BoxWhiskerChartModel(string department, List<double> employeeAges)
        {
            Levels = department;
            Energy = employeeAges;
        }
    }
}
