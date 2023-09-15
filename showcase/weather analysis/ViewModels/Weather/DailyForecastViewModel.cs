#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace syncfusion.weatheranalysis.wpf
{
    public class DailyForecastViewModel : NotificationObject
    {
        private int forecastDays;
        public int ForecastDays
        {
            get { return forecastDays; }
            set
            {
                forecastDays = value;
            }
        }

        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }

            set
            {
                selectedDate = value;
                RaisePropertyChanged(nameof(SelectedDate));
            }
        }

        private ForecastModel selectedTile;

        public ForecastModel SelectedTile
        {
            get
            {
                return selectedTile;
            }

            set
            {
                selectedTile = value;
                RaisePropertyChanged(nameof(SelectedTile));
            }
        }

        private ObservableCollection<ForecastModel> _forecasts;

        public ObservableCollection<ForecastModel> Forecasts
        {
            get { return _forecasts; }
            set { _forecasts = value; RaisePropertyChanged(nameof(Forecasts)); }
        }

        public DailyForecastViewModel()
        {
            ForecastDays = 10;
            Forecasts = new ObservableCollection<ForecastModel>(DataStore.GetForecasts(forecastDays));
            EventManager.Instance.Subscribe<DataChangedEvent, EventArgs>(OnDataChanged);
            EventManager.Instance.Subscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(OnFormatChanged);
            if (SelectedTile == null)
            {
                SelectedTile = Forecasts[0];
            }
        }

        private void OnFormatChanged(TempFormatChangedEventArgs args)
        {
            IsCelsius = args.Payload.Contains("C");
        }

        public void Dispose()
        {
            EventManager.Instance.Unsubscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(OnFormatChanged);
            EventManager.Instance.Unsubscribe<DataChangedEvent, EventArgs>(OnDataChanged);
            if (Forecasts != null)
            {
                Forecasts.Clear();
                Forecasts = null;
            }
        }

        private bool isCelsius = false;

        public bool IsCelsius
        {
            get { return isCelsius; }
            set { isCelsius = value; RaisePropertyChanged(nameof(IsCelsius)); }
        }

        private void OnDataChanged(EventArgs obj)
        {
            var currentDate = SelectedDate.Date;
            Forecasts = new ObservableCollection<ForecastModel>(DataStore.GetForecasts(forecastDays));
            SelectedTile = Forecasts.FirstOrDefault(f => f.Date.Date == currentDate);
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

        private void SelectionChangedExecute(object parameter)
        {
            SelectedDate = SelectedTile != null ? SelectedTile.Date : DateTime.Now;
            EventManager.Instance.Publish<ForecastChangedEvent, ForecastChangedEventArgs>(new ForecastChangedEventArgs() { Payload = SelectedTile });
        }

        private bool CanExecuteSelectionChanged(object parameter)
        {
            return true;
        }
    }
}
