using System;

namespace syncfusion.chartdemos.wpf
{
    public class DataValuesSpline
    {
        public DateTime Month { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public double Value3 { get; set; }

        public DataValuesSpline(DateTime month, double value1, double value2, double value3)
        {
            Month = month;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
    }
}
