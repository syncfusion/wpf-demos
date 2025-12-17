namespace syncfusion.chartdemos.wpf
{
    public class StackedGroup100Model
    {

        public string Year { get; set; }

        public double FossilFuels { get; set; }

        public double Nuclear { get; set; }

        public double Renewables { get; set; }

        public StackedGroup100Model(string year,double fossilfuels, double nuclear, double renewables)
        {
            Year = year;
            FossilFuels = fossilfuels;
            Nuclear = nuclear;
            Renewables = renewables;

        }

    }
}
