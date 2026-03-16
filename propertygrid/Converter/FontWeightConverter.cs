#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;
using System.Windows;

namespace syncfusion.propertygriddemos.wpf
{
    public class FontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }

            if (parameter.ToString() == "bold")
            {
                FontWeight weight = (FontWeight)value;
                if (weight == FontWeights.Bold)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (parameter.ToString() == "italic")
            {
                FontStyle weight = (FontStyle)value;
                if (weight == FontStyles.Italic)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (parameter.ToString() == "left")
            {
                TextAlignment weight = (TextAlignment)value;
                if (weight == TextAlignment.Left)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (parameter.ToString() == "center")
            {
                TextAlignment weight = (TextAlignment)value;
                if (weight == TextAlignment.Center)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                TextAlignment weight = (TextAlignment)value;
                if (weight == TextAlignment.Right)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "bold")
            {
                bool ischecked = (bool)value;
                if (ischecked)
                {
                    return FontWeights.Bold;
                }
                else
                {
                    return FontWeights.Normal;
                }
            }
            else if (parameter.ToString() == "italic")
            {
                bool ischecked = (bool)value;
                if (ischecked)
                {
                    return FontStyles.Italic;
                }
                else
                {
                    return FontStyles.Normal;
                }
            }
            else if (parameter.ToString() == "left")
            {
                bool ischecked = (bool)value;
                if (ischecked)
                {
                    return TextAlignment.Left;
                }
                else
                {
                    return null;
                }
            }
            else if (parameter.ToString() == "center")
            {
                bool ischecked = (bool)value;
                if (ischecked)
                {
                    return TextAlignment.Center;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                bool ischecked = (bool)value;
                if (ischecked)
                {
                    return TextAlignment.Right;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
