#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
    /// <summary>
    ///  Represents the visibility multi converter.
    /// </summary>
    public class BoolToVisibilityMultiConverter : IMultiValueConverter
    {
        #region BoolToVisibilityMultiConverter
        /// <summary>
        /// Convert method to change the boolean property to visibility.
        /// </summary>
        /// <param name="values">Value to be convert</param>
        /// <param name="targetType">Target type in which value to be convert</param>
        /// <param name="parameter">Parameter which is to be passed to the object</param>
        /// <param name="culture">Culture inwhich visibility occcurs</param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0].ToString() != "{DependencyProperty.UnsetValue}")
            {
                if ((bool)values[0] || (bool)values[1])
                    return Visibility.Visible;
            }
             return  Visibility.Hidden;
        }
        /// <summary>
        /// Convert back method.
        /// </summary>
        /// <param name="value">Value to be convert back</param>
        /// <param name="targetTypes">Target type in which value to be convert back</param>
        /// <param name="parameter">Parameter which is to be passed to the object</param>
        /// <param name="culture">Culture inwhich visibility occcurs</param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Represents the visibility multi converter.
    /// </summary>
    public class BooleanToVisibilityMultiConverter2 : IMultiValueConverter
    {
        /// <summary>
        /// Convert method for mailmodel.
        /// </summary>
        /// <param name="values">Value to be convert</param>
        /// <param name="targetType">Target type in which value to be convert</param>
        /// <param name="parameter">Parameter which is to be passed to the object</param>
        /// <param name="culture">Culture inwhich visibility occcurs</param>
        /// <returns></returns>
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

        /// <summary>
        /// Convert back method.
        /// </summary>
        /// <param name="value">Value to be convert back</param>
        /// <param name="targetTypes">Target type in which value to be convert back</param>
        /// <param name="parameter">Parameter which is to be passed to the object</param>
        /// <param name="culture">Culture inwhich visibility occcurs</param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
