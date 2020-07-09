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
using System.Windows.Controls;
using System.Windows.Input;

namespace DockingDemo
{
    public class ViewModel: NotificationObject
    {
        private DocumentContainerMode containerMode = DocumentContainerMode.MDI;
        public DocumentContainerMode ContainerMode
        {
            get
            {
                return containerMode;
            }
            set
            {
                containerMode = value;
                RaisePropertyChanged("ContainerMode");
            }
        }
        private SwitchMode switchMode = SwitchMode.Immediate;
        public SwitchMode SwitchMode
        {
            get
            {
                return switchMode;
            }
            set
            {
                switchMode = value;
                RaisePropertyChanged("SwitchMode");
            }
        }
        private ICommand containerMode1;
        public ICommand ContainerMode1
        {
            get
            {
                return containerMode1;
            }
            set
            {
                containerMode1 = value;
                RaisePropertyChanged("ContainerMode1");
            }
        }
        private ICommand switchMode1;
        public ICommand SwitchMode1
        {
            get
            {
                return switchMode1;
            }
            set
            {
                switchMode1 = value;
                RaisePropertyChanged("SwitchMode1");
            }
        }
        public DockingManager DockingManager
        {
            get;
            set;
        }
        public ICommand Docking
        {
            get;
            set;
        }



        public ViewModel()
        {
            ContainerMode1 = new DelegateCommand<object>(ContainerMode_Click);
            switchMode1 = new DelegateCommand<object>(windowswitchers_Click);
            Docking = new DelegateCommand<object>(Loaded);

        }

        public void ContainerMode_Click(object parameter)
        {
           //Changing Container Mode
            MenuItem menuItem = parameter as MenuItem;
            // Set ContainerMode as MDI
            if (menuItem.Name == "ContainerModeMDI")
            {
                if (menuItem.IsChecked )
                {
                    DockingManager.ContainerMode = DocumentContainerMode.MDI;
                }
                else
                {
                    DockingManager.ContainerMode = DocumentContainerMode.TDI;
                }
            }
            // Set ContainerMode as TDI
            else if (menuItem.Name == "ContainerModeTDI")
            {
               // DockingManager.ContainerMode = DocumentContainerMode.TDI;
               
                menuItem.IsChecked = !menuItem.IsChecked;
                if(menuItem.IsChecked)
                {
                    DockingManager.ContainerMode = DocumentContainerMode.TDI;
                }
                else
                {
                    DockingManager.ContainerMode = DocumentContainerMode.MDI;
                }

            }

        }

        public void windowswitchers_Click(object parameter)
        {
            //Switch Mode of Docking Manager
            MenuItem mi = (MenuItem)parameter;
            string g = mi.Header.ToString();

            if (g.StartsWith("Immediate")&&mi.IsChecked)
                DockingManager.SwitchMode = SwitchMode.Immediate;
            // Set SwitchMode as List
            else if (g.StartsWith("List") && mi.IsChecked)
                DockingManager.SwitchMode = SwitchMode.List;
            // Set SwitchMode as QuickTabs
            else if (g.StartsWith("QuickTabs") && mi.IsChecked)
                DockingManager.SwitchMode = SwitchMode.QuickTabs;
            // Set SwitchMode as VS2005
            else if (g.StartsWith("VS2005") && mi.IsChecked)
                DockingManager.SwitchMode = SwitchMode.VS2005;
            // Set SwitchMode as VistaFlip
            else if (g.StartsWith("VistaFlip") && mi.IsChecked)
                DockingManager.SwitchMode = SwitchMode.VistaFlip;
            else
            {
                DockingManager.SwitchMode = SwitchMode.Immediate;
            }

        }

        public void Loaded(object parameter)
        {
            DockingManager = parameter as DockingManager;
        }
    }
}
