#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System.Windows.Data;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace syncfusion.propertygriddemos.wpf
{
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
            if (info.Value == null)
            {
                PrivateEmployee privateEmployee = new PrivateEmployee();
                privateEmployee.Image = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute));
                info.Value = privateEmployee.Image;
            }
            BindingOperations.SetBinding(image, Image.SourceProperty, binding);
        }

        Image image;
        public object Create(PropertyInfo propertyInfo)
        {
            image = new Image();
            image.Source = new BitmapImage();
            image.MaxHeight = 200;
            image.MaxWidth = 200;
            return image;
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
            if (image != null)
            {
                image.Source = null;
                image = null;
            }
        }
    }
}
