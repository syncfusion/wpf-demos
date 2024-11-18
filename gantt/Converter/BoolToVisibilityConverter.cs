#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace syncfusion.ganttdemos.wpf
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts bool to visbility.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object values, Type targetType, object parameter, CultureInfo culture)
        {
            string paramValue = (string)parameter;
            if (values is Task)
            {
                return paramValue == "MouseOver" ? Visibility.Visible : Visibility.Collapsed;
            }
            else if (values is ResizingTooltipInfo tooltipInfo)
            {
                if (paramValue == "ProgressResizing" && tooltipInfo.StartTime.Equals(DateTime.MinValue)
                    && tooltipInfo.EndTime.Equals(DateTime.MinValue))
                {
                    return Visibility.Visible;
                }

                else if (paramValue == "DateTimeResizing" && !tooltipInfo.StartTime.Equals(DateTime.MinValue)
                    && !tooltipInfo.EndTime.Equals(DateTime.MinValue))
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
