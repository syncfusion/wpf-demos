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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using System.Globalization;

namespace ChromelessWindowSample_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
    }

    #region Converter

    /// <summary>
    /// FormatConvertor class
    /// </summary>
    public class FormatConverter : IValueConverter
    {
        //Converter to display the values modified in slider to the textblock
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                string strFormatString = parameter.ToString();
                if (!string.IsNullOrEmpty(strFormatString))
                    return string.Format(culture, strFormatString, value);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TypeConverter objTypeConverter = TypeDescriptor.GetConverter(targetType);
            object objReturnValue = null;

            if (objTypeConverter.CanConvertFrom(value.GetType()))
            {
                objReturnValue = objTypeConverter.ConvertFrom(value);
            }

            return objReturnValue;
        }
    }

    #endregion
}
