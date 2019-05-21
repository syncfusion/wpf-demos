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
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;
using System.Windows.Data;
using System.Windows;

namespace ChartSeriesConfiguration
{
    public class SeriesConfigViewModel
    {
        public SeriesConfigViewModel()
        {
            this.Power = new ObservableCollection<Power>();
            DateTime yr = new DateTime(2001, 5, 1);
            Power.Add(new Power() { year = yr.AddYears(0), high = 1255, low = 1040, open = 1246, close = 1050 });
            Power.Add(new Power() { year = yr.AddYears(1), high = 1100, low = 890, open = 1050, close = 937 });
            Power.Add(new Power() { year = yr.AddYears(2), high = 1090, low = 920, open = 937, close = 1076 });
            Power.Add(new Power() { year = yr.AddYears(3), high = 1085, low = 1008, open = 1076, close = 1029 });
            Power.Add(new Power() { year = yr.AddYears(4), high = 1029, low = 979, open = 1029, close = 994 });
            Power.Add(new Power() { year = yr.AddYears(5), high = 1000, low = 610, open = 994, close = 623 });
            Power.Add(new Power() { year = yr.AddYears(6), high = 750, low = 605, open = 623, close = 639 });
            Power.Add(new Power() { year = yr.AddYears(7), high = 640, low = 435, open = 639, close = 455 });
           
        }
        
        public ObservableCollection<Power> Power
        {
            get;
            set;
        }

        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                          ChartColorPalette.MixedFantasy
                                        };
            }
        }
        public Array SeriesType
        {
            get
            {
                return new ChartTypes[] 
                { 
                                          ChartTypes.Area,
                                          ChartTypes.Bar,
                                          ChartTypes.BoxAndWhisker,
                                          ChartTypes.Bubble,
                                          ChartTypes.Candle,
                                          ChartTypes.Column,
                                          ChartTypes.FastBar,
                                          ChartTypes.FastColumn,
                                          ChartTypes.FastHiLoOpenClose,
                                          ChartTypes.FastLine,
                                          ChartTypes.FastScatter,
                                          ChartTypes.Gantt,
                                          ChartTypes.HiLo,
                                          ChartTypes.HiLoArea,
                                          ChartTypes.HiLoOpenClose,
                                          ChartTypes.Line,
                                          ChartTypes.Polar,
                                          ChartTypes.Radar,
                                          ChartTypes.RangeArea,
                                          ChartTypes.RangeColumn,
                                          ChartTypes.RotatedSpline,
                                          ChartTypes.Scatter,
                                          ChartTypes.Spline,
                                          ChartTypes.SplineArea,
                                          ChartTypes.StepArea,
                                          ChartTypes.StepLine,
                                          ChartTypes.ThreeLineBreak
                };
            }
        }


    }
    public class BoolToBoolConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InteriorConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return String.Empty;

            ChartSegment seg = value as ChartSegment;
            return seg.Interior;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
