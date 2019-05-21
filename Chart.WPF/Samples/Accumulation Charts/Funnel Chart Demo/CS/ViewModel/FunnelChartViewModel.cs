#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.Shared;

namespace FunnelChart
{
   
    public class FunnelChartModel
    {
        public FunnelChartModel()
        {
            productlist = new List<Power>();
            productlist.Add(new Power() {  source = "Oil", percentage = 30 });
            productlist.Add(new Power() {  source = "Hydro", percentage = 15 });
            productlist.Add(new Power() { source = "Nuclear", percentage = 15 });
            productlist.Add(new Power() { source = "Gas", percentage = 15 });
            productlist.Add(new Power() { source = "Coal", percentage = 25 });
        }
             
        public List<Power> productlist
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
                                          
                                        };
            }
        }
        public Array SegmentLabelContentPathCollection
        {
            get { return Enum.GetValues(typeof(LabelContent)); }
        }
    }

    # region Converters
    public class Labelconvertor : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Power))
                return string.Empty;

            Power info = value as Power;
            
            return String.Format("{0}%",  info.percentage);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion


    }

    public class Labelconvertor1 : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Power))
                return string.Empty;

            Power info = value as Power;

            return String.Format("{0}", info.source);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
    public class TooltipConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return String.Empty;

            ChartSegment seg = value as ChartSegment;
            return seg.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
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
   
    #endregion
}
