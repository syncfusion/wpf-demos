#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CellStyleDemo
{
    internal class CellStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as PersonInfo).Salary < 10000)
                return new SolidColorBrush(Colors.Transparent);
                
            else if ((value as PersonInfo).Salary > 10000 && (value as PersonInfo).Salary < 50000)
                return App.Current.Resources["Brush2"];
            else if ((value as PersonInfo).Salary > 50000 && (value as PersonInfo).Salary < 100000)
                return App.Current.Resources["Brush1"];
            return new SolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    internal class CellStyleConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as PersonInfo).Hike < 6)
                return new SolidColorBrush(Colors.Transparent);

            else if ((value as PersonInfo).Hike > 6 && (value as PersonInfo).Hike < 10)
                return App.Current.Resources["Brush3"];
            else if ((value as PersonInfo).Hike > 10)
                return App.Current.Resources["Brush4"];
            return new SolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




    internal class AvailabilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isAvailable = (bool?)value;
            if (isAvailable == true)
                return new BitmapImage(new Uri("pack://application:,,,/CellStyleDemo;component/Images/yes.png"));
            else
                return new BitmapImage(new Uri("pack://application:,,,/CellStyleDemo;component/Images/no.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class CurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return String.Format("{0:C}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
