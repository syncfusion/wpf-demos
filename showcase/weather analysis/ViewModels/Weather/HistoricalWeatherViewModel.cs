#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace syncfusion.weatheranalysis.wpf
{
    public class HistoricalWeatherViewModel : NotificationObject
    {
        private ObservableCollection<HistoricalWeatherInfoModel> historicalWeatherData;

        public ObservableCollection<HistoricalWeatherInfoModel> HistoricalWeatherData
        {
            get { return historicalWeatherData; }
            set { historicalWeatherData = value; RaisePropertyChanged(nameof(HistoricalWeatherData)); }
        }

        public HistoricalWeatherViewModel()
        {
            var data = DataStore.GetHistoricalData();
            HistoricalWeatherData = new ObservableCollection<HistoricalWeatherInfoModel>(data);
            EventManager.Instance.Subscribe<CityChangedEvent, CityChangedEventArgs>(OnCityChanged);
        }

        private void OnCityChanged(CityChangedEventArgs args)
        {
            var data = DataStore.GetHistoricalData();
            HistoricalWeatherData = new ObservableCollection<HistoricalWeatherInfoModel>(data);
        }

        public void Dispose()
        {
            EventManager.Instance.Unsubscribe<CityChangedEvent, CityChangedEventArgs>(OnCityChanged);
            if (HistoricalWeatherData != null)
            {
                HistoricalWeatherData.Clear();
                HistoricalWeatherData = null;
            }
        }
    }
}
