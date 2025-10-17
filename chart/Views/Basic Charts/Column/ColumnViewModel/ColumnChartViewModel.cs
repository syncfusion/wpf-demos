using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class ColumnChartViewModel : IDisposable
    {
        public ObservableCollection<ColumnChartModel> DefaultColumnData { get; }
        public ObservableCollection<ColumnChartModel> RoundedColumnData { get; }
        public ObservableCollection<ColumnChartModel> ColumnWidthData { get; }
      
        public ColumnChartViewModel()
        {
            //Default column
            this.DefaultColumnData = new ObservableCollection<ColumnChartModel>();
            DefaultColumnData.Add(new ColumnChartModel() { Name = "China", Value = 0.541 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Egypt", Value = 0.818 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Bolivia", Value = 1.51 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Mexico", Value = 1.302 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Brazil", Value = 2.017 });

            //Rounded column
            this.RoundedColumnData = new ObservableCollection<ColumnChartModel>();
            RoundedColumnData.Add(new ColumnChartModel() { Name = "New York", Value = 8683 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Tokyo", Value = 6993 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Chicago", Value = 5498 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Atlanta", Value = 5083 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Boston", Value = 4497 });

            //Width and spacing
            this.ColumnWidthData = new ObservableCollection<ColumnChartModel>();
            ColumnWidthData.Add(new ColumnChartModel() { Name = "Norway", Gold = 16, Silver = 8, Bronze = 13 });
            ColumnWidthData.Add(new ColumnChartModel() { Name = "Russia", Gold = 6, Silver = 12, Bronze = 14 });
            ColumnWidthData.Add(new ColumnChartModel() { Name = "Germany", Gold = 12, Silver = 10, Bronze = 5 });
            ColumnWidthData.Add(new ColumnChartModel() { Name = "Canada", Gold = 4, Silver = 8, Bronze = 14 });
        }

        public void Dispose()
        {
            if(DefaultColumnData !=null)
                DefaultColumnData.Clear();

            if(RoundedColumnData !=null)
                RoundedColumnData.Clear();

            if (ColumnWidthData !=null)
                ColumnWidthData.Clear();
        }
    }
}
