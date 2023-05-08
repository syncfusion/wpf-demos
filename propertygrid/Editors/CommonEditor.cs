#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.propertygriddemos.wpf
{
    public class MobileNoEditor : MaskEditor
    {
        public MobileNoEditor()
        {
            Mask = @"\(\d{3}\) \d{3} - \d{4}";
        }
    }
    public class AccountNo : MaskEditor
    {
        public AccountNo()
        {
            Mask = @"\d{12}";
        }
    }
    public class PasswordEditor : BaseTypeEditor
    {
        PasswordBox passwordBox;
        public override void Attach(PropertyViewItem property, PropertyItem info)
        {
            if (info.CanWrite)
            {
                passwordBox.IsEnabled = true;
            }
            else
            {
                passwordBox.IsEnabled = false;
            }

            passwordBox.Password = info.Value.ToString();
        }

        public override object Create(PropertyInfo PropertyInfo)
        {
            passwordBox = new PasswordBox() { BorderThickness = new Thickness(0), Padding = new Thickness(0) };
            return passwordBox;
        }

        public override object Create(PropertyDescriptor PropertyDescriptor)
        {
            passwordBox = new PasswordBox();
            return passwordBox;
        }

        public override void Detach(PropertyViewItem property)
        {
            passwordBox = null;
        }

        /// <summary>
        /// Overrides the handling of keydown event. If the method returns true, PropertyGrid handles the KeyDown event and focus will be moved to next focusable editor, otherwise the event will not handle by the PropertyGrid.
        /// </summary>
        /// <param name="key">A <see cref="KeyEventArgs" /> object.</param>
        /// <returns>True if the property grid should be allowed to handle keys; false otherwise.</returns>
        public override bool ShouldPropertyGridTryToHandleKeyDown(Key key)
        {
            if (key == Key.Up || key == Key.Down)
                return true;

            return base.ShouldPropertyGridTryToHandleKeyDown(key);
        }
    }
}