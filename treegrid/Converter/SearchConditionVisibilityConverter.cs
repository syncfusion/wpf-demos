#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.treegriddemos.wpf
{
    public class SearchConditionVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = value as int?;
            string text = parameter.ToString();
            if (text.Equals("SearchCondition"))
            {
                if (index > 0)
                    return Visibility.Visible;
            }
            else if (text.Equals("NumericComboBox"))
            {
                if (index == 3 || index == 6)
                    return Visibility.Visible;
            }
            else if (text.Equals("StringComboBox"))
            {
                if (index == 1 || index == 2 || index == 4 || index == 5)
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
