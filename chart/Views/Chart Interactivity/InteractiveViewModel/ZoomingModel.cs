using System;

namespace syncfusion.chartdemos.wpf
{
    public class ZoomingModel
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public ZoomingModel(DateTime dateTime, double value)
        {
            Date = dateTime;
            Value = value;
        }
    } 
}
