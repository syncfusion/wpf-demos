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
