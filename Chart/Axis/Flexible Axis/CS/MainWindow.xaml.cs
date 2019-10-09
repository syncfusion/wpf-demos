#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent(); 

            StockViewModel dataViewModel=new StockViewModel();
            grid1.DataContext = dataViewModel;
        }
    }

    public class StockViewModel : INotifyPropertyChanged
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

        Stock GenerateStocks()
        {
            Stock stock = new Stock();
            stock.StockName = stockNames[0];

            var Path = @"Data\" + stock.StockName + ".txt";

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

                        priceInfo.TimeStamp = DateTime.Parse(values[0],CultureInfo.InvariantCulture);
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

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Stock : INotifyPropertyChanged
    {
        public string StockName { get; set; }

        List<StockData> datas;

        public List<StockData> Datas
        {
            get
            {
                return datas;
            }
            set
            {
                datas = value;
                selectedStock = this;
                OnPropertyChanged("Datas");
            }
        }


        Stock selectedStock;
        public Stock SelectedStock
        {
            get
            {
                return selectedStock;
            }
            set
            {
                selectedStock = value;
                OnPropertyChanged("SelectedStock");
            }
        }

        private double currentLow;

        private double currentClose;

        private double currentHigh;

        public double CurrentLow
        {
            get
            {
                return currentLow;
            }
            set
            {
                currentLow = value;
                OnPropertyChanged("CurrentLow");
            }
        }

        public double CurrentHigh
        {
            get
            {
                return currentHigh;
            }
            set
            {
                currentHigh = value;
                OnPropertyChanged("CurrentHigh");
            }
        }

        public double CurrentClose
        {
            get
            {
                return currentClose;
            }
            set
            {
                currentClose = value;
                OnPropertyChanged("TodayClose");
            }
        }

        private double previousClose;

        public double PreviousClose
        {
            get
            {
                return previousClose;
            }
            set
            {
                previousClose = value;
                OnPropertyChanged("PreviousClose");
            }
        }

        private ObservableCollection<ChartSeries> indicatorsColln = new ObservableCollection<ChartSeries>();

        public ObservableCollection<ChartSeries> IndicatorsCollection
        {

            get
            {
                return indicatorsColln;
            }
            set
            {
                indicatorsColln = value;
                OnPropertyChanged("IndicatorsCollection");
            }
        }

        private string selindicator;

        public string SelectedIndicator
        {

            get
            {
                return selindicator;
            }
            set
            {
                selindicator = value;
                OnPropertyChanged("SelectedIndicator");
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class StockData
    {
        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public double Close { get; set; }

        public double Volume { get; set; }

        public DateTime TimeStamp { get; set; }
    }

}
