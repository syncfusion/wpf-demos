namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a bubble chart data item with size and value fields.</summary>
    public class BubbleChartModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the main numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the high value.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low value.</summary>
        public double Low { get; set; }

        /// <summary>Gets or sets the bubble size.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BubbleChartModel"/> class with name, value, high, and low.
        /// </summary>
        public BubbleChartModel(string name, double value, double high, double low)
        {
            Name = name;
            Value = value;
            High = high;
            Low = low;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BubbleChartModel"/> class with name, high, low, open, and close values.
        /// </summary>
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
