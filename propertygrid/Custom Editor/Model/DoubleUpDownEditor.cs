#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace syncfusion.propertygriddemos.wpf
{
    public class DoubleUpDownEditor : ITypeEditor
    {
        UpDown doubleUpDown;
        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            //If property is enabled, allow the editor to edit
            if (info.CanWrite)
            {
                var binding = new Binding("Value")
                {
                    Mode = BindingMode.TwoWay,
                    Source = info,
                    ValidatesOnExceptions = true,
                    ValidatesOnDataErrors = true
                };

                BindingOperations.SetBinding(doubleUpDown, UpDown.ValueProperty, binding);
                doubleUpDown.IsEnabled = true;
            }

            //If property is not readonly, disable the editor
            else
            {
                doubleUpDown.AllowEdit = false;
                var binding = new Binding("Value")
                {
                    Source = info,
                    ValidatesOnExceptions = true,
                    ValidatesOnDataErrors = true
                };

                BindingOperations.SetBinding(doubleUpDown, UpDown.ValueProperty, binding);
                doubleUpDown.IsTabStop = false;
                doubleUpDown.IsHitTestVisible = false;
                doubleUpDown.IsEnabled = false;
            }
        }

        public object Create(PropertyInfo propertyInfo)
        {
            doubleUpDown = new UpDown()
            {
                ApplyZeroColor = false,
                NumberDecimalDigits = 2,
                MinValue = 1.00,
                BorderThickness = new Thickness(0),
                CornerRadius = new CornerRadius(0)
            };
            return doubleUpDown;
        }
        public object Create(PropertyDescriptor PropertyDescriptor)
        {
            throw new NotImplementedException();
        }


        public bool ShouldPropertyGridTryToHandleKeyDown(Key key)
        {
            return false;
        }
        public void Detach(PropertyViewItem property)
        {

        }
    }
}
