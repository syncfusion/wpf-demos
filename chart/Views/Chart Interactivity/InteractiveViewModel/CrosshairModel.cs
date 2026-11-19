using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a dated stock value for crosshair interaction.</summary>
    public class CrosshairModel
    {
        /// <summary>Gets or sets the data point date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the stock value at the date.</summary>
        public double StockValue { get; set; }
    }
}
