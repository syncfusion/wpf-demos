#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// Represents a ViewModel that manages the task details for a swimlane in a Kanban board. 
    /// </summary>
    public class SwimlaneViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Stores the collection of <see cref="KanbanModel"/> objects.
        /// </summary>
        private ObservableCollection<KanbanModel> taskDetails;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SwimlaneViewModel"/> class.
        /// </summary>
        public SwimlaneViewModel()
        {
            this.TaskDetails = this.GetTaskDetails();            
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the collection of <see cref="KanbanModel"/> objects representing tasks in various stages.
        /// </summary>
        public ObservableCollection<KanbanModel> TaskDetails
        {
            get
            {
                return this.taskDetails;
            }
            set
            {
                this.taskDetails = value;
                this.OnPropertyChanged(nameof(TaskDetails));
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to get the kanban model collections.
        /// </summary>
        /// <returns>The kanban model collections.</returns>
        private ObservableCollection<KanbanModel> GetTaskDetails()
        {
            var taskDetails = new ObservableCollection<KanbanModel>();

            KanbanModel task = new KanbanModel();
            task.Title = "Application performance";
            task.ID = "2";
            task.Assignee = "Andrew Fuller";
            task.Description = "Improve application performance.";
            task.Category = "Backlog";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Analysis";
            task.ID = "18";
            task.Assignee = "Andrew Fuller";
            task.Description = "Analyze SQL server 2008 connection.";
            task.Category = "In Progress";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Editing";
            task.ID = "25";
            task.Assignee = "Andrew Fuller";
            task.Description = "Enhance editing functionality.";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Editing";
            task.ID = "37";
            task.Assignee = "Andrew Fuller";
            task.Description = "Add input validation for editing.";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Customer meeting";
            task.ID = "42";
            task.Assignee = "Andrew Fuller";
            task.Description = "Arrange a web meeting with the customer to show filtering demo.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Filtering issue";
            task.ID = "45";
            task.Assignee = "Andrew Fuller";
            task.Description = "Fix the filtering issues reported in Safari.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Filtering feature";
            task.ID = "49";
            task.Assignee = "Andrew Fuller";
            task.Description = "Enhance filtering feature.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Customer meeting";
            task.ID = "3";
            task.Assignee = "Janet Leverling";
            task.Description = "Arrange a web meeting with the customer to get new requirements.";
            task.Category = "Backlog";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Edge browser issues";
            task.ID = "4";
            task.Assignee = "Janet Leverling";
            task.Description = "Fix the issues reported in the Edge browser.";
            task.Category = "In Progress";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "SQL error";
            task.ID = "16";
            task.Assignee = "Janet Leverling";
            task.Description = "Fix cannot open user's default database SQL error.";
            task.Category = "In Progress";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Chrome issue";
            task.ID = "28";
            task.Assignee = "Janet Leverling";
            task.Description = "Fix editing issues reported in Chrome.";
            task.Category = "In Progress";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Data binding issues";
            task.ID = "17";
            task.Assignee = "Janet Leverling";
            task.Description = "Fix the issues reported in data binding.";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Customer issues";
            task.ID = "29";
            task.Assignee = "Janet Leverling";
            task.Description = "Fix the editing issues reported by customer.";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Analysis";
            task.ID = "22";
            task.Assignee = "Janet Leverling";
            task.Description = "Analyze stored procedures.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Editing feature";
            task.ID = "34";
            task.Assignee = "Janet Leverling";
            task.Description = "Test editing feature in the Edge browser.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Filtering feature";
            task.ID = "46";
            task.Assignee = "Janet Leverling";
            task.Description = "Test filtering in the Edge browser.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Responsive support";
            task.ID = "14";
            task.Assignee = "Laura Callahan";
            task.Description = "Add responsive support to application.";
            task.Category = "In Progress";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle13.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Filtering feature";
            task.ID = "48";
            task.Assignee = "Laura Callahan";
            task.Description = "Check filtering validation.";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle13.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Login validation";
            task.ID = "8";
            task.Assignee = "Laura Callahan";
            task.Description = "Login page validation.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle13.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Data in Grid";
            task.ID = "15";
            task.Assignee = "Margaret Hamilt";
            task.Description = "Show the retrieved data from the server in grid control.";
            task.Category = "Backlog";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle9.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Filtering issues";
            task.ID = "40";
            task.Assignee = "Margaret Hamilt";
            task.Description = "Fix filtering issues reported in the Edge browser.";
            task.Category = "In Progress";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle9.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "New Feature";
            task.ID = "10";
            task.Assignee = "Margaret Hamilt";
            task.Description = "Need to create code base for Gantt control";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle9.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Analysis";
            task.ID = "20";
            task.Assignee = "Margaret Hamilt";
            task.Description = "Analyze grid control.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle9.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Customer meeting";
            task.ID = "39";
            task.Assignee = "Michael Smith";
            task.Description = "Arrange a web meeting with the customer to get new filtering requirements.";
            task.Category = "Backlog";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle35.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "WPF Issue";
            task.ID = "12";
            task.Assignee = "Michael Smith";
            task.Description = "Need to implement tooltip support for histogram series";
            task.Category = "Review";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle35.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            task = new KanbanModel();
            task.Title = "Customer meeting";
            task.ID = "6";
            task.Assignee = "Michael Smith";
            task.Description = "Arrange a web meeting with the customer to get the login page requirements.";
            task.Category = "Done";
            task.ColorKey = "Normal";
            task.ImageURL = new Uri(@"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle35.png", UriKind.RelativeOrAbsolute);
            taskDetails.Add(task);

            return taskDetails;
        }

        #endregion

        #region PropertyChanged

        /// <summary>
        /// Event that is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to raise the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}