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
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;
using System.ComponentModel;
using System.Globalization;
using Syncfusion.Windows.Shared;

namespace FlatList
{
    public partial class FlatList : Window
    {
        DataViewModel data;
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        
        public FlatList()
        {
            InitializeComponent();
            intersect.ItemsSource = Enum.GetValues(typeof(TextIntersectActions));
            data = new DataViewModel();
           /// this.DataContext = data;
            this.sliderFirstItem.Value = this.data.salesList[0].Sales;           
        }
        #endregion
        
        #region Events
        private void sliderFirstItem_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.data.salesList[0].Sales = e.NewValue;
            this.heatMap.ItemsSource = this.data.salesList;
        }
        //Raised when add button is clicked
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Add new Items to List
            data.Add();
            this.heatMap.ItemsSource = this.data.salesList;
        }

        private void myColorMedianPicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.heatMap.MedianWeight = (int)e.NewValue;
            double sliderWidth = this.myColorMedianPicker.Width;
            double sliderHeight = this.myColorMedianPicker.Height;
            //Declares the Liner gradient brush for Slider
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0.5);
            brush.EndPoint = new Point(1, 0.5);
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.LowestWeightColor, Offset = 0 });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.MedianWeightColor, Offset = (((double)this.heatMap.MedianWeight / 100)) });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.HighestWeightColor, Offset = 1 });
            //Sets the Slider background
             this.myColorMedianPicker.Background = brush;
           
            double diff = 0.0;
            if (this.heatMap.ColorWeightsInfo.HighestValue != 0.0)
            {
                diff = this.heatMap.ColorWeightsInfo.HighestValue - this.heatMap.ColorWeightsInfo.LowestValue;
                txtchk.Text = this.heatMap.ColorWeightsInfo.LowestValue.ToString() + "(( " + diff.ToString() + " * " + e.NewValue.ToString() + ") / 100";
                medianColorText.Text = string.Format("${0:F0}", this.heatMap.ColorWeightsInfo.LowestValue + ((diff * e.NewValue) / 100));
               
            }

        }
        #endregion
    }   

    #region Converter

    public class FormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This is possible durign designer load
            if (value == null)
                return string.Empty;

            if (parameter != null)
            {
                string strFormatString = parameter.ToString();
                if (!string.IsNullOrEmpty(strFormatString))
                    return string.Format(culture, strFormatString, value);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            TypeConverter objTypeConverter = TypeDescriptor.GetConverter(targetType);
            object objReturnValue = null;

            if (objTypeConverter.CanConvertFrom(value.GetType()))
            {
                objReturnValue = objTypeConverter.ConvertFrom(value);
            }

            return objReturnValue;

        }
    }

    #endregion
}
