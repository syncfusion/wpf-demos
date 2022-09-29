#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
    public class CriticalPathViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public CriticalPathViewModel()
        {
            _taskDetails = this.GetTaskDetails();
        }

        private ObservableCollection<TaskDetails> _taskDetails;

        /// <summary>
        /// Gets or sets the task collection.
        /// </summary>
        /// <value>The task collection.</value>
        public ObservableCollection<TaskDetails> TaskDetails
        {
            get
            {
                return _taskDetails;
            }
            set
            {
                _taskDetails = value;
            }
        }

        /// <summary>
        /// Gets the task details.
        /// </summary>
        /// <returns></returns>
        ObservableCollection<TaskDetails> GetTaskDetails()
        {
            // Adding Tasks
            ObservableCollection<TaskDetails> task = new ObservableCollection<TaskDetails>();
            task.Add(new TaskDetails { TaskId = 1, TaskName = "Project Schedule", StartDate = new DateTime(2014, 2, 3), FinishDate = new DateTime(2014, 2, 23), Progress = 57d });
            task[0].Child.Add(new TaskDetails { TaskId = 2, TaskName = "Planning", StartDate = new DateTime(2014, 2, 3), FinishDate = new DateTime(2014, 2, 12), Progress = 77d });
            task[0].Child[0].Child.Add(new TaskDetails { TaskId = 3, TaskName = "Planning timeline", StartDate = new DateTime(2014, 2, 3), FinishDate = new DateTime(2014, 2, 7), Progress = 80d });
            task[0].Child[0].Child.Add(new TaskDetails { TaskId = 4, TaskName = "Plan budget", StartDate = new DateTime(2014, 2, 8), FinishDate = new DateTime(2014, 2, 12), Progress = 70d });
            task[0].Child[0].Child.Add(new TaskDetails { TaskId = 5, TaskName = "Allocate resources", StartDate = new DateTime(2014, 2, 8), FinishDate = new DateTime(2014, 2, 10), Progress = 80d });
            task[0].Child[0].Child.Add(new TaskDetails { TaskId = 6, TaskName = "Planning complete", StartDate = new DateTime(2014, 2, 13), FinishDate = new DateTime(2014, 2, 13), Progress = 0d });

            task[0].Child.Add(new TaskDetails { TaskId = 7, TaskName = "Design", StartDate = new DateTime(2014, 2, 13), FinishDate = new DateTime(2014, 2, 23), Progress = 39d });
            task[0].Child[1].Child.Add(new TaskDetails { TaskId = 8, TaskName = "Software Specification", StartDate = new DateTime(2014, 2, 14), FinishDate = new DateTime(2014, 2, 20), Progress = 60d });
            task[0].Child[1].Child.Add(new TaskDetails { TaskId = 9, TaskName = "Develop prototype", StartDate = new DateTime(2014, 2, 14), FinishDate = new DateTime(2014, 2, 16), Progress = 40d });
            task[0].Child[1].Child.Add(new TaskDetails { TaskId = 10, TaskName = "Get approval from customer", StartDate = new DateTime(2014, 2, 17), FinishDate = new DateTime(2014, 2, 21), Progress = 50d });
            task[0].Child[1].Child.Add(new TaskDetails { TaskId = 11, TaskName = "Design complete", StartDate = new DateTime(2014, 2, 22), FinishDate = new DateTime(2014, 2, 24), Progress = 0d });

            task[0].Child.Add(new TaskDetails { TaskId = 12, TaskName = "Implementation", StartDate = new DateTime(2014, 2, 13), FinishDate = new DateTime(2014, 2, 23), Progress = 39d });
            task[0].Child[2].Child.Add(new TaskDetails { TaskId = 13, TaskName = "Develop prototype", StartDate = new DateTime(2014, 2, 25), FinishDate = new DateTime(2014, 2, 27), Progress = 60d });
            task[0].Child[2].Child.Add(new TaskDetails { TaskId = 14, TaskName = "Divide modules", StartDate = new DateTime(2014, 2, 28), FinishDate = new DateTime(2014, 3, 2), Progress = 40d });
            task[0].Child[2].Child.Add(new TaskDetails { TaskId = 15, TaskName = "Allocate resources", StartDate = new DateTime(2014, 3, 3), FinishDate = new DateTime(2014, 3, 7), Progress = 50d });
            task[0].Child[2].Child.Add(new TaskDetails { TaskId = 16, TaskName = "Optimization", StartDate = new DateTime(2014, 3, 8), FinishDate = new DateTime(2014, 3, 10), Progress = 0d });

            task[0].Child.Add(new TaskDetails { TaskId = 17, TaskName = "Testing", StartDate = new DateTime(2014, 2, 13), FinishDate = new DateTime(2014, 2, 23), Progress = 39d });
            task[0].Child[3].Child.Add(new TaskDetails { TaskId = 18, TaskName = "Manual testing", StartDate = new DateTime(2014, 3, 11), FinishDate = new DateTime(2014, 3, 13), Progress = 60d });
            task[0].Child[3].Child.Add(new TaskDetails { TaskId = 19, TaskName = "Develop scripts for testing", StartDate = new DateTime(2014, 3, 14), FinishDate = new DateTime(2014, 3, 16), Progress = 40d });
            task[0].Child[3].Child.Add(new TaskDetails { TaskId = 20, TaskName = "Automation", StartDate = new DateTime(2014, 3, 17), FinishDate = new DateTime(2014, 3, 21), Progress = 50d });
            task[0].Child[3].Child.Add(new TaskDetails { TaskId = 21, TaskName = "Release beta version", StartDate = new DateTime(2014, 3, 22), FinishDate = new DateTime(2014, 3, 22), Progress = 0d });

            //Adding predecessors
            task[0].Child[0].Child[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 3, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[0].Child[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 4, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            task[0].Child[0].Child[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 4, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            task[0].Child[1].Child[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 6, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[1].Child[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 6, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[1].Child[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 9, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[1].Child[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 10, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            task[0].Child[2].Child[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 11, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[2].Child[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 13, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[2].Child[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 14, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[2].Child[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 15, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            task[0].Child[3].Child[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 16, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[3].Child[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 18, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[3].Child[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 19, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            task[0].Child[3].Child[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 20, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            return task;
        }
    }
}