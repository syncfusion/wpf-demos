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

namespace TimeSpanEditor
{
    class ViewModel : NotificationObject
    {
        //EventLogsCollection
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

        private TimeSpan? _value = new TimeSpan(1, 0, 0, 0);
        public TimeSpan? Value
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
      
            
        private TimeSpan minvalue=new TimeSpan(1, 0, 0, 0);
        public TimeSpan  MinimumValue
        {
            get
            {
                return minvalue;
            }
            set
            {
                try
                {

                    if (MaximumValue < value)
                        minvalue  = MaximumValue;
                    else
                        minvalue  = value;

                    RaisePropertyChanged("MinimumValue");
                }
                catch { }
            }

        }

        private TimeSpan maxvalue =new TimeSpan(31,0,0,0);

        public TimeSpan MaximumValue
        {
            get
            {
                return maxvalue;
            }
            set
            {
                try
                {
                    if (value < MinimumValue)
                        maxvalue = MinimumValue;
                    else
                        maxvalue = value;

                    RaisePropertyChanged("MaximumValue");

                }
                catch { }
           }
        }

        private ICommand valueChangedCommand;

        public ICommand ValueChangedCommand
        {
            get
            {
                if (valueChangedCommand == null)
                {
                    valueChangedCommand = new DelegateCommand<object>(ValueChanged);
                }
                return valueChangedCommand;
            }
        }
        public void ValueChanged(object param)
        {
            if (Value != null)
            {
                AddLog("Value Changed: " + Value.ToString());
            }
            else
            {
                AddLog("Value Changed: NULL");
            }


        }
      
        private void AddLog(string eventlog)
        {
            coll.Add(eventlog);
            EventLogsCollection = coll;
        }

    }
}
