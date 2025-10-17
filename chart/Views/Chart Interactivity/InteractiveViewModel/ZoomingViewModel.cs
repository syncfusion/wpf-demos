using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class ZoomingViewModel : IDisposable
    {
        public ObservableCollection<ZoomingModel> ZoomData { get; set; }
        public ZoomingViewModel()
        {
            DateTime date = new DateTime(1950, 3, 01);
            Random r = new Random();
            ZoomData = new ObservableCollection<ZoomingModel>();
            for (int i = 0; i < 20; i++)
            {
                ZoomData.Add(new ZoomingModel(date, r.Next(45, 75)));
                date = date.AddDays(5);
            }
        }

        public void Dispose()
        {
            if(ZoomData != null)
                ZoomData.Clear();
        }
    }
}
