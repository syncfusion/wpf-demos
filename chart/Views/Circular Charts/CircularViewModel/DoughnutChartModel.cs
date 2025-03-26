#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    public class DoughnutChartModel
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public Uri Image { get; set; }

        public string PathData { get; set; }

        public DoughnutChartModel(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public DoughnutChartModel(string name, double value, string path)
        {
            Name = name;
            Value = value;
            PathData = path;
        }

        public DoughnutChartModel(string name, double value, Uri image)
        {
            Name = name;
            Value = value;
            Image = image;
        }
    }
}
