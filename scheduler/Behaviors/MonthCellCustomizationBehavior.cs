#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;

namespace syncfusion.schedulerdemos.wpf
{
    class MonthCellCustomizationBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.ViewChanged += OnSchedulerViewChanged;
        }

        private void OnSchedulerViewChanged(object sender, ViewChangedEventArgs e)
        {
            if (this.AssociatedObject.ViewType == SchedulerViewType.Month && e.NewValue != null)
            {
                this.AssociatedObject.SelectedDate = e.NewValue.ActualStartDate;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.ViewChanged -= OnSchedulerViewChanged;
        }
    }
}
