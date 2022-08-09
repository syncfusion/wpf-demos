#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Converter to convert resource key into Drawing image.
    /// </summary>
    public class ImageConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DrawingImage image = System.Windows.Application.Current.Resources[value] as DrawingImage;
                return image;
            }
            return null;
        }

        public Object ConvertBack(Object value, Type targetTypes, Object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
