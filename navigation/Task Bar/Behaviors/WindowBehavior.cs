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
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class WindowBehavior: Behavior<MainWindow>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += (sender, e) =>
            {
                if (e.Source.GetType() == typeof(MainWindow))
                    AssociatedObject.DragOver();
            };

            MainWindow mainwindow = AssociatedObject as MainWindow;
            if (mainwindow != null)
            {
                mainwindow.Loaded += (sender2, e2) =>
                {
                    mainwindow.combo.SelectionChanged += (sender3, e3) =>
                    {
                        SkinStorage.SetVisualStyle(AssociatedObject, ((sender3 as ComboBoxAdv).SelectedItem as ComboBoxItemAdv).Content.ToString());
                    };
                };
            }
        }
    }
}
