#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    public class ResourceViewBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttached()
        {
            var specialTimeRegions = this.GetSpecialTimeRegions();
            this.AssociatedObject.TimelineViewSettings.ResourceHeaderSize = 100;
            this.AssociatedObject.TimelineViewSettings.SpecialTimeRegions = specialTimeRegions;
            this.AssociatedObject.DaysViewSettings.ResourceHeaderSize = 100;
            this.AssociatedObject.DaysViewSettings.SpecialTimeRegions = specialTimeRegions;
        }

        private ObservableCollection<SpecialTimeRegion> GetSpecialTimeRegions()
        {
            var resourceViewModel = this.AssociatedObject.DataContext as BindingViewModel;
            var currentDate = DateTime.Now;
            var nonWorkingHours_1 = new SpecialTimeRegion();
            nonWorkingHours_1.StartTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 0, 0, 0);
            nonWorkingHours_1.EndTime = nonWorkingHours_1.StartTime.AddHours(9);
            nonWorkingHours_1.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            nonWorkingHours_1.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";
            nonWorkingHours_1.ResourceIdCollection = new ObservableCollection<object>(resourceViewModel.Resources.Select(resource => (resource as Employee).ID).ToList());

            var nonWorkingHours_2 = new SpecialTimeRegion();
            nonWorkingHours_2.StartTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 18, 0, 0);
            nonWorkingHours_2.EndTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 23, 59, 59);
            nonWorkingHours_2.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            nonWorkingHours_2.ResourceIdCollection = new ObservableCollection<object>(resourceViewModel.Resources.Select(resource => (resource as Employee).ID).ToList());
            nonWorkingHours_2.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";

            var specialTimeRegions = new ObservableCollection<SpecialTimeRegion>();
            specialTimeRegions.Add(nonWorkingHours_1);
            specialTimeRegions.Add(nonWorkingHours_2);

            return specialTimeRegions;
        }
    }
}
