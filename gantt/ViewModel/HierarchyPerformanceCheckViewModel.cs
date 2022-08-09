#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
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
    public class HierarchyPerformanceCheckViewModel : NotificationObject
    {

        #region Private Membors

        private static Random random = new Random(14143);
        private ObservableCollection<TaskDetails> _taskCollection;
        private string _timeTaken;
        private string _loadedTime;
        private int _noOfItems = 100;
        private DelegateCommand<object> _loadData;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public HierarchyPerformanceCheckViewModel()
        {
            _loadData = new DelegateCommand<object>(OnLoadDataClicked, CanExecute);
        }

        /// <summary>
        /// Gets or sets the time taken.
        /// </summary>
        /// <value>The time taken.</value>
        public string TimeTaken
        {
            get
            {
                return _timeTaken;
            }
            set
            {
                _timeTaken = value;
                RaisePropertyChanged("TimeTaken");
            }
        }

        /// <summary>
        /// Gets or sets the loaded time.
        /// </summary>
        /// <value>The loaded time.</value>
        public string LoadedTime
        {
            get
            {
                return _loadedTime;
            }

            set
            {
                _loadedTime = value;
                RaisePropertyChanged("LoadedTime");
            }
        }

        /// <summary>
        /// Gets or sets the no of items.
        /// </summary>
        /// <value>The no of items.</value>
        public int NoOfItems
        {
            get
            {
                return _noOfItems;
            }

            set
            {
                _noOfItems = value;
                RaisePropertyChanged("NoOfItems");
            }
        }

        #region Delegate Command

        /// <summary>
        /// Gets the load data.
        /// </summary>
        /// <value>The load data.</value>
        public DelegateCommand<object> LoadData
        {
            get
            {
                return _loadData;
            }
        }

        #endregion

        #region DelegateCommand Method

        /// <summary>
        /// Called when [load data clicked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnLoadDataClicked(object parms)
        {
            ObservableCollection<TaskDetails> DataCollection;
            DateTime time = DateTime.Now;
            DataCollection = this.GetData(this.NoOfItems);
            TimeTaken = Math.Round((DateTime.Now - time).TotalSeconds, 4).ToString() + "  Sec";
            this.TaskCollection = DataCollection;
            LoadedTime = Math.Round((DateTime.Now - time).TotalSeconds, 4).ToString() + "  Sec";
        }

        /// <summary>
        /// Determines whether this instance can execute the specified parms.
        /// </summary>
        /// <param name="parms">The parms.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can execute the specified parms; otherwise, <c>false</c>.
        /// </returns>
        private bool CanExecute(object parms)
        {
            return true;
        }

        #endregion

        /// <summary>
        /// Gets the data as itemssource for Gantt
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public ObservableCollection<TaskDetails> GetData(int count)
        {
            var data = new ObservableCollection<TaskDetails>();
            int index = 1;
            int childCount = count;
            var nextRandom = random.Next(7);
            for (int i = 1; i <= count; i++)
            {
                ObservableCollection<IGanttTask> Children = GetChildData(nextRandom, index);
                nextRandom = random.Next(7);
                data.Add(new TaskDetails()
                {
                    TaskId = index++,
                    TaskName = "Root Task " + i,
                    StartDate = DateTime.Now.AddDays(-5 + random.Next(10)),
                    FinishDate = DateTime.Now.AddDays(5 + random.Next(10)),
                    Progress = random.Next(0, 50),
                    Child = Children,
                });
                count = count - Children.Count;
                index = index + Children.Count;
                if (index >= childCount - 7)
                    nextRandom = childCount - index;
            }
            return data;
        }

        /// <summary>
        /// Gets the child data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private ObservableCollection<IGanttTask> GetChildData(int count, int index)
        {
            var data = new ObservableCollection<IGanttTask>();
            for (int i = 1; i <= count; i++)
            {
                data.Add(new TaskDetails()
                {
                    TaskId = index + i,
                    TaskName = "Sub Task " + i,
                    StartDate = DateTime.Now.AddDays(-5 + random.Next(10)),
                    FinishDate = DateTime.Now.AddDays(5 + random.Next(10)),
                    Progress = random.Next(0, 50),
                });
            }
            return data;
        }

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<TaskDetails> TaskCollection
        {
            get
            {
                return _taskCollection;
            }
            set
            {
                _taskCollection = value;
                RaisePropertyChanged("TaskCollection");
            }
        }
    }
}