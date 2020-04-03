#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DateSelectorDemo
{
    public class DateToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime)value;
            if (parameter.ToString() == "Day")
            {
                if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/medal.png", UriKind.Relative));
                }
                else if (dateTime.DayOfWeek == DayOfWeek.Monday)
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/sun.png", UriKind.Relative));
                }
                else if (dateTime.DayOfWeek == DayOfWeek.Tuesday)
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/smile.png", UriKind.Relative));
                }
                else if (dateTime.DayOfWeek == DayOfWeek.Wednesday)
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/graduation.png", UriKind.Relative));
                }
                else if (dateTime.DayOfWeek == DayOfWeek.Thursday)
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/rain.png", UriKind.Relative));
                }
                else if (dateTime.DayOfWeek == DayOfWeek.Friday)
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/gift.png", UriKind.Relative));
                }
                else
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/graduation.png", UriKind.Relative));
                }
            }
            else
            {
                if (dateTime.Month == DateTime.Now.Month)
                {
                    return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/love.png", UriKind.Relative));
                }
                else
                {
                    if (dateTime.Month % 4 == 0)
                    {
                        return new BitmapImage(new Uri(@"/DateSelectorDemo;component/Assets/ball.png", UriKind.Relative));
                    }
                }
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
