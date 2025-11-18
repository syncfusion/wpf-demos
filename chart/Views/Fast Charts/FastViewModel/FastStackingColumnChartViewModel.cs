using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class FastStackingColumnChartViewModel : IDisposable
    {
        public FastStackingColumnChartViewModel()
        {
            this.MedalDetails = new ObservableCollection<FastStackingColumnChartMedal>();
            Random rd = new Random();

            for (int i = 0; i < 60; i++)
            {
                MedalDetails.Add(new FastStackingColumnChartMedal()
                {
                    CountryName = i,
                    GoldMedals = rd.Next(0, 30),
                    SilverMedals = rd.Next(30, 40),
                    BronzeMedals = rd.Next(20, 30)
                });
            }
        }

        public ObservableCollection<FastStackingColumnChartMedal> MedalDetails { get; set; }

        public void Dispose()
        {
            if (MedalDetails != null)
                MedalDetails.Clear();
        }
    }    
}
