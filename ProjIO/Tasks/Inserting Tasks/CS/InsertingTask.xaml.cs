#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Media;
using Syncfusion.ProjIO;
using System;
using System.Diagnostics;
using System.ComponentModel;

namespace EssentialProjIOSamples
{
    /// <summary>
    /// Interaction logic for InsertingTask.xaml
    /// </summary>
    public partial class InsertingTask : Window
    {
        #region Constants
        private const string DEFAULTIMAGEPATH = @"..\..\..\..\..\..\..\..\Common\Images\ProjIO\{0}";
        private const string outputFileName = "NewTasks.xml";
        private string CurrentDirectory = string.Empty;
        #endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public InsertingTask()
        {
            InitializeComponent();
            CurrentDirectory = Environment.CurrentDirectory;
            ImageSourceConverter img = new ImageSourceConverter();
            string headerImage = GetFullImagePath("ProjIOHeader.png");
            this.image1.Source = (ImageSource)img.ConvertFromString(headerImage);
            string icon = GetFullImagePath("ProjIOIcon.ico");
            this.Icon = (ImageSource)img.ConvertFromString(icon);
        }
        # endregion

        # region Events
        /// <summary>
        ///   Creates Project with tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of Project
            Project project = new Project();

            //creating a new tasks
            Task scopeTask = CreateTask("Scope", new DateTime(2011, 12, 5), new DateTime(2011, 12, 19));// TimeSpan.FromHours(80));5
            scopeTask.Duration = new TimeSpan(80, 0, 0);
            //scopeTask.IsSummary = true;
            Task detProjectScopeTask = CreateTask("Determine project scope", new DateTime(2011, 12, 5), new DateTime(2011, 12, 7));// TimeSpan.FromHours(16));
            Task secureProjectScopeTask = CreateTask("Secure Project sponsorship", new DateTime(2011, 12, 8), new DateTime(2011, 12, 9)); //TimeSpan.FromHours(16));
            Task defPreliminaryTask = CreateTask("Define preliminary resources", new DateTime(2011, 12, 10), new DateTime(2011, 12, 13)); //TimeSpan.FromHours(16));
            Task secureCoreResourcesTask = CreateTask("Secure core resources", new DateTime(2011, 12, 14), new DateTime(2011, 12, 15)); //TimeSpan.FromHours(16));
            Task secureCompleteTask = CreateTask("Secure Complete", new DateTime(2011, 12, 16), new DateTime(2011, 12, 19)); //TimeSpan.FromHours(16));

            //Adding the subtasks into the parent task.
            scopeTask.Children.Add(detProjectScopeTask);
            scopeTask.Children.Add(secureProjectScopeTask);
            scopeTask.Children.Add(defPreliminaryTask);
            scopeTask.Children.Add(secureCoreResourcesTask);
            scopeTask.Children.Add(secureCompleteTask);

            //Add the scope task to the project
            project.RootTask.Children.Add(scopeTask);

            //Invoking this method to recalculate IDs of the task present in the project
            project.CalculateTaskIDs();

            // Create task links
            TaskLink scopeLink = new TaskLink(detProjectScopeTask, secureProjectScopeTask, TaskLinkType.FinishToStart);
            TaskLink sponsorLink = new TaskLink(secureProjectScopeTask, defPreliminaryTask, TaskLinkType.FinishToStart);
            TaskLink preLink = new TaskLink(defPreliminaryTask, secureCoreResourcesTask, TaskLinkType.FinishToStart);
            TaskLink coreLink = new TaskLink(secureCoreResourcesTask, secureCompleteTask, TaskLinkType.FinishToStart);

            // Save the project
            project.Save(outputFileName);

            //Message box confirmation to view the created project.
            if (MessageBox.Show("Do you want to view the Project file?", "Project file has been created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo("WINPROJ.exe");
                    startInfo.Arguments =  GetFileLocation();
                    Process.Start(startInfo);

                    //Exit
                    this.Close();
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show("MS Project is not installed in this system");
                    Console.WriteLine(ex.ToString());
                }
            }
            else
                // Exit
                this.Close();
        }

        /// <summary>
        /// Create a task with the specified properties
        /// </summary>
        /// <param name="taskName">The name of the task</param>
        /// <param name="startTime">The start time of the task</param>
        /// <param name="duration">The duration for the task</param>
        /// <returns>Returns the created task</returns>
        private Task CreateTask(string taskName, DateTime startTime, DateTime finishTime)
        {
            //creating a new task
            Task task = new Task(taskName);
            //specifying the start date and duration for the task
            task.Start = startTime;
            task.Finish = finishTime;
            task.Duration = new TimeSpan(16, 0, 0);
            return task;
        }
        # endregion

        #region HelperMethods
        /// <summary>
        /// Get the input file and return the path of input file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
       
        private string GetFullImagePath(string imageFile)
        {
            return string.Format(DEFAULTIMAGEPATH, imageFile);
        }
        private string GetFileLocation()
        {
            return "\"" + CurrentDirectory + "\\" + outputFileName + "\"";
        }
        #endregion

    }
}