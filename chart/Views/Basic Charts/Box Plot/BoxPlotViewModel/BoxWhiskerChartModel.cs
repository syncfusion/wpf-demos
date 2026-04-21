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
    /// <summary>Represents a box-and-whisker group with its sample values.</summary>
    public class BoxWhiskerChartModel
    {
        /// <summary>Gets or sets the group label.</summary>
        public string Levels { get; set; }

        /// <summary>Gets or sets the collection of numeric samples.</summary>
        public List<double> Energy { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxWhiskerChartModel"/> class.
        /// </summary>
        public BoxWhiskerChartModel(string department, List<double> employeeAges)
        {
            Levels = department;
            Energy = employeeAges;
        }
    }
}
