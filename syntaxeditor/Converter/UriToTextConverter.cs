#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Represents the converter class for converting Uri to Text converter
    /// </summary>
    public class UriToTextConverter : IValueConverter
    {
        /// <summary>
        /// Method for converting Uri to text
        /// </summary>
        /// <param name="value">Specifies the object value</param>
        /// <param name="targetType">Specifies the target type</param>
        /// <param name="parameter">Specifies the object parameter</param>
        /// <param name="culture">Specifies the culture</param>
        /// <returns>Returns the string type.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is Uri)
            {
                Uri tempUri = value as Uri;
                if (tempUri.Segments.Length > 0)
                {
                    return tempUri.Segments[tempUri.Segments.Length - 1];
                }
                return tempUri.LocalPath;
            }
            return string.Empty;
        }

        /// <summary>
        /// Method for convert back
        /// </summary>
        /// <param name="value">Specifies the object value</param>
        /// <param name="targetType">Specifies the target type</param>
        /// <param name="parameter">Specifies the object parameter</param>
        /// <param name="culture">Specifies the culture</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }       
    }
}
