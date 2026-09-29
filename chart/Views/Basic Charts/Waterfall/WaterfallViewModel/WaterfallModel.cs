namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a department entry in a waterfall chart.</summary>
    public class WaterfallModel
    {
        /// <summary>Gets or sets the department name.</summary>
        public string Department { get; set; }

        /// <summary>Gets or sets the value contributing to the total.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets a value indicating whether this item is a summary.</summary>
        public bool IsSummary { get; set; }
    }
}
