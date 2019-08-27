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

namespace ScaleBreakDemo
{
    public class DataViewModel:INotifyPropertyChanged
    {

        public DataViewModel()
        {
            this.SalesDetails = new ObservableCollection<DataModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            this.SalesDetails.Add(new DataModel() { CarBrand = "Maruthi", SoldCars = 2330, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Volkswagen", SoldCars = 2148, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Hyundai", SoldCars = 304, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Toyota", SoldCars = 238, ProfitPercentage = 50, AverageRaise = 50, InvestedAmount = 500 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Jaquar", SoldCars = 192, ProfitPercentage = 60, AverageRaise = 50, InvestedAmount = 600 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "RolceRoyce", SoldCars = 168, ProfitPercentage = 80, AverageRaise = 50, InvestedAmount = 800 });
            this.SalesDetails.Add(new DataModel() { CarBrand = "Tata", SoldCars = 154, ProfitPercentage = 95, AverageRaise = 50, InvestedAmount = 1000 });

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
        public string[] LineStyles
        {
            get
            {

                return new string[] { "Dash Line", "DashDotDot Line", "DashDot Line", "Dot Line", "Solid Line" };
            }
        }
    }
}
