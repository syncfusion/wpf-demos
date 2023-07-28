#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// To apply a format to the adornment label.
    /// </summary>
    public class TextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartAdornment pieAdornment = value as ChartAdornment;
            if (pieAdornment == null)
                return string.Empty;

            int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
            StackingBarChart3DViewModel view = pieAdornment.Series.DataContext as StackingBarChart3DViewModel;

            var path = (pieAdornment.Series as XyDataSeries3D).YBindingPath;
            var yValue = "";

            if (path == "Plastic")
            {
                yValue = view.CategoricalDatas[index].Plastic.ToString();
            }
            else if (path == "Iron")
            {
                yValue = view.CategoricalDatas[index].Iron.ToString();
            }
            else if (path == "Metal")
            {
                yValue = view.CategoricalDatas[index].Metal.ToString();
            }


            return path.ToUpper() + " : " + yValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
