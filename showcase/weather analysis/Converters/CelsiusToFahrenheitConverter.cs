namespace syncfusion.weatheranalysis.wpf
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;

    public class CelsiusToFahrenheitConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
            {
                return null;
            }

            float convertedValue = values[0] is float ? (float)values[0] : float.Parse(values[0].ToString());
            bool isCelsius = (bool)values[1];
            if (parameter == null)
            {
                return convertedValue;
            }

            if (!isCelsius)
            {
                if (float.TryParse(values[0].ToString(), out float celsius))
                {
                    convertedValue = (celsius * 9 / 5) + 32;
                }
            }

            if (values.Count() == 3)
            {
                float[] fahrenheitValues = new float[] { (float)values[0], (float)values[2] };
                if (!isCelsius)
                {
                    fahrenheitValues[0] = convertedValue;
                    if (float.TryParse(values[2].ToString(), out float celsius1))
                    {
                        fahrenheitValues[1] = (celsius1 * 9 / 5) + 32;
                    }
                }

                return string.Format(parameter.ToString(), fahrenheitValues[0], fahrenheitValues[1]);
            }

            return string.Format(parameter.ToString(), convertedValue);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
