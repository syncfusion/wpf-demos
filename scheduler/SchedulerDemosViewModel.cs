#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
            this.Tag = Tag.Preview;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Tag = Tag.Updated, Description = "This sample showcases the following capabilities of the SfScheduler.\n \u2022 Customization of day, week, workweek, month, and timeline views in schedule. \n \u2022 Bind ScheduleAppointmentCollection to ItemSource. \n \u2022 Blackout dates in the month view. \n \u2022 Context menu to add, edit, and delete appointments.\n \u2022 Minimum date and maximum date to restrict date navigation.", GroupName = "GETTING STARTED", DemoViewType = typeof(GettingStartedDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Binding", Description = "The scheduler control provides support to bind any collection that implements the IEnumerable interface to populate appointments.This sample showcases the following capabilities of the SfScheduler. \n \u2022 Map properties of data object to ScheduleAppointment.\n \u2022 Bind custom data collection to ItemSource", GroupName = "GETTING STARTED", DemoViewType = typeof(DataBindingDemo)});

            this.Demos.Add(new DemoInfo() { SampleName = "Appointment", Description = "This sample showcases the customization capabilities of the scheduler appointment control.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(AppointmentCustomizationDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Time Slot", Description = "This sample showcases the following capabilities of the SfScheduler.\n \u2022 Navigate to specific dates in view.\n \u2022 Hide/show time values and header in view.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(TimeSlotCustomizationDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Month Cell", Description = "This sample showcases the customization capabilities of a scheduler month cell.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(MonthCellCustomizationDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Speical Time Region", Description = "This sample showcases how to add the SpecialTimeRegion and customize its appearance using the DataTemplate in SfScheduler. The SpecialTimeRegion is used for restricting user interactions such as selection, highlighting specific regions of time, and editing data in the scheduler.", GroupName = "CUSTOMIZATION", DemoViewType = typeof(SpecialTimeRegionCustomizationDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Recurring Appointments", Description = "This sample showcases how to create recurring appointments on daily, weekly, monthly, and yearly intervals in SfScheduler.", GroupName = "APPOINTMENTS", DemoViewType = typeof(RecurringAppointmentsDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Recurring Appointment with Exception", Description = "This sample showcases the following capabilities of the SfScheduler.\n \u2022 Generate recurring appointments on daily, weekly, monthly, and yearly intervals. \n \u2022 Avoid the occurrence of recurring appointments on specific dates. \n \u2022 Create and add the changed occurrence of recurring appointments.", GroupName = "APPOINTMENTS", DemoViewType = typeof(RecurrencewithExceptionDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Resource", Tag = Tag.New, GroupName = "Resources", Description = "This sample showcases the following capabilities of the SfScheduler.\n \u2022 Display or group appointments based on different resources.\n \u2022 Display the resources when the scheduler is grouped by either resource or date\n \u2022 Customize the resource view by using the DataTemplate \n \u2022 Map custom resources and appointments data for scheduler resources.", DemoViewType = typeof(ResourceDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Drag and Drop", Tag = Tag.New, GroupName = "Drag and Drop", Description = "Scheduler allows drag and drop the appointments in all views and this sample showcases the drag and drop behavior between ListView and Scheduler.", DemoViewType = typeof(DragandDropDemo) });
        }
    }
}
