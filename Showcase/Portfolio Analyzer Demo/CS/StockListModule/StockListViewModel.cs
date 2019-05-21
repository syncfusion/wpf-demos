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
using System.Timers;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using Microsoft.Practices.Composite.Regions;
using PortfolioAnalyzer.Data.Model;


namespace PortfolioAnalyzer.StockListModule
{
    /// <summary>
    /// Represents the StockListViewModel class which handles the interaction logic for StockListView.
    /// </summary>
    public class StockListViewModel :INotifyPropertyChanged
    {
        #region Class Members
        IEventAggregator eventAggregator;
        private ObservableCollection<Stocks> stockList;
        Stocks selectedStock;
        System.Windows.Forms.Timer t;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockListViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public StockListViewModel(IEventAggregator eventAggregator)
        {
                this.eventAggregator = eventAggregator;
                this.eventAggregator.GetEvent<Events>().Subscribe(SelectedAccountEventHandler);
                this.eventAggregator.GetEvent<StartStopUpdateEvent>().Subscribe(RealTimeUpdates);
                this.AccountNames = GetAccounts();
                this.StockList =  new ObservableCollection<Stocks>(GetHoldings(this.AccountNames.ElementAt(0)));                                
                this.SelectedStock = this.StockList[0];
        }

        #region EventHandlers
        BackgroundWorker worker = null;
        /// <summary>
        /// Is raised when an account is selected.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        void SelectedAccountEventHandler(string accountName)
        {
            if (this.IsVisible)
            {
                if (worker != null)
                {
                    worker.WorkerSupportsCancellation = true;
                    worker.DoWork -= new DoWorkEventHandler(worker_DoWork);
                    worker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                    worker.CancelAsync();
                }

                worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync(accountName);
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsBusy = false;
            this.StockList = e.Result as ObservableCollection<Stocks>;
            this.SelectedStock = this.StockList[0];
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsBusy = true;
            e.Result = new ObservableCollection<Stocks>(GetHoldings(e.Argument.ToString()));
        }

        /// <summary>
        /// Dynamically refreshes the stock list with real time data.
        /// </summary>
        /// <param name="start">if set to <c>true</c> [start].</param>
        void RealTimeUpdates(bool start)
        {
            if (start)
            {
                if (t == null)
                {
                    t = new System.Windows.Forms.Timer();
                    t.Interval = 30;
                    t.Tick += (object sender, EventArgs e) => StockUpdates();
                    t.Start();
                }
                else
                    t.Start();
            }
            else
                t.Stop();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the start real time updates DelegateCommand
        /// </summary>
        /// <value>The start real time updates.</value>
        public DelegateCommand<object> StartRealTimeUpdates { get; set; }

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
        /// Gets or sets the stock list.
        /// </summary>
        /// <value>The stock list.</value>
        public ObservableCollection<Stocks> StockList
        {
            get
            {
                return stockList;
            }
            private set
            {
                if (this.stockList != value)
                {
                    this.stockList = value;

                    OnPropertyChanged("StockList");
                }
            }
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged("IsBusy"); }
        }


        /// <summary>
        /// Gets or sets the selected stock.
        /// </summary>
        /// <value>The selected stock.</value>
        public Stocks SelectedStock
        {
            get
            {
                return selectedStock;
            }
            set
            {
                if (this.selectedStock != value && value != null)
                {
                    this.selectedStock = value;
                    this.OnPropertyChanged("SelectedStock");

                    this.eventAggregator.GetEvent<StockSelectedEvent>().Publish(value.Symbol);
                }
            }
        }
        /// <summary>
        /// Gets or sets if the view is visible
        /// </summary>
        public bool IsVisible { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the accounts from teh database.
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
        /// Gets the holdings for the selected account from the database.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <returns></returns>
        public static List<Stocks> GetHoldings(string accountName)
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(DataUtils.connString);
            dataContext.ObjectTrackingEnabled = false;

            var r = from stocks in dataContext.Holdings
                    where stocks.Accounts.AccountName == accountName
                    select new Stocks
                    {
                        Symbol = stocks.Quotes_Symbol,
                        CompanyName = stocks.Quotes.CompanyName,
                        Quantity = stocks.Quantity,
                        Price = stocks.PricePaid,
                        Change = stocks.Quotes.Change,
                        OpenPrince = stocks.Quotes.Open,
                        PercentChange = stocks.Quotes.PercentChange,
                        PurchaseDate = stocks.PurchaseDate,
                        IndustryName = stocks.Quotes.Industries.IndusrtyName,
                        SectorName = stocks.Quotes.Industries.Sectors.SectorName,
                        StockExchangeName = stocks.StockExchanges.StockExchangeName
                    };

            return r.ToList<Stocks>();
        }

     
       

        /// <summary>
        /// Updates the StockList
        /// </summary>
        void StockUpdates()
        {
            Random stock = new Random();
            var listIndex = stock.Next(0, this.StockList.Count / 3);

            Random percent = new Random();
            double? percentChange = percent.Next(6, 16) * 0.01;

            if (stock.Next(0, 2) == 0)
            {
                this.StockList[listIndex].Price += this.StockList[listIndex].Price * Convert.ToDecimal(percentChange);
                this.StockList[listIndex].Change = Convert.ToDouble(this.StockList[listIndex].Price - this.StockList[listIndex].OpenPrince);
                this.StockList[listIndex].PercentChange = Convert.ToDouble(((this.StockList[listIndex].Price - this.StockList[listIndex].OpenPrince) / this.StockList[listIndex].OpenPrince) * 100);
            }
            else
            {
                this.StockList[listIndex].Price -= this.StockList[listIndex].Price * Convert.ToDecimal(percentChange);
                this.StockList[listIndex].Change = Convert.ToDouble(this.StockList[listIndex].Price - this.StockList[listIndex].OpenPrince);
                this.StockList[listIndex].PercentChange = Convert.ToDouble(((this.StockList[listIndex].Price - this.StockList[listIndex].OpenPrince) / this.StockList[listIndex].OpenPrince) * 100);
            }
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

    /// <summary>
    /// Represents the Stock class. 
    /// </summary>
    public class Stocks : INotifyPropertyChanged
    {
        #region Class Members
        decimal? price;
        double? change;
        double? percentchange;
        #endregion

        #region Class Properties
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal? Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                this.OnPropertyChanged("Price");
            }
        }

        /// <summary>
        /// Gets or sets the open prince.
        /// </summary>
        /// <value>The open prince.</value>
        public decimal? OpenPrince { get; set; }

        /// <summary>
        /// Gets or sets the change.
        /// </summary>
        /// <value>The change.</value>
        public double? Change
        {
            get
            {
                return change;
            }
            set
            {
                change = value;
                this.OnPropertyChanged("Change");
            }
        }

        /// <summary>
        /// Gets or sets the percent change.
        /// </summary>
        /// <value>The percent change.</value>
        public double? PercentChange
        {
            get
            {
                return percentchange;
            }
            set
            {
                percentchange = value;
                this.OnPropertyChanged("PercentChange");
            }
        }

        /// <summary>
        /// Gets or sets the purchase date.
        /// </summary>
        /// <value>The purchase date.</value>
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the stock exchange.
        /// </summary>
        /// <value>The name of the stock exchange.</value>
        public string StockExchangeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the industry.
        /// </summary>
        /// <value>The name of the industry.</value>
        public string IndustryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the sector.
        /// </summary>
        /// <value>The name of the sector.</value>
        public string SectorName { get; set; }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
          if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}