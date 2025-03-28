#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    public class ScatterChartModel
    {
       public float Eruptions
       {
           get;
           set;
       }

       public int WaitingTime
       {
           get;
           set;
       }
    }

    public class ScatterModel
    {
        public double Value { get; set; }
        public double Size { get; set; }

        public ScatterModel(double value, double size)
        {
            Value = value;
            Size = size;
        }
    }
}
