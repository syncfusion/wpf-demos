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
using PortfolioAnalyzer.Model;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PortfolioAnalyzer.Infrastructure;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Input;
using PortfolioAnalyzer.Data.Model;
using Syncfusion.Data;

namespace PortfolioAnalyzer.PortfolioGridModule
{
    /// <summary>
    /// Represents the PortfolioGridViewModel class which handles the interaction logic for PortfolioGridView.
    /// </summary>
    public class PortfolioGridViewModel : INotifyPropertyChanged
    {
        #region Class Members
        IEventAggregator eventAggregator;
        Holdings selectedStock;
        private List<Stocks> stockList;
        public readonly static string connString = "Data Source=" + DataUtils.FindFile("PortfolioManagerDB.sdf");
        bool groupDropArea;
        ResourceDictionary financedictionary;
        string finance_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Finance.xaml";

        #endregion

        BackgroundWorker worker = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioGridViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public PortfolioGridViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<Events>().Subscribe(delegate(string accountName)
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
                   // this.StockList = GetHoldings(accountName);
                }
            });    

            this.eventAggregator.GetEvent<ShowHideGroupingEvent>().Subscribe(show => this.GroupDropArea = show);
            this.AccountNames = GetAccounts();
            this.StockList = GetHoldings(this.AccountNames.ElementAt(0));           
            financedictionary = new ResourceDictionary();
            financedictionary.Source = new Uri(finance_Key, UriKind.RelativeOrAbsolute);                 
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsBusy = false;
            this.StockList = (e.Result as ObservableCollection<Stocks>).ToList();
          //  this.SelectedStock = 
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsBusy = true;
            e.Result = new ObservableCollection<Stocks>(GetHoldings(e.Argument.ToString()));
        }


       
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged("IsBusy"); }
        }


        ///
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
        public List<Stocks> StockList
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

        /// <summary>
        /// Gets or sets the selected stock.
        /// </summary>
        /// <value>The selected stock.</value>
        public Holdings SelectedStock
        {
            get
            {
                return selectedStock;
            }
            set
            {
                if (this.selectedStock != value)
                {
                    this.selectedStock = value;
                    this.OnPropertyChanged("SelectedStock");
                    this.eventAggregator.GetEvent<StockSelectedEvent>().Publish(value.Quotes_Symbol);
                }
            }
        }

        /// <summary>
        /// Gets or sets the option to show GroupDropArea in the grid
        /// </summary>
        public bool GroupDropArea {
            get 
            {
                return this.groupDropArea;
            }
            set
            {
                this.groupDropArea = value;
                this.OnPropertyChanged("GroupDropArea");
            }
        }
        
        /// <summary>
        /// Gets or sets if the view is visible
        /// </summary>
        public bool IsVisible { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the holdings for the selected account from the database.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <returns></returns>
        public static List<Stocks> GetHoldings(string accountName)
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(connString);
            dataContext.ObjectTrackingEnabled = false;

            var r = from stocks in dataContext.Holdings
                    where stocks.Accounts.AccountName == accountName
                    select new Stocks
                    {
                        Symbol = stocks.Quotes_Symbol,
                        CompanyName = stocks.Quotes.CompanyName,
                        Quantity = stocks.Quantity,
                        Price = stocks.PricePaid,
                        PurchaseDate = stocks.PurchaseDate,
                        IndustryName = stocks.Quotes.Industries.IndusrtyName,
                        SectorName = stocks.Quotes.Industries.Sectors.SectorName,
                        StockExchangeName = stocks.StockExchanges.StockExchangeName,
                        QuoteChange = stocks.Quotes.Change,
                        QuotePercentChange = stocks.Quotes.PercentChange,
                        Volume = stocks.Quotes.Volume
                    };

            return r.ToList<Stocks>();
        }

        /// <summary>
        /// Gets the accounts from the database.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetAccounts()
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(connString);

            var accountNames = from accounts in dataContext.Accounts
                               orderby accounts.AccountName ascending
                               select accounts.AccountName;

            return accountNames as IEnumerable<string>;
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
    /// Represents the Stock details for the selected account
    /// </summary>
    public class Stocks
    {
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
        public decimal? Price { get; set; }

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

        /// <summary>
        /// Gets or sets the quote change.
        /// </summary>
        /// <value>The quote change.</value>
        public double? QuoteChange { get; set; }

        /// <summary>
        /// Gets or sets the quote percent change.
        /// </summary>
        /// <value>The quote percent change.</value>
        public double? QuotePercentChange { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        public double? Volume { get; set; }
    }
   

    /// <summary>
    /// Summarizes the change in the stock price in the current day.
    /// </summary>
    public class DayChangeSummary : ISummaryAggregate
    {

        public DayChangeSummary()
        {
        }

        /// <summary>
        /// Gets or sets the day change total.
        /// </summary>
        /// <value>The day change total.</value>
        public decimal? DayChangeTotal
        {
            get;
            set;
        }

        #region IGridDataSummaryAggregate Members

        /// <summary>
        /// Returns an Action delegate for the aggregate.
        /// </summary>
        /// <returns></returns>
         Action<System.Collections.IEnumerable, string, PropertyDescriptor>ISummaryAggregate.CalculateAggregateFunc()
        {
            return (items, property, pd) =>
            {
                // type cast to the underlying source, so we get to call the LINQ method directly
                var enumerableItems = items as IEnumerable<Stocks>;
                decimal? count = enumerableItems.Count();

                if (pd.Name == "DayChangeTotal")
                {
                    decimal? dayChange = 0;
                    foreach (Stocks stock in enumerableItems)
                    {
                        dayChange = dayChange + (stock.Price * stock.Quantity);
                    }

                    this.DayChangeTotal = dayChange / count;
                }
            };
        }
    }
        #endregion
        
    
}