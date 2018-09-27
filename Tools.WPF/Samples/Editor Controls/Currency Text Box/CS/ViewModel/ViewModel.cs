using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Curruncy_Text_Box
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
        public ICommand ValueChangedCommand
        {
            get
            {
                return valueChangedCommand;
            }
            set
            {
                valueChangedCommand = value;
            }

        }

        private decimal? _value=0;
        public decimal? Value
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

        private decimal?  minvalue = 0;
        public decimal?  MinimumValue
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
        private decimal?  maxvalue = 100;
        public decimal?  MaximumValue
        {
            get
            {
                return maxvalue;
            }
            set
            {

                try
                {

                    if (MinimumValue > value)
                        maxvalue = (MinimumValue );
                    else
                    maxvalue = value;
                    RaisePropertyChanged("MaximumValue");

                }
                catch { }

            }

        }

        private ICommand minValueChangedCommand;
        public ICommand MinValueChangedCommand
        {
            get
            {
                return minValueChangedCommand;
            }
            set
            {
                minValueChangedCommand = value;
            }

        }
        private ICommand maxValueChangedCommand;
        public ICommand  MaxValueChangedCommand
        {
            get
            {
                return maxValueChangedCommand;
            }
            set
            {
                maxValueChangedCommand = value;
            }

        }
        public ViewModel()
        {
            ValueChangedCommand = new DelegateCommand<object>(ValueChanged);
            MinValueChangedCommand = new DelegateCommand<object>(MinValueChanged);
            MaxValueChangedCommand = new DelegateCommand<object>(MaxValueChanged);
        }
        public void ValueChanged(object param)
        {
            if (Value  != null)
            {
                if (param is CurrencyTextBox)
                {
                    CurrencyTextBox textBox = param as CurrencyTextBox;
                    if (Value.Value > MaximumValue && !textBox.IsFocused && textBox.MaxValidation != MaxValidation.OnLostFocus)
                    {
                        AddLog("Value Changed: " + MaximumValue.ToString());
                    }
                    else if (Value.Value < MinimumValue && !textBox.IsFocused && textBox.MinValidation != MinValidation.OnLostFocus)
                    {
                        AddLog("Value Changed: " + MinimumValue.ToString());
                    }
                    else
                    {
                        AddLog("Value Changed: " + Value.ToString());
                    }
                }
                else
                    AddLog("Value Changed: " + Value.ToString());
            }
            else
            {
                AddLog("Value Changed: NULL");
            }

        }
        public void MinValueChanged(object param)
        {
            if (MinimumValue  != null)
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
