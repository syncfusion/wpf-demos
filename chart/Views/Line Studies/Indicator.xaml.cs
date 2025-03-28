#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using syncfusion.demoscommon.wpf;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for Indicator.xaml
    /// </summary>
    public partial class Indicator : DemoControl
    {
        private IndicatorStockViewModel dataViewModel;

        public ObservableCollection<ChartSeries> indicatorsCollection = new ObservableCollection<ChartSeries>();
        public Indicator()
        {
            InitializeComponent();
            dataViewModel = new IndicatorStockViewModel(0);
            this.DataContext = dataViewModel.Stocks;
            this.sfchart.Series[0].ItemsSource = dataViewModel.Stocks[0].Datas;
            string[] technicalIndicators = {"MACD","Average True Range", "Accumulation Distribution", "Bollinger Band",
                                                "Exponential Average", "Momentum", "RSI", "Simple Average", "Stochastic",
                                                "Triangular Average"};
            Indicators.ItemsSource = technicalIndicators;
            Indicators.SelectedItem = technicalIndicators[0];

        }

        private void OnIndicatorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxAdv comboBox = sender as ComboBoxAdv;

            indicatorsCollection.Clear();
            this.sfchart.TechnicalIndicators.Clear();

            if (comboBox != null)
            {
                var indicator = Addindicator(comboBox.SelectedItem.ToString(), 1);
                if (indicator != null)
                {
                    indicatorsCollection.Add(indicator);
                }
            }

            foreach (var item in indicatorsCollection)
            {
                ISupportAxes2D indicatorAxis = item as ISupportAxes2D;
                if (indicatorAxis != null)
                {
                    this.sfchart.TechnicalIndicators.Add(item);
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
            string a = "";
            object obj = a;
            string b = (obj as string);
            switch (value)
            {
                case "Accumulation Distribution":
                    IndicatorStockViewModel model = new IndicatorStockViewModel(1);

                    DataContext = model.Stocks;
                    indicator = new AccumulationDistributionIndicator() { SignalLineColor = new SolidColorBrush(Colors.Blue) };
                    sfchart.Annotations.Clear();
                    TextAnnotation annotationAD = new TextAnnotation { Text = "High in Prices", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 22, Y1 = 30,};
                    TextAnnotation annotation2AD = new TextAnnotation { Text = "Decline in Prices", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 38, Y1 = 28,};
                    TextAnnotation annotation3AD = new TextAnnotation { Text = "Price is Trending Down", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 0.1, Y1 = 41.5,};

                    sfchart.Annotations.Add(annotationAD);
                    sfchart.Annotations.Add(annotation2AD);
                    sfchart.Annotations.Add(annotation3AD);
                    break;
                case "Average True Range":
                    IndicatorStockViewModel model9 = new IndicatorStockViewModel(1);

                    DataContext = model9.Stocks;
                    sfchart.Annotations.Clear();
                    indicator = new AverageTrueRangeIndicator()
                    {
                        SignalLineColor = new SolidColorBrush(Colors.Blue),
                        Period = 2
                    };
                    TextAnnotation annotationAT = new TextAnnotation { Text = "Buy Signal", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 6, Y1 = 37 };
                    TextAnnotation annotationAT1 = new TextAnnotation { Text = "Buy Signal", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 8, Y1 = 18 };
                    TextAnnotation annotationAT2 = new TextAnnotation { Text = "Sell Signal", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 20, Y1 = 24 };
                    TextAnnotation annotationAT3 = new TextAnnotation { Text = "Sell Signal", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 27.3, Y1 = 41 };
                    TextAnnotation annotationAT4 = new TextAnnotation { Text = "Average True Range" + "\n" + "Trailing Stops", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 35, Y1 = 22 };
                    sfchart.Annotations.Add(annotationAT);
                    sfchart.Annotations.Add(annotationAT1);
                    sfchart.Annotations.Add(annotationAT2);
                    sfchart.Annotations.Add(annotationAT3);
                    sfchart.Annotations.Add(annotationAT4);

                    break;
                case "Bollinger Band":
                    IndicatorStockViewModel model1 = new IndicatorStockViewModel(0);

                    DataContext = model1.Stocks;

                    indicator = new BollingerBandIndicator()
                    {
                        UpperLineColor = new SolidColorBrush(Colors.Green),
                        LowerLineColor = new SolidColorBrush(Colors.Red),
                        SignalLineColor = new SolidColorBrush(Colors.Transparent),
                        Period = 2
                    };

                    sfchart.Annotations.Clear();
                    TextAnnotation annotation = new TextAnnotation { Text = "Upper Bollinger Band", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 16, Y1 = 650 };
                    TextAnnotation annotation1 = new TextAnnotation { Text = "Sell Signal", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 33.7, Y1 = 690 };
                    TextAnnotation annotation2 = new TextAnnotation { Text = "Lower Bollinger Band", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 40, Y1 = 390 };
                    TextAnnotation annotation3 = new TextAnnotation { Text = "Buy Signal", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 7, Y1 = 230 };

                    sfchart.Annotations.Add(annotation);
                    sfchart.Annotations.Add(annotation1);
                    sfchart.Annotations.Add(annotation2);
                    sfchart.Annotations.Add(annotation3);
                    break;
                case "Exponential Average":
                    IndicatorStockViewModel model8 = new IndicatorStockViewModel(0);

                    DataContext = model8.Stocks;
                    indicator = new ExponentialAverageIndicator() { SignalLineColor = new SolidColorBrush(Colors.Blue) };
                    sfchart.Annotations.Clear();
                    TextAnnotation annotationE = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 7, Y1 = 700 };
                    TextAnnotation annotationE2 = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 8, Y1 = 260 };
                    TextAnnotation annotationE3 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 20, Y1 = 580 };
                    TextAnnotation annotationE4 = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 26, Y1 = 450 };
                    TextAnnotation annotationE5 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 35, Y1 = 660 };
                    TextAnnotation annotationE6 = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 40, Y1 = 460 };
                    TextAnnotation annotationE7 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 54, Y1 = 760 };

                    sfchart.Annotations.Add(annotationE);
                    sfchart.Annotations.Add(annotationE2);
                    sfchart.Annotations.Add(annotationE3);
                    sfchart.Annotations.Add(annotationE4);
                    sfchart.Annotations.Add(annotationE5);
                    sfchart.Annotations.Add(annotationE6);
                    sfchart.Annotations.Add(annotationE7);
                    break;
                case "MACD":
                    IndicatorStockViewModel model7 = new IndicatorStockViewModel(2);

                    DataContext = model7.Stocks;
                    sfchart.Annotations.Clear();
                    indicator = new MACDTechnicalIndicator()
                    {
                        Period = 5,
                        LongPeriod = 8,
                        ShortPeriod = 3,

                        SignalLineColor = new SolidColorBrush(Colors.Blue),
                        ConvergenceLineColor = new SolidColorBrush(Colors.Green),
                        DivergenceLineColor = new SolidColorBrush(Colors.Red)
                    };
                    TextAnnotation annotationMA = new TextAnnotation { Text = "MACD" + "\n" + "Sell Signals", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 17, Y1 = 700 };
                    TextAnnotation annotationMA1 = new TextAnnotation { Text = "MACD" + "\n" + "Buy Signals", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 2, Y1 = 400 };
                    TextAnnotation annotationMA2 = new TextAnnotation { Text = "Buy", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 10, Y1 = 250 };
                    TextAnnotation annotationMA3 = new TextAnnotation { Text = "Sell", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 24, Y1 = 620 };
                    TextAnnotation annotationMA4 = new TextAnnotation { Text = "Buy", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 30, Y1 = 450 };
                    TextAnnotation annotationMA5 = new TextAnnotation { Text = "Sell", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 48, Y1 = 650 };

                    sfchart.Annotations.Add(annotationMA);
                    sfchart.Annotations.Add(annotationMA1);
                    sfchart.Annotations.Add(annotationMA2);
                    sfchart.Annotations.Add(annotationMA3);
                    sfchart.Annotations.Add(annotationMA4);
                    sfchart.Annotations.Add(annotationMA5);
                    break;
                case "Momentum":
                    sfchart.Annotations.Clear();
                    IndicatorStockViewModel model6 = new IndicatorStockViewModel(2);

                    DataContext = model6.Stocks;
                    indicator = new MomentumTechnicalIndicator()
                    {
                        MomentumLineColor = new SolidColorBrush(Colors.Blue),

                        Period = 4
                    };
                    TextAnnotation annotationM = new TextAnnotation { Text = "Downtrend", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 0, Y1 = 353 };
                    TextAnnotation annotationM1 = new TextAnnotation { Text = "Buy", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 6.5, Y1 = 450 };
                    TextAnnotation annotationM2 = new TextAnnotation { Text = "Sell", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 21, Y1 = 530 };
                    TextAnnotation annotationM3 = new TextAnnotation { Text = "Divergence of Price" + "\n" + "& Momentum", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 36.5, Y1 = 357 };

                    sfchart.Annotations.Add(annotationM);
                    sfchart.Annotations.Add(annotationM1);
                    sfchart.Annotations.Add(annotationM2);
                    sfchart.Annotations.Add(annotationM3);
                    break;
                case "RSI":
                    IndicatorStockViewModel model5 = new IndicatorStockViewModel(2);

                    DataContext = model5.Stocks;
                    sfchart.Annotations.Clear();
                    indicator = new RSITechnicalIndicator()
                    {
                        SignalLineColor = new SolidColorBrush(Colors.Blue),
                        LowerLineColor = new SolidColorBrush(Colors.Red),
                        Period = 5,
                        UpperLineColor = new SolidColorBrush(Colors.Green)
                    };
                    TextAnnotation annotationRS = new TextAnnotation { Text = "Oversold", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 42, Y1 = 695 };
                    TextAnnotation annotationRS1 = new TextAnnotation { Text = "Overbought", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 0, Y1 = 380 };
                    TextAnnotation annotationRS2 = new TextAnnotation { Text = "Seller Territory" + "\n" + "(over 500)", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 10, Y1 = 600 };
                    TextAnnotation annotationRS3 = new TextAnnotation { Text = "Buyers Territory" + "\n" + "(below 500)", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 50, Y1 = 450 };

                    sfchart.Annotations.Add(annotationRS);
                    sfchart.Annotations.Add(annotationRS1);
                    sfchart.Annotations.Add(annotationRS2);
                    sfchart.Annotations.Add(annotationRS3);
                    break;
                case "Simple Average":
                    IndicatorStockViewModel model4 = new IndicatorStockViewModel(0);

                    DataContext = model4.Stocks;
                    sfchart.Annotations.Clear();
                    indicator = new SimpleAverageIndicator() { SignalLineColor = new SolidColorBrush(Colors.Blue) };
                    TextAnnotation annotationSA = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 0, Y1 = 405 };
                    TextAnnotation annotationSA1 = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 8, Y1 = 250 };
                    TextAnnotation annotationSA2 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 21, Y1 = 620 };
                    TextAnnotation annotationSA3 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 31, Y1 = 630 };
                    TextAnnotation annotationSA6 = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 40, Y1 = 475 };
                    TextAnnotation annotationSA7 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 54, Y1 = 760 };

                    sfchart.Annotations.Add(annotationSA);
                    sfchart.Annotations.Add(annotationSA1);
                    sfchart.Annotations.Add(annotationSA2);
                    sfchart.Annotations.Add(annotationSA3);
                    sfchart.Annotations.Add(annotationSA6);
                    sfchart.Annotations.Add(annotationSA7);
                    break;
                case "Stochastic":
                    sfchart.Annotations.Clear();
                    IndicatorStockViewModel model3 = new IndicatorStockViewModel(0);

                    DataContext = model3.Stocks;
                    indicator = new StochasticTechnicalIndicator()
                    {
                        SignalLineColor = new SolidColorBrush(Colors.Red),
                        UpperLineColor = new SolidColorBrush(Colors.Green),
                        Period = 3
                    };
                    TextAnnotation annotationS = new TextAnnotation { Text = "Lower Low", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 0.8, Y1 = 423, };
                    TextAnnotation annotationS1 = new TextAnnotation { Text = "Low#1", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = -0.6, Y1 = 400 };
                    TextAnnotation annotationS2 = new TextAnnotation { Text = "Low#2", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 8, Y1 = 243 };
                    TextAnnotation annotationS5 = new TextAnnotation { Text = "High#2", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 271, Y1 = 650 };
                    TextAnnotation annotationS6 = new TextAnnotation { Text = "High#1", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 5, Y1 = 370 };
                    TextAnnotation annotationS7 = new TextAnnotation { Text = "Higher Low", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 38, Y1 = 710,};
                    TextAnnotation annotationS8 = new TextAnnotation { Text = "Low#3", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 30, Y1 = 696 };
                    TextAnnotation annotationS9 = new TextAnnotation { Text = "Low#4", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 48, Y1 = 200 };

                    sfchart.Annotations.Add(annotationS);
                    sfchart.Annotations.Add(annotationS1);
                    sfchart.Annotations.Add(annotationS2);
                    sfchart.Annotations.Add(annotationS5);
                    sfchart.Annotations.Add(annotationS6);
                    sfchart.Annotations.Add(annotationS7);
                    sfchart.Annotations.Add(annotationS8);
                    sfchart.Annotations.Add(annotationS9);
                    break;
                case "Triangular Average":
                    IndicatorStockViewModel model2 = new IndicatorStockViewModel(0);

                    DataContext = model2.Stocks;
                    sfchart.Annotations.Clear();
                    indicator = new TriangularAverageIndicator() { SignalLineColor = new SolidColorBrush(Colors.Blue) };
                    TextAnnotation annotationT = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 2, Y1 = 400 };
                    TextAnnotation annotationT1 = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 8, Y1 = 250 };
                    TextAnnotation annotationT2 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 21, Y1 = 620 };
                    TextAnnotation annotationT3 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 31, Y1 = 630 };
                    TextAnnotation annotationT6 = new TextAnnotation { Text = "BUY", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 40, Y1 = 475 };
                    TextAnnotation annotationT7 = new TextAnnotation { Text = "SELL", Foreground = new SolidColorBrush(Color.FromRgb(170, 104, 67)), CoordinateUnit = CoordinateUnit.Axis, X1 = 54, Y1 = 760 };

                    sfchart.Annotations.Add(annotationT);
                    sfchart.Annotations.Add(annotationT1);
                    sfchart.Annotations.Add(annotationT2);
                    sfchart.Annotations.Add(annotationT3);
                    sfchart.Annotations.Add(annotationT6);
                    sfchart.Annotations.Add(annotationT7);
                    break;
                default:
                    return null;
            }
            var index = rowIndex == 0 ? 1 : 0;
            ChartSeries Series = this.sfchart.VisibleSeries[index] as ChartSeries;
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

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext is IndicatorStockViewModel && (this.DataContext as IndicatorStockViewModel).Stocks != null)
            {
                (this.DataContext as IndicatorStockViewModel).Stocks.Clear();
            }

            if (sfchart != null)
            {
                foreach (var series in sfchart.Series)
                {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
                foreach (var series in sfchart.TechnicalIndicators)
                {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }

                sfchart.Dispose();
                sfchart = null;
            }

            this.grid.Resources = null;
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}
