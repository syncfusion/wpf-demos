#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;
using System.Windows.Data;

namespace AxisDateTimeRangeDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {

        public DataViewModel()
        {
            this.AcrossYears = new ObservableCollection<DataModel>();
            this.Year = new ObservableCollection<DataModel>();
            this.AcrossMonths = new ObservableCollection<DataModel>();
            this.Days = new ObservableCollection<DataModel>();
            this.Hours = new ObservableCollection<DataModel>();
            this.Minutes = new ObservableCollection<DataModel>();

            GenerateData();
        }

        private void GenerateData()
        {
            DateTime dt=new DateTime(2006, 1, 1,1,0,0);
            this.AcrossYears.Add(new DataModel() { TimePeriod = dt.AddYears(0), SalesAmount = 20, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.AcrossYears.Add(new DataModel() { TimePeriod = dt.AddYears(1), SalesAmount = 40, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.AcrossYears.Add(new DataModel() { TimePeriod = dt.AddYears(2), SalesAmount = 60, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.AcrossYears.Add(new DataModel() { TimePeriod = dt.AddYears(3), SalesAmount = 80, ProfitPercentage = 40, AverageRaise = 50, InvestedAmount = 400 });
            this.AcrossYears.Add(new DataModel() { TimePeriod = dt.AddYears(4), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
            this.AcrossYears.Add(new DataModel() { TimePeriod = dt.AddYears(5), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });

            DateTime dt1 = new DateTime(2006, 1, 1, 1, 0, 0);
            this.Year.Add(new DataModel() { TimePeriod = dt1.AddDays(365), SalesAmount = 20, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.Year.Add(new DataModel() { TimePeriod = dt1.AddDays(365 * 2), SalesAmount = 40, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.Year.Add(new DataModel() { TimePeriod = dt1.AddDays(365 * 3), SalesAmount = 60, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.Year.Add(new DataModel() { TimePeriod = dt1.AddDays(365 * 4), SalesAmount = 80, ProfitPercentage = 40, AverageRaise = 50, InvestedAmount = 400 });
            this.Year.Add(new DataModel() { TimePeriod = dt1.AddDays(365 * 5), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
            this.Year.Add(new DataModel() { TimePeriod = dt1.AddDays(365 * 6), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });

            DateTime dt2 = new DateTime(2006, 3, 1, 1, 0, 0);
            this.AcrossMonths.Add(new DataModel() { TimePeriod = dt2.AddMonths(0), SalesAmount = 20, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.AcrossMonths.Add(new DataModel() { TimePeriod = dt2.AddMonths(1), SalesAmount = 40, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.AcrossMonths.Add(new DataModel() { TimePeriod = dt2.AddMonths(2), SalesAmount = 60, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.AcrossMonths.Add(new DataModel() { TimePeriod = dt2.AddMonths(3), SalesAmount = 80, ProfitPercentage = 40, AverageRaise = 50, InvestedAmount = 400 });
            this.AcrossMonths.Add(new DataModel() { TimePeriod = dt2.AddMonths(4), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
            this.AcrossMonths.Add(new DataModel() { TimePeriod = dt2.AddMonths(5), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });

            DateTime dt3 = new DateTime(2006, 1, 1, 1, 0, 0);
            this.Days.Add(new DataModel() { TimePeriod = dt3.AddDays(0), SalesAmount = 20, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.Days.Add(new DataModel() { TimePeriod = dt3.AddDays(1), SalesAmount = 40, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.Days.Add(new DataModel() { TimePeriod = dt3.AddDays(2), SalesAmount = 60, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.Days.Add(new DataModel() { TimePeriod = dt3.AddDays(3), SalesAmount = 80, ProfitPercentage = 40, AverageRaise = 50, InvestedAmount = 400 });
            this.Days.Add(new DataModel() { TimePeriod = dt3.AddDays(4), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
            this.Days.Add(new DataModel() { TimePeriod = dt3.AddDays(5), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });

            DateTime dt4 = new DateTime(2006, 1, 1, 1, 0, 0);
            this.Hours.Add(new DataModel() { TimePeriod = dt4.AddHours(0), SalesAmount = 20, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.Hours.Add(new DataModel() { TimePeriod = dt4.AddHours(1), SalesAmount = 40, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.Hours.Add(new DataModel() { TimePeriod = dt4.AddHours(2), SalesAmount = 60, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.Hours.Add(new DataModel() { TimePeriod = dt4.AddHours(3), SalesAmount = 80, ProfitPercentage = 40, AverageRaise = 50, InvestedAmount = 400 });
            this.Hours.Add(new DataModel() { TimePeriod = dt4.AddHours(4), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
            this.Hours.Add(new DataModel() { TimePeriod = dt4.AddHours(12), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });

            DateTime dt5 = new DateTime(2006, 1, 1, 1, 0, 0);
            this.Minutes.Add(new DataModel() { TimePeriod = dt5.AddMinutes(0), SalesAmount = 20, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.Minutes.Add(new DataModel() { TimePeriod = dt5.AddMinutes(1), SalesAmount = 40, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.Minutes.Add(new DataModel() { TimePeriod = dt5.AddMinutes(2), SalesAmount = 60, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.Minutes.Add(new DataModel() { TimePeriod = dt5.AddMinutes(3), SalesAmount = 80, ProfitPercentage = 40, AverageRaise = 50, InvestedAmount = 400 });
            this.Minutes.Add(new DataModel() { TimePeriod = dt5.AddMinutes(4), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
            this.Minutes.Add(new DataModel() { TimePeriod = dt5.AddMinutes(5), SalesAmount = 160, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
        }

        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                          ChartColorPalette.MixedFantasy
                                        };
            }
        }

        public ObservableCollection<DataModel> acrossYears;
        public ObservableCollection<DataModel> AcrossYears
        {
            get
            {
                return acrossYears;
            }
            set
            {
                acrossYears = value;
                OnPropertyChanged("AcrossYears");
            }
        }

        public ObservableCollection<DataModel> year;
        public ObservableCollection<DataModel> Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public ObservableCollection<DataModel> acrossMonths;
        public ObservableCollection<DataModel> AcrossMonths
        {
            get
            {
                return acrossMonths;
            }
            set
            {
                acrossMonths = value;
                OnPropertyChanged("AcrossMonths");
            }
        }

        public ObservableCollection<DataModel> days;
        public ObservableCollection<DataModel> Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
                OnPropertyChanged("Days");
            }
        }

        public ObservableCollection<DataModel> hours;
        public ObservableCollection<DataModel> Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
                OnPropertyChanged("Hours");
            }
        }

        public ObservableCollection<DataModel> minutes;
        public ObservableCollection<DataModel> Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
                OnPropertyChanged("Minutes");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }
        #endregion
    }

    public class VisbilityConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return false;
            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }

    public class DateTimeConverter : IValueConverter
    {


        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string original = value as string;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
