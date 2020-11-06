#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace syncfusion.navigationdemos.wpf.Converter
{
    public class WeatherConverter: IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Climate)value == Climate.Sunny)
            {
                return "/syncfusion.navigationdemos.wpf;component/Assets/TabControlExt/sunny.png";
            }
            else if ((Climate)value == Climate.Rainy)
            {
                return "/syncfusion.navigationdemos.wpf;component/Assets/TabControlExt/rainy.png";
            }
            else
            {
                return "/syncfusion.navigationdemos.wpf;component/Assets/TabControlExt/cloudy.png";
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
