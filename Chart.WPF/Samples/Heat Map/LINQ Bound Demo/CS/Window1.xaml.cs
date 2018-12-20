#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Chart;

namespace LINQBound
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {  
        #region Initialization
            /// <summary>
            /// Contrcutor for window1.
            /// </summary>
        public Window1()
        {
            InitializeComponent();
            AddDefaultValues();         
           
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// To Add values to the Chart
        /// </summary>
        private void AddDefaultValues()
{
 	 this.topLayoutModeOptions.ItemsSource = Enum.GetValues(typeof(HeatMapLayoutMode));
            this.innerLayoutModeOptions.ItemsSource = Enum.GetValues(typeof(HeatMapLayoutMode));

            SalesList sList = new SalesList();
            var salesByCountry =
                from sales in sList
                group sales by sales.Country into g
                select new CountryWiseSalesGroup { CountryName = g.Key, RegionalSales = g.ToList(), Sales = g.Sum(i => i.Sales), Expense = g.Sum(i => i.Expense) };

            this.heatMap.ItemsSource = salesByCountry;
}
        #endregion

        #region Events
        /// <summary>
        /// Event for setting WeightValuePath.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.heatMap.WeightValuePath == "Expense")
                this.heatMap.WeightValuePath = "Sales";
            else
                this.heatMap.WeightValuePath = "Expense";
        }

        /// <summary>
        /// Event for setting MedianWeight.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myColorMedianPicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.heatMap.MedianWeight = (int)e.NewValue;

            double sliderWidth = this.myColorMedianPicker.Width;
            double sliderHeight = this.myColorMedianPicker.Height;

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0.5);
            brush.EndPoint = new Point(1, 0.5);
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.LowestWeightColor, Offset = 0 });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.MedianWeightColor, Offset = (((double)this.heatMap.MedianWeight / 100)) });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.HighestWeightColor, Offset = 1 });
            this.myColorMedianPicker.Background = brush;
        }
        #endregion

    }   
}
