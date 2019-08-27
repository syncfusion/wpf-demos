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
    /// Code for indent the selected task 
    /// </summary>
    public class IndentTaskCommand
    {
        static IndentTaskCommand()
        {
            //Registering the IndentTask Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(IndentTask, OnExecuteIndentTask, OnCanExecuteIndentTask));
        }

        public static RoutedCommand IndentTask = new RoutedCommand("IndentTask", typeof(GanttControl));

        /// <summary>
        /// Called when [execute indent task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteIndentTask(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;

            /// The loop has been limitted to one, to perform the intend operation on only the first item in the selected items collection.
            /// By replacing the condition of loop you can achieve it for all selected items.
            for (int i = 0; i < 1; i++)
            {
                TaskDetails currentTask = gantt.SelectedItems[i] as TaskDetails;

                /// Getting the parent of the current Task
                TaskDetails parentTask = gantt.Model.GetParentOfItem(currentTask) as TaskDetails;

                if (parentTask == null)
                {
                    int index = gantt.Model.InbuiltTaskCollection.IndexOf(currentTask);
                    if (index < 1)
                        continue;

                    /// Changing the hierarchy to achieve indent
                    gantt.Model.InbuiltTaskCollection.Remove(currentTask);
                    gantt.Model.InbuiltTaskCollection[index - 1].Child.Add(currentTask);
                }
                else
                {
                    int currentIndex = parentTask.Child.IndexOf(currentTask);
                    if ((currentIndex - 1) >= 0)
                    {
                        /// Changing the hierarchy to achieve indent
                        parentTask.Child.Remove(currentTask as IGanttTask);
                        parentTask.Child[currentIndex - 1].Child.Add(currentTask);
                    }
                }
                 gantt.SelectedItems.Clear();
                 gantt.SelectedItems.Add(currentTask);
            }
        }

        /// <summary>
        /// Called when [can execute indent task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteIndentTask(object sender, CanExecuteRoutedEventArgs args)
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
