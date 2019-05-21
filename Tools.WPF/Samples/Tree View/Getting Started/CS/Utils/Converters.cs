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
using TreeViewAdvConfigurationDemo;
using Syncfusion.Windows.Tools;

namespace TreeViewAdvConfigurationDemo
{
    public class StyleConverter : IValueConverter
    {

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                Window1 window = Application.Current.MainWindow as Window1;
                Style basestyle = new Style();
            
                if (window.TreeView.Resources.MergedDictionaries.Count > 0)
                {
                    ResourceDictionary rdic = window.TreeView.Resources.MergedDictionaries[window.TreeView.Resources.MergedDictionaries.Count - 1] as ResourceDictionary;
                    basestyle = rdic[value.ToString() + "TreeViewItemAdvStyle"] as Style;
                    Style itemcontainerstyle = window.Resources["style"] as Style;
                    foreach (Setter setter in itemcontainerstyle.Setters)
                    {
                   
                            basestyle.Setters.Add(setter);
                    }
                }
                return basestyle;
             }
             catch
             {
                 return null;
             }
            
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

    public class AnimationTypeConverter : IValueConverter
    {

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (var item in Enum.GetValues(typeof(AnimationType)))
            {
                if (value.ToString() == item.ToString())
                {
                    return item;
                }
            }

            return null;

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
