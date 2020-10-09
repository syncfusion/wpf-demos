#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace RecursiveAppointments
{
    /// <summary>
    /// Recurrence View Model class
    /// </summary>
	public class RecurrenceViewModel : NotificationObject
	{
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RecurrenceViewModel" /> class.
        /// </summary>
        public RecurrenceViewModel()
		{
			this.CreateRecurrsiveAppointments();
        }

        #endregion Constructor

        #region Properties
        /// <summary>
        /// Gets or sets recursive appointment collection
        /// </summary>
        public ObservableCollection<Meeting> RecursiveAppointmentCollection
        {
            get;
            set;
        }
        #endregion Properties

        #region creating RecurrsiveAppointments

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveAppointments()
		{
            this.RecursiveAppointmentCollection = new ObservableCollection<Meeting>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            Meeting dailyEvent = new Meeting
            {
                EventName = "Daily recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                BackColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100"
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            Meeting weeklyEvent = new Meeting
            {
                EventName = "Weekly recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                BackColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20"
            };

            RecursiveAppointmentCollection.Add(weeklyEvent);

            Meeting monthlyEvent = new Meeting
            {
                EventName = "Monthly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                BackColor = Brushes.Red,
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50"
            };

            RecursiveAppointmentCollection.Add(monthlyEvent);

            Meeting yearlyEvent = new Meeting
            {
                EventName = "Yearly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 2, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 3, 0, 0),
                BackColor = Brushes.Yellow,
                RecurrenceRule = "FREQ=YEARLY;BYMONTHDAY=3;BYMONTH=5;INTERVAL=1;COUNT=50"
            };

            RecursiveAppointmentCollection.Add(yearlyEvent);
        }

		#endregion creating RecurrsiveAppointments
	}
}