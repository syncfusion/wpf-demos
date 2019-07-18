#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PatientDetailsDemo
{
    public class TextConverter : IValueConverter
    {      
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = null;
            if (value is string)
            {
                DateTime labelValue = System.Convert.ToDateTime(value.ToString());
                if (parameter.ToString().Equals("0"))
                {
                    res = labelValue.ToString("hh:mm:ss");
                }
                else
                    res = labelValue.ToString("dd/MM");
            }
            else
            {
                ChartAxisLabel axlabel = value as ChartAxisLabel;
                DateTime labelValue = System.Convert.ToDateTime(axlabel.LabelContent.ToString());

                if (parameter.ToString().Equals("0"))
                {
                    res = labelValue.ToString("hh:mm:ss");
                }
                else
                    res = labelValue.ToString("dd/MM");
            }
            return res;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BloodPressureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PatientDetails patient = value as PatientDetails;

            if (patient != null)
            {
                var BP1 = patient.BloodPressure.ToString();
                var BP2 = patient.BloodPressure2.ToString();
                return BP1 + "/" + BP2;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class SaturationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PatientDetails patient = value as PatientDetails;

            if (patient != null)
            {
                var val = patient.Saturation + "%";
                //var BP2 = patient.BloodPressure2.ToString();
                return val;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Value converter that translates true to <see cref="Visibility.Visible"/> and false to
    /// <see cref="Visibility.Collapsed"/>.
    /// </summary>
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }

    /// <summary>
    /// Value converter that translates true to false and vice versa.
    /// </summary>
    public sealed class BooleanNegationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool)value);
        }
    }

    class ViewportWidthConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var width = value as double?;
                if (parameter.ToString().Equals("WholeGrid"))
                    return (width * 1.75) + 500;
            }
            return 0;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class ToggleButtonConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? false : true;
        }
    }

}
