#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    public class SchedulerModel : NotificationObject
    {
        private DateTime from, to;
        private string eventName;
        private bool isAllDay;
        private string startTimeZone, endTimeZone;
        private Brush color;
        private ObservableCollection<DateTime> recurrenceExceptionDates = new ObservableCollection<DateTime>();
        private string rRUle;
        private object recurrenceId;
        private object id;
        private ObservableCollection<object> resources;
        private string notes;
        private string timeValue;
        private ObservableCollection<ReminderModel> reminders;

        public SchedulerModel()
        {
        }

        public DateTime From
        {
            get { return from; }
            set
            {
                from = value;
                RaisePropertyChanged("From");
            }
        }

        public DateTime To
        {
            get { return to; }
            set
            {
                to = value;
                RaisePropertyChanged("To");
            }
        }

        public bool IsAllDay
        {
            get { return isAllDay; }
            set
            {
                isAllDay = value;
                RaisePropertyChanged("IsAllDay");
            }
        }
        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                RaisePropertyChanged("EventName");
            }
        }

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                RaisePropertyChanged("Notes");
            }
        }
        public string StartTimeZone
        {
            get { return startTimeZone; }
            set
            {
                startTimeZone = value;
                RaisePropertyChanged("StartTimeZone");
            }
        }
        public string EndTimeZone
        {
            get { return endTimeZone; }
            set
            {
                endTimeZone = value;
                RaisePropertyChanged("EndTimeZone");
            }
        }

        public Brush Color
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }

        public object RecurrenceId
        {
            get { return recurrenceId; }
            set
            {
                recurrenceId = value;
                RaisePropertyChanged("RecurrenceId");
            }
        }

        public object Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string RecurrenceRule
        {
            get { return rRUle; }
            set
            {
                rRUle = value;
                RaisePropertyChanged("RecurrenceRule");
            }
        }

        public ObservableCollection<DateTime> RecurrenceExceptions
        {
            get { return recurrenceExceptionDates; }
            set
            {
                recurrenceExceptionDates = value;
                RaisePropertyChanged("RecurrenceExceptions");
            }
        }

        /// <summary>
        /// Gets or sets Resource
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get { return resources; }
            set
            {
                resources = value;
                this.RaisePropertyChanged("Resources");
            }
        }

        /// <summary>
        /// Gets or sets Reminders
        /// </summary>
        public ObservableCollection<ReminderModel> Reminders
        {
            get { return reminders; }
            set
            {
                reminders = value;
                this.RaisePropertyChanged("Reminders");
            }
        }

        /// <summary>
        /// Get or sets appointment time values in appointment customization
        /// </summary>
        public string TimeValue
        {
            get { return timeValue; }
            set
            {
                timeValue = value;
                RaisePropertyChanged("TimeValue");
            }
        }
    }

    public class Employee
    {
        /// <summary>
        /// Gets or sets the resource name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource id.
        /// </summary>
        public object ID { get; set; }

        /// <summary>
        /// Gets or sets the resource background brush.
        /// </summary>
        public Brush BackgroundBrush { get; set; }

        /// <summary>
        /// Gets or sets the foreground brush.
        /// </summary>
        public Brush ForegroundBrush { get; set; }

        /// <summary>
        /// Gets or sets the resource image.
        /// </summary>
        public string ImageSource { get; set; }
    }
}
