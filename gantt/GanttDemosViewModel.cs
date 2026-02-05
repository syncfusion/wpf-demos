#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.ganttdemos.wpf
{
    public class GanttDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new GanttProductDemos());
            return productdemos;
        }
    }

    public class GanttProductDemos : ProductDemo
    {
        public GanttProductDemos()
        {
            this.Product = "Gantt";
            this.ProductCategory = "DATA VISUALIZATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M0 1C0 0.447715 0.447715 0 1 0H5C5.55228 0 6 0.447715 6 1V1.5H6.6C7.3732 1.5 8 2.1268 8 2.9V6H10C10.5523 6 11 6.44772 11 7V7.5H11.6C12.3732 7.5 13 8.1268 13 8.9V12H15C15.5523 12 16 12.4477 16 13V15C16 15.5523 15.5523 16 15 16H10C9.44771 16 9 15.5523 9 15V13C9 12.4477 9.44772 12 10 12H12V8.9C12 8.67909 11.8209 8.5 11.6 8.5H11V9C11 9.55229 10.5523 10 10 10H5C4.44772 10 4 9.55229 4 9V7C4 6.44772 4.44772 6 5 6H7V2.9C7 2.67909 6.82091 2.5 6.6 2.5H6V3C6 3.55228 5.55228 4 5 4H1C0.447715 4 0 3.55228 0 3V1Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Gantt control is a UI tool for creating project schedules and timelines with an interactive view.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Gantt.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",
                GroupName = "GETTING STARTED",
                Description = "This sample illustrates how a control development project's activities have been scheduled using the Gantt control. The tasks are split up into sub-tasks based on work breakdown structure, and the sub-tasks are scheduled based on their dependent tasks. The connectivity between tasks represents their dependency relationship.",
                DemoViewType = typeof(EssentialGantt),
            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Gantt - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/gantt/getting-started")}
            };

            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);            
            this.Demos.Add(new DemoInfo() { SampleName = "Project Scheduler", GroupName = "GETTING STARTED", Description= "This sample showcases how the Gantt control can be used in real-time application development. This sample is a project analysis application that has been built using the Gantt control. Users can easily schedule and track their project works here by using this sample.", DemoViewType = typeof(ProjectScheduler) });
            this.Demos.Add(new DemoInfo() { SampleName = "Binding Task Details", GroupName = "DATA BINDING", Description= "Gantt control provides a built-in data model to hold the task/activities information. The name of this class is TaskDetails, it is inherited from an interface IGanttTask. Users can make use of this class to create their project information.  This sample will illustrate how the TaskDetails class has been used to create the project information and how the created TaskDetails collection is bounded to Gantt Control.", DemoViewType = typeof(BindingTaskDetails) });
            this.Demos.Add(new DemoInfo() { SampleName = "External Property Binding", GroupName = "DATA BINDING", Description= "Any external class collection can be bound to the Gantt control by mapping its attributes. Mapping can be done between the TaskAttributeMapping of Gantt and the attributes of external class. When a task node position changes, its corresponding data in the grid will automatically get updated and also the underlying source will get updated. This sample showcases how the Gantt control accepts an external collection as a data source.", DemoViewType = typeof(ExternalPropertyBinding) });
            this.Demos.Add(new DemoInfo() { SampleName = "Resource View Gantt", GroupName = "DATA BINDING", Description= "Essential Gantt allows you to populate multiple nodes in a single row by using inline task mapping. This sample showcases how to build a resource view Gantt using inline task mapping. It will reflect the work progress of the resources involved in a small control development process.", DemoViewType = typeof(ResourceView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Baseline Table View", GroupName = "BASELINE SUPPORT", Description= "A baseline table view provides the variance between the current progress and estimated progress of a project. This helps to check whether the project is moving at the estimated pace. This sample showcases how we can get the variances between the current progress and the baseline of the project in a table format in the Gantt grid. You can also switch back to the normal view by invoking the provided API.", DemoViewType = typeof(BaselineTableView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Project Statistics", GroupName = "BASELINE SUPPORT", Description= "Project statistics provide the current status of the project on the basis of timeline and budget. This sample illustrates how a house construction project's activities are carried out using the Gantt control and illustrates how the statistics can be displayed in a custom UI.", DemoViewType = typeof(ProjectStatistics) });
            this.Demos.Add(new DemoInfo() { SampleName = "Predecessors", GroupName = "CONNECTORS", Description= "This sample showcases how to set relationships between tasks in the Gantt control. The Gantt control includes four types of relationships: start to start, start to finish, finish to start, and finish to finish. A task can be set with any number of relationships.", DemoViewType = typeof(Predecessors) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom DateTime Schedule", GroupName = "CUSTOM SCHEDULE", Description= "A custom schedule will get the time definition from the application and render the schedule based on that. This sample showcases how a custom date-time Gantt schedule can be defined from the application level. Here the date-time schedule is customized as three months per cell in the month row and one year per cell in the years row.", DemoViewType = typeof(CustomDateTimeSchedule) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Numeric Schedule", GroupName = "CUSTOM SCHEDULE", ThemeMode = ThemeMode.Default, Description = "A custom numeric schedule will render tasks based on the custom measurement unit. This sample showcases how a bar chart can be drawn using a custom numeric schedule. Here the GDP growth of several countries in 2010 is listed as a bar chart. The top 35 countries (based on the GDP rank) are listed here.", DemoViewType = typeof(CustomNumericSchedule) });
            this.Demos.Add(new DemoInfo() { SampleName = "Customized Schedule", GroupName = "CUSTOM SCHEDULE", Description= "Gantt schedule cells can be customized at the sample level. This sample showcases how users can customize the appearance of the schedule. Here the schedule cells are customized to display the month unit as quarter 1 (Q1), quarter 2 (Q2) and so on.", DemoViewType = typeof(CustomizedScheduleAppearance) });
            this.Demos.Add(new DemoInfo() { SampleName = "Split Task Sample", GroupName = "SPLIT TASK", Description= "This sample visualizes the interrupt work on a task.", DemoViewType = typeof(SplitTaskSample) });
            this.Demos.Add(new DemoInfo() { SampleName = "Customized Table", GroupName = "TABEL CUSTOMIZATION", Description= "This sample showcases how to add and customize the columns of the grid in the Gantt control. In this sample, two new custom columns are added and existing column styles have been changed. Also, some existing columns have been removed.", DemoViewType = typeof(CustomizedTable) });
            this.Demos.Add(new DemoInfo() { SampleName = "Flat Data Performance", GroupName = "GANTT PERFORMANCE", Description= "This sample showcases how to add and customize the columns of the grid in the Gantt control. In this sample, two new custom columns are added and existing column styles have been changed. Also, some existing columns have been removed.", DemoViewType = typeof(FlatPerformanceCheck) });
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchy Data Performance", GroupName = "GANTT PERFORMANCE", Description= "This sample showcases the performance of the Gantt control with a hierarchical data collection as a data source. By changing the value in the Items text box and clicking Load button, the specified number of items will be generated and populated in the Gantt control. The time taken to populate the Gantt control will be displayed in the Loading Time text box.", DemoViewType = typeof(HierarchyPerformanceCheck) });
            this.Demos.Add(new DemoInfo() { SampleName = "Built-in Zooming", GroupName = "INTERACTIVE FEATURES", Description= "Zooming allows the user to zoom the schedule and chart of the Gantt control between year and minute time units. Built-in zooming will zoom in and zoom out of the schedule and chart region based on the zoom factor. The schedule type and cell size will be changed dynamically based on the zoom factor.", DemoViewType = typeof(BuiltinZooming) });
            this.Demos.Add(new DemoInfo() { SampleName = "Calendar Customization", GroupName = "INTERACTIVE FEATURES",Description= "This sample illustrates how to customize schedule calendar in Essential Gantt", DemoViewType = typeof(CalendarCustomization) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom ToolTip", GroupName = "INTERACTIVE FEATURES", Description = " This sample showcases how a custom tooltip can be set in the Gantt control for each and every task bar. Based on the specific task bar, the values in the tooltip will be changed.", DemoViewType = typeof(CustomToolTip) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Zooming", GroupName = "INTERACTIVE FEATURES", Description = "Zooming allows the user to zoom the schedule and chart of the Gantt control between year and minute time units. This sample will illustrate how the zooming can be achieved in the sample level by handling the ZoomChanged event of Gantt. Schedule row definitions and cell size can be dynamically changed at run time by handling the ZoomChanged event of Gantt.", DemoViewType = typeof(CustomZooming) });
            this.Demos.Add(new DemoInfo() { SampleName = "Highlighting Tasks", GroupName = "INTERACTIVE FEATURES", Description = "Highlighting tasks will allow the user to highlight a specific set of tasks in the Gantt chart region. This sample showcases how users can highlight the tasks that fall between a specified range of dates and the tasks that are in a critical path of the project.", DemoViewType = typeof(HighlightingTasks) });
            this.Demos.Add(new DemoInfo() { SampleName = "Striplines", GroupName = "INTERACTIVE FEATURES", Description = "Striplines in Gantt Control allows the user to place custom strips in Gantt Chart region. By using striplines user can specify the special dates, important works and can add the notes in Gantt Chart region. Absolute type of striplines allows the user to place strip in Absolute postion with Absolute measurement of strip", DemoViewType = typeof(GanttStripLine) });
            this.Demos.Add(new DemoInfo() { SampleName = "Critical Path", GroupName = "CRITICAL PATH", Description = "The longest sequence of activities in the project is critical path, all the tasks in this path are critical task, all the tasks in the critical path must be completed on planned time. If suppose any one of the critical task get delayed means, the whole project will be delayed.", DemoViewType = typeof(CriticalPath) });
            this.Demos.Add(new DemoInfo() { SampleName = "Export To Image", GroupName = "IMPORT EXPORT", Description = "Essential Gantt allows the user to export the Gantt Chart to RenderTargetBitmap image. This samples shows how to export the Gantt Chart in project Gantt and ResourceView Gantt to Image.", DemoViewType = typeof(ExportToImage) });
            this.Demos.Add(new DemoInfo() { SampleName = "Import and Export", GroupName = "IMPORT EXPORT", Description = "This sample showcases how the task details bounded to Gantt control can be Exported/Imported as an xml file. The XML file generated by Gantt can be opened in the MS Project vice versa. The xml file which is generated by the MS Project can be imported to the Gantt control", DemoViewType = typeof(ImportExportDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Metro Style", GroupName = "STYLES", ThemeMode = ThemeMode.Default, Description = "This sample showcases how the user can set the Metro style for Gantt Control with different colors. Here the windows phone 7 theme colors are used. User also can apply their own color for the Metro Theme.", DemoViewType = typeof(CustomMetroStyle) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Node Style", GroupName = "STYLES", ThemeMode = ThemeMode.Default, Description = "This sample showcases how a custom style can be set to the different Nodes of Gantt control. User can apply custom style to all the three type of nodes namely, Task bar, Header bar and Milestone.", DemoViewType = typeof(CustomNodeStyle) });
            this.Demos.Add(new DemoInfo() { SampleName = "Gantt Style Properties", GroupName = "STYLES", Description = "This sample illustrates the core features of the Gantt control and different ways of customizing them, such as applying background colors, foreground colors, border colors, and more.", DemoViewType = typeof(GanttStyleProperties) });
            this.Demos.Add(new DemoInfo() { SampleName = "Resource Name Customization", GroupName = "STYLES", Description= "Gantt control provides the way to customize the Resource name in Gantt Chart Region. User can customize the Resource Name using DataTemplate. By using Resource Container created and Resource Container Template Selector user can set the template for the Resource Name.", DemoViewType = typeof(ResourceNameCustomization) });
        }
    }
}
