using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides data for zooming interaction demos.</summary>
    public class ZoomingViewModel : IDisposable
    {
        /// <summary>Collection of data points used for zooming demonstrations.</summary>
        public ObservableCollection<ZoomingModel> ZoomData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomingViewModel"/> class.
        /// </summary>
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

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(ZoomData != null)
                ZoomData.Clear();
        }
    }
}
