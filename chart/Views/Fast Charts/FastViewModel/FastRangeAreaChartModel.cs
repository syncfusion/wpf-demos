using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a date with high/low temperatures for range area charts.</summary>
    public class FastRangeAreaChartModel
    {
        /// <summary>Gets or sets the date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the low temperature.</summary>
        public double LowTemperature { get; set; }

        /// <summary>Gets or sets the high temperature.</summary>
        public double HighTemperature { get; set; }
    }
}
