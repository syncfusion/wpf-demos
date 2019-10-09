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
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Shapes;

namespace CategoryEditorDemo
{
    public class ElementTotypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                Type type = value.GetType();
                return type.Name;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ObjectToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string obj = ((ComboBoxItem)value).Content.ToString();
            string param = parameter.ToString();
            if (obj.Contains("Person"))
            {
                return Visibility.Collapsed;
            }

            if (obj == param)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ObjectConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ComboBoxItem item = (ComboBoxItem)value;
            Grid grid1 = ((ComboBox)item.Parent).Parent as Grid;
            Grid grid = grid1.Children[1] as Grid;
            if (grid != null)
            {
                foreach (UIElement child in grid.Children)
                {
                    if (child.Visibility == Visibility.Visible)
                    {
                        return child;
                    }
                }
            }
            return App.Current.MainWindow.Resources["person"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class PersonToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ComboBoxItem item = (ComboBoxItem)value;
            if (item.Content.ToString().Contains("Person"))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class NameToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FrameworkElement element = value as FrameworkElement;
            string str;
            if (element != null)
            {
                str = element.Name;
                if (string.IsNullOrEmpty(str))
                {
                    return "<no name>";
                }
            }
            else
            {
                return "<no name>";
            }

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ElementToImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VisualBrush source = new VisualBrush();
            source.Stretch = Stretch.Uniform;
            ImageBrush brush = new ImageBrush();
            brush.Stretch = Stretch.Uniform;
            if (value is Visual)
            {
                source.Visual = value as Visual;
                return source;
            }
            else
            {

                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class SelectedIndexToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = (int)value;
            Visibility vis;
            if (index == 0 && parameter.ToString() == "Foreground")
            {
                vis = Visibility.Visible;
            }
            else if (index == 1 && parameter.ToString() == "Background")
            {
                vis = Visibility.Visible;
            }
            else if (index == 2 && parameter.ToString() == "OpacityMask")
            {
                vis = Visibility.Visible;
            }
            else
            {
                vis = Visibility.Collapsed;
            }

            return vis;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class FontWeightConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             if (value==null)
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
            else if(parameter.ToString() == "italic")
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
            else if(parameter.ToString() == "italic")
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

    public class VisibilityToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibilityValue = (Visibility)value;
            int heightValue = 0;

            if (visibilityValue == Visibility.Visible || visibilityValue == Visibility.Hidden)
            {
                heightValue = 55;
            }
            else if (visibilityValue == Visibility.Collapsed)
            {
                heightValue = 0;
            }

            return heightValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class FontFamilyComboBox : ComboBox
    {
        public FontFamilyComboBox()
        {
            ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();
            fonts.Add(new FontFamily("Arial"));
            fonts.Add(new FontFamily("Courier New"));
            fonts.Add(new FontFamily("Times New Roman"));
            fonts.Add(new FontFamily("Batang"));
            fonts.Add(new FontFamily("BatangChe"));
            fonts.Add(new FontFamily("DFKai-SB"));
            fonts.Add(new FontFamily("Dotum"));
            fonts.Add(new FontFamily("DutumChe"));
            fonts.Add(new FontFamily("FangSong"));
            fonts.Add(new FontFamily("GulimChe"));
            fonts.Add(new FontFamily("Gungsuh"));
            fonts.Add(new FontFamily("GungsuhChe"));
            fonts.Add(new FontFamily("KaiTi"));
            fonts.Add(new FontFamily("Malgun Gothic"));
            fonts.Add(new FontFamily("Meiryo"));
            fonts.Add(new FontFamily("Microsoft JhengHei"));
            fonts.Add(new FontFamily("Microsoft YaHei"));
            fonts.Add(new FontFamily("MingLiU"));
            fonts.Add(new FontFamily("MingLiu_HKSCS"));
            fonts.Add(new FontFamily("MingLiu_HKSCS-ExtB"));
            fonts.Add(new FontFamily("MingLiu-ExtB"));
            fonts.Add(new FontFamily("Segoe UI"));
            this.ItemsSource = fonts; 
        }
    }
}
