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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace LinkedManagerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int count = 0;
        public static List<MainWindow> windowlist = new List<MainWindow>();

        public MainWindow()
        {
            InitializeComponent();

            if (count == 0)
            {
                count++;
                windowlist.Add(this);
                this.Left = 50;
                this.Top = 100;
                MainWindow MainWindow = new MainWindow();
                MainWindow.Title = "Docking Manager " + count;
                MainWindow.Show();
                MainWindow.Closed += new EventHandler(MainWindow_Closed);
                windowlist.Add(MainWindow);
                MainWindow.Left = 700;
                MainWindow.Top = 100;
                this.clientdockingManager.AddToTargetManagersList(MainWindow.clientdockingManager);
                MainWindow.clientdockingManager.AddToTargetManagersList(this.clientdockingManager);
                this.Add.IsChecked = true;
                MainWindow.Add.IsChecked = true;
            }
        }

        /// <summary>
        /// Handles the TransferredFromManager event of the clientdockingManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Tools.Controls.TransferManagerEventArgs"/> instance containing the event data.</param>
        private void clientdockingManager_TransferredFromManager(object sender, Syncfusion.Windows.Tools.Controls.TransferManagerEventArgs e)
        {
            Debug.WriteLine("Transferred from " + e.PreviousManager + " to other Docking Manager " + e.TargetManager);
        }

        /// <summary>
        /// Handles the TransferredToManager event of the clientdockingManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Tools.Controls.TransferManagerEventArgs"/> instance containing the event data.</param>
        private void clientdockingManager_TransferredToManager(object sender, Syncfusion.Windows.Tools.Controls.TransferManagerEventArgs e)
        {
            Debug.WriteLine("Transferred to " + e.TargetManager + " from other Docking Manager " + e.PreviousManager);
        }

        /// <summary>
        /// Handles the Click event of the NewDockingWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void NewDockingWindow_Click(object sender, RoutedEventArgs e)
        {
            count++;
            MainWindow MainWindow = new MainWindow();
            MainWindow.Title = "Docking Manager " + count;
            MainWindow.Show();
            MainWindow.Closed += new EventHandler(MainWindow_Closed);
            windowlist.Add(MainWindow);
            MainWindow.Left = 400;
            MainWindow.Top = 200;
        }

        /// <summary>
        /// Handles the Closed event of the MainWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void MainWindow_Closed(object sender, EventArgs e)
        {
            MainWindow MainWindow = sender as MainWindow;
            string checkmenu = MainWindow.Title;
            for (int j = 0; j < windowlist.Count; j++)
            {
                MainWindow window = windowlist[j] as MainWindow;
                if (window.Title.Equals(MainWindow.Title))
                {
                    windowlist.Remove(window);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the AddToTargetManagerList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void AddToTargetManagerList_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuitem=sender as MenuItem;
            if (menuitem.IsChecked)
            {
                menuitem.IsChecked = false;
            }
            else
            {
                menuitem.IsChecked = true;
            }

            if (menuitem.IsChecked)
            {
                for (int i = 0;i< windowlist.Count; i++)
                {
                    MainWindow window = windowlist[i] as MainWindow;
                    if (!window.Title.Equals(this.Title))
                    {
                        this.clientdockingManager.AddToTargetManagersList(window.clientdockingManager);
                        window.clientdockingManager.AddToTargetManagersList(this.clientdockingManager);
                    }
                }
            }
            else
            {
                for (int i = 0; i<windowlist.Count; i++)
                {
                    MainWindow window = windowlist[i] as MainWindow;
                    if (!window.Title.Equals(this.Title))
                    {
                        this.clientdockingManager.RemoveFromTargetManagersList(window.clientdockingManager);
                        window.clientdockingManager.RemoveFromTargetManagersList(this.clientdockingManager);
                    }
                }
            }
        }
    }
}
