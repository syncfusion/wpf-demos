#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.ganttdemos.wpf
{
     public class ProjectSchedulerInitialSetupBehavior : Behavior<ProjectScheduler>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            AssociatedObject.Gantt.ImportFromXML("Assets/gantt/ProjectData.xml");
           AssociatedObject.Gantt.Loaded += new System.Windows.RoutedEventHandler(Gantt_Loaded);

        }

        /// <summary>
        /// Handles the Loaded event of the Gantt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void Gantt_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            AssociatedObject.Gantt.GanttGrid.AllowAutoSizingNodeColumn = false;
            AssociatedObject.NewTask.Click += NewTask_Click;
            AssociatedObject.InsertTask.Click += InsertTask_Click;
            AssociatedObject.Indent.Click += Indent_Click;
            AssociatedObject.Outdent.Click += Outdent_Click;
            AssociatedObject.DeleteTask.Click += DeleteTask_Click;
            AssociatedObject.Load.Click += Load_Click;
            AssociatedObject.Save.Click += Save_Click;
            AssociatedObject.SaveAs.Click += SaveAs_Click;
            AssociatedObject.DeleteALL.Click += DeleteALL_Click;
            EnableAndDisableButtonVisibility();
            AssociatedObject.Gantt.SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
        }

        private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            EnableAndDisableButtonVisibility();
        }

        void EnableAndDisableButtonVisibility()
        {
            GanttControl gantt = AssociatedObject.Gantt;
            if (gantt.SelectedItems == null || gantt.SelectedItems.Count <= 0)
            {
                AssociatedObject.DeleteTask.Background = AssociatedObject.Outdent.Background = AssociatedObject.Indent.Background = AssociatedObject.InsertTask.Background = new SolidColorBrush(Colors.WhiteSmoke);
                AssociatedObject.DeleteTask.Foreground = AssociatedObject.Outdent.Foreground = AssociatedObject.Indent.Foreground = AssociatedObject.InsertTask.Foreground = new SolidColorBrush(Colors.LightGray);
                AssociatedObject.DeleteTask.IsHitTestVisible = AssociatedObject.Outdent.IsHitTestVisible = AssociatedObject.Indent.IsHitTestVisible = AssociatedObject.InsertTask.IsHitTestVisible = false;
            }
            else
            {
                AssociatedObject.DeleteTask.Background = AssociatedObject.Outdent.Background = AssociatedObject.Indent.Background = AssociatedObject.InsertTask.Background = AssociatedObject.NewTask.Background;
                AssociatedObject.DeleteTask.Foreground = AssociatedObject.Outdent.Foreground = AssociatedObject.Indent.Foreground = AssociatedObject.InsertTask.Foreground = AssociatedObject.NewTask.Foreground;
                AssociatedObject.DeleteTask.IsHitTestVisible = AssociatedObject.Outdent.IsHitTestVisible = AssociatedObject.Indent.IsHitTestVisible = AssociatedObject.InsertTask.IsHitTestVisible = true;
            }
        }
        private void Outdent_Click(object sender, RoutedEventArgs e)
        {
            GanttControl gantt = AssociatedObject.Gantt;

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

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            GanttControl gantt = AssociatedObject.Gantt;

            /// This will delete only the first Item of the seleted Item from the source
            TaskDetails task = gantt.Model.GetParentOfItem(gantt.SelectedItems[0]) as TaskDetails;
            if (task == null)
                gantt.Model.InbuiltTaskCollection.Remove(gantt.SelectedItems[0] as TaskDetails);
            else
                task.Child.Remove(gantt.SelectedItems[0] as IGanttTask);
            gantt.SelectedItems.Clear();
        }

        private void Indent_Click(object sender, RoutedEventArgs e)
        {
            GanttControl gantt = AssociatedObject.Gantt;

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

        private void DeleteALL_Click(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Gantt.Model.InbuiltTaskCollection.Clear();
        }

       private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Gantt.ExportToXML();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Gantt.ExportToXML("Assets/gantt/ProjectData.xml");
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Gantt.ImportFromXML();
        }

        private void InsertTask_Click(object sender, RoutedEventArgs e)
        {
            GanttControl gantt = AssociatedObject.Gantt;

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

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            GanttControl gantt = AssociatedObject.Gantt;
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
                    StartDate = gantt.ActualStartTime.AddDays(14),
                    FinishDate = gantt.ActualStartTime.AddDays(16)
                });
            }

            /// Type casting the collection for calculating the Task Id
            var tempCol = new ObservableCollection<IGanttTask>(gantt.Model.InbuiltTaskCollection.Cast<IGanttTask>());

            /// Calculating the Task ID after adding a new Item
            CalculatedInsertTaskId(tempCol, 1);
        }

        /// <summary>
        /// Calculateds the task id.
        /// </summary>
        /// <param name="tasks">The tasks.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private static int CalculatedInsertTaskId(ObservableCollection<IGanttTask> tasks, int index)
        {
            int count = index;
            foreach (TaskDetails task in tasks)
            {
                task.TaskId = count++;

                if (task.Child.Count > 0)
                    count = CalculatedInsertTaskId(task.Child, count);
            }
            return count;
        }

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
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.Gantt.Loaded -= new System.Windows.RoutedEventHandler(Gantt_Loaded);
            AssociatedObject.NewTask.Click -= NewTask_Click;
            AssociatedObject.InsertTask.Click -= InsertTask_Click;
            AssociatedObject.Indent.Click -= Indent_Click;
            AssociatedObject.Outdent.Click -= Outdent_Click;
            AssociatedObject.DeleteTask.Click -= DeleteTask_Click;
            AssociatedObject.Load.Click -= Load_Click;
            AssociatedObject.Save.Click -= Save_Click;
            AssociatedObject.SaveAs.Click -= SaveAs_Click;
            AssociatedObject.DeleteALL.Click -= DeleteALL_Click;
            AssociatedObject.Gantt.SelectedItems.CollectionChanged -= SelectedItems_CollectionChanged;
        }
    }
}