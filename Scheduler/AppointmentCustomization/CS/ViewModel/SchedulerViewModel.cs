#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AppointmentCustomization
{
    /// <summary>
    /// Appointment view customization view model.
    /// </summary>
    public class SchedulerViewModel : NotificationObject
    {
        #region Properties
        /// <summary>
        /// event name collection.
        /// </summary>
        private List<string> eventCollection;

        /// <summary>
        /// start time collection.
        /// </summary>
        private List<DateTime> startTimeCollection;

        /// <summary>
        /// Appointment background collection.
        /// </summary>
        private List<string> colorCollection;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulerViewModel" /> class
        /// </summary>
        public SchedulerViewModel()
        {
            this.InitializingDataForEvents();
            this.AddAppointments();
        }

        #endregion Constructor

        /// <summary>
        /// Gets or sets appointments
        /// </summary>
        public ObservableCollection<Events> Appointments { get; set; }

        #region methods
        /// <summary>
        /// Adding appointments
        /// </summary>
        private void AddAppointments()
        {
            var random = new Random();
            this.Appointments = new ObservableCollection<Events>();

            for (int i = 0; i < 60; i++)
            {
                var year = DateTime.Now.Date.Year;
                var month = DateTime.Now.Date.AddMonths(random.Next(-1, 2)).Month;
                var day = random.Next(1, 30);
                var hour = random.Next(9, 14);
                var newEvent = new Events();
                newEvent.EventName = this.eventCollection[random.Next(0, 4)];
                newEvent.From = new DateTime(year, month, day, hour, 0, 0);
                newEvent.To = newEvent.From.AddHours(1);
                newEvent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(this.colorCollection[random.Next(0, 15)]));
                this.Appointments.Add(newEvent);
            }

            for (int i = 0; i < 6; i++)
            {
                var allDayEvent = new Events();
                allDayEvent.EventName = this.eventCollection[random.Next(0, 5)];
                allDayEvent.From = this.startTimeCollection[random.Next(0,10)];
                allDayEvent.To = allDayEvent.From.AddHours(1);
                allDayEvent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(this.colorCollection[random.Next(0, 15)]));
                allDayEvent.IsAllDay = true;
                this.Appointments.Add(allDayEvent);
            }
        }

        /// <summary>
        /// Initializing data for appointments
        /// </summary>
        private void InitializingDataForEvents()
        {
            this.eventCollection = new List<string>();
            this.eventCollection.Add("Conference");
            this.eventCollection.Add("System Troubleshoot");
            this.eventCollection.Add("Birthday");
            this.eventCollection.Add("Checkup");
            this.eventCollection.Add("Conference");

            this.startTimeCollection = new List<DateTime>();
            this.startTimeCollection.Add(DateTime.Now.Date.AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(1).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(2).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(3).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(11).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(15).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(18).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(20).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(24).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddDays(27).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(1).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(1).AddDays(4).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(1).AddDays(11).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(-1).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(-1).AddDays(3).AddHours(9));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(1).AddDays(7).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(-1).AddDays(6).AddHours(10));
            this.startTimeCollection.Add(DateTime.Now.Date.AddMonths(-1).AddDays(9).AddHours(9));

            this.colorCollection = new List<string>();
            this.colorCollection.Add("#FFA2C139");
            this.colorCollection.Add("#FFD80073");
            this.colorCollection.Add("#FF1BA1E2");
            this.colorCollection.Add("#FFE671B8");
            this.colorCollection.Add("#FFF09609");
            this.colorCollection.Add("#FF339933");
            this.colorCollection.Add("#FF00ABA9");
            this.colorCollection.Add("#FFE671B8");
            this.colorCollection.Add("#FF1BA1E2");
            this.colorCollection.Add("#FFD80073");
            this.colorCollection.Add("#FFA2C139");
            this.colorCollection.Add("#FFA2C139");
            this.colorCollection.Add("#FFD80073");
            this.colorCollection.Add("#FF339933");
            this.colorCollection.Add("#FFE671B8");
            this.colorCollection.Add("#FF00ABA9");
        }
        #endregion
    }
}
