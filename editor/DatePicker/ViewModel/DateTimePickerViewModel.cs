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
