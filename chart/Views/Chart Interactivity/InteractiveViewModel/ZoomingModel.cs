using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single data point for zooming charts.</summary>
    public class ZoomingModel
    {
        /// <summary>Gets or sets the date associated with the data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the numeric value for the data point.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomingModel"/> class.
        /// </summary>
        /// <param name="dateTime">Represents the date.</param>
        /// <param name="value">Represents the value.</param>
        public ZoomingModel(DateTime dateTime, double value)
        {
            Date = dateTime;
            Value = value;
        }
    } 
}
