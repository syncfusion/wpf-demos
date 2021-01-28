#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represent the ObjectToSourceConverter class.
    /// </summary>
    public class ObjectToSourceConverter : IValueConverter
    {
        /// <summary>
        /// Converts value to source of ItemsControl. 
        /// </summary>
        /// <param name="value">value from the source</param>
        /// <param name="targetType">target type of the value</param>
        /// <param name="parameter">parameter passed from source</param>
        /// <param name="language">culture of the string</param>
        /// <returns>converted value</returns>#if !WINRT
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (parameter != null && parameter.ToString() == "Source" && value is NavigationItem)
            {
                return ((value as NavigationItem).DataContext as MusicModel).SubItems;
            }
            else if (value is NavigationItem)
            {
                return ((value as NavigationItem).DataContext as MusicModel).Item.ToString();
            }

            return null;
        }

        /// <summary>
        /// Throws an exception
        /// </summary>
        /// <param name="value">value from the source</param>
        /// <param name="targetType">target type of the value</param>
        /// <param name="parameter">parameter passed from source</param>
        /// <param name="language">culture of the string</param>
        /// <returns>returns the converted value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
