#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace High_Volume_Data_Demo
{
    public class DataGenerator : INotifyPropertyChanged
    {
        public int DataCount = 500000;
        private Random randomNumber;
        private Stopwatch stopWatch;
        private ObservableCollection<Data> data;
        private string timerText;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Data> Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
                OnPropertyChanged("Data");
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
                OnPropertyChanged("TimerText");
            }
        }

        public DataGenerator()
        {
            randomNumber = new Random();
            Data = new ObservableCollection<Data>();
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
        public ObservableCollection<Data> GenerateData()
        {
            ObservableCollection<Data> datas = new ObservableCollection<Data>();
            DateTime date = new DateTime(2009, 1, 1);
            double value = 1000;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new Data(date, value));
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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
