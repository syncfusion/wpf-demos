#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace syncfusion.chartdemos.wpf
{
    public class VerticalChartViewModel : ObservableCollection<VerticalChartModel>
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime i = DateTime.Now;
        int count = 0;

        public VerticalChartViewModel()
        {
            Random rand = new Random();
            DateTime dt = new DateTime(2014, 7, 8, 5, 20, 10);
            for (int i = 11; i < 50; i++)
            {
                dt = dt.AddSeconds(1);
                this.Add(new VerticalChartModel { Velocity = rand.Next(-3, 3), Time = dt });
                dt = dt.AddSeconds(1);
            }

            timer.Interval = TimeSpan.FromMilliseconds(2);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public void Dispose()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= timer_Tick;
                timer = null;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            i = this[this.Count - 1].Time.AddSeconds(1);
            count = count + 1;
            Random rand = new Random();
            if (count > 350)
            {
                timer.Stop();
            }
            else if (count > 300)
            {
                this.Add(new VerticalChartModel() { Time = i, Velocity = rand.Next(0, 0)});
            }
            else if (count > 250)
            {
                this.Add(new VerticalChartModel() { Time = i, Velocity = rand.Next(-2, 1) });
            }
            else if (count > 180)
            {
                this.Add(new VerticalChartModel() { Time = i, Velocity = rand.Next(-3, 2)});
            }
            else if (count > 100)
            {
                this.Add(new VerticalChartModel() { Time = i, Velocity = rand.Next(-7, 6)});
            }
            else
            {
                this.Add(new VerticalChartModel() { Time = i, Velocity = rand.Next(-9, 9)});
            }
        }
    }
}
