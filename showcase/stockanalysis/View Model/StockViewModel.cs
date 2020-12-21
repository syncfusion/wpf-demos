#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace syncfusion.stockanalysisdemo.wpf
{
    public class StockViewModel: INotifyPropertyChanged
    {
        private List<Stock> stocks;
        private int selectedIndex = 0;
        private ICommand loadedCommand;
        private string[] stockNames = { "GOOG", "MSFT", "AAPL", "NOK","SNE","IBM","INTC"};

        public StockViewModel()
        {
            loadedCommand = new DelegateCommand<object>(WindowLoaded);
            LoadData();
        }

        void LoadData()
        {
            Stocks =  GenerateStocks();
            SelectedIndex = 1;
        }

        public void WindowLoaded(object param)
        {
            TileViewControl tileView = param as TileViewControl;
            if (tileView != null)
            {
                TileViewItem tile = tileView.ItemContainerGenerator.ContainerFromIndex(0) as TileViewItem;
                if (tile != null)
                {
                    tile.TileViewItemState = TileViewItemState.Maximized;
                }
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                return loadedCommand;
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
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

            foreach (string stockName in stockNames)
            {
                Stock stock = new Stock();
                stock.StockName = stockName;

                var Path = @"Assets\stockanalysis\" + stockName + ".txt";
                
                stock.OrgDatas = GetDatas(Path);
                stock.Datas = GetDatas(Path);
                int count=stock.Datas.Count;
                stock.CurrentHigh = stock.Datas[count - 1].High;
                stock.CurrentLow = stock.Datas[count - 1].Low;
                stock.CurrentClose = stock.Datas[count - 1].Last;
                stock.PreviousClose = stock.Datas[count - 2].Last;
                stocks.Add(stock);
            }

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
