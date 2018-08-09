using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PercentTextBoxDemo
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


        private double? minvalue = 0;
        public double? MinimumValue
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

        private double? maxvalue = 100;
        public double? MaximumValue
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
                        maxvalue = (MinimumValue);
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


        public void ValueChanged(object param)
        {
            if (Value != null)
            {
                if (param is Syncfusion.Windows.Shared.PercentTextBox)
                {
                    Syncfusion.Windows.Shared.PercentTextBox textBox = param as Syncfusion.Windows.Shared.PercentTextBox;
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
            if (MinimumValue != null)
            {
                AddLog("MinValue Changed: " + MinimumValue.ToString());
            }

        }
        public void MaxValueChanged(object param)
        {
            if (MaximumValue != null)
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
