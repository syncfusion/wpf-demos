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

namespace ReminderAlert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    #region MainWindow Class

    public partial class MainWindow : ChromelessWindow
    {
        #region Private Properties

        private ObservableCollection<DateTime> datecoll = new ObservableCollection<DateTime>();
        private ObservableCollection<string> SubjectColl = new ObservableCollection<string>() 
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Holiday", 
                                                             "Wedding Anniversary", "Auditing", "Go to party", "Client Meeting", 
                                                             "Vacation", "Medical check up", "Salary", "Pay House Rent" };
        #endregion

        #region Constructor

        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        void AddAppointments_Click(object sender, RoutedEventArgs e)
        {
            Schedule.Appointments.Clear();
            ScheduleAppointmentCollection AppCollection = new ScheduleAppointmentCollection();
            DateTime currectDate = DateTime.Now;

            AppCollection.Add(new ScheduleAppointment
            {
                StartTime = currectDate.Date.AddHours(3),
                EndTime = currectDate.Date.AddHours(6),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0x8E, 0xC4, 0x41)),
                Subject = "Business Meeting",
                ReminderTime = ReminderTimeType.FiveMin
            });

            AppCollection.Add(new ScheduleAppointment
            {
                StartTime = currectDate.Date.AddDays(1),
                EndTime = currectDate.Date.AddDays(1).AddHours(4),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0x8D, 0xEA, 0xFF)),
                Subject = "Auditing",
                ReminderTime = ReminderTimeType.OneDay
            });

            AppCollection.Add(new ScheduleAppointment
            {
                StartTime = currectDate.Date.AddDays(7),
                EndTime = currectDate.Date.AddDays(7).AddHours(3),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0xF7, 0x94, 0xD7)),
                Subject = "Conference",
                ReminderTime = ReminderTimeType.TwoWeeks
            });

            Schedule.Appointments = AppCollection;
        }

        #endregion
    }

    #endregion
}
