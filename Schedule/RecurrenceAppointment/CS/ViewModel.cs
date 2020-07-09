#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace RecurrenceAppointment
{
    public class ViewModel
    {
        public ViewModel()
        {
            Events = GenerateRandomAppointments();
        }

        public ScheduleAppointmentCollection Events { get; set; }

        private ScheduleAppointmentCollection GenerateRandomAppointments()
        {
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }

            DateTime currentdate = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);

            var Appointments = new ScheduleAppointmentCollection();
            var exceptionDate = new ObservableCollection<DateTime>();

            //DAILY RECURSIVE APPOINTMENTS
            ScheduleAppointment SchApp = new ScheduleAppointment();
            SchApp.Subject = "Team Meeting";
            SchApp.Notes = "Daily Recurrence";
            SchApp.Location = "Meeting Hall 1";
            SchApp.StartTime = currentdate;
            SchApp.EndTime = currentdate.AddHours(4);
            SchApp.AppointmentBackground = new SolidColorBrush((Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            //Avoid the recurrence appoinments for following specified dates
            for (int i = 0; i < 14; i++)
                exceptionDate.Add(currentdate.AddMonths(1).AddDays(i + 15));
            SchApp.RecursiveExceptionDates = exceptionDate;

            // Setting Recurrence Properties
            RecurrenceProperties RecProp = new RecurrenceProperties();
            RecProp.RecurrenceType = RecurrenceType.Weekly;
            RecProp.IsWeeklyTuesday = true;
            RecProp.IsWeeklyWednesday = true;
            RecProp.IsWeeklyThursday = true;
            RecProp.IsDailyEveryNDays = false;
            RecProp.IsRangeRecurrenceCount = true;
            RecProp.IsRangeNoEndDate = false;
            RecProp.IsRangeEndDate = false;
            RecProp.RangeRecurrenceCount = 50;

            // Generating RRule using ScheduleHelper

            SchApp.RecurrenceRule = ScheduleHelper.RRuleGenerator(RecProp, SchApp.StartTime, SchApp.EndTime);
            SchApp.IsRecursive = true;
            Appointments.Add(SchApp);

            //WEEKLY RECURSIVE APPOINTMENT
            ScheduleAppointment SchAppWeek = new ScheduleAppointment();
            SchAppWeek.Subject = "Doctor Appointment";
            SchAppWeek.Notes = "Weekly Recurrence";
            SchAppWeek.Location = "Global Hospital";
            SchAppWeek.StartTime = currentdate;
            SchAppWeek.EndTime = currentdate.AddHours(4);
            SchAppWeek.AppointmentBackground = new SolidColorBrush((Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));

            //Setting RRule as per ICalc standard by generating from RecurrenceProperties. You can assign string directly also.
            RecurrenceProperties RecPropWeek = new RecurrenceProperties();
            RecPropWeek.RecurrenceType = RecurrenceType.Weekly;
            RecPropWeek.WeeklyEveryNWeeks = 1;
            RecPropWeek.IsWeeklySunday = true;
            RecPropWeek.IsRangeRecurrenceCount = true;
            RecPropWeek.IsRangeNoEndDate = false;
            RecPropWeek.IsRangeEndDate = false;
            RecPropWeek.RangeRecurrenceCount = 20;
            
            SchAppWeek.RecurrenceRule = "FREQ=WEEKLY;COUNT=20;BYDAY=SU";
            SchAppWeek.IsRecursive = true;
            Appointments.Add(SchAppWeek);

            //Montly Recursive Appointment
            var SchAppMonth = new ScheduleAppointment();
            SchAppMonth.Subject = "Client Meeting";
            SchAppMonth.Notes = "Monthly Recurrence";
            SchAppMonth.Location = "Chennai";
            SchAppMonth.StartTime = currentdate;
            SchAppMonth.EndTime = currentdate.AddHours(4);
            SchAppMonth.AppointmentBackground = new SolidColorBrush((Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));

            //Setting RRule as per ICalc standard.
            SchAppMonth.RecurrenceRule = "FREQ=MONTHLY;COUNT=5;BYDAY=6;BYSETPOS=3";
            SchAppMonth.IsRecursive = true;
            Appointments.Add(SchAppMonth);

            // Yearly Recursive Appointment
            var SchAppYear = new ScheduleAppointment();
            SchAppYear.Subject = "Wedding Anniversary";
            SchAppYear.Notes = "Yearly Recurrence";
            SchAppYear.Location = "Home";
            SchAppYear.StartTime = currentdate.AddHours(9);
            SchAppYear.EndTime = currentdate.AddHours(12);
            SchAppYear.AppointmentBackground = new SolidColorBrush((Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));

            //Setting RRule as per ICalc standard.
            SchAppYear.RecurrenceRule = "FREQ=YEARLY;COUNT=3;BYMONTHDAY=" + (DateTime.Now.Day).ToString() + ";BYMONTH=" + (DateTime.Now.Month).ToString() + "";
            SchAppYear.IsRecursive = true;
            Appointments.Add(SchAppYear);
            return Appointments;
        }
    }
}
