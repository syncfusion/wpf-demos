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
    /// Code for adding the new task
    /// </summary>
    public class NewTaskCommand
    {
        static NewTaskCommand()
        {
            //Registering the NewTask Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(NewTask, OnExecuteNewTask, OnCanExecuteNewTask));
        }

        public static RoutedCommand NewTask = new RoutedCommand("NewTask", typeof(GanttControl));

        /// <summary>
        /// Called when [execute new task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteNewTask(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            int count = gantt.Model.InbuiltTaskCollection.Count;
            if (count > 0)
            {
                /// Creating new Task and adding to the source
                gantt.Model.InbuiltTaskCollection.Add(new TaskDetails
                {
                    StartDate = gantt.Model.InbuiltTaskCollection[count - 1].FinishDate,
                    Duration = new TimeSpan(2, 0, 0, 0)
                });
            }
            else
            {
                /// Creating new Task and adding to the source
                gantt.Model.InbuiltTaskCollection.Add(new TaskDetails()
                {
                    StartDate=gantt.ActualStartTime.AddDays(14),
                    FinishDate=gantt.ActualStartTime.AddDays(16)
                });
            }

            /// Type casting the collection for calculating the Task Id
            var tempCol = new ObservableCollection<IGanttTask>(gantt.Model.InbuiltTaskCollection.Cast<IGanttTask>());

            /// Calculating the Task ID after adding a new Item
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
        /// Called when [can execute new task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteNewTask(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
