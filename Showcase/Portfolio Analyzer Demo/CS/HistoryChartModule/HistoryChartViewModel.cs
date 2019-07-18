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
using System.IO;
using System.ComponentModel;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows.Data;
using System.Collections.ObjectModel;
using PortfolioAnalyzer.Infrastructure;
using PortfolioAnalyzer.Model;
using System.Data;
using PortfolioAnalyzer.Infrastructure;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Input;
using System.Windows.Media;
using PortfolioAnalyzer.Data.Model;

namespace PortfolioAnalyzer.HistoryChartModule
{
    /// <summary>
    /// Represents the HistoryChartViewModel class which handles the interaction logic for HistoryChartView.
    /// </summary>
    public class HistoryChartViewModel : INotifyPropertyChanged
    {

        #region Members

        IEventAggregator eventAggregator;
        bool animate;
        private List<HistoricalQuotes> historicalQuotes;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryChartViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public HistoryChartViewModel(IEventAggregator eventAggregator)
        {
                this.eventAggregator = eventAggregator;
                this.eventAggregator.GetEvent<StockSelectedEvent>().Subscribe(SelectedAccountEventHandler);
                this.AccountNames = GetAccounts();
                this.SymbolNames = GetStockSymbols(this.AccountNames.ElementAt(0));
                this.HistoricalQuotes = this.GetHistorialQuotesForSymbol(this.SymbolNames.ElementAt(0));
        }

        #region Event Handlers

        /// <summary>
        /// Is raised when an account is selected.
        /// </summary>
        /// <param name="stockName">Name of the stock.</param>
        void SelectedAccountEventHandler(string stockName)
        {
            this.HistoricalQuotes = this.GetHistorialQuotesForSymbol(stockName);
        }

        /// <summary>
        /// Is raised when the animation is activated/deactivated.
        /// </summary>
        /// <param name="CanApply">if set to <c>true</c> [can apply].</param>
       
        #endregion

        #region Properties

        

        /// <summary>
        /// Gets or sets the historical quotes.
        /// </summary>
        /// <value>The historical quotes.</value>
        public List<HistoricalQuotes> HistoricalQuotes
        {
            get
            {
                return historicalQuotes;
            }
            private set
            {
                if (this.historicalQuotes != value)
                {
                    this.historicalQuotes = value;

                    OnPropertyChanged("HistoricalQuotes");
                }
            }
        }

        /// <summary>
        /// Gets or sets the account names.
        /// </summary>
        /// <value>The account names.</value>
        public IEnumerable<string> AccountNames
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the symbol names.
        /// </summary>
        /// <value>The symbol names.</value>
        public IEnumerable<string> SymbolNames
        {
            get;
            private set;
        }

        bool open = false;
        public bool IsOpen
        {
            get
            {
                return open;
            }
            set
            {
                if (this.open != value)
                {
                    this.open = value;

                    OnPropertyChanged("IsOpen");
                }
            }
        }

        double offx = 0d;
        public double OffsetX
        {
            get
            {
                return offx;
            }
            set
            {
                if (this.offx != value)
                {
                    this.offx = value;

                    OnPropertyChanged("OffsetX");
                }
            }
        }

        double offy = 0d;
        public double OffsetY
        {
            get
            {
                return offy;
            }
            set
            {
                if (this.offy != value)
                {
                    this.offy = value;

                    OnPropertyChanged("OffsetY");
                }
            }
        }

        string date = string.Empty;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if (this.date != value)
                {
                    this.date = value;

                    OnPropertyChanged("Date");
                }
            }
        }

        string openval = string.Empty;
        public string Open
        {
            get
            {
                return openval;
            }
            set
            {
                if (this.openval != value)
                {
                    this.openval = value;

                    OnPropertyChanged("Open");
                }
            }
        }

        string closeval = string.Empty;
        public string Close
        {
            get
            {
                return closeval;
            }
            set
            {
                if (this.closeval != value)
                {
                    this.closeval = value;

                    OnPropertyChanged("Close");
                }
            }
        }

        string highval = string.Empty;
        public string High
        {
            get
            {
                return highval;
            }
            set
            {
                if (this.highval != value)
                {
                    this.highval = value;

                    OnPropertyChanged("High");
                }
            }
        }

        string lowval = string.Empty;
        public string Low
        {
            get
            {
                return lowval;
            }
            set
            {
                if (this.lowval != value)
                {
                    this.lowval = value;

                    OnPropertyChanged("Low");
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the historial quotes for symbol from the database.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns></returns>
        List<HistoricalQuotes> GetHistorialQuotesForSymbol(string symbol)
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(DataUtils.connString);

            return dataContext.HistoricalQuotes
                .Where(quotes => quotes.Symbol == symbol)
                .OrderBy(quotes => quotes.Date).ToList();
        }

        /// <summary>
        /// Gets the accounts from the database.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetAccounts()
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(DataUtils.connString);

            var accountNames = from accounts in dataContext.Accounts
                               orderby accounts.AccountName ascending
                               select accounts.AccountName;

            return accountNames as IEnumerable<string>;
        }

        /// <summary>
        /// Gets the stock symbols for the selected account from the database.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetStockSymbols(string accountName)
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(DataUtils.connString);

            var symbolname = from stocks in dataContext.Holdings
                             where stocks.Accounts.AccountName == accountName
                             select stocks.Quotes_Symbol;

            return symbolname as IEnumerable<string>;
        }

        #endregion 

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }

   
}