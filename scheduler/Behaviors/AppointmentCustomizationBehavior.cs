#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    class AppointmentCustomizationBehavior : Behavior<SfScheduler>
    {
        private ObservableCollection<SchedulerModel> appointments;

        protected override void OnAttached()
        {
            this.AssociatedObject.ViewChanged += OnSchedulerViewChanged;
        }

        private void OnSchedulerViewChanged(object sender, ViewChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var startDate = e.NewValue.StartDate;
                var random = new Random();
                appointments = new ObservableCollection<SchedulerModel>();
                if (this.AssociatedObject.ViewType == SchedulerViewType.Week || this.AssociatedObject.ViewType == SchedulerViewType.WorkWeek)
                {
                    List<DateTime> visibleDates = new List<DateTime>();

                    List<string> eventCollection = new List<string>()
                        {
                            "Environmental Discussion", "Health Checkup", "Cancer awareness", "Happiness", "Tourism"
                        };

                    List<string> notesCollection = new List<string>()
                        {
                            "A day that creates awareness to promote the healthy planet and reduce the air pollution crisis on nature earth.",
                            "A day that raises awareness on different healthy issue. It marks the anniversary of the foundation of WHO.",
                            "A day that raises awareness on cancer and its preventive measures. Early detection saves life.",
                            "A general idea is to promote happiness and smile around the world.",
                            "A day that raises awareness on the role of tourism and its effect on social and economic values."
                        };

                    List<Brush> colorCollection = new List<Brush>()
                        {
                            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF56AB56")),
                            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF357CD2")),
                            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7FA90E")),
                            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8c00")),
                            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5BBEAF"))
                        };

                    for (DateTime date = startDate; date <= e.NewValue.EndDate; date = date.AddDays(1))
                    {
                        visibleDates.Add(date.Date);
                    }
                    if (!visibleDates.Contains(DateTime.Now.Date))
                    {
                        this.AssociatedObject.ItemsSource = appointments;
                    }
                    else
                    {
                        startDate = startDate.AddDays(1);
                        for (int i = 0; i < 5; i++)
                        {
                            SchedulerModel schedulerModel = new SchedulerModel();
                            schedulerModel.Color = colorCollection[i];
                            schedulerModel.From = startDate.AddDays(i).AddHours(10);
                            schedulerModel.To = startDate.AddDays(i).AddHours(16);
                            schedulerModel.EventName = eventCollection[i];
                            schedulerModel.TimeValue = "Time: " + schedulerModel.From.ToShortTimeString() + " - " + schedulerModel.To.ToShortTimeString();
                            schedulerModel.Notes = notesCollection[i];
                            appointments.Add(schedulerModel);
                        }
                        this.AssociatedObject.ItemsSource = appointments;
                    }
                }

                else
                {
                    List<Brush> colorCollection = new List<Brush>()
                    {
                        Brushes.Red, Brushes.Green, Brushes.DarkOrange, Brushes.DarkMagenta, Brushes.DarkSeaGreen, Brushes.Brown, Brushes.Chocolate, Brushes.DarkOrange, Brushes.DeepSkyBlue, Brushes.Purple
                    };

                    List<string> currentDayMeetings = new List<string>()
                    {
                        "General Meeting", "Scrum", "Project Plan", "Consulting", "Support", "Yoga Therapy", "Plan Execution", "Project Plan", "Consulting", "Performance Check"
                    };

                    for (DateTime date = startDate; date <= e.NewValue.EndDate; date = date.AddDays(1))
                    {
                        SchedulerModel schedulerModel = new SchedulerModel();
                        schedulerModel.Color = colorCollection[random.Next(0, 9)];
                        schedulerModel.From = date.AddHours(random.Next(9, 13));
                        schedulerModel.To = schedulerModel.From.AddHours(4);
                        schedulerModel.EventName = currentDayMeetings[random.Next(0, 9)];
                        schedulerModel.TimeValue = schedulerModel.From.ToShortTimeString();
                        appointments.Add(schedulerModel);
                    }

                    for (DateTime date = startDate; date <= e.NewValue.EndDate; date = date.AddDays(2))
                    {
                        SchedulerModel schedulerModel = new SchedulerModel();
                        schedulerModel.Color = colorCollection[random.Next(0, 9)];
                        schedulerModel.From = date.AddHours(random.Next(13, 16));
                        schedulerModel.To = schedulerModel.From.AddHours(4);
                        schedulerModel.EventName = currentDayMeetings[random.Next(0, 9)];
                        schedulerModel.TimeValue = schedulerModel.From.ToShortTimeString();
                        appointments.Add(schedulerModel);
                    }
                    this.AssociatedObject.ItemsSource = appointments;
                }
            }

        }

        protected override void OnDetaching()
        {
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.ViewChanged -= OnSchedulerViewChanged;
            }
        }
    }
}
