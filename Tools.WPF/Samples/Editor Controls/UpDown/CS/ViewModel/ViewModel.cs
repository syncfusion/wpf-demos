using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UpDownDemo
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

        private ICommand valueChangedCommand;

        public ICommand  ValueChangedCommand
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
        private ICommand minValueChangedCommand;

        public ICommand  MinValueChangedCommand
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

        private double? _value = 0;
        public double? Value
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
        private double? minvalue = -500;
        public double?  MinimumValue
        {
            get
            {
                return minvalue;
            }
            set
            {

                try
                {

                    if (value > MaximumValue)
                        minvalue = (MaximumValue);
                    else
                        minvalue = value;
                    RaisePropertyChanged("MinimumValue");
                }
                catch { }

            }

        }

        private double? maxvalue = 500;
        public double?   MaximumValue
        {
            get
            {
                return maxvalue;
            }
            set
            {

                try
                {

                    if (minvalue > value)
                        maxvalue = (minvalue);
                    else
                        maxvalue = value;
                    RaisePropertyChanged("MaximumValue");

                }
                catch { }

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
        public void MinValueChanged(object param)
        {
            if (MinimumValue != null)
            {
                AddLog("MinValue Changed: " + MinimumValue.ToString());
            }

        }
        public void MaxValueChanged(object param)
        {
            if (MaximumValue  != null)
            {
                AddLog("MaxValue Changed: " + MaximumValue.ToString());
            }

        }
        private void AddLog(string eventlog)
        {
            coll.Add(eventlog);
            EventLogsCollection = coll;
        }

    }
}
