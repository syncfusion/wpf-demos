#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;

namespace ItemsSourceDemo
{
    public class SampleTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Window win = Application.Current.MainWindow;
            GroupBar gBar = Syncfusion.Windows.Shared.VisualUtils.FindDescendant(win, typeof(GroupBar)) as GroupBar;

            if (gBar != null)
            {
                if (gBar.Orientation == Orientation.Vertical)
                {
                    return win.Resources["vertical"] as DataTemplate;
                }
                else
                {
                    return win.Resources["horizantal"] as DataTemplate;
                }
            }
            else
            {
                return win.Resources["vertical"] as DataTemplate;
            }
        }
    }
}
