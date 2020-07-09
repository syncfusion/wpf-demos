#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System.Linq;

namespace Localization
{
    /// <summary>
    /// Schedule View Model
    /// </summary>
    public class ScheduleViewModel : NotificationObject
    {
        #region Properties
        /// <summary>
        /// french collection
        /// </summary>
        private List<string> frenchCollection;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Brush> colorCollection;

        /// <summary>
        /// start time collection
        /// </summary>
        private List<DateTime> startTimeCollection;

        /// <summary>
        /// end time collection
        /// </summary>
        private List<DateTime> endTimeCollection;

        /// <summary>
        /// random numbers
        /// </summary>
        ////creating random number collection
        private List<int> randomNums = new List<int>();
        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public ScheduleViewModel()
        {
            this.Appointments = new ObservableCollection<Meeting>();

            this.CreateRandomNumbersCollection();
            this.CreateStartTimeCollection();
            this.CreateEndTimeCollection();
            this.CreateColorCollection();

            this.AddFrenchLanguageString();
            this.GetFrenchAppoitments(10);
        }

        #endregion Constructor
        private ObservableCollection<Meeting> appointments;
        /// <summary>
        /// Gets or sets appointments
        /// </summary>
        public ObservableCollection<Meeting> Appointments
        {
            get { return appointments; }
            set
            {
                appointments = value;
            }
        }

        #region Methods

        #region GettingTimeRanges

        /// <summary>
        /// Method for get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

        #endregion GettingTimeRanges

        #region creating color collection

        /// <summary>
        /// color collection
        /// </summary>
        ////creating color collection
        private void CreateColorCollection()
        {
            this.colorCollection = new List<Brush>();
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF09609")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
        }

        #endregion creating color collection

        #region CreateRandomNumbersCollection

        /// <summary>
        /// random numbers collection
        /// </summary>
        private void CreateRandomNumbersCollection()
        {
            this.randomNums = new List<int>();

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int random = rand.Next(9, 15);
                this.randomNums.Add(random);
            }
        }

        #endregion CreateRandomNumbersCollection

        #region CreateStartTimeCollection

        /// <summary>
        /// start time collection
        /// </summary>
        //// creating StartTime collection
        private void CreateStartTimeCollection()
        {
            this.startTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;

            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count], 0, 0);
                DateTime startDateTime = startTime.AddDays(i);
                this.startTimeCollection.Add(startDateTime);
                count++;
            }
        }

        #endregion CreateStartTimeCollection

        #region CreateEndTimeCollection

        /// <summary>
        /// end time collection
        /// </summary>
        ////  creating EndTime collection
        private void CreateEndTimeCollection()
        {
            this.endTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;
            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count] + 1, 0, 0);
                DateTime endDateTime = endTime.AddDays(i);
                if (i == -3 || i == 3)
                {
                    endDateTime = endTime.AddDays(i).AddHours(22);
                }

                this.endTimeCollection.Add(endDateTime);
                count++;
            }
        }

        #endregion CreateEndTimeCollection

        #endregion Methods

        #region Language String

        /// <summary>
        /// french appointment collection
        /// </summary>
        private void AddFrenchLanguageString()
        {
            this.frenchCollection = new List<string>();
            this.frenchCollection.Add("aller ‡ la rÈunion");
            this.frenchCollection.Add("Un rendez-vous d'affaire");
            this.frenchCollection.Add("ConfÈrence");
            this.frenchCollection.Add("Discussion Projet de Statut");
            this.frenchCollection.Add("audit");
            this.frenchCollection.Add("RÈunion du client");
            this.frenchCollection.Add("gÈnÈrer un rapport");
            this.frenchCollection.Add("RÈunion cible");
            this.frenchCollection.Add("AssemblÈe gÈnÈrale");
            this.frenchCollection.Add("Pay Maison Louer");
            this.frenchCollection.Add("Service automobile");
        }

        #endregion
        #region Appointments collection

        /// <summary>
        /// Gets the french appointments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetFrenchAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Meeting scheduleAppointment = new Meeting();
                scheduleAppointment.Color = this.colorCollection[i];
                scheduleAppointment.EventName = this.frenchCollection[i];
                scheduleAppointment.From = this.startTimeCollection[i];
                scheduleAppointment.To = this.endTimeCollection[i];
                this.Appointments.Add(scheduleAppointment);
            }

            // AllDay Appointment in current day
            Meeting allDayAppointment = new Meeting();
            allDayAppointment.Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073"));
            allDayAppointment.EventName = "L'anniversaire de Jeni";
            allDayAppointment.From = this.startTimeCollection[5];
            allDayAppointment.To = this.endTimeCollection[5];
            allDayAppointment.IsAllDay = true;
            this.Appointments.Add(allDayAppointment);
        }
        #endregion Appointments collection

    }
}