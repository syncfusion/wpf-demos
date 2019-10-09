#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Diagnostics;

namespace TaskBarDemo
{
	/// <summary>
	/// Sample-specific converter used to represent bart of the values of the slider as NaN to allow autosizing.
	/// </summary>
	[ValueConversion( typeof( double ), typeof( double ) )]
	public class GroupWidthConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			double groupWidth = (double)value;

			if( double.IsNaN( groupWidth ) )
				return 500;

			return groupWidth;
		}

		public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			double groupWidth = (double)value;

            

			return groupWidth;
		}

		#endregion
	}		 
}
