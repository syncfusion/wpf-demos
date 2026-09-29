namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single histogram sample with an optional size bucket.</summary>
    public class HistogramChartModel
    {
        /// <summary>Gets or sets the sample value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets an optional size value.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistogramChartModel"/> class.
        /// </summary>
        /// <param name="value">Represents the sample value.</param>
        /// <param name="size">Represents the size value.</param>
        public HistogramChartModel(double value, double size)
        {
            Value = value;
            Size = size;
        }
    }
}
