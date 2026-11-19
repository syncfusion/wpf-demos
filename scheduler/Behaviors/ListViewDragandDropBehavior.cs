using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Scheduler;
using System;
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

            if (appointment.EventName == string.Empty)
                appointment.EventName = "(No title)";

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
