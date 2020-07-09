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
using System.Globalization;
using System.Linq;
using System.Windows;
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
                EventName = "Daily scrum meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                BackColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=50"
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            //Add ExceptionDates to avoid occurrence on specific dates.
            DateTime changedExceptionDate = dailyEvent.From.AddDays(5).Date;
            DateTime deletedExceptionDate = dailyEvent.From.AddDays(2).Date;

            dailyEvent.RecurrenceExceptions = new ObservableCollection<DateTime>()
            {
                deletedExceptionDate,
                changedExceptionDate,
            };

            //Change start time or end time of an occurrence.
            Meeting changedEvent = new Meeting
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, 13, 0, 0),
                BackColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                RecurrenceId = dailyEvent
            };

            RecursiveAppointmentCollection.Add(changedEvent);
        }

		#endregion creating RecurrsiveAppointments
	}
}