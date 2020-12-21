#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;

namespace syncfusion.editordemos.wpf
{
    public class DateTimePickerViewModel : NotificationObject
    {
        private DateTime minDate;
        private DateTime datetime = DateTime.Now;
        private DateTime maxDate;

        public DateTimePickerViewModel()
        {
            MinDate = DateTime.Now.AddDays(-390);
            MaxDate = DateTime.Now.AddDays(390);
        }

        public DateTime Value
        {
            get { return datetime; }
            set
            {
                datetime = value;
                RaisePropertyChanged("Value");
            }
        }

        public DateTime MinDate
        {
            get { return minDate; }
            set
            {
                if (minDate != value)
                {
                    minDate = value;
                    RaisePropertyChanged("MinDate");
                }
            }
        }
      
        public DateTime MaxDate
        {
            get { return maxDate; }
            set
            {
                if (maxDate != value)
                {
                    maxDate = value;
                    RaisePropertyChanged("MaxDate");
                }
            }
        }
    }
}
