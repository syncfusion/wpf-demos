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
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class MDIViewModel: NotificationObject
    {
        private ICommand switchModeChange;
        public ICommand SwitchModeChangeAction
        {
            get
            {
                return switchModeChange;
            }
            set
            {
                switchModeChange = value;
            }
        }

        public MDIViewModel()
        {
            switchModeChange = new DelegateCommand<object>(ChangeSwitchMode);
        }

        private void ChangeSwitchMode(object obj)
        {
            if (obj != null)
            {
                switch (obj.ToString())
                {
                    case "Immediate":
                    case "List":
                    case "QuickTabs":
                    case "VS2005":
                    case "VistaFlip":
                        {
                            this.SwitchMode = (SwitchMode)Enum.Parse(typeof(SwitchMode), obj.ToString());
                            break;
                        }
                }
            }
        }

        private SwitchMode switchMode = SwitchMode.Immediate;

        public SwitchMode SwitchMode
        {
            get { return switchMode; }
            set
            {
                switchMode = value;
                this.RaisePropertyChanged(nameof(this.SwitchMode));
            }
        }
    }
}
