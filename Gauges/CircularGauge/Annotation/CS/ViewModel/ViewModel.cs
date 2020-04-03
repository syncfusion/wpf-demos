#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Annotation
{
    public class ViewModel : INotifyPropertyChanged
    {
        private float hours;

        private float second;

        private float minute;

        private DateTime currentDate;

        private string currentTime;

        public DateTime CurrentDateTime
        {
            get { return currentDate; }
            set
            {
                currentDate = value;
                OnPropertyChanged("CurrentDateTime");
            }
        }

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }
        public float Hour
        {
            get { return hours; }
            set
            {
                hours = value;
                OnPropertyChanged("Hour");
            }
        }

        public float Minutes
        {
            get { return minute; }
            set
            {
                minute = value;
                OnPropertyChanged("Minutes");
            }
        }

        public float Seconds
        {
            get { return second; }
            set
            {
                second = value;
                OnPropertyChanged("Seconds");
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DynamicUpdate();
        }

        private void DynamicUpdate()
        {
            CurrentDateTime = DateTime.Now;
            CurrentTime = CurrentDateTime.ToShortTimeString();
            float hour = CurrentDateTime.Hour;
            hour = hour > 12 ? (hour % 12) : hour;

            float min = CurrentDateTime.Minute;
            float sec = CurrentDateTime.Second;

            Minutes = min / 5f + (sec / 60f * 0.2f);
            Hour = hour + (min / 60f);
            Seconds = (sec / 5f);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    
}
