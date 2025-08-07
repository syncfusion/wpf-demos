#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    public class ChartTimerBehavior : Behavior<UIElement>
    {
        bool isRenderingCalled = false;
        Stopwatch sw = new Stopwatch();
        TimeSpan watch;
        DataGenerator generator;
        SfChart chart;
        protected override void OnAttached()
        {
            chart = (AssociatedObject as SfChart);
            chart.LayoutUpdated += PerformanceDemo_LayoutUpdated;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            chart.Loaded += Chart_Loaded;
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            chart = (AssociatedObject as SfChart);
            if (chart != null)
            {
                chart.LayoutUpdated -= PerformanceDemo_LayoutUpdated;
                chart.Loaded -= Chart_Loaded;
            }

            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            base.OnDetaching();
        }

        private void Chart_Loaded(object sender, RoutedEventArgs e)
        {
            generator = (sender as SfChart).DataContext as DataGenerator;
            List<string> colorNames = new List<string>();
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

                if (chart != null)
                {
                    chart.Series.Add(bitmapSeries);
                }
            }
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {           
            if (generator != null && generator.IsRunning)
            {
                isRenderingCalled = true;
            }
        }

        private void PerformanceDemo_LayoutUpdated(object sender, EventArgs e)
        {
            if (generator != null && generator.IsRunning && isRenderingCalled)
            {
                watch = DateTime.Now.Subtract(generator.StartTime);
                UpdateTimeTaken(watch.Milliseconds.ToString());
                generator.IsRunning = false;
            }
        }

        void UpdateTimeTaken(string time)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                (chart.DataContext as DataGenerator).TimeTaken = "Time Taken: " + time + "ms";
            }));
        }
    }
}
