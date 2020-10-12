#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;

namespace syncfusion.dockingmanagerdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LinkedManager : ChromelessWindow
    {
        static int count = 0;
        public static List<LinkedManager> windowlist = new List<LinkedManager>();

        public LinkedManager(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
            this.Closed += LinkedManager_Closed;
            this.Loaded += (sender, args) =>
            {
                if (count == 0)
                {
                    count++;
                    windowlist.Add(this);
                    this.Left = 50;
                    this.Top = 100;
                    LinkedManager linkedManager = new LinkedManager(themename);
                    linkedManager.Title = "Docking Manager " + count;
                    linkedManager.Owner = this;
                    linkedManager.Show();
                    windowlist.Add(linkedManager);
                    linkedManager.Left = 700;
                    linkedManager.Top = 100;
                    this.clientdockingManager.AddToTargetManagersList(linkedManager.clientdockingManager);
                    linkedManager.clientdockingManager.AddToTargetManagersList(this.clientdockingManager);
                    this.Add.IsChecked = true;
                    linkedManager.Add.IsChecked = true;
                }
            };
        }

        private void LinkedManager_Closed(object sender, EventArgs e)
        {
            LinkedManager MainWindow = sender as LinkedManager;
            windowlist.Remove(MainWindow);
            if(windowlist.Count == 0)
            {
                count = 0;
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
            LinkedManager linkedManager = new LinkedManager(SfSkinManager.GetTheme(this).ThemeName);
            linkedManager.Title = "Docking Manager " + count;
            linkedManager.Owner = this;
            linkedManager.Show();
            windowlist.Add(linkedManager);
            linkedManager.Left = 400;
            linkedManager.Top = 200;
        }
       
        /// <summary>
        /// Handles the Click event of the AddToTargetManagerList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void AddToTargetManagerList_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuitem = sender as MenuItem;
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
                for (int i = 0; i < windowlist.Count; i++)
                {
                    LinkedManager window = windowlist[i] as LinkedManager;
                    if (!window.Title.Equals(this.Title))
                    {
                        this.clientdockingManager.AddToTargetManagersList(window.clientdockingManager);
                        window.clientdockingManager.AddToTargetManagersList(this.clientdockingManager);
                    }
                }
            }
            else
            {
                for (int i = 0; i < windowlist.Count; i++)
                {
                    LinkedManager window = windowlist[i] as LinkedManager;
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
