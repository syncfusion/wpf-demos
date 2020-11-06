#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.patientmonitor.wpf
{
    public class TextConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = null;
            if (value is string)
            {
                DateTime labelValue = System.Convert.ToDateTime(value.ToString());
                if (parameter.ToString().Equals("0"))
                {
                    res = labelValue.ToString("hh:mm:ss");
                }
                else
                    res = labelValue.ToString("dd/MM");
            }
            else
            {
                ChartAxisLabel axlabel = value as ChartAxisLabel;
                DateTime labelValue = System.Convert.ToDateTime(axlabel.LabelContent.ToString());

                if (parameter.ToString().Equals("0"))
                {
                    res = labelValue.ToString("hh:mm:ss");
                }
                else
                    res = labelValue.ToString("dd/MM");
            }
            return res;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
