#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

namespace syncfusion.demoscommon.wpf
{
    public class PrefixSuffixConverter : DependencyObject, IValueConverter
    {
        public string PrefixString
        {
            get { return (string)GetValue(PrefixStringProperty); }
            set { SetValue(PrefixStringProperty, value); }
        }

        public static readonly DependencyProperty PrefixStringProperty =
            DependencyProperty.Register("PrefixString", typeof(string), typeof(PrefixSuffixConverter), new PropertyMetadata(string.Empty));

        public string SuffixString
        {
            get { return (string)GetValue(SuffixStringProperty); }
            set { SetValue(SuffixStringProperty, value); }
        }

        public static readonly DependencyProperty SuffixStringProperty =
            DependencyProperty.Register("SuffixString", typeof(string), typeof(PrefixSuffixConverter), new PropertyMetadata(string.Empty));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            return PrefixString + value.ToString() + SuffixString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
