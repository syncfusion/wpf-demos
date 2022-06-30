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

    public class CustomizedScheduleAppearanceViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public CustomizedScheduleAppearanceViewModel()
        {
            _taskDetails = GetData();
            _customScheduleInfo = GetCustomScheduleSource();
        }
        private ObservableCollection<Task> _taskDetails;

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<Task> TaskDetails
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

        private IList<GanttScheduleRowInfo> _customScheduleInfo;

        /// <summary>
        /// Gets or sets the custom schedule info.
        /// </summary>
        /// <value>The custom schedule info.</value>
        public IList<GanttScheduleRowInfo> CustomScheduleInfo
        {
            get
            {
                return _customScheduleInfo;
            }
            set
            {
                _customScheduleInfo = value;
            }
        }

        /// <summary>
        /// Gets the custom schedule source.
        /// </summary>
        /// <returns></returns>
        public IList<GanttScheduleRowInfo> GetCustomScheduleSource()
        {
            List<GanttScheduleRowInfo> RowInfo = new List<GanttScheduleRowInfo>();

            //Declaring the top most row of the scheduls in Year Time Unit
            RowInfo.Add(new GanttScheduleRowInfo() { TimeUnit = TimeUnit.Years, CellsPerUnit = 1, HorizontalAlignment = HorizontalAlignment.Left });

            // Declaring the bottom most row of the schedule as months (each cell will consist the three months).
            // Pixels per unit denotes a single month widh.
            RowInfo.Add(new GanttScheduleRowInfo() { TimeUnit = TimeUnit.Months, CellsPerUnit = 3, PixelsPerUnit = 15 });
            return RowInfo;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Task> GetData()
        {
            var data = new ObservableCollection<Task>();

            data.Add(new Task() { Id = 1, Name = "Scope", StDate = new DateTime(2011, 8, 9), EndDate = new DateTime(2012, 6, 20), Complete = 40d });
            data[0].ChildTask.Add((new Task() { Id = 2, Name = "Determine project office scope", StDate = new DateTime(2011, 8, 9), EndDate = new DateTime(2012, 2, 20), Complete = 20d, }));
            data[0].ChildTask.Add((new Task() { Id = 3, Name = "Justify Project Offfice via business model", StDate = new DateTime(2011, 11, 6), EndDate = new DateTime(2012, 4, 7), Complete = 20d, }));
            data[0].ChildTask.Add((new Task() { Id = 4, Name = "Secure executive sponsorship", StDate = new DateTime(2012, 2, 10), EndDate = new DateTime(2012, 6, 14), Complete = 10d, }));
            data[0].ChildTask.Add((new Task() { Id = 5, Name = "Secure complete", StDate = new DateTime(2012, 6, 14), EndDate = new DateTime(2012, 9, 14), Complete = 10d }));

            data.Add(new Task() { Id = 6, Name = "Risk Assessment", StDate = new DateTime(2012, 7, 15), EndDate = new DateTime(2011, 7, 24) });
            data[1].ChildTask.Add((new Task() { Id = 7, Name = "Perform risk assessment", StDate = new DateTime(2012, 2, 15), EndDate = new DateTime(2012, 8, 21), Complete = 20d, }));
            data[1].ChildTask.Add((new Task() { Id = 8, Name = "Evaluate risk assessment", StDate = new DateTime(2012, 5, 21), EndDate = new DateTime(2012, 7, 23), Complete = 20d, }));
            data[1].ChildTask.Add((new Task() { Id = 9, Name = "Prepare contingency plans", StDate = new DateTime(2012, 8, 21), EndDate = new DateTime(2013, 2, 24), Complete = 20d, }));
            data[1].ChildTask.Add((new Task() { Id = 10, Name = "Risk Assessment complete", StDate = new DateTime(2012, 4, 24), EndDate = new DateTime(2012, 9, 24), Complete = 30d }));

            data.Add(new Task() { Id = 11, Name = "Monitoring", StDate = new DateTime(2012, 7, 25), EndDate = new DateTime(2012, 8, 6), Duration = new TimeSpan(1, 0, 0, 0) });
            data[2].ChildTask.Add((new Task() { Id = 12, Name = "Prepare Meeting agenda", StDate = new DateTime(2012, 9, 25), EndDate = new DateTime(2012, 12, 26), Complete = 20d, }));
            data[2].ChildTask.Add((new Task() { Id = 13, Name = "Conduct review meeting", StDate = new DateTime(2013, 1, 27), EndDate = new DateTime(2013, 7, 30), Complete = 20d, }));
            data[2].ChildTask.Add((new Task() { Id = 14, Name = "Migrate critical issues", StDate = new DateTime(2013, 3, 30), EndDate = new DateTime(2013, 7, 2), Complete = 20d, }));
            data[2].ChildTask.Add((new Task() { Id = 15, Name = "Estabilish change mgmt Control", StDate = new DateTime(2013, 5, 3), EndDate = new DateTime(2013, 9, 6), Complete = 30d, }));
            data[2].ChildTask.Add((new Task() { Id = 16, Name = "Monitoring Complete", StDate = new DateTime(2013, 7, 6), EndDate = new DateTime(2013, 12, 6), Complete = 30d }));

            data.Add(new Task() { Id = 17, Name = "Post Implementation", StDate = new DateTime(2013, 7, 25), EndDate = new DateTime(2012, 3, 12) });
            data[3].ChildTask.Add((new Task() { Id = 18, Name = "Obtain User feedback", StDate = new DateTime(2013, 7, 25), EndDate = new DateTime(2014, 4, 29), Complete = 20d, }));
            data[3].ChildTask.Add((new Task() { Id = 19, Name = "Evaluate lessons learned", StDate = new DateTime(2013, 10, 29), EndDate = new DateTime(2014, 7, 5), Complete = 20d, }));
            data[3].ChildTask.Add((new Task() { Id = 20, Name = "Modify items as necessary", StDate = new DateTime(2014, 1, 2), EndDate = new DateTime(2014, 9, 8), Complete = 20d, }));
            data[3].ChildTask.Add((new Task() { Id = 21, Name = "Post Implementation complete", StDate = new DateTime(2014, 4, 8), EndDate = new DateTime(2014, 9, 12), Complete = 30d }));

            data[0].ChildTask[0].Resource.Add(new Resource() { ID = 1, Name = "Leslie" });
            data[0].ChildTask[1].Resource.Add(new Resource() { ID = 2, Name = "John" });
            data[0].ChildTask[2].Resource.Add(new Resource() { ID = 3, Name = "David" });
            data[0].ChildTask[3].Resource.Add(new Resource() { ID = 4, Name = "Peter" });

            data[1].ChildTask[0].Resource.Add(new Resource() { ID = 5, Name = "Neil" });
            data[1].ChildTask[1].Resource.Add(new Resource() { ID = 7, Name = "Johnson" });
            data[1].ChildTask[1].Resource.Add(new Resource() { ID = 8, Name = "Julie" });
            data[1].ChildTask[2].Resource.Add(new Resource() { ID = 9, Name = "Peterson" });
            data[1].ChildTask[3].Resource.Add(new Resource() { ID = 10, Name = "Thomas" });

            data[3].ChildTask[1].Resource.Add(new Resource() { ID = 5, Name = "David" });
            data[3].ChildTask[2].Resource.Add(new Resource() { ID = 7, Name = "Peter" });
            data[3].ChildTask[3].Resource.Add(new Resource() { ID = 8, Name = "Thomas" });

            data[0].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 2, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            data[0].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 3, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            data[0].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 3, GanttTaskRelationship = GanttTaskRelationship.StartToStart });

            data[1].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 9, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            data[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 10, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            data[1].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 7, GanttTaskRelationship = GanttTaskRelationship.StartToStart });

            data[2].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 12, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 12, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[2].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 12, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });

            data[3].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 18, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            data[3].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 18, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            data[3].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 19, GanttTaskRelationship = GanttTaskRelationship.StartToStart });
            return data;
        }

        internal void Dispose()
        {
            foreach(var taskDetail in TaskDetails)
            {
                taskDetail.Dispose();
            }
        }
    }
}
    

