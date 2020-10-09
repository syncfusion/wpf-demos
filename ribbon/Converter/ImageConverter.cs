#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Class represents the ImageConverter 
    /// </summary>
    public class ImageConverter : IValueConverter
    {
        /// <summary>
        /// Method which is used to convert the images to string format.
        /// </summary>
        /// <param name="value">Value inwhich size to be convert.</param>
        /// <param name="targetType">Specifies the target type.</param>
        /// <param name="parameter">Specifies the object parameter.</param>
        /// <param name="culture">Specifies the culture.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string str = value.ToString();
                return "../../Images/" + str;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Method which is used to convert back the images to string format.
        /// </summary>
        /// <param name="value">Value inwhich size to be convert back.</param>
        /// <param name="targetType">Specifies the target type.</param>
        /// <param name="parameter">Specifies the object parameter.</param>
        /// <param name="culture">Specifies the culture.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
