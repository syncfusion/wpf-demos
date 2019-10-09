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
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Media;

namespace CalendarDemo
{
    public class ViewModel : NotificationObject
    {

        public ViewModel()
        {
            SelectionChangedCommand = new DelegateCommand<object>(SelectionChanged);
            BlackOutWeekends(new DateTime(2019, 01, 09), new DateTime(2019, 03, 22));
        }

        private ICommand selectionChangedCommand;

        public ICommand SelectionChangedCommand
        {
            get
            {
                return selectionChangedCommand;
            }
            set
            {
                selectionChangedCommand = value;
                RaisePropertyChanged("SelectionChangedCommand");
            }
        }
       
        private Object culture = "en-US";

        public Object CultureString
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

        private bool showAbbrivatedDays = true;

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

        private bool showAbbrivatedMonths = true;

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

        private bool enableDateSelection = true;

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

        private bool enableMultipleSelection = true;

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

        private object visualStyle = "Office2016Colorful";

        public object VisualStyle
        {
            get
            {
                return visualStyle;
            }
            set
            {
                visualStyle = value; RaisePropertyChanged("VisualStyle");
            }
        }


        private BlackoutDatesCollection blackoutDates = new BlackoutDatesCollection();

        private BlackoutDatesCollection BlackOutDatesCollection
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

        private void SelectionChanged(object obj)
        {
            SfSkinManager.SetVisualStyle((obj as Window1) as Visual, (VisualStyles)Enum.Parse(typeof(VisualStyles), (VisualStyle as ComboBoxItemAdv).Content.ToString()));
            if ((obj as Window1).MaxAndMinDays != null)
            {
                (obj as Window1).MaxAndMinDays.BlackoutDates = BlackOutDatesCollection;
            }
        }
       
    }

    public class StringToCultureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is ComboBoxItem)
                return (value as ComboBoxItem).Content.ToString();

            return "en-US";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
