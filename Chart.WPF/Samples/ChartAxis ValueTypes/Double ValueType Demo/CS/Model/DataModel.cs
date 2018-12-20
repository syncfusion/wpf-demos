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

namespace AxisDoubleRangeDemo
{
    public class DataModel : INotifyPropertyChanged
    {

        private double quantity;
        public double QuantityOfGrains
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("QuantityOfGrains");
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

        public double profitpercentage;
        public double ProfitPercentage
        {
            get
            {
                return profitpercentage;
            }
            set
            {
                profitpercentage = value;
                OnPropertyChanged("ProfitPercentage");
            }
        }

        public string grainname;
        public string GrainName
        {
            get
            {
                return grainname;
            }
            set
            {
                grainname = value;
                OnPropertyChanged("GrainName");
            }
        }

        public double investedamount;
        public double InvestedAmount
        {
            get
            {
                return investedamount;
            }
            set
            {
                investedamount = value;
                OnPropertyChanged("InvestedAmount");
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
