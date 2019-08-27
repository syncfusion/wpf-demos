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
using System.Threading.Tasks;
using System.Windows.Data;

namespace MasterDetailsExportingDemo
{
    public class EccelOptionsConverter : IMultiValueConverter
    {
        private static bool _isCustomize=false;
        public bool isCustomized
        {
            get
            {
                return _isCustomize;
            }
            set
            {
                _isCustomize = value;

            }
        }

        private static bool _isCustomizeRow=false;
        public bool IsCustomizeRow
        {
            get
            {
                return _isCustomizeRow;
            }
            set
            {
                _isCustomizeRow = value;

            }
        }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var options = new ExcelExportingOptions();
            if ((bool)values[0])
                isCustomized = true;
            else
                isCustomized = false;
            
            if ((bool)values[1])
                IsCustomizeRow = true;
            else
                IsCustomizeRow = false;
            
            return options;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
