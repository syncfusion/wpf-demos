#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Loads and exposes stock data for technical indicator demos.</summary>
    public class IndicatorStockViewModel : INotifyPropertyChanged , IDisposable
    {
        private List<Stock> stocks;

        private string[] stockNames = { "GOOG", "ADI", "MACD" };

        private int stockID = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndicatorStockViewModel"/> class with the given stock id.
        /// </summary>
        /// <param name="id">Represents the stock id</param>
        public IndicatorStockViewModel(int id)
        {
            stockID = id;
            LoadData();
        }

        void LoadData()
        {
            Stocks = GenerateStocks();
        }

        /// <summary>Gets or sets the list of stocks with parsed data.</summary>
        public List<Stock> Stocks
        {
            get
            {
                return stocks;
            }
            set
            {
                stocks = value;
                OnPropertyChanged("Stocks");
            }
        }

        /// <summary>Raises the PropertyChanged event for the specified property name.</summary>
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        List<Stock> GenerateStocks()
        {
            List<Stock> stocks = new List<Stock>();
            Stock stock = new Stock();

            string path = @"Assets\Chart\" + "INDICATOR_GOOG" + ".txt";
            stock.OrgDatas = GetDatas(path);
            stock.Datas = GetDatas(path);
            int count = stock.Datas.Count;
            stock.CurrentHigh = stock.Datas[count - 1].High;
            stock.CurrentLow = stock.Datas[count - 1].Low;
            stock.CurrentClose = stock.Datas[count - 1].Last;
            stock.PreviousClose = stock.Datas[count - 2].Last;
            stocks.Add(stock);
            return stocks;
        }

        /// <summary>Reads and parses stock data from a file.</summary>
        public static List<StockData> GetDatas(string fileName)
        {
            char[] comma = new char[] { ',' };
            char[] slashN = new char[] { '\n' };
            List<StockData> list = new List<StockData>();
            Random r = new Random();
            string s = File.ReadAllText(fileName);
            string[] lines = s.Split(slashN);
            bool firstLine = true;
            string[] values;
            int count = lines.Count() - 2;

            StockData priceInfo;
            int index = 0;
            foreach (string line in lines)
            {
                if (count != -1 && index >= count)
                    break;
                if (!firstLine)
                {
                    values = line.Split(comma);
                    if (values.GetLength(0) > 5)
                    {
                        priceInfo = new StockData()
                        {
                            TimeStamp = DateTime.Parse(values[0], CultureInfo.InvariantCulture),
                            Open = double.Parse(values[1]),
                            High = double.Parse(values[2]),
                            Low = double.Parse(values[3]),
                            Last = double.Parse(values[4]),
                            Volume = double.Parse(values[5])
                        };
                        list.Insert(index, priceInfo);
                        index++;
                    }
                }
                else
                {
                    firstLine = false;
                }
            }
            return list;
        }

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (Stocks != null)
                Stocks.Clear();
        }
    }
}
