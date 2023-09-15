#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{
	public class CornerRadiusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Theme theme = null;
			if (parameter is SfChart3D chart3D)
				theme = SfSkinManager.GetTheme(chart3D);
			else if(parameter is SfChart chart)
				theme = SfSkinManager.GetTheme(chart);

			if (theme != null && (theme.ThemeName.Equals("Windows11Light")|| theme.ThemeName.Equals("Windows11Dark")))
			{
				return 4;
			}
			else
				return 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
