using System;

namespace syncfusion.chartdemos.wpf
{
    public class DataValuesColumn
    {
        public String Gadget { get; set; }

        public String Month { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public DataValuesColumn(string gadget, string month, double value1, double value2)
        {
            Gadget = gadget;
            Value1 = value1;
            Value2 = value2;
            Month = month;
        }
    }
}
