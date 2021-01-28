#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class PerformanceViewModel : NotificationObject
    {
        public int DataCount = 500000;
        private Random randomNumber;
        private Stopwatch stopWatch;
        private ObservableCollection<PerformanceModel> data;
        private string timerText;

        public ObservableCollection<PerformanceModel> Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
                RaisePropertyChanged(nameof(this.Data));
            }
        }
        
        public string TimerText
        {
            get 
            {
                return timerText; 
            }

            set 
            {
                timerText = value;
                RaisePropertyChanged(nameof(this.TimerText));
            }
        }

        public PerformanceViewModel()
        {
            randomNumber = new Random();
            Data = new ObservableCollection<PerformanceModel>();
            stopWatch = new Stopwatch();
            TimerText = "Total Time Taken : ";
        }

        internal void Button_Click(string converterParameter)
        {
            if (converterParameter == "Start")
            {
                stopWatch.Start();
                Data = GenerateData();
            }
            else
            {
                stopWatch.Stop();
                TimerText = "Total Time Taken : " + stopWatch.ElapsedMilliseconds.ToString() + " ms";
            }
        }
        public ObservableCollection<PerformanceModel> GenerateData()
        {
            ObservableCollection<PerformanceModel> datas = new ObservableCollection<PerformanceModel>();
            DateTime date = new DateTime(2009, 1, 1);
            double value = 1000;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new PerformanceModel(date, value));
                date = date.Add(TimeSpan.FromSeconds(5));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
    }
}
