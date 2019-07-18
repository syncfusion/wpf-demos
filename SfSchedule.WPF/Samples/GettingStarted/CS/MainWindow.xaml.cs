#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GettingStarted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    #region MainWindow Class

    public partial class MainWindow : ChromelessWindow
    {
        #region Private Properties

        private ObservableCollection<DateTime> WorkWeekDays = new ObservableCollection<DateTime>();
        private ObservableCollection<string> WorkWeekSubjects = new ObservableCollection<string>() 
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

        private ObservableCollection<DateTime> NonWorkingDays = new ObservableCollection<DateTime>();
        private ObservableCollection<string> NonWorkingSubjects = new ObservableCollection<string>() 
                                                           { "Go to party", "Order Pizza", "Buy Gift",
                                                             "Vacation" };
        private ObservableCollection<DateTime> YearlyOccurrance = new ObservableCollection<DateTime>();
        private ObservableCollection<string> YearlyOccurranceSubjects = new ObservableCollection<string>() { "Wedding Anniversary", "Sam's Birthday", "Jenny's Birthday" };
        private ObservableCollection<DateTime> MonthlyOccurrance = new ObservableCollection<DateTime>();
        private ObservableCollection<string> MonthlyOccurranceSubjects = new ObservableCollection<string>() { "Pay House Rent", "Car Service", "Medical Check Up" };
        private ObservableCollection<DateTime> WeekEndOccurrance = new ObservableCollection<DateTime>();
        private ObservableCollection<string> WeekEndOccurranceSubjects = new ObservableCollection<string>() { "FootBall Match", "TV Show" };

        #endregion

        #region Constructor

        public MainWindow()
        {
            this.InitializeComponent();

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

            ScheduleAppointmentCollection AppointmentCollection = new ScheduleAppointmentCollection();
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
                AppointmentCollection.Add(new ScheduleAppointment()
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
                AppointmentCollection.Add(new ScheduleAppointment()
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
                AppointmentCollection.Add(new ScheduleAppointment()
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
                AppointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[l],
                    Subject = WeekEndOccurranceSubjects[l]
                });
                l++;
            }
            Schedule.Appointments = AppointmentCollection;
            Schedule.ScheduleTypeChanging += Schedule_ScheduleTypeChanging;
            SfSkinManager.SetVisualStyle(combo, Syncfusion.SfSkinManager.VisualStyles.Metro);
        }

        #endregion

        #region Events

        void Schedule_ScheduleTypeChanging(object sender, ScheduleTypeChangingEventArgs e)
        {
            if (Month.IsChecked == true && Schedule.ScheduleType == ScheduleType.Day)
            {
                Day.Focus();
                Day.IsChecked = true;
                Month.IsChecked = false;
            }
        }

        private void Btn_ScheduleType_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Name)
            {
                case "Day":
                    {
                        Schedule.ScheduleType = ScheduleType.Day;
                        break;
                    }
                case "Week":
                    {
                        Schedule.ScheduleType = ScheduleType.Week;
                        break;
                    }
                case "WorkWeek":
                    {
                        Schedule.ScheduleType = ScheduleType.WorkWeek;
                        break;
                    }
                case "Month":
                    {
                        Schedule.ScheduleType = ScheduleType.Month;
                        break;
                    }
                case "TimeLine":
                    {
                        Schedule.ScheduleType = ScheduleType.TimeLine;
                        break;
                    }
            }
        }

        private void ComboBoxAdv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItemAdv item;
            WindowCollection windows = Application.Current.Windows;
            if (windows.Count > 0)
            {
                Window samplewindow = windows[0];
                ComboBoxAdv combo = sender as ComboBoxAdv;
                if (combo != null)
                {
                    if (combo.SelectedItem != null)
                    {
                        item = combo.SelectedItem as ComboBoxItemAdv;
                        SfSkinManager.SetVisualStyle(Schedule, (VisualStyles)Enum.Parse(typeof(VisualStyles), item.Content.ToString()));
                    }

                }
            }
        }
        #endregion
    }

    #endregion
}

