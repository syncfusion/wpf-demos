#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace TreeViewBindingDemo
{          
    public class Stock : NotificationObject
    {
        string stockID;
        public string StockID
        {
            get
            {
                return stockID;
            }
            set
            {
                stockID = value;
                this.RaisePropertyChanged(() => this.StockID);
            }
        }

        string stockName;
        public string StockName
        {
            get
            {
                return stockName;
            }
            set
            {
                stockName = value;
                this.RaisePropertyChanged(() => this.StockName);
            }
        }

        double price = 0d;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                this.RaisePropertyChanged(() => this.Price);
            }
        }

        double open = 0d;
        public double Open
        {
            get
            {
                return open;
            }
            set
            {
                open = value;
                this.RaisePropertyChanged(() => this.Open);
            }
        }       
    }      
}
