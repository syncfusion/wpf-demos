#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
    public class StockDetailsViewModel : NotificationObject
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
                newRec.Symbol = symbol[r.Next(0,25)];
                newRec.Trade1 = 10 * 30;
                newRec.Trade2 = 10 * 12;
                newRec.Trade3 = 10 * 34;
                newRec.Trade4 = 10 * 56;
                newRec.Trade5 = 10 * 76;
                newRec.Trade6 = 10 * 33;
                newRec.Trade7 = 10 * 76;
                newRec.Trade8 = 10 * 26;
                newRec.Trade9 = 10 * 25;
                newRec.Trade10 = 10 * 32;
                newRec.Trade11 = 10 * 46;
                newRec.Trade12 = 10 * 52;
                newRec.Trade13 = 10 * 76;
                newRec.Trade14 = 10 * 21;
                newRec.Trade15 = 10 * 32;
                newRec.Trade16 = 10 * 31;
                newRec.Trade17 = 10 * 23;
                newRec.Trade18 = 10 * 51;
                newRec.Trade19 = 10 * 20;
                newRec.Trade20 = 10 * 30;
                newRec.Trade21 = 10 * 26;
                newRec.Trade22 = 10 * 42;
                newRec.Trade23 = 10 * 43;
                newRec.Trade24 = 10 * 12;
                newRec.Trade25 = 10 * 16;
                newRec.Trade26 = 10 * 19;
                newRec.Trade27 = 10 * 49;
                newRec.Trade28 = 10 * 64;
                newRec.Trade29 = 10 * 13;
                stocks.Add(newRec);
            }
            return stocks;
        }

        string[] symbol = new string[]
        {
            "ZRH", "AFH", "DHY", "MQR", "PRS", "QJR", "NDW", "ZVY", "LPJY", "EVS","SHG" , "HRJ", "KSD", "WGE", "WIEG", "FQHE", "QWHG", "BCH", "MKE", "ODH", "EFV", "EGE", "UGV",  "MEW", "IOH", "QWT"
        };
        
    }
}
