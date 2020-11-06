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

namespace syncfusion.weatheranalysis.wpf
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        string str = value.ToString();

        if (str == "Cloudy" || str == "Partly Sunny")
            return @"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/img_PartlySunny.png";
        else if (str == "Rainy")
            return @"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/img_Humidity.png";
        else if (str == "Rainy Storm")
            return @"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/img_RainyStorm.png";
        else if (str == "Partly Cloudy")
            return @"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/img_PartlyCloudy.png";
        else if (str == "Snow")
            return @"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/img_Snow.png";
        else if (str == "Fog")
            return @"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/img_DewPoint.png";

        return @"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/Image1.png";
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
}
