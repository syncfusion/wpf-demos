#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace StockAnalysis
{
    public class StockViewModel: INotifyPropertyChanged
    {
        private List<Stock> stocks;

        private string[] stockNames = { "GOOG", "MSFT", "AAPL", "NOK","SNE","IBM","INTC"};

        public StockViewModel()
        {
            LoadData();
            //stocks = GenerateStocks();
        }

        //async void LoadData()
        //{
        //    Stocks = await GenerateStocks();
        //}

        void LoadData()
        {
            Stocks =  GenerateStocks();
            //await Task.Delay(50);
            SelectedIndex = 1;
        }

        private int selectedIndex = 0;
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

                var Path = @"Data\" + stockName + ".txt";
                
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

    public class Stock : INotifyPropertyChanged
    {
        public Stock()
        {

        }

        public string StockName { get; set; }

        public List<StockData> OrgDatas
        {
            get;
            set;
        }

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


        ICommand updatePeriod;

        public ICommand UpdatePeriod
        {
            get
            {
                if (updatePeriod == null)
                {
                    updatePeriod = new UpdatePeriodCommand(this, Datas);
                    this.Datas = Datas;
                }
                return updatePeriod;
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

    public class ConcatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ChartCustomInfo obj = value as ChartCustomInfo;
            return  obj.LabelX +" "+"|"+" "+ obj.ValueX.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdatePeriodCommand : ICommand,INotifyPropertyChanged
    {

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
                Stock1.Datas = value;
                OnPropertyChanged("Datas");
            }
        }
        Stock Stock1;
        public UpdatePeriodCommand( Stock stock,List<StockData> datas)
        {
            Stock1 = stock;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add {}
            remove {}
        }

        public void Execute(object parameter)
        {
            var value = parameter as string;

            if (value == "5")
            {
                int count = Stock1.OrgDatas.Count;
                DateTime start = Stock1.OrgDatas[count - 1].TimeStamp;
                DateTime end = start.AddYears(-5);
                Datas = Stock1.OrgDatas.Where(x => x.TimeStamp < start && x.TimeStamp > end).ToList();
            }
            else if (value == "3")
            {
                int count = Stock1.OrgDatas.Count;
                DateTime start = Stock1.OrgDatas[count - 1].TimeStamp;
                DateTime end = start.AddYears(-3);
                Datas = Stock1.OrgDatas.Where(x => x.TimeStamp < start && x.TimeStamp > end).ToList();
            }
            else if (value == "2")
            {
                int count = Stock1.OrgDatas.Count;
                DateTime start = Stock1.OrgDatas[count - 1].TimeStamp;
                DateTime end = start.AddYears(-2);
                Datas = Stock1.OrgDatas.Where(x => x.TimeStamp < start && x.TimeStamp > end).ToList();
            }
            else
            {
                int count = Stock1.OrgDatas.Count;
                DateTime start = Stock1.OrgDatas[count - 1].TimeStamp;
                DateTime end = start.AddYears(1);
                Datas = Stock1.OrgDatas.Where(x => x.TimeStamp < start && x.TimeStamp > end).ToList();
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

    public class FillConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null && value!=null)
            {
                Stock data = value as Stock;
                if (data.CurrentClose < data.PreviousClose)
                    return new SolidColorBrush(Colors.Red);
                else
                    return new SolidColorBrush(Colors.Green);
            }
            //else
            //{ 
            //  if(parameter.ToString().Equals("High"))
            //      return new SolidColorBrush(Colors.Green);
            //  else
            //      return new SolidColorBrush(Colors.Red);
            //}
            return new SolidColorBrush(Colors.Red);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class RotateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Stock data = value as Stock;
            if (data!=null && data.CurrentClose < data.PreviousClose)
                return 0;
            else
                return 180;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TimeStampConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string time = ((DateTime)value).ToString(@"dd MMMM yyyy");
                return time;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
