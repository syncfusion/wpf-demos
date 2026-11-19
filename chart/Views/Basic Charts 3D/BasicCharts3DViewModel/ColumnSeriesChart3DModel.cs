using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents data for 3D column charts with optional series values.</summary>
    public class ColumnSeriesChart3DModel : NotificationObject
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the primary value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the value for Sudan.</summary>
        public double Sudan { get; set; }

        /// <summary>Gets or sets the value for Togo.</summary>
        public double Togo { get; set; }
    }
}
