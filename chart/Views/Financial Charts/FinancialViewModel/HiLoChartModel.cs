using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a high/low data point for HiLo charts.</summary>
    public class HiLoChartModel
    {
        /// <summary>Gets or sets the date of the record.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the high value.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low value.</summary>
        public double Low { get; set; }
    }
}
