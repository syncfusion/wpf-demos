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
using System.Collections.Specialized;
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
    public class HighlightingTasksModel : NotificationObject
    {
        public HighlightingTasksModel()
        {
            ChildTask = new ObservableCollection<HighlightingTasksModel>();
            Predecessor = new ObservableCollection<Predecessor>();
            Resource = new ObservableCollection<Resource>();
        }

        private int id;
        private string name;
        private DateTime stDate;
        private DateTime endDate;
        private TimeSpan duration;
        private ObservableCollection<Resource> resource;
        private double complete;
        private ObservableCollection<HighlightingTasksModel> childTask;
        private ObservableCollection<Predecessor> predecessor;
        private Double cost;
        private DateTime baselineStart;
        private DateTime baselineEnd;
        private Double baselineCost;

        /// <summary>
        /// Gets or sets the complete.
        /// </summary>
        /// <value>
        /// The complete.
        /// </value>
        public double Complete
        {
            get
            {
                return Math.Round(complete, 2);
            }
            set
            {
                if (value <= 100)
                {
                    if (childTask != null && childTask.Count >= 1)
                    {
                        var sum = 0d;
                        complete = ((childTask.Aggregate(sum, (cur, task) => cur + task.Complete)) / childTask.Count);
                    }
                    else
                        complete = value;
                    RaisePropertyChanged("Complete");
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        /// <value>
        /// The resource.
        /// </value>
        public ObservableCollection<Resource> Resource
        {
            get
            {
                return resource;
            }
            set
            {
                resource = value;
                RaisePropertyChanged("Resource");
            }
        }


        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public TimeSpan Duration
        {
            get
            {
                if (childTask != null && childTask.Count >= 1)
                {
                    var sum = new TimeSpan(0, 0, 0, 0);
                    sum = childTask.Aggregate(sum, (current, task) => current + task.Duration);
                    return sum;
                }

                /// Finish date is having 8 working hours, the dead line will include that too. Hence one day is added in calcuation to get the exact duration.                 

                duration = endDate.Subtract(stDate);
                return duration;
            }

            set
            {
                if (childTask != null && childTask.Count >= 1)
                {
                    var sum = new TimeSpan(0, 0, 0, 0);
                    sum = childTask.Aggregate(sum, (current, task) => current + task.Duration);
                    duration = sum;
                    return;
                }

                duration = value;

                /// When calculating finish date from duration  we need to remove the extra date that we have added in duration to make the it fill the finish date too.
                /// End date is beeing calcuated here to make the change in endate based on duration. Duration is interlinked with start and end date, so will affect both based on the change.
                EndDate = stDate.AddDays(Double.Parse((duration.TotalDays).ToString()));

            }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (childTask != null && childTask.Count >= 1)
                {
                    /// If this task is a parent task, then it should have the maximum end time. Hence comparing the date with maximum date of its children.

                    if (value >= childTask.Max(s => s.EndDate) && endDate != value)
                        endDate = value;
                }
                else
                    endDate = value;
                RaisePropertyChanged("EndDate");
                /// Duration changed is invoked to notify the chagne in duration based on the new end date.
                RaisePropertyChanged("Duration");
            }
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StDate
        {
            get
            {
                return stDate;
            }
            set
            {
                /// If this task is a parent task, then it should have the minimum start time. Hence comparing the date with minimum date of its children.

                if (childTask != null && childTask.Count >= 1)
                {
                    if (value <= childTask.Min(s => s.stDate) && stDate != value)
                        stDate = value;
                }
                else
                    stDate = value;
                RaisePropertyChanged("StDate");

                /// Duration chagned is invoked to notify the chagne in duration based on the new start date.
                RaisePropertyChanged("Duration");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets the predecessor.
        /// </summary>
        /// <value>
        /// The predecessor.
        /// </value>
        public ObservableCollection<Predecessor> Predecessor
        {
            get
            {
                return predecessor;
            }
            set
            {
                predecessor = value;
                RaisePropertyChanged("Predecessor");
            }
        }
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public Double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (cost != value)
                {
                    if (childTask != null && childTask.Count >= 1)
                    {
                        var sum = 0d;
                        cost = childTask.Aggregate(sum, (cur, task) => cur + task.Cost);
                    }
                    else
                        cost = value;
                    RaisePropertyChanged("Cost");
                }

            }
        }

        /// <summary>
        /// Gets or sets the Baseline start.
        /// </summary>
        /// <value>
        /// The Baseline start.
        /// </value>
        public DateTime BaselineStart
        {
            get
            {
                return baselineStart;
            }
            set
            {
                if (baselineStart != value)
                {
                    if (childTask != null && childTask.Count >= 1)
                    {
                        baselineStart = childTask.Min(s => s.baselineStart);
                    }
                    else
                        baselineStart = value;
                    RaisePropertyChanged("BaselineStart");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Baseline end.
        /// </summary>
        /// <value>
        /// The Baseline end.
        /// </value>
        public DateTime BaselineEnd
        {
            get
            {
                return baselineEnd;
            }
            set
            {
                if (baselineEnd != value)
                {
                    if (childTask != null && childTask.Count >= 1)
                    {
                        baselineEnd = childTask.Max(s => s.baselineEnd);
                    }
                    else
                        baselineEnd = value;
                    RaisePropertyChanged("BaselineEnd");
                }
            }
        }

        /// <summary>
        /// Gets or sets the baseline cost.
        /// </summary>
        /// <value>
        /// The baseline cost.
        /// </value>
        public Double BaselineCost
        {
            get
            {
                return baselineCost;
            }
            set
            {
                if (BaselineCost != value)
                {
                    if (childTask != null && childTask.Count >= 1)
                    {
                        var sum = 0d;
                        baselineCost = childTask.Aggregate(sum, (current, task) => current + task.baselineCost);
                    }
                    else
                        baselineCost = value;
                    RaisePropertyChanged("BaselineCost");
                }

            }
        }

        #region ChildTask Collection

        public ObservableCollection<HighlightingTasksModel> ChildTask
        {
            get
            {
                if (childTask == null)
                {
                    childTask = new ObservableCollection<HighlightingTasksModel>();
                    /// Collection changed of child tasks are hooked to listen and refresh the parent node based on the changes made in Child.
                    childTask.CollectionChanged += ChildNodesCollectionChanged;
                }
                return childTask;
            }
            set
            {
                childTask = value;
                ///Collection changed of child tasks are hooked to listen and refresh the parent node based on the changes made in Child.

                childTask.CollectionChanged += ChildNodesCollectionChanged;

                if (value.Count > 0)
                {
                    childTask.ToList().ForEach(n =>
                    {
                        /// To listen the changes occuring in child task.
                        n.PropertyChanged += ChildNodePropertyChanged;

                    });
                    UpdateData();
                }
                RaisePropertyChanged("ChildTask");
            }
        }
        /// <summary>
        /// The following does the calculations to update the Parent Task, when child collection property changes.
        /// </summary>
        /// <param name="sender">The source</param>
        /// <param name="e">Property changed event args</param>
        void ChildNodePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null)
                if (e.PropertyName != null)
                    if (e.PropertyName == "StDate" || e.PropertyName == "EndDate" || e.PropertyName == "Cost" || e.PropertyName == "BaselineStart" ||
                        e.PropertyName == "BaselineEnd" || e.PropertyName == "BaselineCost" || e.PropertyName == "Complete")
                    {
                        UpdateData();
                    }
        }
        /// <summary>
        /// Updates the data.
        /// </summary>
        private void UpdateData()
        {
            /// Updating the Required Data based on the chagne occur in the date of child task
            StDate = childTask.Select(c => c.StDate).Min();
            EndDate = childTask.Select(c => c.EndDate).Max();
            BaselineStart = childTask.Select(c => c.BaselineStart).Min();
            BaselineEnd = childTask.Select(c => c.BaselineEnd).Max();
            Cost = childTask.Aggregate(0d, (cur, task) => cur + task.Cost);
            BaselineCost = childTask.Aggregate(0d, (cur, task) => cur + task.BaselineCost);
            Complete = ((childTask.Aggregate(0d, (cur, task) => cur + task.Complete)) / childTask.Count);
        }

        /// <summary>
        /// handles the child nodes collection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        public void ChildNodesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (HighlightingTasksModel node in e.NewItems)
                {
                    node.PropertyChanged += ChildNodePropertyChanged;
                }
            }
            else
            {
                foreach (HighlightingTasksModel node in e.OldItems)
                    node.PropertyChanged -= ChildNodePropertyChanged;
            }
            UpdateData();
        }

        #endregion

        internal void Dispose()
        {
            ChildTask.CollectionChanged -= ChildNodesCollectionChanged;

            if (ChildTask.Count > 0)
            {
                ChildTask.ToList().ForEach(node =>
                {
                    node.PropertyChanged -= ChildNodePropertyChanged;
                });
            }
        }
    }

    public class TaskRepository : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        public TaskRepository()
        {
            _taskCollections = GetData();
        }

        private ObservableCollection<HighlightingTasksModel> _taskCollections;

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<HighlightingTasksModel> TaskCollections
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
        public ObservableCollection<HighlightingTasksModel> GetData()
        {
            var data = new ObservableCollection<HighlightingTasksModel>();

            // Collection to Strore the Required Resources.
            ObservableCollection<Resource> ResidentialConstructionResources = new ObservableCollection<Resource>();
            ResidentialConstructionResources = GetResources();

            // Adding Tasks

            data.Add(new HighlightingTasksModel() { Id = 1, Name = "Residential Construction (2500 sq.ft)", StDate = new DateTime(2012, 3, 1), EndDate = new DateTime(2012, 3, 15), Complete = 0d, Cost = 500, BaselineCost = 833d, BaselineStart = new DateTime(2012, 2, 1), BaselineEnd = new DateTime(2012, 2, 17) });

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 2, Name = "General Considerations", StDate = new DateTime(2012, 7, 3), EndDate = new DateTime(2012, 7, 14), Complete = 0d, Cost = 89, BaselineCost = 833d, BaselineStart = DateTime.Today, BaselineEnd = DateTime.Today });

            data[0].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 3, Name = "Finalize and Approve Plans", StDate = new DateTime(2012, 3, 1), EndDate = new DateTime(2012, 3, 15), Complete = 0d, Cost = 500, BaselineCost = 833d, BaselineStart = new DateTime(2012, 2, 1), BaselineEnd = new DateTime(2012, 2, 17) });
            data[0].ChildTask[0].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 4, Name = "Review and Finalize Site Plans", StDate = new DateTime(2012, 3, 1), EndDate = new DateTime(2012, 3, 20), Complete = 0d, Cost = 500, BaselineCost = 833d, BaselineStart = new DateTime(2012, 2, 1), BaselineEnd = new DateTime(2012, 2, 17) });
            data[0].ChildTask[0].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 5, Name = "Sign contract and Proceed", StDate = new DateTime(2012, 3, 20), EndDate = new DateTime(2012, 3, 22), Complete = 0d, Cost = 500, BaselineCost = 833d, BaselineStart = new DateTime(2012, 2, 1), BaselineEnd = new DateTime(2012, 2, 17) });

            data[0].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 6, Name = "Contracts and Agreements", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), Complete = 0d, BaselineStart = new DateTime(2012, 3, 12), BaselineEnd = new DateTime(2012, 3, 12), Cost = 20d, BaselineCost = 14 });
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new HighlightingTasksModel() { Id = 7, Name = "Lot Sale Agreement", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), Complete = 0d, BaselineStart = new DateTime(2012, 3, 12), BaselineEnd = new DateTime(2012, 3, 12), Cost = 20d, BaselineCost = 14 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new HighlightingTasksModel() { Id = 8, Name = "Construction Agreement", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), Complete = 0d, BaselineStart = new DateTime(2012, 3, 12), BaselineEnd = new DateTime(2012, 3, 12), Cost = 33d, BaselineCost = 12 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new HighlightingTasksModel() { Id = 9, Name = "Contract Specifications", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), Complete = 0d, BaselineStart = new DateTime(2012, 3, 12), BaselineEnd = new DateTime(2012, 3, 12), Cost = 30d, BaselineCost = 50 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new HighlightingTasksModel() { Id = 10, Name = "Contract Site Plan", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), Complete = 0d, BaselineStart = new DateTime(2012, 3, 12), BaselineEnd = new DateTime(2012, 3, 12), Cost = 360d, BaselineCost = 100 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new HighlightingTasksModel() { Id = 11, Name = "Financing", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), Complete = 0d, BaselineStart = new DateTime(2012, 3, 12), BaselineEnd = new DateTime(2012, 3, 12), Cost = 39d, BaselineCost = 16 }));

            data[0].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 12, Name = "Apply Permits", StDate = new DateTime(2012, 3, 23), EndDate = new DateTime(2012, 3, 24), Complete = 0d, BaselineStart = new DateTime(2012, 3, 2), BaselineEnd = new DateTime(2012, 3, 5), Cost = 53d, BaselineCost = 65 });
            data[0].ChildTask[0].ChildTask[2].ChildTask.Add((new HighlightingTasksModel() { Id = 13, Name = "Foundation Permit", StDate = new DateTime(2012, 3, 23), EndDate = new DateTime(2012, 3, 24), Complete = 0d, BaselineStart = new DateTime(2012, 3, 2), BaselineEnd = new DateTime(2012, 3, 5), Cost = 53d, BaselineCost = 65 }));
            data[0].ChildTask[0].ChildTask[2].ChildTask.Add((new HighlightingTasksModel() { Id = 14, Name = "Electrical Permit", StDate = new DateTime(2012, 3, 24), EndDate = new DateTime(2012, 3, 25), Complete = 0d, BaselineStart = new DateTime(2012, 3, 4), BaselineEnd = new DateTime(2012, 3, 6), Cost = 23d, BaselineCost = 34 }));
            data[0].ChildTask[0].ChildTask[2].ChildTask.Add((new HighlightingTasksModel() { Id = 15, Name = "Plumbing Permit", StDate = new DateTime(2012, 3, 25), EndDate = new DateTime(2012, 3, 26), Complete = 0d, BaselineStart = new DateTime(2012, 3, 5), BaselineEnd = new DateTime(2012, 3, 7), Cost = 63d, BaselineCost = 53 }));

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 16, Name = "Site Work", StDate = new DateTime(2012, 3, 26), EndDate = new DateTime(2012, 3, 27), Complete = 0d, BaselineStart = new DateTime(2012, 3, 26), BaselineEnd = new DateTime(2012, 3, 26), Cost = 2000d, BaselineCost = 1000 });
            data[0].ChildTask[1].ChildTask.Add(new HighlightingTasksModel() { Id = 17, Name = "Clear Lot", StDate = new DateTime(2012, 3, 26), EndDate = new DateTime(2012, 3, 27), Complete = 0d, BaselineStart = new DateTime(2012, 3, 26), BaselineEnd = new DateTime(2012, 3, 26), Cost = 2000d, BaselineCost = 1000 });
            data[0].ChildTask[1].ChildTask.Add(new HighlightingTasksModel() { Id = 18, Name = "Strip Topsoil", StDate = new DateTime(2012, 3, 27), EndDate = new DateTime(2012, 3, 28), Complete = 0d, BaselineStart = new DateTime(2012, 3, 26), BaselineEnd = new DateTime(2012, 3, 27), Cost = 1200d, BaselineCost = 800 });
            data[0].ChildTask[1].ChildTask.Add(new HighlightingTasksModel() { Id = 19, Name = "Installing Temporary requirements", StDate = new DateTime(2012, 3, 28), EndDate = new DateTime(2012, 3, 29), Complete = 0d, BaselineStart = new DateTime(2012, 3, 25), BaselineEnd = new DateTime(2012, 3, 28), Cost = 354d, BaselineCost = 230 });

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 20, Name = "Foundation", StDate = new DateTime(2012, 3, 29), EndDate = new DateTime(2012, 4, 2), Complete = 0d, Cost = 899, BaselineCost = 833d, BaselineStart = new DateTime(2012, 4, 29), BaselineEnd = new DateTime(2012, 4, 2) });
            data[0].ChildTask[2].ChildTask.Add(new HighlightingTasksModel() { Id = 21, Name = "Excavate for foundation", StDate = new DateTime(2012, 3, 29), EndDate = new DateTime(2012, 4, 2), Complete = 0d, Cost = 899, BaselineCost = 833d, BaselineStart = new DateTime(2012, 4, 29), BaselineEnd = new DateTime(2012, 4, 2) });
            data[0].ChildTask[2].ChildTask.Add(new HighlightingTasksModel() { Id = 22, Name = "Building Basement Walls", StDate = new DateTime(2012, 4, 3), EndDate = new DateTime(2012, 4, 8), Complete = 0d, Cost = 889, BaselineCost = 803d, BaselineStart = new DateTime(2012, 4, 5), BaselineEnd = new DateTime(2012, 4, 15) });
            data[0].ChildTask[2].ChildTask.Add(new HighlightingTasksModel() { Id = 23, Name = "Foundation inspection", StDate = new DateTime(2012, 4, 8), EndDate = new DateTime(2012, 4, 10), Complete = 0d, Cost = 8, BaselineCost = 8d, BaselineStart = new DateTime(2012, 4, 14), BaselineEnd = new DateTime(2012, 4, 16) });
            data[0].ChildTask[2].ChildTask.Add(new HighlightingTasksModel() { Id = 24, Name = "Finishing Foundation", StDate = new DateTime(2012, 4, 10), EndDate = new DateTime(2012, 4, 17), Complete = 0d, Cost = 0, BaselineCost = 8d, BaselineStart = new DateTime(2012, 4, 17), BaselineEnd = new DateTime(2012, 4, 17) });

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 25, Name = "Framing", StDate = new DateTime(2012, 4, 18), EndDate = new DateTime(2012, 4, 24), Complete = 0d, Cost = 890, BaselineCost = 803d, BaselineStart = new DateTime(2012, 4, 18), BaselineEnd = new DateTime(2012, 5, 7) });
            data[0].ChildTask[3].ChildTask.Add(new HighlightingTasksModel() { Id = 26, Name = "First Floor Framing", StDate = new DateTime(2012, 4, 18), EndDate = new DateTime(2012, 4, 24), Complete = 0d, Cost = 890, BaselineCost = 803d, BaselineStart = new DateTime(2012, 4, 18), BaselineEnd = new DateTime(2012, 5, 7) });
            data[0].ChildTask[3].ChildTask.Add(new HighlightingTasksModel() { Id = 27, Name = "Second Floor Framing", StDate = new DateTime(2012, 4, 24), EndDate = new DateTime(2012, 5, 3), Complete = 0d, Cost = 789, BaselineCost = 898d, BaselineStart = new DateTime(2012, 5, 8), BaselineEnd = new DateTime(2012, 5, 18) });
            data[0].ChildTask[3].ChildTask.Add(new HighlightingTasksModel() { Id = 28, Name = "Framing Roof", StDate = new DateTime(2012, 5, 3), EndDate = new DateTime(2012, 5, 7), Complete = 0d, Cost = 780, BaselineCost = 833d, BaselineStart = new DateTime(2012, 5, 18), BaselineEnd = new DateTime(2012, 5, 23) });
            data[0].ChildTask[3].ChildTask.Add(new HighlightingTasksModel() { Id = 29, Name = "Framing Inspection", StDate = new DateTime(2012, 5, 7), EndDate = new DateTime(2012, 5, 8), Complete = 0d, Cost = 5, BaselineCost = 8d, BaselineStart = new DateTime(2012, 5, 18), BaselineEnd = new DateTime(2012, 5, 30) });

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 30, Name = "Dry In", StDate = new DateTime(2012, 5, 8), EndDate = new DateTime(2012, 5, 14), Complete = 0d, Cost = 232, BaselineCost = 323d, BaselineStart = new DateTime(2012, 5, 30), BaselineEnd = new DateTime(2012, 6, 2) });
            data[0].ChildTask[4].ChildTask.Add(new HighlightingTasksModel() { Id = 31, Name = "Installing Sheathing for floors", StDate = new DateTime(2012, 5, 8), EndDate = new DateTime(2012, 5, 14), Complete = 0d, Cost = 232, BaselineCost = 323d, BaselineStart = new DateTime(2012, 5, 30), BaselineEnd = new DateTime(2012, 6, 2) });
            data[0].ChildTask[4].ChildTask.Add(new HighlightingTasksModel() { Id = 32, Name = "Installing Windows", StDate = new DateTime(2012, 5, 14), EndDate = new DateTime(2012, 5, 25), Complete = 0d, Cost = 325, BaselineCost = 452d, BaselineStart = new DateTime(2012, 6, 4), BaselineEnd = new DateTime(2012, 6, 17) });
            data[0].ChildTask[4].ChildTask.Add(new HighlightingTasksModel() { Id = 33, Name = "Installing Sheathing for Roof", StDate = new DateTime(2012, 5, 25), EndDate = new DateTime(2012, 5, 30), Complete = 0d, Cost = 82, BaselineCost = 83d, BaselineStart = new DateTime(2012, 6, 18), BaselineEnd = new DateTime(2012, 6, 20) });

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 34, Name = "Exterior Finishing", StDate = new DateTime(2012, 5, 31), EndDate = new DateTime(2012, 6, 12), Complete = 0d, Cost = 463, BaselineCost = 633d, BaselineStart = new DateTime(2012, 6, 20), BaselineEnd = new DateTime(2012, 6, 25) });
            data[0].ChildTask[5].ChildTask.Add(new HighlightingTasksModel() { Id = 35, Name = "Exterior Trimming", StDate = new DateTime(2012, 5, 31), EndDate = new DateTime(2012, 6, 12), Complete = 0d, Cost = 463, BaselineCost = 633d, BaselineStart = new DateTime(2012, 6, 20), BaselineEnd = new DateTime(2012, 6, 25) });
            data[0].ChildTask[5].ChildTask.Add(new HighlightingTasksModel() { Id = 36, Name = "Completing Exterior Bricks", StDate = new DateTime(2012, 6, 12), EndDate = new DateTime(2012, 6, 17), Complete = 0d, Cost = 234, BaselineCost = 333d, BaselineStart = new DateTime(2012, 6, 26), BaselineEnd = new DateTime(2012, 6, 28) });

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 37, Name = "Interior Finishing", StDate = new DateTime(2012, 6, 17), EndDate = new DateTime(2012, 6, 19), Complete = 0d, Cost = 43, BaselineCost = 33d, BaselineStart = new DateTime(2012, 6, 28), BaselineEnd = new DateTime(2012, 7, 9) });

            data[0].ChildTask[6].ChildTask.Add(new HighlightingTasksModel() { Id = 38, Name = "Installing Insulation", StDate = new DateTime(2012, 6, 17), EndDate = new DateTime(2012, 6, 19), Complete = 0d, Cost = 43, BaselineCost = 33d, BaselineStart = new DateTime(2012, 6, 28), BaselineEnd = new DateTime(2012, 7, 9) });
            data[0].ChildTask[6].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 39, Name = "Install Floor Insulation", StDate = new DateTime(2012, 6, 17), EndDate = new DateTime(2012, 6, 19), Complete = 0d, Cost = 43, BaselineCost = 33d, BaselineStart = new DateTime(2012, 6, 28), BaselineEnd = new DateTime(2012, 7, 9) });
            data[0].ChildTask[6].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 40, Name = "Install Wall Insulation", StDate = new DateTime(2012, 6, 19), EndDate = new DateTime(2012, 6, 21), Complete = 0d, Cost = 53, BaselineCost = 83d, BaselineStart = new DateTime(2012, 7, 10), BaselineEnd = new DateTime(2012, 7, 20) });
            data[0].ChildTask[6].ChildTask[0].ChildTask.Add(new HighlightingTasksModel() { Id = 41, Name = "Install Ceiling Insulation", StDate = new DateTime(2012, 6, 21), EndDate = new DateTime(2012, 6, 22), Complete = 0d, Cost = 89, BaselineCost = 83d, BaselineStart = new DateTime(2012, 7, 20), BaselineEnd = new DateTime(2012, 7, 22) });


            data[0].ChildTask[6].ChildTask.Add(new HighlightingTasksModel() { Id = 42, Name = "Painting and Wallpaper", StDate = new DateTime(2012, 6, 22), EndDate = new DateTime(2012, 6, 23), Complete = 0d, Cost = 453, BaselineCost = 563, BaselineStart = new DateTime(2012, 7, 21), BaselineEnd = new DateTime(2012, 7, 25) });
            data[0].ChildTask[6].ChildTask[1].ChildTask.Add(new HighlightingTasksModel() { Id = 43, Name = "Painting all Interior", StDate = new DateTime(2012, 6, 22), EndDate = new DateTime(2012, 6, 23), Complete = 0d, Cost = 453, BaselineCost = 563, BaselineStart = new DateTime(2012, 7, 21), BaselineEnd = new DateTime(2012, 7, 25) });
            data[0].ChildTask[6].ChildTask[1].ChildTask.Add(new HighlightingTasksModel() { Id = 44, Name = "Painting all Exterior", StDate = new DateTime(2012, 6, 23), EndDate = new DateTime(2012, 6, 25), Complete = 0d, Cost = 352, BaselineCost = 342, BaselineStart = new DateTime(2012, 7, 26), BaselineEnd = new DateTime(2012, 7, 27) });
            data[0].ChildTask[6].ChildTask[1].ChildTask.Add(new HighlightingTasksModel() { Id = 45, Name = "Additional Trimming Work", StDate = new DateTime(2012, 6, 25), EndDate = new DateTime(2012, 6, 27), Complete = 0d, Cost = 32, BaselineCost = 50, BaselineStart = new DateTime(2012, 7, 28), BaselineEnd = new DateTime(2012, 7, 29) });

            data[0].ChildTask[6].ChildTask.Add(new HighlightingTasksModel() { Id = 46, Name = "Finishing Plumbing", StDate = new DateTime(2012, 6, 27), EndDate = new DateTime(2012, 6, 29), Complete = 0d, Cost = 424, BaselineCost = 423, BaselineStart = new DateTime(2012, 7, 29), BaselineEnd = new DateTime(2012, 8, 1) });
            data[0].ChildTask[6].ChildTask[2].ChildTask.Add(new HighlightingTasksModel() { Id = 47, Name = "First floor Plumbing", StDate = new DateTime(2012, 6, 27), EndDate = new DateTime(2012, 6, 29), Complete = 0d, Cost = 424, BaselineCost = 423, BaselineStart = new DateTime(2012, 7, 29), BaselineEnd = new DateTime(2012, 8, 1) });
            data[0].ChildTask[6].ChildTask[2].ChildTask.Add(new HighlightingTasksModel() { Id = 48, Name = "Second floor plumbing", StDate = new DateTime(2012, 6, 29), EndDate = new DateTime(2012, 7, 1), Complete = 0d, Cost = 234, BaselineCost = 324, BaselineStart = new DateTime(2012, 8, 1), BaselineEnd = new DateTime(2012, 8, 9) });
            data[0].ChildTask[6].ChildTask[2].ChildTask.Add(new HighlightingTasksModel() { Id = 49, Name = "Inspecting Plumbing", StDate = new DateTime(2012, 7, 1), EndDate = new DateTime(2012, 7, 3), Complete = 0d, Cost = 23, BaselineCost = 33d, BaselineStart = new DateTime(2012, 8, 10), BaselineEnd = new DateTime(2012, 8, 17) });

            data[0].ChildTask[6].ChildTask.Add(new HighlightingTasksModel() { Id = 50, Name = "Finishing Electrical", StDate = new DateTime(2012, 7, 3), EndDate = new DateTime(2012, 7, 5), Complete = 0d, Cost = 432, BaselineCost = 536, BaselineStart = new DateTime(2012, 8, 17), BaselineEnd = new DateTime(2012, 8, 19) });
            data[0].ChildTask[6].ChildTask[3].ChildTask.Add(new HighlightingTasksModel() { Id = 51, Name = "Complete first floor connections", StDate = new DateTime(2012, 7, 3), EndDate = new DateTime(2012, 7, 5), Complete = 0d, Cost = 432, BaselineCost = 536, BaselineStart = new DateTime(2012, 8, 17), BaselineEnd = new DateTime(2012, 8, 19) });
            data[0].ChildTask[6].ChildTask[3].ChildTask.Add(new HighlightingTasksModel() { Id = 52, Name = "Complete second floor connections", StDate = new DateTime(2012, 7, 5), EndDate = new DateTime(2012, 7, 7), Complete = 0d, Cost = 563, BaselineCost = 463, BaselineStart = new DateTime(2012, 8, 18), BaselineEnd = new DateTime(2012, 8, 19) });
            data[0].ChildTask[6].ChildTask[3].ChildTask.Add(new HighlightingTasksModel() { Id = 53, Name = "Complete non-Electrical Wiring", StDate = new DateTime(2012, 7, 7), EndDate = new DateTime(2012, 7, 8), Complete = 0d, Cost = 234, BaselineCost = 563, BaselineStart = new DateTime(2012, 8, 19), BaselineEnd = new DateTime(2012, 8, 20) });

            data[0].ChildTask[6].ChildTask.Add(new HighlightingTasksModel() { Id = 54, Name = "Carpet,Tiles and Furnishing", StDate = new DateTime(2012, 7, 8), EndDate = new DateTime(2012, 7, 10), Complete = 0d, Cost = 253, BaselineCost = 210, BaselineStart = new DateTime(2012, 8, 20), BaselineEnd = new DateTime(2012, 8, 21) });
            data[0].ChildTask[6].ChildTask[4].ChildTask.Add(new HighlightingTasksModel() { Id = 55, Name = "Complete first floor carpet", StDate = new DateTime(2012, 7, 8), EndDate = new DateTime(2012, 7, 10), Complete = 0d, Cost = 253, BaselineCost = 210, BaselineStart = new DateTime(2012, 8, 20), BaselineEnd = new DateTime(2012, 8, 21) });
            data[0].ChildTask[6].ChildTask[4].ChildTask.Add(new HighlightingTasksModel() { Id = 56, Name = "Complete second floor carpet", StDate = new DateTime(2012, 7, 10), EndDate = new DateTime(2012, 7, 13), Complete = 0d, Cost = 341, BaselineCost = 300, BaselineStart = new DateTime(2012, 8, 21), BaselineEnd = new DateTime(2012, 8, 22) });
            data[0].ChildTask[6].ChildTask[4].ChildTask.Add(new HighlightingTasksModel() { Id = 57, Name = "Complete Furnishing Kitchen, bath, hall", StDate = new DateTime(2012, 7, 13), EndDate = new DateTime(2012, 7, 14), Complete = 0, Cost = 4252, BaselineCost = 6033d, BaselineStart = new DateTime(2012, 8, 22), BaselineEnd = new DateTime(2012, 8, 25) });

            data[0].ChildTask.Add(new HighlightingTasksModel() { Id = 58, Name = "Final Acceptance", StDate = new DateTime(2012, 7, 14), EndDate = new DateTime(2012, 7, 16), Complete = 0d, Cost = 430, BaselineCost = 433d, BaselineStart = new DateTime(2012, 8, 25), BaselineEnd = new DateTime(2012, 8, 26) });
            data[0].ChildTask[7].ChildTask.Add(new HighlightingTasksModel() { Id = 59, Name = "Cleaning", StDate = new DateTime(2012, 7, 14), EndDate = new DateTime(2012, 7, 16), Complete = 0d, Cost = 430, BaselineCost = 433d, BaselineStart = new DateTime(2012, 8, 25), BaselineEnd = new DateTime(2012, 8, 26) });
            data[0].ChildTask[7].ChildTask.Add(new HighlightingTasksModel() { Id = 60, Name = "Final Inspection", StDate = new DateTime(2012, 7, 16), EndDate = new DateTime(2012, 7, 17), Complete = 0d, Cost = 0, BaselineCost = 5, BaselineStart = new DateTime(2012, 8, 26), BaselineEnd = new DateTime(2012, 8, 27) });
            data[0].ChildTask[7].ChildTask.Add(new HighlightingTasksModel() { Id = 61, Name = "Move In", StDate = new DateTime(2012, 7, 17), EndDate = new DateTime(2012, 7, 17), Complete = 0d, Cost = 0, BaselineCost = 0, BaselineStart = new DateTime(2012, 8, 28), BaselineEnd = new DateTime(2012, 8, 28) });


            //Adding Resources
            data[0].ChildTask[0].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[1]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[0]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[2]);

            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[0]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[1]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[2]);

            data[0].ChildTask[1].ChildTask[0].Resource.Add(ResidentialConstructionResources[3]);
            data[0].ChildTask[1].ChildTask[1].Resource.Add(ResidentialConstructionResources[3]);
            data[0].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[5]);
            data[0].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[6]);
            data[0].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[4]);

            data[0].ChildTask[2].ChildTask[0].Resource.Add(ResidentialConstructionResources[3]);
            data[0].ChildTask[2].ChildTask[1].Resource.Add(ResidentialConstructionResources[6]);
            data[0].ChildTask[2].ChildTask[2].Resource.Add(ResidentialConstructionResources[7]);
            data[0].ChildTask[2].ChildTask[3].Resource.Add(ResidentialConstructionResources[3]);

            data[0].ChildTask[3].ChildTask[0].Resource.Add(ResidentialConstructionResources[8]);
            data[0].ChildTask[3].ChildTask[1].Resource.Add(ResidentialConstructionResources[8]);
            data[0].ChildTask[3].ChildTask[2].Resource.Add(ResidentialConstructionResources[9]);
            data[0].ChildTask[3].ChildTask[3].Resource.Add(ResidentialConstructionResources[7]);

            data[0].ChildTask[4].ChildTask[0].Resource.Add(ResidentialConstructionResources[8]);
            data[0].ChildTask[4].ChildTask[1].Resource.Add(ResidentialConstructionResources[9]);
            data[0].ChildTask[4].ChildTask[2].Resource.Add(ResidentialConstructionResources[8]);

            data[0].ChildTask[5].ChildTask[0].Resource.Add(ResidentialConstructionResources[14]);
            data[0].ChildTask[5].ChildTask[1].Resource.Add(ResidentialConstructionResources[8]);

            data[0].ChildTask[6].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[10]);
            data[0].ChildTask[6].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[10]);
            data[0].ChildTask[6].ChildTask[0].ChildTask[2].Resource.Add(ResidentialConstructionResources[10]);

            data[0].ChildTask[6].ChildTask[1].ChildTask[0].Resource.Add(ResidentialConstructionResources[12]);
            data[0].ChildTask[6].ChildTask[1].ChildTask[1].Resource.Add(ResidentialConstructionResources[12]);
            data[0].ChildTask[6].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[12]);

            data[0].ChildTask[6].ChildTask[2].ChildTask[0].Resource.Add(ResidentialConstructionResources[5]);
            data[0].ChildTask[6].ChildTask[2].ChildTask[1].Resource.Add(ResidentialConstructionResources[5]);
            data[0].ChildTask[6].ChildTask[2].ChildTask[2].Resource.Add(ResidentialConstructionResources[7]);

            data[0].ChildTask[6].ChildTask[3].ChildTask[0].Resource.Add(ResidentialConstructionResources[4]);
            data[0].ChildTask[6].ChildTask[3].ChildTask[1].Resource.Add(ResidentialConstructionResources[4]);
            data[0].ChildTask[6].ChildTask[3].ChildTask[2].Resource.Add(ResidentialConstructionResources[4]);

            data[0].ChildTask[6].ChildTask[4].ChildTask[0].Resource.Add(ResidentialConstructionResources[13]);
            data[0].ChildTask[6].ChildTask[4].ChildTask[1].Resource.Add(ResidentialConstructionResources[13]);
            data[0].ChildTask[6].ChildTask[4].ChildTask[2].Resource.Add(ResidentialConstructionResources[14]);

            data[0].ChildTask[7].ChildTask[0].Resource.Add(ResidentialConstructionResources[16]);
            data[0].ChildTask[7].ChildTask[1].Resource.Add(ResidentialConstructionResources[7]);
            data[0].ChildTask[7].ChildTask[2].Resource.Add(ResidentialConstructionResources[1]);

            //Adding Predecessors
            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 4, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[4].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });

            data[0].ChildTask[0].ChildTask[2].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[2].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });

            data[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 13, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 14, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 15, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 17, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 18, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[2].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 19, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[2].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 21, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 19, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[2].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 23, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[3].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 24, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[3].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 26, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[3].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 27, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[3].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 28, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[4].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 29, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[4].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 31, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[4].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 32, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[5].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 33, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[5].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 35, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[0].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 36, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[0].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 39, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[0].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 40, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 41, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[1].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 43, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 44, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 43, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[2].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 45, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 47, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 48, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[3].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 49, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[3].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 48, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[3].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 51, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[3].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 52, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[4].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 53, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[4].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 55, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[4].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 56, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[7].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 57, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[7].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 59, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[7].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 60, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            return data;
        }

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<Resource> GetResources()
        {
            ObservableCollection<Resource> Resources = new ObservableCollection<Resource>();
            Resources.Add(new Resource() { ID = 1, Name = "General Contractor" });
            Resources.Add(new Resource() { ID = 2, Name = "Owner" });
            Resources.Add(new Resource() { ID = 3, Name = "Architect" });
            Resources.Add(new Resource() { ID = 4, Name = "Site Excavation Contractor" });
            Resources.Add(new Resource() { ID = 5, Name = "Electrical Contractor" });
            Resources.Add(new Resource() { ID = 6, Name = "Plumbing Contractor" });
            Resources.Add(new Resource() { ID = 7, Name = "Concrete Contractor" });
            Resources.Add(new Resource() { ID = 8, Name = "Inspector" });
            Resources.Add(new Resource() { ID = 9, Name = "Framing Contractor" });
            Resources.Add(new Resource() { ID = 10, Name = "Roofing Contractor" });
            Resources.Add(new Resource() { ID = 11, Name = "Insulation Contractor" });
            Resources.Add(new Resource() { ID = 12, Name = "Drywall contractor" });
            Resources.Add(new Resource() { ID = 13, Name = "Painting Contractor" });
            Resources.Add(new Resource() { ID = 14, Name = "Flooring Contractor" });
            Resources.Add(new Resource() { ID = 15, Name = "Appliance Contractor" });
            Resources.Add(new Resource() { ID = 16, Name = "Masonry Contractor" });
            Resources.Add(new Resource() { ID = 17, Name = "Maid Service" });

            return Resources;
        }
    }
}
