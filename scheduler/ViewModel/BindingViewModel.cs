#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        #region Properties

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
        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public BindingViewModel()
        {
            this.Appointments = new ObservableCollection<SchedulerModel>();
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
            this.CustomizationAppointments();
            this.CreateRecurrsiveExceptionAppointments();
            this.CreateRecurrsiveAppointments();
            this.InitializeResources();
            this.BookingResourceAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        #endregion Constructor

        /// <summary>
        /// Gets or sets appointments
        /// </summary>
        public ObservableCollection<SchedulerModel> Appointments
        {
            get;
            set;
        }

        /// <summary>
        /// list appointment collection
        /// </summary>
        public ObservableCollection<SchedulerModel> ListAppointmentCollection
        {
            get;
            set;
        }

        /// <summary>
        /// Scheduler appointment collection
        /// </summary>
        public ObservableCollection<SchedulerModel> SchedulerAppointmentCollection
        {
            get;
            set;
        }

        private List<string> eventCollection;
        private ObservableCollection<object> resources;
        private List<string> nameCollection;

        public ObservableCollection<SchedulerModel> CustomizeAppointments { get; set; }
         
        public ObservableCollection<SchedulerModel> RecursiveAppointmentCollection { get; set; }

        public ObservableCollection<SchedulerModel> RecursiveExceptionAppointmentCollection { get; set; }

        public ObservableCollection<SchedulerModel> ResourceAppointments { get; set; }

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

        #region Methods

        #region create customization appointments
        private void CustomizationAppointments()
        {
            CustomizeAppointments = new ObservableCollection<SchedulerModel>();
            var random = new Random();
            this.eventCollection = new List<string>();
            this.eventCollection.Add("Conference");
            this.eventCollection.Add("System Troubleshoot");
            this.eventCollection.Add("Birthday");
            this.eventCollection.Add("Checkup");
            this.eventCollection.Add("Conference");

            for (int i = 0; i < 50; i++)
            {
                var year = DateTime.Now.Date.Year;
                var month = DateTime.Now.Date.AddMonths(random.Next(-1, 2)).Month;
                var day = random.Next(1, 30);
                var hour = random.Next(9, 14);
                var newEvent = new SchedulerModel();
                newEvent.EventName = this.eventCollection[random.Next(0, 4)];
                newEvent.From = new DateTime(year, month, day, hour, 0, 0);
                newEvent.To = newEvent.From.AddHours(1);
                if (newEvent.EventName == "Conference")
                {
                    newEvent.Color = this.colorCollection[0];
                }
                else if (newEvent.EventName == "System Troubleshoot")
                {
                    newEvent.Color = this.colorCollection[1];
                }
                else if (newEvent.EventName == "Birthday")
                {
                    newEvent.Color = this.colorCollection[2];
                }
                else if (newEvent.EventName == "Checkup")
                {
                    newEvent.Color = this.colorCollection[3];
                }
                this.CustomizeAppointments.Add(newEvent);
            }
        }

        #endregion

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
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=50"
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
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                RecurrenceId = dailyEvent
            };
            RecursiveExceptionAppointmentCollection.Add(changedEvent);

            SchedulerModel changedEvent1 = new SchedulerModel
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 13, 0, 0),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                RecurrenceId = dailyEvent
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
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            SchedulerModel weeklyEvent = new SchedulerModel
            {
                EventName = "Weekly recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")),
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
                employee.BackgroundBrush = this.colorCollection[random.Next(8)];
                employee.ID = i.ToString();
                employee.ImageSource = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle" + i.ToString() + ".png";
                Resources.Add(employee);
            }
        }

        #region BookingAppointments

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
                        meeting.Color = this.colorCollection[randomTime.Next(8)];
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
                    meeting.Color = this.colorCollection[randomTime.Next(8)];
                    meeting.IsAllDay = true;
                    var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employee).ID
                            };
                    meeting.Resources = coll;
                    this.ResourceAppointments.Add(meeting);
                }

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


            this.colorCollection = new List<Brush>();
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
                meeting.Color = this.colorCollection[randomTime.Next(0, 10)];
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

        #region CreateListAppointmentCollection

        /// <summary>
        /// list appointment collection
        /// </summary>
        ////  creating ListAppointment collection
        private void  CreateListViewItems()
        {
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddHours(2), To = DateTime.Now.Date.AddHours(4), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")), EventName = "Business Meeting", Notes = "Consulting firm laws with business advisers" });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(1).AddHours(6), To = DateTime.Now.Date.AddDays(1).AddHours(8), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")), EventName = "Conference", Notes = "Attend 2nd international conference about WinRT Development" });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")), EventName = "Medical check up", Notes = "Brooklyn medical university. Dental checkup" });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")), EventName = "Performance Check", Notes = "Search for and enter performance notes." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")), EventName = "Consulting", Notes = "Executive summary." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")), EventName = "Project Status Discussion", Notes = "provides an opportunity to share information across the whole team." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF09609")), EventName = "Client Meeting", Notes = "Way to understand their needs and how you can help support them." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4F67FF")), EventName = "General Meeting", Notes = "Meeting of all the shareholders of a company." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")), EventName = "Yoga Therapy", Notes = "Encourages the integration of mind, body, and spirit." });
            ListAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(4), To = DateTime.Now.Date.AddDays(-2).AddHours(6), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")), EventName = "GoToMeeting", Notes = "User to meet with other users, customers, clients or colleagues." });
        }
        #endregion CreateListAppointmentCollection

        #region CreateSchedulerAppointmentCollection

        /// <summary>
        /// Scheduler appointment collection
        /// </summary>
        ////  creating SchedulerAppointment collection
        private void CreateSchedulerAppointments()
        {
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddHours(10), To = DateTime.Now.Date.AddHours(11), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")), EventName = "Business Meeting", Notes = "Consulting firm laws with business advisers" });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(1).AddHours(11), To = DateTime.Now.Date.AddDays(1).AddHours(12), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")), EventName = "Conference", Notes = "Attend 2nd international conference about WinRT Development" });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-2).AddHours(12), To = DateTime.Now.Date.AddDays(-2).AddHours(13), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")), EventName = "Medical check up", Notes = "Brooklyn medical university. Dental checkup" });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(3).AddHours(13), To = DateTime.Now.Date.AddDays(3).AddHours(14), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")), EventName = "Performance Check", Notes = "Search for and enter performance notes." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-3).AddHours(14), To = DateTime.Now.Date.AddDays(-3).AddHours(15), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")), EventName = "Consulting", Notes = "Executive summary." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(4).AddHours(15), To = DateTime.Now.Date.AddDays(4).AddHours(16), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")), EventName = "Project Status Discussion", Notes = "provides an opportunity to share information across the whole team." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(2).AddHours(14), To = DateTime.Now.Date.AddDays(2).AddHours(15), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF09609")), EventName = "Client Meeting", Notes = "Way to understand their needs and how you can help support them." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-1).AddHours(12), To = DateTime.Now.Date.AddDays(-1).AddHours(13), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4F67FF")), EventName = "General Meeting", Notes = "Meeting of all the shareholders of a company." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(-5).AddHours(18), To = DateTime.Now.Date.AddDays(-5).AddHours(19), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")), EventName = "Yoga Therapy", Notes = "Encourages the integration of mind, body, and spirit." });
            SchedulerAppointmentCollection.Add(new SchedulerModel() { From = DateTime.Now.Date.AddDays(6).AddHours(14), To = DateTime.Now.Date.AddDays(6).AddHours(15), Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")), EventName = "GoToMeeting", Notes = "User to meet with other users, customers, clients or colleagues." });
        }
        #endregion CreateSchedulerAppointmentCollection
    }
}
