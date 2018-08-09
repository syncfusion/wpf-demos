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
