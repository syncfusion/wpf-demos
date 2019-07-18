#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SerializationDemo
{
    public class SerializationOptionsConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts source values to a value for the binding target. The data binding
        //  engine calls this method when it propagates the values from source bindings
        //  to the binding target.
        /// </summary>      
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var options = new SerializationOptions();
            if (!(bool)values[0])
                options.SerializeColumns = false;
            if (!(bool)values[1])
                options.SerializeGrouping = false;
            if (!(bool)values[2])
                options.SerializeSorting = false;
            if (!(bool)values[3])
                options.SerializeFiltering = false;
            if (!(bool)values[4])
                options.SerializeGroupSummaries = false;
            if (!(bool)values[5])
                options.SerializeTableSummaries = false;
            if (!(bool)values[6])
                options.SerializeStackedHeaders = false;
            
            return options;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class DeserializationOptionsConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts source values to a value for the binding target. The data binding
        //  engine calls this method when it propagates the values from source bindings
        //  to the binding target.
        /// </summary>      
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var options = new DeserializationOptions();
            if (!(bool)values[0])
                options.DeserializeColumns = false;
            if (!(bool)values[1])
                options.DeserializeGrouping = false;
            if (!(bool)values[2])
                options.DeserializeSorting = false;
            if (!(bool)values[3])
                options.DeserializeFiltering = false;
            if (!(bool)values[4])
                options.DeserializeGroupSummaries = false;
            if (!(bool)values[5])
                options.DeserializeTableSummaries = false;            
            if (!(bool)values[6])
                options.DeserializeStackedHeaders = false;
            return options;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
