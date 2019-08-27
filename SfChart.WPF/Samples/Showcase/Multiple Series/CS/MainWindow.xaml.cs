#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace Multiple_Series_Demo
{
    public partial class MainWindow : SampleLayoutWindow
    {
        Stopwatch sw = new Stopwatch(); 
        DataGenerator generator;
        bool isRunning = false;
        TimeSpan watch;
        DateTime startTime;
        bool isRenderingCalled = false;

        public MainWindow()
        {
            InitializeComponent();

            generator = new DataGenerator();
            this.lineChart.LayoutUpdated += PerformanceDemo_LayoutUpdated;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            List<string> colorNames=new List<string>();
            Type colors = typeof(Colors);
            PropertyInfo[] colorInfo = colors.GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach (PropertyInfo info in colorInfo)
            {
               colorNames.Add(info.Name);
            }

            for (int i = 0; i < 500; i++)
            {
                FastLineBitmapSeries bitmapSeries = new FastLineBitmapSeries()
                {
                    XBindingPath = "Date",
                    YBindingPath = "Value"
                };

                bitmapSeries.Interior = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorNames[i % (colorNames.Count - 1)]));

                lineChart.Series.Add(bitmapSeries);
            }
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRenderingCalled = true;
            }
        }
       
        void PerformanceDemo_LayoutUpdated(object sender, object e)
        {
            if (isRunning && isRenderingCalled)
            {
                watch = DateTime.Now.Subtract(startTime);
                UpdateTimeTaken(watch.Milliseconds.ToString());
                isRunning = false;
            }
        }

        void UpdateTimeTaken(string time)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                timeTaken.Text = "Time Taken: " + time + "ms";
            }));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IList<Data> datas = generator.GenerateData();
            isRunning = true;
            startTime = DateTime.Now;
            lineChart.SuspendSeriesNotification();

            for (int i = 0; i < 500; i++)
            {
                this.lineChart.Series[i].ItemsSource = datas;
                datas = generator.GenerateData();
            }
            lineChart.ResumeSeriesNotification();
        }
    }

    public class DataGenerator
    {
        public int DataCount = 500;

        private Random randomNumber;

        public DataGenerator()
        {
            randomNumber = new Random();
        }

        public IList<Data> GenerateData()
        {
            List<Data> datas = new List<Data>();

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
    }

    public class Data
    {
        public Data(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
    }
}
