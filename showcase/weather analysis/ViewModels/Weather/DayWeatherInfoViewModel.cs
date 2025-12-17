using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace syncfusion.weatheranalysis.wpf
{
    public class DayWeatherInfoViewModel : NotificationObject
    {
        public DayWeatherInfoViewModel()
        {
            RefreshData();
            EventManager.Instance.Subscribe<DataChangedEvent, EventArgs>(RefreshData);
            EventManager.Instance.Subscribe<ForecastChangedEvent, ForecastChangedEventArgs>(OnForecastDateChanged);
            EventManager.Instance.Subscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(FormatChanged);
        }

        private void FormatChanged(TempFormatChangedEventArgs args)
        {
            IsCelsius = args.Payload.Contains("C");
        }

        private void RefreshData(EventArgs obj = null)
        {
            var datamodel = DataStore.GetSelectedTileWeather(selectedDateTime);
            City = datamodel.City;
            Weather = datamodel.Weather;
            Temperature = datamodel.Temperature;
            TemperatureDay = datamodel.TemperatureDay;
            TemperatureNight = datamodel.TemperatureNight;
            WindSpeed = datamodel.WindSpeed;
            Feelslike = datamodel.Feelslike;
            Humidity = datamodel.Humidity;
            SunRiseTime = datamodel.SunRiseTime;
            SunSetTime = datamodel.SunSetTime;
            MoonRiseTime = datamodel.MoonRiseTime;
            MoonSetTime = datamodel.MoonSetTime;
            UVIndex = datamodel.UVIndex;
            MaxTemperature = datamodel.MaxTemperature;
            MinTemperature = datamodel.MinTemperature;
            MoonPhase = datamodel.MoonPhase;
            Dew = datamodel.Dew;
            Precipitation = datamodel.Precipitation;
            MaxWind = datamodel.MaxWind;
            Interval = Math.Round((MaxTemperature - MinTemperature) / 2, 2);
            MinYValue = (int)MinTemperature - 1;
            MaxYValue = (int)MaxTemperature + 1;
            TimeSpanForSunrise = (SunSetTime - SunRiseTime).Hours;
            TimeSpanForMoonrise = (MoonSetTime - MoonRiseTime).Hours;
            HourlyWeatherData = new ObservableCollection<HourlyWeatherInfoModel>(datamodel.HourlyWeatherData);
            WeatherCollection = datamodel.WeatherCollection;
        }

        public void Dispose()
        {
            EventManager.Instance.Unsubscribe<DataChangedEvent, EventArgs>(RefreshData);
            EventManager.Instance.Unsubscribe<ForecastChangedEvent, ForecastChangedEventArgs>(OnForecastDateChanged);
            EventManager.Instance.Unsubscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(FormatChanged);
            if (HourlyWeatherData != null)
            {
                HourlyWeatherData.Clear();
                HourlyWeatherData = null;
            }
            if (WeatherCollection != null)
            {
                WeatherCollection.Clear();
                WeatherCollection = null;
            }
        }

        private int timeSpanForSunrise;

        public int TimeSpanForSunrise
        {
            get { return timeSpanForSunrise; }
            set { timeSpanForSunrise = value; RaisePropertyChanged(nameof(TimeSpanForSunrise)); }
        }

        private int timeSpanForMoonrise;

        public int TimeSpanForMoonrise
        {
            get { return timeSpanForMoonrise; }
            set { timeSpanForMoonrise = value; RaisePropertyChanged(nameof(TimeSpanForMoonrise)); }
        }

        private bool isCelsius = false;

        public bool IsCelsius
        {
            get { return isCelsius; }
            set { isCelsius = value; RaisePropertyChanged(nameof(IsCelsius)); }
        }

        private double interval;

        public double Interval
        {
            get { return interval; }
            set { interval = value; RaisePropertyChanged(nameof(Interval)); }
        }

        private int minYValue;

        public int MinYValue
        {
            get { return minYValue; }
            set { minYValue = value; RaisePropertyChanged(nameof(MinYValue)); }
        }

        private int maxYValue;

        public int MaxYValue
        {
            get { return maxYValue; }
            set { maxYValue = value; RaisePropertyChanged(nameof(MaxYValue)); }
        }

        private DateTime selectedDateTime = DateTime.Now;

        private void OnForecastDateChanged(ForecastChangedEventArgs obj)
        {
            if (obj.Payload == null) return;
            selectedDateTime = obj.Payload.Date;
            RefreshData(obj);
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; RaisePropertyChanged(nameof(City)); }
        }

        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; RaisePropertyChanged(nameof(Temperature)); }
        }

        private float temperatureDay;

        public float TemperatureDay
        {
            get { return temperatureDay; }
            set { temperatureDay = value; RaisePropertyChanged(nameof(TemperatureDay)); }
        }

        private float temperatureNight;

        public float TemperatureNight
        {
            get { return temperatureNight; }
            set { temperatureNight = value; RaisePropertyChanged(nameof(TemperatureNight)); }
        }

        private float windSpeed;

        public float WindSpeed
        {
            get { return windSpeed; }
            set { windSpeed = value; RaisePropertyChanged(nameof(WindSpeed)); }
        }

        private float feelslike;

        public float Feelslike
        {
            get { return feelslike; }
            set { feelslike = value; RaisePropertyChanged(nameof(Feelslike)); }
        }

        private float humidity;

        public float Humidity
        {
            get { return humidity; }
            set { humidity = value; RaisePropertyChanged(nameof(Humidity)); }
        }

        private float rainChance;

        public float RainChance
        {
            get { return rainChance; }
            set { rainChance = value; RaisePropertyChanged(nameof(RainChance)); }
        }

        private ImageSource weatherIcon;

        public ImageSource WeatherIcon
        {
            get { return weatherIcon; }
            set { weatherIcon = value; RaisePropertyChanged(nameof(WeatherIcon)); }
        }

        private DateTime sunRiseTime;

        public DateTime SunRiseTime
        {
            get { return sunRiseTime; }
            set { sunRiseTime = value; RaisePropertyChanged(nameof(SunRiseTime)); }
        }

        private DateTime sunSetTime;

        public DateTime SunSetTime
        {
            get { return sunSetTime; }
            set { sunSetTime = value; RaisePropertyChanged(nameof(SunSetTime)); }
        }

        private DateTime moonRiseTime;

        public DateTime MoonRiseTime
        {
            get { return moonRiseTime; }
            set { moonRiseTime = value; RaisePropertyChanged(nameof(MoonRiseTime)); }
        }

        private DateTime moonSetTime;

        public DateTime MoonSetTime
        {
            get { return moonSetTime; }
            set { moonSetTime = value; RaisePropertyChanged(nameof(MoonSetTime)); }
        }

        private float uvIndex;

        public float UVIndex
        {
            get { return uvIndex; }
            set { uvIndex = value; RaisePropertyChanged(nameof(UVIndex)); }
        }

        private float maxTemperature;
        private float minTemperature;

        public float MaxTemperature
        {
            get { return maxTemperature; }
            set { maxTemperature = value; RaisePropertyChanged(nameof(MaxTemperature)); }
        }

        public float MinTemperature
        {
            get { return minTemperature; }
            set { minTemperature = value; RaisePropertyChanged(nameof(MinTemperature)); }
        }
         
        private string moonPhase;

        public string MoonPhase
        {
            get { return moonPhase; }
            set { moonPhase = value; RaisePropertyChanged(nameof(MoonPhase)); }
        }

        private float dewPoint;

        public float Dew
        {
            get { return dewPoint; }
            set { dewPoint = value; RaisePropertyChanged(nameof(Dew)); }
        }

        private float precipitation;

        public float Precipitation
        {
            get { return precipitation; }
            set { precipitation = value; RaisePropertyChanged(nameof(Precipitation)); }
        }

        private float maxWind;

        public float MaxWind
        {
            get { return maxWind; }
            set { maxWind = value; RaisePropertyChanged(nameof(MaxWind)); }
        }

        private string weather;

        public string Weather
        {
            get { return weather; }
            set { weather = value; RaisePropertyChanged(nameof(Weather)); }
        }

        private ObservableCollection<HourlyWeatherInfoModel> hourlyWeatherData;

        public ObservableCollection<HourlyWeatherInfoModel> HourlyWeatherData
        {
            get { return hourlyWeatherData; }
            set { hourlyWeatherData = value; RaisePropertyChanged(nameof(HourlyWeatherData)); }
        }

        private List<string> weatherCollection;

        public List<string> WeatherCollection
        {
            get { return weatherCollection; }
            set { weatherCollection = value; RaisePropertyChanged(nameof(WeatherCollection)); }
        }
    }
}
