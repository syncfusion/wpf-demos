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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SpecialTimeRegionCustomization
{
    /// <summary>
    /// Special time region customization view model class.
    /// </summary>
    public class SchedulerViewModel : NotificationObject
    {
        #region Properties
        /// <summary>
        /// event name collection.
        /// </summary>
        private List<string> eventCollection;

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

            for (int i = 0; i < 100; i++)
            {
                var day = random.Next(-50, 50);
                var hour = random.Next(9, 18);
                if (hour == 13) hour = 10;
                var newEvent = new Events();
                newEvent.EventName = this.eventCollection[random.Next(0, 9)];
                newEvent.From = DateTime.Now.Date.AddDays(day).AddHours(hour);
                newEvent.To = newEvent.From.AddHours(1);
                newEvent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(this.colorCollection[random.Next(0, 15)]));
                this.Appointments.Add(newEvent);
            }
        }

        /// <summary>
        /// Initializing data for appointments
        /// </summary>
        private void InitializingDataForEvents()
        {
            this.eventCollection = new List<string>();
            this.eventCollection.Add("Conference");
            this.eventCollection.Add("Checkup");
            this.eventCollection.Add("General Meeting");
            this.eventCollection.Add("Consulting");
            this.eventCollection.Add("Yoga Therapy");
            this.eventCollection.Add("Plan Execution");
            this.eventCollection.Add("Project Plan");
            this.eventCollection.Add("Consulting");
            this.eventCollection.Add("Performance Check");

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
