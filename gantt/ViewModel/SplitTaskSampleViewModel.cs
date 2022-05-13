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
    public class SplitTaskSampleViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public SplitTaskSampleViewModel()
        {
            _taskCollections = GetData();
        }

        private ObservableCollection<SplitTaskSampleModel> _taskCollections;

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<SplitTaskSampleModel> TaskCollections
        {
            get
            {
                return _taskCollections;
            }
            set
            {
                _taskCollections = value;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SplitTaskSampleModel> GetData()
        {
            var data = new ObservableCollection<SplitTaskSampleModel>();
            data.Add(new SplitTaskSampleModel() { Id = 1, Name = "Scope", StDate = new DateTime(2011, 7, 3), EndDate = new DateTime(2011, 7, 14), Complete = 40d, Resource = new ObservableCollection<Resource>() { new Resource() { Name = "John" } } });
            data[0].ChildTask.Add((new SplitTaskSampleModel() { Id = 2, Name = "Determine project office scope", StDate = new DateTime(2011, 6, 10), EndDate = new DateTime(2011, 6, 30), Complete = 20d }));
            data[0].ChildTask.Add((new SplitTaskSampleModel() { Id = 3, Name = "Justify Project Offfice via business model", StDate = new DateTime(2011, 7, 6), EndDate = new DateTime(2011, 7, 7), Complete = 20d }));
            data[0].ChildTask.Add((new SplitTaskSampleModel() { Id = 4, Name = "Secure executive sponsorship", StDate = new DateTime(2011, 7, 10), EndDate = new DateTime(2011, 7, 30), Complete = 10d }));
            data[0].ChildTask.Add((new SplitTaskSampleModel() { Id = 5, Name = "Secure complete", StDate = new DateTime(2011, 7, 14), EndDate = new DateTime(2011, 7, 14), Complete = 10d }));
            var splitSegments = new ObservableCollection<SplitTask>();
            splitSegments.Add(new SplitTask { StartDate = new DateTime(2011, 6, 10), FinishDate = new DateTime(2011, 6, 11) });
            splitSegments.Add(new SplitTask { StartDate = new DateTime(2011, 6, 12), FinishDate = new DateTime(2011, 6, 13) });
            splitSegments.Add(new SplitTask { StartDate = new DateTime(2011, 6, 14), FinishDate = new DateTime(2011, 6, 16) });
            splitSegments.Add(new SplitTask { StartDate = new DateTime(2011, 6, 17), FinishDate = new DateTime(2011, 6, 20) });
            splitSegments.Add(new SplitTask { StartDate = new DateTime(2011, 6, 21), FinishDate = new DateTime(2011, 6, 30) });
            data[0].ChildTask[0].SplitSegments = splitSegments;

            data.Add(new SplitTaskSampleModel() { Id = 6, Name = "Risk Assessment", StDate = new DateTime(2011, 7, 15), EndDate = new DateTime(2011, 7, 24), Resource = new ObservableCollection<Resource>() { new Resource() { Name = "David" } } });
            data[1].ChildTask.Add((new SplitTaskSampleModel() { Id = 7, Name = "Perform risk assessment", StDate = new DateTime(2011, 7, 15), EndDate = new DateTime(2011, 7, 21), Complete = 20d }));
            data[1].ChildTask.Add((new SplitTaskSampleModel() { Id = 8, Name = "Evaluate risk assessment", StDate = new DateTime(2011, 7, 21), EndDate = new DateTime(2011, 7, 23), Complete = 20d }));
            data[1].ChildTask.Add((new SplitTaskSampleModel() { Id = 9, Name = "Prepare contingency plans", StDate = new DateTime(2011, 7, 21), EndDate = new DateTime(2011, 7, 24), Complete = 20d }));
            data[1].ChildTask.Add((new SplitTaskSampleModel() { Id = 10, Name = "Risk Assessment complete", StDate = new DateTime(2011, 7, 24), EndDate = new DateTime(2011, 7, 24), Complete = 30d }));

            data.Add(new SplitTaskSampleModel() { Id = 11, Name = "Monitoring", StDate = new DateTime(2011, 7, 25), EndDate = new DateTime(2011, 8, 6), Duration = new TimeSpan(1, 0, 0, 0) });
            data[2].ChildTask.Add((new SplitTaskSampleModel() { Id = 12, Name = "Prepare Meeting agenda", StDate = new DateTime(2011, 7, 25), EndDate = new DateTime(2011, 7, 26), Complete = 20d }));
            data[2].ChildTask.Add((new SplitTaskSampleModel() { Id = 13, Name = "Conduct review meeting", StDate = new DateTime(2011, 7, 27), EndDate = new DateTime(2011, 7, 30), Complete = 20d }));
            data[2].ChildTask.Add((new SplitTaskSampleModel() { Id = 14, Name = "Migrate critical issues", StDate = new DateTime(2011, 7, 31), EndDate = new DateTime(2011, 8, 2), Complete = 20d }));
            data[2].ChildTask.Add((new SplitTaskSampleModel() { Id = 15, Name = "Estabilish change mgmt Control", StDate = new DateTime(2011, 8, 3), EndDate = new DateTime(2011, 8, 6), Complete = 30d }));
            data[2].ChildTask.Add((new SplitTaskSampleModel() { Id = 16, Name = "Monitoring Complete", StDate = new DateTime(2011, 8, 6), EndDate = new DateTime(2011, 8, 6), Complete = 30d }));

            data.Add(new SplitTaskSampleModel() { Id = 17, Name = "Post Implementation", StDate = new DateTime(2011, 7, 25), EndDate = new DateTime(2011, 8, 12) });
            data[3].ChildTask.Add((new SplitTaskSampleModel() { Id = 18, Name = "Obtain User feedback", StDate = new DateTime(2011, 7, 25), EndDate = new DateTime(2011, 7, 29), Complete = 20d }));
            data[3].ChildTask.Add((new SplitTaskSampleModel() { Id = 19, Name = "Evaluate lessons learned", StDate = new DateTime(2011, 7, 29), EndDate = new DateTime(2011, 8, 5), Complete = 20d }));

            var segments = new ObservableCollection<SplitTask>();
            splitSegments.Add(new SplitTask { StartDate = new DateTime(2011, 7, 29), FinishDate = new DateTime(2011, 7, 30) });
            splitSegments.Add(new SplitTask { StartDate = new DateTime(2011, 8, 1), FinishDate = new DateTime(2011, 8, 3) });
            data[3].ChildTask[1].SplitSegments = segments;
            data[3].ChildTask.Add((new SplitTaskSampleModel() { Id = 20, Name = "Modify items as necessary", StDate = new DateTime(2011, 8, 2), EndDate = new DateTime(2011, 8, 8), Complete = 20d }));
            data[3].ChildTask.Add((new SplitTaskSampleModel() { Id = 21, Name = "Post Implementation complete", StDate = new DateTime(2011, 8, 8), EndDate = new DateTime(2011, 8, 12), Complete = 30d }));


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
    }
}
