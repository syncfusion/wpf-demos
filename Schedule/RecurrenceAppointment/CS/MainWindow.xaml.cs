#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecurrenceAppointment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    #region MainWindow Class

    public partial class MainWindow : ChromelessWindow
    {
        #region Constructor

        public MainWindow()
        {
            this.InitializeComponent();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
               today= today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
               today= today.AddMonths(1);
            }
            DateTime currentdate = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            ScheduleAppointmentCollection AppointmentCollection = new ScheduleAppointmentCollection();
            ObservableCollection<DateTime> exceptionDate = new ObservableCollection<DateTime>();
            // Daily Recursive Appointment

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
            AppointmentCollection.Add(SchApp);

            Schedule.Appointments = AppointmentCollection;

            // Weekly Recursive Appointment

            ScheduleAppointment SchAppWeek = new ScheduleAppointment();
            SchAppWeek.Subject = "Doctor Appointment";
            SchAppWeek.Notes = "Weekly Recurrence";
            SchAppWeek.Location = "Global Hospital";
            SchAppWeek.StartTime = currentdate;
            SchAppWeek.EndTime = currentdate.AddHours(4);
            SchAppWeek.AppointmentBackground = new SolidColorBrush((Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));

            // Setting Recurrence Properties

            RecurrenceProperties RecPropWeek = new RecurrenceProperties();
            RecPropWeek.RecurrenceType = RecurrenceType.Weekly;
            RecPropWeek.WeeklyEveryNWeeks = 1;
            RecPropWeek.IsWeeklySunday = true;
            RecPropWeek.IsRangeRecurrenceCount = true;
            RecPropWeek.IsRangeNoEndDate = false;
            RecPropWeek.IsRangeEndDate = false;
            RecPropWeek.RangeRecurrenceCount = 20;

            // Generating RRule using ScheduleHelper

            SchAppWeek.RecurrenceRule = ScheduleHelper.RRuleGenerator(RecPropWeek, SchAppWeek.StartTime, SchAppWeek.EndTime);
            SchAppWeek.IsRecursive = true;
            AppointmentCollection.Add(SchAppWeek);

            // Montly Recursive Appointment

            ScheduleAppointment SchAppMonth = new ScheduleAppointment();
            SchAppMonth.Subject = "Client Meeting";
            SchAppMonth.Notes = "Monthly Recurrence";
            SchAppMonth.Location = "Chennai";
            SchAppMonth.StartTime = currentdate;
            SchAppMonth.EndTime = currentdate.AddHours(4);
            SchAppMonth.AppointmentBackground = new SolidColorBrush((Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));

            // Setting Recurrence Properties using RRule

            SchAppMonth.RecurrenceRule = "FREQ=MONTHLY;COUNT=5;BYDAY=6;BYSETPOS=3";
            SchAppMonth.IsRecursive = true;
            AppointmentCollection.Add(SchAppMonth);

            // Yearly Recursive Appointment

            ScheduleAppointment SchAppYear = new ScheduleAppointment();
            SchAppYear.Subject = "Wedding Anniversary";
            SchAppYear.Notes = "Yearly Recurrence";
            SchAppYear.Location = "Home";
            SchAppYear.StartTime = currentdate;
            SchAppYear.EndTime = currentdate.AddHours(4);
            SchAppYear.AppointmentBackground = new SolidColorBrush((Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));

            // Setting Recurrence Properties using RRule

            SchAppYear.RecurrenceRule = "FREQ=YEARLY;COUNT=3;BYMONTHDAY=" + (DateTime.Now.Day).ToString() + ";BYMONTH=" + (DateTime.Now.Month).ToString() + "";
            SchAppYear.IsRecursive = true;
            AppointmentCollection.Add(SchAppYear);

        }

        #endregion

    }

    #endregion
}
