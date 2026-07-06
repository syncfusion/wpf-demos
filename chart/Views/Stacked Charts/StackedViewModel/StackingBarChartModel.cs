namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents yearly device sales for stacked bar series.</summary>
    public class StackingBarChartModel
    {
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the iPod sales value.</summary>
        public double iPod { get; set; }

        /// <summary>Gets or sets the iPhone sales value.</summary>
        public double iPhone { get; set; }

        /// <summary>Gets or sets the iPad sales value.</summary>
        public double iPad { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackingBarChartModel"/> class.
        /// </summary>
        public StackingBarChartModel(string year, double ipod, double iphone, double ipad)
        {
            Year = year;
            iPod = ipod;
            iPhone = iphone;
            iPad = ipad;
        }

    }
}
