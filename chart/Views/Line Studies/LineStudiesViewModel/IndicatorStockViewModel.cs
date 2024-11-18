#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    public class IndicatorStockViewModel : INotifyPropertyChanged
    {
        private List<Stock> stocks;

        private string[] stockNames = { "GOOG", "ADI", "MACD" };

        private int stockID = 0;

        public IndicatorStockViewModel(int id)
        {
            stockID = id;
            LoadData();
        }

        void LoadData()
        {
            Stocks = GenerateStocks();
        }

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
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
