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
    /// Code for outdent the selected task
    /// </summary>
    public class OutdentTaskCommand
    {
        static OutdentTaskCommand()
        {
            //Registering the OutdentTask Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(OutdentTask, OnExecuteOutdentTask, OnCanExecuteOutdentTask));
        }

        public static RoutedCommand OutdentTask = new RoutedCommand("OutdentTask", typeof(GanttControl));

        /// <summary>
        /// Called when [execute outdent task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteOutdentTask(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;

            /// The loop has been limitted to one, to perform the out-dent operation on only tge first item in the selected items collection.
            /// By replacing the condition of loop you can achieve it for all selected items.
            for (int i = 0; i < 1; i++)
            {
                TaskDetails currentTask = gantt.SelectedItems[i] as TaskDetails;

                /// Getting the parent of the current Task
                TaskDetails parentTask = gantt.Model.GetParentOfItem(currentTask) as TaskDetails;


                DateTime parentStart;
                DateTime parentEnd;

                if (parentTask == null)
                {
                    continue;
                }

                else
                {
                    parentStart = parentTask.StartDate;
                    parentEnd = parentTask.FinishDate;
                    /// Getting the parent of the current Task
                    TaskDetails nextLevelParent = gantt.Model.GetParentOfItem(parentTask) as TaskDetails;
                    int currentIndex = parentTask.Child.IndexOf(currentTask);

                    parentTask.Child.Remove(currentTask);

                    while ((parentTask.Child.Count) > currentIndex)
                    {
                        TaskDetails child = parentTask.Child[currentIndex] as TaskDetails;
                        /// Changing the hierarchy to achieve indent
                        parentTask.Child.Remove(child);
                        currentTask.Child.Add(child);
                    }

                    if (nextLevelParent == null)
                    {
                        /// Changing the hierarchy to achieve indent
                        int parentIndex = gantt.Model.InbuiltTaskCollection.IndexOf(parentTask);
                        gantt.Model.InbuiltTaskCollection.Insert(parentIndex + 1, currentTask);
                    }
                    else
                    {
                        /// Changing the hierarchy to achieve indent
                        int parentIndex = nextLevelParent.Child.IndexOf(parentTask);
                        nextLevelParent.Child.Insert(parentIndex + 1, currentTask);
                    }

                    parentTask.StartDate = parentStart;
                    parentTask.FinishDate = parentEnd;
                }
                gantt.SelectedItems.Clear();
                gantt.SelectedItems.Add(currentTask);
            }
        }

        /// <summary>
        /// Called when [can execute outdent task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteOutdentTask(object sender, CanExecuteRoutedEventArgs args)
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
