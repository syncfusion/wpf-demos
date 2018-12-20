#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace AxisDoubleRangeDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {

        public DataViewModel()
        {
            this.SalesDetails = new ObservableCollection<DataModel>();
            this.MillionDetails = new ObservableCollection<DataModel>();
            this.KDetails = new ObservableCollection<DataModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 1000000000, SalesAmount = 20, ProfitPercentage = 10, GrainName = "Wheat", InvestedAmount = 100 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 20565656565, SalesAmount = 40, ProfitPercentage = 20, GrainName = "Corn", InvestedAmount = 200 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 3056565653, SalesAmount = 60, ProfitPercentage = 30, GrainName = "Raggi", InvestedAmount = 300 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 4043543, SalesAmount = 80, ProfitPercentage = 40, GrainName = "Rice", InvestedAmount = 400 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 50435453534, SalesAmount = 120, ProfitPercentage = 50, GrainName = "Oat", InvestedAmount = 500 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 60435453453, SalesAmount = 140, ProfitPercentage = 60, GrainName ="Barley", InvestedAmount = 600 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 90435353535, SalesAmount = 160, ProfitPercentage = 70, GrainName = "Farro", InvestedAmount = 700 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 9054545454, SalesAmount = 165, ProfitPercentage = 80, GrainName = "Spelt", InvestedAmount = 800 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 10045445454, SalesAmount = 170, ProfitPercentage = 85, GrainName = "Millet", InvestedAmount = 900 });
            this.SalesDetails.Add(new DataModel() { QuantityOfGrains = 13054545454, SalesAmount = 185, ProfitPercentage = 95, GrainName = "Maize", InvestedAmount = 1000 });

            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 1000000, SalesAmount = 20, ProfitPercentage = 10, GrainName = "Wheat", InvestedAmount = 100 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 20565656, SalesAmount = 40, ProfitPercentage = 20, GrainName = "Corn", InvestedAmount = 200 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 30565656, SalesAmount = 60, ProfitPercentage = 30, GrainName = "Raggi", InvestedAmount = 300 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 40435, SalesAmount = 80, ProfitPercentage = 40, GrainName = "Rice", InvestedAmount = 400 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 50435453, SalesAmount = 120, ProfitPercentage = 50, GrainName = "Oat", InvestedAmount = 500 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 60435453, SalesAmount = 140, ProfitPercentage = 60, GrainName = "Barley", InvestedAmount = 600 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 80435353, SalesAmount = 160, ProfitPercentage = 70, GrainName = "Farro", InvestedAmount = 700 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 90545454, SalesAmount = 165, ProfitPercentage = 80, GrainName = "Spelt", InvestedAmount = 800 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 10045445, SalesAmount = 170, ProfitPercentage = 85, GrainName = "Millet", InvestedAmount = 900 });
            this.MillionDetails.Add(new DataModel() { QuantityOfGrains = 13054545, SalesAmount = 185, ProfitPercentage = 95, GrainName = "Maize", InvestedAmount = 1000 });

            this.KDetails.Add(new DataModel() { QuantityOfGrains = 1000, SalesAmount = 20, ProfitPercentage = 10, GrainName = "Wheat", InvestedAmount = 100 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 2056, SalesAmount = 40, ProfitPercentage = 20, GrainName = "Corn", InvestedAmount = 200 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 3056, SalesAmount = 60, ProfitPercentage = 30, GrainName = "Raggi", InvestedAmount = 300 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 4043, SalesAmount = 80, ProfitPercentage = 40, GrainName = "Rice", InvestedAmount = 400 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 5043, SalesAmount = 120, ProfitPercentage = 50, GrainName = "Oat", InvestedAmount = 500 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 6043, SalesAmount = 140, ProfitPercentage = 60, GrainName = "Barley", InvestedAmount = 600 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 8043, SalesAmount = 160, ProfitPercentage = 70, GrainName = "Farro", InvestedAmount = 700 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 9054, SalesAmount = 165, ProfitPercentage = 80, GrainName = "Spelt", InvestedAmount = 800 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 1004, SalesAmount = 170, ProfitPercentage = 85, GrainName = "Millet", InvestedAmount = 900 });
            this.KDetails.Add(new DataModel() { QuantityOfGrains = 1305, SalesAmount = 185, ProfitPercentage = 95, GrainName = "Maize", InvestedAmount = 1000 });

        }

        public Array doubleunitcollection
        {
            get { return Enum.GetValues(typeof(DoubleUnits)); }
        }

        public Array doubleunitalign
        {
            get { return Enum.GetValues(typeof(ChartAlignment)); }
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

        public ObservableCollection<DataModel> milliondetails;
        public ObservableCollection<DataModel> MillionDetails
        {
            get
            {
                return milliondetails;
            }
            set
            {
                milliondetails = value;
                OnPropertyChanged("MillionDetails");
            }
        }

        public ObservableCollection<DataModel> kdetails;
        public ObservableCollection<DataModel> KDetails
        {
            get
            {
                return kdetails;
            }
            set
            {
                kdetails = value;
                OnPropertyChanged("KDetails");
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
