using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents data for 3D bar charts with optional per-country values.</summary>
    public class BarChart3DModel : NotificationObject
    {
        /// <summary>Gets or sets the energy or category name.</summary>
        public string Energy { get; set; }

        /// <summary>Gets or sets the primary numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the value for Brazil.</summary>
        public double Brazil { get; set; }

        /// <summary>Gets or sets the value for Bolivia.</summary>
        public double Bolivia { get; set; }
    }
}

