using System;

namespace syncfusion.chartdemos.wpf
{
    public class CandleChartModel
    {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Value { get; set; }
        public double Size { get; set; }

        public CandleChartModel(DateTime date, double high, double low, double open, double close)
        {
            Date = date;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
    }
}
