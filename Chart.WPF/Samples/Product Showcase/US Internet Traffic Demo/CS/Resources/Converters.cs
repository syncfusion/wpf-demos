#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace ColorPaletteDemo
{
    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.Windows.Data;
    using Syncfusion.Windows.Controls.Map;

    public class SelectedIndexToColorPalette : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int selectedIndex = (int)value;
            switch (selectedIndex)
            {
                case 0:
                    return ColorPalettes.ColorPalette1;

                case 1:
                    return ColorPalettes.ColorPalette2;

                case 2:
                    return ColorPalettes.ColorPalette3;

                case 3:
                    return ColorPalettes.ColorPalette4;

                case 4:
                    return ColorPalettes.ColorPalette5;

                case 5:
                    return ColorPalettes.CustomColorPalette;


                default:
                    return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
     public class SelectedValueToStringConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int selectedIndex = (int)value;
            switch (selectedIndex)
            {
                case 0:
                    return VisualStyles.Blend;

                case 1:
                    return VisualStyles.Default;

                case 2:
                    return VisualStyles.Office2007Black;

                case 3:
                    return VisualStyles.Office2007Blue;

                case 4:
                    return VisualStyles.Office2007Silver;

                case 5:
                    return VisualStyles.Office2010Black;

                case 6:
                    return VisualStyles.Office2010Blue;

                case 7:
                    return VisualStyles.Office2010Silver;

                case 8:
                    return VisualStyles.VS2010;


                default:
                    return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
