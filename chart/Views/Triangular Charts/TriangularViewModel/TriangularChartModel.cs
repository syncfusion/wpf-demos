using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single data item used in pyramid and funnel charts.</summary>
    public class TriangularChartModel
    {
        /// <summary>Gets or sets the category label.</summary>
        public string Category { get; set; }

        /// <summary>Gets or sets the percentage value for the item.</summary>
        public double Percentage { get; set; }

        /// <summary>Gets or sets an optional numeric value associated with the item.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets a formatted percentage text (for display).</summary>
        public string PercentageValue { get; set; }
    }
}
