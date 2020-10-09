#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace TimeslotCustomization
{
    public class CheckBoxControlBehavior : Behavior<CheckBox>
    {
        private MainWindow window;
        private SfScheduler scheduler;
        protected override void OnAttached()
        {
            window = App.Current.MainWindow as MainWindow;
            scheduler = window.Schedule;
            this.AssociatedObject.Click += AssociatedObject_Click;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= AssociatedObject_Click;
            window = null;
            scheduler = null;
        }
        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            if (this.AssociatedObject.Name == "showHeader")
            {
                if ((bool)AssociatedObject.IsChecked)
                {
                    this.scheduler.DaysViewSettings.ViewHeaderHeight = 50;
                    this.scheduler.TimelineViewSettings.ViewHeaderHeight = 50;
                }
                else
                {
                    this.scheduler.DaysViewSettings.ViewHeaderHeight = 0;
                    this.scheduler.TimelineViewSettings.ViewHeaderHeight = 0;
                }
            }
            else
            {
                if ((bool)AssociatedObject.IsChecked)
                {
                    this.scheduler.DaysViewSettings.TimeRulerSize = 52;
                    this.scheduler.TimelineViewSettings.TimeRulerSize = 30;
                }
                else
                {
                    this.scheduler.DaysViewSettings.TimeRulerSize = 0;
                    this.scheduler.TimelineViewSettings.TimeRulerSize = 0;
                }
            }
        }
    }
}
