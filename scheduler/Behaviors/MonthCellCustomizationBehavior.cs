#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.schedulerdemos.wpf
{
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.UI.Xaml.Scheduler;

    /// <summary>
    /// Represents the behavior that customizes the month view of the scheduler.
    /// </summary>
    public class MonthCellCustomizationBehavior : Behavior<MonthCellCustomizationDemo>
    {
        /// <summary>
        /// The scheduler instance.
        /// </summary>
        private SfScheduler scheduler;

        /// <summary>
        /// Attaches event handlers when the behavior is attached to the associated object.
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += this.OnAssociatedObjectLoaded;
        }

        /// <summary>
        /// Event handler for the loaded event of the associated object.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The routed event args.</param>
        private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            this.scheduler = AssociatedObject.Schedule;
            this.AssociatedObject.showWeekView.Click += this.OnShowWeekViewClick;
            this.AssociatedObject.showWeekNumber.Click += this.OnShowWeekNumberClick;
        }

        /// <summary>
        /// Detaches event handlers when the behavior is being detached from the associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= this.OnAssociatedObjectLoaded;

            this.AssociatedObject.showWeekView.Click -= this.OnShowWeekViewClick;
            this.AssociatedObject.showWeekNumber.Click -= this.OnShowWeekNumberClick;

            this.AssociatedObject.showWeekView = null;
            this.AssociatedObject.showWeekNumber = null;
            this.scheduler = null;
        }

        /// <summary>
        /// Event handler for toggling the visibility of the week view in the scheduler's month view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The events args.</param>
        private void OnShowWeekViewClick(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
            {
                return;
            }

            this.scheduler.MonthViewSettings.NumberOfVisibleWeeks = (bool)checkBox.IsChecked ? 3 : 6;
        }

        /// <summary>
        /// Event handler for toggling the visibility of the week number in the scheduler's month view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The events args.</param>
        private void OnShowWeekNumberClick(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
            {
                return;
            }

            this.scheduler.MonthViewSettings.ShowWeekNumber = (bool)checkBox.IsChecked ? true : false;
        }
    }
}