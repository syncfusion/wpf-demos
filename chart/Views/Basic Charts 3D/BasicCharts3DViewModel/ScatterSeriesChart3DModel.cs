using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class ScatterSeriesChart3DModel : NotificationObject
    {
        public int Count { get; set; }
        public double Value { get; set; }

        public ScatterSeriesChart3DModel(int count, double value)
        {
            Count = count;
            Value = value;
        }
    }
}
