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
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DateTimeEditDemo
{
    class ViewModel : NotificationObject
    {

        private ObservableCollection<string> eventLogsCollection;

        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }
        ObservableCollection<string> coll = new ObservableCollection<string>();

        private ICommand dateTimeChangedCommand;
        public ICommand DateTimeChangedCommand
        {
            get
            {
                if (dateTimeChangedCommand == null)
                {
                    dateTimeChangedCommand = new DelegateCommand<object>(dateTimeChanged);
                }
                return dateTimeChangedCommand;
            }


        }
        private ICommand isDropDownOpenChangedCommand;
        public ICommand IsDropDownOpenChangedCommand
        {
            get
            {
                if (isDropDownOpenChangedCommand == null)
                {
                    isDropDownOpenChangedCommand = new DelegateCommand<object>(DropDownOpenChanged);
                }
                return isDropDownOpenChangedCommand;
            }


        }

        private ICommand isClockPopupOpenedCommand;
        public ICommand IsClockPopupOpenedCommand
        {
            get
            {
                if (isClockPopupOpenedCommand == null)
                {
                    isClockPopupOpenedCommand = new DelegateCommand<object>(ClockPopupOpenChanged);
                }
                return isClockPopupOpenedCommand;
            }


        }

        private ICommand isCalendarPopupOpenedCommand;
        public ICommand IsCalendarPopupOpenedCommand
        {
            get
            {
                if (isCalendarPopupOpenedCommand == null)
                {
                    isCalendarPopupOpenedCommand = new DelegateCommand<object>(CalendarPopupOpenChanged);
                }
                return isCalendarPopupOpenedCommand;
            }


        }

        private ICommand minValueChangedCommand;
        public ICommand MinValueChangedCommand
        {
            get
            {
                if (minValueChangedCommand == null)
                {
                    minValueChangedCommand = new DelegateCommand<object>(MinValueChanged);
                }
                return minValueChangedCommand;
            }


        }

        private ICommand maxValueChangedCommand;
        public ICommand MaxValueChangedCommand
        {
            get
            {
                if (maxValueChangedCommand == null)
                {
                    maxValueChangedCommand = new DelegateCommand<object>(MaxValueChanged);
                }
                return maxValueChangedCommand;
            }

        }

        private ICommand patternChangedCommand;
        public ICommand PatternChangedCommand
        {
            get
            {
                if (patternChangedCommand == null)
                {
                    patternChangedCommand = new DelegateCommand<object>(PatternChanged);
                }
                return patternChangedCommand;
            }


        }

        private DateTime? _value = System.DateTime.Now;
        public DateTime? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => this.Value);
            }

        }


        private DateTime? minimumValue = new DateTime(1998, 4, 3);
        public DateTime? MinimumValue
        {
            get
            {
                return minimumValue;
            }
            set
            {
                minimumValue = value;
                RaisePropertyChanged(() => this.MinimumValue);
            }

        }

        private DateTime? maximumValue = new DateTime(DateTime.Now.AddYears(10).Year, 12, 31);
        public DateTime? MaximumValue
        {
            get
            {
                return maximumValue;
            }
            set
            {
                maximumValue = value;
                RaisePropertyChanged(() => this.MaximumValue);
            }

        }

        private DateTimePattern pattern = DateTimePattern.LongDate;
        public DateTimePattern Pattern
        {
            get
            {
                return pattern;
            }
            set
            {
                pattern = value;
                RaisePropertyChanged(() => this.Pattern);
            }

        }

        public void dateTimeChanged(object param)
        {
            if (Value != null)
            {
                AddLog("DateTime Changed: " + Value.ToString());
            }
            else
            {
                AddLog("DateTime Changed: NULL");
            }

        }
        public void MinValueChanged(object param)
        {
            if (MinimumValue != null)
            {
                AddLog("MinDateTime changed: " + MinimumValue.ToString());
            }

        }
        public void PatternChanged(object param)
        {
            
                AddLog("Pattern changed: " + Pattern.ToString());

        }
        public void MaxValueChanged(object param)
        {
            if (MaximumValue != null)
            {
                AddLog("MaxDateTime changed: " + MaximumValue.ToString());
            }

        }
        public void DropDownOpenChanged(object param)
        {
            if ((bool)param == true)

                AddLog(" DateTimeEdit popup opened ");
            else
                AddLog(" DateTimeEdit popup closed ");


        }
        public void ClockPopupOpenChanged(object param)
        {

            AddLog(" Clock popup opened ");

        }
        public void CalendarPopupOpenChanged(object param)
        {

            AddLog(" Calendar popup opened ");

        }
        private void AddLog(string eventlog)
        {
            coll.Add(eventlog);
            EventLogsCollection = coll;
        }

    }
}
