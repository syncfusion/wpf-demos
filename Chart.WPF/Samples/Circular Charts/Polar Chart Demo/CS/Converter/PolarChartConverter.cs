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

namespace Polar_Chart
{
    #region IsClosedConverter
    public class IsClosedConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object seriesType, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string type = seriesType as string;
            if (type == "Line" || type == "Area")
            {
                return (bool)true;
            }
            else
                return (bool)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
    #endregion
}
