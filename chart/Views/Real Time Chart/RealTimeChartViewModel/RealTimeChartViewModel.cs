#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace syncfusion.chartdemos.wpf
{
    public class RealTimeChartViewModel
    {
        public int DataCount = 50000;
        private int RateOfData = 5;
        private ObservableCollection<RealTimeChartModel> Data;
        int myindex = 0;
        DispatcherTimer timer;
        public Action SuspendSeriesAction { get; set; }
        public Action ResumeSeriesAction { get; set; }

        public ObservableCollection<RealTimeChartModel> DynamicData { get; set; }

        public RealTimeChartViewModel()
        {
            DynamicData = new ObservableCollection<RealTimeChartModel>();
            Data = new ObservableCollection<RealTimeChartModel>();
            Data = GenerateData();
            LoadData();

            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Start();
        }

        public void Dispose()
        {
            if(timer != null)
            {
                timer.Stop();
                timer.Tick -= timer_Tick;
                timer = null;
            }

            if(Data != null)
            {
                Data.Clear();
                Data = null;
            }

            if(DynamicData != null)
            {
                DynamicData.Clear();
                DynamicData = null;
            }
        }

        int count = 0;
        public void AddData()
        {
            if (count == 0)
            {
                SuspendSeriesAction.Invoke();
            }

            count++;

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

            if (count == 5)
            {
                ResumeSeriesAction.Invoke();
                count = 0;
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

        public ObservableCollection<RealTimeChartModel> GenerateData()
        {
            ObservableCollection<RealTimeChartModel> datas = new ObservableCollection<RealTimeChartModel>();

            DateTime date = DateTime.Now;
            double minValue = 30;
            double maxValue = 90;
            Random randomNumber = new Random();

            for (int i = 0; i < this.DataCount; i++)
            {
                double value;
                if (i % 3 == 0)
                {
                    value = randomNumber.NextDouble() * (maxValue - minValue) + minValue;
                }
                else
                {
                    double range = maxValue - minValue;
                    double randomValue = randomNumber.NextDouble();
                    if (randomValue < 0.5)
                    {
                        value = minValue + range * Math.Sqrt(randomValue);
                    }
                    else
                    {
                        value = maxValue - range * Math.Sqrt(1 - randomValue);
                    }
                }

                datas.Add(new RealTimeChartModel(date, value));
                date = date.AddSeconds(5);
            }

            return datas;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((System.Windows.Application.Current.MainWindow.DataContext is DemoBrowserViewModel) &&(System.Windows.Application.Current.MainWindow.DataContext as DemoBrowserViewModel).SelectedSample != null && (System.Windows.Application.Current.MainWindow.DataContext as DemoBrowserViewModel).SelectedSample.SampleName == "Real-time Line Chart")
            {
                AddData();
            }
        }
    }
}
