#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.schedulerdemos.wpf
{
    public class CheckBoxControlBehavior : Behavior<TimeSlotCustomizationDemo>
    {
        private SfScheduler scheduler;
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            scheduler = AssociatedObject.Schedule;
            this.AssociatedObject.showHeader.Click += AssociatedObject_showHeader_Click;
            this.AssociatedObject.timeRuler.Click += AssociatedObject_timeRuler_Click;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.showHeader.Click -= AssociatedObject_showHeader_Click;
            this.AssociatedObject.timeRuler.Click -= AssociatedObject_timeRuler_Click;
            this.AssociatedObject.showHeader = null;
            this.AssociatedObject.timeRuler = null;
            scheduler = null;
        }
        private void AssociatedObject_showHeader_Click(object sender, RoutedEventArgs e)
        {
                if ((bool)AssociatedObject.showHeader.IsChecked)
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
        private void AssociatedObject_timeRuler_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)AssociatedObject.timeRuler.IsChecked)
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
