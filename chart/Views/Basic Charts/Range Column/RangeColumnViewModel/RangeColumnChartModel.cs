namespace syncfusion.chartdemos.wpf
{
    public class RangeColumnChartModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double Size { get; set; }
        public RangeColumnChartModel(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }
    }
}
