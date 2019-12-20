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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RealTimeUpdateDemo
{
    public class DataGenerator
    {
        public int DataCount = 50000;
        private int RateOfData = 5;
        private ObservableCollection<Data> Data;
        private Random randomNumber;
        int myindex = 0;
        DispatcherTimer timer;

        public ObservableCollection<Data> DynamicData { get; set; }

        public DataGenerator()
        {
            randomNumber = new Random();
            DynamicData = new ObservableCollection<Data>();
            Data = new ObservableCollection<Data>();
            Data = GenerateData();
            LoadData();

            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Start();
        }

        public void AddData()
        {
            for (int i = 0; i < RateOfData; i++)
            {
                myindex++;
                if (myindex < 100)
                {
                    DynamicData.Add(this.Data[myindex]);
                }
                else if (myindex > 100)
                {
                    DynamicData.RemoveAt(0);
                    DynamicData.Add(this.Data[(myindex % (this.Data.Count - 1))]);
                }
            }

        }

        public void LoadData()
        {
            for (int i = 0; i < 10; i++)
            {
                myindex++;
                if (myindex < Data.Count)
                {
                    DynamicData.Add(this.Data[myindex]);
                }
            }

        }

        public ObservableCollection<Data> GenerateData()
        {
            ObservableCollection<Data> datas = new ObservableCollection<Data>();

            DateTime date = new DateTime(2009, 1, 1);
            double value = 1000;
            double value1 = 1001;
            double value2 = 1002;
            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new Data(date, value, value1, value2));
                date = date.Add(TimeSpan.FromSeconds(5));

                if ((randomNumber.NextDouble() + value2) < 1004.85)
                {
                    double random = randomNumber.NextDouble();
                    value += random;
                    value1 += random;
                    value2 += random;
                }
                else
                {
                    double random = randomNumber.NextDouble();
                    value -= random;
                    value1 -= random;
                    value2 -= random;
                }
            }

            return datas;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AddData();
        }
    }
}
