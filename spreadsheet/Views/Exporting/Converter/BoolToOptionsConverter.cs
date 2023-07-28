#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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

namespace syncfusion.spreadsheetdemos.wpf
{
    public class BoolToOptionsConverter : IMultiValueConverter

    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int number = 0;
            foreach (object o in values)
            {
                bool result;
                if (bool.TryParse(o.ToString(), out result))
                {
                    if (result)
                    {
                        switch (number)
                        {
                            case 0:
                                return "Export to HTML";
                            case 1:
                                return "Export to Image";
                            case 2:
                                return "Export to PDF";
                            default:
                                return "Export to HTML";
                        }
                    }
                    else
                        number++;
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
