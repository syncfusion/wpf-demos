#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.Windows.SampleLayout;
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
using Syncfusion.Windows.Tools.Controls;

namespace Indicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow

    {
        StockViewModel dataViewModel = new StockViewModel();
        
        public ObservableCollection<ChartSeries> indicatorsCollection = new ObservableCollection<ChartSeries>();
        
        public MainWindow()
        {
            InitializeComponent();
           this.DataContext = dataViewModel.Stocks;
            string[] technicalIndicators = { "Bollinger Band", "Accumulation Distribution", "Exponential Average", 
                                             "MACD", "Average True Range", "Momentum", "RSI", "Simple Average", "Stochastic",
                                             "Triangular Average"};
            Indicators.ItemsSource = technicalIndicators;
            Indicators.SelectedItem = technicalIndicators[0];
        }
    
        private void Indicators_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem == null)
                return;
            indicatorsCollection.Clear();
            this.SfChart.TechnicalIndicators.Clear();
            var indicator = Addindicator(comboBox.SelectedItem.ToString(), 1);
            if (indicator != null)
              {
                    indicatorsCollection.Add(indicator);
              }

            foreach (var item in indicatorsCollection)
            {
                ISupportAxes2D indicatorAxis = item as ISupportAxes2D;
                if (indicatorAxis != null)
                {
                    this.SfChart.TechnicalIndicators.Add(item);
                    NumericalAxis axis = new NumericalAxis();
                    axis.OpposedPosition = true;
                    axis.ShowGridLines = false;
                    axis.Visibility = Visibility.Collapsed;
                    indicatorAxis.YAxis = axis;
                }
            }  
        }

        private FinancialTechnicalIndicator Addindicator(string value, int rowIndex)
        {
            FinancialTechnicalIndicator indicator;
            switch (value)
            {
                case "Accumulation Distribution":
                    indicator = new AccumulationDistributionIndicator();
                    break;

                case "Average True Range":
                    indicator = new AverageTrueRangeIndicator()
                    {
                       Period = 1
                    };
                    break;

                case "Bollinger Band":
                    indicator = new BollingerBandIndicator()
                    {
                        UpperLineColor = Brushes.Green,
                        Period = 3
                    };
                    break;
                case "Exponential Average":
                    indicator = new ExponentialAverageIndicator();
                    break;

                case "MACD":
                    indicator = new MACDTechnicalIndicator()
                    {
                        Period = 5,
                        LongPeriod = 12,
                        ShortPeriod = 6,
                        ConvergenceLineColor = Brushes.Green
                    };
                    break;
                case "Momentum":
                    indicator = new MomentumTechnicalIndicator()
                    {
                       Period = 4
                    };
                    break;
                case "RSI":
                    indicator = new RSITechnicalIndicator()
                    {
                        Period = 4,
                        UpperLineColor = Brushes.Green
                    };
                    break;
                case "Simple Average":
                    indicator = new SimpleAverageIndicator();
                    break;
                case "Stochastic":
                    indicator = new StochasticTechnicalIndicator()
                    {
                      UpperLineColor  = Brushes.Green
                    };
                    break;
                case "Triangular Average":
                    indicator = new TriangularAverageIndicator();
                    break;
                default:
                    return null;
            }
            var index = rowIndex == 0 ? 1 : 0;
            ChartSeries Series = this.SfChart.VisibleSeries[index] as ChartSeries;
            indicator.XBindingPath = "TimeStamp";
            indicator.High = "High";
            indicator.Low = "Low";
            indicator.Open = "Open";
            indicator.Close = "Last";
            indicator.Volume = "Volume";
            Binding binding = new Binding();
            binding.Path = new PropertyPath("ItemsSource");
            binding.Source = Series;
            binding.Mode = BindingMode.TwoWay;
            indicator.SetBinding(FinancialTechnicalIndicator.ItemsSourceProperty, binding);

            return indicator;
        }
    }

    public class StockViewModel : INotifyPropertyChanged
    {
        private List<Stock> stocks;

        private string[] stockNames = { "GOOG" };

        public StockViewModel()
        {
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

            foreach (string stockName in stockNames)
            {
                Stock stock = new Stock();
                stock.StockName = stockName;

                var Path = @"Data\" + stockName + ".txt";

                stock.OrgDatas = GetDatas(Path);
                stock.Datas = GetDatas(Path);
                int count = stock.Datas.Count;
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
                OnPropertyChanged("Datas");
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
        public StockData()
        {

        }

        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public double Close { get; set; }

        public double Volume { get; set; }
        
        public double Last { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
