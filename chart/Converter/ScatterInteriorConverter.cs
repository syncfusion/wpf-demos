#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    public class ScatterInteriorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ScatterSegment).YData;
            Brush interior;

            interior = ydata >= 25 ? new SolidColorBrush(Color.FromArgb(0xFF, 0x8B, 0xC3, 0x4A)) :
               new SolidColorBrush(Color.FromArgb(0xFF, 0xD1, 0xD3, 0xD4)); ;

            return interior;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
