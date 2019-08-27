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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Localization
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
        private ObservableCollection<DateTime> WorkWeekDays = new ObservableCollection<DateTime>();
        private ObservableCollection<string> SubjectColl = new ObservableCollection<string>() 
                                                           { "Aller à l'Assemblée", "Réunion d'affaires", "conférence", "fête", 
                                                              "audit", "Allez faire la fête", "Réunion du client", 
                                                             "vacances", "Visite médicale", "salaire", "Payer Maison Louer" };

        #endregion

        #region Constructor

        public MainWindow()
        {
            this.InitializeComponent();

            CultureInfo culture = new CultureInfo("fr-FR");
#if !SyncfusionFramework4
            CultureInfo.DefaultThreadCurrentCulture = culture;
#endif
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
     
            Random ran = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
               today= today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
               today= today.AddMonths(1);
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

            ScheduleAppointmentCollection AppCollection = new ScheduleAppointmentCollection();
            for (int i = 0; i < 90; i++)
            {
                if (i % 7 == 0 || i % 7 == 6)
                {
                    //add weekend appointments
                    //NonWorkingDays.Add(CurrentStart.AddDays(i));
                }
                else
                {
                    //Add Workweek appointment
                    WorkWeekDays.Add(CurrentStart.AddDays(i));
                }
            }


            for (int i = 0; i < 40; i++)
            {
                DateTime date = WorkWeekDays[ran.Next(0, WorkWeekDays.Count)].AddHours(ran.Next(9, 17));
                AppCollection.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[i % brush.Count],
                    Subject = SubjectColl[i % SubjectColl.Count]
                });
            }
            schedule.Appointments = AppCollection;
        }

        #endregion
    }

    #endregion
}




