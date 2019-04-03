#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace TileViewConfigurationDemo
{
    public class StyleConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            MainWindow window = Application.Current.MainWindow as MainWindow;
            Style basestyle = new Style();
            if (window != null && window.Resources.MergedDictionaries.Count > 0 && window.TileView.Resources.MergedDictionaries.Count > 0)
            {
                ResourceDictionary rdic = window.TileView.Resources.MergedDictionaries[window.TileView.Resources.MergedDictionaries.Count - 1] as ResourceDictionary;
                basestyle = rdic[value.ToString() + "TileViewItemStyle"] as Style;
                Style itemcontainerstyle = window.Resources["tileViewItemStyle"] as Style;
                foreach (Setter setter in itemcontainerstyle.Setters)
                {
                    basestyle.Setters.Add(setter);
                }
            }
            return basestyle;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = value.ToString();

            return "../Images/" + str + ".jpg";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
