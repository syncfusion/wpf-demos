#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Windows.Shared;

namespace syncfusion.editordemos.wpf
{
    public class DateTimeEditViewModel : NotificationObject
    {
        private DateTime? _value = DateTime.Now;
        private DateTime? minimumValue = new DateTime(1998, 4, 3);
        private DateTime? maximumValue = new DateTime(DateTime.Now.AddYears(10).Year, 12, 31);
        private DateTimePattern pattern = DateTimePattern.LongDate;
        private bool enablePattern;
        private bool enableCulture;
        private bool enableMinMax;
        private string dateTimeCulture = "en-US";

        public DateTime? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(nameof(this.Value));
            }
        }

        public DateTime? MinimumValue
        {
            get
            {
                return minimumValue;
            }
            set
            {
                minimumValue = value;
                RaisePropertyChanged(nameof(this.MinimumValue));
            }
        }

        public DateTime? MaximumValue
        {
            get
            {
                return maximumValue;
            }
            set
            {
                maximumValue = value;
                RaisePropertyChanged(nameof(this.MaximumValue));
            }
        }

        public DateTimePattern Pattern
        {
            get
            {
                return pattern;
            }
            set
            {
                if (pattern != value)
                {
                    pattern = value;
                    this.RaisePropertyChanged(nameof(this.Pattern));
                }
            }
        }

        public bool EnablePattern
        {
            get
            {
                return enablePattern;
            }
            set
            {
                if (enablePattern != value)
                {
                    enablePattern = value;
                    this.RaisePropertyChanged(nameof(this.EnablePattern));
                }
            }
        }

        public bool EnableCulture
        {
            get
            {
                return enableCulture;
            }
            set
            {
                if (enableCulture != value)
                {
                    enableCulture = value;
                    this.RaisePropertyChanged(nameof(this.EnableCulture));
                }
            }
        }

        public bool EnableMinMax
        {
            get
            {
                return enableMinMax;
            }
            set
            {
                if (enableMinMax != value)
                {
                    enableMinMax = value;
                    this.RaisePropertyChanged(nameof(this.EnableMinMax));
                }
            }
        }

        public string DateTimeCulture
        {
            get
            {
                return dateTimeCulture;
            }
            set
            {
                if (dateTimeCulture != value)
                {
                    dateTimeCulture = value;
                    this.RaisePropertyChanged(nameof(this.DateTimeCulture));
                }
            }
        }
    }
}
