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

namespace AxisStringValueTypeDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {

        public DataViewModel()
        {
            this.SalesDetails = new ObservableCollection<DataModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            this.SalesDetails.Add(new DataModel() { CarBrand = "Maruthi", SalesAmount = 20, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Volkswagen", SalesAmount = 40, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Hyundai", SalesAmount = 60, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            //this.SalesDetails.Add(new DataModel() { CarBrand = "FiatPalio", SalesAmount = 80, ProfitPercentage = 40, AverageRaise = 50, InvestedAmount = 400 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Toyota", SalesAmount = 120, ProfitPercentage = 50, AverageRaise = 50, InvestedAmount = 500 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Jaquar", SalesAmount = 140, ProfitPercentage = 60, AverageRaise = 50, InvestedAmount = 600 });
            //this.SalesDetails.Add(new DataModel() { CarBrand = "McClaren", SalesAmount = 150, ProfitPercentage = 70, AverageRaise = 50, InvestedAmount = 700 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "RolceRoyce", SalesAmount = 160, ProfitPercentage = 80, AverageRaise = 50, InvestedAmount = 800 });
            //this.SalesDetails.Add(new DataModel() { CarBrand = "Benz", SalesAmount = 180, ProfitPercentage = 85, AverageRaise = 50, InvestedAmount = 900 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Tata", SalesAmount = 200, ProfitPercentage = 95, AverageRaise = 50, InvestedAmount = 1000 });

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
