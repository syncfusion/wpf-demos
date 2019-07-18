#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace StockAnalysis
{
    public class ChartTechnicalIndicatorBehavior:ChartBehavior
    {

       // ComboBox IndicatorSource1=new ComboBox();

        ComboBoxAdv IndicatorSource2 = new ComboBoxAdv();

        
       // TextBlock TextSource1 = new TextBlock();

        TextBlock TextSource2 = new TextBlock();
  

        public ObservableCollection<ChartSeries> indicatorsCollection = new ObservableCollection<ChartSeries>();

        public ChartTechnicalIndicatorBehavior()
        {
            TextSource2.ToolTip = "Highest Stock Value";
            
        }

        string[] technicalIndicators = {"AverageTrueRangeIndicator","AccumulationDistributionIndicator", "BollingerBandIndicator", "ExponentialAverageIndicator",
                                              "MACDTechnicalIndicator","MomentumTechnicalIndicator","RSITechnicalIndicator","SimpleAverageIndicator","StochasticTechnicalIndicator","TriangularAverageIndicator"};

        public string[] TechnicalIndicators
        {
            get
            {
                return technicalIndicators;
            }
        }

        protected override void AttachElements()
        {
         
            IndicatorSource2.Width = 160;
            IndicatorSource2.Height = 35;
            IndicatorSource2.ItemsSource = TechnicalIndicators;
            IndicatorSource2.SelectionChanged += IndicatorSource2_SelectionChanged;
            IndicatorSource2.AllowMultiSelect = true;
            IndicatorSource2.DefaultText ="--Add Indicators--";
            this.AdorningCanvas.Children.Add(IndicatorSource2);
            this.AdorningCanvas.Children.Add(TextSource2);
            this.ChartArea.SizeChanged += ChartArea_SizeChanged;
            
        }

        private FinancialTechnicalIndicator Addindicator(string value,int rowIndex)
        {
            FinancialTechnicalIndicator indic;
            switch (value)
            {
                case "AccumulationDistributionIndicator":
                        indic = new AccumulationDistributionIndicator();
                        break;

                case "AverageTrueRangeIndicator":
                        indic = new AverageTrueRangeIndicator();
                        break;

                case "BollingerBandIndicator":
                        indic = new BollingerBandIndicator();
                        break;
                case "ExponentialAverageIndicator":
                         indic = new ExponentialAverageIndicator();
                        break;

                case "MACDTechnicalIndicator":
                        indic = new MACDTechnicalIndicator();
                        break;
                case "MomentumTechnicalIndicator":
                        indic = new MomentumTechnicalIndicator();
                        break;
                case "RSITechnicalIndicator":
                        indic = new RSITechnicalIndicator();
                        break;
                case "SimpleAverageIndicator":

                        indic = new SimpleAverageIndicator();
                        break;
                case "StochasticTechnicalIndicator":
                        indic = new StochasticTechnicalIndicator();
                       break;
                case "TriangularAverageIndicator":
                        indic = new TriangularAverageIndicator();
                       break;
                default:
                    return null;
            }
                var index = rowIndex == 0 ? 1 : 0;
                ChartSeries Series = this.ChartArea.VisibleSeries[index] as ChartSeries;
                indic.XBindingPath = "TimeStamp";
                indic.High = "High";
                indic.Low = "Low";
                indic.Open = "Open";
                indic.Close = "Last";
                indic.Volume = "Volume";
                Binding binding = new Binding();
                binding.Path = new PropertyPath("ItemsSource");
                binding.Source = Series;
                binding.Mode = BindingMode.TwoWay;
                indic.SetBinding(FinancialTechnicalIndicator.ItemsSourceProperty, binding);
               
                if (rowIndex == 0)
                {
                    var supportAxes = this.ChartArea.VisibleSeries[1] as ISupportAxes;
                    if (supportAxes != null)
                        indic.YAxis = supportAxes.ActualYAxis as RangeAxisBase;
                    indic.YAxis.ShowGridLines = false;
                    SfChart.SetRow(indic.YAxis, 1);
                }
                else
                {
                    indic.YAxis = this.ChartArea.SecondaryAxis;
                    SfChart.SetRow(indic.YAxis, 0);
                }
                return indic;
        }

        void IndicatorSource2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indicatorsCollection.Clear();
            this.ChartArea.TechnicalIndicators.Clear();
            foreach(var indi in IndicatorSource2.SelectedItems)
            {
                  var indicator = Addindicator((string)indi, 1);
                  if (indicator != null)
                  {
                      indicatorsCollection.Add(indicator);
                  }
            }

            foreach (var item in indicatorsCollection)
            {
                ISupportAxes2D indicatorAxis = item as ISupportAxes2D;
                    var index = SfChart.GetRow(indicatorAxis.YAxis);
                    if (index == 0)
                    {
                        this.ChartArea.TechnicalIndicators.Add(item);
                        NumericalAxis axis = new NumericalAxis();
                        axis.OpposedPosition = true;
                        axis.ShowGridLines = false;
                        axis.Visibility = Visibility.Collapsed;
                        indicatorAxis.YAxis = axis;
                        SfChart.SetRow(indicatorAxis.YAxis, 0);
                        
                    }
                }
            
        }



        protected override void OnMouseLeave(MouseEventArgs e)
        {
            //base.OnPointerReleased(e);
          //  this.IndicatorSource1.Visibility = Visibility.Visible;
            this.IndicatorSource2.Visibility = Visibility.Visible;
        }

        void ChartArea_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            double[] top = new double[5];

            var left = this.ChartArea.SeriesClipRect.Left;

            var right = this.ChartArea.SeriesClipRect.Right;


            for (int i = 0; i < this.ChartArea.RowDefinitions.Count; i++)
            {
                top[i] = this.ChartArea.RowDefinitions[i].RowTop;
            }

            //var areaBorder = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this.ChartArea, 0), 0) as Border;
            //areaBorder.Padding = new Thickness(15, this.ChartArea.SeriesClipRect.Top + IndicatorSource1.ActualHeight, 15, 15);

            //Canvas.SetLeft(IndicatorSource1, right - IndicatorSource1.ActualWidth );
            //Canvas.SetTop(IndicatorSource1, top[1] - IndicatorSource1.ActualHeight + 35);
            //Canvas.SetZIndex(IndicatorSource1, 100);

            Canvas.SetLeft(IndicatorSource2, right - IndicatorSource2.ActualWidth - 10);
            Canvas.SetTop(IndicatorSource2, top[0] - IndicatorSource2.ActualHeight - 10);
            Canvas.SetZIndex(IndicatorSource2, 100);

            //Canvas.SetLeft(TextSource1, left + TextSource1.ActualWidth);
            //Canvas.SetTop(TextSource1, top[1] - TextSource1.ActualHeight - 40);
            //Canvas.SetZIndex(TextSource1, 80);
           
            Canvas.SetLeft(TextSource2, left+10);
            Canvas.SetTop(TextSource2, -TextSource2.ActualHeight-10);
            Canvas.SetZIndex(TextSource2, 80);

            TextSource2.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x33, 0x33));
            //TextSource1.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x33, 0x33));

            TextSource2.FontSize = 35;

            //TextSource1.FontSize = 35;

            Binding binding = new Binding();
            binding.Source = this.ChartArea;
            binding.Path = new PropertyPath("DataContext");
            binding.Mode = BindingMode.TwoWay;
            binding.Converter = new TextBlockConverter();
            //TextSource1.SetBinding(TextBlock.TextProperty, binding);
            TextSource2.SetBinding(TextBlock.TextProperty, binding);
        }
    }

    public class TextBlockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (value is Stock))
            {
                List<StockData> data = (value as Stock).Datas;
                return data.Max(p => p.High);
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
