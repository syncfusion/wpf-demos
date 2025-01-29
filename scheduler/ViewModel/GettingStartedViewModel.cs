#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    public class GettingStartedViewModel : NotificationObject
    {
        public GettingStartedViewModel()
        {
            Events = GenerateRandomAppointments();
            TimelineEvents = GenerateTimelineRandomAppointments();
            MinDate = DateTime.Now.Date.AddMonths(-3);
            MaxDate = DateTime.Now.AddMonths(3);
            DisplayDate = DateTime.Now.Date.AddHours(9);
            this.SchedulerViewTypes = SchedulerViewTypeHelper.GetSchedulerViewTypes();
            this.CalendarTypes = SchedulerViewTypeHelper.GetCalendarTypes();
        }

        private ScheduleAppointmentCollection events;

        private ScheduleAppointmentCollection timelineEvents;

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> SchedulerViewTypes { get; set; }

        /// <summary>
        /// Gets or sets calendar identifier collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> CalendarTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> TimelineViewTypes { get; set; }

        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime DisplayDate { get; set; }
        public ScheduleAppointmentCollection Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged("Events");
            }
        }

        public ScheduleAppointmentCollection TimelineEvents
        {
            get { return timelineEvents; }
            set
            {
                timelineEvents = value;
                RaisePropertyChanged("TimelineEvents");
            }
        }

        /// <summary>
        /// Method to get foreground color based on background.
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        private Brush GetAppointmentForeground(Brush backgroundColor)
        {
            if (backgroundColor.ToString().Equals("#FF8551F2") || backgroundColor.ToString().Equals("#FF5363FA") || backgroundColor.ToString().Equals("#FF2D99FF"))
                return Brushes.White;
            else
                return new SolidColorBrush(Color.FromRgb(51, 51, 51));
        }

        private ScheduleAppointmentCollection GenerateRandomAppointments()
        {
            var WorkWeekDays = new ObservableCollection<DateTime>();
            var WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            var NonWorkingDays = new ObservableCollection<DateTime>();
            var NonWorkingSubjects = new ObservableCollection<string>()
                                                           { "Go to party", "Order Pizza", "Buy Gift",
                                                             "Vacation" };
            var YearlyOccurrance = new ObservableCollection<DateTime>();
            var YearlyOccurranceSubjects = new ObservableCollection<string>() { "Wedding Anniversary", "Sam's Birthday", "Jenny's Birthday" };
            var MonthlyOccurrance = new ObservableCollection<DateTime>();
            var MonthlyOccurranceSubjects = new ObservableCollection<string>() { "Pay House Rent", "Car Service", "Medical Check Up" };
            var WeekEndOccurrance = new ObservableCollection<DateTime>();
            var WeekEndOccurranceSubjects = new ObservableCollection<string>() { "FootBall Match", "TV Show" };


            var brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromRgb(133, 81, 242)));
            brush.Add(new SolidColorBrush(Color.FromRgb(140, 245, 219)));
            brush.Add(new SolidColorBrush(Color.FromRgb(83, 99, 250)));
            brush.Add(new SolidColorBrush(Color.FromRgb(255, 222, 133)));
            brush.Add(new SolidColorBrush(Color.FromRgb(45, 153, 255)));
            brush.Add(new SolidColorBrush(Color.FromRgb(253, 183, 165)));
            brush.Add(new SolidColorBrush(Color.FromRgb(198, 237, 115)));
            brush.Add(new SolidColorBrush(Color.FromRgb(253, 185, 222)));
            brush.Add(new SolidColorBrush(Color.FromRgb(255, 222, 133)));

            Random ran = new Random();
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

            var appointments = new ScheduleAppointmentCollection();
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

            for (int i = 0; i < 50; i++)
            {
                DateTime date = WorkWeekDays[ran.Next(0, WorkWeekDays.Count)].AddHours(ran.Next(9, 17));
                Brush background = brush[i % brush.Count];
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = background,
                    Foreground = GetAppointmentForeground(background),
                    Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count]
                });
            }
            int j = 0;
            int k = 0;
            int l = 0;

            while (j < YearlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)];
                Brush background = brush[1];
               appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = background,
                    Foreground = GetAppointmentForeground(background),
                    Subject = YearlyOccurranceSubjects[j]
                });
                j++;
            }
            while (k < MonthlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(9, 23));
                Brush background = brush[k];
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = background,
                    Foreground = GetAppointmentForeground(background),
                    Subject = MonthlyOccurranceSubjects[k]
                });
                k++;
            }
            while (l < WeekEndOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(0, 23));
                Brush background = brush[l];
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = background,
                    Foreground = GetAppointmentForeground(background),
                    Subject = WeekEndOccurranceSubjects[l]
                });
                l++;
            }

            return appointments;
        }

        private ScheduleAppointmentCollection GenerateTimelineRandomAppointments()
        {
            var WorkWeekDays = new ObservableCollection<DateTime>();
            var WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            var NonWorkingDays = new ObservableCollection<DateTime>();
            var NonWorkingSubjects = new ObservableCollection<string>()
                                                           { "Go to party", "Order Pizza", "Buy Gift",
                                                             "Vacation" };
            var YearlyOccurrance = new ObservableCollection<DateTime>();
            var YearlyOccurranceSubjects = new ObservableCollection<string>() { "Wedding Anniversary", "Sam's Birthday", "Jenny's Birthday" };
            var MonthlyOccurrance = new ObservableCollection<DateTime>();
            var MonthlyOccurranceSubjects = new ObservableCollection<string>() { "Pay House Rent", "Car Service", "Medical Check Up" };
            var WeekEndOccurrance = new ObservableCollection<DateTime>();
            var WeekEndOccurranceSubjects = new ObservableCollection<string>() { "FootBall Match", "TV Show" };


            var brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromRgb(133, 81, 242)));
            brush.Add(new SolidColorBrush(Color.FromRgb(140, 245, 219)));
            brush.Add(new SolidColorBrush(Color.FromRgb(83, 99, 250)));
            brush.Add(new SolidColorBrush(Color.FromRgb(255, 222, 133)));
            brush.Add(new SolidColorBrush(Color.FromRgb(45, 153, 255)));
            brush.Add(new SolidColorBrush(Color.FromRgb(253, 183, 165)));
            brush.Add(new SolidColorBrush(Color.FromRgb(198, 237, 115)));
            brush.Add(new SolidColorBrush(Color.FromRgb(253, 185, 222)));
            brush.Add(new SolidColorBrush(Color.FromRgb(255, 222, 133)));

            Random ran = new Random();
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

            var appointments = new ScheduleAppointmentCollection();
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

            for (int i = 0; i < 50; i++)
            {
                DateTime date = WorkWeekDays[ran.Next(0, WorkWeekDays.Count)].AddHours(ran.Next(9, 17));
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[i % brush.Count],
                    Foreground = GetAppointmentForeground(brush[i % brush.Count]),
                    Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count]
                });
            }

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            ScheduleAppointment weeklyEvent = new ScheduleAppointment
            {
                Subject = "Weekly recurring meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                AppointmentBackground = new SolidColorBrush((Color.FromRgb(45, 216, 175))),
                Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20",
                RecurrenceExceptionDates = new ObservableCollection<DateTime>()
            };

            appointments.Add(weeklyEvent);

            ScheduleAppointment monthlyEvent = new ScheduleAppointment
            {
                Subject = "Monthly recurring Meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0),
                AppointmentBackground = Brushes.Red,
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50",
                RecurrenceExceptionDates = new ObservableCollection<DateTime>()
            };

            appointments.Add(monthlyEvent);

            ScheduleAppointment dailyEvent = new ScheduleAppointment
            {
                Subject = "Daily scrum meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                AppointmentBackground = new SolidColorBrush((Color.FromRgb(191, 235, 97))),
                Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=50",
                Id = 1
            };

            appointments.Add(dailyEvent);

            //Add ExceptionDates to avoid occurrence on specific dates.
            DateTime changedExceptionDate1 = DateTime.Now.AddDays(-1).Date;
            DateTime changedExceptionDate2 = DateTime.Now.Date.AddDays(4).Date;
            DateTime deletedExceptionDate1 = DateTime.Now.Date.AddDays(2);
            DateTime deletedExceptionDate2 = DateTime.Now.Date.AddDays(6);
            DateTime deletedExceptionDate3 = DateTime.Now.Date.AddDays(8);

            dailyEvent.RecurrenceExceptionDates = new ObservableCollection<DateTime>()
            {
                changedExceptionDate1,
                changedExceptionDate2,
                deletedExceptionDate1,
                deletedExceptionDate2,
            };

            return appointments;
        }
    }
}
