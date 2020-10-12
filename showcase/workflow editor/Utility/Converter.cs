#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;

namespace syncfusion.workfloweditor.wpf
{

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string val = (string)value;

                if (val == "String")
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }
    }

    public class NumberTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;

            if (val == "Double")
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CalendarTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;

            if (val == "DatePicker")
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RatingTypeToVisiblityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;
            if (val == "Rating")
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TimeTypeToVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;
            if (val == "TimePicker")
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorPickerToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;

            if (val == "ColorPicker")
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            string typeValue = value.ToString();
            string parameterValue = parameter.ToString();
            return typeValue.Equals(parameterValue, StringComparison.InvariantCultureIgnoreCase);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null) return null;
            bool useValue = (bool)value;
            if (useValue) return parameter.ToString();
            return null;
        }
    }

    public class TypeToVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string val = (string)value;
                if (val == "String")
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                object obj = (object)value;
                if (obj.GetType() == typeof(ProcessAutomationConnector))
                {
                    return Visibility.Collapsed;
                }
                else if (obj.GetType() == typeof(ProcessAutomationNode))
                {
                    if ((obj as ProcessAutomationNode).Content != null)
                    {
                        if (((obj as ProcessAutomationNode).Content as NodeContent).DispalyText == "Yes" || ((obj as ProcessAutomationNode).Content as NodeContent).DispalyText == "No" || ((obj as ProcessAutomationNode).Content as NodeContent).DispalyText == "Start" || ((obj as ProcessAutomationNode).Content as NodeContent).DispalyText == "End")
                        {
                            return Visibility.Collapsed;
                        }
                    }
                    return Visibility.Visible;
                }
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                object obj = (object)value;
                if (obj.GetType() == typeof(ProcessAutomationConnector))
                {
                    return Visibility.Collapsed;
                }
                else if (obj.GetType() == typeof(ProcessAutomationNode))
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NodeDataTemplator : DataTemplateSelector
    {
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.workfloweditor.wpf;component/Template/ProcessNodeEditorTemplate.xaml", UriKind.RelativeOrAbsolute)
        };

        public override DataTemplate SelectTemplate
           (object item, DependencyObject container)
        {
            if (item is NodeContent)
            {
                return resourceDictionary["propertyeditor"] as DataTemplate;
            }
            return null;
        }
    }

    public class NodeValueDataTemplate : DataTemplateSelector
    {
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.workfloweditor.wpf;component/Template/ProcessNodeEditorTemplate.xaml", UriKind.RelativeOrAbsolute)
        };

        public override DataTemplate SelectTemplate
          (object item, DependencyObject container)
        {
            if (item is NodeContent)
            {
                return resourceDictionary["ValueEditor"] as DataTemplate;
            }
            return null;
        }
    }

    public class vb:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
