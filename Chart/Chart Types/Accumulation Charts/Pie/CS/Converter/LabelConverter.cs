#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace PieChart
{
    public class LabelConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartAdornment pieAdornment = value as ChartAdornment;

            var model = pieAdornment.Item as Model;

            if (model != null)
            {
                return String.Format(model.Country + " : " + pieAdornment.YData);
            }
            else
            {
                var list = pieAdornment.Item as List<object>;
                string labelData = "";

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i] as Model;
                    labelData = labelData + String.Format(item.Country + " : " + item.Count);

                    if (i + 1 != list.Count)
                    {
                        labelData = labelData + Environment.NewLine;
                    }
                }

                return labelData;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
