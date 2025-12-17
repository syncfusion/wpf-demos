using System;

namespace syncfusion.chartdemos.wpf
{
    public class ScatterDataValues
    {
        public DateTime Year { get; set; }

        public double Count { get; set; }

        public double Variation { get; set; }

        public ScatterDataValues(DateTime year, double count, double variation)
        {
            Year = year;
            Count = count;
            Variation = variation;
        }
    }
}
