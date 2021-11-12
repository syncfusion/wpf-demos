#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Represents helper class to get scheduler view types.
    /// </summary>
    public static class SchedulerViewTypeHelper
    {
        /// <summary>
        /// Method to get all scheduler view types.
        /// </summary>
        /// <returns> Scheduler view type collection as key and value.</returns>
        internal static ObservableCollection<SchedulerViewTypeModel> GetSchedulerViewTypes()
        {
            var schedulerViewTypes = new ObservableCollection<SchedulerViewTypeModel>();
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Month", SchedulerViewType = "Month" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Day", SchedulerViewType = "Day" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Week", SchedulerViewType = "Week" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Work Week", SchedulerViewType = "WorkWeek" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Day", SchedulerViewType = "TimelineDay" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Week", SchedulerViewType = "TimelineWeek" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Work Week", SchedulerViewType = "TimelineWorkWeek" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Month", SchedulerViewType = "TimelineMonth" });
            return schedulerViewTypes;
        }

        /// <summary>
        /// Method to get scheduler view types for resource sample, which excludes Month type.
        /// </summary>
        /// <returns> Scheduler view type collection as key and value.</returns>
        internal static ObservableCollection<SchedulerViewTypeModel> GetResourceSchedulerViewTypes()
        {
            var schedulerViewTypes = new ObservableCollection<SchedulerViewTypeModel>();
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Day", SchedulerViewType = "Day" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Week", SchedulerViewType = "Week" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Work Week", SchedulerViewType = "WorkWeek" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Day", SchedulerViewType = "TimelineDay" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Week", SchedulerViewType = "TimelineWeek" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Work Week", SchedulerViewType = "TimelineWorkWeek" });
            schedulerViewTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Timeline Month", SchedulerViewType = "TimelineMonth" });
            return schedulerViewTypes;
        }

        /// <summary>
        /// Method to get calendar types for calendar identifier.
        /// </summary>
        /// <returns>calendar type collection as key and value.</returns>
        internal static ObservableCollection<SchedulerViewTypeModel> GetCalendarTypes()
        {
            var calendarTypes = new ObservableCollection<SchedulerViewTypeModel>();
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Gregorian Calendar", SchedulerViewType = "GregorianCalendar" });
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Hebrew Calendar", SchedulerViewType = "HebrewCalendar" });
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Hijri Calendar", SchedulerViewType = "HijriCalendar" });
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Korean Calendar", SchedulerViewType = "KoreanCalendar" });
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Persian Calendar", SchedulerViewType = "PersianCalendar" });
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Taiwan Calendar", SchedulerViewType = "TaiwanCalendar" });
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "Thai Calendar", SchedulerViewType = "ThaiCalendar" });
            calendarTypes.Add(new SchedulerViewTypeModel() { ViewTypeDisplayMemberPath = "UmAlQura Calendar", SchedulerViewType = "UmAlQuraCalendar" });
            return calendarTypes;
        }
    }
}
