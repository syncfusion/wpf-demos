namespace syncfusion.chartdemos.wpf
{
    public class BubbleChartModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Size { get; set; }

        public BubbleChartModel(string name, double value, double high, double low)
        {
            Name = name;
            Value = value;
            High = high;
            Low = low;
        }

        public BubbleChartModel(string name, double high, double low, double open, double close)
        {
            Name = name;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
    }
}
