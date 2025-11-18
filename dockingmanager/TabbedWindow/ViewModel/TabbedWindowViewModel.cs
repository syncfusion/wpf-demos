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
