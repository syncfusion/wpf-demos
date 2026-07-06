using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single data point used for interactive annotations.</summary>
    public class AnnotationInteractionModel
    {
        /// <summary>Gets or sets the year associated with the data point.</summary>
        public DateTime Year { get; set; }

        /// <summary>Gets or sets the population for the given year.</summary>
        public double Population { get; set; }
    }
}
