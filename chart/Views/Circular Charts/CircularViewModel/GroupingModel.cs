namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a category with value and size for grouping in circular charts.</summary>
    public class GroupingModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the size.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingModel"/> class.
        /// </summary>
        /// <param name="name">Represents the category name.</param>
        /// <param name="value">Represents the value.</param>
        /// <param name="size">Represents the value of size.</param>
        public GroupingModel(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }
    }
}
