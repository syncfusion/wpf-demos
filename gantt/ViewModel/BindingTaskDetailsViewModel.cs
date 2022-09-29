#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Gantt;
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
    public class BindingTaskDetailsViewModel
    {
        public BindingTaskDetailsViewModel()
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
            ObservableCollection<TaskDetails> task = new ObservableCollection<TaskDetails>();
            task.Add(new TaskDetails { TaskId = 1, TaskName = "Scope", StartDate = new DateTime(2011, 7, 3), FinishDate = new DateTime(2011, 7, 14), Progress = 40d });
            task[0].Child.Add(new TaskDetails { TaskId = 2, TaskName = "Determine project office scope", StartDate = new DateTime(2011, 7, 3), FinishDate = new DateTime(2011, 7, 5), Progress = 20d });
            task[0].Child.Add(new TaskDetails { TaskId = 3, TaskName = "Justify Project Offfice via business model", StartDate = new DateTime(2011, 7, 3), FinishDate = new DateTime(2011, 7, 7), Progress = 20d });
            task[0].Child.Add(new TaskDetails { TaskId = 4, TaskName = "Secure executive sponsorship", StartDate = new DateTime(2011, 7, 3), FinishDate = new DateTime(2011, 7, 14), Progress = 20d });
            task[0].Child.Add(new TaskDetails { TaskId = 5, TaskName = "Secure complete", StartDate = new DateTime(2011, 7, 14), FinishDate = new DateTime(2011, 7, 14), Progress = 20d });

            task.Add(new TaskDetails { TaskId = 6, TaskName = "Risk Assessment", StartDate = new DateTime(2011, 7, 8), FinishDate = new DateTime(2011, 7, 24), Progress = 30d });

            task[1].Child.Add(new TaskDetails { TaskId = 7, TaskName = "Perform risk assessment", StartDate = new DateTime(2011, 7, 8), FinishDate = new DateTime(2011, 7, 21), Progress = 20d });
            task[1].Child.Add(new TaskDetails { TaskId = 8, TaskName = "Evaluate risk assessment", StartDate = new DateTime(2011, 7, 8), FinishDate = new DateTime(2011, 7, 23), Progress = 30d });
            task[1].Child.Add(new TaskDetails { TaskId = 9, TaskName = "Prepare contingency plans", StartDate = new DateTime(2011, 7, 12), FinishDate = new DateTime(2011, 7, 24), Progress = 30d });
            task[1].Child.Add(new TaskDetails { TaskId = 10, TaskName = "Risk Assessment complete", StartDate = new DateTime(2011, 7, 15), FinishDate = new DateTime(2011, 7, 24), Progress = 30d });

            task.Add(new TaskDetails { TaskId = 11, TaskName = "Monitoring", StartDate = new DateTime(2011, 7, 13), FinishDate = new DateTime(2011, 8, 6), Progress = 40d });
            task[2].Child.Add(new TaskDetails { TaskId = 12, TaskName = "Prepare Meeting agenda", StartDate = new DateTime(2011, 7, 13), FinishDate = new DateTime(2011, 7, 26), Progress = 30d });
            task[2].Child.Add(new TaskDetails { TaskId = 13, TaskName = "Conduct review meeting", StartDate = new DateTime(2011, 7, 13), FinishDate = new DateTime(2011, 7, 30), Progress = 30d });
            task[2].Child.Add(new TaskDetails { TaskId = 14, TaskName = "Migrate critical issues", StartDate = new DateTime(2011, 7, 18), FinishDate = new DateTime(2011, 8, 2), Progress = 30d });
            task[2].Child.Add(new TaskDetails { TaskId = 15, TaskName = "Estabilish change mgmt Control", StartDate = new DateTime(2011, 8, 3), FinishDate = new DateTime(2011, 8, 6), Progress = 30d });
            task[2].Child.Add(new TaskDetails { TaskId = 16, TaskName = "Monitoring Complete", StartDate = new DateTime(2011, 8, 6), FinishDate = new DateTime(2011, 8, 6), Progress = 30d });

            task.Add(new TaskDetails { TaskId = 17, TaskName = "Post Implementation", StartDate = new DateTime(2011, 8, 7), FinishDate = new DateTime(2011, 8, 19), Progress = 40d });
            task[3].Child.Add(new TaskDetails { TaskId = 18, TaskName = "Obtain User feedback", StartDate = new DateTime(2011, 8, 7), FinishDate = new DateTime(2011, 8, 10), Progress = 30d });
            task[3].Child.Add(new TaskDetails { TaskId = 19, TaskName = "Evaluate lessons learned", StartDate = new DateTime(2011, 8, 7), FinishDate = new DateTime(2011, 8, 17), Progress = 30d });
            task[3].Child.Add(new TaskDetails { TaskId = 20, TaskName = "Modify items as necessary", StartDate = new DateTime(2011, 8, 7), FinishDate = new DateTime(2011, 8, 19), Progress = 30d });
            task[3].Child.Add(new TaskDetails { TaskId = 21, TaskName = "Post Implementation complete", StartDate = new DateTime(2011, 8, 19), FinishDate = new DateTime(2011, 8, 19), Progress = 30d });

            task[0].Resources = new ObservableCollection<Resource>() { new Resource { ID = 1, Name = "John" }, new Resource { ID = 2, Name = "Neil" } };
            task[0].Child[3].Resources = new ObservableCollection<Resource>() { new Resource() { ID = 3, Name = "Peter" } };
            task[1].Resources = new ObservableCollection<Resource>() { new Resource() { ID = 4, Name = "David" } };
            return task;
        }
    }
}
