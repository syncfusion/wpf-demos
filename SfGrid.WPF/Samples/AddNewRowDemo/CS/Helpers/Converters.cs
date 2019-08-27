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
using Syncfusion.UI.Xaml.Grid;

namespace AddNewRowDemo
{
    internal class AddNewRowPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? index = value as int?;
            if (index == 0)
                return AddNewRowPosition.None;
            else if (index == 1)
                return AddNewRowPosition.Top;
            else if (index == 2)
                return AddNewRowPosition.FixedTop;
            else
                return AddNewRowPosition.Bottom;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
