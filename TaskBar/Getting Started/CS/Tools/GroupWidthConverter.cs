#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Windows.Data;

namespace TaskBarDemo
{
	/// <summary>
	/// Sample-specific converter used to represent bart of the values of the slider as NaN to allow autosizing.
	/// </summary>
	[ValueConversion( typeof( double ), typeof( double ) )]
	public class GroupWidthConverter : IValueConverter
	{
        /// <summary>
        /// Method used to convert the object to double type for group width.
        /// </summary>
        /// <param name="value">Specifies the object parameter.</param>
        /// <param name="targetType">Specifies the Type parameter.</param>
        /// <param name="parameter">Specifies the object parameter.</param>
        /// <param name="culture">Specifies the culture info.</param>
        /// <returns>Specifies the double return type.</returns>
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			double groupWidth = (double)value;
			if( double.IsNaN( groupWidth ) )
				return 500;
			return groupWidth;
		}

        /// <summary>
        /// Method used to convert back 
        /// </summary>
        /// <param name="value">Specifies the object parameter.</param>
        /// <param name="targetType">Specifies the Type parameter.</param>
        /// <param name="parameter">Specifies the object parameter.</param>
        /// <param name="culture">Specifies the culture info.</param>
        /// <returns>Specifies the double return type.</returns>
		public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			double groupWidth = (double)value;
			return groupWidth;
		}
	}		 
}
