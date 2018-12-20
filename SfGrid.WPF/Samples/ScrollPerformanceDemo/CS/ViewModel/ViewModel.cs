#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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

namespace ScrollPerformanceDemo
{
    /// <summary>
    /// This class represents the StocksViewModel 
    /// </summary>
    public class StocksViewModel : NotificationObject
    {
        #region Members

        ObservableCollection<StockData> data;
        Random r = new Random(123345345);        
        List<string> StockSymbols = new List<string>();
        private bool isBusy =true;

        #endregion        

        /// <summary>
        /// Gets the IsBusy whether to show the busy indicator.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; RaisePropertyChanged("IsBusy"); }
        }

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public ObservableCollection<StockData> Stocks
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
                RaisePropertyChanged("Stocks");
            }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StocksViewModel"/> class.
        /// </summary>
        public StocksViewModel()
        {
            this.data = new ObservableCollection<StockData>();
        }

        #endregion        
     
        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        internal ObservableCollection<StockData> GenerateDataSource(int count)
        {
            var stocks = new ObservableCollection<StockData>();
            for (int i = 0; i < count; ++i)
            {
                var newRec = new StockData();
                newRec.Symbol = ChangeSymbol();
                newRec.Trade1 = Math.Round(r.NextDouble() * 30, 2);
                newRec.Trade2 = Math.Round(r.NextDouble() * 12, 2);
                newRec.Trade3 = Math.Round(r.NextDouble() * 34, 2);
                newRec.Trade4 = Math.Round(r.NextDouble() * 56, 2);
                newRec.Trade5 = Math.Round(r.NextDouble() * 76, 2);
                newRec.Trade6 = Math.Round(r.NextDouble() * 33, 2);
                newRec.Trade7 = Math.Round(r.NextDouble() * 76, 2);
                newRec.Trade8 = Math.Round(r.NextDouble() * 26, 2);
                newRec.Trade9 = Math.Round(r.NextDouble() * 25, 2);
                newRec.Trade10 = Math.Round(r.NextDouble() * 32, 2);
                newRec.Trade11 = Math.Round(r.NextDouble() * 46, 2);
                newRec.Trade12 = Math.Round(r.NextDouble() * 52, 2);
                newRec.Trade13 = Math.Round(r.NextDouble() * 76, 2);
                newRec.Trade14 = Math.Round(r.NextDouble() * 21, 2);
                newRec.Trade15 = Math.Round(r.NextDouble() * 32, 2);
                newRec.Trade16 = Math.Round(r.NextDouble() * 31, 2);
                newRec.Trade17 = Math.Round(r.NextDouble() * 23, 2);
                newRec.Trade18 = Math.Round(r.NextDouble() * 51, 2);
                newRec.Trade19 = Math.Round(r.NextDouble() * 20, 2);
                newRec.Trade20 = Math.Round(r.NextDouble() * 30, 2);
                newRec.Trade21 = Math.Round(r.NextDouble() * 26, 2);
                newRec.Trade22 = Math.Round(r.NextDouble() * 42, 2);
                newRec.Trade23 = Math.Round(r.NextDouble() * 43, 2);
                newRec.Trade24 = Math.Round(r.NextDouble() * 12, 2);
                newRec.Trade25 = Math.Round(r.NextDouble() * 16, 2);
                newRec.Trade26 = Math.Round(r.NextDouble() * 19, 2);
                newRec.Trade27 = Math.Round(r.NextDouble() * 49, 2);
                newRec.Trade28 = Math.Round(r.NextDouble() * 64, 2);
                newRec.Trade29 = Math.Round(r.NextDouble() * 13, 2);
                stocks.Add(newRec);
            }
            return stocks;
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <returns></returns>
        private String ChangeSymbol()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            do
            {
                builder = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

            } while (StockSymbols.Contains(builder.ToString()));

            StockSymbols.Add(builder.ToString());
            return builder.ToString();
        }      
    }
}
