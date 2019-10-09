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
using System.Collections.ObjectModel;

namespace ProjectScheduler
{
    /// <summary>
    /// Code for inserting the task below the selected task
    /// </summary>
    public class InsertTaskCommand
    {
        static InsertTaskCommand()
        {
            //Registering the InsertTask Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(InsertTask, OnExecuteInsertTask, OnCanExecuteInsertTask));
        }

        public static RoutedCommand InsertTask = new RoutedCommand("InsertTask", typeof(GanttControl));

        /// <summary>
        /// Called when [execute insert task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteInsertTask(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            
            TaskDetails selectedTask = gantt.SelectedItems[gantt.SelectedItems.Count - 1] as TaskDetails;

            /// Getting the parent of selected Item
            TaskDetails parent = gantt.Model.GetParentOfItem(selectedTask) as TaskDetails;
            TaskDetails newTask;

            /// Based on the parent value the task will be added in root collectin or in child collection.
            if (parent == null)
            {
                int count = gantt.Model.InbuiltTaskCollection.Count;
                int index = gantt.Model.InbuiltTaskCollection.IndexOf(selectedTask);

                if (index <= -1)
                    return;
                newTask = new TaskDetails
                {
                    TaskId = count + 1,
                    StartDate = selectedTask.FinishDate,
                    Duration = new TimeSpan(1, 0, 0, 0)
                };
                /// Inserting a new task to the root collection.
                gantt.Model.InbuiltTaskCollection.Insert(index + 1, newTask);
            }
            else
            {
                int index = parent.Child.IndexOf(selectedTask as IGanttTask);
                newTask = new TaskDetails
                {
                    TaskId = selectedTask.TaskId + 1,
                    StartDate = selectedTask.FinishDate,
                    Duration = new TimeSpan(1, 0, 0, 0)
                };
                /// Inserting a new task to the child collection.
                parent.Child.Insert(index + 1, newTask);
            }
            gantt.SelectedItems.Clear();
            gantt.SelectedItems.Add(newTask);
            /// Type casting the collection for calculating the Task Id
            var tempCol = new ObservableCollection<IGanttTask>(gantt.Model.InbuiltTaskCollection.Cast<IGanttTask>());

            /// Calculating the Task ID after inserting a new Item
            CalculatedTaskId(tempCol, 1);
        }

        /// <summary>
        /// Calculateds the task id.
        /// </summary>
        /// <param name="tasks">The tasks.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private static int CalculatedTaskId(ObservableCollection<IGanttTask> tasks, int index)
        {
            int count = index;
            foreach (TaskDetails task in tasks)
            {
                task.TaskId = count++;

                if (task.Child.Count > 0)
                    count = CalculatedTaskId(task.Child, count);
            }
            return count;
        }

        /// <summary>
        /// Called when [can execute insert task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteInsertTask(object sender, CanExecuteRoutedEventArgs args)
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
