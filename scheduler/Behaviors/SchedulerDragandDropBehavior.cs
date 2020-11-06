#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.schedulerdemos.wpf
{
    public class SchedulerDragandDropBehavior : TargetedTriggerAction<SfScheduler>
    {
        private SfScheduler scheduler;
        private DateTime droppingTime;

        protected override void Invoke(object parameter)
        {
            scheduler = this.AssociatedObject as SfScheduler;

            if (scheduler != null)
            {
                scheduler.AppointmentDropping += OnSchedulerAppointmentDropping;
                scheduler.Drop += OnSchedulerDrop;
                scheduler.DragDropSettings.AllowNavigate = false;
            }
        }

        protected override void OnDetaching()
        {
            if (scheduler != null)
            {
                scheduler.AppointmentDropping -= OnSchedulerAppointmentDropping;
                scheduler.Drop -= OnSchedulerDrop;
                scheduler = null;
            }
            base.OnDetaching();
        }

        /// <summary>
        /// Raises the <see cref="AppointmentDropping"/> event in Scheduler.
        /// </summary>
        /// <param name="args">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.Scheduler.AppointmentDroppingEventArgs"/> that contains the event data.        
        /// </param> 
        private void OnSchedulerAppointmentDropping(object sender, AppointmentDroppingEventArgs e)
        {
            droppingTime = e.DropTime;
        }

        /// <summary>
        ///  Occurs when a drag-and-drop operation is ended.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="args" >this contains the event data.</param>
        private void OnSchedulerDrop(object sender, DragEventArgs e)
        {
            var appointment = e.Data.GetData("draggingAppointment") as SchedulerModel;
            if (appointment == null)
                return;

            TimeSpan timeInterval;
            if (scheduler.ViewType == SchedulerViewType.Timeline)
                timeInterval = scheduler.TimelineViewSettings.TimeInterval;
            else
                timeInterval = scheduler.DaysViewSettings.TimeInterval;
            appointment.From = (DateTime)droppingTime;
            appointment.To = appointment.From.Add(timeInterval);

            var dragDropViewModel = (this.AssociatedObject as SfScheduler).DataContext as BindingViewModel;
            // condition to remove appointment from list view items source.
            if (dragDropViewModel.ListAppointmentCollection.Contains(appointment))
            {
                dragDropViewModel.ListAppointmentCollection.Remove(appointment);
            }
            // condition to add appointment into scheduler items source.
            if (!dragDropViewModel.SchedulerAppointmentCollection.Contains(appointment))
            {
                dragDropViewModel.SchedulerAppointmentCollection.Add(appointment);
            }
        }
    }
}
