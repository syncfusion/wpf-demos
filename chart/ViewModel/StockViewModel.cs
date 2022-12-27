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
using System.Linq;
using System.Globalization;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class StockViewModel : NotificationObject
    {
        private Stock stocks;

        private string[] stockNames = { "GOOG" };

        public StockViewModel()
        {
            LoadData();
        }

        void LoadData()
        {
            Stocks = GenerateStocks();
        }

        public Stock Stocks
        {
            get
            {
                return stocks;
            }
            set
            {
                stocks = value;
                RaisePropertyChanged(nameof(this.Stocks));
            }
        }

        Stock GenerateStocks()
        {
            Stock stock = new Stock();
            stock.StockName = stockNames[0];

            var Path = @"Assets\Chart\" + stock.StockName + ".txt";

            stock.Datas = GetDatas(Path);
            int count = stock.Datas.Count;
            stock.CurrentHigh = stock.Datas[count - 1].High;
            stock.CurrentLow = stock.Datas[count - 1].Low;
            stock.CurrentClose = stock.Datas[count - 1].Close;
            stock.PreviousClose = stock.Datas[count - 2].Close;
            return stock;
        }

        public static List<StockData> GetDatas(string fileName)
        {
            char[] comma = new char[] { '\t' };
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
                        priceInfo = new StockData();

                        priceInfo.TimeStamp = DateTime.Parse(values[0], CultureInfo.InvariantCulture);
                        priceInfo.Open = double.Parse(values[1]);
                        priceInfo.High = double.Parse(values[2]);
                        priceInfo.Low = double.Parse(values[3]);
                        priceInfo.Close = double.Parse(values[4]);
                        priceInfo.Volume = double.Parse(values[5]) / 10000;

                        list.Add(priceInfo);
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
    }
}
