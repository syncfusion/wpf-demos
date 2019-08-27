#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Diagnostics;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TrendlineDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region methods

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox select = sender as ComboBox;
            if (sfchart != null)
            {
                if (select.SelectedIndex == 0)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].Type = TrendlineType.Linear;
                }
                else if (select.SelectedIndex == 1)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].Type = TrendlineType.Exponential;
                }
                else if (select.SelectedIndex == 2)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].Type = TrendlineType.Power;
                }
                else if (select.SelectedIndex == 3)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].Type = TrendlineType.Logarithmic;
                }
                else if (select.SelectedIndex == 4)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].Type = TrendlineType.Polynomial;
                }
            }
        }
        private void ComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox select = sender as ComboBox;
            if (sfchart != null)
            {
                if (select.SelectedIndex == 0)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].PolynomialOrder = 2;
                }
                else if (select.SelectedIndex == 1)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].PolynomialOrder = 3;
                }
                else if (select.SelectedIndex == 2)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].PolynomialOrder = 4;
                }
                else if (select.SelectedIndex == 3)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].PolynomialOrder = 5;
                }
                else if (select.SelectedIndex == 4)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].PolynomialOrder = 6;
                }
            }
        }
        private void Stroke_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          
          if(sfchart != null)
           (sfchart.Series[0] as FastLineSeries).Trendlines[0].Stroke = new SolidColorBrush((Color)e.NewValue);
              
        }
        private void ComboBox_SelectionChanged3(object sender, SelectionChangedEventArgs e)
        {
            ComboBox select = sender as ComboBox;
            if (sfchart != null)
            {
                if (select.SelectedIndex == 0)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].StrokeDashArray = new DoubleCollection() { 1, 1 };
                }
                else if (select.SelectedIndex == 1)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].StrokeDashArray = new DoubleCollection() { 4, 4 };
                }
                else if (select.SelectedIndex == 2)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].StrokeDashArray = new DoubleCollection() { 4, 8 };
                }
                else if (select.SelectedIndex == 3)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].StrokeDashArray = new DoubleCollection() { 4, 2 };
                }
                else if (select.SelectedIndex == 4)
                {
                    (sfchart.Series[0] as FastLineSeries).Trendlines[0].StrokeDashArray = new DoubleCollection() { 1,0 };
                }
            }
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            if (sfchart != null)
                (sfchart.Series[0] as FastLineSeries).Trendlines[0].StrokeThickness = Math.Round(slider.Value);
        }
        private void Backward_ValueChanged(object sender,  RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            (sfchart.Series[0] as FastLineSeries).Trendlines[0].BackwardForecast = Math.Round(slider.Value);
        }
        private void Forward_ValueChanged(object sender,  RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            (sfchart.Series[0] as FastLineSeries).Trendlines[0].ForwardForecast = Math.Round(slider.Value);
        }

        #endregion

    }

    public class Collection
    {
        public Collection()
        {
            this.StockPriceDetails = new ObservableCollection<Model>();
            DateTime date = new DateTime(2013, 1, 1);
            Random rd = new Random();
            this.StockPriceDetails.Add(new Model() { Value = 26, Date = date.AddDays(1) });
            this.StockPriceDetails.Add(new Model() { Value = 34, Date = date.AddDays(2) });
            this.StockPriceDetails.Add(new Model() { Value = 42, Date = date.AddDays(3) });
            this.StockPriceDetails.Add(new Model() { Value = 29, Date = date.AddDays(4) });
            this.StockPriceDetails.Add(new Model() { Value = 14, Date = date.AddDays(5) });
            this.StockPriceDetails.Add(new Model() { Value = 89, Date = date.AddDays(6) });
            this.StockPriceDetails.Add(new Model() { Value = 45, Date = date.AddDays(7) });
            this.StockPriceDetails.Add(new Model() { Value = 39, Date = date.AddDays(8) });
            this.StockPriceDetails.Add(new Model() { Value = 45, Date = date.AddDays(9) });
            this.StockPriceDetails.Add(new Model() { Value = 88, Date = date.AddDays(10) });
            this.StockPriceDetails.Add(new Model() { Value = 70, Date = date.AddDays(11) });
            this.StockPriceDetails.Add(new Model() { Value = 45, Date = date.AddDays(12) });
        }

        public ObservableCollection<Model> StockPriceDetails { get; set; }
    }
    public class Model
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

    }
}
