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

namespace CollectionViewSourceDemo
{
    public class DataModel : INotifyPropertyChanged
    {

        private double shopcode;
        public double ShopCode
        {
            get
            {
                return shopcode;
            }
            set
            {
                shopcode = value;
                OnPropertyChanged("ShopCode");
            }
        }

        public string locationName;
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

        public double salesamount;
        public double SalesAmount
        {
            get
            {
                return salesamount;
            }
            set
            {
                salesamount = value;
                OnPropertyChanged("SalesAmount");
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

}
