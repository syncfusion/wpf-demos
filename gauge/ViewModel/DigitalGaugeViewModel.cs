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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace syncfusion.gaugedemos.wpf
{
    class DigitalGaugeViewModel : NotificationObject
    {
   
        DateTime datetime;

        private string dateGauge;

        private string monthGauge;

        private string dayGauge;

        private string timeGauge;

        private string secondsGauge;

        DispatcherTimer timer = new DispatcherTimer();

        public string DateGauge
        {
            get { return dateGauge; }
            set
            {
                dateGauge = value;
                RaisePropertyChanged("DateGauge");
            }
        }

        public string MonthGauge
        {
            get { return monthGauge; }
            set
            {
                monthGauge = value;
                RaisePropertyChanged("MonthGauge");
            }
        }

        public string DayGauge
        {
            get { return dayGauge; }
            set
            {
                dayGauge = value;
                RaisePropertyChanged("DayGauge");
            }
        }
        public string TimeGauge
        {
            get { return timeGauge; }
            set
            {
                timeGauge = value;
                RaisePropertyChanged("TimeGauge");
            }
        }

        public string SecondsGauge
        {
            get { return secondsGauge; }
            set
            {
                secondsGauge = value;
                RaisePropertyChanged("SecondsGauge");
            }
        }

        public DigitalGaugeViewModel()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
            datetime = DateTime.Now;
            TimeGauge = DateTime.Now.ToString("HH-mm");
            SecondsGauge = datetime.Second.ToString();
            DateGauge = datetime.Day.ToString();
            MonthGauge = datetime.Month.ToString();
            DayGauge = datetime.DayOfWeek.ToString().Remove(3, datetime.DayOfWeek.ToString().Length - 3).ToUpper();
        }

        void timer_Tick(object sender, object e)
        {
            TimeGauge = DateTime.Now.ToString("HH-mm");
            SecondsGauge = DateTime.Now.Second.ToString();
        }

        internal void Dispose()
        {
            timer.Tick -= timer_Tick;
            timer.Stop();
            timer = null;
        }
    }
}
