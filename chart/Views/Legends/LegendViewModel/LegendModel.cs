using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a data item used across legend demonstrations.</summary>
    public class LegendModel
    {
        /// <summary>Gets or sets the category or year label.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the primary numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the value for Apple.</summary>
        public double Apple { get; set; }

        /// <summary>Gets or sets the value for Orange.</summary>
        public double Orange { get; set; }

        /// <summary>Gets or sets the value for Pear.</summary>
        public double Pear { get; set; }

        /// <summary>Gets or sets the value for Others.</summary>
        public double Others { get; set; }

        /// <summary>Gets or sets the month (date) value.</summary>
        public DateTime Months { get; set; }

        /// <summary>Gets or sets the sales value.</summary>
        public double Sales { get; set; }

        /// <summary>Gets or sets the target value.</summary>
        public double Target { get; set; }
    }
}
