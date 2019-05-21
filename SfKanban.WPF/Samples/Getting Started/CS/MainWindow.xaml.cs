#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Kanban;
using Syncfusion.Windows.SampleLayout;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GettingStarted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var workflow = new WorkflowCollection();
            workflow.Add(new KanbanWorkflow() { Category = "Open", AllowedTransitions = { "InProgress", "Closed", "Closed NoChanges", "Won't Fix" } });
            workflow.Add(new KanbanWorkflow() { Category = "Postponed", AllowedTransitions = { "Open", "InProgress", "Closed", "Closed NoChanges", "Won't Fix" } });
            workflow.Add(new KanbanWorkflow() { Category = "Review", AllowedTransitions = { "InProgress", "Closed", "Postponed" } });

            workflow.Add(new KanbanWorkflow() { Category = "InProgress", AllowedTransitions = { "Review", "Postponed" } });

            Kanban.Workflows = workflow;
        }
    }

    public class TaskDetails
    {
        public TaskDetails()
        {
            Tasks = new ObservableCollection<KanbanModel>();

            KanbanModel task = new KanbanModel();
            task.Title = "UWP Issue";
            task.ID = "6593";
            task.Description = "Sorting is not working properly in DateTimeAxis";
            task.Category = "Postponed";
            task.ColorKey = "High";
            task.Tags = new string[] { "Bug Fixing" };
            task.ImageURL = new Uri(@"Images/Image0.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "New Feature";
            task.ID = "6593";
            task.Description = "Need to create code base for Gantt control";
            task.Category = "Postponed";
            task.ColorKey = "Low";
            task.Tags = new string[] { "GanttControl UWP" };
            task.ImageURL = new Uri(@"Images/Image1.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "UG";
            task.ID = "6516";
            task.Description = "Need to do post processing work for closed incidents";
            task.Category = "Postponed";
            task.ColorKey = "Normal";
            task.Tags = new string[] { "Post processing" };
            task.ImageURL = new Uri(@"Images/Image2.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "UWP Issue";
            task.ID = "651";
            task.Description = "Crosshair label template not visible in UWP.";
            task.Category = "Open";
            task.ColorKey = "High";
            task.Tags = new string[] { "Bug Fixing" };
            task.ImageURL = new Uri(@"Images/Image3.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "UWP Issue";
            task.ID = "646";
            task.Description = "AxisLabel cropped when rotate the axis label.";
            task.Category = "Open";
            task.ColorKey = "Low";
            task.Tags = new string[] { "Bug Fixing" };
            task.ImageURL = new Uri(@"Images/Image4.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "WPF Issue";
            task.ID = "23822";
            task.Description = "Need to implement tooltip support for histogram series.";
            task.Category = "Open";
            task.ColorKey = "High";
            task.Tags = new string[] { "Bug Fixing" };
            task.ImageURL = new Uri(@"Images/Image0.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "Kanban Feature";
            task.ID = "25678";
            task.Description = "Need to prepare SampleBrowser sample";
            task.Category = "InProgress";
            task.ColorKey = "Low";
            task.Tags = new string[] { "New control" };
            task.ImageURL = new Uri(@"Images/Image5.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "WP Issue";
            task.ID = "1254";
            task.Description = "HorizontalAlignment for tooltip is not working";
            task.Category = "InProgress";
            task.ColorKey = "High";
            task.Tags = new string[] { "Bug fixing" };
            task.ImageURL = new Uri(@"Images/Image2.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "WPF Issue";
            task.ID = "28066";
            task.Description = "In minimized state, first and last segment have incorrect spacing";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.Tags = new string[] { "Bug Fixing" };
            task.ImageURL = new Uri(@"Images/Image1.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "WPF Issue";
            task.ID = "29477";
            task.Description = "Null reference exception thrown in line chart";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.Tags = new string[] { "Bug Fixing" };
            task.ImageURL = new Uri(@"Images/Image7.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "WPF Issue";
            task.ID = "29574";
            task.Description = "Minimum and maximum property are not working in dynamic update";
            task.Category = "Review";
            task.ColorKey = "High";
            task.Tags = new string[] { "Bug Fixing" };
            task.ImageURL = new Uri(@"Images/Image0.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "Kanban Feature";
            task.ID = "29574";
            task.Description = "Need to implement tooltip support for SfKanban";
            task.Category = "Review";
            task.ColorKey = "High";
            task.Tags = new string[] { "New Control" };
            task.ImageURL = new Uri(@"Images/Image4.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "New Feature";
            task.ID = "29574";
            task.Description = "Dragging events support for SfKanban";
            task.Category = "Closed";
            task.ColorKey = "Normal";
            task.Tags = new string[] { "New Control" };
            task.ImageURL = new Uri(@"Images/Image5.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);

            task = new KanbanModel();
            task.Title = "New Feature";
            task.ID = "29574";
            task.Description = "Swimlane support for SfKanban";
            task.Category = "Open";
            task.ColorKey = "Low";
            task.Tags = new string[] { "New Control" };
            task.ImageURL = new Uri(@"Images/Image8.png", UriKind.RelativeOrAbsolute);
            Tasks.Add(task);
        }
        public ObservableCollection<KanbanModel> Tasks { get; set; }
    }
}
