#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
    public class RadialMenuBehaviors : Behavior<RadialMenuDemosView>
    {
        private Point rect;
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {          
            AssociatedObject.defaultmenu.Loaded += Defaultmenu_Loaded;
            AssociatedObject.text.PreviewMouseDown += Text_PreviewMouseDown;
            AssociatedObject.text.PreviewMouseUp += Text_PreviewMouseUp;           
        }

        private void Defaultmenu_Loaded(object sender, RoutedEventArgs e)
        {
            Binding binding = new Binding();
            binding.Path = new PropertyPath("CenterBackButtonForeground");
            binding.Source = AssociatedObject.defaultmenu;
            BindingOperations.SetBinding(AssociatedObject.defaulticon, System.Windows.Shapes.Path.FillProperty, binding);
        }

        private void Text_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rect = e.GetPosition(AssociatedObject.text);
            if (rect != null)
            {
                double left = AssociatedObject.text.ActualWidth - 200;
                double top = AssociatedObject.text.ActualHeight - 200;
                if (rect.X > left)
                {
                    rect.X = Math.Abs(left - (rect.X - left));
                }
                AssociatedObject.transform1.X = AssociatedObject.transform2.X = rect.X - 50;
                if (AssociatedObject.transform1.X < 0 && AssociatedObject.transform2.X < 0)
                {
                    AssociatedObject.transform1.X = AssociatedObject.transform2.X = 0.0;
                }

                if (rect.Y > top)
                {
                    rect.Y = Math.Abs(top - (rect.Y - top));
                }

                AssociatedObject.transform1.Y = AssociatedObject.transform2.Y = rect.Y - 100;
            }
        }

        private void Text_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rect = e.GetPosition(AssociatedObject.text);
            AssociatedObject.defaultmenu.IsOpen = false;
            AssociatedObject.selectionmenu.IsOpen = false;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.text.PreviewMouseDown -= Text_PreviewMouseDown;
            AssociatedObject.text.PreviewMouseUp -= Text_PreviewMouseUp;
            AssociatedObject.defaultmenu.Loaded -= Defaultmenu_Loaded;
        }
    }
}
