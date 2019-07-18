#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace GroupbarOutlookDemo
{
    public class BoolToVisibilityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0].ToString() != "{DependencyProperty.UnsetValue}")
            {
                if ((bool)values[0] || (bool)values[1])
                    return Visibility.Visible;
            }
             return  Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanToVisibilityMultiConverter2 : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null && parameter.ToString() == "header")
            {
                if ((bool)values[0])
                    return Visibility.Visible;
                else
                {
                    var coll = values[1] as ObservableCollection<MailModel>;
                    if(coll != null)
                    {
                        if (coll.Any(p => p.IsUnRead ))
                        {
                            return Visibility.Visible;
                        }

                    }
                    SortedMailCollection soretedmails = values[1] as SortedMailCollection;
                    if (soretedmails != null)
                    {
                        if (soretedmails.MailCollection.Any(p => p.IsUnRead))
                            return Visibility.Visible;
                    }
                }
            }
            else
            {
                if (values[0].ToString() != "{DependencyProperty.UnsetValue}" && values[1].ToString() != "{DependencyProperty.UnsetValue}")
                {
                    if ((bool)values[0])
                        return Visibility.Visible;
                    else
                    {
                        if ((bool)values[1])
                            return Visibility.Visible;
                    }
                }
            }
                return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
