#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Charts;

namespace CustomSeriesDemo
{
    public class ScatterAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ScatterSegment).YData;
            var angle = (ydata >= 25) ? 180 : 0;

            return angle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ScatterAdornmentForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ChartAdornment).YData;
            if (ydata >= 25)
                return new SolidColorBrush(Colors.White);
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ScatterAdornmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = ((value as ChartAdornment).YData);
            var variate = ((value as ChartAdornment).Item as ScatterDataValues).Variation;
            if (ydata >= 25)
                return String.Format("+" + variate);
            return String.Format("-" + variate);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ScatterInteriorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ScatterSegment).YData;
            Brush interior;

            interior = ydata >= 25 ? new SolidColorBrush(Color.FromArgb(0xFF, 0x8B, 0xC3, 0x4A)) :
               new SolidColorBrush(Color.FromArgb(0xFF, 0xD1, 0xD3, 0xD4)); ;

            return interior;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColumnPointsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ColumnSegment).XData;
            Point point = new Point();
            if (ydata == 0.0)
            {
                point.X = 0;
                point.Y = 0;
            }
            else if (ydata == 1.0)
            {
                point.X = 0;
                point.Y = 0.4;
            }
            else if (ydata == 3.0)
            {
                point.X = 0;
                point.Y = 0.4;
            }
            else if (ydata == 2.0)
            {
                point.X = 0;
                point.Y = 0.2;
            }
            else if (ydata == 4.0)
            {
                point.X = 0;
                point.Y = 0.1;
            }

            return point;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColumnPointsConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ColumnSegment).XData;
            Point point = new Point();
            if (ydata == 0.0)
            {
                point.X = 0;
                point.Y = 0.25;
            }
            else if (ydata == 1.0)
            {
                point.X = 0;
                point.Y = 0.1;
            }
            else if (ydata == 3.0)
            {
                point.X = 0;
                point.Y = 0.25;
            }
            else if (ydata == 2.0)
            {
                point.X = 0;
                point.Y = 0;
            }
            else if (ydata == 4.0)
            {
                point.X = 0;
                point.Y = 0.2;
            }

            return point;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColumnPointsConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ColumnSegment).XData;
            Point point = new Point();
            if (ydata == 0.0)
            {
                point.X = 0;
                point.Y = 0.25;
            }
            else if (ydata == 1.0)
            {
                point.X = 0;
                point.Y = 0.1;
            }
            else if (ydata == 3.0)
            {
                point.X = 0;
                point.Y = 0.25;
            }
            else if (ydata == 2.0)
            {
                point.X = 0;
                point.Y = 0;
            }
            else if (ydata == 4.0)
            {
                point.X = 0;
                point.Y = 0.2;
            }

            return point;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SplineValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as SplineSegment).YData;
            Brush interior;

            interior = ydata > 0 ? 
                new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xC1, 0x07)) : 
                new SolidColorBrush(Color.FromArgb(0xFF, 0xD1, 0xD3, 0xD4));

            return interior;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BarTopConverter : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var itemData = (item as BarSegment).XData;

            if (itemData == 0.0)
                return ChartDictionary.GenericDictionary["carTemplate1"] as DataTemplate;
            else if (itemData == 1.0)
                return ChartDictionary.GenericDictionary["carTemplate2"] as DataTemplate;
            else if (itemData == 2.0)
                return ChartDictionary.GenericDictionary["carTemplate3"] as DataTemplate;
            else if (itemData == 3.0)
                return ChartDictionary.GenericDictionary["carTemplate4"] as DataTemplate;
            return ChartDictionary.GenericDictionary["carTemplate5"] as DataTemplate;
        }
    }
}
