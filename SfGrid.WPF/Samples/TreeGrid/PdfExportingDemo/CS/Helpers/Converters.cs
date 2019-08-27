#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeGrid.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PDFExportingDemo
{
    public class PDFOptionsConverter : IMultiValueConverter
    {
        private static bool isCutomized = false;
        public bool IsCutomized
        {
            get
            {
                return isCutomized;
            }
            set
            {
                isCutomized = value;
            }
        }


        private static bool isHeaderFooterEnabled = false;
        public bool IsHeaderFooterEnabled
        {
            get
            {
                return isHeaderFooterEnabled; 
            }
            set
            {
                isHeaderFooterEnabled = value;
            }
        }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var options = new TreeGridPdfExportingOptions();

            options.AutoRowHeight = (bool)values[0];
            options.AutoColumnWidth = (bool)values[1];
            options.ExportFormat = (bool)values[2];
            options.CanExportHyperLink = (bool)values[3];
            options.RepeatHeaders = (bool)values[4];
            options.FitAllColumnsInOnePage = (bool)values[5];          
          
            isCutomized = (bool)values[6];
            isHeaderFooterEnabled = (bool)values[7];
            return options;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
