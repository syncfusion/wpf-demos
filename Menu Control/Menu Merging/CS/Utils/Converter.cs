#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Globalization;

namespace MenuMerging
{
  /// <summary>
  /// Class represents the image converter.
  /// </summary>
    public class ImageConverter : IValueConverter
    {
        /// <summary>
        /// Method to convert into image.
        /// </summary>
        /// <param name="values">Value to be convert.</param>
        /// <param name="targetType">Target type in which value to be convert.</param>
        /// <param name="parameter">Parameter which is to be passed to the object.</param>
        /// <param name="culture">Culture in which visibility occcurs.</param>
        /// <returns>Returns the image.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string imageSource = value.ToString();

                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Width = 16;
                image.Height = 16;
                image.Source = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));
                return image;
            }
            return null;
        }

        /// <summary>
        /// Method to convert back from image.
        /// </summary>
        /// <param name="values">Value to be convert.</param>
        /// <param name="targetType">Target type in which value to be convert back.</param>
        /// <param name="parameter">Parameter which is to be passed to the object.</param>
        /// <param name="culture">Culture in which visibility occcurs.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
