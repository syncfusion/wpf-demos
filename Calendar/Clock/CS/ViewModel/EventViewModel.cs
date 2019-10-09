#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace ClockDemo
{
    class EventViewModel : NotificationObject
    {
        private ICommand dateTimeChangedCommand;
        public ICommand
           DateTimeChangedCommand
        {
            get
            {
                return dateTimeChangedCommand;
            }
            set
            {
                dateTimeChangedCommand = value;
            }
        }
        private DateTime selecteddate=DateTime.Now;
        public DateTime SelectedDate
        {
            get
            {
                return selecteddate;
            }
            set
            {
                selecteddate = value;
                RaisePropertyChanged("SelectedDate");
            }
        }

        public void DateTimeChanged(object param)
        {
            coll.Add("DateTime Changed: " + SelectedDate.ToString());
            EventLogs=coll;
        }
        private ObservableCollection<string> eventLogs;

        public ObservableCollection<string> EventLogs
        {
            get { return eventLogs; }
            set
            {
                eventLogs = value;
                this.RaisePropertyChanged(() => this.EventLogs);
            }
        }

        public EventViewModel()
        {
            DateTimeChangedCommand = new DelegateCommand<object>(DateTimeChanged);
        }
        ObservableCollection<string> coll = new ObservableCollection<string>();
    }
}
