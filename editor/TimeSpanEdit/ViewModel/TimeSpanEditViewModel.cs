#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Windows.Shared;
using System.Windows.Input;

namespace syncfusion.editordemos.wpf
{
    class TimeSpanEditViewModel : NotificationObject
    {
        private TimeSpan? _value = new TimeSpan(1, 0, 0, 0);
        private TimeSpan minvalue = new TimeSpan(1, 0, 0, 0);
        private TimeSpan maxvalue = new TimeSpan(31, 0, 0, 0);
        private bool allowNull = true;
        private string nullString = "TimeSpanEdit...";
        private bool incrementOnScrolling = true;
        private bool showArrowButtons = true;
        private string format = "d 'Days' h 'Hours' m 'Minutes'";
        private ICommand setNullValueCommand;

        public TimeSpanEditViewModel()
        {
            SetNullValueCommand = new DelegateCommand(SetNullValue);
        }

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

        public TimeSpan MinimumValue
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
                        minvalue = MaximumValue;
                    else
                        minvalue = value;

                    RaisePropertyChanged("MinimumValue");
                }
                catch { }
            }

        }

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

        public bool AllowNull
        {
            get
            {
                return allowNull;
            }
            set
            {
                if (allowNull != value)
                {
                    allowNull = value;
                    this.RaisePropertyChanged(nameof(this.AllowNull));
                }
            }
        }

        public string NullString
        {
            get
            {
                return nullString;
            }
            set
            {
                if (nullString != value)
                {
                    nullString = value;
                    this.RaisePropertyChanged(nameof(this.NullString));
                }
            }
        }

        public bool IncrementOnScrolling
        {
            get
            {
                return incrementOnScrolling;
            }
            set
            {
                if (incrementOnScrolling != value)
                {
                    incrementOnScrolling = value;
                    this.RaisePropertyChanged(nameof(this.IncrementOnScrolling));
                }
            }
        }

        public bool ShowArrowButtons
        {
            get
            {
                return showArrowButtons;
            }
            set
            {
                if (showArrowButtons != value)
                {
                    showArrowButtons = value;
                    this.RaisePropertyChanged(nameof(this.ShowArrowButtons));
                }
            }
        }

        public string Format
        {
            get
            {
                return format;
            }
            set
            {
                if (format != value)
                {
                    format = value;
                    this.RaisePropertyChanged(nameof(this.Format));
                }
            }
        }

        public ICommand SetNullValueCommand
        {
            get
            {
                return setNullValueCommand;
            }
            set
            {
                if (setNullValueCommand != value)
                {
                    setNullValueCommand = value;
                    this.RaisePropertyChanged(nameof(this.SetNullValueCommand));
                }
            }
        }

        private void SetNullValue(object param)
        {
            this.Value = null;
        }
    }
}
