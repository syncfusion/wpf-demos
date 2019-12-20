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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GettingStarted
{
    public class ViewModel : NotificationObject
    {
        private ScheduleType _scheduleType = ScheduleType.Month;

        public ViewModel()
        {
            Events = GenerateRandomAppointments();
            ScheduleTypeCommand = new DelegateCommand(ChangeScheduleType, (obj) => true);
        }

        public DelegateCommand ScheduleTypeCommand { get; set; }

        public ScheduleType ScheduleType
        {
            get { return _scheduleType; }
            set
            {
                _scheduleType = value;
                this.RaisePropertyChanged("ScheduleType");
            }
        }

        private void ChangeScheduleType(object typename)
        {
            ScheduleType = (ScheduleType)Enum.Parse(typeof(ScheduleType), typename.ToString());
        }

        public ScheduleAppointmentCollection Events { get; set; }

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
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0x96, 0x09)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));

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
                    Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count]
                });
            }
            int j = 0;
            int k = 0;
            int l = 0;

            while (j < YearlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)];
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[1],
                    Subject = YearlyOccurranceSubjects[j]
                });
                j++;
            }
            while (k < MonthlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(9, 23));
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[k],
                    Subject = MonthlyOccurranceSubjects[k]
                });
                k++;
            }
            while (l < WeekEndOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(0, 23));
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[l],
                    Subject = WeekEndOccurranceSubjects[l]
                });
                l++;
            }

            return appointments;
        }
    }
}
