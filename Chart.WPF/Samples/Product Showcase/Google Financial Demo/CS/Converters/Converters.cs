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
using Syncfusion.Windows.Chart;
using System.Windows.Data;

namespace GoogleFinanceDemo
{
    public class StarttimeConvertor : IMultiValueConverter
    {

        #region IMultiValueConverter Members

        public static ChartAxis axis;
        ChartArea area;

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            area = parameter as ChartArea;
            double zoomingFactor = (double)values[0];
            double zoomingPosition = (double)values[1];
            axis = (ChartAxis)values[2];

            return axis.VisibleRange.Start;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {

            double StartValue = (double)value;
            double endValue = area.EndValue;
            double TotalValueStart = axis.Range.Start;
            double TotalValueEnd = axis.Range.End;

            double ZoomingFactor = (endValue - StartValue) / (TotalValueEnd - TotalValueStart);
            double ZoomingPosition = ((StartValue - axis.Range.Start)) / axis.Range.Delta; //(StartValue + ((endValue - StartValue) / 2)) / axis.Range.Delta;

            object[] ret = { ZoomingFactor, ZoomingPosition, axis };
            return ret;
        }

        #endregion
    }

    public class EndtimeConvertor : IMultiValueConverter
    {

        #region IMultiValueConverter Members

        public ChartAxis axis;
        ChartArea area;

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            area = parameter as ChartArea;
            double zoomingFactor = (double)values[0];
            double zoomingPosition = (double)values[1];
            this.axis = (ChartAxis)values[2];

            return axis.VisibleRange.End;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {

            double endValue = (double)value;
            double StartValue = area.StartValue;
            double TotalValueStart = axis.Range.Start;
            double TotalValueEnd = axis.Range.End;

            double ZoomingFactor = (endValue - StartValue) / (TotalValueEnd - TotalValueStart);
            double ZoomingPosition = (StartValue - axis.Range.Start) / axis.Range.Delta;

            object[] ret = { ZoomingFactor, ZoomingPosition, this.axis };
            return ret;
        }

        #endregion
    }

    public class LabelConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(ChartAxisLabel))
            {
                DateTime date;
                DateTime.TryParse((value as ChartAxisLabel).Content.ToString(), out date);
                if (date.Month >= 1 && date.Month <= 3)
                {
                    return "Q1";
                }
                else if (date.Month >= 4 && date.Month <= 6)
                {
                    return "Q2";
                }
                else if (date.Month >= 7 && date.Month <= 9)
                {
                    return "Q3";
                }
                else if (date.Month >= 10 && date.Month <= 12)
                {
                    return "Q4";
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   }
