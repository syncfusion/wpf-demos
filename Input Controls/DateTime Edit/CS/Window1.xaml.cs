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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;

namespace DateTimeEditDemo
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        #region Constructor

        public Window2()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
            {
                foreach (DateTimeEdit dateTimeEdit in FindVisualChildren<DateTimeEdit>(this))
                {
                    dateTimeEdit.Loaded += (s, args) =>
                    {
                        if (dateTimeEdit.Name == "blackOutDates")
                        {
                            Syncfusion.Windows.Controls.CalendarDateRange blackOutDays = new Syncfusion.Windows.Controls.CalendarDateRange();                           
                            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            /*DateTime.DaysInMonth(CurrentDateTime.Year, CurrentDateTime.Month)*/
                            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 2);
                            blackOutDays = new Syncfusion.Windows.Controls.CalendarDateRange() { Start = StartDate, End = EndDate };
                            Syncfusion.Windows.Controls.Calendar calendar = dateTimeEdit.DateTimeCalender as Syncfusion.Windows.Controls.Calendar;
                            calendar.BlackoutDates.Add(blackOutDays);
                        }
                    };
                    dateTimeEdit.GotFocus += (s, args) =>
                    {
                        focusedDateTimeEdit = s as DateTimeEdit;

                        if (focusedDateTimeEdit == patternDT)
                            cmbopattern.IsEnabled = true;
                        else
                            cmbopattern.IsEnabled = false;

                        if (focusedDateTimeEdit == cultureDT)
                            comboculture.IsEnabled = true;
                        else
                            comboculture.IsEnabled = false;

                        if (focusedDateTimeEdit == validationDT || focusedDateTimeEdit == minDateTime || focusedDateTimeEdit == maxDateTime)
                            minDateTime.IsEnabled = true;
                        else
                            minDateTime.IsEnabled = false;
                    };
                }
            };
        }

        DateTimeEdit focusedDateTimeEdit;

        #endregion

        #region Helper Methods

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        #endregion

    }
}
