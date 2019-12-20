#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace AutoHideDemo
{
    public class ColorConverter : IValueConverter
    {
        /// <summary>
        /// Helps to convert the Color to SolidColorBrush
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color)
                return new SolidColorBrush((Color)value);
            if (value is SolidColorBrush)
                return (value as SolidColorBrush).Color;
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color)
                return new SolidColorBrush((Color)value);
            return new SolidColorBrush(Colors.Transparent);
        }
    }

    /// <summary>
    /// Helps to convert the Color to Brush based on the active window of DockingManager
    /// </summary>
    public class SideTabItemColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Brush brush = values[0] is Color ? new SolidColorBrush((Color)values[0]) : new SolidColorBrush(Colors.Transparent);
            if (parameter == null)
                return new SolidColorBrush(Colors.Red);
            if (values[2] is FrameworkElement)
            {
                if (brush != null && values[1] == values[2])
                {
                    return brush;
                }
                else
                {
                    brush = parameter.ToString() == "Background" ? DockingManager.GetSideTabItemBackground(values[2] as FrameworkElement) : DockingManager.GetSideTabItemForeground(values[2] as FrameworkElement);
                    if (brush != null)
                        return brush;
                }
            }
          
            return (brush == null && values[0] is Color) ? new SolidColorBrush((Color)values[0]) : new SolidColorBrush(Colors.Transparent);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Helps to convert the DockState of the DockingManager to Visibility
    /// </summary>
    public class StateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DockState && (DockState)value == DockState.AutoHidden)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
