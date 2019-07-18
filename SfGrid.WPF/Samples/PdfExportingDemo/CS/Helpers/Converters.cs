#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace PdfExportingDemo
{
    public class PdfOptionsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var options = new PdfExportingOptions();
            if (!(bool)values[0])
                options.AutoColumnWidth = false;
            if (!(bool)values[1])
                options.AutoRowHeight = false;
            if (!(bool)values[2])
                options.ExportGroups = false;
            if (!(bool)values[3])
                options.ExportGroupSummary = false;
            if (!(bool)values[4])
                options.ExportTableSummary = false;
            if (!(bool)values[5])
                options.RepeatHeaders = false;
            if ((bool)values[6])
                options.FitAllColumnsInOnePage = true;
            
            return options;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
