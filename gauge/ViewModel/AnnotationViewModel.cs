#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace syncfusion.gaugedemos.wpf
{
    public class AnnotationViewModel : NotificationObject
    {
        private float hours;

        private float seconds;

        private float minute;

        private DateTime currentDate;

        private string currentTime;

        DispatcherTimer timer = new DispatcherTimer();

        public DateTime CurrentDateTime
        {
            get { return currentDate; }
            set
            {
                currentDate = value;
                RaisePropertyChanged("CurrentDateTime");
            }
        }

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }
        public float Hour
        {
            get { return hours; }
            set
            {
                hours = value;
                RaisePropertyChanged("Hour");
            }
        }

        public float Minutes
        {
            get { return minute; }
            set
            {
                minute = value;
                RaisePropertyChanged("Minutes");
            }
        }

        public float Seconds
        {
            get { return seconds; }
            set
            {
                seconds = value;
                RaisePropertyChanged("Seconds");
            }
        }

        public AnnotationViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            DynamicUpdate();
        }

        private void DynamicUpdate()
        {
            CurrentDateTime = DateTime.Now;
            CurrentTime = CurrentDateTime.ToShortTimeString();
            float hour =  CurrentDateTime.Hour;
            hour = hour > 12 ? (hour % 12) : hour;

            float min = CurrentDateTime.Minute;
            float sec = CurrentDateTime.Second;

            Minutes = min / 5f + (sec / 60f * 0.2f);
            Hour = hour + (min / 60f);
            Seconds = (sec / 5f);
        }

        internal void Dispose()
        {
            timer.Tick -= timer_Tick;
            timer.Stop();
            timer = null;
        }
    }
}
