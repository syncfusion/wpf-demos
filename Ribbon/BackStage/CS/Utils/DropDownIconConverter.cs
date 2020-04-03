#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace BackStageSample
{
    /// <summary>
    /// Represents the value converters.
    /// </summary>
  public  class DropDownIconConverter : IValueConverter
    {
        /// <summary>
        /// Method which is used to convert the images into string format.
        /// </summary>
        /// <param name="value">Image.</param>
        /// <param name="targetType">Convert to string type.</param>
        /// <param name="parameter">Image.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Returns string.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return @"/BackStageSample;component/Resources/" + value.ToString();

        }

        /// <summary>
        /// Method which is used to convert back.
        /// </summary>
        /// <param name="value">Image.</param>
        /// <param name="targetType">Convert back to string type.</param>
        /// <param name="parameter">Image.</param>
        /// <param name="culture">Culture.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
