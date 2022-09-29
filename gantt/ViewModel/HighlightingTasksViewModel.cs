#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class HighlightingTasksViewModel : TaskRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public HighlightingTasksViewModel()
        {
            _highlightTaskBetween = new DelegateCommand<object>(OnHighlightTaskBetweenClicked, CanExcute);
            _highlightCriticalTask = new DelegateCommand<object>(OnHighlightCriticalTaskClicked, CanExcute);
            _highlightingBrush = Brushes.Red;
        }

        private List<HighlightingTasksModel> _highlightTaskItems;

        /// <summary>
        /// Gets or sets the highlight task items.
        /// </summary>
        /// <value>The highlight task items.</value>
        public List<HighlightingTasksModel> HighlightTaskItems
        {
            get
            {
                return _highlightTaskItems;
            }
            set
            {
                _highlightTaskItems = value;
                RaisePropertyChanged("HighlightTaskItems");
            }
        }

        private DateTime _startTime =new DateTime(2012,2,16);

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (value <= _endTime || this._endTime.Equals(DateTime.MinValue))
                {
                    _startTime = value;
                }
                RaisePropertyChanged("StartTime");
            }
        }

        private DateTime _endTime=new DateTime(2012,8,1);

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
                RaisePropertyChanged("EndTime");
            }
        }

        private Brush _highlightingBrush;

        /// <summary>
        /// Gets or sets the highlighting brush.
        /// </summary>
        /// <value>The highlighting brush.</value>
        public Brush HighlightingBrush
        {
            get
            {
                return _highlightingBrush;
            }
            set
            {
                _highlightingBrush = value;
                RaisePropertyChanged("HighlightingBrush");
            }
        }

        #region Delegate Commands

        private DelegateCommand<object> _highlightTaskBetween;

        /// <summary>
        /// Gets the highlight task between.
        /// </summary>
        /// <value>The highlight task between.</value>
        public DelegateCommand<object> HighlightTaskBetween
        {
            get
            {
                return _highlightTaskBetween;
            }
        }

        private DelegateCommand<object> _highlightCriticalTask;

        /// <summary>
        /// Gets the highlight critical task.
        /// </summary>
        /// <value>The highlight critical task.</value>
        public DelegateCommand<object> HighlightCriticalTask
        {
            get
            {
                return _highlightCriticalTask;
            }
        }

        #endregion

        #region Delegate Command Methods

        /// <summary>
        /// Called when [highlight task between clicked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnHighlightTaskBetweenClicked(object parms)
        {
            this.HighlightTaskItems = this.GetTasksBetween(this.StartTime, this.EndTime);
        }

        /// <summary>
        /// Called when [highlight critical task clicked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnHighlightCriticalTaskClicked(object parms)
        {
            this.HighlightTaskItems = this.GetCriticalTasks();
        }

        /// <summary>
        /// Determines whether this instance can excute the specified parms.
        /// </summary>
        /// <param name="parms">The parms.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can excute the specified parms; otherwise, <c>false</c>.
        /// </returns>
        private bool CanExcute(object parms)
        {
            return true;
        }

        #endregion

        /// <summary>
        /// Gets the tasks between.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="End">The end.</param>
        /// <returns></returns>
        internal List<HighlightingTasksModel> GetTasksBetween(DateTime Start, DateTime End)
        {
            if (DateTime.MaxValue.Equals(Start) || DateTime.MaxValue.Equals(End) || DateTime.MinValue.Equals(Start) || DateTime.MinValue.Equals(End))
                return null;

            List<HighlightingTasksModel> tasks = new List<HighlightingTasksModel>();
            this.GetTasksBetween(Start, End, this.TaskCollections, tasks);

            return tasks;
        }

        /// <summary>
        /// Gets the tasks between.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="source">The source.</param>
        /// <param name="taskList">The task list.</param>
        private void GetTasksBetween(DateTime start, DateTime end, ObservableCollection<HighlightingTasksModel> source, List<HighlightingTasksModel> taskList)
        {
            foreach (HighlightingTasksModel task in source)
            {
                if (task.StDate >= start && task.EndDate <= end)
                    taskList.Add(task);
                if (task.ChildTask != null && task.ChildTask.Count > 0)
                    GetTasksBetween(start, end, task.ChildTask, taskList);
            }
        }

        /// <summary>
        /// Gets the critical tasks.
        /// </summary>
        /// <returns></returns>
        internal List<HighlightingTasksModel> GetCriticalTasks()
        {
            List<HighlightingTasksModel> criticalTasks = new List<HighlightingTasksModel>();

            criticalTasks.AddRange(this.TaskCollections[0].ChildTask[0].ChildTask[2].ChildTask);
            criticalTasks.AddRange(this.TaskCollections[0].ChildTask[1].ChildTask);
            criticalTasks.AddRange(this.TaskCollections[0].ChildTask[2].ChildTask);

            return criticalTasks;
        }

        internal void Dispose()
        {
            if (HighlightTaskItems != null)
            {
                foreach (var highlightingTaskItem in HighlightTaskItems)
                {
                    highlightingTaskItem.Dispose();
                }
            }
        }
    }
}
