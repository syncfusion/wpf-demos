#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace TimeslotCustomization
{
    public class SliderControlBehavior : Behavior<Slider>
    {
        private MainWindow window;
        private SfScheduler scheduler;
        private Label endHourLabel;
        private Label startHourLabel;
        protected override void OnAttached()
        {
            window = App.Current.MainWindow as MainWindow;
            scheduler = window.Schedule;
            startHourLabel = window.startHourLabel;
            endHourLabel = window.endHourLabel;
            this.AssociatedObject.ValueChanged += AssociatedObject_ValueChanged;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.ValueChanged -= AssociatedObject_ValueChanged;
            window = null;
            scheduler = null;
            startHourLabel = null;
            endHourLabel = null;
        }

        private void AssociatedObject_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.AssociatedObject.Name == "startTimeSlider")
            {
                this.scheduler.DaysViewSettings.WorkStartHour = (int)this.AssociatedObject.Value;
                this.scheduler.TimelineViewSettings.WorkStartHour = (int)this.AssociatedObject.Value;
                this.startHourLabel.Content = "Work start hour : " + this.Converter(this.AssociatedObject.Value);
            }
            else
            {
                this.scheduler.DaysViewSettings.WorkEndHour = (int)this.AssociatedObject.Value;
                this.scheduler.TimelineViewSettings.WorkEndHour = (int)this.AssociatedObject.Value;
                this.endHourLabel.Content = "Work end hour : " + this.Converter(this.AssociatedObject.Value);
            }
        }

        /// <summary>
        /// Method for converter
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>return the double value</returns>
        private string Converter(double input)
        {
            string final;
            double hour = (int)input;
            double min = input - hour;
            string ampm = " ";
            if (min == 59)
            {
                hour = hour + 1;
                min = 0;
            }

            if (hour == 12)
            {
                ampm = "PM";
            }
            else if (hour == 24)
            {
                hour = 12;
                ampm = "AM";
            }
            else if (hour > 12)
            {
                hour = hour - 12;
                ampm = "PM";
            }
            else if (hour < 12)
            {
                ampm = "AM";
            }

            min = TimeSpan.FromMinutes(min).Seconds;
            if (min == 0)
            {
                var time = TimeSpan.FromMinutes(min);
                final = hour.ToString() + ":" + min.ToString() + "0 " + ampm;
            }
            else if (min == 1 || min == 2 || min == 3 || min == 4 || min == 5 || min == 6 || min == 7 || min == 8 || min == 9)
            {
                var time = TimeSpan.FromMinutes(min);
                final = hour.ToString() + ":0" + min.ToString() + " " + ampm;
            }
            else
            {
                final = hour.ToString() + ":" + min.ToString() + " " + ampm;
            }

            return final;
        }
    }
}
