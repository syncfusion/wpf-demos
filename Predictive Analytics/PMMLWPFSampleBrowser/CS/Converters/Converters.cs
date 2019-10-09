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
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PMMLWPFSampleBrowser
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string sampleStatus = value.ToString();

                if (sampleStatus == "NEW")
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#14a88e"));
                }
                else if (sampleStatus == "PREVIEW")
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#f68d38"));
                }
                else if (sampleStatus == "UPDATED")
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#268bb5"));
                }
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string sampleStatus = value.ToString();

                if (sampleStatus == "NEW")
                {
                    return "NEW";
                }
                else if (sampleStatus == "PREVIEW")
                {
                    return "PREVIEW";
                }
                else if (sampleStatus == "UPDATED")
                {
                    return "UPDATED";
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
