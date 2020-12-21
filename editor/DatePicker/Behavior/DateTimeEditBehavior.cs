#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Windows;

namespace syncfusion.editordemos.wpf
{
    public class DateTimeEditBehavior : Behavior<DateTimeEditDemo>
    {
        private DateTimeEditViewModel viewModel;

        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnAssociatedObjectLoaded;
        }

        protected override void OnDetaching()
        {
            foreach (DateTimeEdit dateTimeEdit in Syncfusion.Windows.Shared.VisualUtils.EnumChildrenOfType(AssociatedObject, typeof(DateTimeEdit)))
            {
                dateTimeEdit.GotFocus -= OnDateTimeEditGotFocus;
                dateTimeEdit.Loaded -= OnDateTimeEditLoaded;
            }

            AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
            base.OnDetaching();
        }

        private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            viewModel = AssociatedObject.DataContext as DateTimeEditViewModel;
            foreach (DateTimeEdit dateTimeEdit in Syncfusion.Windows.Shared.VisualUtils.EnumChildrenOfType(AssociatedObject, typeof(DateTimeEdit)))
            {
                dateTimeEdit.Loaded += OnDateTimeEditLoaded;
                dateTimeEdit.GotFocus += OnDateTimeEditGotFocus;
            }
        }

        private void OnDateTimeEditLoaded(object sender, RoutedEventArgs e)
        {
            DateTimeEdit dateTimeEdit = sender as DateTimeEdit;
            if (dateTimeEdit.Name == "blackOutDates")
            {
                CalendarDateRange blackOutDays = new CalendarDateRange();
                DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 2);
                blackOutDays = new CalendarDateRange() { Start = StartDate, End = EndDate };
                Calendar calendar = dateTimeEdit.DateTimeCalender as Calendar;
                calendar.BlackoutDates.Add(blackOutDays);
            }
        }

        private void OnDateTimeEditGotFocus(object sender, RoutedEventArgs e)
        {
            DateTimeEdit focusedDateTimeEdit = sender as DateTimeEdit;
            viewModel.EnablePattern = focusedDateTimeEdit == AssociatedObject.patternDT;
            viewModel.EnableCulture = focusedDateTimeEdit == AssociatedObject.cultureDT;
            viewModel.EnableMinMax = focusedDateTimeEdit == AssociatedObject.validationDT ||
                                     focusedDateTimeEdit == AssociatedObject.minDateTime ||
                                     focusedDateTimeEdit == AssociatedObject.maxDateTime;
        }
    }
}
