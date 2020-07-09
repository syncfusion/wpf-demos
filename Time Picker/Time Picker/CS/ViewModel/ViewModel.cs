#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePicker
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            MinTime = new TimeSpan(9, 0, 0);
            MaxTime = new TimeSpan(18, 59, 59);
        }
        private TimeSpan minTime;

        public TimeSpan MinTime
        {
            get { return minTime; }
            set
            {
                if (minTime != value)
                {
                    minTime = value;
                    RaisePropertyChanged("MinTime");
                }
            }
        }

        private TimeSpan maxTime;

        public TimeSpan MaxTime
        {
            get { return maxTime; }
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
