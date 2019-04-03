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
using Microsoft.Practices.Composite.Events;
using PortfolioAnalyzer.Infrastructure;
using PortfolioAnalyzer.Model;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PortfolioAnalyzer.Data.Model;


namespace PortfolioAnalyzer.CountrySectorChartModule
{
    /// <summary>
    /// Represents the CountrySectorChartViewModel class which handles the interaction logic for CountrySectorChartView.
    /// </summary>
    public class CountrySectorChartViewModel : INotifyPropertyChanged
    {
        #region Members
        IEventAggregator eventAggregator;
        bool animate;
        bool applyThreeD;
        private List<SectorAndValue> sectorList;
        private List<ExchangeAndValue> exchangeList;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CountrySectorChartViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public CountrySectorChartViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<Events>().Subscribe(SelectedAccountEventHandler);
            this.eventAggregator.GetEvent<ThreeDEvent>().Subscribe(ThreeDEventHandler);
            this.eventAggregator.GetEvent<ChartTypesEvent>().Subscribe(ChartTypeEventHandler);
            this.AccountNames = GetAccounts();
            this.SectorList = GetSectorNames(this.AccountNames.ElementAt(0).ToString());
            this.ExchangeList = GetExchangeNamesAndValues(this.AccountNames.ElementAt(0).ToString());
        }

        #region EventHandlers


        /// <summary>
        /// Is raised when an account is selected.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        void SelectedAccountEventHandler(string accountName)
        {
            if (this.IsVisible)
            {
                this.SectorList = GetSectorNames(accountName);
                this.ExchangeList = GetExchangeNamesAndValues(accountName);
            }
        }

        /// <summary>
        /// Is raised when ThreeD mode  is activated or deactivated.
        /// </summary>
        /// <param name="CanEnable">if set to <c>true</c> [can enable].</param>
        void ThreeDEventHandler(bool CanEnable)
        {
            if (CanEnable)
            {
                if(ChartType.GetType().Name=="PieChart")
                {
                    ChartType=new PieChart3D();
                }
                else if(ChartType.GetType().Name=="Doughnut")
                {
                    ChartType=new Doughnut3D();
                }
                this.EnableThreeD = true;
            }
            else
            {
                if (ChartType.GetType().Name == "PieChart3D")
                {
                    ChartType = new PieChart();
                }
                else if (ChartType.GetType().Name == "Doughnut3D")
                {
                    ChartType = new Doughnut();
                }
                this.EnableThreeD = false;
            }
        }

       
        void ChartTypeEventHandler(string type)
        {
            switch (type)
            {
                case "Pie":
                    if (this.EnableThreeD)
                        ChartType = new PieChart3D();
                    else
                          ChartType = new PieChart();
                    break;
                case "Funnel":
                    ChartType = new Funnel();
                    break;
                case "Doughnut":
                    if (this.EnableThreeD)
                        ChartType = new Doughnut3D();
                    else
                        ChartType = new Doughnut();
                    break;
                case "Pyramid":
                    ChartType = new Pyramid();
                    break;
            }
        }

        /// <summary>
        /// Gets or sets the type of the chart.
        /// </summary>

        private UserControl type = new PieChart();
        public UserControl ChartType
        {
            get
            {
                return type;
            }
            set
            {
                if (this.type != value)
                {
                    this.type = value;

                    OnPropertyChanged("ChartType");
                }
            }
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets a value indicating whether to enable ThreeD mode.
        /// </summary>
        /// <value><c>true</c> if [enable three D]; otherwise, <c>false</c>.</value>
        public bool EnableThreeD
        {
            get
            {
                return applyThreeD;
            }
            set
            {
                if (this.applyThreeD != value)
                {
                    this.applyThreeD = value;

                    OnPropertyChanged("EnableThreeD");
                }
            }
        }

        /// <summary>
        /// Gets or sets the sector list.
        /// </summary>
        /// <value>The sector list.</value>
        public List<SectorAndValue> SectorList
        {
            get
            {
                return sectorList;
            }
            private set
            {
                if (this.sectorList != value)
                {
                    this.sectorList = value;

                    OnPropertyChanged("SectorList");
                }
            }
        }


        /// <summary>
        /// Gets or sets the StockExchange list.
        /// </summary>
        /// <value>The exchange list.</value>
        public List<ExchangeAndValue> ExchangeList
        {
            get
            {
                return exchangeList;
            }
            private set
            {
                if (this.exchangeList != value)
                {
                    this.exchangeList = value;

                    OnPropertyChanged("ExchangeList");
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
        /// Gets or sets if the view is visible
        /// </summary>
        public bool IsVisible { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Gets the StockExchange names and values.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <returns></returns>
        List<ExchangeAndValue> GetExchangeNamesAndValues(string accountName)
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(DataUtils.connString);

            var Exchanges = from holdings in dataContext.Holdings
                            where holdings.Accounts.AccountName == accountName
                            group (holdings.PricePaid * holdings.Quantity) by holdings.StockExchanges.Country into exchanges
                            select new ExchangeAndValue
                            {
                                ExchangeName = exchanges.Key,
                                Value = exchanges.Sum()
                            };

            return Exchanges.ToList<ExchangeAndValue>();
        }


        /// <summary>
        /// Gets the sector names of the selected account from the database .
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <returns></returns>
         List<SectorAndValue> GetSectorNames(string accountName)
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(DataUtils.connString);
                          
            var Sectors = from stocks in dataContext.Holdings
                          where stocks.Accounts.AccountName == accountName
                          group (stocks.PricePaid * stocks.Quantity) by stocks.Quotes.Industries.Sectors.SectorName into sectors
                          select new SectorAndValue
                          {
                              SectorName = sectors.Key,
                              Value = sectors.Sum()
                          };

            return Sectors.ToList<SectorAndValue>();
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
