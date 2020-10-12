#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class DockChildMaximizationViewModel : NotificationObject
    {
        public DockChildMaximizationViewModel()
        {
            this.MaximizeModeChangeAction = new DelegateCommand<object>(ChangeMaximizeMode);
        }

        private void ChangeMaximizeMode(object obj)
        {
            if (obj != null)
            {
                switch (obj.ToString())
                {
                    case "FullScreen":
                    case "Default":
                        this.MaximizeMode = (MaximizeMode)Enum.Parse(typeof(MaximizeMode), obj.ToString());
                        break;
                }
            }
        }

        private MaximizeMode maximizeMode = MaximizeMode.Default;

        public MaximizeMode MaximizeMode
        {
            get { return maximizeMode; }
            set
            {
                maximizeMode = value; this.RaisePropertyChanged(nameof(MaximizeMode));
            }
        }

        private ICommand maximizeModeChangeAction;

        public ICommand MaximizeModeChangeAction
        {
            get { return maximizeModeChangeAction; }
            set { maximizeModeChangeAction = value; }
        }

    }
}
