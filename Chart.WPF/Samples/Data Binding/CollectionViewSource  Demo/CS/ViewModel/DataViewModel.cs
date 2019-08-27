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
using System.Windows.Input;
using System.Windows.Data;

namespace CollectionViewSourceDemo
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
            this.SalesDetails.Add(new DataModel() { ShopCode = 1000, SalesAmount = 20, LocationName = "Aberdeen"});
            this.SalesDetails.Add(new DataModel() { ShopCode = 1001, SalesAmount = 75, LocationName = "BentonCity" });
            this.SalesDetails.Add(new DataModel() { ShopCode = 1002, SalesAmount = 70, LocationName = "Blaine" });
            this.SalesDetails.Add(new DataModel() { ShopCode = 1003, SalesAmount = 45, LocationName = "Kelso" });
            this.SalesDetails.Add(new DataModel() { ShopCode = 1004, SalesAmount = 50, LocationName = "Lacey" });
            this.SalesDetails.Add(new DataModel() { ShopCode = 1005, SalesAmount = 60, LocationName = "Langley" });
            this.SalesDetails.Add(new DataModel() { ShopCode = 1006, SalesAmount = 30, LocationName = "Redmond" });
            this.SalesDetails.Add(new DataModel() { ShopCode = 1007, SalesAmount = 40, LocationName = "NewCastle" });           
            
        }

        private ICommand modifyCollectionCommand;
        public ICommand ModifyCollectionCommand
        {
            get
            {
                return (new ModifyRecords(this));
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

        private double shopCode;
        public double ShopCode
        {
            get
            {
                return shopCode;
            }
            set
            {
                shopCode = value;
                OnPropertyChanged("ShopCode");
            }
        }

        private string locationName="Enter Location Name";
        public string LocationName
        {
            get
            {
                return locationName;
            }
            set
            {
                locationName = value;
                OnPropertyChanged("LocationName");
            }
        }
        private double saleAmount;
        public double SalesAmount
        {
            get
            {
                return saleAmount;
            }
            set
            {
                saleAmount = value;
                OnPropertyChanged("SalesAmount");
            }
        }

        private DataModel selectedItemKey;
        public DataModel SelectedItemKey
        {
            get
            {
                return selectedItemKey;
            }
            set
            {
                selectedItemKey = value;
                OnPropertyChanged("SelectedItemKey");
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

    public class ModifyRecords:ICommand
    {
        private DataViewModel dataModel;
        public ModifyRecords(DataViewModel DataModel)
        {
            dataModel = DataModel;
        }



        #region ICommand Members

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            switch(parameter.ToString())
            {
                case "Add":
                    dataModel.SelectedItemKey=(new DataModel() {LocationName=dataModel.LocationName,ShopCode=dataModel.ShopCode,SalesAmount=dataModel.SalesAmount});
                    this.dataModel.SalesDetails.Add(dataModel.SelectedItemKey);
                    this.dataModel.LocationName = "Enter Location name";
                    this.dataModel.ShopCode = 0;
                    this.dataModel.SalesAmount = 0;
                    break;
                case "Remove":
                    this.dataModel.SalesDetails.Remove(dataModel.SelectedItemKey);
                    break;
            
            }
            
        }

        #endregion
    }

}
