#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.schedulerdemos.wpf
{
    public class SchedulerDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SchedulerProductDemos());
            return productdemos;
        }
    }
    public class SchedulerProductDemos : ProductDemo
    {
        public SchedulerProductDemos()
        {
            this.Product = "Scheduler";
            this.ProductCategory = "CALENDAR";
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "This sample showcases the scheduler views such as day, week, workweek and month views with scheduler appointments added. It also showcases the date navigation restriction within minimum and maximum scheduler date range, blackout dates restriction in month view and to navigate quickly to the day view by tapping on the month cell and view header of the scheduler views.", GroupName = "GETTING STARTED", DemoViewType = typeof(GettingStartedDemo), Tag = Tag.Updated });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Binding", Description = "This sample showcases to binding any business event object to the scheduler items source using the property mapping concept.", GroupName = "GETTING STARTED", DemoViewType = typeof(DataBindingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Timeline views", Description = "This sample showcases the scheduler timeline day, timeline week, timeline work week and timeline month views. It also showcases the capabilities of creating recurring appointments on daily, weekly, monthly, and yearly intervals in timeline day, timeline week, timeline work week and timeline month views, creating the recurrence appointment with exception date and changed occurrence of recurring series appointments and the capabilities of highlighting specific regions in timeslot cells and restricting user interactions such as selection, appointment creations.", GroupName = "GETTING STARTED", DemoViewType = typeof(TimelineViewsDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Appointment", Description = "This sample showcases the customization capabilities of the scheduler appointment control.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(AppointmentCustomizationDemo), ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Time Slot", Description = "This sample showcases the capabilities to navigate to specific dates in scheduler views, show or hide header view, time ruler label and 24 hours time ruler format in the scheduler.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(TimeSlotCustomizationDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Fare Calendar ", Description = "This sample showcases the customization capabilities of a scheduler month cell.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(MonthCellCustomizationDemo), ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Speical Time Region", Description = "This sample showcases the capabilities of highlighting specific regions in timeslot cells and restricting user interactions such as selection, appointment creation and customize the appearance of highlighted timeslot cells.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(SpecialTimeRegionCustomizationDemo), ThemeMode = ThemeMode.Default });

            this.Demos.Add(new DemoInfo() { SampleName = "Recurring Appointments", Description = "This sample showcases the capabilities of creating recurring appointments on daily, weekly, monthly, and yearly intervals in day, week, workweek and month views.", GroupName = "APPOINTMENTS", DemoViewType = typeof(RecurringAppointmentsDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Recurring Appointment with Exception", Description = "This sample showcases the capabilities of creating the recurrence appointment with exception date and changed occurrence of recurring series appointments.", GroupName = "APPOINTMENTS", DemoViewType = typeof(RecurrencewithExceptionDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Calendar Identifier", Description = "This example shows how to use the scheduler to set several calendar types such as Gregorian, Korean, Hebrew, and so on.", GroupName = "CALENDAR TYPES", DemoViewType = typeof(CalendarIdentifierDemo), Tag = Tag.New, });

            this.Demos.Add(new DemoInfo() { SampleName = "Horizontal Grouping", Description = "This sample showcases the capabilities to display or group appointments based on the resources in day, week and workweek views.", GroupName = "RESOURCES", DemoViewType = typeof(HorizontalResourceGroupingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Date-wise Grouping", Description = "This sample showcases the capabilities to display or group appointments based on the dates in day, week and workweek views.", GroupName = "RESOURCES", DemoViewType = typeof(DateWiseResourceGroupingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Timeline Grouping", Description = "This sample showcases the capabilities to display or group appointments based on the resources in timeline day, timeline week, timeline workweek and timeline month views.", GroupName = "RESOURCES", DemoViewType = typeof(TimelineResourceGroupingDemo), Tag = Tag.Updated });

            this.Demos.Add(new DemoInfo() { SampleName = "Load on demand", Description = "This sample showcases the appointment on demand loading capability of the scheduler with business event object binding.", GroupName = "LOAD ON DEMAND", DemoViewType = typeof(LoadOnDemandDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Reminder", Description = "This sample showcases the scheduler appointment reminder’s feature with business event object binding.", GroupName = "REMINDER", DemoViewType = typeof(ReminderDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Context Menu", Description = "This sample showcases the context menu to add, edit and delete the appointments by using the RoutedUICommands support for the time slots, month cells and scheduler appointments.", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(ContextMenuDemo), ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Drag and Drop", Description = "The scheduler allows drag and drop the appointments in all views and this sample showcases the drag and drop behavior between ListView and Scheduler.", GroupName = "INTERACTIVE FEATURES", DemoViewType = typeof(DragandDropDemo) });
        }
    }
}
