#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    public class HistogramChartModel
    {
        public double Value { get; set; }
        public double Size { get; set; }

        public HistogramChartModel(double value, double size)
        {
            Value = value;
            Size = size;
        }
    }
}
