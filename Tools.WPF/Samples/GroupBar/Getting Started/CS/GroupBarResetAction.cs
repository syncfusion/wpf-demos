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
using System.Windows;
using System.Windows.Controls;

namespace GroupBarDemo
{
    public class GroupBarResetAction:TriggerAction<Button>
    {
        Syncfusion.Windows.Tools.Controls.GroupBar myGroupBar;

        protected override void Invoke(object parameter)
        {
            myGroupBar = Target as Syncfusion.Windows.Tools.Controls.GroupBar;
            if (myGroupBar != null)
            {
                myGroupBar.ResetBarState();
            }
        }

        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(GroupBarResetAction), new UIPropertyMetadata(null));
    }
}
