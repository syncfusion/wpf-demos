#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.weatheranalysis.wpf
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string _parameter = parameter?.ToString();
            if (value is IEnumerable<string> keys)
            {
                string drawingGroupName = string.Empty;
                List<string> processedKeys = keys.Select(key => key).ToList();

                foreach (string item in processedKeys.Take(2))
                {
                    if (!string.IsNullOrEmpty(drawingGroupName))
                    {
                        drawingGroupName += "_";
                    }

                    string trimmedItem = item.Replace(" ", string.Empty);
                    drawingGroupName += trimmedItem;
                }

                if (_parameter == "Label")
                {
                    return WeatherLabelCollection[drawingGroupName];
                }

                return (DrawingImage)WindowHelper.MainWindow.TryFindResource(drawingGroupName);
            }

            if (value is string weather)
            {
                weather = weather.Replace(" ", string.Empty);
                if (_parameter == "Moon")
                {
                    string bitmapURL = $"/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/{weather}.png";
                    return new BitmapImage(new Uri(bitmapURL, UriKind.Relative));
                }

                return (DrawingImage)WindowHelper.MainWindow.TryFindResource(weather);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        static readonly Dictionary<string, string> WeatherLabelCollection = new Dictionary<string, string>()
        {
            { "Sunny_Rain", "Light rain showers" },
            { "Sunny_Snow", "Partly sunny with snow" },
            { "Sunny_Partiallycloudy", "Mostly sunny" },
            { "Sunny_Cloudy", "Partly sunny" },
            { "Sunny_FreezingRain", "Mostly sunny" },
            { "Rain_Snow", "Wintry mix" },
            { "Rain_Partiallycloudy", "Light rain" },
            { "Rain_Cloudy", "Heavy rain" },
            { "Rain_FreezingRain", "Freezing rain" },
            { "Rain_Sunny", "Rain showers" },
            { "Snow_Partiallycloudy", "Partially cloudy with snow" },
            { "Snow_Cloudy", "Cloudy with snow" },
            { "Snow_FreezingRain", "Wintry mix" },
            { "Snow_Sunny", "Snowy with sun" },
            { "Snow_Rain", "Wintry mix" },
            { "Partiallycloudy_Cloudy", "Cloudy" },
            { "Partiallycloudy_FreezingRain", "Rain showers" },
            { "Partiallycloudy_Sunny", "Mostly cloudy" },
            { "Partiallycloudy_Rain", "Light rain showers" },
            { "Partiallycloudy_Snow", "Partial snow" },
            { "Cloudy_FreezingRain", "Light rain showers" },
            { "Cloudy_Sunny", "Mostly cloudy" },
            { "Cloudy_Rain", "Thunder strom" },
            { "Cloudy_Snow", "Cloudy with snow" },
            { "Cloudy_Partiallycloudy", "Cloudy" },
            { "FreezingRain_Sunny", "Mostly rainy" },
            { "FreezingRain_Rain", "Heavy rain" },
            { "FreezingRain_Snow", "Wintry mix" },
            { "FreezingRain_Partiallycloudy", "Light freezing rain showers" },
            { "FreezingRain_Cloudy", "Light freezing rain showers" },
        };
    }
}
