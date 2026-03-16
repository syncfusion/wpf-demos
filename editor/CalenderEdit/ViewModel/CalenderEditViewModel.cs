#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Syncfusion.Windows.Shared;

namespace syncfusion.editordemos.wpf
{
    public class CalenderEditViewModel : NotificationObject
    {
        private string culture = "en-US";
        private bool showAbbrivatedDays = true;
        private bool showAbbrivatedMonths = true;
        private bool enableDateSelection = true;
        private bool enableMultipleSelection = true;
        private BlackoutDatesCollection blackoutDates = new BlackoutDatesCollection();

        public CalenderEditViewModel()
        {
            BlackOutWeekends(new DateTime(2019, 01, 09), new DateTime(2019, 03, 22));
        }

        public string CultureString
        {
            get
            {
                return culture;
            }
            set
            {
                culture = value;
                RaisePropertyChanged("CultureString");
            }
        }

        public bool ShowAbbrivatedDays
        {
            get
            {
                return showAbbrivatedDays;
            }
            set
            {
                showAbbrivatedDays = value;
                RaisePropertyChanged("ShowAbbrivatedDays");
            }
        }

        public bool ShowAbbrivatedMonths
        {
            get
            {
                return showAbbrivatedMonths;
            }
            set
            {
                showAbbrivatedMonths = value;
                RaisePropertyChanged("ShowAbbrivatedMonths");
            }
        }

        public bool EnableDateSelection
        {
            get
            {
                return enableDateSelection;
            }
            set
            {
                enableDateSelection = value;
                RaisePropertyChanged("EnableDateSelection");
            }
        }

        public bool EnableMultipleSelection
        {
            get
            {
                return enableMultipleSelection;
            }
            set
            {
                enableMultipleSelection = value;
                RaisePropertyChanged("EnableMultipleSelection");
            }
        }

        public BlackoutDatesCollection BlackOutDatesCollection
        {
            get
            {
                return blackoutDates;
            }
            set
            {
                blackoutDates = value;
                RaisePropertyChanged("BlackOutDatesCollection");
            }
        }

        private void BlackOutWeekends(DateTime value1, DateTime value2)
        {
            int count;
            List<DateTime> time = new List<DateTime>();
            time = (GetDaysBetween(value1, value2)).ToList();
            count = time.Count;

            for (int j = 0; j < count; j++)
            {
                BlackoutDatesRange blackOutDays = new BlackoutDatesRange();
                blackOutDays.StartDate = time[j];
                blackOutDays.EndDate = time[j];
                BlackOutDatesCollection.Add(blackOutDays);

            }
        }

        private IEnumerable<DateTime> GetDaysBetween(DateTime value3, DateTime value4)
        {
            List<DateTime> days_list = new List<DateTime>();
            for (DateTime date = value3; date <= value4; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    days_list.Add(date);
            }

            return days_list;
        }
    }
}
