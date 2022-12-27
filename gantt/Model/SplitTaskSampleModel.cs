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
    public class SplitTaskSampleModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplitTaskSampleModel"/> class.
        /// </summary>
        public SplitTaskSampleModel()
        {
            ChildTask = new ObservableCollection<SplitTaskSampleModel>();
            Predecessor = new ObservableCollection<Predecessor>();
            Resource = new ObservableCollection<Resource>();
            this.SplitSegments = new ObservableCollection<SplitTask>();
            this.Children = new ObservableCollection<SplitTaskSampleModel>();
        }

        private int id;
        private string name;
        private DateTime stDate;
        private DateTime endDate;
        private TimeSpan duration;
        private ObservableCollection<Resource> resource;
        private double complete;
        private ObservableCollection<SplitTaskSampleModel> childTask;
        private ObservableCollection<Predecessor> predecessor;

        public ObservableCollection<SplitTask> SplitSegments { get; set; }

        public ObservableCollection<SplitTaskSampleModel> Children { get; set; }

        /// <summary>
        /// Gets or sets the complete.
        /// </summary>
        /// <value>The complete.</value>
        public double Complete
        {
            get
            {
                return Math.Round(complete, 2);
            }
            set
            {
                this.complete = value;
                RaisePropertyChanged("Complete");
            }
        }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        /// <value>The resource.</value>
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
        /// <value>The duration.</value>
        public TimeSpan Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        /// <summary>
        /// Gets or sets the st date.
        /// </summary>
        /// <value>The st date.</value>
        public DateTime StDate
        {
            get
            {
                return stDate;
            }

            set
            {
                stDate = value;
                RaisePropertyChanged("StDate");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
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
        /// <value>The id.</value>
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
        /// <value>The predecessor.</value>
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
        /// Gets or sets the child task.
        /// </summary>
        /// <value>The child task.</value>
        public ObservableCollection<SplitTaskSampleModel> ChildTask
        {
            get
            {
                return childTask;
            }

            set
            {
                childTask = value;
                RaisePropertyChanged("ChildTask");
            }
        }
    }
}
