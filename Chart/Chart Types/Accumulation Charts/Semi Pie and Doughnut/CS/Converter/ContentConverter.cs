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
using System.Windows.Controls;
using System.Windows.Data;

namespace Semi_PieSeries
{
    public class ContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var userControl = value as UserControl;
            string displayName = "";

            if (userControl != null)
            {
                var userControlName = userControl.GetType().Name;
                displayName = userControlName == "PieSeriesDemo" ? "Pie" : "Doughnut";
            }

            return displayName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var displayName = value as string;
            UserControl userControl = null;

            if (displayName != null)
            {
                if (displayName == "Pie")
                {
                    userControl = new PieSeriesDemo();
                }
                else
                {
                    userControl = new DoughnutSeriesDemo();
                }
            }

            return userControl;
        }
    }
}
