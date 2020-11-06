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
    public class OutlookConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string imagePath = "/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/";
                switch (value.ToString())
                {
                    case "Cloudy":
                        return imagePath + "Sun.png";
                    case "Rainy":
                        return imagePath + "Umbrella.png";
                    case "Rainy Storm":
                        return imagePath + "Rain.png";
                    case "Overcast":
                        return imagePath + "Sun.png";
                    case "Partly Cloudy":
                        return imagePath  + "Sun.png";
                    case "Sunny":
                        return imagePath  + "Sun.png";
                    case "Drizzle":
                        return imagePath  + "Rain.png";
                    case "Snow":
                        return imagePath  + "Snow.png";
                    case "Fog":
                        return imagePath  + "Snow.png";
                    case "Partly Sunny":
                        return imagePath  + "Sun.png";
                    default:
                        return null;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
