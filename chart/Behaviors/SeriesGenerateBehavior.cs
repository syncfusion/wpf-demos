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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.chartdemos.wpf
{
    public class SeriesGenerateBehavior : Behavior<UIElement>
    {       
        protected override void OnAttached()
        {
            var button = AssociatedObject as Button;

            if(button != null)
            {
                button.Click += GenerateButton_Click;
            }

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            var button = AssociatedObject as Button;

            if (button != null)
            {
                button.Click -= GenerateButton_Click;
            }

            base.OnDetaching();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var generator = button.DataContext as DataGenerator;
            var lineChart = button.Tag as SfChart;

            IList<Data> datas = generator.GenerateData();
            generator.StartTime = DateTime.Now;
            generator.IsRunning = true;
            lineChart.SuspendSeriesNotification();

            for (int i = 0; i < 500; i++)
            {
                lineChart.Series[i].ItemsSource = datas;
                datas = generator.GenerateData();
            }

            lineChart.ResumeSeriesNotification();
        }
    }
}
