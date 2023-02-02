#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

namespace syncfusion.chartdemos.wpf
{
    public class CustomSeriesContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var comboBoxContent = value as ComboBoxItem;
            UserControl actualContent = null;

            if (comboBoxContent != null)
            {
                var comboBoxString = comboBoxContent.Content.ToString();

                switch (comboBoxString)
                {
                    case "Bar":
                        actualContent = new CustomBarSeries();
                        break;

                    case "Scatter":
                        actualContent = new ScatterSeries();
                        break;

                    case "Spline":
                        actualContent = new SplineSeries();
                        break;

                    default:
                        actualContent = new ColumnSeries();
                        break;
                }
            }

            return actualContent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
