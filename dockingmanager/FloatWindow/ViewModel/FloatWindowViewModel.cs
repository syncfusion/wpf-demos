#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
