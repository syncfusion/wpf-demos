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
    /// Interaction logic for InsertingResources.xaml
    /// </summary>
    public partial class InsertingResources : Window
    {
        #region Constants
        private const string DEFAULTIMAGEPATH = @"..\..\..\..\..\..\..\..\Common\Images\ProjIO\{0}";
        private const string DEFAULTPATH = @"..\..\..\..\..\..\..\..\Common\Data\ProjIO\{0}";
        private string outputFileName = "ResourceInsertedTask.xml";
        private string CurrentDirectory = string.Empty;
        #endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public InsertingResources()
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
        private void btnInsertResources_Click(object sender, RoutedEventArgs e)
        {
            Project project = new Project();

            //Get the path of the input file
            string inputPath = GetFullTemplatePath("NewTasks.xml");
            project = ProjectReader.Open(inputPath);
            //Create Resources
            Resource managerResource = new Resource();
            managerResource.Name = "Product Manager";

            Resource managerResource1 = new Resource();
            managerResource1.Name = "Resource Manager";

            Resource leaderResource = new Resource();
            leaderResource.Name = "Team Leader";

            //Add resources to project
            project.Resources.Add(managerResource);
            project.Resources.Add(managerResource1);
            project.Resources.Add(leaderResource);

            //Invoke method to calculate Resource ID
            project.CalculateResourceIDs();

            //Create Assignments
            Assignment scopeAssign = new Assignment();
            scopeAssign.Task = project.GetTaskByUID(2);
            scopeAssign.Resource = managerResource;

            Assignment sponsorAssign = new Assignment();
            sponsorAssign.Task = project.GetTaskByUID(3);
            sponsorAssign.Resource = managerResource;

            Assignment taskAssign = new Assignment();
            taskAssign.Task = project.GetTaskByUID(4);
            taskAssign.Resource = managerResource1;

            Assignment taskAssign1 = new Assignment();
            taskAssign1.Task = project.GetTaskByUID(5);
            taskAssign1.Resource = leaderResource;

            Assignment taskAssign2 = new Assignment();
            taskAssign2.Task = project.GetTaskByUID(6);
            taskAssign2.Resource = leaderResource;

            //Add assignments to project
            project.Assignments.Add(scopeAssign);
            project.Assignments.Add(sponsorAssign);
            project.Assignments.Add(taskAssign);
            project.Assignments.Add(taskAssign1);
            project.Assignments.Add(taskAssign2);

            // Save the project
            project.Save(outputFileName);

            project = ProjectReader.Open(outputFileName);

            //Message box confirmation to view the created project.
            if (MessageBox.Show("Do you want to view the Project file?", "Project file has been created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo("WINPROJ.exe");
                    startInfo.Arguments = GetFileLocation();
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

        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }
        
        /// <summary>
        /// Get the input image and return the path of the same
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