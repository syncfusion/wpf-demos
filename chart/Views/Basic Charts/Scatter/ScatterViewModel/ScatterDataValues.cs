using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a dated scatter data item with a count and variation.</summary>
    public class ScatterDataValues
    {
        /// <summary>Gets or sets the year of the data point.</summary>
        public DateTime Year { get; set; }

        /// <summary>Gets or sets the count value.</summary>
        public double Count { get; set; }

        /// <summary>Gets or sets the variation value.</summary>
        public double Variation { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterDataValues"/> class.
        /// </summary>
        /// <param name="year">Represents the year.</param>
        /// <param name="count">Represents the count.</param>
        /// <param name="variation">Represents the variation.</param>
        public ScatterDataValues(DateTime year, double count, double variation)
        {
            Year = year;
            Count = count;
            Variation = variation;
        }
    }
}
