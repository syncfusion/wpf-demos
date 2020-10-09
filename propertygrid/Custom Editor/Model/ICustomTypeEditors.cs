#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Windows.PropertyGrid;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace syncfusion.propertygriddemos.wpf
{
    public class UpDownEditor : ITypeEditor
    {
        UpDown upDown;
        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            if (info.CanWrite)
            {
                var binding = new Binding("Value")
                {
                    Mode = BindingMode.TwoWay,
                    Source = info,
                    ValidatesOnExceptions = true,
                    ValidatesOnDataErrors = true
                };

                BindingOperations.SetBinding(upDown, UpDown.ValueProperty, binding);
                upDown.IsEnabled = true;
            }
            else
            {
                upDown.AllowEdit = false;
                var binding = new Binding("Value")
                {
                    Source = info,
                    ValidatesOnExceptions = true,
                    ValidatesOnDataErrors = true
                };

                BindingOperations.SetBinding(upDown, UpDown.ValueProperty, binding);
                upDown.IsTabStop = false;
                upDown.IsHitTestVisible = false;
                upDown.IsEnabled = false;
            }
        }

        public object Create(PropertyInfo propertyInfo)
        {
            upDown = new UpDown()
            {
                ApplyZeroColor = false
            };

            if (propertyInfo.Name == "FontSize" || propertyInfo.Name == "MinWidth" || propertyInfo.Name == "MinHeight" || propertyInfo.Name == "MaxHeight" || propertyInfo.Name == "MaxWidth" ||
                propertyInfo.Name == "Height" || propertyInfo.Name == "Width" || propertyInfo.Name == "ActualWidth" || propertyInfo.Name == "ActualHeight")
            {
                upDown.MinValue = 0;
            }

            if (propertyInfo.Name == "FontSize")
            {
                upDown.MaxValue = 35790;
            }

            if (propertyInfo.Name == "Opacity")
            {
                upDown.MinValue = 0.0;
                upDown.MaxValue = 1.0;
                upDown.Step = 0.1;
            }

            return upDown;
        }

        public void Detach(PropertyViewItem property)
        {
            
        }
    }

    public class ImageEditor : ITypeEditor
    {
        ImageBrowser imgbrowser;
        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            var binding = new Binding("Value")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true
            };

            BindingOperations.SetBinding(imgbrowser, ImageBrowser.ImageSourceProperty, binding);
        }
        
        public object Create(PropertyInfo propertyInfo)
        {
            imgbrowser = new ImageBrowser();
            return imgbrowser;
        }

        public void Detach(PropertyViewItem property)
        {
            
        }
    }
}
