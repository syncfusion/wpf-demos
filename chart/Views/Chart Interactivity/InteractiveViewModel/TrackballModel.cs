using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a sales data point for multiple persons on a specific date.</summary>
    public class TrackballModel
    {
        /// <summary>Gets or sets the date of the data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the value for Person 1.</summary>
        public double Person1 { get; set; }

        /// <summary>Gets or sets the value for Person 2.</summary>
        public double Person2 { get; set; }

        /// <summary>Gets or sets the value for Person 3.</summary>
        public double Person3 { get; set; }
    }
}
