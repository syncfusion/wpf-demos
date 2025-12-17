namespace syncfusion.chartdemos.wpf
{
    public class GroupingModel
    {
        public string Name { get; set; }

        public double Value { get; set; }
        public double Size { get; set; }

        public GroupingModel(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }
    }
}
