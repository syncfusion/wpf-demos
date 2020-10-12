#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.organizationallayout.wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.organizationallayout.wpf
{
    public class StringtoVisiblityConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? val = value as int?;
            if (val == 0 | val == 2)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NumerictoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? val = value as int?;
            if (val == 1)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? val = value as bool?;
            if (val == true)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (Visibility)value;

            if (val == Visibility.Visible)
            {
                return true; ;

            }
            return false;

        }
    }

    public class BoolToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? val = value as bool?;
            if (val == true)
                return new Thickness(3.2);
            return new Thickness(1.2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? val = value as bool?;
            if (val == true)
            {
                return new SolidColorBrush(Colors.SkyBlue);
            }
            else
            {
                //return new SolidColorBrush(Colors.White);
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(255, 221, 221, 221);
                return brush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoExpandConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object val = Enum.ToObject(typeof(State), value);
            if (value.ToString() == State.Expand.ToString())
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoCollapseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object val = Enum.ToObject(typeof(State), value);
            if (value.ToString() == State.Collapse.ToString())
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoPathVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object val = Enum.ToObject(typeof(State), value);
            if (value.ToString() == State.None.ToString())
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // No format provided.
            if (parameter == null)
            {
                return value;
            }

            return String.Format((String)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class EnumtoFocusConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object val = Enum.ToObject(typeof(NodeFocusState), value);
            SolidColorBrush solid = new SolidColorBrush();
            if (val.ToString() == NodeFocusState.Normal.ToString())
            {
                return new SolidColorBrush(Colors.White);
            }
            else if (value.ToString() == NodeFocusState.MouseHover.ToString())
            {
                solid.Color = Color.FromArgb(255, 239, 239, 239);
                return solid;
            }
            //else 
            //{
            //    if(value.ToString() == NodeFocusState.Focused.ToString())
            //    {
            //        solid.Color = Color.FromArgb(255, 201, 201, 201);
            //        return solid;
            //    }
            //}
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedItemConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class FormatConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Retrieve the format string and use it to format the value.
            string formatString = parameter as string;
            if (!string.IsNullOrEmpty(formatString))
            {
                return string.Format(
                    culture, formatString, value);
            }
            // If the format string is null or empty, simply call ToString()
            // on the value.
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string formatString = parameter as string;
            if (!string.IsNullOrEmpty(formatString))
            {
                return string.Format(
                    culture, formatString, value);
            }
            // If the format string is null or empty, simply call ToString()
            // on the value.
            return value.ToString();
        }
    }

    public class ItemtoImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            if (value.ToString() == "Female")
            {
                return "/syncfusion.organizationallayout.wpf;component/Asset/female.png";
            }
            else
            {
                return "/syncfusion.organizationallayout.wpf;component/Asset/male.png";
            }

        }
    }

    public class RatingToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string i = (string)value;
                int coun = 0;
                switch (i)
                {
                    case "#FFC34444":
                        coun = 1;
                        break;
                    case "#FF68C2DE":
                        coun = 2;
                        break;
                    case "#FF93B85A":
                        coun = 3;
                        break;
                    case "#FFEBB92E":
                        coun = 4;
                        break;
                    case "#FFD46E89":
                        coun = 5;
                        break;
                }
                return coun;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int i = (int)value;
                string color = string.Empty;
                switch (i)
                {
                    case 1:
                        color = "#FFC34444";
                        break;
                    case 2:
                        color = "#FF68C2DE";
                        break;
                    case 3:
                        color = "#FF93B85A";
                        break;
                    case 4:
                        color = "#FFEBB92E";
                        break;
                    case 5:
                        color = "#FFD46E89";
                        break;
                }
                return color;
            }
            return null;
        }
    }

    public static class ColorHelper
    {
        public static SolidColorBrush GetColorFromHexa(string hexaColor)
        {
            return new SolidColorBrush(
                Color.FromArgb(
                    255, Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16)
                )
            );
        }
    }

    public class ContentPresenters : ContentPresenter
    {
        public ContentPresenters()
        {

        }
        public SolidColorBrush Foreground
        {
            get { return (SolidColorBrush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(SolidColorBrush), typeof(ContentPresenters), new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));

    }

    public class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = parameter.ToString();

            if (value.ToString() == s)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
