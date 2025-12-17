namespace syncfusion.chartdemos.wpf
{
    public class StackingBarChartModel
    {
        public string Year { get; set; }
        
        public double iPod { get; set; }

        public double iPhone{ get; set; }
        
        public double iPad{ get; set; }


        public StackingBarChartModel(string year, double ipod, double iphone, double ipad)
        {
            Year = year;
            iPod = ipod;
            iPhone = iphone;
            iPad = ipad;
        }

    }
}
