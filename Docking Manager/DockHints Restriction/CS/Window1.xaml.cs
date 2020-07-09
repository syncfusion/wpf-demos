#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Threading;
using System.Timers;
using System.Windows.Threading;

namespace DockAbilityDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
       
        #region Constructor
        /// <summary>
        /// Constructor for window1.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            this.dockingManager.Loaded += DockingManager_Loaded;
            (this.dockingManager.DocContainer as DocumentContainer).Loaded += Window1_Loaded;           
        }

        private void DockingManager_Loaded(object sender, RoutedEventArgs e)
        {
            DockingManager.SetState(properties, DockState.Float);
            DockingManager.SetFloatingWindowRect(properties, new Rect(590, 345, 250, 300));
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as DocumentContainer).CreateVerticalTabGroup(features);
        }

        #endregion

        private void dockingManager_PreviewDockHints(object sender, PreviewDockHintsEventArgs e)
        {
            if(e.DraggingTarget != null)
            {
                if (e.DraggingSource == properties)
                {
                    e.DockAbility = DockAbility.None;
                }
                else if (e.DraggingTarget == toolBox)
                {
                    e.DockAbility = DockAbility.Left;
                }
                else if (e.DraggingTarget == serverExplorer)
                {
                    e.DockAbility = DockAbility.Horizontal;
                }
                else if (e.DraggingTarget == bottomWindow)
                {
                    e.DockAbility = DockAbility.All;
                }
                else if (e.DraggingTarget == solutionExplorer)
                {
                    e.DockAbility = DockAbility.Top;
                }
                else if (e.DraggingTarget == teamExplorer)
                {
                    e.DockAbility = DockAbility.None;
                }
                else if(e.DraggingTarget == startPage)
                {
                    e.DockAbility = DockAbility.DocumentAll;
                }
                else if (e.DraggingTarget == features)
                {
                    e.DockAbility = DockAbility.Horizontal | DockAbility.Vertical;
                }
                else if (e.DraggingTarget == integration)
                {
                    e.DockAbility = DockAbility.DockAll;
                }
                else if (e.DraggingTarget == tabbedWindow)
                {
                    e.DockAbility = DockAbility.DockTabbed;
                }
                else
                {
                    e.DockAbility = DockAbility.All;
                }
            }
        }
    }
}