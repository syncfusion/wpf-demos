#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Syncfusion.Windows.Shared;
using System.Diagnostics;
using System.ComponentModel;
using Syncfusion.Data.Extensions;
using System.Reflection;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// This class represents the StockDetailsViewModel 
    /// </summary>
    public class StockDetailsViewModel : NotificationObject,IDisposable
    {
        #region Members

        ObservableCollection<StockDetails> _stocks = new ObservableCollection<StockDetails>();
        Random r = new Random(123345345);        
        List<string> StockSymbols = new List<string>();        

        #endregion        

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public ObservableCollection<StockDetails> Stocks
        {
            get
            {
                return this._stocks;
            }
            set
            {
                this._stocks = value;
                RaisePropertyChanged("Stocks");
            }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDetailsViewModel"/> class.
        /// </summary>
        public StockDetailsViewModel()
        {
            this.Stocks = GenerateDataSource(20000);
        }

        #endregion

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        internal ObservableCollection<StockDetails> GenerateDataSource(int count)
        {
            var stocks = new ObservableCollection<StockDetails>();
            for (int i = 0; i < count; ++i)
            {
                var newRec = new StockDetails();
                newRec.Symbol = symbol[r.Next(0, 25)];
                newRec.Trade1 = r.Next(10, 25) * 30;
                newRec.Trade2 = r.Next(10, 25) * 12;
                newRec.Trade3 = r.Next(10, 25) * 34;
                newRec.Trade4 = r.Next(10, 25) * 56;
                newRec.Trade5 = r.Next(10, 25) * 76;
                newRec.Trade6 = r.Next(10, 25) * 33;
                newRec.Trade7 = r.Next(10, 25) * 76;
                newRec.Trade8 = r.Next(10, 25) * 26;
                newRec.Trade9 = r.Next(10, 25) * 25;
                newRec.Trade10 = r.Next(10, 25) * 32;
                newRec.Trade11 = r.Next(10, 25) * 46;
                newRec.Trade12 = r.Next(10, 25) * 52;
                newRec.Trade13 = r.Next(10, 25) * 76;
                newRec.Trade14 = r.Next(10, 25) * 21;
                newRec.Trade15 = r.Next(10, 25) * 32;
                newRec.Trade16 = r.Next(10, 25) * 31;
                newRec.Trade17 = r.Next(10, 25) * 23;
                newRec.Trade18 = r.Next(10, 25) * 51;
                newRec.Trade19 = r.Next(10, 25) * 20;
                newRec.Trade20 = r.Next(10, 25) * 30;
                newRec.Trade21 = r.Next(10, 25) * 26;
                newRec.Trade22 = r.Next(10, 25) * 42;
                newRec.Trade23 = r.Next(10, 25) * 43;
                newRec.Trade24 = r.Next(10, 25) * 12;
                newRec.Trade25 = r.Next(10, 25) * 16;
                newRec.Trade26 = r.Next(10, 25) * 19;
                newRec.Trade27 = r.Next(10, 25) * 49;
                newRec.Trade28 = r.Next(10, 25) * 64;
                newRec.Trade29 = r.Next(10, 25) * 13;
                stocks.Add(newRec);
            }
            return stocks;
        }

        public void Dispose()
        {
            this.Stocks.Clear();
            this.Stocks = null;
            this.StockSymbols.Clear();
            this.StockSymbols = null;
        }

        string[] symbol = new string[]
        {
            "ZRH", "AFH", "DHY", "MQR", "PRS", "QJR", "NDW", "ZVY", "LPJY", "EVS","SHG" , "HRJ", "KSD", "WGE", "WIEG", "FQHE", "QWHG", "BCH", "MKE", "ODH", "EFV", "EGE", "UGV",  "MEW", "IOH", "QWT"
        };
        
    }
}
