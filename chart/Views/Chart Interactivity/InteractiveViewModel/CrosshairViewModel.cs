using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class CrosshairViewModel : IDisposable
    {
        public ObservableCollection<CrosshairModel> StockDetails { get; }
        public CrosshairViewModel()
        {
            StockDetails = new ObservableCollection<CrosshairModel>();

            Random rand = new Random();
            double value = 100;
            DateTime dateTime = new DateTime(1900, 1, 1);

            for (int i = 1; i < 1600; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();

                StockDetails.Add(new CrosshairModel() { Date = dateTime.AddMonths(i), StockValue = value });
            }
        }

        public void Dispose()
        {
            if(StockDetails != null)
                StockDetails.Clear();
        }
    }
}
