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
using System.Windows.Input;
using Syncfusion.Windows.Controls.Gantt;
using System.Windows;

namespace ProjectScheduler
{
    /// <summary>
    /// Code for delete the selected task
    /// </summary>
    public class DeleteTaskCommand
    {
        static DeleteTaskCommand()
        {
            //Registering the DeleteTask command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(DeleteTask, OnExecuteDeleteTask, OnCanExecuteDeleteTask));
        }

        public static RoutedCommand DeleteTask = new RoutedCommand("DeleteTask", typeof(GanttControl));

        /// <summary>
        /// Called when [execute delete task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteDeleteTask(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;

            /// This will delete only the first Item of the seleted Item from the source
            TaskDetails task = gantt.Model.GetParentOfItem(gantt.SelectedItems[0]) as TaskDetails;
            if (task == null)
                gantt.Model.InbuiltTaskCollection.Remove(gantt.SelectedItems[0] as TaskDetails);
            else
                task.Child.Remove(gantt.SelectedItems[0] as IGanttTask);
            gantt.SelectedItems.Clear();
        }

        /// <summary>
        /// Called when [can execute delete task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteDeleteTask(object sender, CanExecuteRoutedEventArgs args)
        {
            GanttControl gantt = sender as GanttControl;
            if (gantt.SelectedItems == null || gantt.SelectedItems.Count <= 0)
            {
                args.CanExecute = false;
            }
            else
                args.CanExecute = true;
        }
    }
}
