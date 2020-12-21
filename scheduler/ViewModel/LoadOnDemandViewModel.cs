#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Load on demand view model.
    /// </summary>
    public class LoadOnDemandViewModel : NotificationObject
    {
        #region Fields

        /// <summary>
        /// Gets or Sets event collection.
        /// </summary>
        private IEnumerable events;

        /// <summary>
        /// Gets or sets a value indicating whether to show the busy indicator.
        /// </summary>
        private bool showBusyIndicator;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets load on demand command.
        /// </summary>
        public ICommand LoadOnDemandCommand { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> SchedulerViewTypes { get; set; }

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public IEnumerable Events
        {
            get { return events; }
            set
            {
                events = value;
                this.RaisePropertyChanged("Events");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the busy indicator.
        /// </summary>
        public bool ShowBusyIndicator
        {
            get { return showBusyIndicator; }
            set
            {
                showBusyIndicator = value;
                this.RaisePropertyChanged("ShowBusyIndicator");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadOnDemandViewModel" /> class.
        /// </summary>
        public LoadOnDemandViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                this.LoadOnDemandCommand = new DelegateCommand(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
            }

            this.SchedulerViewTypes = SchedulerViewTypeHelper.GetSchedulerViewTypes();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to excute load on demand command and set scheduler appointments.
        /// </summary>
        /// <param name="parameter">QueryAppointmentsEventArgs object.</param>
        public async void ExecuteOnDemandLoading(object parameter)
        {
            if (parameter == null)
            {
                return;
            }

            this.ShowBusyIndicator = true;
            await Task.Delay(500);
            await Application.Current.MainWindow.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                this.Events = this.GenerateSchedulerAppointments((parameter as QueryAppointmentsEventArgs).VisibleDateRange);
            }));
            this.ShowBusyIndicator = false;
        }

        /// <summary>
        /// Method to check whether the load on demand command can be invoked or not.
        /// </summary>
        /// <param name="sender">QueryAppointmentsEventArgs object.</param>
        private bool CanExecuteOnDemandLoading(object sender)
        {
            return true;
        }

        /// <summary>
        /// Method to generate scheduler appointments based on current visible date range.
        /// </summary>
        /// <param name="dateRange">Current visible date range.</param>
        private IEnumerable GenerateSchedulerAppointments(DateRange dateRange)
        {
            var brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0x96, 0x09)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));

            var subjectCollection = new ObservableCollection<string>();
            subjectCollection.Add("Business Meeting");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Medical check up");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Project Status Discussion");
            subjectCollection.Add("Client Meeting");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Yoga Therapy");
            subjectCollection.Add("GoToMeeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");

            Random ran = new Random();
            int daysCount = (dateRange.ActualEndDate - dateRange.ActualStartDate).Days;
            var appointments = new ObservableCollection<SchedulerModel>();
            for (int i = 0; i < 50; i++)
            {
                var startTime = dateRange.ActualStartDate.AddDays(ran.Next(0, daysCount + 1)).AddHours(ran.Next(0, 24));
                appointments.Add(new SchedulerModel
                {
                    From = startTime,
                    To = startTime.AddHours(1),
                    EventName = subjectCollection[ran.Next(0,subjectCollection.Count)],
                    Color = brush[ran.Next(0, brush.Count)],
                });
            }

            return appointments;
        }

        #endregion
    }
}
