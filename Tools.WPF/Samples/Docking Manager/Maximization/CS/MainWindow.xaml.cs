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
using Syncfusion.Windows.Tools.Controls;

namespace MaximizeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SubmenuOpened event of the MaximizeMode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void MaximizeMode_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;

            foreach (Control control in item.Items)
            {
                if (control is MenuItem)
                {
                    MenuItem subitem = control as MenuItem;
                    string header = (string)subitem.Header;
                    if (dockingManager.MaximizeMode == MaximizeMode.FullScreen)
                    {
                        subitem.IsChecked = true;
                    }
                    else
                    {
                        subitem.IsChecked = false;
                    }
                }
            }
        }

        /// <summary>
        /// Called when [maximize mode changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnMaximizeModeChanged(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            string header = (string)item.Header;
            if (!item.IsChecked)
            {
                dockingManager.MaximizeMode = MaximizeMode.FullScreen;
            }
            else
            {
                dockingManager.MaximizeMode = MaximizeMode.Default;
            }
        }

        /// <summary>
        /// Called when [max min changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnMaxMinChanged(object sender, RoutedEventArgs e)
        {
            if (dockingManager.ActiveWindow != null)
            {
                MenuItem item = sender as MenuItem;
                FrameworkElement element = dockingManager.ActiveWindow;
                string header = (string)item.Header;
                if (element != null)
                {
                    switch (header)
                    {
                        case "CanMaximize":
                            if (DockingManager.GetDockWindowState(element) != WindowState.Maximized)
                            {
                                DockingManager.SetCanMaximize(element, !item.IsChecked);
                            }
                            break;
                        case "CanMinimize":
                            if (DockingManager.GetDockWindowState(element) != WindowState.Minimized)
                            {
                                DockingManager.SetCanMinimize(element, !item.IsChecked);
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the SubmenuOpened event of the activewindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void activewindow_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            if (dockingManager.ActiveWindow != null)
            {
                MenuItem item = sender as MenuItem;
                FrameworkElement element = dockingManager.ActiveWindow;

                foreach (Control control in item.Items)
                {
                    if (control is MenuItem)
                    {
                        MenuItem subitem = control as MenuItem;
                        string header = (string)subitem.Header;

                        switch (header)
                        {
                            case "CanMaximize":
                                subitem.IsChecked = DockingManager.GetCanMaximize(element);
                                break;
                            case "CanMinimize":
                                subitem.IsChecked = DockingManager.GetCanMinimize(element);
                                break;
                        }
                    }
                }
            } 
        }
    }
}
