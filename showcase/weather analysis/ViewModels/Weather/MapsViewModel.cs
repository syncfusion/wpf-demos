#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;

namespace syncfusion.weatheranalysis.wpf
{
    public class MapsViewModel : NotificationObject
    {
        public MapsViewModel()
        {  
            LocationDataCollection = new ObservableCollection<LocationModel>();
            RefreshData(DateTime.Now);
            EventManager.Instance.Subscribe<ForecastChangedEvent, ForecastChangedEventArgs>(OnForecastDateChanged);
            EventManager.Instance.Subscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(FormatChanged);
        }
        
        private void FormatChanged(TempFormatChangedEventArgs args)
        {
            IsCelsius = args.Payload.Contains("C");
        }

        private bool isCelsius = false;

        public bool IsCelsius
        {
            get { return isCelsius; }
            set { isCelsius = value; RaisePropertyChanged(nameof(IsCelsius)); }
        }
        private void RefreshData(DateTime dateTime)
        {
            LocationDataCollection = DataStore.GetLocationDataForDate(dateTime);
        }

        private void OnForecastDateChanged(ForecastChangedEventArgs args)
        {
            if (args.Payload != null)
                RefreshData(args.Payload.Date);
        }

        private ObservableCollection<LocationModel> locationCollection;

        public ObservableCollection<LocationModel> LocationDataCollection
        {
            get { return locationCollection; }
            set { locationCollection = value; RaisePropertyChanged(nameof(LocationDataCollection)); }
        }

        public void Dispose()
        {
            EventManager.Instance.Unsubscribe<ForecastChangedEvent, ForecastChangedEventArgs>(OnForecastDateChanged);
            EventManager.Instance.Unsubscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(FormatChanged);
            if (LocationDataCollection != null)
            {
                LocationDataCollection.Clear();
                LocationDataCollection = null;
            }
        }
    }
}
