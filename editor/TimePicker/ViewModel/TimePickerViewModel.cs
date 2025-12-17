using Syncfusion.Windows.Shared;
using System;

namespace syncfusion.editordemos.wpf
{
    public class TimePickerViewModel : NotificationObject
    {
        private TimeSpan minTime = new TimeSpan(9, 0, 0);
        private TimeSpan maxTime = new TimeSpan(18, 59, 59);

        public TimeSpan MinTime
        {
            get 
            { 
                return minTime; 
            }
            set
            {
                if (minTime != value)
                {
                    minTime = value;
                    RaisePropertyChanged("MinTime");
                }
            }
        }

        public TimeSpan MaxTime
        {
            get 
            {
                return maxTime;
            }
            set
            {
                if (maxTime != value)
                {
                    maxTime = value;
                    RaisePropertyChanged("MaxTime");
                }
            }
        }
    }
}
