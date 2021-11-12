#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class TabbedWindowViewModel : NotificationObject
    {   
        private Dock dockTabAlignment = Dock.Bottom;

        public Dock DockTabAlignment
        {
            get 
            { 
                return this.dockTabAlignment; 
            }
            set
            {
                this.dockTabAlignment = value;
                this.RaisePropertyChanged(nameof(DockTabAlignment));
            }
        }

        private AutoHideTabsMode tabsMode;

        public AutoHideTabsMode AutoHideTabsMode
        {
            get { return tabsMode; }
            set { tabsMode = value; this.RaisePropertyChanged(nameof(this.AutoHideTabsMode)); }
        } 
        
        private CloseTabsMode closeTabs;

        public CloseTabsMode CloseTabs
        {
            get { return closeTabs; }
            set { closeTabs = value; this.RaisePropertyChanged(nameof(this.CloseTabs)); }
        }

        public TabbedWindowViewModel()
        {
        }
    }
}
