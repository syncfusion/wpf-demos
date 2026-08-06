using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;

namespace syncfusion.weatheranalysis.wpf
{
    public class LocationViewModel : NotificationObject
    {
        private ObservableCollection<LocationModel> cityCollection;

        public ObservableCollection<LocationModel> CityCollection
        {
            get { return cityCollection; }
            set { cityCollection = value; }
        }

        private ObservableCollection<string> temperatureFormatCollection;

        public ObservableCollection<string> TemperatureFormatCollection
        {
            get { return temperatureFormatCollection; }
            set { temperatureFormatCollection = value; RaisePropertyChanged(nameof(TemperatureFormatCollection)); }
        }

        private LocationModel selectedCity;

        public LocationModel SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; RaisePropertyChanged(nameof(SelectedCity)); }
        }

        private string selectedFormat;

        public string SelectedFormat
        {
            get { return selectedFormat; }
            set { selectedFormat = value; RaisePropertyChanged(nameof(SelectedFormat)); }
        }

        public LocationViewModel()
        {
            CityCollection = new ObservableCollection<LocationModel>();
            RefreshData(DateTime.Now);
            EventManager.Instance.Subscribe<ForecastChangedEvent, ForecastChangedEventArgs>(OnForecastDateChanged);
            TemperatureFormatCollection = new ObservableCollection<string>
            {
                "°F",
                "°C"
            };
            ThemeName = lightTheme;
            SelectedCity = cityCollection[0];
            SelectedFormat = temperatureFormatCollection[0];
            SelectionChangedCommand?.Execute(selectedCity);
            FormatChanged?.Execute(selectedFormat);
        }

        private void RefreshData(DateTime dateTime)
        {
            CityCollection = DataStore.GetLocationDataForDate(dateTime);
        }

        private void OnForecastDateChanged(ForecastChangedEventArgs args)
        {
            if (args.Payload != null)
                RefreshData(args.Payload.Date);
        }

        private bool isCelsius = false;

        public bool IsCelsius
        {
            get { return isCelsius; }
            set { isCelsius = value; RaisePropertyChanged(nameof(IsCelsius)); }
        }


        private ICommand selectionChangedCommand;

        public ICommand SelectionChangedCommand
        {
            get
            {
                if (selectionChangedCommand == null)
                {
                    selectionChangedCommand = new RelayCommand(SelectionChangedExecute, CanExecuteSelectionChanged);
                }

                return selectionChangedCommand;
            }
        }

        private ICommand formatChanged;

        public ICommand FormatChanged
        {
            get
            {
                if (formatChanged == null)
                {
                    formatChanged = new RelayCommand(FormatChangedExecute, CanFormatChanged);
                }

                return formatChanged;
            }
        }

        private ICommand themeChanged;

        public ICommand ThemeChanged
        {
            get
            {
                if (themeChanged == null)
                {
                    themeChanged = new RelayCommand(ThemeChangedExecute, CanThemeChanged);
                }

                return themeChanged;
            }
        }

        public void Dispose()
        {
            EventManager.Instance.Unsubscribe<ForecastChangedEvent, ForecastChangedEventArgs>(OnForecastDateChanged);
            if (CityCollection != null)
            {
                CityCollection.Clear();
                CityCollection = null;
            }

            if (TemperatureFormatCollection != null)
            {
                TemperatureFormatCollection.Clear();
                TemperatureFormatCollection = null;
            }
        }

        private void ThemeChangedExecute(object parameter) 
        {
            ThemeName = ThemeName == lightTheme ? darkTheme : lightTheme;
            UpdateTheme();
        }

        private void SelectionChangedExecute(object parameter)
        {
            EventManager.Instance.Publish<CityChangedEvent, CityChangedEventArgs>(new CityChangedEventArgs()
            {
                Payload = SelectedCity?.City?.ToString()
            });
        }

        private void FormatChangedExecute(object parameter)
        {
            EventManager.Instance.Publish<TempFormatChangedEvent, TempFormatChangedEventArgs>(new TempFormatChangedEventArgs()
            {
                Payload = SelectedFormat?.ToString()
            });

            IsCelsius = SelectedFormat?.ToString().Contains("C") ?? false;
        }

        private bool CanExecuteSelectionChanged(object parameter)
        {
            return true;
        }

        private bool CanFormatChanged(object parameter)
        {
            return true;
        }

        private bool CanThemeChanged(object parameter)
        {
            return true;
        }

        private string themeName;

        public string ThemeName
        {
            get
            {
                return themeName;
            }

            set
            {
                if (themeName != value)
                {
                    themeName = value;
                    UpdateTheme();
                }
            }
        }

        string lightTheme = "Windows11Light";
        string darkTheme = "Windows11Dark";

        void UpdateTheme()
        {
            if (ThemeName == darkTheme)
            {
                SfSkinManager.SetTheme(WindowHelper.MainWindow, new Theme() { ThemeName = darkTheme });
                PathData = "M8.33203 1V2.33333M8.33203 14.334V15.6673M3.14453 3.14648L4.0912 4.09315M12.5703 12.5742L13.517 13.5209M1 8.33398H2.33333M14.332 8.33398H15.6654M3.14453 13.5209L4.0912 12.5742M12.5703 4.09315L13.517 3.14648M11.6667 8.33333C11.6667 10.1743 10.1743 11.6667 8.33333 11.6667C6.49238 11.6667 5 10.1743 5 8.33333C5 6.49238 6.49238 5 8.33333 5C10.1743 5 11.6667 6.49238 11.6667 8.33333Z";
            }
            else
            {
                SfSkinManager.SetTheme(WindowHelper.MainWindow, new Theme() { ThemeName = lightTheme });
                PathData = "M1 7.88484C1 11.8144 4.18557 15 8.11516 15C11.422 15 14.2019 12.7442 15 9.68742C14.4243 9.83773 13.8202 9.91774 13.1974 9.91774C9.26783 9.91774 6.08226 6.73217 6.08226 2.80258C6.08226 2.17979 6.16227 1.57569 6.31258 1C3.25584 1.7981 1 4.57803 1 7.88484Z";
            }
        }

        private string pathData;

        public string PathData
        {
            get { return pathData; }
            set { pathData = value; RaisePropertyChanged(nameof(PathData)); }
        }
    }
}
