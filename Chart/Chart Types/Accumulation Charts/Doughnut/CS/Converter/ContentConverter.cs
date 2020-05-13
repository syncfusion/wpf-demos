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

namespace DoughnutChart
{
    public class ContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentContentName = (string)value;
            UserControl currentContent = null;

            if (currentContentName != null)
            {
                switch (currentContentName)
                {
                    case "Multiple Doughnut":
                        currentContent = new MultipleDoughnutSeriesDemo();
                        break;

                    case "Stacked Doughnut":
                        currentContent = new StackedDoughnutDemo();
                        break;

                    default:
                        currentContent = new DoughnutSeriesDemo();
                        break;
                }
            }

            return currentContent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
