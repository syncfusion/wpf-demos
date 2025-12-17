using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class AutoHideViewModel : NotificationObject
    {
        private bool showPin = true;

        public bool ShowPin
        {
            get
            {
                return this.showPin;
            }
            set
            {
                this.showPin = value;
                this.RaisePropertyChanged(nameof(this.ShowPin));
            }
        }
    }
}
