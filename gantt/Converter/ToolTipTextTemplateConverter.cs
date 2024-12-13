#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.ganttdemos.wpf
{
    using Syncfusion.Windows.Controls.Gantt;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Represents the class which converts tooltip text values.
    /// </summary>
    public class ToolTipTextTemplateConverter : IValueConverter
    {
        /// <summary>
        /// Converts tooltip text values.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return 0;
            }

            string paramValue = (string)parameter;
            if (value is Task taskDetails)
            {
                if (paramValue == "TaskId")
                {
                    return taskDetails.Id;
                }
                else if (paramValue == "StartDate")
                {
                    return taskDetails.StDate;
                }
                else if (paramValue == "FinishDate")
                {
                    return taskDetails.EndDate;
                }
                else if (paramValue == "Progress")
                {
                    return taskDetails.Complete;
                }
            }
            else if (value is ResizingTooltipInfo resizingTooltipInfo)
            {
                if (paramValue == "StartDate")
                {
                    return resizingTooltipInfo.StartTime;
                }
                else if (paramValue == "FinishDate")
                {
                    return resizingTooltipInfo.EndTime;
                }
            }

            return value;
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
