#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
   public class ListViewDragandDropBehavior: TargetedTriggerAction<ListView>
    {
        protected override void Invoke(object parameter)
        {
           var listView = this.AssociatedObject as ListView;
            if (listView != null)
            {
                listView.PreviewMouseMove += OnListViewPreviewMouseMove;
                listView.Drop += OnListViewDrop;
            }
        }

        protected override void OnDetaching()
        {
            var listView = this.AssociatedObject as ListView;
            if (listView != null)
            {
                listView.PreviewMouseMove -= OnListViewPreviewMouseMove;
                listView.Drop -= OnListViewDrop;
                listView = null;
            }
                base.OnDetaching();
        }

        /// <summary>
        ///  Occurs when a drag-and-drop operation is ended.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="args" >this contains the event data.</param>
        private void OnListViewDrop(object sender, DragEventArgs e)
        {
            var app = e.Data.GetData("Appointment") as ScheduleAppointment;
            if (app == null)
                return;

            var appointment = app.Data as SchedulerModel;
            var dragDropViewModel = (this.TargetObject as SfScheduler).DataContext as BindingViewModel;

            // condition to Remove appointment from scheduler items source.
            if (dragDropViewModel.SchedulerAppointmentCollection.Contains(appointment))
            {
                dragDropViewModel.SchedulerAppointmentCollection.Remove(appointment);
            }
            //// condition to add appointment into listview items source.
            if (!dragDropViewModel.ListAppointmentCollection.Contains(appointment))
            {
                dragDropViewModel.ListAppointmentCollection.Insert(0, appointment);
            }

            var listView = this.AssociatedObject as ListView;
            if (listView == null)
                return;

            Decorator border = VisualTreeHelper.GetChild(listView, 0) as Decorator;
            if (border != null)
            {
                // Get scrollviewer
                ScrollViewer scrollViewer = border.Child as ScrollViewer;
                if (scrollViewer != null)
                {
                    // Top the Scroll Viewer.
                    scrollViewer.ScrollToVerticalOffset(0.0);
                }
            }
        }

        /// <summary>
        /// Invokes when mouse left button moved on appointment in list view.
        /// </summary>
        private void OnListViewPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ListView listview = sender as ListView;
                var appointment = GetDataFromListBox(listview, e.GetPosition(listview)) as SchedulerModel;
                if (appointment != null)
                {
                    var dataObject = new DataObject();
                    dataObject.SetData("draggingAppointment", appointment);
                    DragDrop.DoDragDrop(listview, dataObject,DragDropEffects.Copy|DragDropEffects.Move);
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// Method is used to get the selected appointment from list view.
        /// </summary>
        private static object GetDataFromListBox(ListBox listView, Point point)
        {
            UIElement element = listView.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = listView.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == listView)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }
    }
}
