#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomEditorDemo
{
    public class ElementTotypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                Type type = value.GetType();
                return type.Name;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ObjectToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string obj = ((ComboBoxItem)value).Content.ToString();
            string param = parameter.ToString();
            if (obj.Contains("Person"))
            {
                return Visibility.Collapsed;
            }

            if (obj == param)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ObjectConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ComboBoxItem item = (ComboBoxItem)value;
            Grid grid1 = ((ComboBox)item.Parent).Parent as Grid;
            Grid grid = grid1.Children[1] as Grid;
            if (grid != null)
            {
                foreach (UIElement child in grid.Children)
                {
                    if (child.Visibility == Visibility.Visible)
                    {
                        return child;
                    }
                }
            }
            return App.Current.MainWindow.Resources["person"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class PersonToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ComboBoxItem item = (ComboBoxItem)value;
            if (item.Content.ToString().Contains("Person"))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }


    public class NameToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FrameworkElement element = value as FrameworkElement;
            string str;
            if (element != null)
            {
                str = element.Name;
                if (string.IsNullOrEmpty(str))
                {
                    return "<no name>";
                }
            }
            else
            {
                return "<no name>";
            }

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ElementToImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VisualBrush source = new VisualBrush();
            source.Stretch = Stretch.Uniform;
            ImageBrush brush = new ImageBrush();
            brush.Stretch = Stretch.Uniform;
            if (value is Visual)
            {
                source.Visual = value as Visual;
                return source;
            }
            else
            {

                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class VisibilityToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibilityValue = (Visibility)value;
            int heightValue = 0;

            if (visibilityValue == Visibility.Visible || visibilityValue == Visibility.Hidden)
            {
                heightValue = 55;
            }
            else if (visibilityValue == Visibility.Collapsed)
            {
                heightValue = 0;
            }

            return heightValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
