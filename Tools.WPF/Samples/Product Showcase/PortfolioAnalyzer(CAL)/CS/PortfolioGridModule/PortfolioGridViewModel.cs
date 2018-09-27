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
using Syncfusion.Windows.Controls.Grid;
using PortfolioAnalyzer.Infrastructure;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using Syncfusion.Windows.Data;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Input;
using Syncfusion.Windows.ComponentModel;
using PortfolioAnalyzer.Data.Model;

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
                    this.StockList = GetHoldings(accountName);
            });    
            this.eventAggregator.GetEvent<ShowHideGroupingEvent>().Subscribe(show => this.GroupDropArea = show);
            this.AccountNames = GetAccounts();
            this.StockList = GetHoldings(this.AccountNames.ElementAt(0));
            this.SectorGridQueryCellStyleInfo = new DelegateCommand<GridQueryCellInfoEventArgs>(OnSectorGridQueryCellStyleInfo);
            this.StockExchangeGridQueryCellStyleInfo = new DelegateCommand<GridQueryCellInfoEventArgs>(OnStockExchangeGridQueryCellStyleInfo);
            this.ItemsSourceChanged = new DelegateCommand<SyncfusionRoutedEventArgs>(OnItemsSourceChanged);
            financedictionary = new ResourceDictionary();
            financedictionary.Source = new Uri(finance_Key, UriKind.RelativeOrAbsolute);                 
        }

        #region EventHandlers

        private void OnSectorGridQueryCellStyleInfo(GridQueryCellInfoEventArgs args)
        {   
            var style = args.Style as GridDataStyleInfo;
            var tableStyleIdentity = style.CellIdentity;

            #region conditional formatting of group summaries
            if (tableStyleIdentity.TableCellType == GridDataTableCellType.GroupCaptionSummaryRecordCell)
            {
                if (tableStyleIdentity.SummaryColumn != null)
                {
                    if (tableStyleIdentity.SummaryColumn.Name == "QuoteChange")
                    {
                        var value = tableStyleIdentity.GridModel.GetGroupCaptionSummary(tableStyleIdentity.Group, tableStyleIdentity.SummaryColumn);
                        double result;
                        if (value["DayChangeTotal"] != null)
                        {
                            Double.TryParse(value["DayChangeTotal"].ToString(), out result);

                            if (result > 0)
                            {
                                args.Style.Foreground = Brushes.Green;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceUp"] };                             
                            }
                            else
                            {
                                args.Style.Foreground = Brushes.Red;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceDown"] };                                
                            }
                        }
                    }
                    else if (tableStyleIdentity.SummaryColumn.Name == "QuotePercentChange")
                    {
                        var value = tableStyleIdentity.GridModel.GetGroupCaptionSummary(tableStyleIdentity.Group, tableStyleIdentity.SummaryColumn);
                        double result;
                        if (value["Average"] != null)
                        {
                            Double.TryParse(value["Average"].ToString(), out result);

                            if (result > 0)
                            {
                                args.Style.Foreground = Brushes.Green;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceUp"] };                                
                            }
                            else
                            {
                                args.Style.Foreground = Brushes.Red;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceDown"] };                                
                            }
                        }
                    }
                }

                style.ImageHeight = new GridLength(0.85, GridUnitType.Star);
                style.ImageWidth = new GridLength(0.15, GridUnitType.Star);
                style.ImageMargins = new Syncfusion.Windows.Controls.Cells.CellMarginsInfo(10, 2, 0, 2);
            }
            #endregion
        }

        private void OnStockExchangeGridQueryCellStyleInfo(GridQueryCellInfoEventArgs args)
        {
            var style = args.Style as GridDataStyleInfo;
            var tableStyleIdentity = style.CellIdentity;

            #region conidtional formatting of group summaries
            if (tableStyleIdentity.TableCellType == GridDataTableCellType.GroupCaptionSummaryRecordCell)
            {
                if (tableStyleIdentity.SummaryColumn != null)
                {
                    if (tableStyleIdentity.SummaryColumn.Name == "QuoteChange")
                    {
                        var value = tableStyleIdentity.GridModel.GetGroupCaptionSummary(tableStyleIdentity.Group, tableStyleIdentity.SummaryColumn);
                        double result;
                        if (value["DayChangeTotal"] != null)
                        {
                            Double.TryParse(value["DayChangeTotal"].ToString(), out result);

                            if (result > 0)
                            {
                                args.Style.Foreground = Brushes.Green;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceUp"] };                                
                            }
                            else
                            {
                                args.Style.Foreground = Brushes.Red;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceDown"] };                                
                            }
                        }
                    }
                    else if (tableStyleIdentity.SummaryColumn.Name == "QuotePercentChange")
                    {
                        var value = tableStyleIdentity.GridModel.GetGroupCaptionSummary(tableStyleIdentity.Group, tableStyleIdentity.SummaryColumn);
                        double result;
                        if (value["Average"] != null)
                        {
                            Double.TryParse(value["Average"].ToString(), out result);

                            if (result > 0)
                            {
                                args.Style.Foreground = Brushes.Green;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceUp"] };                                
                            }
                            else
                            {
                                args.Style.Foreground = Brushes.Red;
                                style.Image = new Image() { Source = (DrawingImage)financedictionary["PriceDown"] };                                
                            }
                        }
                    }

                    style.ImageContentAlignment = ImageContentAlignment.Left;
                    style.ImageHeight = new GridLength(0.85, GridUnitType.Star);
                    style.ImageWidth = new GridLength(0.15, GridUnitType.Star);
                    style.ImageMargins = new Syncfusion.Windows.Controls.Cells.CellMarginsInfo(10, 1, 0, 1);
                }
            }

            #endregion
        }

        private void OnItemsSourceChanged(SyncfusionRoutedEventArgs args)
        {
            GridDataControl grid = args.Source as GridDataControl;
            if (grid.GroupedColumns.Count > 0)
                grid.Model.Table.ExpandAllGroupsAtLevel(1);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the sector grid's QueryCellStyleInfo event handler
        /// </summary>
        public DelegateCommand<GridQueryCellInfoEventArgs> SectorGridQueryCellStyleInfo { get; set; }

        /// <summary>
        /// Gets or sets the stockexchange grid's QueryCellStyleInfo event handler
        /// </summary>
        public DelegateCommand<GridQueryCellInfoEventArgs> StockExchangeGridQueryCellStyleInfo { get; set; }

        /// <summary>
        /// Gets or sets the grid's ItemsSourceChanged event handler
        /// </summary>
        public DelegateCommand<SyncfusionRoutedEventArgs> ItemsSourceChanged { get; set; }

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
    /// Grouped Column Collection
    /// </summary>
    public class GroupedColumnCollection : FreezableCollection<GridDataGroupColumn>
    {
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
        public Action<System.Collections.IEnumerable, string, PropertyDescriptor> CalculateAggregateFunc()
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

        #endregion
    }
}