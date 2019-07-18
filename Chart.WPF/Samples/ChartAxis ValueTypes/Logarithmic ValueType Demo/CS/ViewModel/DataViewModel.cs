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

namespace LogarithmicValueRangeDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {

        public DataViewModel()
        {
            this.SalesDetails = new ObservableCollection<DataModel>();
            this.Sales1Details = new ObservableCollection<DataModel>();
            this.Sales2Details = new ObservableCollection<DataModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            this.SalesDetails.Add(new DataModel() { CarBrand = "Maruthi", HorsePower = 2000393939, FuelConsumption = 10, AverageSpeed = 50, RotationsPerMinute = 100 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Volkswagen", HorsePower = 40003030300, FuelConsumption = 20, AverageSpeed = 50, RotationsPerMinute = 200 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Hyundai", HorsePower = 6000393939, FuelConsumption = 30, AverageSpeed = 50, RotationsPerMinute = 300 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Toyota", HorsePower = 1200393939, FuelConsumption = 50, AverageSpeed = 50, RotationsPerMinute = 500 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Jaquar", HorsePower = 1400, FuelConsumption = 60, AverageSpeed = 50, RotationsPerMinute = 600 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "McClaren", HorsePower = 150000000, FuelConsumption = 70, AverageSpeed = 50, RotationsPerMinute = 700 });

            this.Sales1Details.Add(new DataModel() { CarBrand = "Maruthi", HorsePower = 2000393, FuelConsumption = 10, AverageSpeed = 50, RotationsPerMinute = 100 });
            this.Sales1Details.Add(new DataModel() { CarBrand = "Volkswagen", HorsePower = 40003030, FuelConsumption = 20, AverageSpeed = 50, RotationsPerMinute = 200 });
            this.Sales1Details.Add(new DataModel() { CarBrand = "Hyundai", HorsePower = 6000393, FuelConsumption = 30, AverageSpeed = 50, RotationsPerMinute = 300 });
            this.Sales1Details.Add(new DataModel() { CarBrand = "Toyota", HorsePower = 1200393, FuelConsumption = 50, AverageSpeed = 50, RotationsPerMinute = 500 });
            this.Sales1Details.Add(new DataModel() { CarBrand = "Jaquar", HorsePower = 1400, FuelConsumption = 60, AverageSpeed = 50, RotationsPerMinute = 600 });
            this.Sales1Details.Add(new DataModel() { CarBrand = "McClaren", HorsePower = 150000, FuelConsumption = 70, AverageSpeed = 50, RotationsPerMinute = 700 });

            this.Sales2Details.Add(new DataModel() { CarBrand = "Maruthi", HorsePower = 2000, FuelConsumption = 10, AverageSpeed = 50, RotationsPerMinute = 100 });
            this.Sales2Details.Add(new DataModel() { CarBrand = "Volkswagen", HorsePower = 4000, FuelConsumption = 20, AverageSpeed = 50, RotationsPerMinute = 200 });
            this.Sales2Details.Add(new DataModel() { CarBrand = "Hyundai", HorsePower = 6000, FuelConsumption = 30, AverageSpeed = 50, RotationsPerMinute = 300 });
            this.Sales2Details.Add(new DataModel() { CarBrand = "Toyota", HorsePower = 1200, FuelConsumption = 50, AverageSpeed = 50, RotationsPerMinute = 500 });
            this.Sales2Details.Add(new DataModel() { CarBrand = "Jaquar", HorsePower = 1400, FuelConsumption = 60, AverageSpeed = 50, RotationsPerMinute = 600 });
            this.Sales2Details.Add(new DataModel() { CarBrand = "McClaren", HorsePower = 15000, FuelConsumption = 70, AverageSpeed = 50, RotationsPerMinute = 700 });
            
        }

        public Array chartvaluetypecollection
        {
            get { return Enum.GetValues(typeof(ChartValueType)); }
        }

        public Array logintervalcoll
        {
            get { return Enum.GetValues(typeof(LogarithmicType)); }
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
        public ObservableCollection<DataModel> salesdetails;
        public ObservableCollection<DataModel> SalesDetails
        {
            get
            {
                return salesdetails;
            }
            set
            {
                salesdetails = value;
                OnPropertyChanged("SalesDetails");
            }
        }
        public ObservableCollection<DataModel> sales1details;
        public ObservableCollection<DataModel> Sales1Details
        {
            get
            {
                return sales1details;
            }
            set
            {
                sales1details = value;
                OnPropertyChanged("Sales1Details");
            }
        }

        public ObservableCollection<DataModel> sales2details;
        public ObservableCollection<DataModel> Sales2Details
        {
            get
            {
                return sales2details;
            }
            set
            {
                sales2details = value;
                OnPropertyChanged("Sales2Details");
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
}
