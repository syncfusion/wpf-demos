using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Practices.Composite.Events;
using PortfolioAnalyzer.Infrastructure;
using PortfolioAnalyzer.Model;
using Syncfusion.Windows.Chart;
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
        ChartColorPalette colorpalette = ChartColorPalette.Custom;
        ChartTypes type = ChartTypes.Pie;

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
            this.eventAggregator.GetEvent<AnimationEvents>().Subscribe(AnimationEventHandler);
            this.eventAggregator.GetEvent<ChartTypesEvent>().Subscribe(ChartTypeEventHandler);
            this.eventAggregator.GetEvent<SkinChangedEvent>().Subscribe(SkinChangedHandler);
            this.AccountNames = GetAccounts();
            this.SectorList = GetSectorNames(this.AccountNames.ElementAt(0).ToString());
            this.ExchangeList = GetExchangeNamesAndValues(this.AccountNames.ElementAt(0).ToString());
        }

        #region EventHandlers

        /// <summary>
        /// Represents the Skin changed event handler. Selects the appropriate Palette based on the parameter passed while publishing the event.
        /// </summary>
        /// <param name="SkinName">The Skin Name</param>
        void SkinChangedHandler(string SkinName)
        {
            switch (SkinName)
            {
                case "Blue":
                    Palette = ChartColorPalette.Office2007Blue;
                    break;
                case "Black":
                    Palette = ChartColorPalette.Office2007Black;
                    break;
                case "Silver":
                    Palette = ChartColorPalette.Office2007Silver;
                    break;
                case "Blend":
                    Palette = ChartColorPalette.Custom;
                    break;
            }
        }     

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
        /// Is raised when animation is activated or deactivated.
        /// </summary>
        /// <param name="CanApply">if set to <c>true</c> [can apply].</param>
        void AnimationEventHandler(bool CanApply)
        {
            if (CanApply)
            {
                this.ApplyAnimation = true;
            }
            else
            {
                this.ApplyAnimation = false;
            }
        }

        /// <summary>
        /// Is raised when ThreeD mode  is activated or deactivated.
        /// </summary>
        /// <param name="CanEnable">if set to <c>true</c> [can enable].</param>
        void ThreeDEventHandler(bool CanEnable)
        {
            if (CanEnable)
                this.EnableThreeD = true;
            else
                this.EnableThreeD = false;
        }

       
        void ChartTypeEventHandler(string type)
        {
            switch (type)
            {
                case "Pie":
                    ChartType = ChartTypes.Pie;
                    break;
                case "Funnel":
                    ChartType = ChartTypes.Funnel;
                    break;
                case "Doughnut":
                    ChartType = ChartTypes.Doughnut;
                    break;
                case "Pyramid":
                    ChartType = ChartTypes.Pyramid;
                    break;
            }
        }

        /// <summary>
        /// Gets or sets the type of the chart.
        /// </summary>
        /// <value>The type of the chart.</value>
        public ChartTypes ChartType
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
        /// Gets or sets the ChartColorPalette.
        /// </summary>
        /// <value>The ChartColorPalette.</value>
        public ChartColorPalette Palette
        {
            get
            {
                return colorpalette;
            }
            set
            {
                if (this.colorpalette != value)
                {
                    this.colorpalette = value;

                    OnPropertyChanged("Palette");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [apply animation].
        /// </summary>
        /// <value><c>true</c> if [apply animation]; otherwise, <c>false</c>.</value>
        public bool ApplyAnimation
        {
            get
            {
                return animate;
            }
            set
            {
                if (this.animate != value)
                {
                    this.animate = value;

                    OnPropertyChanged("ApplyAnimation");
                }
            }
        }

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
