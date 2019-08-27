#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DockingDemo
{
	public class BooleanToVisibilityConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			if ( (bool)value )
			{
				return Visibility.Visible;
			}
			else
				return Visibility.Hidden;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
