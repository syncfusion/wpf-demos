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
using System.Linq;
using System.Windows.Input;

namespace syncfusion.weatheranalysis.wpf
{
    public class HourlyForecastViewModel : NotificationObject
    {
        private int hourlyforecastDays;

        public int HourlyForecastDays
        {
            get { return hourlyforecastDays; }
            set { hourlyforecastDays = value; }
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

        private ObservableCollection<ForecastModel> _hourlyforecasts;

        public ObservableCollection<ForecastModel> HourlyForecasts
        {
            get { return _hourlyforecasts; }
            set { _hourlyforecasts = value; RaisePropertyChanged(nameof(HourlyForecasts)); }
        }

        public HourlyForecastViewModel()
        {
            HourlyForecastDays = 10;
            HourlyForecasts = new ObservableCollection<ForecastModel>(DataStore.GetHourlyForecasts(hourlyforecastDays));
            EventManager.Instance.Subscribe<DataChangedEvent, EventArgs>(OnDataChanged);
            if (SelectedTile == null)
            {
                SelectedTile = HourlyForecasts[0];
            }
        }

        private void OnDataChanged(EventArgs obj)
        {
            var currentDate = SelectedDate.Date;
            HourlyForecasts = new ObservableCollection<ForecastModel>(DataStore.GetHourlyForecasts(hourlyforecastDays));
            SelectedTile = HourlyForecasts.FirstOrDefault(f => f.Date.Date == currentDate);
        }

        public void Dispose()
        {
            EventManager.Instance.Unsubscribe<DataChangedEvent, EventArgs>(OnDataChanged);
            if (HourlyForecasts != null)
            {
                HourlyForecasts.Clear();
                HourlyForecasts = null;
            }
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
