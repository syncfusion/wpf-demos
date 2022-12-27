#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    public class SpecialTimeRegionBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttached()
        {
            var specialTimeRegions = this.GetSpecialTimeRegions();
            this.AssociatedObject.TimelineViewSettings.SpecialTimeRegions = specialTimeRegions;
            this.AssociatedObject.DaysViewSettings.SpecialTimeRegions = specialTimeRegions;
        }

        private ObservableCollection<SpecialTimeRegion> GetSpecialTimeRegions()
        {
            var currentDate = DateTime.Now.AddMonths(-3);
            var nonWorkingHours_1 = new SpecialTimeRegion();
            nonWorkingHours_1.StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 10, 0, 0);
            nonWorkingHours_1.EndTime = nonWorkingHours_1.StartTime.AddHours(1);
            nonWorkingHours_1.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            nonWorkingHours_1.RecurrenceRule = "FREQ=DAILY;INTERVAL=2";
            nonWorkingHours_1.CanEdit = false;

            var nonWorkingHours_2 = new SpecialTimeRegion();
            nonWorkingHours_2.StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 13, 0, 0);
            nonWorkingHours_2.EndTime = nonWorkingHours_2.StartTime.AddHours(1);
            nonWorkingHours_2.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            nonWorkingHours_2.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";
            nonWorkingHours_2.CanMergeAdjacentRegions = true;
            nonWorkingHours_2.CanEdit = false;

            var specialTimeRegions = new ObservableCollection<SpecialTimeRegion>();
            specialTimeRegions.Add(nonWorkingHours_1);
            specialTimeRegions.Add(nonWorkingHours_2);

            return specialTimeRegions;
        }
    }
}
