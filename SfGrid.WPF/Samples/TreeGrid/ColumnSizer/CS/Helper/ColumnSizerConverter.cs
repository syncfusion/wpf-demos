#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Syncfusion.UI.Xaml.TreeGrid;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Media;

namespace ColumnSizerDemo
{
    class TreeGridColumnSizerConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? index = value as int?;
            if (index == 0)
                return TreeColumnSizer.Auto;
            else if (index == 1)
                return TreeColumnSizer.AutoFillColumn;
            else if (index == 2)
                return TreeColumnSizer.FillColumn;
            else if (index == 3)
                return TreeColumnSizer.None;
            else if (index == 4)
                return TreeColumnSizer.SizeToCells;
            else if (index == 5)
                return TreeColumnSizer.SizeToHeader;
            else
                return TreeColumnSizer.Star;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }    
}
