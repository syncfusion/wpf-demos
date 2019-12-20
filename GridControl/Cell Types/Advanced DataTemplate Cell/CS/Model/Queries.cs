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
using PortfolioManager1.Model;
using Syncfusion.Windows.Controls.Grid;

namespace PortfolioManager1
{
    public class Queries
    {
        public static string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("PortfolioManagerDB.sdf"));
        public static PortfolioManagerDB DB = new PortfolioManagerDB(connectionString);

        public class CurrentHoldings
        {
            public int HoldingID { get; set; }
            public bool? Open { get; set; }
            public string Quotes_Symbol { get; set; }
            public string Quote_CompanyName { get; set; }
            public decimal? PricePaid { get; set; }
            public decimal? Quantity { get; set; }
            public double? Quote_Change { get; set; }
            public double? DayChange { get; set; }
            public double? Quote___Change { get; set; }
            public string Account_AccountName { get; set; }
            public string Quote_Industry_Sector_SectorName { get; set; }
            public string Quote_Industry_IndusrtyName { get; set; }
            public string StockExchange_StockExchangeName { get; set; }
            public decimal? Quote_Price { get; set; }
            public decimal? MarketValue { get; set; }
            public decimal? TotalReturn { get; set; }
        }

        public static List<CurrentHoldings> GetHoldingsList()
        {
            DB.ObjectTrackingEnabled = false;

            var holding = from holdings in DB.Holdings
                          select new CurrentHoldings
                          {
                              HoldingID = holdings.HoldingID,
                              Open = holdings.Open,
                              Quotes_Symbol = holdings.Quotes_Symbol,
                              Quote_CompanyName = holdings.Quotes.CompanyName,
                              PricePaid = holdings.PricePaid,
                              Quantity = holdings.Quantity,
                              Quote_Change = holdings.Quotes.Change,
                              DayChange = holdings.Quotes.Change * (double?)holdings.Quantity,
                              Quote___Change = holdings.Quotes.PercentChange,
                              Account_AccountName = holdings.Accounts.AccountName,
                              Quote_Industry_Sector_SectorName = holdings.Quotes.Industries.Sectors.SectorName,
                              Quote_Industry_IndusrtyName = holdings.Quotes.Industries.IndusrtyName,
                              StockExchange_StockExchangeName = holdings.StockExchanges.StockExchangeName,
                              Quote_Price = holdings.Quotes.Price,
                              MarketValue = holdings.Quotes.Price * holdings.Quantity,
                              TotalReturn = holdings.Quotes.Price * holdings.Quantity - holdings.PricePaid * holdings.Quantity
                          };

            return holding.ToList<CurrentHoldings>();
        }

        public class DateAssetValue
        {
            public DateTime Date { get; set; }
            public Decimal? AssetValue { get; set; }
        }

        public static List<DateAssetValue> GetDateAndAssetValue(string AccoutName, DateTime MinDate, DateTime MaxDate)
        {
             string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("PortfolioManagerDB.sdf"));
            using (PortfolioManagerDB DB = new PortfolioManagerDB(connectionString))
            {
                DB.ObjectTrackingEnabled = false;

                List<DateAssetValue> list = new List<DateAssetValue>();

                var Dates = from hist in DB.HistoricalQuotes
                            where hist.Date > MinDate
                            where hist.Date <= MaxDate
                            group hist by hist.Date into date
                            orderby date.Key descending
                            select new { date.Key };

                foreach (var Date in Dates)
                {
                    DateTime date = DateTime.Parse(Date.Key.ToString());

                    var w = from holdings in DB.Holdings.Where(acct => acct.Accounts.AccountName == AccoutName)
                            join histQuotes in DB.HistoricalQuotes.Where(histQuotes => histQuotes.Date == date)
                            on holdings.Quotes_Symbol equals histQuotes.Symbol
                            group (holdings.Quantity * histQuotes.Close) by AccoutName into AssetValueAtDate
                            select new
                            {
                                Value = AssetValueAtDate.Sum()
                            };

                    Decimal? AssetValue = 0;
                    AssetValue = w.SingleOrDefault().Value;

                    DateAssetValue value = new DateAssetValue() { Date = date, AssetValue = AssetValue };
                    list.Add(value);
                }

                return list;
            }
        }

        public class AcountNameAndValue
        {
            public string AccountName { get; set; }
            public Decimal? AssetValue { get; set; }
        }

        public static List<AcountNameAndValue> GetAcountNameAndValue()
        {
            var acctValue = from acct in DB.Accounts
                            select new AcountNameAndValue
                            {
                                AccountName = acct.AccountName,
                                AssetValue = acct.AssetBalance
                            };

            return acctValue.ToList<AcountNameAndValue>();
        }

        public class ExchangeAndValue
        {
            public string ExchangeName { get; set; }
            public Decimal? Value { get; set; }
        }

        public static List<ExchangeAndValue> GetExchangeNamesAndValues(int accountID)
        {
            var Exchanges = from holdings in DB.Holdings
                            where holdings.Accounts_AccountID == accountID
                            group (holdings.PricePaid * holdings.Quantity) by holdings.StockExchanges.Country into exchanges
                            select new ExchangeAndValue
                            {
                                ExchangeName = exchanges.Key,
                                Value = exchanges.Sum()
                            };

            return Exchanges.ToList<ExchangeAndValue>();
        }
    }
}