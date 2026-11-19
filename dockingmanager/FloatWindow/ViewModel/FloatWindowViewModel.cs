using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class FloatWindowViewModel : NotificationObject
    {
        private DoubleClickAction doubleClickAction= DoubleClickAction.DockOrFloat;
        private bool showFloatWindowInTaskbar = false;

        public DoubleClickAction DoubleClickAction
        {
            get
            {
                return
                    doubleClickAction;
            }
            set
            {
                doubleClickAction = value;
                this.RaisePropertyChanged(nameof(DoubleClickAction));
            }
        }
        
        public bool ShowFloatWindowInTaskbar
        {
            get
            {
                return showFloatWindowInTaskbar;
            }
            set
            {
                showFloatWindowInTaskbar = value;
                this.RaisePropertyChanged(nameof(ShowFloatWindowInTaskbar));
            }
        }
        public FloatWindowViewModel()
        {
        }
    }
}
