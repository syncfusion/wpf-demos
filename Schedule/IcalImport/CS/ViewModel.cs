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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IcalImport
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            this.GenerateAppointments();
        }

        private ScheduleAppointmentCollection events;

        public ScheduleAppointmentCollection Events
        {
            get { return events; }
            set
            {
                events = value;
                this.RaisePropertyChanged("Events");
            }
        }

        private void GenerateAppointments()
        {
            ObservableCollection<DateTime> WorkWeekDays = new ObservableCollection<DateTime>();
            ObservableCollection<string> WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            ObservableCollection<DateTime> NonWorkingDays = new ObservableCollection<DateTime>();
            ObservableCollection<string> NonWorkingSubjects = new ObservableCollection<string>()
                                                           { "Go to party", "Order Pizza", "Buy Gift",
                                                             "Vacation" };
            ObservableCollection<DateTime> YearlyOccurrance = new ObservableCollection<DateTime>();
            ObservableCollection<string> YearlyOccurranceSubjects = new ObservableCollection<string>() { "Wedding Anniversary", "Sam's Birthday", "Jenny's Birthday" };
            ObservableCollection<DateTime> MonthlyOccurrance = new ObservableCollection<DateTime>();
            ObservableCollection<string> MonthlyOccurranceSubjects = new ObservableCollection<string>() { "Pay House Rent", "Car Service", "Medical Check Up" };
            ObservableCollection<DateTime> WeekEndOccurrance = new ObservableCollection<DateTime>();
            ObservableCollection<string> WeekEndOccurranceSubjects = new ObservableCollection<string>() { "FootBall Match", "Car Wash", "TV Show" };
            var ran = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }
            DateTime startMonth = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            DateTime endMonth = new DateTime(today.Year, today.Month + 1, 30, 0, 0, 0);
            DateTime dt = new DateTime(today.Year, today.Month, 15, 0, 0, 0);
            int day = (int)startMonth.DayOfWeek;
            DateTime CurrentStart = startMonth.AddDays(-day);
            ObservableCollection<SolidColorBrush> brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0x96, 0x09)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));

            Events = new ScheduleAppointmentCollection();
            for (int i = 0; i < 90; i++)
            {
                if (i % 7 == 0 || i % 7 == 6)
                {
                    //add weekend appointments
                    NonWorkingDays.Add(CurrentStart.AddDays(i));
                }
                else
                {
                    //Add Workweek appointment
                    WorkWeekDays.Add(CurrentStart.AddDays(i));
                }
            }


            for (int i = 0; i < 60; i++)
            {
                DateTime date = WorkWeekDays[ran.Next(0, WorkWeekDays.Count)].AddHours(ran.Next(9, 17));
                Events.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[i % brush.Count],
                    Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count]
                });
            }
        }
    }
}
