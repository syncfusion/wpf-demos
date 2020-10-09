#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
