#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.stockanalysisdemo.wpf 
{
    public class InteriorConverter : IValueConverter 
    {  
        private static int count = 0;
        private int itemCount = 0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            bool isBull = false;
             
            SolidColorBrush greenBrush = new SolidColorBrush(Color.FromRgb(52, 211, 153));  
            SolidColorBrush redBrush = new SolidColorBrush(Color.FromRgb(252, 165, 165));

            if (value != null && value is ColumnSeries candle)  
            {
                var data = (ObservableCollection<StockData>)candle.ItemsSource;
                if (itemCount!=data.Count|| count>=data.Count)
                {
                    itemCount = data.Count;
                    count = 0;
                } 
                var item = data[count];
                if (count == 0)
                {
                    isBull = item.Close > item.Open;
                }
                else
                {
                    var previousItem = data[count - 1];
                    isBull = item.Low >= previousItem.Low;
                } 
                count++;
                return isBull ? greenBrush : redBrush;
            } 
            return greenBrush; 
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            throw new NotImplementedException();
        } 
    } 
}
