#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Syncfusion.UI.Xaml.Grid;
using System.Windows;

namespace CustomPrintingDemo
{
    internal class IsClosedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return value;
            if ((bool) value)

                return new BitmapImage(new Uri("pack://application:,,,/CustomPrintingDemo;component/Images/yes.png"));
            else
                return new BitmapImage(new Uri("pack://application:,,,/CustomPrintingDemo;component/Images/no.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class EditTriggerOptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? index = value as int?;
            if (index == 0)
                return EditTrigger.OnDoubleTap;
            else
                return EditTrigger.OnTap;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
