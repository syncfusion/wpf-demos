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
using Syncfusion.Windows.Tools.Controls;

namespace ItemsSourceDemo
{
    public class ContextMenuAction : TriggerAction<GroupBar>
    {
        GroupBar gBar;
        protected override void Invoke(object parameter)
        {
            gBar = Target as GroupBar;
            if (gBar != null)
            {
                ViewModel vm = gBar.DataContext as ViewModel;
                vm.SampleList.Add(new Employee() { Name = "New Item", Age = "**", Location = "**** ****", Image = "/Resources/contact_person_icon.jpg" });
            }
        }


        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(ContextMenuAction), new UIPropertyMetadata(null));


    }
}
