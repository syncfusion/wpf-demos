using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a 3D scatter data point.</summary>
    public class ScatterSeriesChart3DModel : NotificationObject
    {
        /// <summary>Gets or sets the count.</summary>
        public int Count { get; set; }

        /// <summary>Gets or sets the value.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterSeriesChart3DModel"/> class.
        /// </summary>
        /// <param name="count">Represents the count.</param>
        /// <param name="value">Represents the value.</param>
        public ScatterSeriesChart3DModel(int count, double value)
        {
            Count = count;
            Value = value;
        }
    }
}
