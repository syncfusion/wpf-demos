namespace syncfusion.chartdemos.wpf
{
    public class HistogramChartModel
    {
        public double Value { get; set; }
        public double Size { get; set; }

        public HistogramChartModel(double value, double size)
        {
            Value = value;
            Size = size;
        }
    }
}
