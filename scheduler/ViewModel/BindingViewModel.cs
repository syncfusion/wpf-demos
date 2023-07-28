#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Schedule View Model
    /// </summary>
    public class BindingViewModel : NotificationObject
    {
        #region Fields

        /// <summary>
        /// team management
        /// </summary>
        private List<string> teamManagement;

        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// Notes Collection.
        /// </summary>
        private List<string> notesCollection;

        /// <summary>
        /// Notes Collection.
        /// </summary>
        private List<string> noteCollection;
        /// <summary>
        /// minimum time meetings
        /// </summary>
        private List<string> minTimeMeetings;
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

        /// <summary>
        /// resource collection.
        /// </summary>
        private ObservableCollection<object> resources;

        /// <summary>
        /// Name collection for meeting.
        /// </summary>
        private List<string> nameCollection;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public BindingViewModel()
        {
            this.Appointments = new ObservableCollection<SchedulerModel>();
            this.MonthCellAppointments = new ObservableCollection<SchedulerModel>();
            this.ListAppointmentCollection = new ObservableCollection<SchedulerModel>();
            this.SchedulerAppointmentCollection = new ObservableCollection<SchedulerModel>();
            this.CreateListViewItems();
            this.CreateSchedulerAppointments();
            this.CreateRandomNumbersCollection();
            this.CreateStartTimeCollection();
            this.CreateEndTimeCollection();
            this.CreateSubjectCollection();
            this.CreateColorCollection();
            this.InitializeDataForBookings();
            this.IntializeAppoitments();
            this.CreateRecurrsiveExceptionAppointments();
            this.CreateRecurrsiveAppointments();
            this.InitializeResources();
            this.BookingResourceAppointments();
            this.CreateMonthCellAppointments();
            this.CreateSpecialTimeRegionAppointments();
            this.InitializeSchedulerViewTypes();
            DisplayDate = DateTime.Now.Date.AddHours(9);
            MinDate = DateTime.Now.Date;
            MaxDate = DateTime.Now.Date.AddMonths(6);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets appointments
        /// </summary>
        public ObservableCollection<SchedulerModel> Appointments { get; set; }

        /// <summary>
        /// Gets or sets appointments for fare calendar
        /// </summary>
        public ObservableCollection<SchedulerModel> MonthCellAppointments { get; set; }

        /// <summary>
        /// list appointment collection
        /// </summary>
        public ObservableCollection<SchedulerModel> ListAppointmentCollection { get; set; }

        /// <summary>
        /// Scheduler appointment collection.
        /// </summary>
        public ObservableCollection<SchedulerModel> SchedulerAppointmentCollection { get; set; }

        /// <summary>
        /// Gets or sets recursive appointments.
        /// </summary>
        public ObservableCollection<SchedulerModel> RecursiveAppointmentCollection { get; set; }

        /// <summary>
        /// Gets or sets recursive exception appointments.
        /// </summary>
        public ObservableCollection<SchedulerModel> RecursiveExceptionAppointmentCollection { get; set; }

        /// <summary>
        /// Gets or sets resource appointments.
        /// </summary>
        public ObservableCollection<SchedulerModel> ResourceAppointments { get; set; }

        /// <summary>
        /// Gets or sets appointments for special time region sample.
        /// </summary>
        public ObservableCollection<SchedulerModel> SpecialTimeRegionAppointments { get; set; }

        /// <summary>
        /// Gets or sets resource collection.
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
                this.RaisePropertyChanged("Resources");
            }
        }

        /// <summary>
        /// Gets or sets display date
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler minimum  date
        /// </summary>
        public DateTime MinDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler maximum date
        /// </summary>
        public DateTime MaxDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> SchedulerViewTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection for Appointment customizaton sample.
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> AppointmentCustomizationViewTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection for resource view sample.
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> ResourceSchedulerViewTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection for time slot customization sample.
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> TimeSlotCustomizationViewTypes { get; set; }

        #endregion

        #region Methods

        #region creating RecurrsiveAppointments

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveExceptionAppointments()
        {
            this.RecursiveExceptionAppointmentCollection = new ObservableCollection<SchedulerModel>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            SchedulerModel dailyEvent = new SchedulerModel
            {
                EventName = "Daily scrum meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                Color = new SolidColorBrush((Color.FromRgb(191, 235, 97))),
                ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=50",
                Id = 1
            };

            RecursiveExceptionAppointmentCollection.Add(dailyEvent);

            //Add ExceptionDates to avoid occurrence on specific dates.
            DateTime changedExceptionDate1 = DateTime.Now.AddDays(-1).Date;
            DateTime changedExceptionDate2 = DateTime.Now.Date.AddDays(4).Date;
            DateTime deletedExceptionDate1 = DateTime.Now.Date.AddDays(2);
            DateTime deletedExceptionDate2 = DateTime.Now.Date.AddDays(6);
            DateTime deletedExceptionDate3 = DateTime.Now.Date.AddDays(8);

            dailyEvent.RecurrenceExceptions = new ObservableCollection<DateTime>()
            {
                changedExceptionDate1,
                changedExceptionDate2,
                deletedExceptionDate1,
                deletedExceptionDate2,
            };

            //Change start time or end time of an occurrence.
            SchedulerModel changedEvent = new SchedulerModel
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 13, 0, 0),
                Color = new SolidColorBrush((Color.FromRgb(45, 216, 175))),
                ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                Id = 2,
                RecurrenceId = 1
            };
            RecursiveExceptionAppointmentCollection.Add(changedEvent);

            SchedulerModel changedEvent1 = new SchedulerModel
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 13, 0, 0),
                Color = new SolidColorBrush((Color.FromRgb(83, 99, 250))),
                ForegroundColor = new SolidColorBrush((Color.FromRgb(255, 255, 255))),

                Id = 3,
                RecurrenceId = 1
            };
            RecursiveExceptionAppointmentCollection.Add(changedEvent1);
        }

        #endregion creating RecurrsiveAppointments

        #region creating RecurrsiveAppointments

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveAppointments()
        {
            this.RecursiveAppointmentCollection = new ObservableCollection<SchedulerModel>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            SchedulerModel dailyEvent = new SchedulerModel
            {
                EventName = "Daily recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                Color = new SolidColorBrush((Color.FromRgb(191, 235, 97))),
                ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            SchedulerModel weeklyEvent = new SchedulerModel
            {
                EventName = "Weekly recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                Color = new SolidColorBrush((Color.FromRgb(45, 216, 175))),
                ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(weeklyEvent);

            SchedulerModel monthlyEvent = new SchedulerModel
            {
                EventName = "Monthly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                Color = Brushes.Red,
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(monthlyEvent);

            SchedulerModel yearlyEvent = new SchedulerModel
            {
                EventName = "Yearly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 2, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 3, 0, 0),
                Color = Brushes.Yellow,
                RecurrenceRule = "FREQ=YEARLY;BYMONTHDAY=3;BYMONTH=5;INTERVAL=1;COUNT=50",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(yearlyEvent);
        }

        #endregion creating RecurrsiveAppointments

        #region Create month cell customization appointment
        /// <summary>
        /// Method to create appointments for fare calender
        /// </summary>
        private void CreateMonthCellAppointments()
        {
             List<string> Fares = new List<string>()
             {   "$134.50", "$305.00", "$152.66", "$267.09", "$189.20", "$212.10", "$238.83",
                 "$100.17", "$101.72", "$332.48" ,"$100.17", "$449.68", "$378.44", "$273.45",
                 "$134.50", "$305.00", "$152.66", "$267.09", "$189.20", "$212.10", "$238.83",
            };

            List<string> FlightNames = new List<string>() { "Airways 1", "Airways 2", "Airways 3" };
            Random random = new Random();

            var startDate = DateTime.Now.AddMonths(-1).Date.AddHours(9);
            for(int i=0; i < 300; i++)
            {
                this.MonthCellAppointments.Add(new SchedulerModel()
                {
                    EventName = FlightNames[random.Next(0,3)],
                    Notes = Fares[random.Next(0,20)],
                    From = startDate.AddDays(i),
                    To=startDate.AddDays(i).AddHours(1)
                });
            }
        }
        #endregion

        private void InitializeResources()
        {
            Random random = new Random();
            this.Resources = new ObservableCollection<object>();
            this.nameCollection = new List<string>();
            this.nameCollection.Add("Sophia");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Adeline Ruby");
            this.nameCollection.Add("Kinsley Ruby");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Adeline Elena");
            this.nameCollection.Add("Emilia William");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Danial William");
            this.nameCollection.Add("Stephen Addison");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Danial Addison");
            this.nameCollection.Add("Brooklyn");
            for (int i = 0; i < 7; i++)
            {
                Employee employee = new Employee();
                employee.Name = nameCollection[i];
                employee.BackgroundBrush = this.colorCollection[random.Next(9)];
                employee.ID = i.ToString();
                employee.ImageSource = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle" + i.ToString() + ".png";
                Resources.Add(employee);
            }
        }

        #region BookingAppointments

        /// <summary>
        /// Method to get foreground color based on background.
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        private Brush GetAppointmentForeground(Brush backgroundColor)
        {
            if (backgroundColor.ToString().Equals("#FF8551F2") || backgroundColor.ToString().Equals("#FF5363FA") || backgroundColor.ToString().Equals("#FF2D99FF"))
                return Brushes.White;
            else
                return new SolidColorBrush(Color.FromRgb(51, 51, 51));
        }

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        private void BookingResourceAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();
            ResourceAppointments = new ObservableCollection<SchedulerModel>();
            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
                    {
                        SchedulerModel meeting = new SchedulerModel();
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                        meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;

                        var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employee).ID
                            };
                        meeting.Resources = coll;

                        this.ResourceAppointments.Add(meeting);
                    }

                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
                    {
                        SchedulerModel meeting = new SchedulerModel();
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(7, 12), 0, 0);
                        meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;

                        var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employee).ID
                            };
                        meeting.Resources = coll;

                        this.ResourceAppointments.Add(meeting);
                    }
                }
                else
                {
                    SchedulerModel meeting = new SchedulerModel();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                    meeting.IsAllDay = true;
                    var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employee).ID
                            };
                    meeting.Resources = coll;
                    this.ResourceAppointments.Add(meeting);
                }

            }

            for (int i = 0; i < 3; i++)
            {
                SchedulerModel meeting1 = new SchedulerModel();
                meeting1.From = DateTime.Now.Date.AddHours(10);
                meeting1.To = meeting1.From.AddHours(randomTime.Next(1, 3));
                meeting1.EventName = this.currentDayMeetings[randomTime.Next(0, 10)];
                meeting1.Color = this.colorCollection[randomTime.Next(0, 9)];
                meeting1.ForegroundColor = GetAppointmentForeground(meeting1.Color);
                meeting1.IsAllDay = false;

                var resourceCollection = new ObservableCollection<object>
                {
                    "1"
                };

                meeting1.Resources = resourceCollection;
                this.ResourceAppointments.Add(meeting1);
            }
        }

        #endregion BookingAppointments

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

        #region InitializeDataForBookings

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");

            // MinimumHeight Appointment Subjects
            this.minTimeMeetings = new List<string>();
            this.minTimeMeetings.Add("Work log alert");
            this.minTimeMeetings.Add("Birthday wish alert");
            this.minTimeMeetings.Add("Task due date");
            this.minTimeMeetings.Add("Status mail");
            this.minTimeMeetings.Add("Start sprint alert");

            this.notesCollection = new List<string>();
            this.notesCollection.Add("Consulting firm laws with business advisers");
            this.notesCollection.Add("Execute Project Scope");
            this.notesCollection.Add("Project Scope & Deliverables");
            this.notesCollection.Add("Executive summary");
            this.notesCollection.Add("Try to reduce the risks");
            this.notesCollection.Add("Encourages the integration of mind, body, and spirit");
            this.notesCollection.Add("Execute Project Scope");
            this.notesCollection.Add("Project Scope & Deliverables");
            this.notesCollection.Add("Executive summary");
            this.notesCollection.Add("Try to reduce the risk");

            this.noteCollection = new List<string>();
            this.noteCollection.Add("To show the status of multiple underlying simple alerts with one overall status.");
            this.noteCollection.Add("25th Celebration");
            this.noteCollection.Add("Date by which member should complete a task");
            this.noteCollection.Add("Helps you to establish reports for company, team, and individual usage");
            this.noteCollection.Add("Receive a warning regarding scope");
        }

        #endregion InitializeDataForBookings

        #region InitializeAppointments
        /// <summary>
        /// Initialize appointments
        /// </summary>
        /// <param name="count">count value</param>
        private void IntializeAppoitments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-100);
            DateTime dateTo = DateTime.Now.AddDays(100);
            var random = new Random();
            var dateCount = random.Next(4);
            DateTime dateRangeStart = DateTime.Now.AddDays(0);
            DateTime dateRangeEnd = DateTime.Now.AddDays(1);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if (date.Day % 7 != 0)
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 1; additionalAppointmentIndex++)
                    {
                        SchedulerModel meeting = new SchedulerModel();
                        int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;
                        meeting.Notes = this.notesCollection[randomTime.Next(9)];
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;
                        this.Appointments.Add(meeting);
                    }
                }
                else
                {
                    SchedulerModel meeting = new SchedulerModel();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                    meeting.IsAllDay = true;
                    meeting.Notes = this.notesCollection[randomTime.Next(9)];
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    this.Appointments.Add(meeting);
                }
            }

            // Minimum Height Meetings
            DateTime minDate;
            DateTime minDateFrom = DateTime.Now.AddDays(-2);
            DateTime minDateTo = DateTime.Now.AddDays(2);

            for (minDate = minDateFrom; minDate < minDateTo; minDate = minDate.AddDays(1))
            {
                SchedulerModel meeting = new SchedulerModel();
                meeting.From = new DateTime(minDate.Year, minDate.Month, minDate.Day, randomTime.Next(9, 18), 30, 0);
                meeting.To = meeting.From;
                meeting.EventName = this.minTimeMeetings[randomTime.Next(0, 4)];
                meeting.Color = this.colorCollection[randomTime.Next(9)];
                meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                meeting.Notes = this.noteCollection[randomTime.Next(0, 4)];
                meeting.StartTimeZone = string.Empty;
                meeting.EndTimeZone = string.Empty;

                this.Appointments.Add(meeting);
            }
        }

        #endregion InitializeAppointments

        #region SubjectCollection

        /// <summary>
        /// Subject collection
        /// </summary>
        ////creating subject collection
        private void CreateSubjectCollection()
        {
            this.teamManagement = new List<string>();
            this.teamManagement.Add("General Meeting");
            this.teamManagement.Add("Plan Execution");
            this.teamManagement.Add("Project Plan");
            this.teamManagement.Add("Consulting");
            this.teamManagement.Add("Performance Check");
            this.teamManagement.Add("General Meeting");
            this.teamManagement.Add("Plan Execution");
            this.teamManagement.Add("Project Plan");
            this.teamManagement.Add("Consulting");
            this.teamManagement.Add("Performance Check");
        }

        #endregion SubjectCollection

        #region creating color collection

        /// <summary>
        /// color collection
        /// </summary>
        ////creating color collection
        private void CreateColorCollection()
        {
            this.colorCollection = new List<Brush>();
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(133, 81, 242)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(140, 245, 219)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(83, 99, 250)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(255, 222, 133)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(45, 153, 255)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(253, 183, 165)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(198, 237, 115)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(253, 185, 222)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromRgb(83, 99, 250)));
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

        #region SpecialTimeRegion appointments

        /// <summary>
        /// Method to create appointments for special time region sample.
        /// </summary>
        private void CreateSpecialTimeRegionAppointments()
        {
            Random randomTime = new Random();
            List<int> randomTimeCollection = new List<int>() { 9, 11, 12, 14, 15, 16, 17, 18 };
            this.SpecialTimeRegionAppointments = new ObservableCollection<SchedulerModel>();
            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-100);
            DateTime dateTo = DateTime.Now.AddDays(100);
            var random = new Random();
            var dateCount = random.Next(4);
            DateTime dateRangeStart = DateTime.Now.AddDays(0);
            DateTime dateRangeEnd = DateTime.Now.AddDays(1);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if (date.Day % 7 != 0)
                {
                    // Normal meetings.
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 1; additionalAppointmentIndex++)
                    {
                        SchedulerModel meeting = new SchedulerModel();
                        int hour = randomTimeCollection[randomTime.Next(0, 7)];
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;
                        meeting.Notes = this.notesCollection[randomTime.Next(9)];
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;
                        this.SpecialTimeRegionAppointments.Add(meeting);
                    }
                }
                else
                {
                    // All day meetings.
                    SchedulerModel meeting = new SchedulerModel();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(14, 17), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                    meeting.IsAllDay = true;
                    meeting.Notes = this.notesCollection[randomTime.Next(9)];
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    this.SpecialTimeRegionAppointments.Add(meeting);
                }
            }

            // Minimum Height Meetings.
            DateTime minDate;
            DateTime minDateFrom = DateTime.Now.AddDays(-2);
            DateTime minDateTo = DateTime.Now.AddDays(2);

            for (minDate = minDateFrom; minDate < minDateTo; minDate = minDate.AddDays(1))
            {
                SchedulerModel meeting = new SchedulerModel();
                meeting.From = new DateTime(minDate.Year, minDate.Month, minDate.Day, randomTimeCollection[randomTime.Next(0, 7)], 30, 0);
                meeting.To = meeting.From;
                meeting.EventName = this.minTimeMeetings[randomTime.Next(0, 4)];
                meeting.Color = this.colorCollection[randomTime.Next(9)];
                meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                meeting.Notes = this.noteCollection[randomTime.Next(0, 4)];
                meeting.StartTimeZone = string.Empty;
                meeting.EndTimeZone = string.Empty;

                this.SpecialTimeRegionAppointments.Add(meeting);
            }
        }

        #endregion

        #region CreateListAppointmentCollection

        /// <summary>
        /// list appointment collection
        /// </summary>
        ////  creating ListAppointment collection
        private void CreateListViewItems()
        {
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddHours(2), To = DateTime.Now.Date.AddHours(4), Color = new SolidColorBrush(Color.FromRgb(83, 99, 250)), ForegroundColor = Brushes.White, EventName = "Business Meeting", Notes = "Consulting firm laws with business advisers" });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(1).AddHours(6), To = DateTime.Now.Date.AddDays(1).AddHours(8), Color = new SolidColorBrush(Color.FromRgb(133, 81, 242)), ForegroundColor = Brushes.White, EventName = "Conference", Notes = "Attend 2nd international conference about WinRT Development" });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(140, 245, 219)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "Medical check up", Notes = "Brooklyn medical university. Dental checkup" });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(83, 99, 250)), ForegroundColor = Brushes.White, EventName = "Performance Check", Notes = "Search for and enter performance notes." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(45, 153, 255)), ForegroundColor = Brushes.White, EventName = "Consulting", Notes = "Executive summary." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(255, 222, 133)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "Project Status Discussion", Notes = "provides an opportunity to share information across the whole team." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(253, 183, 165)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "Client Meeting", Notes = "Way to understand their needs and how you can help support them." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(198, 237, 115)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "General Meeting", Notes = "Meeting of all the shareholders of a company." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(133, 81, 242)), ForegroundColor = Brushes.White, EventName = "Yoga Therapy", Notes = "Encourages the integration of mind, body, and spirit." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush(Color.FromRgb(253, 185, 222)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "GoToMeeting", Notes = "User to meet with other users, customers, clients or colleagues." });
        }
        #endregion CreateListAppointmentCollection

        #region CreateSchedulerAppointmentCollection

        /// <summary>
        /// Scheduler appointment collection
        /// </summary>
        ////  creating SchedulerAppointment collection
        private void CreateSchedulerAppointments()
        {
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddHours(10), To = DateTime.Now.Date.AddHours(11), Color = new SolidColorBrush(Color.FromRgb(83, 99, 250)), ForegroundColor = Brushes.White, EventName = "Business Meeting", Notes = "Consulting firm laws with business advisers" });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(1).AddHours(11), To = DateTime.Now.Date.AddDays(1).AddHours(12), Color = new SolidColorBrush(Color.FromRgb(133, 81, 242)), ForegroundColor = Brushes.White, EventName = "Conference", Notes = "Attend 2nd international conference about WinRT Development" });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(12), To = DateTime.Now.Date.AddDays(-2).AddHours(13), Color = new SolidColorBrush(Color.FromRgb(140, 245, 219)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "Medical check up", Notes = "Brooklyn medical university. Dental checkup" });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(3).AddHours(13), To = DateTime.Now.Date.AddDays(3).AddHours(14), Color = new SolidColorBrush(Color.FromRgb(83, 99, 250)), ForegroundColor = Brushes.White, EventName = "Performance Check", Notes = "Search for and enter performance notes." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-3).AddHours(14), To = DateTime.Now.Date.AddDays(-3).AddHours(15), Color = new SolidColorBrush(Color.FromRgb(45, 153, 255)), ForegroundColor = Brushes.White, EventName = "Consulting", Notes = "Executive summary." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(4).AddHours(15), To = DateTime.Now.Date.AddDays(4).AddHours(16), Color = new SolidColorBrush(Color.FromRgb(255, 222, 133)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "Project Status Discussion", Notes = "provides an opportunity to share information across the whole team." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(2).AddHours(14), To = DateTime.Now.Date.AddDays(2).AddHours(15), Color = new SolidColorBrush(Color.FromRgb(253, 183, 165)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "Client Meeting", Notes = "Way to understand their needs and how you can help support them." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-1).AddHours(12), To = DateTime.Now.Date.AddDays(-1).AddHours(13), Color = new SolidColorBrush(Color.FromRgb(198, 237, 115)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "General Meeting", Notes = "Meeting of all the shareholders of a company." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-5).AddHours(18), To = DateTime.Now.Date.AddDays(-5).AddHours(19), Color = new SolidColorBrush(Color.FromRgb(133, 81, 242)), ForegroundColor = Brushes.White, EventName = "Yoga Therapy", Notes = "Encourages the integration of mind, body, and spirit." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(6).AddHours(14), To = DateTime.Now.Date.AddDays(6).AddHours(15), Color = new SolidColorBrush(Color.FromRgb(253, 185, 222)), ForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51)), EventName = "GoToMeeting", Notes = "User to meet with other users, customers, clients or colleagues." });
        }
        #endregion CreateSchedulerAppointmentCollection

        #region Initialize scheduler ViewTypes.

        /// <summary>
        /// Method to initialize scheduler view type collection.
        /// </summary>
        private void InitializeSchedulerViewTypes()
        {
            this.SchedulerViewTypes = SchedulerViewTypeHelper.GetSchedulerViewTypes();
            this.ResourceSchedulerViewTypes = SchedulerViewTypeHelper.GetResourceSchedulerViewTypes();
        }

        #endregion

        #endregion Methods
    }
}
