#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using System.Xml;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;
using WebBrowser = System.Windows.Forms.WebBrowser;


namespace DockingDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {


        #region Constructor

        /// <summary>
        /// Constructor for Window
        /// </summary>

        public Window1()
        {
            try
            {
                InitializeComponent();
                EventsLog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// Subscribe the events while creating object
        /// </summary>  
        public void EventsLog()
        {
            // Subscribe the DockingManager events
            this.DockingManager.Loaded += new RoutedEventHandler(DockingManager_Loaded);
        }


        #endregion

        #region Helper Methods


        /// <summary>
        /// Events occur while loading docking manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void DockingManager_Loaded(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
        }

        bool m_layoutflag = true;
        private void DockingManager_LayoutUpdated(object sender, EventArgs e)
        {
            if (m_layoutflag)
            {
                SkinStorage.SetVisualStyle(this, "Office2007Blue");
                m_layoutflag = false;
            }
        }

        /// <summary>
        /// Click event for containermode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void windowswitchers_Click(object sender, RoutedEventArgs e)
        {
            //Switch Mode of Docking Manager
            MenuItem mi = (MenuItem)e.OriginalSource;
            string g = mi.Header.ToString();

            for (int i = 0; i < WindowSwitchers.Items.Count; i++)
            {
                MenuItem mitem = (MenuItem)WindowSwitchers.Items[i];
                if (mitem.Header.ToString().Equals(g))
                    mitem.IsChecked = true;
                else
                    mitem.IsChecked = false;
            }
            // Set SwitchMode as Immediate
            if (g.StartsWith("Immediate"))
                DockingManager.SwitchMode = SwitchMode.Immediate;
            // Set SwitchMode as List
            else if (g.StartsWith("List"))
                DockingManager.SwitchMode = SwitchMode.List;
            // Set SwitchMode as QuickTabs
            else if (g.StartsWith("QuickTabs"))
                DockingManager.SwitchMode = SwitchMode.QuickTabs;
            // Set SwitchMode as VS2005
            else if (g.StartsWith("VS2005"))
                DockingManager.SwitchMode = SwitchMode.VS2005;
            // Set SwitchMode as VistaFlip
            else if (g.StartsWith("VistaFlip"))
                DockingManager.SwitchMode = SwitchMode.VistaFlip;
        }

        /// <summary>
        /// Click event for containermode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContainerMode_Click(object sender, RoutedEventArgs e)
        {
            //Changing Container Mode
            MenuItem menuItem = sender as MenuItem;
            // Set ContainerMode as MDI
            if (menuItem.Name == "ContainerModeMDI")
            {
                DockingManager.ContainerMode = DocumentContainerMode.MDI;
                ContainerModeMDI.IsChecked = true;
                ContainerModeTDI.IsChecked = false;
            }
            // Set ContainerMode as TDI
            else if (menuItem.Name == "ContainerModeTDI")
            {
                DockingManager.ContainerMode = DocumentContainerMode.TDI;
                ContainerModeMDI.IsChecked = false;
                ContainerModeTDI.IsChecked = true;
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// Event log.
        /// </summary>
        /// <param name="prop"></param>
        public void AddToLog(string prop)
        {
            TextBlock tt = new TextBlock();
            tt = new TextBlock();
            tt.FontSize = 12;
            tt.Text = prop + "Occured";
            evntlog.Children.Add(tt);
            Scroll.ScrollToBottom();
        }

        /// <summary>
        /// WindowVisibility changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_WindowVisibilityChanged(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }
        /// <summary>
        /// WindowActivated changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_WindowActivated(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }
        /// <summary>
        /// WindowDeactivated changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_WindowDeactivated(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }
        /// <summary>
        /// WindowDrag end event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_WindowDragEnd(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }
        /// <summary>
        /// WindowDrag start event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_WindowDragStart(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }
        /// <summary>
        /// BeforeContextMenuOpen event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_BeforeContextMenuOpen(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }
        /// <summary>
        /// AutoHideAnimation start event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_AutoHideAnimationStart(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }
        /// <summary>
        /// AutoHideAnimation stop event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_AutoHideAnimationStop(object sender, RoutedEventArgs e)
        {
            AddToLog(e.RoutedEvent.ToString());
        }


        #endregion

      

        private void window1_Loaded(object sender, RoutedEventArgs e)
        {
            SkinStorage.SetVisualStyle(this, "Metro");
        }

       

       

    }
}
