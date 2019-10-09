#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using Syncfusion.ProjIO;

namespace EssentialProjIOSamples
{
    /// <summary>
    /// Interaction logic for CreateEmptyTask.xaml
    /// </summary>
    public partial class CreateProject : Window
    {
        #region Constants
        private const string DEFAULTIMAGEPATH = @"..\..\..\..\..\..\..\..\Common\Images\ProjIO\{0}";         
        private const string outputFileName = "NewProject.xml";
        private string CurrentDirectory = string.Empty;
        #endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public CreateProject()
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
        /// Creates Project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of Project
            Project project = new Project();

            //creating a new task
            Task task = new Task("Hello World task");

            //specifying the start date and duration for the task
            task.Start = DateTime.Now;
            task.Duration = TimeSpan.FromHours(16);

            //Add the task to the project
            project.RootTask.Children.Add(task);

            //Invoking this method to recalculate IDs of the task present in the project
            project.CalculateTaskIDs();

            // Save the project
            project.Save(outputFileName);

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