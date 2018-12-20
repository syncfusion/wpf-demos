#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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

namespace PyramidChart
{
   
    public class PyramidChartModel
    {
        public PyramidChartModel()
        {
            productlist = new List<AgriculturalProducts>();
            productlist.Add(new AgriculturalProducts() { ProductName = "Oats", GrowthPercentage = 21 });
            productlist.Add(new AgriculturalProducts() { ProductName = "Rice", GrowthPercentage = 20 });
            productlist.Add(new AgriculturalProducts() { ProductName = "Maize", GrowthPercentage = 19 });
            productlist.Add(new AgriculturalProducts() { ProductName = "Barley", GrowthPercentage = 23 });
            productlist.Add(new AgriculturalProducts() { ProductName = "Wheat", GrowthPercentage = 25 });
        }

        public List<AgriculturalProducts> productlist
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
            if (!(value is AgriculturalProducts))
                return string.Empty;

            AgriculturalProducts info = value as AgriculturalProducts;
            
            return String.Format("{0}%",  info.GrowthPercentage);

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
            if (!(value is AgriculturalProducts))
                return string.Empty;

            AgriculturalProducts info = value as AgriculturalProducts;

            return String.Format("{0}", info.ProductName);

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
    public class ToolTipConv : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            String tooltiptype = (String)parameter;

            if (tooltiptype == "Chart")
            {
                if (val)
                {
                    string tooltip = "Chart ToolTip";
                    return tooltip;
                }
                else
                {
                    return null;
                }
            }

            if (tooltiptype == "ChartLegend")
            {
                if (val)
                {
                    string tooltip = "Chart Legend ToolTip";
                    return tooltip;
                }
                else
                {
                    return null;
                }
            }

            if (tooltiptype == "ChartArea")
            {
                if (val)
                {
                    string tooltip = "Chart Area ToolTip";
                    return tooltip;
                }
                else
                {
                    return null;
                }
            }

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion
   

}
