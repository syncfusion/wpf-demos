#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Kanban;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.kanbandemos.wpf
{
    public class CardCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var columnTag = value as ColumnTag;
            if (columnTag == null) return "";
            if (columnTag.Header.ToString() == "Menu")
                return "Total Items : ";
            else if (columnTag.Header.ToString() == "Order")
                return "Pizza Count : ";
            else if (columnTag.Header.ToString() == "To be cooked")
                return "Pizza Count : ";
            else if (columnTag.Header.ToString() == "Ready to Serve")
                return "Pizza Count : ";
            else if (columnTag.Header.ToString() == "Ready to Delivery")
                return "Pizza Count : ";
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
