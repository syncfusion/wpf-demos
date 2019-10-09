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
using Syncfusion.Windows.PropertyGrid;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;

namespace CustomEditorDemo
{
    public class UpDownEditor : ITypeEditor
    {

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
            }
        }

        UpDown upDown;
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

    public class BrushEditor : ITypeEditor
    {
        public void Attach(PropertyViewItem property, PropertyItem info)
        {

            var binding = new Binding("Value")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                TargetNullValue = new object()        
            };
            BindingOperations.SetBinding(brushCombo, BrushComboBox.SelectedItemProperty, binding);

        }

        BrushComboBox brushCombo;
        public object Create(PropertyInfo propertyInfo)
        {
            brushCombo = new BrushComboBox()
            {
                
            };
            brushCombo.Loaded += new RoutedEventHandler(brushCombo_Loaded);
            
            return brushCombo;
        }

        void brushCombo_Loaded(object sender, RoutedEventArgs e)
        {
            brushCombo.SelectedIndex = 0;
        }

        public void Detach(PropertyViewItem property)
        {
            
        }
    }

    public class ImageEditor : ITypeEditor
    {

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

        ImageBrowser imgbrowser;
        public object Create(PropertyInfo propertyInfo)
        {
            imgbrowser = new ImageBrowser()
            {

            };
            return imgbrowser;
        }

        public void Detach(PropertyViewItem property)
        {
            
        }
    }

    public class BrushComboBox : ComboBox
    {
        public BrushComboBox()
        {
            Type brush = typeof(Brushes);
            PropertyInfo[] m = brush.GetProperties();
            foreach(PropertyInfo item in m)
            {
                Brush brush1 = (Brush)(new System.Windows.Media.BrushConverter().ConvertFromString(item.Name));
                Items.Add(brush1);
            }
            this.ItemTemplate = App.Current.MainWindow.Resources["BrushCombo"] as DataTemplate;
        }
    }
}
