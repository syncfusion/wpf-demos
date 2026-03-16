#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    public class ReminderViewModel : NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReminderViewModel" /> class.
        /// </summary>
        public ReminderViewModel()
        {
            this.Events = new ObservableCollection<SchedulerModel>();
            this.CreateSchedulerAppointments();
            this.SchedulerViewTypes = SchedulerViewTypeHelper.GetSchedulerViewTypes();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public ObservableCollection<SchedulerModel> Events { get; set; }

        /// <summary>
        /// Gets or sets display date
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> SchedulerViewTypes { get; set; }

        #endregion Properties

        #region CreateSchedulerAppointmentCollection

        /// <summary>
        /// Method to create Scheduler appointment collection
        /// </summary>
        private void CreateSchedulerAppointments()
        {
            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now,
                To = DateTime.Now.AddHours(1),
                Color = new SolidColorBrush(Color.FromRgb(83, 99, 250)),
                ForegroundColor = Brushes.White,
                EventName = "Conference",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(-2).AddHours(10),
                To = DateTime.Now.Date.AddDays(-2).AddHours(11),
                Color = new SolidColorBrush(Color.FromRgb(133, 81, 242)),
                ForegroundColor = Brushes.White,
                EventName = "Business Meeting",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(2).AddHours(12),
                To = DateTime.Now.Date.AddDays(2).AddHours(13),
                Color = new SolidColorBrush(Color.FromRgb(45, 153, 255)),
                ForegroundColor = Brushes.White,
                EventName = "Medical check up",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(1, 0, 0, 0)},
                    new ReminderModel { TimeInterval = new TimeSpan(2, 0, 0, 0)},
                    new ReminderModel { TimeInterval = new TimeSpan(3, 0, 0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(-10).AddHours(15),
                To = DateTime.Now.Date.AddDays(-10).AddHours(16),
                Color = new SolidColorBrush(Color.FromRgb(253, 183, 165)),
                ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                EventName = "Project Status Discussion",
                Notes = "provides an opportunity to share information across the whole team.",
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=WE;INTERVAL=1;COUNT=20",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(3).AddHours(14),
                To = DateTime.Now.Date.AddDays(3).AddHours(15),
                Color = new SolidColorBrush(Color.FromRgb(191, 235, 97)),
                ForegroundColor = Brushes.Black,
                EventName = "GoToMeeting",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

        }

        #endregion CreateSchedulerAppointmentCollection
    }
}
