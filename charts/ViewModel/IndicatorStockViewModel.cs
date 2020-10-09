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
    public class IndicatorStockViewModel : NotificationObject
    {
        public string[] TechincalIndicatorsStringCollection
        {
            get
            {
                return new string[]{"Bollinger Band", "Accumulation Distribution", "Exponential Average",
                                    "MACD", "Average True Range", "Momentum", "RSI", "Simple Average", "Stochastic",
                                    "Triangular Average"};
            }
        }
        public ObservableCollection<ChartSeries> TechnicalIndicators { get; set; }
        public List<IndicatorStockDataModel> Datas { get; set; }
        public string SelectedIndicator
        {
            get
            {
                return selectedIndicator;
            }

            set
            {
                selectedIndicator = value;
                RaisePropertyChanged(nameof(this.SelectedIndicator));

                // Creating and adding the TechnicalIndicator to the collection.
                TechnicalIndicators.Clear();
                var indicator = Addindicator(selectedIndicator);
                TechnicalIndicators.Add(indicator);
            }
        }
        private string selectedIndicator;

        public IndicatorStockViewModel()
        {
            var path = @"Data/" + "INDICATOR_GOOG" + ".txt";
            Datas = GetDatas(path);
            TechnicalIndicators = new ObservableCollection<ChartSeries>();
            SelectedIndicator = "Bollinger Band";   
        }

        public static List<IndicatorStockDataModel> GetDatas(string fileName)
        {
            char[] comma = new char[] { ',' };
            char[] slashN = new char[] { '\n' };
            List<IndicatorStockDataModel> list = new List<IndicatorStockDataModel>();
            Random r = new Random();
            string s = File.ReadAllText(fileName);
            string[] lines = s.Split(slashN);
            bool firstLine = true;
            string[] values;
            int count = lines.Count() - 2;

            IndicatorStockDataModel priceInfo;
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
                        priceInfo = new IndicatorStockDataModel()
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

        private FinancialTechnicalIndicator Addindicator(string value)
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
                        UpperLineColor = Brushes.Green
                    };
                    break;

                case "Triangular Average":
                    indicator = new TriangularAverageIndicator();
                    break;

                default:
                    return null;
            }

            indicator.XBindingPath = "TimeStamp";
            indicator.High = "High";
            indicator.Low = "Low";
            indicator.Open = "Open";
            indicator.Close = "Last";
            indicator.Volume = "Volume";
            indicator.Interior = new SolidColorBrush(Color.FromRgb(0x87, 0x4D, 0xAF));
            Binding binding = new Binding();
            binding.Path = new PropertyPath("Datas");
            binding.Source = this;
            binding.Mode = BindingMode.TwoWay;
            indicator.SetBinding(FinancialTechnicalIndicator.ItemsSourceProperty, binding);

            ISupportAxes2D indicatorAxis = indicator as ISupportAxes2D;

            if (indicatorAxis != null)
            {
                NumericalAxis axis = new NumericalAxis();
                axis.OpposedPosition = true;
                axis.ShowGridLines = false;
                axis.Visibility = Visibility.Collapsed;
                indicatorAxis.YAxis = axis;
            }

            return indicator;
        }
    }
}
