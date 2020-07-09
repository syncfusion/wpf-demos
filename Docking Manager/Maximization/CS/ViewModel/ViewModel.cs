#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaximizeDemo
{
    public class ViewModel : NotificationObject
    {
        private ICommand submenuOpened;
        public ICommand SubmenuOpened
        {
            get
            {
                return submenuOpened;
            }
            set
            {
                submenuOpened = value;
                RaisePropertyChanged("SubmenuOpened");
            }
        }
        public ICommand Docking
        {
            get;
            set;
        }
       
        public DockingManager dockingManager
        {
            get;
            set;
        }

        private ICommand maximizeModeChanged;
        public ICommand MaximizeModeChanged
        {
            get
            {
                return maximizeModeChanged;
            }
            set
            {
                maximizeModeChanged = value;
                RaisePropertyChanged("MaximizeModeChanged");
            }
        }
        private ICommand activewindow_SubmenuOpened;
        public ICommand Activewindow_SubmenuOpened
        {
            get
            {
                return activewindow_SubmenuOpened;
            }
            set
            {
                activewindow_SubmenuOpened = value;
                RaisePropertyChanged("Activewindow_SubmenuOpened");
            }
        }
        private ICommand maxMinChanged;
        public ICommand MaxMinChanged
        {
            get
            {
                return maxMinChanged;
            }
            set
            {
                maxMinChanged = value;
                RaisePropertyChanged("MaxMinChanged");
            }
        }
        public ViewModel()
        {
            SubmenuOpened = new DelegateCommand<object>(MaximizeMode_SubmenuOpened);
            MaximizeModeChanged = new DelegateCommand<object>(OnMaximizeModeChanged);
            Activewindow_SubmenuOpened= new DelegateCommand<object>(OnActivewindow_SubmenuOpened);
            MaxMinChanged = new DelegateCommand<object>(OnMaxMinChanged);
            Docking = new DelegateCommand<object>(Loaded);
        }

        private void Loaded(object parameter)
        {
            dockingManager = (parameter as DockingManager);
        }

        public void MaximizeMode_SubmenuOpened(object parameter)
        {
            MenuItem item = parameter as MenuItem;

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
        public void OnMaximizeModeChanged(object parameter)
        {
            MenuItem item = parameter as MenuItem;
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
        private void OnActivewindow_SubmenuOpened(object parameter)
        {
            if (dockingManager.ActiveWindow != null)
            {
                MenuItem item = parameter as MenuItem;
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
        private void OnMaxMinChanged(object parameter)
        {
            if (dockingManager.ActiveWindow != null)
            {
                MenuItem item = parameter as MenuItem;
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
    }
}
