namespace syncfusion.ganttdemos.wpf
{
    using Syncfusion.Windows.Controls.Gantt;
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows;

    /// <summary>
    /// Represents the class which converts boolean value to visibility.
    /// </summary>
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
            if (values is Task || values is Item)
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
