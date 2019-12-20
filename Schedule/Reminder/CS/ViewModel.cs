#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReminderDemo
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            Events = new ScheduleAppointmentCollection();
            LoadAppointments();
        }

        private ScheduleAppointmentCollection _events;
        public ScheduleAppointmentCollection Events
        {
            get { return _events; }
            set
            {
                _events = value;
                this.RaisePropertyChanged("Events");
            }
        }

        private void LoadAppointments()
        {
            DateTime currectDate = DateTime.Now;

            //Remind the event Five Minutes before.
            Events.Add(new ScheduleAppointment
            {
                StartTime = currectDate.Date.AddDays(-1).AddHours(9),
                EndTime = currectDate.Date.AddDays(-1).AddHours(10),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0x8E, 0xC4, 0x41)),
                Subject = "Business Meeting",
                ReminderTime = ReminderTimeType.FiveMin
            });

            //Remind the event One Day before.
            Events.Add(new ScheduleAppointment
            {
                StartTime = currectDate.Date.AddDays(1),
                EndTime = currectDate.Date.AddDays(1).AddHours(4),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0x8D, 0xEA, 0xFF)),
                Subject = "Auditing",
                ReminderTime = ReminderTimeType.OneDay
            });

            //Remind the event Two Weeks before.
            Events.Add(new ScheduleAppointment
            {
                StartTime = currectDate.Date.AddDays(7),
                EndTime = currectDate.Date.AddDays(7).AddHours(3),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0xF7, 0x94, 0xD7)),
                Subject = "Conference",
                ReminderTime = ReminderTimeType.TwoWeeks
            });
        }
    }
}
