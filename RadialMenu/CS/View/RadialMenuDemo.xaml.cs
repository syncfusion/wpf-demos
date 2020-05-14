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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Navigation;

namespace SfRadialMenu
{
    /// <summary>
    /// Interaction logic for RadialMenuDemo.xaml
    /// </summary>
    public partial class RadialMenuDemo : UserControl
    {
        public RadialMenuDemo()
        {
            InitializeComponent();          
        }

        private Point rect;

        ///Need to get the position of the mouse button event args so these are evne not moved to view model

        private void Text_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            rect=e.GetPosition(text);
            defaultmenu.IsOpen = false;
            selectionmenu.IsOpen = false;
        }

        private void Text_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            rect = e.GetPosition(text);
            if (rect != null)
            {
                double left = text.ActualWidth - 200;
                double top = text.ActualHeight - 200;
                if (rect.X > left)
                {
                    rect.X = Math.Abs(left - (rect.X - left));
                }
                transform1.X = transform2.X = rect.X - 50;
                if (transform1.X < 0 && transform2.X < 0)
                {
                    transform1.X = transform2.X = 0.0;
                }

                if (rect.Y > top)
                {
                    rect.Y = Math.Abs(top - (rect.Y - top));
                }

                transform1.Y = transform2.Y = rect.Y - 100;
            }
        }
    }
}
