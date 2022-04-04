#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    public class PriceUpImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as string) != null)
            {
                if ((value as string).EndsWith("%"))
                {
                    var val = (value as string).Remove((value as string).Length - 1);
                    value = double.Parse(val);
                    return ((double)value) >= 0;
                }
            }
            return ((double?)value) >= 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
