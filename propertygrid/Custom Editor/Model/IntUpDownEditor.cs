#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.propertygriddemos.wpf
{
    public class IntUpDownEditor : ITypeEditor
    {
        UpDown intUpDown;
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

                BindingOperations.SetBinding(intUpDown, UpDown.ValueProperty, binding);
                intUpDown.IsEnabled = true;
            }

            //If property is not readonly, disable the editor
            else
            {
                intUpDown.AllowEdit = false;
                var binding = new Binding("Value")
                {
                    Source = info,
                    ValidatesOnExceptions = true,
                    ValidatesOnDataErrors = true
                };

                BindingOperations.SetBinding(intUpDown, UpDown.ValueProperty, binding);
                intUpDown.IsTabStop = false;
                intUpDown.IsHitTestVisible = false;
                intUpDown.IsEnabled = false;
            }
        }

        public object Create(PropertyInfo propertyInfo)
        {
            intUpDown = new UpDown()
            {
                ApplyZeroColor = false,
                NumberDecimalDigits = 0,
                BorderThickness = new Thickness(0),
                CornerRadius = new CornerRadius(0)
            };
            if (propertyInfo.Name == "Age")
            {
                intUpDown.MinValue = 25;
                intUpDown.MaxValue = 100;
            }
            else if (propertyInfo.Name == "Experience")
            {
                intUpDown.MinValue = 5;
                intUpDown.MaxValue = 80;
            }

            return intUpDown;
        }

        public void Detach(PropertyViewItem property)
        {

        }
    }
}
