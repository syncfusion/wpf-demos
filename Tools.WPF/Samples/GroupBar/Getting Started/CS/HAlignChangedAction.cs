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
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;

namespace GroupBarDemo
{
    public class HAlignChangedAction : TriggerAction<ComboBox>
    {
        Syncfusion.Windows.Tools.Controls.GroupView grpview;

        protected override void Invoke(object parameter)
        {
            grpview = Target as Syncfusion.Windows.Tools.Controls.GroupView;
            if (grpview != null && parameter is SelectionChangedEventArgs && (parameter as SelectionChangedEventArgs).AddedItems.Count>0)
            {
                grpview.HorizontalContentAlignment = (HorizontalAlignment)(parameter as SelectionChangedEventArgs).AddedItems[0];
            }
        }

        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(HAlignChangedAction), new UIPropertyMetadata(null));
    }
}
