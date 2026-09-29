using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a timestamped visitor count record.</summary>
    public class AIModel
    {
        /// <summary>Gets or sets the observation timestamp.</summary>
        public DateTime DateTime { get; set; }

        /// <summary>Gets or sets the number of visitors.</summary>
        public double Visitors { get; set; }
    }
}
